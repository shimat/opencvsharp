using System.Runtime.CompilerServices;
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

    // Feature2D base entry points take the object as an OpenCvSafeHandle (callers pass Handle and drop
    // GC.KeepAlive(this)). Image / keypoint / mask arguments stay IntPtr until those classes are swept.
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Feature2D_detect_Mat1(
        OpenCvSafeHandle detector, IntPtr image, IntPtr keypoints, IntPtr mask);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Feature2D_detect_Mat2(
        OpenCvSafeHandle detector, IntPtr[] images, int imageLength, IntPtr keypoints, IntPtr[]? mask);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Feature2D_detect_InputArray(
        OpenCvSafeHandle detector, IntPtr image, IntPtr keypoints, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Feature2D_compute1(OpenCvSafeHandle obj, IntPtr image, IntPtr keypoints, IntPtr descriptors);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Feature2D_compute2(
        OpenCvSafeHandle detector, IntPtr[] images, int imageLength,
        IntPtr keypoints, IntPtr[] descriptors, int descriptorsLength);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Feature2D_detectAndCompute(
        OpenCvSafeHandle detector, IntPtr image, IntPtr mask,
        IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Feature2D_descriptorSize(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Feature2D_descriptorType(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Feature2D_defaultNorm(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Feature2D_empty(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Feature2D_write(OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string fileName);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Feature2D_read(OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string fileName);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Feature2D_getDefaultName(OpenCvSafeHandle obj, IntPtr returnValue);
        
    #region SIFT

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_SIFT_create(
        int nFeatures, int nOctaveLayers, double contrastThreshold, double edgeThreshold, double sigma, 
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_SIFT_delete(IntPtr ptr);

    #endregion


    #region ORB
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_create(
        int nFeatures, float scaleFactor, int nlevels, int edgeThreshold, int firstLevel, int wtaK, 
        int scoreType, int patchSize, int fastThreshold, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_ORB_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_setMaxFeatures(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_getMaxFeatures(OpenCvSafeHandle obj, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_setScaleFactor(OpenCvSafeHandle obj, double val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_getScaleFactor(OpenCvSafeHandle obj, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_setNLevels(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_getNLevels(OpenCvSafeHandle obj, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_setEdgeThreshold(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_getEdgeThreshold(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_setFirstLevel(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_getFirstLevel(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_setWTA_K(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_getWTA_K(OpenCvSafeHandle obj, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_setScoreType(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_getScoreType(OpenCvSafeHandle obj, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_setPatchSize(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_getPatchSize(OpenCvSafeHandle obj, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_setFastThreshold(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ORB_getFastThreshold(OpenCvSafeHandle obj, out int returnValue);

    #endregion

    #region MSER
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_MSER_create(int delta, int minArea, int maxArea,
        double maxVariation, double minDiversity, int maxEvolution,
        double areaThreshold, double minMargin, int edgeBlurSize, 
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_MSER_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_MSER_detectRegions(
        OpenCvSafeHandle obj, IntPtr image, IntPtr msers, IntPtr bboxes);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_MSER_setDelta(OpenCvSafeHandle obj, int delta);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_MSER_getDelta(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_MSER_setMinArea(OpenCvSafeHandle obj, int minArea);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_MSER_getMinArea(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_MSER_setMaxArea(OpenCvSafeHandle obj, int maxArea);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_MSER_getMaxArea(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_MSER_setPass2Only(OpenCvSafeHandle obj, int f);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_MSER_getPass2Only(OpenCvSafeHandle obj, out int returnValue);

    #endregion

    #region FastFeatureDetector
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_FAST1(IntPtr image, IntPtr keypoints, int threshold, int nonmaxSupression);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_FAST2(IntPtr image, IntPtr keypoints, int threshold, int nonmaxSupression, int type);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_FastFeatureDetector_create(int threshold, int nonmaxSuppression, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_FastFeatureDetector_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_FastFeatureDetector_setThreshold(OpenCvSafeHandle obj, int threshold);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_FastFeatureDetector_getThreshold(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_FastFeatureDetector_setNonmaxSuppression(OpenCvSafeHandle obj, int f);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_FastFeatureDetector_getNonmaxSuppression(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_FastFeatureDetector_setType(OpenCvSafeHandle obj, int type);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_FastFeatureDetector_getType(OpenCvSafeHandle obj, out int returnValue);

    #endregion


    #region GFTTDetector
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_GFTTDetector_create(int maxCorners, double qualityLevel, 
        double minDistance, int blockSize, int useHarrisDetector, double k, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_GFTTDetector_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_GFTTDetector_setMaxFeatures(OpenCvSafeHandle obj, int maxFeatures);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_GFTTDetector_getMaxFeatures(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_GFTTDetector_setQualityLevel(OpenCvSafeHandle obj, double qLevel);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_GFTTDetector_getQualityLevel(OpenCvSafeHandle obj, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_GFTTDetector_setMinDistance(OpenCvSafeHandle obj, double minDistance);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_GFTTDetector_getMinDistance(OpenCvSafeHandle obj, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_GFTTDetector_setBlockSize(OpenCvSafeHandle obj, int blockSize);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_GFTTDetector_getBlockSize(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_GFTTDetector_setHarrisDetector(OpenCvSafeHandle obj, int val);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_GFTTDetector_getHarrisDetector(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_GFTTDetector_setK(OpenCvSafeHandle obj, double k);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_GFTTDetector_getK(OpenCvSafeHandle obj, out double returnValue);

    #endregion

    #region SimpleBlobDetector

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_SimpleBlobDetector_create(
        ref SimpleBlobDetector.WParams parameters, out IntPtr returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_SimpleBlobDetector_delete(IntPtr ptr);

    #endregion


    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_Feature2D_get(IntPtr obj, out IntPtr returnValue);

    #region AffineFeature

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_AffineFeature_create(
        IntPtr backend, int maxTilt, int minTilt, float tiltStep, float rotateStepBase, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_AffineFeature_setViewParams(
        OpenCvSafeHandle obj, float[] tilts, int tiltsLength, float[] rolls, int rollsLength);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_AffineFeature_getViewParams(OpenCvSafeHandle obj, IntPtr tilts, IntPtr rolls);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_AffineFeature_delete(IntPtr ptr);

    #endregion

    #region DISK

    [LibraryImport(DllExtern, EntryPoint = "features_DISK_create"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DISK_create_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string modelPath, int maxKeypoints, float scoreThreshold, Size imageSize, int backendId, int targetId, out IntPtr returnValue);

    [LibraryImport(DllExtern, EntryPoint = "features_DISK_create"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DISK_create_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string modelPath, int maxKeypoints, float scoreThreshold, Size imageSize, int backendId, int targetId, out IntPtr returnValue);

    public static ExceptionStatus features_DISK_create(string modelPath, int maxKeypoints, float scoreThreshold, Size imageSize, int backendId, int targetId, out IntPtr returnValue)
        => IsWindows()
            ? features_DISK_create_Windows(modelPath, maxKeypoints, scoreThreshold, imageSize, backendId, targetId, out returnValue)
            : features_DISK_create_NotWindows(modelPath, maxKeypoints, scoreThreshold, imageSize, backendId, targetId, out returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DISK_create_buffer(
        byte[] bufferModel, IntPtr bufferModelLength, int maxKeypoints, float scoreThreshold, Size imageSize, int backendId, int targetId, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DISK_setMaxKeypoints(OpenCvSafeHandle obj, int maxKeypoints);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DISK_getMaxKeypoints(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DISK_setScoreThreshold(OpenCvSafeHandle obj, float threshold);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DISK_getScoreThreshold(OpenCvSafeHandle obj, out float returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DISK_setImageSize(OpenCvSafeHandle obj, Size size);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_DISK_getImageSize(OpenCvSafeHandle obj, out Size returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_DISK_delete(IntPtr ptr);

    #endregion

    #region ALIKED

    [LibraryImport(DllExtern, EntryPoint = "features_ALIKED_create"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ALIKED_create_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string modelPath, Size inputSize, int normalizeDescriptors, int engine, int backend, int target, out IntPtr returnValue);

    [LibraryImport(DllExtern, EntryPoint = "features_ALIKED_create"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ALIKED_create_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string modelPath, Size inputSize, int normalizeDescriptors, int engine, int backend, int target, out IntPtr returnValue);

    public static ExceptionStatus features_ALIKED_create(string modelPath, Size inputSize, int normalizeDescriptors, int engine, int backend, int target, out IntPtr returnValue)
        => IsWindows()
            ? features_ALIKED_create_Windows(modelPath, inputSize, normalizeDescriptors, engine, backend, target, out returnValue)
            : features_ALIKED_create_NotWindows(modelPath, inputSize, normalizeDescriptors, engine, backend, target, out returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_ALIKED_create_buffer(
        byte[] modelData, IntPtr modelDataLength, Size inputSize, int normalizeDescriptors, int engine, int backend, int target, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus features_Ptr_ALIKED_delete(IntPtr ptr);

    #endregion
}
