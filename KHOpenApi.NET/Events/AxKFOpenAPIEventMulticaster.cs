using System.Runtime.InteropServices;

namespace KHOpenApi.NET
{
    /// <inheritdoc cref="_DKFOpenAPIEvents_OnReceiveTrDataEvent"/>
    public delegate void _DKFOpenAPIEvents_OnReceiveTrDataEventHandler(object sender, _DKFOpenAPIEvents_OnReceiveTrDataEvent e);
    /// <inheritdoc cref="_DKFOpenAPIEvents_OnReceiveRealDataEvent"/>
    public delegate void _DKFOpenAPIEvents_OnReceiveRealDataEventHandler(object sender, _DKFOpenAPIEvents_OnReceiveRealDataEvent e);
    /// <inheritdoc cref="_DKFOpenAPIEvents_OnReceiveMsgEvent"/>
    public delegate void _DKFOpenAPIEvents_OnReceiveMsgEventHandler(object sender, _DKFOpenAPIEvents_OnReceiveMsgEvent e);
    /// <inheritdoc cref="_DKFOpenAPIEvents_OnReceiveChejanDataEvent"/>
    public delegate void _DKFOpenAPIEvents_OnReceiveChejanDataEventHandler(object sender, _DKFOpenAPIEvents_OnReceiveChejanDataEvent e);
    /// <inheritdoc cref="_DKFOpenAPIEvents_OnEventConnectEvent"/>
    public delegate void _DKFOpenAPIEvents_OnEventConnectEventHandler(object sender, _DKFOpenAPIEvents_OnEventConnectEvent e);

    [ClassInterface(ClassInterfaceType.None)]
    internal class AxKFOpenAPIEventMulticaster(AxKFOpenAPI parent) : _DKFOpenAPIEvents
    {
        private readonly AxKFOpenAPI parent = parent;

        public virtual void OnReceiveTrData(string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPrevNext) => parent.RaiseOnOnReceiveTrData(parent, new(sScrNo, sRQName, sTrCode, sRecordName, sPrevNext, string.Empty));

        public virtual void OnReceiveMsg(string sScrNo, string sRQName, string sTrCode, string sMsg) => parent.RaiseOnOnReceiveMsg(parent, new(sScrNo, sRQName, sTrCode, sMsg));

        public virtual void OnReceiveRealData(string sJongmokCode, string sRealType, string sRealData) => parent.RaiseOnOnReceiveRealData(parent, new(sJongmokCode, sRealType, sRealData));

        public virtual void OnReceiveChejanData(string sGubun, int nItemCnt, string sFIdList) => parent.RaiseOnOnReceiveChejanData(parent, new(sGubun, nItemCnt, sFIdList));

        public virtual void OnEventConnect(int nErrCode) => parent.RaiseOnOnEventConnect(parent, new(nErrCode));
    }
}

