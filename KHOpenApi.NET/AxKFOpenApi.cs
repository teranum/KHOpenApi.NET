using KHOpenApi.NET.Attributes;

namespace KHOpenApi.NET;


/// <summary>
/// 해외선물옵션용 OpenAPI+ ActiveX 컨트롤을 위한 래퍼 클래스
/// </summary>
//[ComId("d1acab7d-a3af-49e4-9004-c9e98344e17a")]
[ComId("KFOPENAPI.KFOpenAPICtrl.1")]
public class AxKFOpenAPI : AxBase
{
    #region 이벤트 핸들러

    internal enum EventId
    {
        OnReceiveTrData = 1,
        OnReceiveMsg = 2,
        OnReceiveRealData = 3,
        OnReceiveChejanData = 4,
        OnEventConnect = 5,
    }

    /// <inheritdoc cref="_DKFOpenAPIEvents_OnReceiveTrDataEvent"/>
    public event _DKFOpenAPIEvents_OnReceiveTrDataEventHandler? OnReceiveTrData;

    /// <inheritdoc cref="_DKFOpenAPIEvents_OnReceiveRealDataEvent"/>
    public event _DKFOpenAPIEvents_OnReceiveRealDataEventHandler? OnReceiveRealData;

    /// <inheritdoc cref="_DKFOpenAPIEvents_OnReceiveMsgEvent"/>
    public event _DKFOpenAPIEvents_OnReceiveMsgEventHandler? OnReceiveMsg;

    /// <inheritdoc cref="_DKFOpenAPIEvents_OnReceiveChejanDataEvent"/>
    public event _DKFOpenAPIEvents_OnReceiveChejanDataEventHandler? OnReceiveChejanData;

    /// <inheritdoc cref="_DKFOpenAPIEvents_OnEventConnectEvent"/>
    public event _DKFOpenAPIEvents_OnEventConnectEventHandler? OnEventConnect;

    internal void RaiseOnOnReceiveTrData(object sender, _DKFOpenAPIEvents_OnReceiveTrDataEvent e)
    {
        if (!ProcInternalAsyncNode((int)EventId.OnReceiveTrData, e))
            OnReceiveTrData?.Invoke(this, e);
    }

    internal void RaiseOnOnReceiveRealData(object sender, _DKFOpenAPIEvents_OnReceiveRealDataEvent e)
    {
        OnReceiveRealData?.Invoke(this, e);
    }

    internal void RaiseOnOnReceiveMsg(object sender, _DKFOpenAPIEvents_OnReceiveMsgEvent e)
    {
        if (!ProcInternalAsyncNode((int)EventId.OnReceiveMsg, e))
            OnReceiveMsg?.Invoke(this, e);
    }

    internal void RaiseOnOnReceiveChejanData(object sender, _DKFOpenAPIEvents_OnReceiveChejanDataEvent e)
    {
        OnReceiveChejanData?.Invoke(this, e);
    }

    internal void RaiseOnOnEventConnect(object sender, _DKFOpenAPIEvents_OnEventConnectEvent e)
    {
        if (!ProcInternalAsyncNode((int)EventId.OnEventConnect, e))
            OnEventConnect?.Invoke(this, e);
    }

    #endregion

    #region 메서드

    /// <summary>
    /// 로그인 윈도우를 실행한다.
    /// </summary>
    /// <param name="nAutoUpgrade">버전처리시, 수동 또는 자동 설정을 위한 구분값(0 : 수동진행, 1 : 자동진행)</param>
    /// <returns>
    /// 0	: 정상처리<br/>
    /// -1	: 미접속상태<br/>
    /// -100	: 로그인시 접속 실패(아이피오류 또는 접속정보 오류<br/>
    /// -101	: 서버 접속 실패<br/>
    /// -102	: 버전처리가 실패하였습니다.
    /// </returns>
    /// <remarks>
    /// nAutoUpgrade = 0 : 수동진행<br/>
    /// 로그인창 -> 버전처리진행 -> 메시지박스(OCX포함한 프로그램을 종료 후, 버전처리 요망...)<br/>
    /// -> 프로그램(OCX포함된) 수동으로 직접 종료 -> 메시지박스 확인 수동클릭 -> 버전처리진행/완료<br/>
    /// -> 고객이 직접 프로그램 재실행<br/>
    /// <br/>nAutoUpgrade = 1 : 자동진행<br/>
    /// 로그인창 -> 버전처리진행 -> 프로그램(OCX포함된) 자동종료 -> 버전처리진행/완료<br/>
    /// -> 자동으로 프로그램(OCX포함된) 재실행<br/>
    /// <br/>[비고]<br/>
    /// 수동/자동 여부는 고객 프로그램(OCX포함)이 단독으로 사용되어지는 경우에는 자동으로 선택하시고,<br/>
    /// 프로그램(OCX포함)이 다른 프로그램과 연동되어져 서로 데이타교환이 있는 경우에는 수동으로 선택해서 사용 바랍니다.<br/>
    /// 엑셀에서 OCX사용시, 수동으로 선택해서 사용 바랍니다.<br/>
    /// <br/>Ex)<br/>
    /// openApi.CommConnect(0); //수동<br/>
    /// openApi.CommConnect(1); //자동<br/>
    /// </remarks>
    public virtual int CommConnect(int nAutoUpgrade)
    {
        ThrowIfNull(ocx);

        return ocx.CommConnect(nAutoUpgrade);
    }

    /// <summary>
    /// 조회를 서버로 송신한다.
    /// </summary>
    /// <param name="sRQName">사용자구분명 입력</param>
    /// <param name="sTrCode">Tr목록의 TrCode 입력 (예 : opt10001)</param>
    /// <param name="sPrevNext">서버에서 내려준 Next키 값  입력</param>
    /// <param name="sScreenNo">4자리의 화면번호 입력 (1 ~ 9999 : 숫자형식으로만 가능)</param>
    /// <returns>
    /// -103 	: TrCode가 존재하지 않습니다.<br/>
    /// -200 	: 조회과부하<br/>
    /// -201 	: 주문과부하<br/>
    /// -202 	: 조회입력값(명칭/누락) 오류<br/>
    /// -203 	: 종목코드 미존재<br/>
    /// -300 	: 주문입력값 오류<br/>
    /// -301 	: 계좌비밀번호를 입력하십시오.<br/>
    /// -302 	: 타인 계좌를 사용할 수 없습니다.
    /// </returns>
    /// <remarks>
    /// </remarks>
    public virtual int CommRqData(string sRQName, string sTrCode, string sPrevNext, string sScreenNo)
    {
        ThrowIfNull(ocx);

        return ocx.CommRqData(sRQName, sTrCode, sPrevNext, sScreenNo);
    }

    /// <summary>
    /// 조회 입력값을 셋팅한다
    /// </summary>
    /// <param name="sID">입력 아이디명</param>
    /// <param name="sValue">입력 값 </param>
    public virtual void SetInputValue(string sID, string sValue)
    {
        ThrowIfNull(ocx);

        ocx.SetInputValue(sID, sValue);
    }

    /// <summary>
    /// 수신데이타를 반환한다.
    /// </summary>
    /// <param name="strTrCode">Tr목록의 TrCode</param>
    /// <param name="strRecordName">조회시 sRQName</param>
    /// <param name="nIndex">Row 인덱스</param>
    /// <param name="strItemName">Tr목록의 싱글/멀티데이타의 필드명</param>
    /// <returns></returns>
    public virtual string GetCommData(string strTrCode, string strRecordName, int nIndex, string strItemName)
    {
        ThrowIfNull(ocx);

        return ocx.GetCommData(strTrCode, strRecordName, nIndex, strItemName);
    }

    /// <summary>
    /// OpenAPI의 서버 접속을 해제한다.
    /// </summary>
    /// <remarks>
    /// 프로그램 종료시 적용시키는 함수이며, 미적용되어도 OpenAPI 내부에서 처리하게 되어 있음.
    /// </remarks>
    public virtual void CommTerminate()
    {
        ThrowIfNull(ocx);

        ocx.CommTerminate();
    }

    /// <summary>
    /// 수신데이타(멀티데이타) 반복횟수를 반환한다.
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
    /// 화면 내의 모든 리얼데이터 요청을 제거한다.
    /// </summary>
    /// <param name="sScreenNo">4자리의 화면번호 입력 (1 ~ 9999 : 숫자형식으로만 가능)</param>
    /// <remarks>화면을 종료할 때 반드시 위 함수를 호출해야 리얼데이타 해제가 된다.</remarks>
    public virtual void DisconnectRealData(string sScreenNo)
    {
        ThrowIfNull(ocx);

        ocx.DisconnectRealData(sScreenNo);
    }

    /// <summary>
    /// 실시간데이타를 반환한다.
    /// </summary>
    /// <param name="sRealType">"해외선물시세", "해외옵션시세", "해외선물호가", "해외옵션호가" 입력 (미입력해도 가능) </param>
    /// <param name="nFid">실시간목록의 필드값을 참조</param>
    /// <returns>실시간 데이타 반환</returns>
    /// <remarks>입력부에 strRealType 값을 셋팅 안해도 리턴값 가능</remarks>
    public virtual string GetCommRealData(string sRealType, int nFid)
    {
        ThrowIfNull(ocx);

        return ocx.GetCommRealData(sRealType, nFid);
    }

    /// <summary>
    /// 체결잔고 실시간 데이타를 반환한다.
    /// </summary>
    /// <param name="nFid">실시간목록의 필드값을 참조  </param>
    /// <returns>체결잔고 데이타 반환</returns>
    public virtual string GetChejanData(int nFid)
    {
        ThrowIfNull(ocx);

        return ocx.GetChejanData(nFid);
    }

    /// <summary>
    /// 주문을 서버로 송신한다.
    /// </summary>
    /// <param name="sRQName">사용자구분명 입력</param>
    /// <param name="sScreenNo">4자리의 화면번호 입력 (1 ~ 9999 : 숫자형식으로만 가능)</param>
    /// <param name="sAccNo">계좌번호</param>
    /// <param name="nOrderType">주문유형 (1:신규매도, 2:신규매수 3:매도취소, 4:매수취소, 5:매도정정, 6:매수정정)</param>
    /// <param name="sCode">종목코드</param>
    /// <param name="nQty">주문수량</param>
    /// <param name="sPrice">주문단가</param>
    /// <param name="sStopPrice">Stop단가</param>
    /// <param name="sHogaGb">거래구분 (1:시장가, 2:지정가, 3:STOP, 4:STOP LIMIT)</param>
    /// <param name="sOrgOrderNo">원주문번호</param>
    /// <returns>
    /// 0    : 정상처리<br/>
    /// -201 	: 주문과부하<br/>
    /// -203 	: 종목코드 미존재<br/>
    /// -300 	: 주문입력값 오류<br/>
    /// -301 	: 계좌비밀번호를 입력하십시오.<br/>
    /// -302 	: 타인 계좌를 사용할 수 없습니다.<br/>
    /// -303 	: 경고-주문수량 200개 초과<br/>
    /// -304 	: 제한-주문수량 400개 초과
    /// </returns>
    public virtual int SendOrder(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, string sPrice, string sStopPrice, string sHogaGb, string sOrgOrderNo)
    {
        ThrowIfNull(ocx);

        return ocx.SendOrder(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, sPrice, sStopPrice, sHogaGb, sOrgOrderNo);
    }

    /// <summary>
    /// 로그인 사용자 정보를 반환한다.
    /// </summary>
    /// <param name="sTag">사용자정보 구분값</param>
    /// <returns>로그인정보 데이타 반환</returns>
    /// <remarks>
    /// [sTag]<br/>
    /// ACCOUNT_CNT	- 전체 계좌 개수를 반환한다.<br/>
    /// ACCNO		- 전체 계좌를 반환한다. 계좌별 구분은 ‘;’이다.<br/>
    /// USER_ID		- 사용자 ID를 반환한다.<br/>
    /// USER_NAME	- 사용자명을 반환한다.<br/>
    /// KEY_BSECGB	- 키보드보안 해지여부. 0:정상, 1:해지<br/>
    /// FIREW_SECGB	- 방화벽 설정 여부. 0:미설정, 1:설정, 2:해지
    /// </remarks>
    public virtual string GetLoginInfo(string sTag)
    {
        ThrowIfNull(ocx);

        return ocx.GetLoginInfo(sTag);
    }

    /// <summary>
    /// 해외선물 상품리스트를 반환한다.
    /// </summary>
    /// <returns>해외선물 상품리스트, 상품간 구분은 ";"</returns>
    public virtual string GetGlobalFutureItemlist()
    {
        ThrowIfNull(ocx);

        return ocx.GetGlobalFutureItemlist();
    }

    /// <summary>
    /// 해외옵션 상품리스트를 반환한다.
    /// </summary>
    /// <returns>해외옵션 상품리스트, 상품간 구분은 ";"</returns>
    public virtual string GetGlobalOptionItemlist()
    {
        ThrowIfNull(ocx);

        return ocx.GetGlobalOptionItemlist();
    }

    /// <summary>
    /// 해외상품별 해외선물 종목코드 리스트를 반환
    /// </summary>
    /// <param name="sItem">해외상품 입력 (6A, ES, ...)  </param>
    /// <returns>해외선물 종목코드리스트, 종목간 구분은 ";"</returns>
    public virtual string GetGlobalFutureCodelist(string sItem)
    {
        ThrowIfNull(ocx);

        return ocx.GetGlobalFutureCodelist(sItem);
    }

    /// <summary>
    /// 해외상품별 해외옵션 종목코드 리스트를 반환
    /// </summary>
    /// <param name="sItem">해외상품 입력 (6A, ES, ...)  </param>
    /// <returns>해외옵션 종목코드리스트, 종목간 구분은 ";"</returns>
    public virtual string GetGlobalOptionCodelist(string sItem)
    {
        ThrowIfNull(ocx);

        return ocx.GetGlobalOptionCodelist(sItem);
    }

    /// <summary>
    /// 현재 접속상태를 반환한다.
    /// </summary>
    /// <returns>접속상태 (0 : 미연결,  1 : 연결완료) </returns>
    public virtual int GetConnectState()
    {
        ThrowIfNull(ocx);

        return ocx.GetConnectState();
    }

    /// <summary>
    /// OpenAPI모듈의 경로를 반환한다.
    /// </summary>
    /// <returns>Path 경로위치</returns>
    public virtual string GetAPIModulePath()
    {
        ThrowIfNull(ocx);

        return ocx.GetAPIModulePath();
    }

    /// <summary>
    /// 공통함수로 추후 추가함수가 필요시 사용할 함수이다.
    /// </summary>
    /// <param name="sFuncName">함수명 입력</param>
    /// <param name="sParam">입력항목 입력  </param>
    /// <returns>함수에 대한 반환값</returns>
    public virtual string GetCommonFunc(string sFuncName, string sParam)
    {
        ThrowIfNull(ocx);

        return ocx.GetCommonFunc(sFuncName, sParam);
    }

    /// <summary>
    /// 가격 진법에 따라 변환된 가격을 반환한다
    /// </summary>
    /// <param name="sCode">종목코드 입력</param>
    /// <param name="sPrice">가격 입력</param>
    /// <param name="nType">가격타입 입력 (0 : 진법(표시가격) -> 10진수,  1 : 10진수 -> 진법(표시가격))  </param>
    /// <returns>가격에 대한 반환값</returns>
    public virtual string GetConvertPrice(string sCode, string sPrice, int nType)
    {
        ThrowIfNull(ocx);

        return ocx.GetConvertPrice(sCode, sPrice, nType);
    }

    /// <summary>
    /// 해외선물옵션 종목코드 정보를 타입별로 반환한다.
    /// </summary>
    /// <param name="nGubun">해외선물옵션 구분값 입력 (0 : 해외선물, 1 : 해외옵션)</param>
    /// <param name="sType">상품타입 입력 ("" : 전체, IDX : 지수, CUR : 통화, INT : 금리, MTL : 금속, ENG : 에너지, CMD : 농산물) </param>
    /// <returns>종목코드 정보리스트들을 문자값으로 반환한다</returns>
    public virtual string GetGlobalFutOpCodeInfoByType(int nGubun, string sType)
    {
        ThrowIfNull(ocx);

        return ocx.GetGlobalFutOpCodeInfoByType(nGubun, sType);
    }

    /// <summary>
    /// 해외선물옵션 종목코드정보를 종목코드별로 반환한다.
    /// </summary>
    /// <param name="sCode">해외선물옵션 종목코드 입력</param>
    /// <returns>종목코드 정보를 문자값으로 반환한다</returns>
    public virtual string GetGlobalFutOpCodeInfoByCode(string sCode)
    {
        ThrowIfNull(ocx);

        return ocx.GetGlobalFutOpCodeInfoByCode(sCode);
    }

    /// <summary>
    /// 해외선물 상품리스트를 타입별로 반환한다
    /// </summary>
    /// <param name="sType">상품타입 입력 (IDX : 지수, CUR : 통화, INT : 금리, MTL : 금속, ENG : 에너지, CMD : 농산물) </param>
    /// <returns>상품리스트들을 문자값으로 반환한다</returns>
    public virtual string GetGlobalFutureItemlistByType(string sType)
    {
        ThrowIfNull(ocx);

        return ocx.GetGlobalFutureItemlistByType(sType);
    }

    /// <summary>
    /// 해외선물종목코드를 상품/월물별로 반환한다.
    /// </summary>
    /// <param name="sItem">상품코드 입력 (6A, ES...)</param>
    /// <param name="sMonth">월물 입력 ("201606")</param>
    /// <returns>종목코드를 문자값으로 반환한다</returns>
    public virtual string GetGlobalFutureCodeByItemMonth(string sItem, string sMonth)
    {
        ThrowIfNull(ocx);

        return ocx.GetGlobalFutureCodeByItemMonth(sItem, sMonth);
    }

    /// <summary>
    /// 해외옵션 종목코드를 상품/콜풋/행사가/월물별로 반환한다.
    /// </summary>
    /// <param name="sItem">상품코드 입력 (6A, ES...)</param>
    /// <param name="sCPGubun">콜/풋 구분 입력 (C : 콜, P : 풋)</param>
    /// <param name="sActivePrice">행사가 입력 (0.7615)</param>
    /// <param name="sMonth">월물 입력 ("201606")</param>
    /// <returns>종목코드를 문자값으로 반환한다</returns>
    public virtual string GetGlobalOptionCodeByMonth(string sItem, string sCPGubun, string sActivePrice, string sMonth)
    {
        ThrowIfNull(ocx);

        return ocx.GetGlobalOptionCodeByMonth(sItem, sCPGubun, sActivePrice, sMonth);
    }

    /// <summary>
    /// 해외옵션 월물리스트를 상품별로 반환한다.
    /// </summary>
    /// <param name="sItem">상품코드 입력 (6A, ES...)  </param>
    /// <returns>월물리스트를 문자값으로 반환한다</returns>
    public virtual string GetGlobalOptionMonthByItem(string sItem)
    {
        ThrowIfNull(ocx);

        return ocx.GetGlobalOptionMonthByItem(sItem);
    }

    /// <summary>
    /// 해외옵션행사가리스트를 상품별로 반환한다.
    /// </summary>
    /// <param name="sItem">해외상품 입력 (6A, ES, ...)  </param>
    /// <returns>행사가리스트를 문자값으로 반환한다</returns>
    public virtual string GetGlobalOptionActPriceByItem(string sItem)
    {
        ThrowIfNull(ocx);

        return ocx.GetGlobalOptionActPriceByItem(sItem);
    }

    /// <summary>
    /// 해외선물 상품타입리스트를 반환한다.
    /// </summary>
    /// <returns>상품타입리스트를 문자값으로 반환한다</returns>
    public virtual string GetGlobalFutureItemTypelist()
    {
        ThrowIfNull(ocx);

        return ocx.GetGlobalFutureItemTypelist();
    }

    /// <summary>
    /// 수신된 전체데이터를 반환한다
    /// </summary>
    /// <param name="sTrCode">Tr목록의 TrCode</param>
    /// <param name="sRecordName">사용자구분명 입력</param>
    /// <param name="nGubun">수신데이타 구분 입력 (0 : 전체(싱글+멀티),  1 : 싱글데이타, 2 : 멀티데이타)</param>
    /// <returns>수신 전체데이터를 문자값으로 반환한다(TR목록에서 필드 사이즈 참조(필드명 옆 가로안의 숫자))</returns>
    /// <remarks>
    /// 모든 시세/원장/차트 조회가 가능하며, 특히 차트데이타 같은 대용량 데이타를 한 번에 수신해서 처리가능.
    /// </remarks>
    public virtual string GetCommFullData(string sTrCode, string sRecordName, int nGubun)
    {
        ThrowIfNull(ocx);

        return ocx.GetCommFullData(sTrCode, sRecordName, nGubun);
    }

    #endregion

    private readonly _DKFOpenAPI? ocx;

    /// <summary>
    /// OCX를 생성합니다.
    /// </summary>
    /// <param name="hWndParent">윈도우 핸들</param>
    /// <remarks>GUI모드에서 메인 윈도우 핸들을 설정해준다</remarks>
    public AxKFOpenAPI(nint hWndParent = 0) : base(hWndParent)
    {
        ocx = dispatch as _DKFOpenAPI;
    }

    /// <inheritdoc/>
    protected override object CreateEventSink() => new AxKFOpenAPIEventMulticaster(this);
}
