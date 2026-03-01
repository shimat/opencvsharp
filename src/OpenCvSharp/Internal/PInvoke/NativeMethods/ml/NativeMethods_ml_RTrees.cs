using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_RTrees_getCalculateVarImportance(IntPtr obj, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_RTrees_setCalculateVarImportance(IntPtr obj, int val);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_RTrees_getActiveVarCount(IntPtr obj, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_RTrees_setActiveVarCount(IntPtr obj, int val);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_RTrees_getTermCriteria(IntPtr obj, out TermCriteria returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_RTrees_setTermCriteria(IntPtr obj, TermCriteria val);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_RTrees_getVarImportance(IntPtr obj, out IntPtr returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_RTrees_create(out IntPtr returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_Ptr_RTrees_delete(IntPtr obj);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_Ptr_RTrees_get(IntPtr obj, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_RTrees_load(
        [MarshalAs(UnmanagedType.LPStr)] string filePath, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_RTrees_loadFromString(
        [MarshalAs(UnmanagedType.LPStr)] string strModel, out IntPtr returnValue);
}
