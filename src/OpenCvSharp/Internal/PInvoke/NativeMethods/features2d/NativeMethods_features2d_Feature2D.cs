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

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Feature2D_detect_Mat1(
        IntPtr detector, IntPtr image, IntPtr keypoints, IntPtr mask);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Feature2D_detect_Mat2(
        IntPtr detector, IntPtr[] images, int imageLength, IntPtr keypoints, IntPtr[]? mask);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Feature2D_detect_InputArray(
        IntPtr detector, IntPtr image, IntPtr keypoints, IntPtr mask);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Feature2D_compute1(IntPtr obj, IntPtr image, IntPtr keypoints, IntPtr descriptors);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Feature2D_compute2(
        IntPtr detector, IntPtr[] images, int imageLength,
        IntPtr keypoints, IntPtr[] descriptors, int descriptorsLength);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Feature2D_detectAndCompute(
        IntPtr detector, IntPtr image, IntPtr mask,
        IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Feature2D_descriptorSize(IntPtr obj, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Feature2D_descriptorType(IntPtr obj, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Feature2D_defaultNorm(IntPtr obj, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Feature2D_empty(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Feature2D_write(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fileName);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Feature2D_read(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fileName);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Feature2D_getDefaultName(IntPtr obj, IntPtr returnValue);
        
    #region SIFT

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_SIFT_create(
        int nFeatures, int nOctaveLayers, double contrastThreshold, double edgeThreshold, double sigma, 
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_SIFT_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_SIFT_get(IntPtr ptr, out IntPtr returnValue);

    #endregion

    #region BRISK

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BRISK_create1(
        int thresh, int octaves, float patternScale, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BRISK_create2(
        float[] radiusList, int radiusListLength, 
        int[] numberList, int numberListLength,
        float dMax, float dMin,
        int[]? indexChange, int indexChangeLength, 
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_BRISK_create3(    
        int thresh, int octaves, 
        float[] radiusList, int radiusListLength, 
        int[] numberList, int numberListLength,
        float dMax, float dMin,
        int[]? indexChange, int indexChangeLength, 
        out IntPtr returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_BRISK_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_BRISK_get(IntPtr ptr, out IntPtr returnValue);

    #endregion

    #region ORB
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_create(
        int nFeatures, float scaleFactor, int nlevels, int edgeThreshold, int firstLevel, int wtaK, 
        int scoreType, int patchSize, int fastThreshold, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_ORB_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_ORB_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_setMaxFeatures(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_getMaxFeatures(IntPtr obj, out int returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_setScaleFactor(IntPtr obj, double val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_getScaleFactor(IntPtr obj, out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_setNLevels(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_getNLevels(IntPtr obj, out int returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_setEdgeThreshold(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_getEdgeThreshold(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_setFirstLevel(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_getFirstLevel(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_setWTA_K(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_getWTA_K(IntPtr obj, out int returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_setScoreType(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_getScoreType(IntPtr obj, out int returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_setPatchSize(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_getPatchSize(IntPtr obj, out int returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_setFastThreshold(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_ORB_getFastThreshold(IntPtr obj, out int returnValue);

    #endregion

    #region MSER
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_MSER_create(int delta, int minArea, int maxArea,
        double maxVariation, double minDiversity, int maxEvolution,
        double areaThreshold, double minMargin, int edgeBlurSize, 
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_MSER_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_MSER_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_MSER_detectRegions(
        IntPtr obj, IntPtr image, IntPtr msers, IntPtr bboxes);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_MSER_setDelta(IntPtr obj, int delta);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_MSER_getDelta(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_MSER_setMinArea(IntPtr obj, int minArea);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_MSER_getMinArea(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_MSER_setMaxArea(IntPtr obj, int maxArea);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_MSER_getMaxArea(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_MSER_setPass2Only(IntPtr obj, int f);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_MSER_getPass2Only(IntPtr obj, out int returnValue);

    #endregion

    #region FastFeatureDetector
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_FAST1(IntPtr image, IntPtr keypoints, int threshold, int nonmaxSupression);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_FAST2(IntPtr image, IntPtr keypoints, int threshold, int nonmaxSupression, int type);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_FastFeatureDetector_create(int threshold, int nonmaxSuppression, out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_FastFeatureDetector_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_FastFeatureDetector_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_FastFeatureDetector_setThreshold(IntPtr obj, int threshold);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_FastFeatureDetector_getThreshold(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_FastFeatureDetector_setNonmaxSuppression(IntPtr obj, int f);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_FastFeatureDetector_getNonmaxSuppression(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_FastFeatureDetector_setType(IntPtr obj, int type);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_FastFeatureDetector_getType(IntPtr obj, out int returnValue);

    #endregion

    #region AgastFeatureDetector
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AGAST(IntPtr image, IntPtr keypoints,
        int threshold, int nonmaxSuppression, int type);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AgastFeatureDetector_create(
        int threshold, int nonmaxSuppression, int type, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_AgastFeatureDetector_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_AgastFeatureDetector_get(IntPtr ptr, out IntPtr returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AgastFeatureDetector_setThreshold(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AgastFeatureDetector_getThreshold(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AgastFeatureDetector_setNonmaxSuppression(IntPtr obj,int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AgastFeatureDetector_getNonmaxSuppression(IntPtr obj, out int returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AgastFeatureDetector_setType(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AgastFeatureDetector_getType(IntPtr obj, out int returnValue);

    #endregion

    #region GFTTDetector
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_GFTTDetector_create(int maxCorners, double qualityLevel, 
        double minDistance, int blockSize, int useHarrisDetector, double k, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_GFTTDetector_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_GFTTDetector_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_GFTTDetector_setMaxFeatures(IntPtr obj, int maxFeatures);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_GFTTDetector_getMaxFeatures(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_GFTTDetector_setQualityLevel(IntPtr obj, double qLevel);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_GFTTDetector_getQualityLevel(IntPtr obj, out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_GFTTDetector_setMinDistance(IntPtr obj, double minDistance);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_GFTTDetector_getMinDistance(IntPtr obj, out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_GFTTDetector_setBlockSize(IntPtr obj, int blockSize);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_GFTTDetector_getBlockSize(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_GFTTDetector_setHarrisDetector(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_GFTTDetector_getHarrisDetector(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_GFTTDetector_setK(IntPtr obj, double k);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_GFTTDetector_getK(IntPtr obj, out double returnValue);

    #endregion

    #region SimpleBlobDetector

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_SimpleBlobDetector_create(
        ref SimpleBlobDetector.WParams parameters, out IntPtr returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_SimpleBlobDetector_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_SimpleBlobDetector_get(IntPtr ptr, out IntPtr returnValue);

    #endregion

    #region KAZE

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KAZE_create(
        int extended, int upright, float threshold,
        int nOctaves, int nOctaveLayers, int diffusivity, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_KAZE_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_KAZE_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KAZE_setDiffusivity(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KAZE_getDiffusivity(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KAZE_setExtended(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KAZE_getExtended(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KAZE_setNOctaveLayers(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KAZE_getNOctaveLayers(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KAZE_setNOctaves(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KAZE_getNOctaves(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KAZE_setThreshold(IntPtr obj, double val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KAZE_getThreshold(IntPtr obj, out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KAZE_setUpright(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_KAZE_getUpright(IntPtr obj, out int returnValue);

    #endregion

    #region AKAZE
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AKAZE_create(
        int descriptor_type, int descriptor_size, int descriptor_channels,
        float threshold, int nOctaves, int nOctaveLayers, int diffusivity, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_AKAZE_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_Ptr_AKAZE_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AKAZE_setDescriptorType(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AKAZE_getDescriptorType(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AKAZE_setDescriptorSize(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AKAZE_getDescriptorSize(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AKAZE_setDescriptorChannels(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AKAZE_getDescriptorChannels(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AKAZE_setThreshold(IntPtr obj, double val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AKAZE_getThreshold(IntPtr obj, out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AKAZE_setNOctaves(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AKAZE_getNOctaves(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AKAZE_setNOctaveLayers(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AKAZE_getNOctaveLayers(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AKAZE_setDiffusivity(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features2d_AKAZE_getDiffusivity(IntPtr obj, out int returnValue);

    #endregion
}
