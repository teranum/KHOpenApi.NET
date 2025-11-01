using System.Runtime.InteropServices;

namespace KHOpenApi.NET.Internals;

// Define the IDispatch interface
[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("00020400-0000-0000-C000-000000000046")]
internal interface IDispatch
{
    void GetTypeInfoCount(
        [Out] out uint pctinfo
        );

    void GetTypeInfo(
        [In] uint iTInfo,
        [In] uint lcid,
        [Out] out IntPtr ppTInfo
        );

    void GetIDsOfNames(
        ref Guid iid,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] names,
        uint nameCount,
        uint lcid,
        [MarshalAs(UnmanagedType.LPArray)][Out] int[] dspIds);

    void Invoke(int dispIdMember, ref Guid riid, uint lcid, System.Runtime.InteropServices.ComTypes.INVOKEKIND wFlags,
        ref System.Runtime.InteropServices.ComTypes.DISPPARAMS pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
}
