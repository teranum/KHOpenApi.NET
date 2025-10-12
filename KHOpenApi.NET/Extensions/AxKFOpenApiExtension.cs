using KHOpenApi.NET.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KHOpenApi.NET;

/// <summary>
/// AxKFOpenAPI 클래스의 확장 메서드를 제공하는 정적 클래스
/// </summary>
public static class AxKFOpenApiExtension
{
    private const int DEF_SUCCESS_CODE = 0;

    /// <summary>
    /// Error Code에 해당하는 메시지 가져오기
    /// </summary>
    /// <param name="api"></param>
    /// <param name="code">에러 코드</param>
    /// <returns>에러 코드에 해당하는 메시지</returns>
    public static string GetErrorMessage(this AxKFOpenAPI api, int code)
    {
        return code switch
        {
            1 or 0 => "정상처리",
            -1 => "미접속상태",
            -100 => "로그인시 접속 실패 (아이피오류 또는 접속정보 오류)",
            -101 => "서버 접속 실패",
            -102 => "버전처리 실패",
            -103 => "TrCode가 존재하지 않습니다.",
            -104 => "해외OpenAPI 미신청",
            -200 => "시세과부하",
            -201 => "주문과부하",
            -202 => "조회입력값 오류",
            -203 => "데이터 없음",
            -300 => "주문입력값 오류",
            -301 => "계좌비밀번호 없음",
            -302 => "타인계좌 사용오류",
            -303 => "경고-주문수량 200개 초과",
            -304 => "제한-주문수량 400개 초과",

            InternalErrorCodes.ERR_ASYNC_WORKING => "비동기요청: 이미 작동중 입니다",
            InternalErrorCodes.ERR_ASYNC_TIMEOUT => "비동기요청: 타임아웃",
            InternalErrorCodes.ERR_ASYNC_NOORDER => "비동기요청: 주문번호가 없습니다.",

            _ => $"unknown",
        };
    }

    /// <summary>
    /// 비동기 요청을 수행합니다.<br/>
    /// 서버 연결을 비동기적으로 처리하여 UI 블로킹을 방지합니다.
    /// </summary>
    /// <inheritdoc cref="AxKFOpenAPI.CommConnect"/>
    public static async Task<(int nRet, string sMsg)> CommConnectAsync(this AxKFOpenAPI api, int nAutoUpgrade)
    {
        // 이미 비동기 요청이 진행 중인지 확인
        if (api.InternalAsyncNode != null)
            return (InternalErrorCodes.ERR_ASYNC_WORKING, api.GetErrorMessage(InternalErrorCodes.ERR_ASYNC_WORKING));

        int nRet = DEF_SUCCESS_CODE;
        // 연결 이벤트를 위한 비동기 노드 생성
        using var asyncNode = new AsyncNode(["CommConnectAsync"]);
        asyncNode.EventCallback = (nEvent, args) =>
        {
            // 연결 이벤트 처리
            if (nEvent == (int)AxKFOpenAPI.EventId.OnEventConnect)
            {
                nRet = ((_DKFOpenAPIEvents_OnEventConnectEvent)args).nErrCode;
                asyncNode.Set(); // 비동기 작업 완료 신호
                return true;
            }
            return false;
        };

        // 비동기 노드 설정 및 연결 요청
        api.InternalAsyncNode = asyncNode;
        nRet = api.CommConnect(nAutoUpgrade);
        if (nRet == DEF_SUCCESS_CODE)
        {
            await asyncNode.Wait(); // 연결 완료까지 대기
        }
        api.InternalAsyncNode = null; // 비동기 노드 정리

        return (nRet, api.GetErrorMessage(nRet));
    }

    /// <summary>
    /// 비동기 요청을 수행합니다.<br/>
    /// (int nRet, string sMsg) 튜플로 결과를 반환합니다.<br/>
    /// nRet값 0이면 성공이며, 그외 실패입니다.<br/>
    /// 실패시 sMsg에 에러메시지가 전달됩니다.
    /// </summary>
    /// <inheritdoc cref="AxKFOpenAPI.CommRqData"/>
    public static async Task<(int nRet, string sMsg)> CommRqDataAsync(this AxKFOpenAPI api, string sRQName, string sTrCode, string sPrevNext, string sScreenNo, Action<_DKFOpenAPIEvents_OnReceiveTrDataEvent> eventCallback)
    {
        // 중복 요청 방지 검사
        if (api.InternalAsyncNode != null)
            return (InternalErrorCodes.ERR_ASYNC_WORKING, api.GetErrorMessage(InternalErrorCodes.ERR_ASYNC_WORKING));

        int nRet = DEF_SUCCESS_CODE;
        // 데이터 요청을 위한 비동기 노드 생성 (요청명, TR코드, 화면번호로 식별)
        int.TryParse(sScreenNo, out var nScreenNo);
        using var asyncNode = new AsyncNode([sRQName, sTrCode, nScreenNo]);
        asyncNode.EventCallback = (nEvent, args) =>
        {
            // 메시지 수신 이벤트 처리
            if (nEvent == (int)AxKFOpenAPI.EventId.OnReceiveMsg)
            {
                if (args is _DKFOpenAPIEvents_OnReceiveMsgEvent e)
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
            else if (nEvent == (int)AxKFOpenAPI.EventId.OnReceiveTrData && args is _DKFOpenAPIEvents_OnReceiveTrDataEvent e)
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
        api.InternalAsyncNode = asyncNode;
        nRet = api.CommRqData(sRQName, sTrCode, sPrevNext, sScreenNo);
        if (nRet == DEF_SUCCESS_CODE && !await asyncNode.Wait(api.AsyncTimeOut))
            nRet = InternalErrorCodes.ERR_ASYNC_TIMEOUT;
        api.InternalAsyncNode = null; // 비동기 노드 정리

        // 에러 메시지 처리
        string sMsg = asyncNode.Msg;
        if (nRet != DEF_SUCCESS_CODE && string.IsNullOrEmpty(sMsg))
            sMsg = api.GetErrorMessage(nRet);
        return (nRet, sMsg);
    }

    /// <summary>
    /// 비동기로 주문을 서버로 전송합니다.<br/>
    /// 결과는 (int nRet, string msg) 로 반환합니다.<br/>
    /// nRet 값이 0이면 서버까지 주문이 확실히 성공, 0이 아니면 주문실패입니다.<br/>
    /// 주문실패 사유로 msg 에 오류메시지가 있습니다.<br/><br/>
    /// <code language="csharp">
    /// // 샘플: 해외선옵주문
    /// var (nRet, msg) = await SendOrderAsync(...);
    /// // 결과처리
    /// if (nRet == 0)
    /// {
    ///     // 주문성공 (서버까지 주문이 확실히 접수됨)
    /// }
    /// else
    /// {
    ///     // 주문실패, msg 에 오류메시지가 있음
    /// }
    /// </code>
    /// </summary>
    /// <inheritdoc cref="AxKFOpenAPI.SendOrder"/>
    public static async Task<(int nRet, string msg)> SendOrderAsync(this AxKFOpenAPI api, string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, string sPrice, string sStopPrice, string sHogaGb, string sOrgOrderNo)
    {
        // 중복 주문 방지 검사
        if (api.InternalAsyncNode != null)
            return (InternalErrorCodes.ERR_ASYNC_WORKING, api.GetErrorMessage(InternalErrorCodes.ERR_ASYNC_WORKING));

        int nRet = DEF_SUCCESS_CODE;
        string sOrderNumber = string.Empty; // 주문번호 저장용
        const string _async_SendOrder = "SendOrderAsync";
        // 주문 요청을 위한 비동기 노드 생성
        int.TryParse(sScreenNo, out var nScreenNo);
        using var asyncNode = new AsyncNode([sRQName, _async_SendOrder, nScreenNo]);
        asyncNode.EventCallback = (nEvent, args) =>
        {
            // 메시지 수신 이벤트 처리
            if (nEvent == (int)AxKFOpenAPI.EventId.OnReceiveMsg)
            {
                if (args is _DKFOpenAPIEvents_OnReceiveMsgEvent e)
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
            else if (nEvent == (int)AxKFOpenAPI.EventId.OnReceiveTrData && args is _DKFOpenAPIEvents_OnReceiveTrDataEvent e)
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
        api.InternalAsyncNode = asyncNode;
        nRet = api.SendOrder(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, sPrice, sStopPrice, sHogaGb, sOrgOrderNo);
        if (nRet == DEF_SUCCESS_CODE && !await asyncNode.Wait(api.AsyncTimeOut))
            nRet = InternalErrorCodes.ERR_ASYNC_TIMEOUT;
        api.InternalAsyncNode = null; // 비동기 노드 정리

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
    /// // 샘플 1: 종목정보조회
    /// var indatas = new Dictionary&lt;string, string&gt; 
    /// {
    ///     { "종목코드", "NQU24" },
    /// };
    /// var response = await RequestTrAsync("opt10001", indatas, ["종목명", "현재가", "시가", "고가", "저가"], ["체결시간", "현재가", "체결량", "누적거래량"]);
    /// 
    /// // 샘플 2: 관심종목정보요청
    /// var indatas = new Dictionary&lt;string, string&gt; 
    /// {
    ///     { "종목코드", "NQU24;NQZ24" }, // 나스닥100선물 9월물, 12월물 (종목코드는 세미콜론으로 구분)
    /// };
    /// var response = await RequestTrAsync("opt10005", indatas, [], ["종목코드", "현재가", "전일대비", "누적거래량"]);
    /// 
    /// // 샘플 3: 해외선물옵션일차트조회
    /// var indatas = new Dictionary&lt;string, string&gt; 
    /// {
    ///     { "종목코드", "NQU24" },
    ///     { "조회일자", "20240704" },
    /// };
    /// var response = await RequestTrAsync("opc10003", indatas, [], ["일자", "현재가", "시가", "고가", "저가", "누적거래량"]);
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
    public static async Task<ResponseData> RequestTrAsync(this AxKFOpenAPI api, string tr_cd, IEnumerable<KeyValuePair<string, string>> indatas, IEnumerable<string> singleFields, IEnumerable<string> multiFields, string cont_key = "", bool reqRealData = false)
    {
        // 화면번호 할당 (요청 식별용)
        var scr_num = ScrNumManager.GetRequestScrNum();

        // 응답 데이터 객체 초기화
        ResponseData response = new()
        {
            tr_cd = tr_cd,
            InValues = [.. indatas],
            InSingleFields = [.. singleFields],
            InMultiFields = [.. multiFields],
        };

        // 입력 데이터 설정
        foreach (var inValue in response.InValues)
            api.SetInputValue(inValue.Key, inValue.Value);

        // 비동기 데이터 요청 실행
        (response.nErrCode, response.rsp_msg) = await api.CommRqDataAsync(tr_cd, tr_cd, cont_key, scr_num, processTrDataEvent);

        void processTrDataEvent(_DKFOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            // 싱글 데이터 추출 (Trim 처리)
            response.OutputSingleDatas = [.. response.InSingleFields.Select(x =>
                    api.GetCommData(e.sTrCode, e.sRQName, 0, x).Trim())];

            // 멀티 데이터 추출 (반복 횟수만큼)
            var nRepeateCnt = api.GetRepeatCnt(e.sTrCode, e.sRQName);
            for (int i = 0; i < nRepeateCnt; i++)
            {
                // 각 행의 데이터 추출 (Trim 처리)
                var datas = response.InMultiFields.Select(x =>
                    api.GetCommData(e.sTrCode, e.sRQName, i, x).Trim()).ToArray();
                response.OutputMultiDatas.Add(datas);
            }

            // 연속조회 키 저장
            response.cont_key = e.sPrevNext;

            // 실시간 데이터가 불필요한 경우 연결 해제
            if (!reqRealData)
                api.DisconnectRealData(e.sScrNo);
        }

        return response;
    }

    /// <summary>
    /// KeyValue 타입을 사용하는 RequestTrAsync 오버로드
    /// </summary>
    /// <inheritdoc cref="RequestTrAsync(AxKFOpenAPI, string, IEnumerable{KeyValuePair{string, string}}, IEnumerable{string}, IEnumerable{string}, string, bool)"/>
    public static Task<ResponseData> RequestTrAsync(this AxKFOpenAPI api, string tr_cd, IEnumerable<KeyValue<string, string>> indatas, IEnumerable<string> singleFields, IEnumerable<string> multiFields, string cont_key = "", bool reqRealData = false)
        => api.RequestTrAsync(tr_cd, indatas.Select(x => new KeyValuePair<string, string>(x.Key, x.Value)), singleFields, multiFields, cont_key, reqRealData);
}
