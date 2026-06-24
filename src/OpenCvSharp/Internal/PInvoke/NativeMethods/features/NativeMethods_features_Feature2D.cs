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
    public static extern ExceptionStatus features_Feature2D_detect_Mat1(
        IntPtr detector, IntPtr image, IntPtr keypoints, IntPtr mask);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Feature2D_detect_Mat2(
        IntPtr detector, IntPtr[] images, int imageLength, IntPtr keypoints, IntPtr[]? mask);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Feature2D_detect_InputArray(
        IntPtr detector, IntPtr image, IntPtr keypoints, IntPtr mask);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Feature2D_compute1(IntPtr obj, IntPtr image, IntPtr keypoints, IntPtr descriptors);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Feature2D_compute2(
        IntPtr detector, IntPtr[] images, int imageLength,
        IntPtr keypoints, IntPtr[] descriptors, int descriptorsLength);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Feature2D_detectAndCompute(
        IntPtr detector, IntPtr image, IntPtr mask,
        IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Feature2D_descriptorSize(IntPtr obj, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Feature2D_descriptorType(IntPtr obj, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Feature2D_defaultNorm(IntPtr obj, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Feature2D_empty(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Feature2D_write(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fileName);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Feature2D_read(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fileName);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Feature2D_getDefaultName(IntPtr obj, IntPtr returnValue);
        
    #region SIFT

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_SIFT_create(
        int nFeatures, int nOctaveLayers, double contrastThreshold, double edgeThreshold, double sigma, 
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Ptr_SIFT_delete(IntPtr ptr);

    #endregion


    #region ORB
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_create(
        int nFeatures, float scaleFactor, int nlevels, int edgeThreshold, int firstLevel, int wtaK, 
        int scoreType, int patchSize, int fastThreshold, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Ptr_ORB_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_setMaxFeatures(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_getMaxFeatures(IntPtr obj, out int returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_setScaleFactor(IntPtr obj, double val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_getScaleFactor(IntPtr obj, out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_setNLevels(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_getNLevels(IntPtr obj, out int returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_setEdgeThreshold(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_getEdgeThreshold(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_setFirstLevel(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_getFirstLevel(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_setWTA_K(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_getWTA_K(IntPtr obj, out int returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_setScoreType(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_getScoreType(IntPtr obj, out int returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_setPatchSize(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_getPatchSize(IntPtr obj, out int returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_setFastThreshold(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ORB_getFastThreshold(IntPtr obj, out int returnValue);

    #endregion

    #region MSER
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_MSER_create(int delta, int minArea, int maxArea,
        double maxVariation, double minDiversity, int maxEvolution,
        double areaThreshold, double minMargin, int edgeBlurSize, 
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Ptr_MSER_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_MSER_detectRegions(
        IntPtr obj, IntPtr image, IntPtr msers, IntPtr bboxes);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_MSER_setDelta(IntPtr obj, int delta);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_MSER_getDelta(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_MSER_setMinArea(IntPtr obj, int minArea);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_MSER_getMinArea(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_MSER_setMaxArea(IntPtr obj, int maxArea);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_MSER_getMaxArea(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_MSER_setPass2Only(IntPtr obj, int f);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_MSER_getPass2Only(IntPtr obj, out int returnValue);

    #endregion

    #region FastFeatureDetector
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_FAST1(IntPtr image, IntPtr keypoints, int threshold, int nonmaxSupression);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_FAST2(IntPtr image, IntPtr keypoints, int threshold, int nonmaxSupression, int type);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_FastFeatureDetector_create(int threshold, int nonmaxSuppression, out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Ptr_FastFeatureDetector_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_FastFeatureDetector_setThreshold(IntPtr obj, int threshold);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_FastFeatureDetector_getThreshold(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_FastFeatureDetector_setNonmaxSuppression(IntPtr obj, int f);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_FastFeatureDetector_getNonmaxSuppression(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_FastFeatureDetector_setType(IntPtr obj, int type);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_FastFeatureDetector_getType(IntPtr obj, out int returnValue);

    #endregion


    #region GFTTDetector
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_GFTTDetector_create(int maxCorners, double qualityLevel, 
        double minDistance, int blockSize, int useHarrisDetector, double k, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Ptr_GFTTDetector_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_GFTTDetector_setMaxFeatures(IntPtr obj, int maxFeatures);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_GFTTDetector_getMaxFeatures(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_GFTTDetector_setQualityLevel(IntPtr obj, double qLevel);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_GFTTDetector_getQualityLevel(IntPtr obj, out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_GFTTDetector_setMinDistance(IntPtr obj, double minDistance);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_GFTTDetector_getMinDistance(IntPtr obj, out double returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_GFTTDetector_setBlockSize(IntPtr obj, int blockSize);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_GFTTDetector_getBlockSize(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_GFTTDetector_setHarrisDetector(IntPtr obj, int val);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_GFTTDetector_getHarrisDetector(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_GFTTDetector_setK(IntPtr obj, double k);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_GFTTDetector_getK(IntPtr obj, out double returnValue);

    #endregion

    #region SimpleBlobDetector

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_SimpleBlobDetector_create(
        ref SimpleBlobDetector.WParams parameters, out IntPtr returnValue);
        
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Ptr_SimpleBlobDetector_delete(IntPtr ptr);

    #endregion


    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Ptr_Feature2D_get(IntPtr obj, out IntPtr returnValue);

    #region AffineFeature

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_AffineFeature_create(
        IntPtr backend, int maxTilt, int minTilt, float tiltStep, float rotateStepBase, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_AffineFeature_setViewParams(
        IntPtr obj, float[] tilts, int tiltsLength, float[] rolls, int rollsLength);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_AffineFeature_getViewParams(IntPtr obj, IntPtr tilts, IntPtr rolls);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Ptr_AffineFeature_delete(IntPtr ptr);

    #endregion

    #region DISK

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "features_DISK_create")]
    public static extern ExceptionStatus features_DISK_create_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string modelPath, int maxKeypoints, float scoreThreshold, Size imageSize, int backendId, int targetId, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "features_DISK_create")]
    public static extern ExceptionStatus features_DISK_create_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string modelPath, int maxKeypoints, float scoreThreshold, Size imageSize, int backendId, int targetId, out IntPtr returnValue);

    public static ExceptionStatus features_DISK_create(string modelPath, int maxKeypoints, float scoreThreshold, Size imageSize, int backendId, int targetId, out IntPtr returnValue)
        => IsWindows()
            ? features_DISK_create_Windows(modelPath, maxKeypoints, scoreThreshold, imageSize, backendId, targetId, out returnValue)
            : features_DISK_create_NotWindows(modelPath, maxKeypoints, scoreThreshold, imageSize, backendId, targetId, out returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_DISK_create_buffer(
        byte[] bufferModel, IntPtr bufferModelLength, int maxKeypoints, float scoreThreshold, Size imageSize, int backendId, int targetId, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_DISK_setMaxKeypoints(IntPtr obj, int maxKeypoints);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_DISK_getMaxKeypoints(IntPtr obj, out int returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_DISK_setScoreThreshold(IntPtr obj, float threshold);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_DISK_getScoreThreshold(IntPtr obj, out float returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_DISK_setImageSize(IntPtr obj, Size size);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_DISK_getImageSize(IntPtr obj, out Size returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Ptr_DISK_delete(IntPtr ptr);

    #endregion

    #region ALIKED

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "features_ALIKED_create")]
    public static extern ExceptionStatus features_ALIKED_create_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string modelPath, Size inputSize, int normalizeDescriptors, int engine, int backend, int target, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "features_ALIKED_create")]
    public static extern ExceptionStatus features_ALIKED_create_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string modelPath, Size inputSize, int normalizeDescriptors, int engine, int backend, int target, out IntPtr returnValue);

    public static ExceptionStatus features_ALIKED_create(string modelPath, Size inputSize, int normalizeDescriptors, int engine, int backend, int target, out IntPtr returnValue)
        => IsWindows()
            ? features_ALIKED_create_Windows(modelPath, inputSize, normalizeDescriptors, engine, backend, target, out returnValue)
            : features_ALIKED_create_NotWindows(modelPath, inputSize, normalizeDescriptors, engine, backend, target, out returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_ALIKED_create_buffer(
        byte[] modelData, IntPtr modelDataLength, Size inputSize, int normalizeDescriptors, int engine, int backend, int target, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus features_Ptr_ALIKED_delete(IntPtr ptr);

    #endregion
}
