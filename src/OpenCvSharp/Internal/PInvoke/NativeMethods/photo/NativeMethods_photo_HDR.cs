using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // CalibrateDebevec

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_createCalibrateDebevec(int samples, float lambda, int random, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_Ptr_CalibrateDebevec_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_Ptr_CalibrateDebevec_get(IntPtr obj, out IntPtr returnValue);
                
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_CalibrateDebevec_getLambda(IntPtr obj, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_CalibrateDebevec_setLambda(IntPtr obj, float value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_CalibrateDebevec_getSamples(IntPtr obj, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_CalibrateDebevec_setSamples(IntPtr obj, float value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_CalibrateDebevec_getRandom(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_CalibrateDebevec_setRandom(IntPtr obj, int value);

    // CalibrateRobertson

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_createCalibrateRobertson(int maxIter, float threshold, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_Ptr_CalibrateRobertson_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_Ptr_CalibrateRobertson_get(IntPtr obj, out IntPtr returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus  photo_CalibrateRobertson_getMaxIter(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus  photo_CalibrateRobertson_setMaxIter(IntPtr obj, int value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus  photo_CalibrateRobertson_getThreshold(IntPtr obj, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus  photo_CalibrateRobertson_setThreshold(IntPtr obj, float value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus  photo_CalibrateRobertson_getRadiance(IntPtr obj, IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_CalibrateCRF_process(
        IntPtr obj, IntPtr[] srcImgs, int srcImgsLength, IntPtr dst, [In, MarshalAs(UnmanagedType.LPArray)] float[] times);

    // TODO Exception Handling

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr photo_createMergeDebevec();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void photo_Ptr_MergeDebevec_delete(IntPtr obj);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr photo_Ptr_MergeDebevec_get(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr photo_createMergeMertens();
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void photo_Ptr_MergeMertens_delete(IntPtr obj);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr photo_Ptr_MergeMertens_get(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void photo_MergeExposures_process(
        IntPtr obj, IntPtr[] srcImgs, int srcImgsLength, IntPtr dst, [In, MarshalAs(UnmanagedType.LPArray)] float[] times, IntPtr response);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr photo_MergeMertens_process(IntPtr obj, IntPtr[] srcImgs, int srcImgsLength, IntPtr dst);
}
