using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_AlignMTB_create(int maxBits, int excludeRange, int cut, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_Ptr_AlignMTB_delete(IntPtr obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_Ptr_AlignMTB_get(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_AlignMTB_process(OpenCvSafeHandle obj, IntPtr src, IntPtr dst,
        in InputArrayProxy times, in InputArrayProxy response);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_AlignMTB_processShort(OpenCvSafeHandle obj, IntPtr src, IntPtr dst);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_AlignMTB_calculateShift(OpenCvSafeHandle obj,
        in InputArrayProxy img0, in InputArrayProxy img1, out Point returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_AlignMTB_shiftMat(OpenCvSafeHandle obj,
        in InputArrayProxy src, in OutputArrayProxy dst, Point shift);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_AlignMTB_computeBitmaps(OpenCvSafeHandle obj,
        in InputArrayProxy img, in OutputArrayProxy tb, in OutputArrayProxy eb);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_AlignMTB_getMaxBits(OpenCvSafeHandle obj, out int value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_AlignMTB_setMaxBits(OpenCvSafeHandle obj, int value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_AlignMTB_getExcludeRange(OpenCvSafeHandle obj, out int value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_AlignMTB_setExcludeRange(OpenCvSafeHandle obj, int value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_AlignMTB_getCut(OpenCvSafeHandle obj, out int value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_AlignMTB_setCut(OpenCvSafeHandle obj, int value);

    // CalibrateDebevec

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_createCalibrateDebevec(int samples, float lambda, int random, out IntPtr returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Ptr_CalibrateDebevec_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Ptr_CalibrateDebevec_get(IntPtr obj, out IntPtr returnValue);
                
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_CalibrateDebevec_getLambda(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_CalibrateDebevec_setLambda(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_CalibrateDebevec_getSamples(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_CalibrateDebevec_setSamples(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_CalibrateDebevec_getRandom(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_CalibrateDebevec_setRandom(OpenCvSafeHandle obj, int value);

    // CalibrateRobertson

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_createCalibrateRobertson(int maxIter, float threshold, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Ptr_CalibrateRobertson_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Ptr_CalibrateRobertson_get(IntPtr obj, out IntPtr returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_CalibrateRobertson_getMaxIter(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_CalibrateRobertson_setMaxIter(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_CalibrateRobertson_getThreshold(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_CalibrateRobertson_setThreshold(OpenCvSafeHandle obj, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_CalibrateRobertson_getRadiance(OpenCvSafeHandle obj, IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_CalibrateCRF_process(
        OpenCvSafeHandle obj, IntPtr[] srcImgs, int srcImgsLength, in OutputArrayProxy dst, [In, MarshalAs(UnmanagedType.LPArray)] float[] times);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_createMergeDebevec(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Ptr_MergeDebevec_delete(IntPtr obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Ptr_MergeDebevec_get(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_createMergeRobertson(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_Ptr_MergeRobertson_delete(IntPtr obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_Ptr_MergeRobertson_get(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_MergeRobertson_process(OpenCvSafeHandle obj,
        IntPtr src, in OutputArrayProxy dst, in InputArrayProxy times);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_createMergeMertens(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Ptr_MergeMertens_delete(IntPtr obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_Ptr_MergeMertens_get(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_MergeExposures_process(
        OpenCvSafeHandle obj, IntPtr[] srcImgs, int srcImgsLength, in OutputArrayProxy dst, [In, MarshalAs(UnmanagedType.LPArray)] float[] times, in InputArrayProxy response);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_MergeMertens_process(OpenCvSafeHandle obj, IntPtr[] srcImgs, int srcImgsLength, in OutputArrayProxy dst);
}
