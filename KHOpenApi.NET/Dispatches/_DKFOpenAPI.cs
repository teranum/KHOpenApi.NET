using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace KHOpenApi.NET;

[ComImport]
[Guid("85B07632-4F84-4CEF-991D-C79DE781363D")]
[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
internal interface _DKFOpenAPI
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
