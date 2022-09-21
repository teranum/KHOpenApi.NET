using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace KFOpenApi.NET
{
    [ComImport]
    [Guid("85B07632-4F84-4CEF-991D-C79DE781363D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface _DKFOpenAPI
    {
        //[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        //[DispId(-552)]
        //void AboutBox();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(1)]
        int CommConnect(int nAutoUpgrade);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(2)]
        int CommRqData([MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sPrevNext, [MarshalAs(UnmanagedType.BStr)] string sScreenNo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(3)]
        void SetInputValue([MarshalAs(UnmanagedType.BStr)] string sID, [MarshalAs(UnmanagedType.BStr)] string sValue);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(4)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetCommData([MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sRQName, int nIndex, [MarshalAs(UnmanagedType.BStr)] string sItemName);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(5)]
        void CommTerminate();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(6)]
        int GetRepeatCnt([MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sRecordName);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(7)]
        void DisconnectRealData([MarshalAs(UnmanagedType.BStr)] string sScreenNo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(8)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetCommRealData([MarshalAs(UnmanagedType.BStr)] string sRealType, int nFid);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(9)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetChejanData(int nFid);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(10)]
        int SendOrder([MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sScreenNo, [MarshalAs(UnmanagedType.BStr)] string sAccNo, int nOrderType, [MarshalAs(UnmanagedType.BStr)] string sCode, int nQty, [MarshalAs(UnmanagedType.BStr)] string sPrice, [MarshalAs(UnmanagedType.BStr)] string sStopPrice, [MarshalAs(UnmanagedType.BStr)] string sHogaGb, [MarshalAs(UnmanagedType.BStr)] string sOrgOrderNo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(11)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetLoginInfo([MarshalAs(UnmanagedType.BStr)] string sTag);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(12)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutureItemlist();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(13)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalOptionItemlist();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(14)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutureCodelist([MarshalAs(UnmanagedType.BStr)] string sItem);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(15)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalOptionCodelist([MarshalAs(UnmanagedType.BStr)] string sItem);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(16)]
        int GetConnectState();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(17)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetAPIModulePath();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(18)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetCommonFunc([MarshalAs(UnmanagedType.BStr)] string sFuncName, [MarshalAs(UnmanagedType.BStr)] string sParam);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(19)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetConvertPrice([MarshalAs(UnmanagedType.BStr)] string sCode, [MarshalAs(UnmanagedType.BStr)] string sPrice, int nType);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(20)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutOpCodeInfoByType(int nGubun, [MarshalAs(UnmanagedType.BStr)] string sType);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(21)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutOpCodeInfoByCode([MarshalAs(UnmanagedType.BStr)] string sCode);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(22)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutureItemlistByType([MarshalAs(UnmanagedType.BStr)] string sType);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(23)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutureCodeByItemMonth([MarshalAs(UnmanagedType.BStr)] string sItem, [MarshalAs(UnmanagedType.BStr)] string sMonth);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(24)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalOptionCodeByMonth([MarshalAs(UnmanagedType.BStr)] string sItem, [MarshalAs(UnmanagedType.BStr)] string sCPGubun, [MarshalAs(UnmanagedType.BStr)] string sActivePrice, [MarshalAs(UnmanagedType.BStr)] string sMonth);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(25)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalOptionMonthByItem([MarshalAs(UnmanagedType.BStr)] string sItem);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(26)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalOptionActPriceByItem([MarshalAs(UnmanagedType.BStr)] string sItem);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(27)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetGlobalFutureItemTypelist();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(28)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetCommFullData([MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sRecordName, int nGubun);
    }

    [ComImport]
    [Guid("952B31F8-06FD-4D5A-A021-5FF57F5030AE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface _DKFOpenAPIEvents
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(1)]
        void OnReceiveTrData([MarshalAs(UnmanagedType.BStr)] string sScrNo, [MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sRecordName, [MarshalAs(UnmanagedType.BStr)] string sPrevNext);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(2)]
        void OnReceiveMsg([MarshalAs(UnmanagedType.BStr)] string sScrNo, [MarshalAs(UnmanagedType.BStr)] string sRQName, [MarshalAs(UnmanagedType.BStr)] string sTrCode, [MarshalAs(UnmanagedType.BStr)] string sMsg);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(3)]
        void OnReceiveRealData([MarshalAs(UnmanagedType.BStr)] string sJongmokCode, [MarshalAs(UnmanagedType.BStr)] string sRealType, [MarshalAs(UnmanagedType.BStr)] string sRealData);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(4)]
        void OnReceiveChejanData([MarshalAs(UnmanagedType.BStr)] string sGubun, int nItemCnt, [MarshalAs(UnmanagedType.BStr)] string sFIdList);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(5)]
        void OnEventConnect(int nErrCode);
    }

    public class _DKFOpenAPIEvents_OnReceiveTrDataEvent
    {
        public string sScrNo;

        public string sRQName;

        public string sTrCode;

        public string sRecordName;

        public string sPreNext;

        public _DKFOpenAPIEvents_OnReceiveTrDataEvent(string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPreNext)
        {
            this.sScrNo = sScrNo;
            this.sRQName = sRQName;
            this.sTrCode = sTrCode;
            this.sRecordName = sRecordName;
            this.sPreNext = sPreNext;
        }
    }
    public class _DKFOpenAPIEvents_OnReceiveMsgEvent
    {
        public string sScrNo;

        public string sRQName;

        public string sTrCode;

        public string sMsg;

        public _DKFOpenAPIEvents_OnReceiveMsgEvent(string sScrNo, string sRQName, string sTrCode, string sMsg)
        {
            this.sScrNo = sScrNo;
            this.sRQName = sRQName;
            this.sTrCode = sTrCode;
            this.sMsg = sMsg;
        }
    }
    public class _DKFOpenAPIEvents_OnReceiveRealDataEvent
    {
        public string sJongmokCode;

        public string sRealType;

        public string sRealData;

        public _DKFOpenAPIEvents_OnReceiveRealDataEvent(string sJongmokCode, string sRealType, string sRealData)
        {
            this.sJongmokCode = sJongmokCode;
            this.sRealType = sRealType;
            this.sRealData = sRealData;
        }
    }
    public class _DKFOpenAPIEvents_OnReceiveChejanDataEvent
    {
        public string sGubun;

        public int nItemCnt;

        public string sFIdList;

        public _DKFOpenAPIEvents_OnReceiveChejanDataEvent(string sGubun, int nItemCnt, string sFIdList)
        {
            this.sGubun = sGubun;
            this.nItemCnt = nItemCnt;
            this.sFIdList = sFIdList;
        }
    }
    public class _DKFOpenAPIEvents_OnEventConnectEvent
    {
        public int nErrCode;

        public _DKFOpenAPIEvents_OnEventConnectEvent(int nErrCode)
        {
            this.nErrCode = nErrCode;
        }
    }

    public delegate void _DKFOpenAPIEvents_OnReceiveTrDataEventHandler(object sender, _DKFOpenAPIEvents_OnReceiveTrDataEvent e);
    public delegate void _DKFOpenAPIEvents_OnReceiveRealDataEventHandler(object sender, _DKFOpenAPIEvents_OnReceiveRealDataEvent e);
    public delegate void _DKFOpenAPIEvents_OnReceiveMsgEventHandler(object sender, _DKFOpenAPIEvents_OnReceiveMsgEvent e);
    public delegate void _DKFOpenAPIEvents_OnReceiveChejanDataEventHandler(object sender, _DKFOpenAPIEvents_OnReceiveChejanDataEvent e);
    public delegate void _DKFOpenAPIEvents_OnEventConnectEventHandler(object sender, _DKFOpenAPIEvents_OnEventConnectEvent e);


    [ClassInterface(ClassInterfaceType.None)]
    public class AxKFOpenAPIEventMulticaster : _DKFOpenAPIEvents
    {
        private AxKFOpenAPI parent;

        public AxKFOpenAPIEventMulticaster(AxKFOpenAPI parent)
        {
            this.parent = parent;
        }

        public virtual void OnReceiveTrData(string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPreNext)
        {
            _DKFOpenAPIEvents_OnReceiveTrDataEvent e = new _DKFOpenAPIEvents_OnReceiveTrDataEvent(sScrNo, sRQName, sTrCode, sRecordName, sPreNext);
            parent.RaiseOnOnReceiveTrData(parent, e);
        }

        public virtual void OnReceiveMsg(string sScrNo, string sRQName, string sTrCode, string sMsg)
        {
            _DKFOpenAPIEvents_OnReceiveMsgEvent e = new _DKFOpenAPIEvents_OnReceiveMsgEvent(sScrNo, sRQName, sTrCode, sMsg);
            parent.RaiseOnOnReceiveMsg(parent, e);
        }

        public virtual void OnReceiveRealData(string sJongmokCode, string sRealType, string sRealData)
        {
            _DKFOpenAPIEvents_OnReceiveRealDataEvent e = new _DKFOpenAPIEvents_OnReceiveRealDataEvent(sJongmokCode, sRealType, sRealData);
            parent.RaiseOnOnReceiveRealData(parent, e);
        }

        public virtual void OnReceiveChejanData(string sGubun, int nItemCnt, string sFIdList)
        {
            _DKFOpenAPIEvents_OnReceiveChejanDataEvent e = new _DKFOpenAPIEvents_OnReceiveChejanDataEvent(sGubun, nItemCnt, sFIdList);
            parent.RaiseOnOnReceiveChejanData(parent, e);
        }

        public virtual void OnEventConnect(int nErrCode)
        {
            _DKFOpenAPIEvents_OnEventConnectEvent e = new _DKFOpenAPIEvents_OnEventConnectEvent(nErrCode);
            parent.RaiseOnOnEventConnect(parent, e);
        }
    }

    public class AxKFOpenAPI
    {
        [DllImport("Atl.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool AtlAxWinInit();
        [DllImport("Atl.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern int AtlAxGetControl(IntPtr h, [MarshalAs(UnmanagedType.IUnknown)] out object pp);
        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr CreateWindowEx(int dwExStyle, string lpClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

        private const int WS_VISIBLE = 0x10000000;
        private const int WS_CHILD = 0x40000000;

        private IntPtr hWndContainer = IntPtr.Zero;

        private _DKFOpenAPI ocx;
        private System.Runtime.InteropServices.ComTypes.IConnectionPoint _pConnectionPoint;
        private int _nCookie = 0;
        private bool bInitialized = false;

        public bool Created => bInitialized;

        public AxKFOpenAPI(IntPtr hWndParent)
        {
            string clsid = System.Environment.Is64BitProcess ? "{c42af31e-d199-4624-a57c-280d5b019cad}" : "{d1acab7d-a3af-49e4-9004-c9e98344e17a}";
            if (!bInitialized)
            {
                if (AtlAxWinInit())
                {
                    hWndContainer = CreateWindowEx(0, "AtlAxWin", clsid, WS_VISIBLE | WS_CHILD, -100, -100, 20, 20, hWndParent, (IntPtr)9002, IntPtr.Zero, IntPtr.Zero);
                    object pUnknown;
                    AtlAxGetControl(hWndContainer, out pUnknown);
                    if (pUnknown != null)
                    {
                        ocx = (_DKFOpenAPI)pUnknown;
                        if (ocx != null)
                        {
                            Guid guidEvents = typeof(_DKFOpenAPIEvents).GUID;
                            System.Runtime.InteropServices.ComTypes.IConnectionPointContainer pConnectionPointContainer;
                            pConnectionPointContainer = (System.Runtime.InteropServices.ComTypes.IConnectionPointContainer)pUnknown;
                            pConnectionPointContainer.FindConnectionPoint(ref guidEvents, out _pConnectionPoint);
                            if (_pConnectionPoint != null)
                            {
                                AxKFOpenAPIEventMulticaster pEventSink = new AxKFOpenAPIEventMulticaster(this);
                                _pConnectionPoint.Advise(pEventSink, out _nCookie);
                            }
                            bInitialized = true;
                        }
                    }
                }
            }
        }

        public event _DKFOpenAPIEvents_OnReceiveTrDataEventHandler OnReceiveTrData;

        public event _DKFOpenAPIEvents_OnReceiveRealDataEventHandler OnReceiveRealData;

        public event _DKFOpenAPIEvents_OnReceiveMsgEventHandler OnReceiveMsg;

        public event _DKFOpenAPIEvents_OnReceiveChejanDataEventHandler OnReceiveChejanData;

        public event _DKFOpenAPIEvents_OnEventConnectEventHandler OnEventConnect;

        internal void RaiseOnOnReceiveTrData(object sender, _DKFOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            if (this.OnReceiveTrData != null)
            {
                this.OnReceiveTrData(sender, e);
            }
        }

        internal void RaiseOnOnReceiveRealData(object sender, _DKFOpenAPIEvents_OnReceiveRealDataEvent e)
        {
            if (this.OnReceiveRealData != null)
            {
                this.OnReceiveRealData(sender, e);
            }
        }

        internal void RaiseOnOnReceiveMsg(object sender, _DKFOpenAPIEvents_OnReceiveMsgEvent e)
        {
            if (this.OnReceiveMsg != null)
            {
                this.OnReceiveMsg(sender, e);
            }
        }

        internal void RaiseOnOnReceiveChejanData(object sender, _DKFOpenAPIEvents_OnReceiveChejanDataEvent e)
        {
            if (this.OnReceiveChejanData != null)
            {
                this.OnReceiveChejanData(sender, e);
            }
        }

        internal void RaiseOnOnEventConnect(object sender, _DKFOpenAPIEvents_OnEventConnectEvent e)
        {
            if (this.OnEventConnect != null)
            {
                this.OnEventConnect(sender, e);
            }
        }

        //public virtual void AboutBox()
        //{
        //    if (ocx == null)
        //    {
        //        throw new InvalidActiveXStateException("AboutBox", ActiveXInvokeKind.MethodInvoke);
        //    }

        //    ocx.AboutBox();
        //}


        public virtual int CommConnect(int nAutoUpgrade)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommConnect", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CommConnect(nAutoUpgrade);
        }
        public virtual int CommRqData(string sRQName, string sTrCode, string sPrevNext, string sScreenNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommRqData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.CommRqData(sRQName, sTrCode, sPrevNext, sScreenNo);
        }

        public virtual void SetInputValue(string sID, string sValue)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SetInputValue", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.SetInputValue(sID, sValue);
        }

        public virtual string GetCommData(string strTrCode, string strRecordName, int nIndex, string strItemName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommData(strTrCode, strRecordName, nIndex, strItemName);
        }

        public virtual void CommTerminate()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("CommTerminate", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.CommTerminate();
        }

        public virtual int GetRepeatCnt(string sTrCode, string sRecordName)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetRepeatCnt", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetRepeatCnt(sTrCode, sRecordName);
        }

        public virtual void DisconnectRealData(string sScreenNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("DisconnectRealData", ActiveXInvokeKind.MethodInvoke);
            }

            ocx.DisconnectRealData(sScreenNo);
        }

        public virtual string GetCommRealData(string sRealType, int nFid)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommRealData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommRealData(sRealType, nFid);
        }

        public virtual string GetChejanData(int nFid)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetChejanData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetChejanData(nFid);
        }

        public virtual int SendOrder(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, string sPrice, string sStopPrice, string sHogaGb, string sOrgOrderNo)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("SendOrder", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.SendOrder(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, sPrice, sStopPrice, sHogaGb, sOrgOrderNo);
        }

        public virtual string GetLoginInfo(string sTag)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetLoginInfo", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetLoginInfo(sTag);
        }

        public virtual string GetGlobalFutureItemlist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureItemlist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureItemlist();
        }

        public virtual string GetGlobalOptionItemlist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionItemlist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionItemlist();
        }

        public virtual string GetGlobalFutureCodelist(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureCodelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureCodelist(sItem);
        }

        public virtual string GetGlobalOptionCodelist(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionCodelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionCodelist(sItem);
        }

        public virtual int GetConnectState()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetConnectState", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetConnectState();
        }

        public virtual string GetAPIModulePath()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetAPIModulePath", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetAPIModulePath();
        }

        public virtual string GetCommonFunc(string sFuncName, string sParam)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommonFunc", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommonFunc(sFuncName, sParam);
        }

        public virtual string GetConvertPrice(string sCode, string sPrice, int nType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetConvertPrice", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetConvertPrice(sCode, sPrice, nType);
        }

        public virtual string GetGlobalFutOpCodeInfoByType(int nGubun, string sType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutOpCodeInfoByType", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutOpCodeInfoByType(nGubun, sType);
        }

        public virtual string GetGlobalFutOpCodeInfoByCode(string sCode)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutOpCodeInfoByCode", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutOpCodeInfoByCode(sCode);
        }

        public virtual string GetGlobalFutureItemlistByType(string sType)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureItemlistByType", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureItemlistByType(sType);
        }

        public virtual string GetGlobalFutureCodeByItemMonth(string sItem, string sMonth)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureCodeByItemMonth", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureCodeByItemMonth(sItem, sMonth);
        }

        public virtual string GetGlobalOptionCodeByMonth(string sItem, string sCPGubun, string sActivePrice, string sMonth)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionCodeByMonth", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionCodeByMonth(sItem, sCPGubun, sActivePrice, sMonth);
        }

        public virtual string GetGlobalOptionMonthByItem(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionMonthByItem", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionMonthByItem(sItem);
        }

        public virtual string GetGlobalOptionActPriceByItem(string sItem)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalOptionActPriceByItem", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalOptionActPriceByItem(sItem);
        }

        public virtual string GetGlobalFutureItemTypelist()
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetGlobalFutureItemTypelist", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetGlobalFutureItemTypelist();
        }

        public virtual string GetCommFullData(string sTrCode, string sRecordName, int nGubun)
        {
            if (ocx == null)
            {
                throw new InvalidActiveXStateException("GetCommFullData", ActiveXInvokeKind.MethodInvoke);
            }

            return ocx.GetCommFullData(sTrCode, sRecordName, nGubun);
        }

        public enum ActiveXInvokeKind
        {
            MethodInvoke,
            PropertyGet,
            PropertySet
        }
        public class InvalidActiveXStateException : Exception
        {
            private readonly string name;
            private readonly ActiveXInvokeKind kind;

            public InvalidActiveXStateException(string name, ActiveXInvokeKind kind)
            {
                this.name = name;
                this.kind = kind;
            }

            public override string ToString()
            {
                switch (kind)
                {
                    case ActiveXInvokeKind.MethodInvoke:
                        return string.Format("AXInvalidMethodInvoke {0}", name);
                    case ActiveXInvokeKind.PropertyGet:
                        return string.Format("AXInvalidPropertyGet {0}", name);
                    case ActiveXInvokeKind.PropertySet:
                        return string.Format("AXInvalidPropertySet {0}", name);
                    default:
                        return base.ToString();
                }
            }
        }
    }
}
