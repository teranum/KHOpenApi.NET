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

        private static void ParsingTRData(ref TrProp trProp, string ansiText)
        {
            if (_trDescDatas.TryGetValue(trProp.TRCode, out var input_infos))
            {
                if (input_infos.Count >= 2 && input_infos[1].Key.Equals("주의"))
                {
                    trProp.Caution = input_infos[1].Value;
                }
            }

            int nLen = ansiText.Length;
            // [INPUT]
            int nPos = 0;
            int nPosEnd = 0;
            nPos = ansiText.IndexOf("[INPUT]", nPos);
            nPos = ansiText.IndexOf("@START_", nPos);
            nPos += "@START_".Length;
            nPosEnd = ansiText.IndexOf("\r\n", nPos);
            string TRName = ansiText[nPos..nPosEnd];
            trProp.TRName = TRName;
            nPos = nPosEnd + "\r\n".Length;
            nPosEnd = ansiText.IndexOf("@END_", nPos);
            string InputBody = ansiText[nPos..nPosEnd];
            var inputKeySizes = GetKeySizes(InputBody);

            foreach (var keySize in inputKeySizes)
            {
                var desc = string.Empty;
                if (input_infos != null)
                {
                    var info = input_infos.FirstOrDefault(x => x.Key.Equals(keySize.Item1));
                    if (info.Key != null)
                        desc = info.Value;
                }
                trProp.Inputs.Add(new(keySize.Item1, keySize.Item2, desc));
            }
            // [OUTPUT]
            nPos = nPosEnd;
            nPos = ansiText.IndexOf("[OUTPUT]", nPos);
            nPos = ansiText.IndexOf("@START_", nPos);
            nPosEnd = ansiText.IndexOf('=', nPos);
            string OutName, OutIdent;
            OutName = ansiText.Substring(nPos + 7, nPosEnd - nPos - 7);
            nPos = nPosEnd + 1;
            nPosEnd = ansiText.IndexOf("\r\n", nPos);
            OutIdent = ansiText[nPos..nPosEnd];
            nPos = nPosEnd + "\r\n".Length;
            nPosEnd = ansiText.IndexOf("@END_", nPos);
            string namebody = ansiText[nPos..nPosEnd];
            if (OutIdent.Equals("*,*,*"))
            {
                var singleKeySizes = GetKeySizes(namebody);
                foreach (var keySize in singleKeySizes)
                {
                    trProp.OutputSingle.Add(new(keySize.Item1, keySize.Item2, string.Empty));
                }
                nPos = nPosEnd + "\r\n".Length;
                nPos = ansiText.IndexOf("@START_", nPos);
                if (nPos != -1)
                {
                    nPosEnd = ansiText.IndexOf("\r\n", nPos);
                    nPos = nPosEnd + "\r\n".Length;
                    nPosEnd = ansiText.IndexOf("@END_", nPos);
                    string ortherbody = ansiText[nPos..nPosEnd];
                    var multiKeySizes = GetKeySizes(ortherbody);
                    foreach (var keySize in multiKeySizes)
                    {
                        trProp.OutputMuti.Add(new(keySize.Item1, keySize.Item2, string.Empty));
                    }
                }
            }
            else
            {
                var multiKeySizes = GetKeySizes(namebody);
                foreach (var keySize in multiKeySizes)
                {
                    trProp.OutputMuti.Add(new(keySize.Item1, keySize.Item2, string.Empty));
                }
            }
            // Caution and InputDescs
            string section = trProp.TRCode + " : " + trProp.TRName;

            //trProp.Caution = GetProfileString(section, "주의", szIniFilePath);
            //trProp.InputDescs = trProp.Inputs.Select(x => GetProfileString(section, x, szIniFilePath)).ToList();

            static List<(string, int)> GetKeySizes(string s)
            {
                List<(string, int)> sections = [];
                string[] lines = s.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    int pos = line.IndexOf('=');
                    if (pos != -1)
                    {
                        var key = line[..pos].Trim();
                        var values = line[(pos + 1)..].Split(',').ToList();
                        int fieldSize = 0;
                        if (values.Count > 1)
                        {
                            if (int.TryParse(values[1], out int size))
                                fieldSize = size;
                        }
                        sections.Add((key, fieldSize));
                    }
                }
                return sections;
            }
        }
        //private static TrProp? LoadTRData(string filepath, IList<string> Errors)
        //{
        //    string fileTitle = Path.GetFileNameWithoutExtension(filepath).ToUpper();
        //    try
        //    {
        //        using var file = File.OpenRead(filepath);
        //        using var zip = new ZipArchive(file, ZipArchiveMode.Read);
        //        foreach (var entry in zip.Entries)
        //        {
        //            string entruTitle = entry.Name[..^4];
        //            if (entruTitle.Equals(fileTitle))
        //            {
        //                using var stream = entry.Open();
        //                byte[] buffer = new byte[entry.Length];
        //                _ = stream.Read(buffer, 0, buffer.Length);
        //                stream.Close();
        //                string ansiText = _krEncoder.GetString(buffer);
        //                TrProp trData = new(filepath, ansiText);
        //                ParsingTRData(ref trData, ansiText);
        //                return trData;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        /*
        //        0195 : 매도평균가      = 083, 20, 0, A ; "004" -> 매수평균가      = 083, 20, 0, A ; "004"
        //         */
        //        Errors.Add($"Error: {filepath} : {ex.Message}");
        //    }

        //    return null;
        //}

        private static Dictionary<string, IList<KeyValuePair<string, string>>> _trDescDatas = [];

        /// <summary>모든 TR리스트 불러오기</summary>
        public static void LoadAllTRLists(string apiFolderPath)
        {
            _errors.Clear();
            if (_allTrInfos.Count > 0) return;

            _trDescDatas.Clear();
            var koatrinputlegend_path = apiFolderPath + "\\koatrinputlegend.ini";
            if (File.Exists(koatrinputlegend_path))
            {
                var lines = File.ReadAllLines(koatrinputlegend_path, _krEncoder);
                string section = "";
                List<KeyValuePair<string, string>>? infos = null;
                foreach (var line in lines)
                {
                    if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        if (infos != null)
                        {
                            _trDescDatas[section] = infos;
                        }
                        infos = null;
                        var section_names = line[1..^1].Split(':');
                        if (section_names.Length == 2)
                        {
                            section = section_names[0].Trim();
                            var name = section_names[1].Trim();
                            infos = [new("TRName", name)];
                        }
                    }
                    else
                    {
                        if (infos != null)
                        {
                            var keyValues = line.Split('=');
                            if (keyValues.Length == 2)
                            {
                                var key = keyValues[0].Trim();
                                var value = keyValues[1].Trim();
                                if (key.Equals("주의"))
                                {
                                    infos.Insert(1, new(key, value));
                                }
                                else
                                    infos.Add(new(key, value));
                            }
                        }
                    }
                }

                if (infos != null)
                {
                    _trDescDatas[section] = infos;
                }
            }

            try
            {
                /// ENC파일 읽기
                /// 폴더에서 ENC파일 검색후
                /// 압축해제
                /// 파일네임과 동일한 압축파일에서 읽기

                // api폴더 설정
                string path = apiFolderPath + "\\data";
                if (!Directory.Exists(path)) return;

                //// 폴더내의 전체 enc파일 불러온다
                //string[] filepaths = Directory.GetFiles(path, "*.enc");
                //if (filepaths.Length == 0)
                //{
                //    _errors.Add("TR dat files Not Found");
                //    return;
                //}

                foreach (var trDesc in _trDescDatas)
                {
                    var trCode = trDesc.Key;
                    var input_infos = trDesc.Value;

                    var trName = input_infos[0].Value;
                    var trData = new TrProp($"{apiFolderPath}\\{trCode}.enc", trCode, trName);
                    if (trData == null) continue;

                    _allTrInfos.Add(trData);
                    if (_codeToTrData.TryGetValue(trData.TRCode, out var existTrData))
                    {
                        _errors.Add($"Exist aleady : {existTrData.TRCode} : {existTrData.FilePath} ");
                    }
                    else
                        _codeToTrData.Add(trData.TRCode, trData);

                    //var trData = LoadTRData(filepath, _errors);
                    //if (trData == null) continue;

                    //_allTrInfos.Add(trData);
                    //if (_codeToTrData.TryGetValue(trData.TRCode, out var existTrData))
                    //{
                    //    _errors.Add($"Exist aleady : {existTrData.TRCode} : {existTrData.FilePath}, {filepath} ");
                    //}
                    //else
                    //    _codeToTrData.Add(trData.TRCode, trData);
                    //int.TryParse(trData.TRCode, out var realType);
                    //if (realType != 0)
                    //{
                    //    if (_realtypeToTrData.TryGetValue(realType, out var existRealTr))
                    //    {
                    //        _errors.Add($"Exist RealType aleady : {existRealTr.TRCode} : {existRealTr.FilePath}, {filepath} ");
                    //    }
                    //    else
                    //        _realtypeToTrData.Add(realType, trData);
                    //}
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
