using System;

namespace KHOpenApi.NET;

/// <summary>
/// 주문전송 후 주문접수, 체결통보, 잔고통보를 수신할 때 마다 발생됩니다.<br/> <see cref="AxKHOpenAPI.GetChejanData"/>함수를 이용해서 FID항목별 값을 얻을수 있습니다.
/// </summary>
public class _DKHOpenAPIEvents_OnReceiveChejanDataEvent(string sGubun, int nItemCnt, string sFIdList) : EventArgs
{
    /// <summary>체결구분. 접수와 체결시 '0'값, 국내주식 잔고변경은 '1'값, 파생잔고변경은 '4'</summary>
    public string sGubun = sGubun;
    /// <summary>FIDs Count</summary>
    public int nItemCnt = nItemCnt;
    /// <summary>FIDs Array</summary>
    public string sFIdList = sFIdList;
}
