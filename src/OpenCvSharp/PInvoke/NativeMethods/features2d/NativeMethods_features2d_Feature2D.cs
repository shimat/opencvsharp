using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // ReSharper disable InconsistentNaming

        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern ExceptionStatus features2d_Ptr_Feature2D_get(IntPtr ptr, out IntPtr returnValue);
        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern ExceptionStatus features2d_Ptr_Feature2D_delete(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Feature2D_detect_Mat1(
            IntPtr detector, IntPtr image, IntPtr keypoints, IntPtr mask);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Feature2D_detect_Mat2(
            IntPtr detector, IntPtr[] images, int imageLength, IntPtr keypoints, IntPtr[]? mask);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Feature2D_detect_InputArray(
            IntPtr detector, IntPtr image, IntPtr keypoints, IntPtr mask);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Feature2D_compute1(IntPtr obj, IntPtr image, IntPtr keypoints, IntPtr descriptors);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Feature2D_compute2(
            IntPtr detector, IntPtr[] images, int imageLength,
            IntPtr keypoints, IntPtr[] descriptors, int descriptorsLength);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Feature2D_detectAndCompute(
            IntPtr detector, IntPtr image, IntPtr mask,
            IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Feature2D_descriptorSize(IntPtr obj, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Feature2D_descriptorType(IntPtr obj, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Feature2D_defaultNorm(IntPtr obj, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Feature2D_empty(IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Feature2D_write(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fileName);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Feature2D_read(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fileName);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Feature2D_getDefaultName(IntPtr obj, IntPtr returnValue);

        #region BRISK

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_BRISK_create1(
            int thresh, int octaves, float patternScale, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_BRISK_create2(
            float[] radiusList, int radiusListLength, 
            int[] numberList, int numberListLength,
            float dMax, float dMin,
            int[]? indexChange, int indexChangeLength, 
            out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_BRISK_create3(    
            int thresh, int octaves, 
            float[] radiusList, int radiusListLength, 
            int[] numberList, int numberListLength,
            float dMax, float dMin,
            int[]? indexChange, int indexChangeLength, 
            out IntPtr returnValue);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Ptr_BRISK_delete(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Ptr_BRISK_get(IntPtr ptr, out IntPtr returnValue);

        #endregion

        #region ORB
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_create(
            int nFeatures, float scaleFactor, int nlevels, int edgeThreshold, int firstLevel, int wtaK, 
            int scoreType, int patchSize, int fastThreshold, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Ptr_ORB_delete(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Ptr_ORB_get(IntPtr ptr, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_setMaxFeatures(IntPtr obj, int val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_getMaxFeatures(IntPtr obj, out int returnValue);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_setScaleFactor(IntPtr obj, double val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_getScaleFactor(IntPtr obj, out double returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_setNLevels(IntPtr obj, int val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_getNLevels(IntPtr obj, out int returnValue);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_setEdgeThreshold(IntPtr obj, int val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_getEdgeThreshold(IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_setFirstLevel(IntPtr obj, int val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_getFirstLevel(IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_setWTA_K(IntPtr obj, int val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_getWTA_K(IntPtr obj, out int returnValue);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_setScoreType(IntPtr obj, int val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_getScoreType(IntPtr obj, out int returnValue);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_setPatchSize(IntPtr obj, int val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_getPatchSize(IntPtr obj, out int returnValue);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_setFastThreshold(IntPtr obj, int val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_ORB_getFastThreshold(IntPtr obj, out int returnValue);

        #endregion

        #region MSER
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_MSER_create(int delta, int minArea, int maxArea,
                                                        double maxVariation, double minDiversity, int maxEvolution,
                                                        double areaThreshold, double minMargin, int edgeBlurSize, 
                                                        out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Ptr_MSER_delete(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Ptr_MSER_get(IntPtr ptr, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_MSER_detectRegions(
            IntPtr obj, IntPtr image, IntPtr msers, IntPtr bboxes);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_MSER_setDelta(IntPtr obj, int delta);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_MSER_getDelta(IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_MSER_setMinArea(IntPtr obj, int minArea);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_MSER_getMinArea(IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_MSER_setMaxArea(IntPtr obj, int maxArea);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_MSER_getMaxArea(IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_MSER_setPass2Only(IntPtr obj, int f);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_MSER_getPass2Only(IntPtr obj, out int returnValue);

        #endregion

        #region FastFeatureDetector
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_FAST1(IntPtr image, IntPtr keypoints, int threshold, int nonmaxSupression);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_FAST2(IntPtr image, IntPtr keypoints, int threshold, int nonmaxSupression, int type);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_FastFeatureDetector_create(int threshold, int nonmaxSuppression, out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Ptr_FastFeatureDetector_delete(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Ptr_FastFeatureDetector_get(IntPtr ptr, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_FastFeatureDetector_setThreshold(IntPtr obj, int threshold);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_FastFeatureDetector_getThreshold(IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_FastFeatureDetector_setNonmaxSuppression(IntPtr obj, int f);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_FastFeatureDetector_getNonmaxSuppression(IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_FastFeatureDetector_setType(IntPtr obj, int type);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_FastFeatureDetector_getType(IntPtr obj, out int returnValue);

        #endregion

        #region AgastFeatureDetector
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_AGAST(IntPtr image, IntPtr keypoints,
            int threshold, int nonmaxSuppression, int type);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_AgastFeatureDetector_create(
            int threshold, int nonmaxSuppression, int type, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Ptr_AgastFeatureDetector_delete(IntPtr ptr);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_Ptr_AgastFeatureDetector_get(IntPtr ptr, out IntPtr returnValue);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_AgastFeatureDetector_setThreshold(IntPtr obj, int val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_AgastFeatureDetector_getThreshold(IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_AgastFeatureDetector_setNonmaxSuppression(IntPtr obj,int val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_AgastFeatureDetector_getNonmaxSuppression(IntPtr obj, out int returnValue);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_AgastFeatureDetector_setType(IntPtr obj, int val);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus features2d_AgastFeatureDetector_getType(IntPtr obj, out int returnValue);

        #endregion
    }
}