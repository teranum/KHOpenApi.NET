using KHOpenApi.NET.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KHOpenApi.NET;

/// <summary>
/// AxKHOpenAPI 클래스의 확장 메서드를 제공하는 정적 클래스
/// </summary>
public static class AxKHOpenApiExtension
{
    private const int DEF_SUCCESS_CODE = 0;
    private const int DEF_CONDITION_SUCCESS_CODE = 1;

    /// <summary>
    /// Error Code에 해당하는 메시지 가져오기
    /// </summary>
    /// <param name="api"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static string GetErrorMessage(this AxKHOpenAPI api, int code)
    {
        return code switch
        {
            1 or 0 => "정상처리",
            -10 => "실패",
            -11 => "조건번호 없음",
            -12 => "조건번호와 조건식 불일치",
            -13 => "조건검색 조회요청 초과",
            -14 => "실시간 조건검색 요청 10개 초과",
            -15 => "거래소 구분값 오류",
            -16 => "조건식 이름 이상",
            -100 => "사용자정보교환 실패",
            -101 => "서버 접속 실패",
            -102 => "버전처리 실패",
            -103 => "개인방화벽 실패",
            -104 => "메모리 보호실패",
            -105 => "함수입력값 오류",
            -106 => "통신연결 종료",
            -107 => "보안모듈 오류",
            -108 => "공인인증 로그인 필요",
            -200 => "시세조회 과부하",
            -201 => "전문작성 초기화 실패",
            -202 => "전문작성 입력값 오류",
            -203 => "데이터 없음",
            -204 => "조회가능한 종목수 초과",
            -205 => "데이터 수신 실패",
            -206 => "조회가능한 FID수 초과",
            -207 => "실시간 해제 오류",
            -209 => "시세조회제한",
            -300 => "입력값 오류",
            -301 => "계좌비밀번호 없음",
            -302 => "타인계좌 사용오류",
            -303 => "주문가격이 주문착오 금액기준 초과",
            -304 => "주문가격이 주문착오 금액기준 초과",
            -305 => "주문수량이 총발행주수의 1% 초과오류",
            -306 => "주문수량은 총발행주수의 3% 초과오류",
            -307 => "주문전송 실패",
            -308 => "주문전송 과부하",
            -309 => "주문수량 300계약 초과",
            -310 => "주문수량 500계약 초과",
            -311 => "주문전송제한 과부하",
            -340 => "계좌정보 없음",
            -500 => "종목코드 없음",

            InternalErrorCodes.ERR_ASYNC_WORKING => "비동기요청: 이미 작동중 입니다",
            InternalErrorCodes.ERR_ASYNC_TIMEOUT => "비동기요청: 타임아웃",
            InternalErrorCodes.ERR_ASYNC_NOORDER => "비동기요청: 주문번호가 없습니다.",

            _ => "unknown",
        };
    }


    /// <summary>
    /// 비동기 로그인 요청을 수행합니다.<br/>
    /// <inheritdoc cref="AxKHOpenAPI.CommConnect"/>
    /// </summary>
    /// <remarks>함수 내부에서  <see cref="AxKHOpenAPI.OnEventConnect"/> 이벤트 처리가 자동으로 진행되며 서버연결 성공/실패 결과를 반환합니다.</remarks>
    /// <returns>
    /// (int nRet, string sMsg) 튜플로 결과를 반환합니다.<br/>
    /// nRet값 0이면 성공이며, 그외 실패입니다.<br/>
    /// 실패시 sMsg에 에러메시지가 전달됩니다.
    /// </returns>
    public static async Task<(int nRet, string sMsg)> CommConnectAsync(this AxKHOpenAPI api)
    {
        // 이미 비동기 요청이 진행 중인지 확인
        int nIdentId = AsyncNode.GetIdentId(["CommConnectAsync"]);
        if (api.InternalAsyncNodes.Any(x => x.IdentId == nIdentId))
            return (InternalErrorCodes.ERR_ASYNC_WORKING, api.GetErrorMessage(InternalErrorCodes.ERR_ASYNC_WORKING));

        int nRet = DEF_SUCCESS_CODE;
        // 연결 이벤트를 위한 비동기 노드 생성
        using var asyncNode = new AsyncNode(["CommConnectAsync"]);
        asyncNode.EventCallback = (nEvent, args) =>
        {
            // 연결 이벤트 처리
            if (nEvent == (int)AxKHOpenAPI.EventId.OnEventConnect)
            {
                nRet = ((_DKHOpenAPIEvents_OnEventConnectEvent)args).nErrCode;
                asyncNode.Set(); // 비동기 작업 완료 신호
                return true;
            }
            return false;
        };

        // 비동기 노드 설정 및 연결 요청
        api.InternalAsyncNodes.Add(asyncNode);
        nRet = api.CommConnect();
        if (nRet == DEF_SUCCESS_CODE)
        {
            await asyncNode.Wait(); // 연결 완료까지 대기
        }
        api.InternalAsyncNodes.Remove(asyncNode); // 비동기 노드 정리

        return (nRet, api.GetErrorMessage(nRet));
    }

    private static async Task<(int nRet, string sMsg)> CommReqAsync(this AxKHOpenAPI api, string sRQName, string sTrCode, string sScreenNo, Func<int> reqFunc, Action<_DKHOpenAPIEvents_OnReceiveTrDataEvent> eventCallback)
    {
        int nRet = 0;
        // 데이터 요청을 위한 비동기 노드 생성 (요청명, TR코드, 화면번호로 식별)
        int.TryParse(sScreenNo, out var nScreenNo);
        using var asyncNode = new AsyncNode([sRQName, sTrCode, nScreenNo]);
        asyncNode.EventCallback = (nEvent, args) =>
        {
            // 메시지 수신 이벤트 처리
            if (nEvent == (int)AxKHOpenAPI.EventId.OnReceiveMsg)
            {
                if (args is _DKHOpenAPIEvents_OnReceiveMsgEvent e)
                {
                    int.TryParse(e.sScrNo, out var scr_no);
                    int async_ident_id = AsyncNode.GetIdentId([e.sRQName, e.sTrCode, scr_no]);
                    // 현재 요청과 일치하는 응답인지 확인
                    if (asyncNode.IdentId == async_ident_id)
                    {
                        asyncNode.EventReceived = true;
                        asyncNode.Msg = e.sMsg;
                        return true;
                    }
                }
            }
            // TR 데이터 수신 이벤트 처리
            else if (nEvent == (int)AxKHOpenAPI.EventId.OnReceiveTrData && args is _DKHOpenAPIEvents_OnReceiveTrDataEvent e)
            {
                int.TryParse(e.sScrNo, out var scr_no);
                int async_ident_id = AsyncNode.GetIdentId([e.sRQName, e.sTrCode, scr_no]);
                // 현재 요청과 일치하는 응답인지 확인
                if (asyncNode.IdentId == async_ident_id)
                {
                    asyncNode.EventReceived = true;
                    eventCallback.Invoke(e); // 사용자 정의 액션 실행
                    asyncNode.Set(); // 비동기 작업 완료 신호
                    return true;
                }
            }
            return false;
        };

        // 비동기 노드 설정 및 데이터 요청
        api.InternalAsyncNodes.Add(asyncNode);
        nRet = reqFunc();
        if (nRet == DEF_SUCCESS_CODE && !await asyncNode.Wait(api.AsyncTimeOut))
            nRet = InternalErrorCodes.ERR_ASYNC_TIMEOUT;
        api.InternalAsyncNodes.Remove(asyncNode); // 비동기 노드 정리

        // 에러 메시지 처리
        string sMsg = asyncNode.Msg;
        if (nRet != DEF_SUCCESS_CODE && string.IsNullOrEmpty(sMsg))
            sMsg = api.GetErrorMessage(nRet);
        return (nRet, sMsg);
    }

    /// <summary>
    /// <see cref="AxKHOpenAPI.CommRqData"/> 비동기 요청을 수행합니다.<br/>
    /// processTrDataEvent 콜백함수에서 <see cref="AxKHOpenAPI.OnReceiveTrData"/> 이벤트를 서술해 줍니다.<br/>
    /// <code language="csharp" >
    /// // 샘플코드: OPT10001: 주식기본정보요청
    /// string 종목명 = string.Empty;
    /// axKHOpenApi.SetInputValue("종목코드", "005930"); // 삼성전자
    /// var (nRet, sMsg) = await axKHOpenApi.CommRqDataAsync("주식기본정보요청", "OPT10001", 0, "0001", (e) =>
    /// {
    ///     종목명 = axKHOpenApi.GetCommData(e.sTrCode, e.sRQName, 0, "종목명");
    /// });
    /// if (nRet == 0) // 요청성공
    ///     Console.WriteLine("종목명: " + 종목명);
    /// else
    ///     Console.WriteLine("요청실패: " + sMsg);
    /// </code>
    /// </summary>
    /// <param name="api"></param>
    /// <param name="sRQName">사용자 구분명 (임의로 지정, 한글지원)</param>
    /// <param name="sTrCode">조회하려는 TR이름</param>
    /// <param name="nPrevNext">연속조회여부</param>
    /// <param name="sScreenNo">화면번호 (4자리 숫자 임의로 지정)</param>
    /// <param name="eventCallback">이벤트 콜백함수</param>
    /// <returns>
    /// (int nRet, string sMsg) 튜플로 결과를 반환합니다.<br/>
    /// nRet값 0이면 성공이며, 그외 실패입니다.<br/>
    /// 실패시 sMsg에 에러메시지가 전달됩니다.
    /// </returns>
    public static async Task<(int nRet, string sMsg)> CommRqDataAsync(this AxKHOpenAPI api, string sRQName, string sTrCode, int nPrevNext, string sScreenNo, Action<_DKHOpenAPIEvents_OnReceiveTrDataEvent> eventCallback)
    {
        return await api.CommReqAsync(sRQName, sTrCode, sScreenNo
            , () => api.CommRqData(sRQName, sTrCode, nPrevNext, sScreenNo)
            , eventCallback
            );
    }

    /// <summary>
    /// <see cref="AxKHOpenAPI.CommKwRqData"/> 비동기 요청을 수행합니다.<br/>
    /// processTrDataEvent 콜백함수에서 <see cref="AxKHOpenAPI.OnReceiveTrData"/> 이벤트를 수신처리 합니다.<br/>
    /// <code language="csharp" >
    /// // 샘플코드: 관심종목정보요청
    /// // 삼성전자, 키움증권 현재가 요청
    /// List&lt;string> rcv_datas = [];
    /// var (nRet, sMsg) = await axKHOpenApi.CommKwRqDataAsync("005930;039490", 0, 2, 0, "관심종목정보요청", "0001", (e) =>
    /// {
    ///     int nRepeatCnt = axKHOpenApi.GetRepeatCnt(e.sTrCode, e.sRQName);
    ///     for (int i = 0; i &lt; nRepeatCnt; i++)
    ///         rcv_datas.Add(axKHOpenApi.GetCommData(e.sTrCode, e.sRQName, i, "현재가"));
    /// });
    /// if (nRet == 0) // 요청성공
    ///     rcv_datas.ForEach((s) => Console.WriteLine("현재가: " + s));
    /// else
    ///     Console.WriteLine("요청실패: " + sMsg);
    /// </code>
    /// </summary>
    /// <param name="api"></param>
    /// <param name="sArrCode">조회하려는 종목코드 리스트</param>
    /// <param name="bNext">연속조회 여부 0:기본값, 1:연속조회(지원안함)</param>
    /// <param name="nCodeCount">종목코드 갯수</param>
    /// <param name="nTypeFlag">0:주식 종목, 3:선물옵션 종목</param>
    /// <param name="sRQName">사용자 구분명</param>
    /// <param name="sScreenNo">화면번호</param>
    /// <param name="eventCallback">이벤트 콜백함수</param>
    /// <returns>
    /// (int nRet, string sMsg) 튜플로 결과를 반환합니다.<br/>
    /// nRet값 0이면 성공이며, 그외 실패입니다.<br/>
    /// 실패시 sMsg에 에러메시지가 전달됩니다.
    /// </returns>
    public static async Task<(int nRet, string sMsg)> CommKwRqDataAsync(this AxKHOpenAPI api, string sArrCode, int bNext, int nCodeCount, int nTypeFlag, string sRQName, string sScreenNo, Action<_DKHOpenAPIEvents_OnReceiveTrDataEvent> eventCallback)
    {
        string sTrCode = nTypeFlag switch
        {
            0 => "OPTKWFID",
            3 => "OPTFOFID",
            _ => throw new ArgumentException("0 또는 3만 허용됩니다.", nameof(nTypeFlag)),
        };

        return await api.CommReqAsync(sRQName, sTrCode, sScreenNo
            , () => api.CommKwRqData(sArrCode, bNext, nCodeCount, nTypeFlag, sRQName, sScreenNo)
            , eventCallback
            );
    }

    /// <summary>
    /// 비동기 조건검색 요청을 수행합니다.<br/>
    /// </summary>
    /// <remarks>함수 내부에서  <see cref="AxKHOpenAPI.OnReceiveTrCondition"/> 이벤트 처리가 자동으로 진행되며 strCodeListr값을 반환합니다.</remarks>
    /// <param name="api"></param>
    /// <param name="strScrNo">화면번호</param>
    /// <param name="strConditionName">조건식 이름</param>
    /// <param name="nIndex">조건식 고유번호</param>
    /// <param name="nSearch">실시간옵션. 0:조건검색만, 1:조건검색+실시간 조건검색</param>
    /// <returns>
    /// (int nRet, string strCodeList) 튜플로 결과를 반환합니다.<br/>
    /// nRet값 1이면 성공이며, 그외 실패입니다.<br/>
    /// 성공시 strCodeList에 검색종목리스트가 전달됩니다.<br/>
    /// 실패시 strCodeList에 에러메시지가 전달됩니다.<br/>
    /// </returns>
    public static async Task<(int nRet, string strCodeList)> SendConditionAsync(this AxKHOpenAPI api, string strScrNo, string strConditionName, int nIndex, int nSearch)
    {
        int nRet = DEF_SUCCESS_CODE;
        // 데이터 요청을 위한 비동기 노드 생성 (요청명, TR코드, 화면번호로 식별)
        int.TryParse(strScrNo, out var nScreenNo);
        using var asyncNode = new AsyncNode([nScreenNo, strConditionName]);
        asyncNode.EventCallback = (nEvent, args) =>
        {
            if (nEvent == (int)AxKHOpenAPI.EventId.OnReceiveTrCondition && args is _DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
            {
                int.TryParse(e.sScrNo, out var scr_no);
                int async_ident_id = AsyncNode.GetIdentId([scr_no, e.strConditionName]);
                // 현재 요청과 일치하는 응답인지 확인
                if (asyncNode.IdentId == async_ident_id)
                {
                    asyncNode.EventReceived = true;
                    asyncNode.Msg = e.strCodeList;
                    asyncNode.Set();
                    return true;
                }
            }
            return false;
        };

        // 비동기 노드 설정 및 데이터 요청
        api.InternalAsyncNodes.Add(asyncNode);
        nRet = api.SendCondition(strScrNo, strConditionName, nIndex, nSearch);
        if (nRet == DEF_CONDITION_SUCCESS_CODE && !await asyncNode.Wait(api.AsyncTimeOut))
            nRet = InternalErrorCodes.ERR_ASYNC_TIMEOUT;
        api.InternalAsyncNodes.Remove(asyncNode); // 비동기 노드 정리

        // 에러 메시지 처리
        string sMsg = asyncNode.Msg;
        if (nRet != DEF_CONDITION_SUCCESS_CODE && string.IsNullOrEmpty(sMsg))
        {
            if (nRet == DEF_SUCCESS_CODE)
                sMsg = "조건검색 요청 실패";
            else
                sMsg = api.GetErrorMessage(nRet);
        }
        return (nRet, sMsg);
    }

    /// <summary>
    /// 비동기 조건식 불러오기 함수.<br/>
    /// <inheritdoc cref="AxKHOpenAPI.GetConditionLoad"/>
    /// </summary>
    /// <remarks>함수 내부에서  <see cref="AxKHOpenAPI.OnReceiveConditionVer"/> 이벤트 처리가 자동으로 진행되며 성공시 조건검색식리스트를 반환합니다.</remarks>
    /// <returns>
    /// (int nRet, string sCondList) 튜플로 결과를 반환합니다.<br/>
    /// nRet값 1이면 성공이며, 그외 실패입니다.<br/>
    /// 성공시 sCondList에 GetConditionNameList() 결과값이 전달됩니다.<br/>
    /// 실패시 sCondList에 에러메시지가 전달됩니다.
    /// </returns>
    public static async Task<(int nRet, string sCondList)> GetConditionLoadAsync(this AxKHOpenAPI api)
    {
        // 중복 요청 방지 검사
        int nIdentId = AsyncNode.GetIdentId(["GetConditionLoadAsync"]);
        if (api.InternalAsyncNodes.Any(x => x.IdentId == nIdentId))
            return (InternalErrorCodes.ERR_ASYNC_WORKING, api.GetErrorMessage(InternalErrorCodes.ERR_ASYNC_WORKING));

        int nRet = DEF_SUCCESS_CODE;
        // 데이터 요청을 위한 비동기 노드 생성 (요청명, TR코드, 화면번호로 식별)
        using var asyncNode = new AsyncNode(["GetConditionLoadAsync"]);
        asyncNode.EventCallback = (nEvent, args) =>
        {
            if (nEvent == (int)AxKHOpenAPI.EventId.OnReceiveConditionVer && args is _DKHOpenAPIEvents_OnReceiveConditionVerEvent e)
            {
                int async_ident_id = AsyncNode.GetIdentId(["GetConditionLoadAsync"]);
                // 현재 요청과 일치하는 응답인지 확인
                if (asyncNode.IdentId == async_ident_id)
                {
                    asyncNode.EventReceived = true;
                    nRet = e.lRet;
                    if (nRet == DEF_CONDITION_SUCCESS_CODE)
                        asyncNode.Msg = api.GetConditionNameList();
                    else
                        asyncNode.Msg = e.sMsg;
                    asyncNode.Set();
                    return true;
                }
            }
            return false;
        };

        // 비동기 노드 설정 및 데이터 요청
        api.InternalAsyncNodes.Add(asyncNode);
        nRet = api.GetConditionLoad();
        if (nRet == DEF_CONDITION_SUCCESS_CODE && !await asyncNode.Wait(api.AsyncTimeOut))
            nRet = InternalErrorCodes.ERR_ASYNC_TIMEOUT;
        api.InternalAsyncNodes.Remove(asyncNode); // 비동기 노드 정리

        // 에러 메시지 처리
        string sMsg = asyncNode.Msg;
        if (nRet != DEF_CONDITION_SUCCESS_CODE && string.IsNullOrEmpty(sMsg))
        {
            if (nRet == DEF_SUCCESS_CODE)
                sMsg = "조건검색 목록 요청 실패";
            else
                sMsg = api.GetErrorMessage(nRet);
        }
        return (nRet, sMsg);
    }

    private static async Task<(int nRet, string sMsg)> OrderAsync(this AxKHOpenAPI api, string sRQName, string sScreenNo, Func<int> orderFunc)
    {
        int nRet = DEF_SUCCESS_CODE;
        string sOrderNumber = string.Empty; // 주문번호 저장용
        const string _async_SendOrder = "SendOrderAsync";
        // 주문 요청을 위한 비동기 노드 생성
        int.TryParse(sScreenNo, out var nScreenNo);
        using var asyncNode = new AsyncNode([sRQName, _async_SendOrder, nScreenNo]);
        asyncNode.EventCallback = (nEvent, args) =>
        {
            // 메시지 수신 이벤트 처리
            if (nEvent == (int)AxKHOpenAPI.EventId.OnReceiveMsg)
            {
                if (args is _DKHOpenAPIEvents_OnReceiveMsgEvent e)
                {
                    int.TryParse(e.sScrNo, out var scr_no);
                    int async_ident_id = AsyncNode.GetIdentId([e.sRQName, _async_SendOrder, scr_no]);
                    // 현재 주문과 일치하는 응답인지 확인
                    if (asyncNode.IdentId == async_ident_id)
                    {
                        asyncNode.EventReceived = true;
                        asyncNode.Msg = e.sMsg;
                        return true;
                    }
                }
            }
            // TR 데이터 수신 이벤트 처리 (주문 결과)
            else if (nEvent == (int)AxKHOpenAPI.EventId.OnReceiveTrData && args is _DKHOpenAPIEvents_OnReceiveTrDataEvent e)
            {
                int.TryParse(e.sScrNo, out var scr_no);
                int async_ident_id = AsyncNode.GetIdentId([e.sRQName, _async_SendOrder, scr_no]);
                // 현재 주문과 일치하는 응답인지 확인
                if (asyncNode.IdentId == async_ident_id)
                {
                    asyncNode.EventReceived = true;
                    // 주문번호 추출 (주문 성공 여부 판단용)
                    sOrderNumber = api.GetCommData(e.sTrCode, e.sRQName, 0, "주문번호");
                    asyncNode.Set(); // 비동기 작업 완료 신호
                    return true;
                }
            }
            return false;
        };

        // 비동기 노드 설정 및 주문 전송
        api.InternalAsyncNodes.Add(asyncNode);
        nRet = orderFunc();
        if (nRet == DEF_SUCCESS_CODE && !await asyncNode.Wait(api.AsyncTimeOut))
            nRet = InternalErrorCodes.ERR_ASYNC_TIMEOUT;
        api.InternalAsyncNodes.Remove(asyncNode); // 비동기 노드 정리

        // 주문번호가 없으면 주문 실패로 처리
        if (nRet == DEF_SUCCESS_CODE && string.IsNullOrEmpty(sOrderNumber))
            nRet = InternalErrorCodes.ERR_ASYNC_NOORDER;

        // 에러 메시지 처리
        string sMsg = asyncNode.Msg;
        if (nRet != DEF_SUCCESS_CODE && string.IsNullOrEmpty(sMsg))
            sMsg = api.GetErrorMessage(nRet);
        return (nRet, sMsg);
    }

    /// <summary>
    /// 비동기로 <inheritdoc cref="AxKHOpenAPI.SendOrder"/><br/>
    /// <code language="csharp">
    /// // 샘플: 주식주문
    /// var (nRet, sMsg) = await SendOrderAsync(...);
    /// // 결과처리
    /// if (nRet == 0)
    /// {
    ///     // 주문성공 (서버까지 주문이 확실히 접수됨)
    /// }
    /// else
    /// {
    ///     // 주문실패, sMsg 에 오류메시지가 있음
    /// }
    /// </code>
    /// </summary>
    /// <returns>
    /// 결과는 (int nRet, string sMsg) 로 반환합니다.<br/>
    /// <inheritdoc cref="AxKHOpenAPI.SendOrder"/><br/>
    /// nRet 값이 0이면 서버까지 주문이 확실히 성공, 0이 아니면 주문실패입니다.<br/>
    /// 주문실패 사유로 sMsg 에 오류메시지가 있습니다.
    /// </returns>
    public static async Task<(int nRet, string sMsg)> SendOrderAsync(this AxKHOpenAPI api, string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, int nPrice, string sHogaGb, string sOrgOrderNo)
    {
        return await api.OrderAsync(sRQName, sScreenNo
            , () => api.SendOrder(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, nPrice, sHogaGb, sOrgOrderNo)
            );
    }

    /// <summary>
    /// 비동기로 <inheritdoc cref="AxKHOpenAPI.SendOrderFO"/><br/>
    /// <code language="csharp">
    /// // 샘플: 선물옵션주문
    /// var (nRet, sMsg) = await SendOrderFOAsync(...);
    /// // 결과처리
    /// if (nRet == 0)
    /// {
    ///     // 주문성공 (서버까지 주문이 확실히 접수됨)
    /// }
    /// else
    /// {
    ///     // 주문실패, sMsg 에 오류메시지가 있음
    /// }
    /// </code>
    /// </summary>
    /// <returns>
    /// 결과는 (int nRet, string sMsg) 로 반환합니다.<br/>
    /// <inheritdoc cref="AxKHOpenAPI.SendOrderFO"/><br/>
    /// nRet 값이 0이면 서버까지 주문이 확실히 성공, 0이 아니면 주문실패입니다.<br/>
    /// 주문실패 사유로 sMsg 에 오류메시지가 있습니다.
    /// </returns>
    public static async Task<(int nRet, string sMsg)> SendOrderFOAsync(this AxKHOpenAPI api, string sRQName, string sScreenNo, string sAccNo, string sCode, int lOrdKind, string sSlbyTp, string sOrdTp, int lQty, string sPrice, string sOrgOrdNo)
    {
        return await api.OrderAsync(sRQName, sScreenNo
            , () => api.SendOrderFO(sRQName, sScreenNo, sAccNo, sCode, lOrdKind, sSlbyTp, sOrdTp, lQty, sPrice, sOrgOrdNo)
            );
    }

    /// <summary>
    /// 비동기로 <inheritdoc cref="AxKHOpenAPI.SendOrderCredit"/><br/>
    /// <code language="csharp">
    /// // 샘플: 신용주문
    /// var (nRet, sMsg) = await SendOrderCreditAsync(...);
    /// // 결과처리
    /// if (nRet == 0)
    /// {
    ///     // 주문성공 (서버까지 주문이 확실히 접수됨)
    /// }
    /// else
    /// {
    ///     // 주문실패, sMsg 에 오류메시지가 있음
    /// }
    /// </code>
    /// </summary>
    /// <returns>
    /// 결과는 (int nRet, string sMsg) 로 반환합니다.<br/>
    /// <inheritdoc cref="AxKHOpenAPI.SendOrderCredit"/><br/>
    /// nRet 값이 0이면 서버까지 주문이 확실히 성공, 0이 아니면 주문실패입니다.<br/>
    /// 주문실패 사유로 sMsg 에 오류메시지가 있습니다.
    /// </returns>
    public static async Task<(int nRet, string sMsg)> SendOrderCreditAsync(this AxKHOpenAPI api, string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, int nPrice, string sHogaGb, string sCreditGb, string sLoanDate, string sOrgOrderNo)
    {
        return await api.OrderAsync(sRQName, sScreenNo
            , () => api.SendOrderCredit(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, nPrice, sHogaGb, sCreditGb, sLoanDate, sOrgOrderNo)
            );
    }


    /// <summary>
    /// 비동기 요청을 간단하게 사용하기 위한 함수입니다.<br/>
    /// 입력파라미터로 TR코드, 입력데이터, 싱글필드 리스트, 멀티필드 리스트를 전달하면 비동기로 요청하고 결과를 반환합니다.<br/>
    /// 싱글데이터, 멀티데이터는 Trim된 결과를 반환합니다.<br/>
    /// 실시간 데이터 허용시 reqRealData 파라미터를 true로 설정.<br/>
    /// 결과는 <see cref="ResponseData"/> 로 반환합니다.<br/>
    /// </summary>
    /// <param name="api"></param>
    /// <param name="tr_cd">TR코드</param>
    /// <param name="indatas">입력데이터 리스트</param>
    /// <param name="singleFields">싱글 필드리스트</param>
    /// <param name="multiFields">멀티 필드 리스트</param>
    /// <param name="cont_key">연속조회 경우 설정. default: 빈문자</param>
    /// <param name="reqRealData">실시간데이터 허용시 true로 설정. default: false</param>
    /// <returns><inheritdoc cref="ResponseData"/></returns>
    /// <remarks>
    /// <code language="csharp">
    /// // 샘플 1: 주식기본정보요청
    /// var indatas = new Dictionary&lt;string, string&gt; 
    /// {
    ///     { "종목코드", "005930" },
    /// };
    /// var response = await RequestTrAsync("OPT10001", indatas, ["종목명", "액면가", "신용비율", "외인소진율"], []);
    /// 
    /// // 샘플 2: 주식일봉차트조회요청
    /// var indatas = new Dictionary&lt;string, string&gt; 
    /// {
    ///     { "종목코드", "005930" },
    ///     { "기준일자", "20240704" },
    ///     { "수정주가구분", "1" }
    /// };
    /// var response = await RequestTrAsync("OPT10081", indatas, ["종목코드"], ["일자", "현재가", "거래량"]);
    /// 
    /// // 샘플 3: 관심종목정보요청
    /// var indatas = new Dictionary&lt;string, string&gt; 
    /// {
    ///     { "종목코드", "005930;039490" }, // 삼성전자, 키움증권 (종목코드는 세미콜론으로 구분)
    /// };
    /// var response = await RequestTrAsync("OPTKWFID", indatas, [], ["종목명", "현재가", "기준가", "시가", "고가", "저가"]);
    /// 
    /// // 샘플 4: 관심종목정보요청(선물옵션)
    /// var indatas = new Dictionary&lt;string, string&gt; 
    /// {
    ///     { "종목코드", "101V9000;101VC000" }, // (종목코드는 세미콜론으로 구분)
    ///     { "타입구분", "3" }, // 0:주식 종목, 3:선물옵션 종목 (기본값은 0)
    /// };
    /// var response = await RequestTrAsync("OPTKWFID", indatas, [], ["종목명", "현재가", "기준가", "시가", "고가", "저가"]);
    /// 
    /// // 결과처리
    /// if (response.nErrCode == 0)
    /// {
    ///     // 요청성공, response.OutputSingleDatas, response.OutputMultiDatas 에 결과가 있음
    /// }
    /// else
    /// {
    ///     // 요청실패, response.rsp_msg 에 오류메시지가 있음
    /// }
    /// </code>
    /// </remarks>
    public static async Task<ResponseData> RequestTrAsync(this AxKHOpenAPI api, string tr_cd, IEnumerable<KeyValuePair<string, string>> indatas, IEnumerable<string> singleFields, IEnumerable<string> multiFields, string cont_key = "", bool reqRealData = false)
    {
        var scr_num = ScrNumManager.GetRequestScrNum();
        ResponseData response = new()
        {
            tr_cd = tr_cd,
            InValues = [.. indatas],
            InSingleFields = [.. singleFields],
            InMultiFields = [.. multiFields],
        };
        string tr_upper = tr_cd.ToUpper();
        if (tr_upper.Equals("OPTKWFID") || tr_upper.Equals("OPTFOFID")) // 관심종목정보요청
        {
            string 종목코드 = response.InValues.FirstOrDefault(x => x.Key.Equals("종목코드") || x.Key.Equals("sArrCode")).Value ?? string.Empty;
            var count = 종목코드.Split([';'], StringSplitOptions.RemoveEmptyEntries).Length;
            int nTypeFlag = tr_upper.Equals("OPTKWFID") ? 0 : 3;
            (response.nErrCode, response.rsp_msg) = await api.CommKwRqDataAsync(종목코드, 0, count, nTypeFlag, tr_cd, scr_num, processTrDataEvent);
            return response;
        }

        foreach (var inValue in response.InValues) api.SetInputValue(inValue.Key, inValue.Value);

        (response.nErrCode, response.rsp_msg) = await api.CommRqDataAsync(tr_cd, tr_cd, cont_key.Equals("2") ? 2 : 0, scr_num, processTrDataEvent);

        return response;

        // 이벤트 콜백함수
        void processTrDataEvent(_DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            response.OutputSingleDatas = [.. response.InSingleFields.Select(x => api.GetCommData(e.sTrCode, e.sRQName, 0, x).Trim())];
            var nRepeateCnt = api.GetRepeatCnt(e.sTrCode, e.sRQName);
            for (int i = 0; i < nRepeateCnt; i++)
            {
                var datas = response.InMultiFields.Select(x => api.GetCommData(e.sTrCode, e.sRQName, i, x).Trim()).ToArray();
                response.OutputMultiDatas.Add(datas);
            }

            response.cont_key = e.sPrevNext.Equals("2") ? "2" : string.Empty;

            if (!reqRealData)
                api.DisconnectRealData(e.sScrNo);
        }
    }

    /// <inheritdoc cref="RequestTrAsync(AxKHOpenAPI, string, IEnumerable{KeyValuePair{string, string}}, IEnumerable{string}, IEnumerable{string}, string, bool)"/>
    public static Task<ResponseData> RequestTrAsync(this AxKHOpenAPI api, string tr_cd, IEnumerable<KeyValue<string, string>> indatas, IEnumerable<string> singleFields, IEnumerable<string> multiFields, string cont_key = "", bool reqRealData = false)
        => api.RequestTrAsync(tr_cd, indatas.Select(x => new KeyValuePair<string, string>(x.Key, x.Value)), singleFields, multiFields, cont_key, reqRealData);
}
