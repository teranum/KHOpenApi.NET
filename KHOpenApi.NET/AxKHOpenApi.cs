using KHOpenApi.NET.Attributes;

namespace KHOpenApi.NET;


/// <summary>
/// 키움 OpenAPI+ ActiveX 컨트롤을 위한 래퍼 클래스
/// </summary>
//[Guid("a1574a0d-6bfa-4bd7-9020-ded88711818d")]
[ComId("KHOPENAPI.KHOpenAPICtrl.1")]
public class AxKHOpenAPI : AxBase
{
    #region 이벤트 핸들러

    internal enum EventId
    {
        OnReceiveTrData = 1,
        OnReceiveRealData = 2,
        OnReceiveMsg = 3,
        OnReceiveChejanData = 4,
        OnEventConnect = 5,
        OnReceiveInvestRealData = 6,
        OnReceiveRealCondition = 7,
        OnReceiveTrCondition = 8,
        OnReceiveConditionVer = 9,
    }

    /// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveTrDataEvent"/>
    public event _DKHOpenAPIEvents_OnReceiveTrDataEventHandler? OnReceiveTrData;

    /// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveRealDataEvent"/>
    public event _DKHOpenAPIEvents_OnReceiveRealDataEventHandler? OnReceiveRealData;

    /// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveMsgEvent"/>
    public event _DKHOpenAPIEvents_OnReceiveMsgEventHandler? OnReceiveMsg;

    /// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveChejanDataEvent"/>
    public event _DKHOpenAPIEvents_OnReceiveChejanDataEventHandler? OnReceiveChejanData;

    /// <inheritdoc cref="_DKHOpenAPIEvents_OnEventConnectEvent"/>
    public event _DKHOpenAPIEvents_OnEventConnectEventHandler? OnEventConnect;

    /// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveInvestRealDataEvent"/>
    public event _DKHOpenAPIEvents_OnReceiveInvestRealDataEventHandler? OnReceiveInvestRealData;

    /// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveRealConditionEvent"/>
    public event _DKHOpenAPIEvents_OnReceiveRealConditionEventHandler? OnReceiveRealCondition;

    /// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveTrConditionEvent"/>
    public event _DKHOpenAPIEvents_OnReceiveTrConditionEventHandler? OnReceiveTrCondition;

    /// <inheritdoc cref="_DKHOpenAPIEvents_OnReceiveConditionVerEvent"/>
    public event _DKHOpenAPIEvents_OnReceiveConditionVerEventHandler? OnReceiveConditionVer;
    internal void RaiseOnOnReceiveTrData(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e)
    {
        if (!ProcInternalAsyncNode((int)EventId.OnReceiveTrData, e))
            OnReceiveTrData?.Invoke(this, e);
    }

    internal void RaiseOnOnReceiveRealData(object sender, _DKHOpenAPIEvents_OnReceiveRealDataEvent e)
    {
        OnReceiveRealData?.Invoke(this, e);
    }

    internal void RaiseOnOnReceiveMsg(object sender, _DKHOpenAPIEvents_OnReceiveMsgEvent e)
    {
        if (!ProcInternalAsyncNode((int)EventId.OnReceiveMsg, e))
            OnReceiveMsg?.Invoke(this, e);
    }

    internal void RaiseOnOnReceiveChejanData(object sender, _DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
    {
        OnReceiveChejanData?.Invoke(this, e);
    }

    internal void RaiseOnOnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
    {
        if (!ProcInternalAsyncNode((int)EventId.OnEventConnect, e))
            OnEventConnect?.Invoke(this, e);
    }

    internal void RaiseOnOnReceiveInvestRealData(object sender, _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent e)
    {
        OnReceiveInvestRealData?.Invoke(this, e);
    }

    internal void RaiseOnOnReceiveRealCondition(object sender, _DKHOpenAPIEvents_OnReceiveRealConditionEvent e)
    {
        OnReceiveRealCondition?.Invoke(this, e);
    }

    internal void RaiseOnOnReceiveTrCondition(object sender, _DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
    {
        if (!ProcInternalAsyncNode((int)EventId.OnReceiveTrCondition, e))
            OnReceiveTrCondition?.Invoke(this, e);
    }

    internal void RaiseOnOnReceiveConditionVer(object sender, _DKHOpenAPIEvents_OnReceiveConditionVerEvent e)
    {
        if (!ProcInternalAsyncNode((int)EventId.OnReceiveConditionVer, e))
            OnReceiveConditionVer?.Invoke(this, e);
    }

    #endregion

    #region 메서드

    /// <summary>
    /// 수동 로그인설정인 경우 로그인창을 출력.<br/> 자동로그인 설정인 경우 로그인창에서 자동으로 로그인을 시도합니다.
    /// </summary>
    /// <returns>0: 성공, other: 실패</returns>
    /// <remarks>요청이 성공하면 <see cref="OnEventConnect"/> 이벤트가 발생합니다.</remarks>
    public virtual int CommConnect()
    {
        ThrowIfNull(ocx);

        return ocx.CommConnect();
    }

    /// <summary>
    /// 프로그램 종료없이 서버와의 접속만 단절시키는 함수입니다.<br/> ※ 함수 사용 후 사용자의 오해소지가 생기는 이유로 더 이상 사용할 수 없는 함수입니다.
    /// </summary>
    [Obsolete("더 이상 사용할 수 없는 함수입니다.")]
    public virtual void CommTerminate()
    {
        ThrowIfNull(ocx);

        ocx.CommTerminate();
    }

    /// <summary>
    /// 조회요청 함수입니다.<br/>조회데이터는 <see cref="OnReceiveTrData"/> 이벤트로 수신됩니다.
    /// </summary>
    /// <param name="sRQName">사용자 구분명 (임의로 지정, 한글지원)</param>
    /// <param name="sTrCode">조회하려는 TR이름</param>
    /// <param name="nPrevNext">연속조회여부</param>
    /// <param name="sScreenNo">화면번호 (4자리 숫자 임의로 지정)</param>
    /// <returns>리턴값 0이면 조회요청 정상, 나머지는 에러<br/>
    /// -200 시세과부하<br/>
    /// -201 조회전문작성 에러
    /// </returns>
    public virtual int CommRqData(string sRQName, string sTrCode, int nPrevNext, string sScreenNo)
    {
        ThrowIfNull(ocx);

        return ocx.CommRqData(sRQName, sTrCode, nPrevNext, sScreenNo);
    }

    /// <summary>
    /// 로그인 후 사용할 수 있으며 인자값에 대응하는 정보를 얻을 수 있습니다.
    /// </summary>
    /// <param name="sTag">"ACCOUNT_CNT",  "ACCLIST", "ACCNO", "USER_ID", "USER_NAME", "GetServerGubun", "KEY_BSECGB", "FIREW_SECGB"</param>
    /// <returns>인자값에 대응하는 정보를 얻을 수 있습니다.</returns>
    /// <remarks>
    /// "ACCOUNT_CNT" : 보유계좌 갯수를 반환합니다.<br/>
    /// "ACCLIST" 또는 "ACCNO" : 구분자 ';'로 연결된 보유계좌 목록을 반환합니다.<br/>
    /// "ACCTLIST_DETAIL" : 구분자 ';'로 연결된 보유계좌, 그 안에서 ','로 계좌번호, 계좌명, 계좌상품(위탁종합, 선물옵션, Fx마진, 해외선물, 금현물) 목록을 반환합니다.<br/>
    /// "USER_ID" : 사용자 ID를 반환합니다.<br/>
    /// "USER_NAME" : 사용자 이름을 반환합니다.<br/>
    /// "GetServerGubun" : 접속서버 구분을 반환합니다.(1 : 모의투자, 나머지 : 실거래 서버)<br/>
    /// "KEY_BSECGB" : 키보드 보안 해지여부를 반환합니다.(0 : 정상, 1 : 해지)<br/>
    /// "FIREW_SECGB" : 방화벽 설정여부를 반환합니다.(0 : 미설정, 1 : 설정, 2 : 해지)
    /// </remarks>
    public virtual string GetLoginInfo(string sTag)
    {
        ThrowIfNull(ocx);

        return ocx.GetLoginInfo(sTag);
    }

    /// <summary>
    /// 서버에 주문을 전송하는 함수 입니다.
    /// </summary>
    /// <param name="sRQName">사용자 구분명</param>
    /// <param name="sScreenNo">화면번호</param>
    /// <param name="sAccNo">계좌번호 10자리</param>
    /// <param name="nOrderType">주문유형은 아래 참고</param>
    /// <param name="sCode">종목코드 (6자리)</param>
    /// <param name="nQty">주문수량</param>
    /// <param name="nPrice">주문가격</param>
    /// <param name="sHogaGb">거래구분(혹은 호가구분)은 아래 참고</param>
    /// <param name="sOrgOrderNo">원주문번호. 신규주문에는 공백 입력, 정정/취소시 입력합니다.</param>
    /// <returns>리턴값이 0이면 성공이며 나머지는 에러입니다.<br/>
    /// 1초에 5회만 주문가능하며 그 이상 주문요청하면 에러 -308을 리턴합니다.
    /// </returns>
    /// <remarks>
    /// 9개 인자값을 가진 주식주문 함수이며 리턴값이 0이면 성공이며 나머지는 에러입니다.<br/>
    /// 1초에 5회만 주문가능하며 그 이상 주문요청하면 에러 -308을 리턴합니다.<br/>
    /// ※ 시장가주문시 주문가격은 0으로 입력합니다. 주문가능수량은 해당 종목의 상한가 기준으로 계산됩니다.<br/>
    /// ※ 취소주문일때 주문가격은 0으로 입력합니다.<br/>
    /// ※ 프로그램매매 주문은 실거래 서버에서만 주문하실수 있으며 모의투자 서버에서는 지원하지 않습니다.<br/><br/>
    /// [주문유형(nOrderType)]<br/>
    /// 1: 신규매수<br/>
    /// 2: 신규매도<br/>
    /// 3: 매수취소<br/>
    /// 4: 매도취소<br/>
    /// 5: 매수정정<br/>
    /// 6: 매도정정<br/>
    /// 7: 프로그램매매 매수<br/>
    /// 8: 프로그램매매 매도<br/>
    /// 11: SOR매수<br/>
    /// 12: SOR매도<br/>
    /// 13: SOR취소<br/>
    /// 15: SOR정정<br/>
    /// 21: NXT매수<br/>
    /// 22: NXT매도<br/>
    /// 23: NXT취소<br/>
    /// 25: NXT정정<br/><br/>
    /// [거래구분(sHogaGb)]
    /// 00 : 지정가<br/>
    /// 03 : 시장가<br/>
    /// 05 : 조건부지정가<br/>
    /// 06 : 최유리지정가<br/>
    /// 07 : 최우선지정가<br/>
    /// 10 : 지정가IOC<br/>
    /// 13 : 시장가IOC<br/>
    /// 16 : 최유리IOC<br/>
    /// 20 : 지정가FOK<br/>
    /// 23 : 시장가FOK<br/>
    /// 26 : 최유리FOK<br/>
    /// 61 : 장전시간외종가<br/>
    /// 62 : 시간외단일가매매<br/>
    /// 81 : 장후시간외종가<br/>
    /// ※ 모의투자에서는 지정가 주문과 시장가 주문만 가능합니다.<br/><br/>
    /// [정규장 외 주문]<br/>
    /// 장전 동시호가 주문<br/>
    /// 08:30 ~ 09:00.	거래구분 00:지정가/03:시장가 (일반주문처럼)<br/>
    /// ※ 08:20 ~ 08:30 시간의 주문은 키움에서 대기하여 08:30 에 순서대로 거래소로 전송합니다.<br/>
    /// 장전시간외 종가<br/>
    /// 08:30 ~ 08:40. 	거래구분 61:장전시간외종가.  가격 0입력<br/>
    /// ※ 전일 종가로 거래. 미체결시 자동취소되지 않음<br/>
    /// 장마감 동시호가 주문<br/>
    /// 15:20 ~ 15:30.	거래구분 00:지정가/03:시장가 (일반주문처럼)<br/>
    /// 장후 시간외 종가<br/>
    /// 15:40 ~ 16:00.	거래구분 81:장후시간외종가.  가격 0입력<br/>
    /// 시간외 단일가<br/>
    /// 16:00 ~ 18:00.	거래구분 62:시간외단일가.  가격 입력<br/>
    /// ※ 10분 단위로 체결, 당일 종가대비 +-10% 가격으로 거래<br/>
    /// </remarks>
    public virtual int SendOrder(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, int nPrice, string sHogaGb, string sOrgOrderNo)
    {
        ThrowIfNull(ocx);

        return ocx.SendOrder(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, nPrice, sHogaGb, sOrgOrderNo);
    }

    /// <summary>
    /// 서버에 주문을 전송하는 함수 입니다, 코스피지수200 선물옵션 전용 주문함수입니다.
    /// </summary>
    /// <param name="sRQName">사용자 구분명</param>
    /// <param name="sScreenNo">화면번호</param>
    /// <param name="sAccNo">계좌번호 10자리</param>
    /// <param name="sCode">종목코드</param>
    /// <param name="lOrdKind">주문종류 1:신규매매, 2:정정, 3:취소</param>
    /// <param name="sSlbyTp">매매구분	1: 매도, 2:매수</param>
    /// <param name="sOrdTp">거래구분(혹은 호가구분)은 아래 참고</param>
    /// <param name="lQty">주문수량</param>
    /// <param name="sPrice">주문가격</param>
    /// <param name="sOrgOrdNo">원주문번호</param>
    /// <returns><inheritdoc cref="SendOrder"/></returns>
    /// <remarks>
    /// [거래구분]<br/>
    /// 1 : 지정가<br/>
    /// 2 : 조건부지정가<br/>
    /// 3 : 시장가<br/>
    /// 4 : 최유리지정가<br/>
    /// 5 : 지정가(IOC)<br/>
    /// 6 : 지정가(FOK)<br/>
    /// 7 : 시장가(IOC)<br/>
    /// 8 : 시장가(FOK)<br/>
    /// 9 : 최유리지정가(IOC)<br/>
    /// A : 최유리지정가(FOK)<br/>
    /// 장종료 후 시간외 주문은 지정가 선택
    /// </remarks>
    public virtual int SendOrderFO(string sRQName, string sScreenNo, string sAccNo, string sCode, int lOrdKind, string sSlbyTp, string sOrdTp, int lQty, string sPrice, string sOrgOrdNo)
    {
        ThrowIfNull(ocx);

        return ocx.SendOrderFO(sRQName, sScreenNo, sAccNo, sCode, lOrdKind, sSlbyTp, sOrdTp, lQty, sPrice, sOrgOrdNo);
    }

    /// <summary>
    /// 조회요청시 TR의 Input값을 지정하는 함수입니다.
    /// </summary>
    /// <param name="sID">TR에 명시된 Input이름</param>
    /// <param name="sValue">Input이름으로 지정한 값</param>
    public virtual void SetInputValue(string sID, string sValue)
    {
        ThrowIfNull(ocx);

        ocx.SetInputValue(sID, sValue);
    }

    /// <summary>SetOutputFID</summary>
    [Obsolete("더 이상 사용할 수 없는 함수입니다.")]
    public virtual int SetOutputFID(string sID)
    {
        ThrowIfNull(ocx);

        return ocx.SetOutputFID(sID);
    }

    /// <summary>
    /// 일부 TR에서 사용상 제약이 있음므로 이 함수 대신 <see cref="GetCommData"/>함수를 사용하시기 바랍니다.
    /// </summary>
    [Obsolete("일부 TR에서 사용상 제약이 있음므로 이 함수 대신 GetCommData()함수를 사용하시기 바랍니다.")]
    public virtual string CommGetData(string sJongmokCode, string sRealType, string sFieldName, int nIndex, string sInnerFieldName)
    {
        ThrowIfNull(ocx);

        return ocx.CommGetData(sJongmokCode, sRealType, sFieldName, nIndex, sInnerFieldName);
    }

    /// <summary>
    /// 화면 내의 모든 리얼데이터 요청을 제거한다.
    /// </summary>
    /// <param name="sScnNo">4자리의 화면번호 입력 (1 ~ 9999 : 숫자형식으로만 가능)</param>
    /// <remarks>
    /// 시세데이터를 요청할때 사용된 화면번호를 이용하여 해당 화면번호로 등록되어져 있는 종목의 실시간시세를 서버에 등록해지 요청합니다.<br/>
    /// 이후 해당 종목의 실시간시세는 수신되지 않습니다.<br/>
    /// 단, 해당 종목이 또다른 화면번호로 실시간 등록되어 있는 경우 해당종목에대한 실시간시세 데이터는 계속 수신됩니다.
    /// </remarks>
    public virtual void DisconnectRealData(string sScnNo)
    {
        ThrowIfNull(ocx);

        ocx.DisconnectRealData(sScnNo);
    }

    /// <summary>
    /// 수신데이타(멀티데이타) 반복횟수를 반환한다.<br/> 이 함수는 <see cref="OnReceiveTrData"/> 이벤트가 발생될때 그 안에서 사용해야 합니다.
    /// </summary>
    /// <param name="sTrCode">Tr목록의 TrCode</param>
    /// <param name="sRecordName">조회시 sRQName  </param>
    /// <returns>데이타 반복횟수</returns>
    public virtual int GetRepeatCnt(string sTrCode, string sRecordName)
    {
        ThrowIfNull(ocx);

        return ocx.GetRepeatCnt(sTrCode, sRecordName);
    }

    /// <summary>
    /// 한번에 100종목까지 조회할 수 있는 복수종목 조회함수 입니다.<br/> 함수인자로 사용하는 종목코드 리스트는 조회하려는 종목코드 사이에 구분자';'를 추가해서 만들면 됩니다.<br/>
    /// 수신되는 데이터는 TR목록에서 복수종목정보요청(OPTKWFID) Output을 참고하시면 됩니다.<br/>
    /// ※ OPTKWFID TR은 CommKwRqData()함수 전용으로, CommRqData 로는 사용할 수 없습니다.<br/>
    /// ※ OPTKWFID TR은 영웅문4 HTS의 관심종목과는 무관합니다.<br/>
    /// 조회 데이터는 <see cref="OnReceiveTrData"/> 이벤트로 수신됩니다.
    /// </summary>
    /// <param name="sArrCode">조회하려는 종목코드 리스트</param>
    /// <param name="bNext">연속조회 여부 0:기본값, 1:연속조회(지원안함)</param>
    /// <param name="nCodeCount">종목코드 갯수</param>
    /// <param name="nTypeFlag">0:주식 종목, 3:선물옵션 종목</param>
    /// <param name="sRQName">사용자 구분명</param>
    /// <param name="sScreenNo">화면번호</param>
    /// <returns><inheritdoc cref="CommRqData"/></returns>
    public virtual int CommKwRqData(string sArrCode, int bNext, int nCodeCount, int nTypeFlag, string sRQName, string sScreenNo)
    {
        ThrowIfNull(ocx);

        return ocx.CommKwRqData(sArrCode, bNext, nCodeCount, nTypeFlag, sRQName, sScreenNo);
    }

    /// <summary>
    /// ocx 폴더경로를 반환합니다. (ex. C:\OpenAPI)
    /// </summary>
    /// <returns>경로</returns>
    public virtual string GetAPIModulePath()
    {
        ThrowIfNull(ocx);

        return ocx.GetAPIModulePath();
    }

    /// <summary>
    /// 주식 시장별 종목코드 리스트를 ';'로 구분해서 전달합니다.<br/> 시장구분값을 ""빈문자로 하면 전체시장 코드리스트를 전달합니다.
    /// </summary>
    /// <param name="sMarket">시장구분값</param>
    /// <returns>종목코드 리스트</returns>
    public virtual string GetCodeListByMarket(string sMarket)
    {
        ThrowIfNull(ocx);

        return ocx.GetCodeListByMarket(sMarket);
    }

    /// <summary>
    /// 서버와 현재 접속 상태를 알려줍니다.
    /// </summary>
    /// <returns>1:연결, 0:연결안됨</returns>
    public virtual int GetConnectState()
    {
        ThrowIfNull(ocx);

        return ocx.GetConnectState();
    }

    /// <summary>
    /// 종목코드에 해당하는 종목명을 전달합니다.
    /// </summary>
    /// <param name="sTrCode">종목코드</param>
    /// <returns></returns>
    public virtual string GetMasterCodeName(string sTrCode)
    {
        ThrowIfNull(ocx);

        return ocx.GetMasterCodeName(sTrCode);
    }

    /// <summary>
    /// 입력한 종목코드에 해당하는 종목 상장주식수를 전달합니다.<br/>
    /// 상장주식수가 2억주 이상인 경우, <see cref="KOA_Functions"/>("GetMasterListedStockCntEx", "종목코드(6자리)") 함수를 사용하시기 바랍니다.
    /// </summary>
    /// <param name="sTrCode">종목코드</param>
    /// <returns></returns>
    public virtual int GetMasterListedStockCnt(string sTrCode)
    {
        ThrowIfNull(ocx);

        return ocx.GetMasterListedStockCnt(sTrCode);
    }

    /// <summary>
    /// 입력한 종목코드에 해당하는 종목의 감리구분을 전달합니다. (정상, 투자주의, 투자경고, 투자위험, 투자주의환기종목)
    /// </summary>
    /// <param name="sTrCode">종목코드</param>
    /// <returns></returns>
    public virtual string GetMasterConstruction(string sTrCode)
    {
        ThrowIfNull(ocx);

        return ocx.GetMasterConstruction(sTrCode);
    }

    /// <summary>
    /// 입력한 종목의 상장일을 전달합니다.
    /// </summary>
    /// <param name="sTrCode">종목코드</param>
    /// <returns></returns>
    public virtual string GetMasterListedStockDate(string sTrCode)
    {
        ThrowIfNull(ocx);

        return ocx.GetMasterListedStockDate(sTrCode);
    }

    /// <summary>
    /// 입력한 종목의 당일 기준가를 전달합니다.
    /// </summary>
    /// <param name="sTrCode">종목코드</param>
    /// <returns></returns>
    public virtual string GetMasterLastPrice(string sTrCode)
    {
        ThrowIfNull(ocx);

        return ocx.GetMasterLastPrice(sTrCode);
    }

    /// <summary>
    /// 입력한 종목의 증거금 비율, 거래정지, 관리종목, 감리종목, 투자융의종목, 담보대출, 액면분할, 신용가능 여부를 전달합니다.
    /// </summary>
    /// <param name="sTrCode">종목코드</param>
    /// <returns></returns>
    public virtual string GetMasterStockState(string sTrCode)
    {
        ThrowIfNull(ocx);

        return ocx.GetMasterStockState(sTrCode);
    }

    /// <summary>GetDataCount</summary>
    [Obsolete("더 이상 사용할 수 없는 함수입니다.")]
    public virtual int GetDataCount(string strRecordName)
    {
        ThrowIfNull(ocx);

        return ocx.GetDataCount(strRecordName);
    }

    /// <summary>GetOutputValue</summary>
    [Obsolete("더 이상 사용할 수 없는 함수입니다.")]
    public virtual string GetOutputValue(string strRecordName, int nRepeatIdx, int nItemIdx)
    {
        ThrowIfNull(ocx);

        return ocx.GetOutputValue(strRecordName, nRepeatIdx, nItemIdx);
    }

    /// <summary>
    /// <see cref="OnReceiveTrData"/> 이벤트가 발생될때 수신한 데이터를 얻어오는 함수입니다.<br/> 이 함수는 <see cref="OnReceiveTrData"/> 이벤트가 발생될때 그 안에서 사용해야 합니다.
    /// </summary>
    /// <param name="strTrCode">TR 이름</param>
    /// <param name="strRecordName">레코드이름</param>
    /// <param name="nIndex">nIndex번째</param>
    /// <param name="strItemName">nIndex번째</param>
    /// <returns></returns>
    public virtual string GetCommData(string strTrCode, string strRecordName, int nIndex, string strItemName)
    {
        ThrowIfNull(ocx);

        return ocx.GetCommData(strTrCode, strRecordName, nIndex, strItemName);
    }

    /// <summary>
    /// 실시간시세 데이터 수신 이벤트인 <see cref="OnReceiveRealData"/> 가 발생될때 실시간데이터를 얻어오는 함수입니다.<br/> 이 함수는 <see cref="OnReceiveRealData"/> 이벤트가 발생될때 그 안에서 사용해야 합니다.
    /// </summary>
    /// <param name="sTrCode"></param>
    /// <param name="nFid"></param>
    /// <returns></returns>
    public virtual string GetCommRealData(string sTrCode, int nFid)
    {
        ThrowIfNull(ocx);

        return ocx.GetCommRealData(sTrCode, nFid);
    }

    /// <summary>
    /// <see cref="OnReceiveChejanData"/> 이벤트가 발생될때 FID에 해당되는 값을 구하는 함수입니다.<br/> 이 함수는 <see cref="OnReceiveChejanData"/> 이벤트 안에서 사용해야 합니다.
    /// </summary>
    /// <param name="nFid">실시간 타입에 포함된 FID(Field ID)</param>
    /// <returns></returns>
    public virtual string GetChejanData(int nFid)
    {
        ThrowIfNull(ocx);

        return ocx.GetChejanData(nFid);
    }

    /// <summary>
    /// 테마 그룹 리스트(코드|네임)를 ';'로 구분해서 전달합니다.(ex "100|태양광_폴리실리콘;101|태양광_잉곳/웨이퍼/셀/모듈;102|태양광_부품/소재/장비;...")
    /// </summary>
    /// <param name="nType">0 코드순, 1: 테마순</param>
    /// <returns></returns>
    public virtual string GetThemeGroupList(int nType)
    {
        ThrowIfNull(ocx);

        return ocx.GetThemeGroupList(nType);
    }

    /// <summary>
    /// 테마그룹코드에 해당하는 테마코드 리스트를 ';'로 구분해서 전달합니다.<br/>
    /// 종목코드에 앞문자가 포함되어 전달 됩니다. (ex "A010060;A004000;A009830;A052420;...")
    /// </summary>
    /// <param name="strThemeCode"><see cref="GetThemeGroupList"/>에서 리턴된 3자리 그룹코드</param>
    /// <returns></returns>
    public virtual string GetThemeGroupCode(string strThemeCode)
    {
        ThrowIfNull(ocx);

        return ocx.GetThemeGroupCode(strThemeCode);
    }

    /// <summary>
    /// 지수선물 종목코드 리스트를 ';'로 구분해서 전달합니다.
    /// </summary>
    /// <returns></returns>
    public virtual string GetFutureList()
    {
        ThrowIfNull(ocx);

        return ocx.GetFutureList();
    }

    /// <summary>
    /// 지수선물 종목코드를 인덱스로 전달합니다.<br/>
    /// ex) GetFutureCodeByIndex(0) : 첫번째 종목코드로 코스피 지수선물 대표월물을 반환
    /// </summary>
    /// <param name="nIndex">인덱스</param>
    /// <returns></returns>
    public virtual string GetFutureCodeByIndex(int nIndex)
    {
        ThrowIfNull(ocx);

        return ocx.GetFutureCodeByIndex(nIndex);
    }

    /// <summary>
    /// 지수옵션 행사가에 100을 곱해서 소수점이 없는 값을 ';'로 구분해서 전달합니다.
    /// </summary>
    /// <returns></returns>
    public virtual string GetActPriceList()
    {
        ThrowIfNull(ocx);

        return ocx.GetActPriceList();
    }

    /// <summary>
    /// 지수옵션 월물정보를 ';'로 구분해서 전달하는데 순서는 콜 11월물 ~ 콜 최근월물 풋 최근월물 ~ 풋 최근월물가 됩니다.
    /// </summary>
    /// <returns></returns>
    public virtual string GetMonthList()
    {
        ThrowIfNull(ocx);

        return ocx.GetMonthList();
    }

    /// <summary>
    /// 인자로 지정한 지수옵션 코드를 전달합니다
    /// </summary>
    /// <param name="strActPrice">소수점을 포함한 행사가</param>
    /// <param name="nCp">콜풋구분값, 콜:2, 풋:3</param>
    /// <param name="strMonth">6자리 월물</param>
    /// <returns></returns>
    public virtual string GetOptionCode(string strActPrice, int nCp, string strMonth)
    {
        ThrowIfNull(ocx);

        return ocx.GetOptionCode(strActPrice, nCp, strMonth);
    }

    /// <summary>GetOptionCodeByMonth</summary>
    public virtual string GetOptionCodeByMonth(string sTrCode, int nCp, string strMonth)
    {
        ThrowIfNull(ocx);

        return ocx.GetOptionCodeByMonth(sTrCode, nCp, strMonth);
    }

    /// <summary>
    /// 옵션전용 함수. 인자로 지정한 지수옵션 종목의 n틱 차이에 해당되는 종목코드를 전달합니다.
    /// </summary>
    /// <param name="sTrCode">기준이 되는 종목코드</param>
    /// <param name="nCp">콜풋구분값, 콜:2, 풋:3</param>
    /// <param name="nTick">기준종목의 n틱 (0값 제외)</param>
    /// <returns></returns>
    public virtual string GetOptionCodeByActPrice(string sTrCode, int nCp, int nTick)
    {
        ThrowIfNull(ocx);

        return ocx.GetOptionCodeByActPrice(sTrCode, nCp, nTick);
    }

    /// <summary>
    /// 기초자산 구분값을 인자로 받아서 주식선물 종목코드, 종목명, 기초자산이름을 구할수 있습니다. 입력값을 공백으로 하면 주식선물 전체 종목코드를 얻을 수 있습니다.
    /// </summary>
    /// <param name="strBaseAssetCode">기초자산 구분값</param>
    /// <returns></returns>
    public virtual string GetSFutureList(string strBaseAssetCode)
    {
        ThrowIfNull(ocx);

        return ocx.GetSFutureList(strBaseAssetCode);
    }

    /// <summary>GetSFutureCodeByIndex</summary>
    public virtual string GetSFutureCodeByIndex(string strBaseAssetCode, int nIndex)
    {
        ThrowIfNull(ocx);

        return ocx.GetSFutureCodeByIndex(strBaseAssetCode, nIndex);
    }

    /// <summary>GetSActPriceList</summary>
    public virtual string GetSActPriceList(string strBaseAssetGb)
    {
        ThrowIfNull(ocx);

        return ocx.GetSActPriceList(strBaseAssetGb);
    }

    /// <summary>GetSMonthList</summary>
    public virtual string GetSMonthList(string strBaseAssetGb)
    {
        ThrowIfNull(ocx);

        return ocx.GetSMonthList(strBaseAssetGb);
    }

    /// <summary>GetSOptionCode</summary>
    public virtual string GetSOptionCode(string strBaseAssetGb, string strActPrice, int nCp, string strMonth)
    {
        ThrowIfNull(ocx);

        return ocx.GetSOptionCode(strBaseAssetGb, strActPrice, nCp, strMonth);
    }

    /// <summary>GetSOptionCodeByMonth</summary>
    public virtual string GetSOptionCodeByMonth(string strBaseAssetGb, string sTrCode, int nCp, string strMonth)
    {
        ThrowIfNull(ocx);

        return ocx.GetSOptionCodeByMonth(strBaseAssetGb, sTrCode, nCp, strMonth);
    }

    /// <summary>GetSOptionCodeByActPrice</summary>
    public virtual string GetSOptionCodeByActPrice(string strBaseAssetGb, string sTrCode, int nCp, int nTick)
    {
        ThrowIfNull(ocx);

        return ocx.GetSOptionCodeByActPrice(strBaseAssetGb, sTrCode, nCp, nTick);
    }

    /// <summary>GetSFOBasisAssetList</summary>
    public virtual string GetSFOBasisAssetList()
    {
        ThrowIfNull(ocx);

        return ocx.GetSFOBasisAssetList();
    }

    /// <summary>
    /// 지수옵션 소수점을 제거한 ATM값을 전달합니다. 예를들어 ATM값이 247.50 인 경우 24750이 전달됩니다.
    /// </summary>
    /// <returns></returns>
    public virtual string GetOptionATM()
    {
        ThrowIfNull(ocx);

        return ocx.GetOptionATM();
    }

    /// <summary>GetSOptionATM</summary>
    public virtual string GetSOptionATM(string strBaseAssetGb)
    {
        ThrowIfNull(ocx);

        return ocx.GetSOptionATM(strBaseAssetGb);
    }

    /// <summary>GetBranchCodeName</summary>
    public virtual string GetBranchCodeName()
    {
        ThrowIfNull(ocx);

        return ocx.GetBranchCodeName();
    }

    /// <summary>CommInvestRqData</summary>
    [Obsolete("더 이상 사용할 수 없는 함수입니다.")]
    public virtual int CommInvestRqData(string sMarketGb, string sRQName, string sScreenNo)
    {
        ThrowIfNull(ocx);

        return ocx.CommInvestRqData(sMarketGb, sRQName, sScreenNo);
    }

    /// <summary>
    /// 서버에 주문을 전송하는 함수 입니다. 국내주식 신용주문 전용함수입니다. 대주거래는 지원하지 않습니다. ※ 프로그램매매 주문은 실거래 서버에서만 주문하실수 있으며 모의투자 서버에서는 지원하지 않습니다.
    /// </summary>
    /// <param name="sRQName">사용자 구분명</param>
    /// <param name="sScreenNo">화면번호</param>
    /// <param name="sAccNo">계좌번호 10자리</param>
    /// <param name="nOrderType">주문유형은 아래 참고</param>
    /// <param name="sCode">종목코드</param>
    /// <param name="nQty">주문수량</param>
    /// <param name="nPrice">주문가격</param>
    /// <param name="sHogaGb">거래구분(혹은 호가구분)은 아래 참고</param>
    /// <param name="sCreditGb">신용거래구분 (아래에서 참고)</param>
    /// <param name="sLoanDate">대출일 (YYYYMMDD. 아래에서 참고)</param>
    /// <param name="sOrgOrderNo">원주문번호</param>
    /// <returns><inheritdoc cref="SendOrder"/></returns>
    /// <remarks><inheritdoc cref="SendOrder"/>
    /// <br/>[신용거래]<br/>
    /// 03 : 신용매수 - 자기융자<br/>
    /// 33 : 신용매도 - 자기융자<br/>
    /// 99 : 신용매도 - 자기융자 합<br/>
    /// <br/>[대출일]<br/>
    /// YYYYMMDD형식 날짜를 입력합니다. (ex 대출일이 2023년 1월 1일이면 "20230101"입력)<br/>
    /// 신용매도 - 자기융자 일때는 종목별 대출일을 입력하고 신용매도 - 융자합이면 "99991231"을 입력합니다.<br/>
    /// </remarks>
    public virtual int SendOrderCredit(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, int nPrice, string sHogaGb, string sCreditGb, string sLoanDate, string sOrgOrderNo)
    {
        ThrowIfNull(ocx);

        return ocx.SendOrderCredit(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, nPrice, sHogaGb, sCreditGb, sLoanDate, sOrgOrderNo);
    }

    /// <summary>
    /// OpenAPI기본 기능외에 기능을 사용하기 쉽도록 만든 함수입니다.
    /// </summary>
    /// <param name="sFunctionName">함수이름 혹은 기능이름</param>
    /// <param name="sParam">함수 매개변수</param>
    /// <returns></returns>
    /// <remarks>
    /// 예)<br/>
    /// KOA_Functions("ShowAccountWindow", ""); // 계좌비밀번호 입력창을 띄웁니다.<br/>
    /// KOA_Functions("GetServerGubun", ""); // 접속서버 구분을 알려준다. 1 : 모의투자 접속, 나머지 : 실서버 접속<br/>
    /// KOA_Functions("GetMasterStockInfo", "039490"); // 입력한 종목에 대한 대분류, 중분류, 업종구분값을 구분자 '|'와 ';'로 연결한 문자열 (ex: 시장구분0|코스피;시장구분1|중형주;업종구분|금융업;)<br/>
    /// KOA_Functions("SetConditionSearchFlag", "AddPrice"); // 조검검색시 현재가 포함하도록 설정<br/>
    /// KOA_Functions("SetConditionSearchFlag", "DelPrice"); // 조검검색시 현재가 미포함(원래상태로 전환) 설정<br/>
    /// KOA_Functions("GetUpjongCode", "0"); // 업종코드요청, 두번째 인자: 0:코스피, 1: 코스닥, 2:KOSPI200, 4:KOSPI100(KOSPI50), 7:KRX100, 
    /// 함수 반환값은 "시장구분값,업종코드,업종명|시장구분값,업종코드,업종명|...|시장구분값,업종코드,업종명"<br/>
    /// KOA_Functions("GetUpjongNameByCode", "업종코드입력"); // 업종이름 획득<br/>
    /// KOA_Functions("IsOrderWarningETF", "종목코드(6자리)"); // ETF 투자유의 종목 여부, 투자유의 종목인 경우 "1" 값이 리턴, 그렇지 않은 경우 "0" 값 리턴. (ETF가 아닌 종목을 입력시 "0" 값 리턴.)<br/>
    /// KOA_Functions("IsOrderWarningStock", "종목코드(6자리)"); // 주식 전종목대상 투자유의 종목 여부, 리턴 값 - "0":해당없음, "2":정리매매, "3":단기과열, "4":투자위험, "5":투자경고<br/>
    /// 거래소 제도개선으로 주식 종목 중 정리매매/단기과열/투자위험/투자경고 종목을 매수주문하는 경우<br/>
    /// 경고 메세지 창이 출력되도록 기능이 추가 되었습니다.<br/>
    /// 경고 메세지 창이 출력되도록 기능이 추가 되었습니다.(경고 창 출력 시 주문을 중지/전송 선택 가능합니다.)<br/>
    /// 주문 함수를 호출하기 전에 특정 종목이 투자유의종목인지 확인할 수 있습니다.<br/>
    /// KOA_Functions("GetMasterListedStockCntEx", "종목코드(6자리)"); // 상장주식수 구하기<br/>
    /// KOA_Functions("GetStockMarketKind", "종목코드(6자리)"); // 종목코드로 Market구분 구하기, 리턴값 "0":코스피, "10":코스닥, "3":ELW, "8":ETF, "4"/"14":뮤추얼펀드, "6"/"16":리츠, "9"/"19":하이일드펀드, "30":제3시장, "60":ETN<br/>
    /// ...<br/>
    /// </remarks>
    public virtual string KOA_Functions(string sFunctionName, string sParam)
    {
        ThrowIfNull(ocx);

        return ocx.KOA_Functions(sFunctionName, sParam);
    }

    /// <summary>SetInfoData</summary>
    [Obsolete("더 이상 사용할 수 없는 함수입니다.")]
    public virtual int SetInfoData(string sInfoData)
    {
        ThrowIfNull(ocx);

        return ocx.SetInfoData(sInfoData);
    }

    /// <summary>
    /// 종목코드와 FID 리스트를 이용해서 실시간 시세를 등록하는 함수입니다.
    /// </summary>
    /// <param name="strScreenNo">화면번호</param>
    /// <param name="strCodeList">종목코드 리스트</param>
    /// <param name="strFidList">실시간 FID리스트</param>
    /// <param name="strOptType">실시간 등록 타입, 0또는 1</param>
    /// <returns></returns>
    public virtual int SetRealReg(string strScreenNo, string strCodeList, string strFidList, string strOptType)
    {
        ThrowIfNull(ocx);

        return ocx.SetRealReg(strScreenNo, strCodeList, strFidList, strOptType);
    }

    /// <summary>
    /// 서버에 저장된 사용자 조건검색 목록을 요청합니다.
    /// </summary>
    /// <returns>조건검색 목록 요청을 성공하면 1, 아니면 0을 리턴합니다.</returns>
    /// <remarks>조건검색 목록을 모두 수신하면 <see cref="OnReceiveConditionVer"/> 이벤트가 발생됩니다.</remarks>
    public virtual int GetConditionLoad()
    {
        ThrowIfNull(ocx);

        return ocx.GetConditionLoad();
    }

    /// <summary>
    /// 서버에서 수신한 사용자 조건식을 조건식의 고유번호와 조건식 이름을 한 쌍으로 하는 문자열들로 전달합니다.
    /// </summary>
    /// <remarks>이 함수는 <see cref="OnReceiveConditionVer"/> 이벤트에서 사용해야 합니다.</remarks>
    /// <returns>"1^내조건식1;2^내조건식2;5^내조건식3;,,,,,,,,,,"</returns>
    public virtual string GetConditionNameList()
    {
        ThrowIfNull(ocx);

        return ocx.GetConditionNameList();
    }

    /// <summary>
    /// 서버에 조건검색을 요청하는 함수입니다.<br/>요청 결과는 <see cref="OnReceiveTrCondition"/> 이벤트로 수신됩니다
    /// </summary>
    /// <param name="strScrNo">화면번호</param>
    /// <param name="strConditionName">조건식 이름</param>
    /// <param name="nIndex">조건식 고유번호</param>
    /// <param name="nSearch">실시간옵션. 0:조건검색만, 1:조건검색+실시간 조건검색</param>
    /// <returns>리턴값 1이면 성공이며, 0이면 실패입니다.</returns>
    public virtual int SendCondition(string strScrNo, string strConditionName, int nIndex, int nSearch)
    {
        ThrowIfNull(ocx);

        return ocx.SendCondition(strScrNo, strConditionName, nIndex, nSearch);
    }

    /// <summary>
    /// 실시간 조건검색을 중지할 때 사용하는 함수입니다.
    /// </summary>
    /// <param name="strScrNo">화면번호</param>
    /// <param name="strConditionName">조건식 이름</param>
    /// <param name="nIndex">조건식 고유번호</param>
    public virtual void SendConditionStop(string strScrNo, string strConditionName, int nIndex)
    {
        ThrowIfNull(ocx);

        ocx.SendConditionStop(strScrNo, strConditionName, nIndex);
    }

    /// <summary>
    /// 조회 수신데이터 크기가 큰 차트데이터를 한번에 가져올 목적으로 만든 차트조회 전용함수입니다.
    /// </summary>
    /// <param name="strTrCode">TR 이름</param>
    /// <param name="strRecordName">레코드이름</param>
    /// <returns></returns>
    public virtual object GetCommDataEx(string strTrCode, string strRecordName)
    {
        ThrowIfNull(ocx);

        return ocx.GetCommDataEx(strTrCode, strRecordName);
    }

    /// <summary>
    /// 실시간시세 해지 함수이며 화면번호와 종목코드를 이용해서 상세하게 설정할 수 있습니다.
    /// </summary>
    /// <param name="strScrNo">화면번호 또는 "ALL"</param>
    /// <param name="strDelCode">종목코드 또는 "ALL"</param>
    public virtual void SetRealRemove(string strScrNo, string strDelCode)
    {
        ThrowIfNull(ocx);

        ocx.SetRealRemove(strScrNo, strDelCode);
    }

    /// <summary>
    /// 종목코드에 해당되는 마켓 타입을 반환합니다.
    /// </summary>
    /// <param name="sTrCode">종목코드</param>
    /// <returns>"0":코스피, "10":코스닥, "3":ELW, "8":ETF, "4"/"14":뮤추얼펀드, "6"/"16":리츠, "9"/"19":하이일드펀드, "30":제3시장, "60":ETN</returns>
    public virtual int GetMarketType(string sTrCode)
    {
        ThrowIfNull(ocx);

        return ocx.GetMarketType(sTrCode);
    }

    #endregion

    private readonly _DKHOpenAPI? ocx;

    /// <summary>
    /// OCX 컨트롤을 생성합니다.<br/>
    /// GUI모드에서 메인 윈도우 핸들을 인자로 전달합니다.<br/>
    /// </summary>
    /// <param name="hWndParent"></param>
    public AxKHOpenAPI(nint hWndParent = 0) : base(hWndParent)
    {
        ocx = dispatch as _DKHOpenAPI;
    }

    /// <inheritdoc/>
    protected override object CreateEventSink() => new AxKHOpenAPIEventMulticaster(this);
}
