namespace KHOpenApi.NET.Helpers
{
    /// <summary>TR 요청 종류 클래스</summary>
    public class REQKindClass
    {
        /// <inheritdoc cref="REQKIND_FUNC"/>
        public REQKIND_FUNC ReqKind_Func;
        /// <inheritdoc cref="REQKIND_MASTER"/>
        public REQKIND_MASTER ReqKind_Master;
        /// <inheritdoc cref="REQKIND_MAIN"/>
        public REQKIND_MAIN ReqKind_Main;
        /// <inheritdoc cref="REQKIND_SUB"/>
        public REQKIND_SUB ReqKind_Sub;
        /// <summary>TR 코드</summary>
        public string Code;
        /// <summary>계좌관련 TR 여부</summary>
        public bool NeedAccount;

        /// <summary>생성자</summary>
        public REQKindClass(string Code
            , REQKIND_FUNC ReqKind_Func
            , REQKIND_MASTER ReqKind_Master
            , REQKIND_MAIN ReqKind_Main
            , REQKIND_SUB ReqKind_Sub
            , bool NeedAccount = false
            )
        {
            this.Code = Code;
            this.ReqKind_Func = ReqKind_Func;
            this.ReqKind_Master = ReqKind_Master;
            this.ReqKind_Main = ReqKind_Main;
            this.ReqKind_Sub = ReqKind_Sub;
            this.NeedAccount = NeedAccount;
        }
    }
    /// <summary>
    /// TR 요청 종류 (주문, 조회, 실시간)
    /// </summary>
    public enum REQKIND_MASTER
    {
        /// <summary>주문</summary>
        주문,
        /// <summary>조회</summary>
        조회,
        /// <summary>실시간</summary>
        실시간,
    }
    /// <summary>메인그럽 종류 (국내, 해외, FX, 공통)</summary>
    public enum REQKIND_MAIN
    {
        /// <summary>국내</summary>
        국내,
        /// <summary>해외</summary>
        해외,
        /// <summary>FX</summary>
        FX,
        /// <summary>공통</summary>
        공통,
    }
    /// <summary>서브그룹 종류 (TR, FID, 시세, 주문, None)</summary>
    public enum REQKIND_SUB
    {
        /// <summary>TR</summary>
        TR,
        /// <summary>FID</summary>
        FID,
        /// <summary>시세</summary>
        시세,
        /// <summary>주문</summary>
        주문,
        /// <summary>None</summary>
        None,
    }
    /// <summary>TR 요청 함수 (CommJumunSvr, CommRqData, CommFIDRqData, CommSetBroad, None)</summary>
    public enum REQKIND_FUNC
    {
        /// <summary>CommJumunSvr</summary>
        CommJumunSvr,
        /// <summary>CommRqData</summary>
        CommRqData,
        /// <summary>CommFIDRqData</summary>
        CommFIDRqData,
        /// <summary>CommSetJumunChe</summary>
        CommSetJumunChe,
        /// <summary>CommSetBroad</summary>
        CommSetBroad,
        /// <summary>None</summary>
        None,
    }

}
