using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable IDE1006 // Naming style
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // BOWTrainer

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWTrainer_add(OpenCvSafeHandle obj, IntPtr descriptors);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWTrainer_getDescriptors(OpenCvSafeHandle obj, IntPtr descriptors);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]

    public static partial ExceptionStatus xfeatures2d_BOWTrainer_descriptorsCount(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWTrainer_clear(OpenCvSafeHandle obj);


    // BOWKMeansTrainer

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWKMeansTrainer_new(
        int clusterCount, TermCriteria termcrit, int attempts, int flags, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWKMeansTrainer_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWKMeansTrainer_cluster1(
        OpenCvSafeHandle obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWKMeansTrainer_cluster2(
        OpenCvSafeHandle obj, IntPtr descriptors, out IntPtr returnValue);


    // BOWImgDescriptorExtractor

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWImgDescriptorExtractor_new1_Ptr(
        IntPtr dextractor, IntPtr dmatcher, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWImgDescriptorExtractor_new2_Ptr(
        IntPtr dmatcher, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWImgDescriptorExtractor_new1_RawPtr(
        IntPtr dextractor, IntPtr dmatcher, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWImgDescriptorExtractor_new2_RawPtr(
        IntPtr dmatcher, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWImgDescriptorExtractor_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWImgDescriptorExtractor_setVocabulary(OpenCvSafeHandle obj, IntPtr vocabulary);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWImgDescriptorExtractor_getVocabulary(OpenCvSafeHandle obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWImgDescriptorExtractor_compute11(
        OpenCvSafeHandle obj, IntPtr image, IntPtr keypoints, IntPtr imgDescriptor,
        IntPtr pointIdxsOfClusters, IntPtr descriptors);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWImgDescriptorExtractor_compute12(
        OpenCvSafeHandle obj, IntPtr keypointDescriptors,
        IntPtr imgDescriptor, IntPtr pointIdxsOfClusters);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWImgDescriptorExtractor_compute2(
        OpenCvSafeHandle obj, IntPtr image, IntPtr keypoints, IntPtr imgDescriptor);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWImgDescriptorExtractor_descriptorSize(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_BOWImgDescriptorExtractor_descriptorType(OpenCvSafeHandle obj, out int returnValue);
}
