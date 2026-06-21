using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // ReSharper disable InconsistentNaming
    #region BRISK

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_BRISK_create1(
        int thresh, int octaves, float patternScale, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_BRISK_create2(
        float[] radiusList, int radiusListLength, 
        int[] numberList, int numberListLength,
        float dMax, float dMin,
        int[]? indexChange, int indexChangeLength, 
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_BRISK_create3(    
        int thresh, int octaves, 
        float[] radiusList, int radiusListLength, 
        int[] numberList, int numberListLength,
        float dMax, float dMin,
        int[]? indexChange, int indexChangeLength, 
        out IntPtr returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_Ptr_BRISK_delete(IntPtr ptr);

    #endregion
    #region AgastFeatureDetector
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AGAST(IntPtr image, IntPtr keypoints,
        int threshold, int nonmaxSuppression, int type);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AgastFeatureDetector_create(
        int threshold, int nonmaxSuppression, int type, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_Ptr_AgastFeatureDetector_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AgastFeatureDetector_setThreshold(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AgastFeatureDetector_getThreshold(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AgastFeatureDetector_setNonmaxSuppression(IntPtr obj,int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AgastFeatureDetector_getNonmaxSuppression(IntPtr obj, out int returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AgastFeatureDetector_setType(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AgastFeatureDetector_getType(IntPtr obj, out int returnValue);

    #endregion
    #region KAZE

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_KAZE_create(
        int extended, int upright, float threshold,
        int nOctaves, int nOctaveLayers, int diffusivity, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_Ptr_KAZE_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_KAZE_setDiffusivity(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_KAZE_getDiffusivity(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_KAZE_setExtended(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_KAZE_getExtended(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_KAZE_setNOctaveLayers(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_KAZE_getNOctaveLayers(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_KAZE_setNOctaves(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_KAZE_getNOctaves(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_KAZE_setThreshold(IntPtr obj, double val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_KAZE_getThreshold(IntPtr obj, out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_KAZE_setUpright(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_KAZE_getUpright(IntPtr obj, out int returnValue);

    #endregion

    #region AKAZE
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AKAZE_create(
        int descriptor_type, int descriptor_size, int descriptor_channels,
        float threshold, int nOctaves, int nOctaveLayers, int diffusivity, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_Ptr_AKAZE_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AKAZE_setDescriptorType(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AKAZE_getDescriptorType(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AKAZE_setDescriptorSize(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AKAZE_getDescriptorSize(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AKAZE_setDescriptorChannels(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AKAZE_getDescriptorChannels(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AKAZE_setThreshold(IntPtr obj, double val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AKAZE_getThreshold(IntPtr obj, out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AKAZE_setNOctaves(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AKAZE_getNOctaves(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AKAZE_setNOctaveLayers(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AKAZE_getNOctaveLayers(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AKAZE_setDiffusivity(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xfeatures2d_AKAZE_getDiffusivity(IntPtr obj, out int returnValue);

    #endregion
}
