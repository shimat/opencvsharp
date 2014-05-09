/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.CPlusPlus
{
    static partial class NativeMethods
    {
        #region LatendSvmDetector

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr objdetect_LatentSvmDetector_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_LatentSvmDetector_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_LatentSvmDetector_clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int objdetect_LatentSvmDetector_empty(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int objdetect_LatentSvmDetector_load(IntPtr obj,
            IntPtr[] fileNames, int fileNamesLength,
            IntPtr[] classNames, int classNamesLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_LatentSvmDetector_detect(
            IntPtr obj, IntPtr image, IntPtr objectDetections,
            float overlapThreshold, int numThreads);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_LatentSvmDetector_getClassNames(IntPtr obj, IntPtr outValues);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr objdetect_LatentSvmDetector_getClassCount(IntPtr obj);

        #endregion

        #region CascadeClassfier

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr objdetect_CascadeClassifier_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr objdetect_CascadeClassifier_newFromFile([MarshalAs(UnmanagedType.LPStr)] string fileName);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_CascadeClassifier_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int objdetect_CascadeClassifier_empty(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int objdetect_CascadeClassifier_load(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fileName);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "objdetect_CascadeClassifier_detectMultiScale1")]
        public static extern void objdetect_CascadeClassifier_detectMultiScale(
            IntPtr obj, IntPtr image, IntPtr objects,
            double scaleFactor, int minNeighbors, int flags, CvSize minSize, CvSize maxSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "objdetect_CascadeClassifier_detectMultiScale2")]
        public static extern void objdetect_CascadeClassifier_detectMultiScale(
            IntPtr obj, IntPtr image, IntPtr objects,
            IntPtr rejectLevels, IntPtr levelWeights,
            double scaleFactor, int minNeighbors, int flags,
            CvSize minSize, CvSize maxSize, int outputRejectLevels);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int objdetect_CascadeClassifier_isOldFormatCascade(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize objdetect_CascadeClassifier_getOriginalWindowSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int objdetect_CascadeClassifier_getFeatureType(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int objdetect_CascadeClassifier_setImage(IntPtr obj, IntPtr img);

        #endregion

        #region HOGDescriptor
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int objdetect_HOGDescriptor_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr objdetect_HOGDescriptor_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr objdetect_HOGDescriptor_new2(CvSize winSize, CvSize blockSize, CvSize blockStride, CvSize cellSize,
            int nbins, int derivAperture, double winSigma, [MarshalAs(UnmanagedType.I4)] HistogramNormType histogramNormType,
            double l2HysThreshold, int gammaCorrection, int nlevels);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr objdetect_HOGDescriptor_new3([MarshalAs(UnmanagedType.LPStr)] string fileName);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_delete(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr objdetect_HOGDescriptor_getDescriptorSize(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int objdetect_HOGDescriptor_checkDetectorSize(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double objdetect_HOGDescriptor_getWinSigma(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_setSVMDetector(IntPtr self, IntPtr svmdetector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern bool objdetect_HOGDescriptor_load(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string objname);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void objdetect_HOGDescriptor_save(IntPtr self, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string objname);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_compute(
            IntPtr self, IntPtr img, IntPtr descriptors,
                         Size winStride, Size padding, [In] Point[] locations, int locationsLength);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "objdetect_HOGDescriptor_detect1")]
        public static extern void objdetect_HOGDescriptor_detect(
            IntPtr self, IntPtr img, IntPtr foundLocations,
            double hitThreshold, CvSize winStride, CvSize padding, [In] Point[] searchLocations, int searchLocationsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "objdetect_HOGDescriptor_detect2")]
        public static extern void objdetect_HOGDescriptor_detect(
            IntPtr self, IntPtr img, IntPtr foundLocations, IntPtr weights,
            double hitThreshold, CvSize winStride, CvSize padding, [In] Point[] searchLocations, int searchLocationsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "objdetect_HOGDescriptor_detectMultiScale1")]
        public static extern void objdetect_HOGDescriptor_detectMultiScale(
            IntPtr self, IntPtr img, IntPtr foundLocations,
            double hitThreshold, CvSize winStride, CvSize padding, double scale, int groupThreshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "objdetect_HOGDescriptor_detectMultiScale2")]
        public static extern void objdetect_HOGDescriptor_detectMultiScale(
            IntPtr self, IntPtr img, IntPtr foundLocations, IntPtr foundWeights,
            double hitThreshold, CvSize winStride, CvSize padding, double scale, int groupThreshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_computeGradient(
            IntPtr self, IntPtr img, IntPtr grad, IntPtr angleOfs, CvSize paddingTL, CvSize paddingBR);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_detectROI(
            IntPtr obj, IntPtr img,
            Point[] locations, int locationsLength,
            IntPtr foundLocations, IntPtr confidences,
            double hitThreshold, CvSize winStride, CvSize padding);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_detectMultiScaleROI(
            IntPtr obj, IntPtr img, IntPtr foundLocations,
            IntPtr roiScales, IntPtr roiLocations, IntPtr roiConfidences,
            double hitThreshold, int groupThreshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void objdetect_HOGDescriptor_readALTModel(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string modelfile);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_groupRectangles(IntPtr obj,
            IntPtr rectList, IntPtr weights, int groupThreshold, double eps);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize objdetect_HOGDescriptor_winSize_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize objdetect_HOGDescriptor_blockSize_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize objdetect_HOGDescriptor_blockStride_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize objdetect_HOGDescriptor_cellSize_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int objdetect_HOGDescriptor_nbins_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int objdetect_HOGDescriptor_derivAperture_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double objdetect_HOGDescriptor_winSigma_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int objdetect_HOGDescriptor_histogramNormType_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double objdetect_HOGDescriptor_L2HysThreshold_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int objdetect_HOGDescriptor_gammaCorrection_get(IntPtr self);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int objdetect_HOGDescriptor_nlevels_get(IntPtr self);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_winSize_set(IntPtr self, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_blockSize_set(IntPtr self, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_blockStride_set(IntPtr self, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_cellSize_set(IntPtr self, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_nbins_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_derivAperture_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_winSigma_set(IntPtr self, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_histogramNormType_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_L2HysThreshold_set(IntPtr self, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_gammaCorrection_set(IntPtr self, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void objdetect_HOGDescriptor_nlevels_set(IntPtr self, int value);
        #endregion
    }
}