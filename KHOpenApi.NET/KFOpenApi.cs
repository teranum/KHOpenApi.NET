namespace KHOpenApi.NET
{
    /// <summary>해외 OpenApi 클래스</summary>
    public class KFOpenApi : IOpenApi
    {
        /// <inheritdoc cref="IOpenApi.ModuleLoaded"/>
        public bool ModuleLoaded => throw new NotImplementedException();

        /// <inheritdoc cref="IOpenApi.IsConnected"/>
        public bool IsConnected => throw new NotImplementedException();

        /// <inheritdoc cref="IOpenApi.IsSimulation"/>
        public bool IsSimulation => throw new NotImplementedException();

        /// <inheritdoc cref="IOpenApi.UserID"/>
        public string UserID { get; private set; } = string.Empty;

        /// <inheritdoc cref="IOpenApi.LastErrorMessage"/>
        public string LastErrorMessage => throw new NotImplementedException();

        /// <inheritdoc cref="IOpenApi.AccountInfos"/>
        public IReadOnlyList<AccountInfo> AccountInfos => throw new NotImplementedException();

        /// <inheritdoc cref="IOpenApi.OnMessageEvent"/>
        public event EventHandler<MessageEventArgs>? OnMessageEvent;
        /// <inheritdoc cref="IOpenApi.OnRealtimeEvent"/>
        public event EventHandler<RealtimeEventArgs>? OnRealtimeEvent;

        /// <inheritdoc cref="IOpenApi.Close"/>
        public bool Close()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IOpenApi.ConnectAsync"/>
        public Task<bool> ConnectAsync()
        {
            throw new NotImplementedException();
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
    }
}
