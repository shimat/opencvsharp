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

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWTrainer_add(IntPtr obj, IntPtr descriptors);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWTrainer_getDescriptors(IntPtr obj, IntPtr descriptors);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

    public static extern ExceptionStatus features2d_BOWTrainer_descriptorsCount(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWTrainer_clear(IntPtr obj);


    // BOWKMeansTrainer

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWKMeansTrainer_new(
        int clusterCount, TermCriteria termcrit, int attempts, int flags, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWKMeansTrainer_delete(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWKMeansTrainer_cluster1(
        IntPtr obj, out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWKMeansTrainer_cluster2(
        IntPtr obj, IntPtr descriptors, out IntPtr returnValue);


    // BOWImgDescriptorExtractor

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWImgDescriptorExtractor_new1_Ptr(
        IntPtr dextractor, IntPtr dmatcher, out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWImgDescriptorExtractor_new2_Ptr(
        IntPtr dmatcher, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWImgDescriptorExtractor_new1_RawPtr(
        IntPtr dextractor, IntPtr dmatcher, out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWImgDescriptorExtractor_new2_RawPtr(
        IntPtr dmatcher, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWImgDescriptorExtractor_delete(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWImgDescriptorExtractor_setVocabulary(IntPtr obj, IntPtr vocabulary);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWImgDescriptorExtractor_getVocabulary(IntPtr obj, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWImgDescriptorExtractor_compute11(
        IntPtr obj, IntPtr image, IntPtr keypoints, IntPtr imgDescriptor,
        IntPtr pointIdxsOfClusters, IntPtr descriptors);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWImgDescriptorExtractor_compute12(
        IntPtr obj, IntPtr keypointDescriptors,
        IntPtr imgDescriptor, IntPtr pointIdxsOfClusters);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWImgDescriptorExtractor_compute2(
        IntPtr obj, IntPtr image, IntPtr keypoints, IntPtr imgDescriptor);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWImgDescriptorExtractor_descriptorSize(IntPtr obj, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BOWImgDescriptorExtractor_descriptorType(IntPtr obj, out int returnValue);
}
