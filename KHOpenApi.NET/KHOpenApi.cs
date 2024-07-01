using KHOpenApi.NET.Helpers;

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

                return true;
            }

            LastErrorMessage = "연결 실패";
            return false;
        }

        /// <inheritdoc cref="IOpenApi.RequestAsync"/>
        public Task<ResponseTrData?> RequestAsync(string tr_cd, string indatas, string cont_key = "", string reqfids = "")
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IOpenApi.RequestRealtime"/>
        public bool RequestRealtime(string tr_cd, string tr_key, bool bAdd)
        {
            throw new NotImplementedException();
        }

        /// <summary>AxKHOpenAPI COM 객체</summary>
        public AxKHOpenAPI AxApi { get; }
        /// <summary>생성자, 메인윈도우 핸들을 인자로 넘겨주어 생성합니다.</summary>
        public KHOpenApi(nint windowHandle)
        {
            LastErrorMessage = string.Empty;
            AxApi = new AxKHOpenAPI(windowHandle);

            if (AxApi.Created)
            {
                var ocx_folder = AxApi.GetAPIModulePath();
                KHTrManager.LoadAllTRLists(ocx_folder);
                //AxApi.OnEventConnect += AxApi_OnEventConnect;
                //AxApi.OnReceiveTrData += AxApi_OnReceiveTrData;
                //AxApi.OnReceiveRealData += AxApi_OnReceiveRealData;
                //AxApi.OnReceiveMsg += AxApi_OnReceiveMsg;
            }
        }
    }
}
