#if ENABLED_CUDA

using System;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Cuda;

#pragma warning disable 1591

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    static partial class NativeMethods
    {
        #region Device
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_getCudaEnabledDeviceCount();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_setDevice(int device);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_getDevice();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_resetDevice();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_deviceSupports(int feature_set);

        // TargetArchs
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_TargetArchs_builtWith(int feature_set);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_TargetArchs_has(int major, int minor);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_TargetArchs_hasPtx(int major, int minor);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_TargetArchs_hasBin(int major, int minor);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_TargetArchs_hasEqualOrLessPtx(int major, int minor);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_TargetArchs_hasEqualOrGreater(int major, int minor);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_TargetArchs_hasEqualOrGreaterPtx(int major, int minor);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_TargetArchs_hasEqualOrGreaterBin(int major, int minor);

        // DeviceInfo
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_DeviceInfo_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_DeviceInfo_new2(int deviceId);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_DeviceInfo_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern void cuda_DeviceInfo_name(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int bufLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_DeviceInfo_majorVersion(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_DeviceInfo_minorVersion(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_DeviceInfo_multiProcessorCount(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong cuda_DeviceInfo_sharedMemPerBlock(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_DeviceInfo_queryMemory(
            IntPtr obj, out ulong totalMemory, out ulong freeMemory);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong cuda_DeviceInfo_freeMemory(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong cuda_DeviceInfo_totalMemory(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_DeviceInfo_supports(IntPtr obj, int featureSet);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_DeviceInfo_isCompatible(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_DeviceInfo_deviceID(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_DeviceInfo_canMapHostMemory(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_printCudaDeviceInfo(int device);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_printShortCudaDeviceInfo(int device);
        #endregion

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_registerPageLocked(IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_unregisterPageLocked(IntPtr m);

        #region Stream

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_Stream_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_Stream_new2(IntPtr s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_Stream_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_Stream_opAssign(IntPtr left, IntPtr right);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_Stream_queryIfComplete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_Stream_waitForCompletion(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_Stream_enqueueDownload_CudaMem(IntPtr obj, IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_Stream_enqueueDownload_Mat(IntPtr obj, IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_Stream_enqueueUpload_CudaMem(IntPtr obj, IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_Stream_enqueueUpload_Mat(IntPtr obj, IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_Stream_enqueueCopy(IntPtr obj, IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_Stream_enqueueMemSet(IntPtr obj, IntPtr src, Scalar val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_Stream_enqueueMemSet_WithMask(IntPtr obj, IntPtr src, Scalar val, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_Stream_enqueueConvert(
            IntPtr obj, IntPtr src, IntPtr dst, int dtype, double a, double b);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_Stream_enqueueHostCallback(
            IntPtr obj, IntPtr callback, IntPtr userData);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_Stream_Null();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_Stream_bool(IntPtr obj);

        #endregion

        #region CascadeClassifier_GPU

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_CascadeClassifier_GPU_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_CascadeClassifier_GPU_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_CascadeClassifier_GPU_new2(string filename);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_CascadeClassifier_GPU_empty(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_CascadeClassifier_GPU_load(IntPtr obj, string filename);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_CascadeClassifier_GPU_release(IntPtr obj);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_CascadeClassifier_GPU_detectMultiScale1(IntPtr obj,
            IntPtr image, IntPtr objectsBuf, double scaleFactor, int minNeighbors, Size minSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_CascadeClassifier_GPU_detectMultiScale2(IntPtr obj,
            IntPtr image, IntPtr objectsBuf, Size maxObjectSize, Size minSize, double scaleFactor,
            int minNeighbors);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_CascadeClassifier_GPU_findLargestObject_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_CascadeClassifier_GPU_findLargestObject_set(IntPtr obj, int value);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_CascadeClassifier_GPU_visualizeInPlace_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_CascadeClassifier_GPU_visualizeInPlace_set(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Size cuda_CascadeClassifier_GPU_getClassifierSize(IntPtr obj);
        
        #endregion

        #region HogDescriptor
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int HOGDescriptor_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr HOGDescriptor_new(Size win_size, Size block_size, Size block_stride, Size cell_size, 
            int nbins, double winSigma, double threshold_L2Hys, bool gamma_correction, int nlevels);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void HOGDescriptor_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong HOGDescriptor_getDescriptorSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong HOGDescriptor_getBlockHistogramSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int HOGDescriptor_checkDetectorSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double HOGDescriptor_getWinSigma(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void HOGDescriptor_setSVMDetector(IntPtr obj, IntPtr svmdetector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void HOGDescriptor_detect(IntPtr obj, IntPtr img, IntPtr found_locations, double hit_threshold, Size win_stride, Size padding);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void HOGDescriptor_detectMultiScale(IntPtr obj, IntPtr img, IntPtr found_locations, 
                                                   double hit_threshold, Size win_stride, Size padding, double scale, int group_threshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void HOGDescriptor_getDescriptors(IntPtr obj, IntPtr img, Size win_stride, IntPtr descriptors, [MarshalAs(UnmanagedType.I4)] DescriptorFormat descr_format);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Size HOGDescriptor_win_size_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Size HOGDescriptor_block_size_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Size HOGDescriptor_block_stride_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Size HOGDescriptor_cell_size_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int HOGDescriptor_nbins_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double HOGDescriptor_win_sigma_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double HOGDescriptor_threshold_L2hys_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int HOGDescriptor_nlevels_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int HOGDescriptor_gamma_correction_get(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void HOGDescriptor_win_size_set(IntPtr obj, Size value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void HOGDescriptor_block_size_set(IntPtr obj, Size value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void HOGDescriptor_block_stride_set(IntPtr obj, Size value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void HOGDescriptor_cell_size_set(IntPtr obj, Size value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void HOGDescriptor_nbins_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void HOGDescriptor_win_sigma_set(IntPtr obj, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void HOGDescriptor_threshold_L2hys_set(IntPtr obj, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void HOGDescriptor_nlevels_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void HOGDescriptor_gamma_correction_set(IntPtr obj, int value);
        #endregion

        #region MOG_GPU
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_MOG_GPU_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_MOG_GPU_new(int nmixtures);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_MOG_GPU_initialize(
            IntPtr obj, Size frameSize, int frameType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_MOG_GPU_operator(
            IntPtr obj, IntPtr frame, IntPtr fgmask, float learningRate, IntPtr stream);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_MOG_GPU_getBackgroundImage(
            IntPtr obj, IntPtr backgroundImage, IntPtr stream);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_MOG_GPU_release(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe int* cuda_MOG_GPU_history(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe float* cuda_MOG_GPU_varThreshold(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe float* cuda_MOG_GPU_backgroundRatio(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe float* cuda_MOG_GPU_noiseSigma(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_MOG2_GPU_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_MOG2_GPU_new(int nmixtures);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_MOG2_GPU_initialize(
            IntPtr obj, Size frameSize, int frameType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_MOG2_GPU_operator(
            IntPtr obj, IntPtr frame, IntPtr fgmask, float learningRate, IntPtr stream);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_MOG2_GPU_getBackgroundImage(
            IntPtr obj, IntPtr backgroundImage, IntPtr stream);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_MOG2_GPU_release(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe int* cuda_MOG2_GPU_history(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe float* cuda_MOG2_GPU_varThreshold(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe float* cuda_MOG2_GPU_backgroundRatio(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe float* cuda_MOG2_GPU_varThresholdGen(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe float* cuda_MOG2_GPU_fVarInit(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe float* cuda_MOG2_GPU_fVarMin(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe float* cuda_MOG2_GPU_fVarMax(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe float* cuda_MOG2_GPU_fCT(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_MOG2_GPU_bShadowDetection_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_MOG2_GPU_bShadowDetection_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe byte* cuda_MOG2_GPU_nShadowDetection(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe float* cuda_MOG2_GPU_fTau(IntPtr obj);

        #endregion

        #region StereoBM_GPU
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_StereoBM_GPU_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_StereoBM_GPU_new2(int preset, int ndisparities, int winSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_StereoBM_GPU_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_StereoBM_GPU_run1(IntPtr obj, IntPtr left, IntPtr right, IntPtr disparity);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_StereoBM_GPU_run2(IntPtr obj, IntPtr left, IntPtr right, IntPtr disparity, IntPtr stream);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_StereoBM_GPU_checkIfGpuCallReasonable();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe int* cuda_StereoBM_GPU_preset(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe int* cuda_StereoBM_GPU_ndisp(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe int* cuda_StereoBM_GPU_winSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe float* cuda_StereoBM_GPU_avergeTexThreshold(IntPtr obj);
        #endregion
    }
}

#endif