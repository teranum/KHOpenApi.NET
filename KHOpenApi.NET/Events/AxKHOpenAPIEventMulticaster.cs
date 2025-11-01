using System.Runtime.InteropServices;

namespace KHOpenApi.NET;

/// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveTrDataEvent"/>
public delegate void _DKHOpenAPIEvents_OnReceiveTrDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e);
/// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveRealDataEvent"/>
public delegate void _DKHOpenAPIEvents_OnReceiveRealDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveRealDataEvent e);
/// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveMsgEvent"/>
public delegate void _DKHOpenAPIEvents_OnReceiveMsgEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveMsgEvent e);
/// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveChejanDataEvent"/>
public delegate void _DKHOpenAPIEvents_OnReceiveChejanDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveChejanDataEvent e);
/// <inheritdoc cref="_DKHOpenAPIEvents_OnEventConnectEvent"/>
public delegate void _DKHOpenAPIEvents_OnEventConnectEventHandler(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e);
/// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveInvestRealDataEvent"/>
public delegate void _DKHOpenAPIEvents_OnReceiveInvestRealDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent e);
/// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveRealConditionEvent"/>
public delegate void _DKHOpenAPIEvents_OnReceiveRealConditionEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveRealConditionEvent e);
/// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveTrConditionEvent"/>
public delegate void _DKHOpenAPIEvents_OnReceiveTrConditionEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveTrConditionEvent e);
/// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveConditionVerEvent"/>
public delegate void _DKHOpenAPIEvents_OnReceiveConditionVerEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveConditionVerEvent e);

[ClassInterface(ClassInterfaceType.None)]
internal class AxKHOpenAPIEventMulticaster(AxKHOpenAPI parent) : _DKHOpenAPIEvents
{
    private readonly AxKHOpenAPI parent = parent;

    public virtual void OnReceiveTrData(string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPrevNext, int nDataLength, string sErrorCode, string sMessage, string sSplmMsg) => parent.RaiseOnOnReceiveTrData(parent, new(sScrNo, sRQName, sTrCode, sRecordName, sPrevNext, nDataLength, sErrorCode, sMessage, sSplmMsg));

    public virtual void OnReceiveRealData(string sRealKey, string sRealType, string sRealData) => parent.RaiseOnOnReceiveRealData(parent, new(sRealKey, sRealType, sRealData));

    public virtual void OnReceiveMsg(string sScrNo, string sRQName, string sTrCode, string sMsg) => parent.RaiseOnOnReceiveMsg(parent, new(sScrNo, sRQName, sTrCode, sMsg));

    public virtual void OnReceiveChejanData(string sGubun, int nItemCnt, string sFIdList) => parent.RaiseOnOnReceiveChejanData(parent, new(sGubun, nItemCnt, sFIdList));

    public virtual void OnEventConnect(int nErrCode) => parent.RaiseOnOnEventConnect(parent, new(nErrCode));

    public virtual void OnReceiveInvestRealData(string sRealKey) => parent.RaiseOnOnReceiveInvestRealData(parent, new(sRealKey));

    public virtual void OnReceiveRealCondition(string sTrCode, string strType, string strConditionName, string strConditionIndex) => parent.RaiseOnOnReceiveRealCondition(parent, new(sTrCode, strType, strConditionName, strConditionIndex));

    public virtual void OnReceiveTrCondition(string sScrNo, string strCodeList, string strConditionName, int nIndex, int nNext) => parent.RaiseOnOnReceiveTrCondition(parent, new(sScrNo, strCodeList, strConditionName, nIndex, nNext));

    public virtual void OnReceiveConditionVer(int lRet, string sMsg) => parent.RaiseOnOnReceiveConditionVer(parent, new(lRet, sMsg));
}
