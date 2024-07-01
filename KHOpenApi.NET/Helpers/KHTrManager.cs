using KHOpenApi.NET.Models;
using System.Text;

namespace KHOpenApi.NET.Helpers
{
    /// <summary>TR 요청 종류 클래스</summary>
    public static class KHTrManager
    {
        private static readonly Encoding _krEncoder = Encoding.GetEncoding("EUC-KR");
        private static readonly Dictionary<string, TrProp> _codeToTrData = [];
        private static readonly Dictionary<int, TrProp> _realtypeToTrData = [];
        private static readonly List<TrProp> _allTrInfos = [];
        private static readonly List<string> _errors = [];
        /// <summary>오류 리스트</summary>
        public static IReadOnlyList<string> Errors => _errors;

        /// <summary>TR정보 리스트</summary>
        public static IReadOnlyList<TrProp> AllTrInfos => _allTrInfos;
        /// <summary>코드에 해당되는 TR가져오기</summary>
        public static TrProp? GetTrProp(string Code)
        {
            if (_codeToTrData.TryGetValue(Code, out var trData))
            {
                return trData;
            }
            return null;
        }

        /// <summary>실시간타입에 해당되는 TR가져오기</summary>
        public static TrProp? GetTrProp(int realtype)
        {
            if (_realtypeToTrData.TryGetValue(realtype, out var trData))
            {
                return trData;
            }
            return null;
        }

        private static void ParsingTRData(ref TrProp trData, string ansiText)
        {
            // [TRINFO]
            char[] separator = ['\r', '\n'];
            var lines = ansiText.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            TRSECTION trSection = TRSECTION.NONE;
            string key = string.Empty;
            string value = string.Empty;
            foreach (string line in lines)
            {
                if (line.IndexOf("[TRINFO]") == 0)
                    trSection = TRSECTION.TRINFO;
                else if (line.IndexOf("[INPUT]") == 0)
                    trSection = TRSECTION.INPUT;
                else if (line.IndexOf("[OUTPUT]") == 0)
                    trSection = TRSECTION.OUTPUT;
                else if (line.IndexOf("@START_OutRec1") == 0)
                {
                    trSection = TRSECTION.OUTREC1;
                    if (SplitKeyValue(line, ref key, ref value))
                    {
                        var vals = value.Split(',');
                        if (vals.Length > 1 && int.TryParse(vals[1], out int digit))
                            trData.OutRec1RowCountDigit = digit;
                    }
                }
                else if (line.IndexOf("@END_OutRec1") == 0)
                    trSection = TRSECTION.END1;
                else if (line.IndexOf("@START_OutRec2") == 0)
                {
                    trSection = TRSECTION.OUTREC2;
                    if (SplitKeyValue(line, ref key, ref value))
                    {
                        var vals = value.Split(',');
                        if (vals.Length > 1 && int.TryParse(vals[1], out int digit))
                            trData.OutRec2RowCountDigit = digit;
                    }
                }
                else if (line.IndexOf("@END_OutRec2") == 0)
                    trSection = TRSECTION.END2;
                else
                {
                    if (line[0] != ';' && SplitKeyValue(line, ref key, ref value, trSection == TRSECTION.INPUT || trSection == TRSECTION.OUTREC1 || trSection == TRSECTION.OUTREC2))
                    {
                        if (trSection == TRSECTION.TRINFO)
                        {
                            if (string.Equals(key, "TRName")) trData.TRName = value;
                            else if (string.Equals(key, "OutputCnt")) trData.OutputCnt = Convert.ToInt32(value);
                            else if (string.Equals(key, "DataHeader")) trData.DataHeader = Convert.ToInt32(value);
                        }
                        else if (trSection == TRSECTION.INPUT)
                        {
                            var vals = value.Split(',');
                            int size = Convert.ToInt32(vals[1]);
                            string desc = string.Empty;
                            var val_desc = value.Split(';');
                            if (val_desc.Length >= 2)
                            {
                                desc = val_desc[1].Trim();
                            }

                            trData.INPUTs.Add(new(key, size, desc));
                        }
                        else if (trSection == TRSECTION.OUTPUT)
                        {
                            var vals = value.Split(',');
                            int size = Convert.ToInt32(vals[1]);
                            string desc = string.Empty;
                            var val_desc = value.Split(';');
                            if (val_desc.Length >= 2)
                            {
                                desc = val_desc[1].Trim();
                            }

                            trData.OUTPUTs.Add(new(key, size, desc));
                            trData.OutputTotalSize += size;
                        }
                        else if (trSection == TRSECTION.OUTREC1)
                        {
                            var vals = value.Split(',');
                            int size = Convert.ToInt32(vals[1]);
                            string desc = string.Empty;
                            var val_desc = value.Split(';');
                            if (val_desc.Length >= 2)
                            {
                                desc = val_desc[1].Trim();
                            }

                            trData.OutRec1s.Add(new(key, size, desc));
                            trData.OutRec1TotalSize += size;
                        }
                        else if (trSection == TRSECTION.OUTREC2)
                        {
                            var vals = value.Split(',');
                            int size = Convert.ToInt32(vals[1]);

                            trData.OutRec2s.Add(new(key, size, string.Empty));
                            trData.OutRec2TotalSize += size;
                        }
                    }
                }
            }

            var Code = trData.TRCode;
            trData.DefReqData = PreDefineReqs.FirstOrDefault(x => x.Code.Equals(Code));

            if (trData.DefReqData == null)
            {
                // 디폴트 목록에 없는 TR경우

                if (int.TryParse(trData.TRCode, out int realtype))
                {
                    trData.DefReqData = new REQKindClass(trData.TRCode, REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.공통, REQKIND_SUB.시세, false);
                }
                //else if (trData.TRCode.Length > 0 && trData.TRCode[0] == 'g')
                //{
                //    trData.DefReqData = new(trData.TRCode, REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.공통, REQKIND_SUB.TR, false);
                //}
            }

            bool SplitKeyValue(string text, ref string key, ref string value, bool bFullValue = false)
            {
                // ex DataHeader=5; 2:해외주문, 3:해외조회, 4:국내주문, 5:국내조회
                // out: (DataHeader, 5)
                char[] separator = bFullValue ? ['=',] : ['=', ';'];
                var key_value = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if (key_value.Length < 2) return false;
                key = key_value[0].Trim();
                value = key_value[1].Trim();
                return true;
            }
        }
        private static TrProp LoadTRData(string filepath, IList<string> Errors)
        {
            TrProp trData = new(filepath);
            try
            {
                byte[] fileData = File.ReadAllBytes(filepath);
                string ansiText = _krEncoder.GetString(fileData, 0, fileData.Length);

                ParsingTRData(ref trData, ansiText);
            }
            catch (Exception ex)
            {
                /*
                0195 : 매도평균가      = 083, 20, 0, A ; "004" -> 매수평균가      = 083, 20, 0, A ; "004"
                 */
                Errors.Add($"Error: {filepath} : {ex.Message}");
            }
            return trData;
        }

        /// <summary>모든 TR리스트 불러오기</summary>
        public static void LoadAllTRLists(string apiFolderPath)
        {
            _errors.Clear();
            if (_allTrInfos.Count > 0) return;

            var defReqs = PreDefineReqs;

            try
            {
                // api폴더 설정
                string path = apiFolderPath + "\\TrData";

                // 폴더내의 전체 dat파일 불러온다
                string[] filepaths = Directory.GetFiles(path, "*.dat");
                if (filepaths.Length == 0)
                {
                    _errors.Add("TR dat files Not Found");
                    return;
                }

                foreach (var filepath in filepaths)
                {
                    var trData = LoadTRData(filepath, _errors);

                    _allTrInfos.Add(trData);
                    if (_codeToTrData.TryGetValue(trData.TRCode, out var existTrData))
                    {
                        _errors.Add($"Exist aleady : {existTrData.TRCode} : {existTrData.FilePath}, {filepath} ");
                    }
                    else
                        _codeToTrData.Add(trData.TRCode, trData);
                    int.TryParse(trData.TRCode, out var realType);
                    if (realType != 0)
                    {
                        if (_realtypeToTrData.TryGetValue(realType, out var existRealTr))
                        {
                            _errors.Add($"Exist RealType aleady : {existRealTr.TRCode} : {existRealTr.FilePath}, {filepath} ");
                        }
                        else
                            _realtypeToTrData.Add(realType, trData);
                    }
                }
            }
            catch (Exception ex)
            {
                _errors.Add(ex.Message);
            }
            return;
        }

        /// <summary>미리 정의된 TR요청 종류</summary>
        public static readonly REQKindClass[] PreDefineReqs =
            [
                // 주문
                // 국내
                new("g12001.DO1601&", REQKIND_FUNC.CommJumunSvr, REQKIND_MASTER.주문, REQKIND_MAIN.국내, REQKIND_SUB.None, true),
                new("g12001.DO1901&", REQKIND_FUNC.CommJumunSvr, REQKIND_MASTER.주문, REQKIND_MAIN.국내, REQKIND_SUB.None, true),
                new("g12001.DO1701&", REQKIND_FUNC.CommJumunSvr, REQKIND_MASTER.주문, REQKIND_MAIN.국내, REQKIND_SUB.None, true),
                new("g12001.DO2201&", REQKIND_FUNC.CommJumunSvr, REQKIND_MASTER.주문, REQKIND_MAIN.국내, REQKIND_SUB.None, true),
                new("g12001.DO2101&", REQKIND_FUNC.CommJumunSvr, REQKIND_MASTER.주문, REQKIND_MAIN.국내, REQKIND_SUB.None, true),
                new("g12001.DO2001&", REQKIND_FUNC.CommJumunSvr, REQKIND_MASTER.주문, REQKIND_MAIN.국내, REQKIND_SUB.None, true),
                // 해외
                new("g12003.AO0401%", REQKIND_FUNC.CommJumunSvr, REQKIND_MASTER.주문, REQKIND_MAIN.해외, REQKIND_SUB.None, true),
                new("g12003.AO0402%", REQKIND_FUNC.CommJumunSvr, REQKIND_MASTER.주문, REQKIND_MAIN.해외, REQKIND_SUB.None, true),
                new("g12003.AO0403%", REQKIND_FUNC.CommJumunSvr, REQKIND_MASTER.주문, REQKIND_MAIN.해외, REQKIND_SUB.None, true),
                // FX
                new("g12003.AO0501%", REQKIND_FUNC.CommJumunSvr, REQKIND_MASTER.주문, REQKIND_MAIN.FX, REQKIND_SUB.None, true),
                new("g12003.AO0502%", REQKIND_FUNC.CommJumunSvr, REQKIND_MASTER.주문, REQKIND_MAIN.FX, REQKIND_SUB.None, true),
                new("g12003.AO0503%", REQKIND_FUNC.CommJumunSvr, REQKIND_MASTER.주문, REQKIND_MAIN.FX, REQKIND_SUB.None, true),

                // 조회
                // 국내
                new("g11002.DQ0104&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR, true),
                new("g11002.DQ0107&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR, true),
                new("g11002.DQ0110&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR, true),
                new("g11002.DQ1305&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR, true),
                new("g11002.DQ0116&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR, true),
                new("g11002.DQ0119&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR, true),
                new("g11002.DQ0122&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR, true),
                new("g11002.DQ1306&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR, true),
                new("g11002.DQ0125&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR, true),
                new("g11002.DQ1303&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR, true),
                new("g11002.DQ0217&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR, true),
                new("g11002.DQ0242&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR, true),
                new("g11002.DQ0502&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR, true),
                new("g11002.DQ0509&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR, true),
                new("g11002.DQ0521&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR, true),
                new("g11002.DQ0622&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR),
                new("g11002.DQ1211&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR),
                new("g11002.DQ1302&", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR),
                new("v90003", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.TR),
                new("l41600", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.FID),
                new("l41601", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.FID),
                new("l41602", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.FID),
                new("l41603", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.FID),
                new("l41619", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.FID),
                new("s20001", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.FID),
                new("s31001", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.FID),
                new("s10001", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.FID),
                new("l41700", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.국내, REQKIND_SUB.FID),

                // 해외
                new("g11004.AQ0128%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR),
                new("g11004.AQ0301%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0302%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0401%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0402%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0403%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0404%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0405%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0408%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0409%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0415%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0450%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                //new("g11004.AQ0495%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR), // 공통에 들어가 있음
                new("g11004.AQ0602%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0605%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0607%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0636%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR),
                new("g11004.AQ0712%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0715%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR),
                new("g11004.AQ0725%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR),
                new("g11004.AQ0805%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0824%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0807%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0451%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("o44005", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR),
                new("o51000", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.FID),
                new("o51010", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.FID),
                new("o51200", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.FID),
                new("o51210", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.FID),
                // 추가
                new("o44010", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR),
                // FX
                new("g11004.AQ0901%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0904%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0906%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0908%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0910%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0911%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0914%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0920%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("g11004.AQ0923%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.TR, true),
                new("x00001", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.FID),
                new("x00002", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.FID),
                new("x00003", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.FID),
                new("x00004", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.FID),
                new("x00005", REQKIND_FUNC.CommFIDRqData, REQKIND_MASTER.조회, REQKIND_MAIN.해외, REQKIND_SUB.FID),
                // 공통
                new("g11004.AQ0495%", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.공통, REQKIND_SUB.None, true),
                new("n51000", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.공통, REQKIND_SUB.None),
                new("n51001", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.공통, REQKIND_SUB.None),
                new("n51003", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.공통, REQKIND_SUB.None),
                new("n51006", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.공통, REQKIND_SUB.None),
                new("o44011", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.공통, REQKIND_SUB.None),
                new("v90001", REQKIND_FUNC.CommRqData, REQKIND_MASTER.조회, REQKIND_MAIN.공통, REQKIND_SUB.None),

                // 실시간
                // 국내
                new("0051", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.시세),
                new("0052", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.시세),
                new("0058", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.시세),
                new("0059", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.시세),
                new("0065", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.시세),
                new("0066", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.시세),
                new("0071", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.시세),
                new("0073", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.시세),
                new("0075", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.시세),
                new("0077", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.시세),
                new("0078", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.시세),
                new("0079", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.시세),
                new("0056", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.시세),
                new("0068", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.시세),
                new("0101", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.시세),
                new("0310", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.시세),
                new("0120", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.시세),
                new("0181", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.주문),
                new("0182", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.주문),
                new("0183", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.주문),
                new("0184", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.주문),
                new("0185", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.주문),
                new("0211", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.주문),
                new("0212", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.주문),
                new("0213", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.주문),
                new("0261", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.주문),
                new("0262", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.주문),
                new("0265", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.주문),
                new("0271", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.주문),
                new("0273", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.국내, REQKIND_SUB.주문),
                // 해외
                new("0076", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.해외, REQKIND_SUB.시세),
                new("0082", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.해외, REQKIND_SUB.시세),
                new("0241", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.해외, REQKIND_SUB.시세),
                new("0242", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.해외, REQKIND_SUB.시세),
                new("0196", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.해외, REQKIND_SUB.주문),
                new("0186", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.해외, REQKIND_SUB.주문),
                new("0188", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.해외, REQKIND_SUB.주문),
                new("0189", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.해외, REQKIND_SUB.주문),
                new("0190", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.해외, REQKIND_SUB.주문),
                new("0296", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.해외, REQKIND_SUB.주문),
                new("0286", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.해외, REQKIND_SUB.주문),
                new("0289", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.해외, REQKIND_SUB.주문),
                // FX
                new("0171", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.FX, REQKIND_SUB.시세),
                new("0197", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.FX, REQKIND_SUB.주문),
                new("0191", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.FX, REQKIND_SUB.주문),
                new("0192", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.FX, REQKIND_SUB.주문),
                new("0193", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.FX, REQKIND_SUB.주문),
                new("0194", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.FX, REQKIND_SUB.주문),
                new("0195", REQKIND_FUNC.CommSetJumunChe, REQKIND_MASTER.실시간, REQKIND_MAIN.FX, REQKIND_SUB.주문),
                // 공통
                new("-144", REQKIND_FUNC.None, REQKIND_MASTER.실시간, REQKIND_MAIN.공통, REQKIND_SUB.None),
                new("0161", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.공통, REQKIND_SUB.None),
                new("0208", REQKIND_FUNC.CommSetBroad, REQKIND_MASTER.실시간, REQKIND_MAIN.공통, REQKIND_SUB.None),
            ];

        private static REQKindClass? GetPreDefineReq(string Code) => PreDefineReqs.FirstOrDefault(x => x.Code.Equals(Code));
    }

    enum TRSECTION
    {
        NONE,
        TRINFO,
        INPUT,
        OUTPUT,
        OUTREC1,
        END1,
        OUTREC2,
        END2,
    }

}
