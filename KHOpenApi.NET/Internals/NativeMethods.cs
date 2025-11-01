using System.Runtime.InteropServices;

namespace KHOpenApi.NET.Internals;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

static class NativeMethods
{
    // additonal code
    [DllImport("Atl.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool AtlAxWinInit();
    [DllImport("Atl.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int AtlAxGetControl(IntPtr h, [MarshalAs(UnmanagedType.IUnknown)] out object pp);
    [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr CreateWindowEx(int dwExStyle, string lpClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);
    [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool DestroyWindow(IntPtr hWnd);
    [DllImport("kernel32.dll")]
    public static extern IntPtr GetConsoleWindow();
}
