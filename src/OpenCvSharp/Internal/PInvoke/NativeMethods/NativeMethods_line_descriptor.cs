using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenCvSharp.LineDescriptor;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus line_descriptor_LSDDetector_new1(
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus line_descriptor_LSDDetector_new2(
        double scale,
        double sigmaScale,
        double quant,
        double angTh,
        double logEps,
        double densityTh,
        int nBins,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus line_descriptor_LSDDetector_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus line_descriptor_LSDDetector_detect1(
        OpenCvSafeHandle obj, IntPtr image, IntPtr keypoints, int scale, int numOctaves, OpenCvSafeHandle mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus line_descriptor_LSDDetector_detect2(
        OpenCvSafeHandle obj,
        IntPtr[] images, int imagesSize,
        IntPtr keyLines, int scale, int numOctaves,
        IntPtr[] masks, int masksSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_create(
        IntPtr parameters, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_Ptr_BinaryDescriptor_get(
        IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_Ptr_BinaryDescriptor_delete(IntPtr obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_getNumOfOctaves(
        OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_setNumOfOctaves(
        OpenCvSafeHandle obj, int value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_getWidthOfBand(
        OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_setWidthOfBand(
        OpenCvSafeHandle obj, int value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_getReductionRatio(
        OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_setReductionRatio(
        OpenCvSafeHandle obj, int value);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_detect1(
        OpenCvSafeHandle obj, IntPtr image, IntPtr keyLines, OpenCvSafeHandle mask);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_detect2(
        OpenCvSafeHandle obj, IntPtr[] images, int imagesLength, IntPtr keyLines,
        IntPtr[] masks, int masksLength);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_compute1(
        OpenCvSafeHandle obj, IntPtr image, IntPtr keyLines, IntPtr descriptors, int returnFloatDescriptor);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_compute2(
        OpenCvSafeHandle obj, IntPtr[] images, int imagesLength,
        IntPtr[] keyLines, int[] keyLineSizes, int keyLinesLength,
        IntPtr outputKeyLines, IntPtr descriptors, int returnFloatDescriptor);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_descriptorSize(
        OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_descriptorType(
        OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_defaultNorm(
        OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_Params_new(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_Params_delete(IntPtr obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_Params_getAll(
        IntPtr obj, out BinaryDescriptorParamsData data);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_Params_setAll(
        IntPtr obj, BinaryDescriptorParamsData data);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_Params_read(IntPtr obj, IntPtr node);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptor_Params_write(IntPtr obj, IntPtr storage);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptorMatcher_create(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_Ptr_BinaryDescriptorMatcher_get(
        IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_Ptr_BinaryDescriptorMatcher_delete(IntPtr obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptorMatcher_match(
        OpenCvSafeHandle obj, IntPtr query, IntPtr train, IntPtr matches, OpenCvSafeHandle mask);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptorMatcher_matchQuery(
        OpenCvSafeHandle obj, IntPtr query, IntPtr matches, IntPtr[] masks, int masksLength);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptorMatcher_knnMatch(
        OpenCvSafeHandle obj, IntPtr query, IntPtr train, IntPtr matches, int k,
        OpenCvSafeHandle mask, int compactResult);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptorMatcher_knnMatchQuery(
        OpenCvSafeHandle obj, IntPtr query, IntPtr matches, int k,
        IntPtr[] masks, int masksLength, int compactResult);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptorMatcher_add(
        OpenCvSafeHandle obj, IntPtr[] descriptors, int descriptorsLength);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptorMatcher_train(OpenCvSafeHandle obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus line_descriptor_BinaryDescriptorMatcher_clear(OpenCvSafeHandle obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static unsafe partial ExceptionStatus line_descriptor_drawLineMatches(
        IntPtr image1, KeyLine* keyLines1, int keyLines1Length,
        IntPtr image2, KeyLine* keyLines2, int keyLines2Length,
        DMatch* matches, int matchesLength, IntPtr output,
        Scalar matchColor, Scalar singleLineColor,
        byte* matchesMask, int matchesMaskLength, int flags);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static unsafe partial ExceptionStatus line_descriptor_drawKeylines(
        IntPtr image, KeyLine* keyLines, int keyLinesLength,
        IntPtr output, Scalar color, int flags);
}

[StructLayout(LayoutKind.Sequential)]
internal struct BinaryDescriptorParamsData
{
    public int NumOfOctaves;
    public int WidthOfBand;
    public int ReductionRatio;
    public int KSize;
}
