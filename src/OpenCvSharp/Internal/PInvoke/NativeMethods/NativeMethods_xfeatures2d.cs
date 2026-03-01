using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // BriefDescriptorExtractor

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_BriefDescriptorExtractor_create(int bytes, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_Ptr_BriefDescriptorExtractor_delete(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_BriefDescriptorExtractor_read(IntPtr obj, IntPtr fn);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_BriefDescriptorExtractor_write(IntPtr obj, IntPtr fs);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_BriefDescriptorExtractor_descriptorSize(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_BriefDescriptorExtractor_descriptorType(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_Ptr_BriefDescriptorExtractor_get(IntPtr ptr, out IntPtr returnValue);


    // FREAK

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_FREAK_create(int orientationNormalized,
        int scaleNormalized, float patternScale, int nOctaves,
        int[]? selectedPairs, int selectedPairsLength,
        out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_Ptr_FREAK_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_Ptr_FREAK_get(IntPtr ptr, out IntPtr returnValue);

    // StarDetector
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_StarDetector_create(
        int maxSize, int responseThreshold,
        int lineThresholdProjected, int lineThresholdBinarized, int suppressNonmaxSize, 
        out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_Ptr_StarDetector_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_Ptr_StarDetector_get(IntPtr ptr, out IntPtr returnValue);


    // LUCID

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_LUCID_create(int lucidKernel, int blurKernel, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_Ptr_LUCID_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_Ptr_LUCID_get(IntPtr ptr, out IntPtr returnValue);


    // LATCH

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_LATCH_create(
        int bytes, int rotationInvariance, int halfSsdSize, double sigma, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_Ptr_LATCH_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_Ptr_LATCH_get(IntPtr ptr, out IntPtr returnValue);


    // SURF

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_SURF_create(
        double hessianThreshold, int nOctaves,
        int nOctaveLayers, int extended, int upright, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_Ptr_SURF_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_Ptr_SURF_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_SURF_getHessianThreshold(IntPtr obj, out double returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_SURF_getNOctaves(IntPtr obj, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_SURF_getNOctaveLayers(IntPtr obj, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_SURF_getExtended(IntPtr obj, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_SURF_getUpright(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_SURF_setHessianThreshold(IntPtr obj, double value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_SURF_setNOctaves(IntPtr obj, int value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_SURF_setNOctaveLayers(IntPtr obj, int value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_SURF_setExtended(IntPtr obj, int value);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_SURF_setUpright(IntPtr obj, int value);
}
