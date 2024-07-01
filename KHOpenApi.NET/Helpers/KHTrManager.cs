using KHOpenApi.NET.Models;
using System.IO.Compression;
using System.Text;

namespace KHOpenApi.NET.Helpers
{
    /// <summary>TR 요청 종류 클래스</summary>
    public static class KHTrManager
    {
        private static readonly Encoding _krEncoder = Encoding.GetEncoding("EUC-KR");
        private static readonly Dictionary<string, TrProp> _codeToTrData = [];
        private static readonly Dictionary<string, TrProp> _realtypeToTrData = [];
        private static readonly List<TrProp> _allTrInfos = [];
        private static readonly List<TrProp> _allRInfos = [];
        private static readonly List<string> _errors = [];

        private static readonly Dictionary<string, string> _map_FidToName = [];
        static KHTrManager()
        {
            char[] separator = ['\r', '\n'];
            var filecontent = Properties.Resources.FID_KORNAME;
            string[] FIDLines = filecontent.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int nFIDLines = FIDLines.Length;
            foreach (string line in FIDLines)
            {
                int nPos = line.IndexOf('=');
                if (nPos > 0)
                {
                    string key = line[..nPos];
                    string name = line[(nPos + 1)..];
                    _map_FidToName.Add(key, name);
                }
            }

            var apiPath = OcxPathHelper.GetOcxPathFromClassID(OcxPathHelper.GetClassIDFromProgID("KHOPENAPI.KHOpenAPICtrl.1"));
            if (apiPath != null)
            {
                var apiFolderPath = Path.GetDirectoryName(apiPath);
                if (apiFolderPath != null)
                {
                    LoadAllTRLists(apiFolderPath);
                }
            }
        }
        /// <summary>오류 리스트</summary>
        public static IReadOnlyList<string> Errors => _errors;

        /// <summary>TR 요청 리스트</summary>
        public static IReadOnlyList<TrProp> AllTrInfos => _allTrInfos;

        /// <summary>실시간 요청 리스트</summary>
        public static IReadOnlyList<TrProp> AllRtInfos => _allRInfos;
        /// <summary>코드에 해당되는 TR가져오기</summary>
        public static TrProp? GetTrProp(string Code)
        {
            if (_codeToTrData.TryGetValue(Code, out var trData))
            {
                trData.LoadDetailData();
                return trData;
            }
            return null;
        }

        /// <summary>실시간타입에 해당되는 TR가져오기</summary>
        public static TrProp? GetRtProp(string realtype)
        {
            if (_realtypeToTrData.TryGetValue(realtype, out var trData))
            {
                return trData;
            }
            return null;
        }
        /// <summary>
        /// FID번호에 해당되는 이름 가져오기
        /// </summary>
        /// <param name="fid">FID번호</param>
        public static string GetFidName(string fid)
        {
            if (_map_FidToName.TryGetValue(fid, out var name))
                return name;
            return fid;
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

        /// <summary>TR데이터 로드</summary>
        public static bool LoadDetailData(this TrProp trData)
        {
            if (trData.FileText.Length > 0)
            {
                return true;
            }
            try
            {
                using var file = File.OpenRead(trData.FilePath);
                using var zip = new ZipArchive(file, ZipArchiveMode.Read);
                foreach (var entry in zip.Entries)
                {
                    string entruTitle = entry.Name[..^4];
                    if (entruTitle.Equals(trData.TRCode))
                    {
                        using var stream = entry.Open();
                        byte[] buffer = new byte[entry.Length];
                        _ = stream.Read(buffer, 0, buffer.Length);
                        stream.Close();
                        string ansiText = _krEncoder.GetString(buffer);
                        trData.FileText = ansiText;
                        ParsingTRData(ref trData, ansiText);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                /*
                0195 : 매도평균가      = 083, 20, 0, A ; "004" -> 매수평균가      = 083, 20, 0, A ; "004"
                 */
                _errors.Add($"Error: {trData.FilePath} : {ex.Message}");
            }

            return false;
        }

        private static Dictionary<string, IList<KeyValuePair<string, string>>> _trDescDatas = [];

        private static void LoadAllTRLists(string apiFolderPath)
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

            foreach (var trDesc in _trDescDatas)
            {
                var trCode = trDesc.Key;
                var input_infos = trDesc.Value;

                var trName = input_infos[0].Value;
                var trData = new TrProp($"{apiFolderPath}\\data\\{trCode}.enc", trCode, trName);
                if (trData == null) continue;

                _allTrInfos.Add(trData);
                if (_codeToTrData.TryGetValue(trData.TRCode, out var existTrData))
                {
                    _errors.Add($"Exist aleady : {existTrData.TRCode} : {existTrData.FilePath} ");
                }
                else
                    _codeToTrData.Add(trData.TRCode, trData);
            }

            // 실시간 TR
            _allRInfos.Clear();
            _realtypeToTrData.Clear();
            string filepath = apiFolderPath + "\\system\\koarealtime.dat";
            List<byte[]> rtlines = [];
            try
            {
                var fileDatas = File.ReadAllBytes(filepath);
                int filelength = fileDatas.Length;
                int nBytePos = 0;
                int nLineStartPos = 0;
                while (nBytePos < filelength)
                {
                    if (fileDatas[nBytePos] == '\n')
                    {
                        rtlines.Add(fileDatas.Skip(nLineStartPos).Take(nBytePos - nLineStartPos - 1).ToArray());
                        nLineStartPos = nBytePos + 1;
                    }
                    nBytePos++;
                }
                if (filelength > nLineStartPos)
                {
                    rtlines.Add(fileDatas.Skip(nLineStartPos).Take(filelength - nLineStartPos).ToArray());
                }
            }
            catch (Exception)
            {
                //throw;
            }
            foreach (var line in rtlines)
            {
                // 형식 = GIDC(1) + DESC(19) + NFID(3) + FID1(5) + ... + FIDn(5)'\r\n'
                if (line.Length < 23) continue;
                byte[] GIDC = line.Skip(0).Take(1).ToArray();
                byte[] DESC = line.Skip(1).Take(19).ToArray();
                byte[] NFID = line.Skip(20).Take(3).ToArray();
                if (GIDC[0] == ';') continue;
                int FidCount = Convert.ToInt32(_krEncoder.GetString(NFID));
                string name = _krEncoder.GetString(DESC).Trim();
                if (FidCount == 0 || line.Length < FidCount * 5 + 23)
                    continue;

                var trProp = new TrProp("", name, name) { FileText = name, IsRealtype = true, };
                _allRInfos.Add(trProp);
                _realtypeToTrData[name] = trProp;

                for (int i = 0; i < FidCount; i++)
                {
                    string fid = _krEncoder.GetString(line.Skip(23 + 5 * i).Take(5).ToArray()).Trim();
                    if (_map_FidToName.TryGetValue(fid, out var fid_name))
                        trProp.OutputSingle.Add(new(fid, 0, fid_name));
                    else
                        trProp.OutputSingle.Add(new(fid, 0, "'Extra Item"));
                }
            }
            return;
        }
    }
}
