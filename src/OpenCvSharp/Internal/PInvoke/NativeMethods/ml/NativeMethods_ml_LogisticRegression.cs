using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_LogisticRegression_getLearningRate(IntPtr obj, out double returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_LogisticRegression_setLearningRate(IntPtr obj, double val);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_LogisticRegression_getIterations(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_LogisticRegression_setIterations(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_LogisticRegression_getRegularization(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_LogisticRegression_setRegularization(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_LogisticRegression_getTrainMethod(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_LogisticRegression_setTrainMethod(IntPtr obj, int val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_LogisticRegression_getMiniBatchSize(IntPtr obj, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_LogisticRegression_setMiniBatchSize(IntPtr obj, int val);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_LogisticRegression_getTermCriteria(IntPtr obj, out TermCriteria returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_LogisticRegression_setTermCriteria(IntPtr obj, TermCriteria val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_LogisticRegression_predict(
        IntPtr obj, IntPtr samples, IntPtr results, int flags, out float returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_LogisticRegression_get_learnt_thetas(IntPtr obj, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_LogisticRegression_create(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_Ptr_LogisticRegression_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_Ptr_LogisticRegression_get(IntPtr obj, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_LogisticRegression_load(
        [MarshalAs(UnmanagedType.LPStr)] string filePath, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ml_LogisticRegression_loadFromString(
        [MarshalAs(UnmanagedType.LPStr)] string strModel, out IntPtr returnValue);
}
