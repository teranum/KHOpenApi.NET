using KHOpenApi.NET.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KHOpenApi.NET;

/// <summary>
/// OpenApi
/// </summary>
public class KHOpenApi
{
    #region Properties

    /// <summary>연결여부</summary>
    public bool Connected { get; private set; }
    /// <summary>모의투자여부</summary>
    public bool IsSimulation { get; private set; }


    /// <summary>AciveX OpenApi</summary>
    public AxKHOpenAPI AxApi;

    #endregion

    #region 생성자

    /// <summary>생성자</summary>
    public KHOpenApi(IntPtr Handle)
    {
        AxApi = new AxKHOpenAPI(Handle);
        //AxApi.OnEventConnect += _openApi_OnEventConnect;
        //AxApi.OnReceiveTrData += _openApi_OnReceiveTrData;
        //AxApi.OnReceiveRealData += _openApi_OnReceiveRealData;
        //AxApi.OnReceiveMsg += _openApi_OnReceiveMsg;
        //AxApi.OnReceiveChejanData += _openApi_OnReceiveChejanData;
        //AxApi.OnReceiveConditionVer += _openApi_OnReceiveConditionVer;
        //AxApi.OnReceiveTrCondition += _openApi_OnReceiveTrCondition;
        //AxApi.OnReceiveRealCondition += _openApi_OnReceiveRealCondition;
    }

    #endregion

    #region 로그인
    /// <summary>
    /// 로그인
    /// </summary>
    /// <returns></returns>
    public async Task<int> ConnectAsync()
    {
        if (!AxApi.Created)
        {
            return -901;
        }

        int nRet = await AxApi.CommConnectAsync();
        if (nRet != 0)
        {
            return nRet;
        }

        // 시장 전체종목 가져오기

        // 주식종목
        string[] market_codes = ["0", "10", "3", "8", "50", "4", "5", "6", "9", "30"];
        string[] market_names = ["코스피", "코스닥", "ELW", "ETF", "KONEX", "뮤추얼펀드", "신주인수권", "리츠", "하이얼펀드", "K-OTC"];
        MarketSubType[] market_supTypes = [MarketSubType.코스피, MarketSubType.코스닥, MarketSubType.ELW, MarketSubType.ETF,
            MarketSubType.KONEX, MarketSubType.뮤추얼펀드, MarketSubType.신주인수권, MarketSubType.리츠, MarketSubType.하이얼펀드, MarketSubType.K_OTC];
        for (int i = 0; i < market_codes.Length; i++)
        {
            string[] codes = AxApi.GetCodeListByMarket(market_codes[i]).Split(';');
            var subType = market_supTypes[i];
            foreach (string code in codes)
            {
                if (string.IsNullOrEmpty(code))
                    continue;
                if (_itemDic.ContainsKey(code))
                    continue;
                double.TryParse(AxApi.GetMasterLastPrice(code), out var lastPrice);
                var itemInfo = new ItemInfo(MarketType.주식, subType, code, AxApi.GetMasterCodeName(code), lastPrice);
                _items.Add(itemInfo);
                _itemDic.Add(code, itemInfo);
            }
        }

        // 선물옵션
        // 지수선물
        var futureCodes = AxApi.GetFutureList().Split(';');
        foreach (string futureCode in futureCodes)
        {
            if (string.IsNullOrEmpty(futureCode))
                continue;
            double.TryParse(AxApi.GetMasterLastPrice(futureCode), out var lastPrice);
            var itemInfo = new ItemInfo(MarketType.선물옵션, MarketSubType.지수선물, futureCode, AxApi.GetMasterCodeName(futureCode), lastPrice);
            _items.Add(itemInfo);
            _itemDic.Add(futureCode, itemInfo);
        }

        // 지수옵션
        //new NotImplementedException();

        // 주식선물
        var stockFutureCodes = AxApi.GetSFutureList(string.Empty).Split('|');
        foreach (string stockFutureCode in stockFutureCodes)
        {
            if (string.IsNullOrEmpty(stockFutureCode))
                continue;
            var infos = stockFutureCode.Split('^');
            if (infos.Length < 3)
                continue;
            string code = infos[0];
            string name = infos[1];
            //double.TryParse(AxApi.GetMasterLastPrice(code), out var lastPrice);
            var itemInfo = new ItemInfo(MarketType.선물옵션, MarketSubType.주식선물, code, name, 0);
            _items.Add(itemInfo);
            _itemDic.Add(code, itemInfo);
        }

        // 상품선물
        //new NotImplementedException();

        // 업종
        string[] upjongGroups = ["0", "1", "2", "4", "7",]; // 0:장내, 1: 코스닥, 2:KOSPI200, 4:KOSPI100(KOSPI50), 7:KRX100
        MarketSubType[] upjong_supTypes = [MarketSubType.코스피, MarketSubType.코스닥, MarketSubType.KOSPI200, MarketSubType.KOSPI100_KOSPI50, MarketSubType.KRX100,];
        for (int i = 0; i < upjongGroups.Length; i++)
        {
            var subType = market_supTypes[i];
            string[] upjongs = AxApi.KOA_Functions("GetUpjongCode", upjongGroups[i]).Split('|'); // 0,001,종합(KOSPI)|0,002,대형주|...|0,605,코스피배당성정50
            foreach (string upjong in upjongs)
            {
                if (string.IsNullOrEmpty(upjong))
                    continue;
                string[] infos = upjong.Split(',');
                if (infos.Length < 3)
                    continue;
                string code = infos[1];
                string name = infos[2];
                var itemInfo = new ItemInfo(MarketType.업종, subType, code, name, 0);
                _items.Add(itemInfo);
                _itemDic.Add(code, itemInfo);
            }
        }


        Connected = true;


        return 0;
    }

    #endregion

    #region 종목정보

    private List<ItemInfo> _items = [];
    private Dictionary<string, ItemInfo> _itemDic = new Dictionary<string, ItemInfo>();

    /// <summary>
    /// 종목정보 가져오기
    /// </summary>
    /// <param name="codeOrName">종목코드, 또는 종목명</param>
    /// <returns></returns>
    public ItemInfo GetItemInfo(string codeOrName)
    {
        if (_itemDic.TryGetValue(codeOrName, out var itemInfo))
        {
            return itemInfo;
        }
        return null;
    }

    #endregion

    #region 요청


    #endregion

    #region 이벤트
    #endregion

    #region 메서드

    /// <summary>
    /// 에러메시지 가져오기
    /// </summary>
    /// <param name="nErrorCode"></param>
    /// <returns></returns>
    public string GetErrorMessge(int nErrorCode)
    {
        string strErrMsg = "";
        return strErrMsg;
    }
    #endregion
}
