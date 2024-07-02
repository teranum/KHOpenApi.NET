using KHOpenApi.NET.Helpers;
using KHOpenApi.NET.Models;
using System.Security.Cryptography;

namespace KHOpenApi.NET
{
    /// <summary>국내 OpenApi 클래스</summary>
    public class KHOpenApi : IOpenApi
    {
        /// <inheritdoc cref="IOpenApi.ModuleLoaded"/>
        public bool ModuleLoaded => AxApi.Created;

        /// <inheritdoc cref="IOpenApi.IsConnected"/>
        public bool IsConnected { get; private set; }

        /// <inheritdoc cref="IOpenApi.IsSimulation"/>
        public bool IsSimulation { get; private set; }

        /// <inheritdoc cref="IOpenApi.UserID"/>
        public string UserID { get; private set; } = string.Empty;

        /// <inheritdoc cref="IOpenApi.LastErrorMessage"/>
        public string LastErrorMessage { get; private set; }

        private readonly List<AccountInfo> _accountList = [];
        /// <inheritdoc cref="IOpenApi.AccountInfos"/>
        public IReadOnlyList<AccountInfo> AccountInfos => _accountList;

        /// <inheritdoc cref="IOpenApi.OnMessageEvent"/>
        public event EventHandler<MessageEventArgs>? OnMessageEvent;
        /// <inheritdoc cref="IOpenApi.OnRealtimeEvent"/>
        public event EventHandler<RealtimeEventArgs>? OnRealtimeEvent;

        private readonly List<ConditionInfo> _conditionList = [];
        /// <summary>조건검색식 리스트</summary>
        public IReadOnlyList<ConditionInfo> ConditionInfos => _conditionList;

        /// <inheritdoc cref="IOpenApi.Close"/>
        public bool Close()
        {
            if (IsConnected)
            {
                IsConnected = false;
                //AxApi.CommTerminate();
            }
            return true;
        }

        /// <inheritdoc cref="IOpenApi.ConnectAsync"/>
        public async Task<bool> ConnectAsync()
        {
            LastErrorMessage = string.Empty;
            if (IsConnected)
            {
                LastErrorMessage = "이미 연결되어 있습니다.";
                return true;
            }

            var connectResult = await AxApi.CommConnectAsync();

            if (connectResult == 0)
            {
                IsConnected = true;
                IsSimulation = AxApi.GetLoginInfo("GetServerGubun").Equals("1");
                UserID = AxApi.GetLoginInfo("USER_ID");

                // 계좌정보 요청
                _accountList.Clear();
                var account_details = AxApi.GetLoginInfo("ACCTLIST_DETAIL").Split(';', StringSplitOptions.RemoveEmptyEntries);
                var accountList = new List<AccountInfo>();
                foreach (var account in account_details)
                {
                    var infos = account.Split(',');
                    if (infos.Length >= 3)
                    {
                        _accountList.Add(new AccountInfo(infos[0], infos[1], infos[2], ""));
                    }
                }

                // 조건검색식 로드
                _conditionList.Clear();
                await AxApi.GetConditionLoadAsync();

                var conditions = AxApi.GetConditionNameList().Split(';');
                foreach (var condition in conditions)
                {
                    var conditionInfo = condition.Split('^');
                    if (conditionInfo.Length >= 2)
                    {
                        var conditionIndex = int.Parse(conditionInfo[0]);
                        var conditionName = conditionInfo[1];
                        _conditionList.Add(new ConditionInfo(conditionIndex, conditionName));
                    }
                }

                return true;
            }

            LastErrorMessage = "연결 실패";
            return false;
        }

        class ScrNumManager
        {
            private const int _indexBase = 6000;
            private const int _requreCount = 100;
            private const int _conditionCount = 100;
            private const int _realtimeCount = 100;

            private int _requestIndex = 0;
            public string GetRequestScrNum()
            {
                _requestIndex++;
                if (_requestIndex >= _requreCount)
                    _requestIndex = 0;
                return (_indexBase + _requestIndex).ToString("D4");
            }

            private int _conditionIndex = 0;
            public int GetConditionScrNum()
            {
                _conditionIndex++;
                if (_conditionIndex >= _conditionCount)
                    _conditionIndex = 0;
                return _indexBase + _requreCount + _conditionIndex;
            }

            private int _realtimeIndex = 0;
        }

        ScrNumManager _scrNumManager = new();

        /// <inheritdoc cref="IOpenApi.RequestAsync"/>
        public async Task<ResponseTrData?> RequestAsync(string tr_cd, IEnumerable<KeyValuePair<string, object>> indatas, string cont_key = "")
        {
            var trProp = KHTrManager.GetTrProp(tr_cd);
            if (trProp == null)
            {
                LastErrorMessage = "정의된 TR 코드를 찾을 수 없습니다.";
                return null;
            }
            var scr_num = _scrNumManager.GetRequestScrNum();

            foreach (var indata in indatas)
            {
                AxApi.SetInputValue(indata.Key, indata.Value.ToString()!);
            }

            ResponseTrData? responseTrData = null;

            var out_prevNext = string.Empty;
            var out_singles = new List<string>();

            var nRet = await AxApi.CommRqDataAsync(tr_cd, tr_cd, cont_key.Equals("2") ? 2: 0, scr_num,
                (e)=>
                {
                    AxApi.DisconnectRealData(e.sScrNo);
                    if (e.sPrevNext.Equals("2")) out_prevNext = "2";

                    var blockDatas = new List<(string blockName, IList<string[]> datas)>();

                    if (trProp.OutputSingle.Count > 0)
                    {
                        var blockData = new List<string[]>();
                        var datas = new string[trProp.OutputSingle.Count];
                        for (int i = 0; i < trProp.OutputSingle.Count; i++)
                        {
                            datas[i] = AxApi.GetCommData(e.sTrCode, e.sRecordName, 0, trProp.OutputSingle[i].Key).Trim();
                        }
                        blockData.Add(datas);
                        blockDatas.Add(("OutputSingle", blockData));
                    }

                    int nRepeateCnt = AxApi.GetRepeatCnt(e.sTrCode, e.sRecordName);
                    if (nRepeateCnt > 0)
                    {
                        var blockData = new List<string[]>();
                        for (int i = 0; i < nRepeateCnt; i++)
                        {
                            var datas = new string[trProp.OutputMulti.Count];
                            for (int j = 0; j < trProp.OutputMulti.Count; j++)
                            {
                                datas[j] = AxApi.GetCommData(e.sTrCode, e.sRecordName, i, trProp.OutputMulti[j].Key).Trim();
                            }
                            blockData.Add(datas);
                        }
                        blockDatas.Add(("OutputMulti", blockData));
                    }

                    responseTrData = new ResponseTrData()
                    {
                        tr_cd = e.sTrCode,
                        cont_key = e.sPrevNext.Equals("2") ? "2" : string.Empty,
                        rsp_cd = e.sErrorCode,
                        rsp_msg = e.sMessage,
                        blockDatas = blockDatas,
                    };
                }
                );

            if (nRet != 0)
            {
                LastErrorMessage = KHTrManager.GetErrorMessage(nRet);
                return null;
            }

            return responseTrData;
        }

        /// <inheritdoc cref="IOpenApi.RequestRealtime"/>
        public bool RequestRealtime(string scr_num, string code_list, string fid_list, bool bAdd)
        {
            if (!IsConnected)
            {
                LastErrorMessage = "연결되어 있지 않습니다.";
                return false;
            }
            if (bAdd)
                AxApi.SetRealReg(scr_num, code_list, fid_list, "1");
            else
                AxApi.SetRealRemove(scr_num, code_list);

            return true;
        }

        /// <summary>AxKHOpenAPI COM 객체</summary>
        public AxKHOpenAPI AxApi { get; }
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="windowHandle">메인 윈도우 핸들</param>
        public KHOpenApi(nint windowHandle)
        {
            LastErrorMessage = string.Empty;
            AxApi = new AxKHOpenAPI(windowHandle);

            AxApi.OnEventConnect += (s, e) =>
            {
                if (e.nErrCode != 0)
                {
                    IsConnected = false;
                    LastErrorMessage = KHTrManager.GetErrorMessage(e.nErrCode);
                    OnMessageEvent?.Invoke(this, new MessageEventArgs("연결실패"));
                }
            };

            AxApi.OnReceiveRealData += (s, e) =>
            {
                OnRealtimeEvent?.Invoke(this, new RealtimeEventArgs(e.sRealType, e.sRealKey, e.sRealData));
            };
        }
    }
}
