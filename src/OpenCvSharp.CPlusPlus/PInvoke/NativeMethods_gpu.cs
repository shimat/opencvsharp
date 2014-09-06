using System;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable InconsistentNaming

    static partial class NativeMethods
    {
        #region Device
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_getCudaEnabledDeviceCount();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_setDevice(int device);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_getDevice();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_resetDevice();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_deviceSupports(int feature_set);

        // TargetArchs
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_TargetArchs_builtWith(int feature_set);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_TargetArchs_has(int major, int minor);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_TargetArchs_hasPtx(int major, int minor);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_TargetArchs_hasBin(int major, int minor);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_TargetArchs_hasEqualOrLessPtx(int major, int minor);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_TargetArchs_hasEqualOrGreater(int major, int minor);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_TargetArchs_hasEqualOrGreaterPtx(int major, int minor);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_TargetArchs_hasEqualOrGreaterBin(int major, int minor);

        // DeviceInfo
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gpu_DeviceInfo_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gpu_DeviceInfo_new2(int deviceId);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_DeviceInfo_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void gpu_DeviceInfo_name(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int bufLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_DeviceInfo_majorVersion(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_DeviceInfo_minorVersion(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_DeviceInfo_multiProcessorCount(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong gpu_DeviceInfo_sharedMemPerBlock(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_DeviceInfo_queryMemory(
            IntPtr obj, out ulong totalMemory, out ulong freeMemory);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong gpu_DeviceInfo_freeMemory(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong gpu_DeviceInfo_totalMemory(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_DeviceInfo_supports(IntPtr obj, int featureSet);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_DeviceInfo_isCompatible(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_DeviceInfo_deviceID(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_printCudaDeviceInfo(int device);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_printShortCudaDeviceInfo(int device);
        #endregion

        #region CudaMem

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_registerPageLocked(IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_unregisterPageLocked(IntPtr m);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gpu_CudaMem_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gpu_CudaMem_new2(IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gpu_CudaMem_new3(int rows, int cols, int type, int allocType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gpu_CudaMem_new4(IntPtr m, int allocType);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_CudaMem_delete(IntPtr m);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_CudaMem_opAssign(IntPtr left, IntPtr right);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gpu_CudaMem_clone(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_CudaMem_create(IntPtr obj, int rows, int cols, int type, int allocType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_CudaMem_release(IntPtr obj);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gpu_CudaMem_createMatHeader(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gpu_CudaMem_createGpuMatHeader(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_CudaMem_canMapHostMemory();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_CudaMem_isContinuous(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong gpu_CudaMem_elemSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong gpu_CudaMem_elemSize1(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_CudaMem_type(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_CudaMem_depth(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_CudaMem_channels(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong gpu_CudaMem_step1(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize gpu_CudaMem_size(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_CudaMem_empty(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_CudaMem_flags(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_CudaMem_rows(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_CudaMem_cols(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong gpu_CudaMem_step(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* gpu_CudaMem_data(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* gpu_CudaMem_refcount(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* gpu_CudaMem_datastart(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* gpu_CudaMem_dataend(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_CudaMem_alloc_type(IntPtr obj);

        #endregion

        #region Stream

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gpu_Stream_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gpu_Stream_new2(IntPtr s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_Stream_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_Stream_opAssign(IntPtr left, IntPtr right);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_Stream_queryIfComplete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_Stream_waitForCompletion(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_Stream_enqueueDownload_CudaMem(IntPtr obj, IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_Stream_enqueueDownload_Mat(IntPtr obj, IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_Stream_enqueueUpload_CudaMem(IntPtr obj, IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_Stream_enqueueUpload_Mat(IntPtr obj, IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_Stream_enqueueCopy(IntPtr obj, IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_Stream_enqueueMemSet(IntPtr obj, IntPtr src, CvScalar val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_Stream_enqueueMemSet_WithMask(IntPtr obj, IntPtr src, CvScalar val, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_Stream_enqueueConvert(
            IntPtr obj, IntPtr src, IntPtr dst, int dtype, double a, double b);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_Stream_enqueueHostCallback(
            IntPtr obj, IntPtr callback, IntPtr userData);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gpu_Stream_Null();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_Stream_bool(IntPtr obj);

        #endregion

        #region CascadeClassifier_GPU

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_CascadeClassifier_GPU_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gpu_CascadeClassifier_GPU_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gpu_CascadeClassifier_GPU_new2(string filename);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_CascadeClassifier_GPU_empty(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_CascadeClassifier_GPU_load(IntPtr obj, string filename);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_CascadeClassifier_GPU_release(IntPtr obj);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_CascadeClassifier_GPU_detectMultiScale1(IntPtr obj,
            IntPtr image, IntPtr objectsBuf, double scaleFactor, int minNeighbors, CvSize minSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_CascadeClassifier_GPU_detectMultiScale2(IntPtr obj,
            IntPtr image, IntPtr objectsBuf, CvSize maxObjectSize, CvSize minSize, double scaleFactor,
            int minNeighbors);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_CascadeClassifier_GPU_findLargestObject_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_CascadeClassifier_GPU_findLargestObject_set(IntPtr obj, int value);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_CascadeClassifier_GPU_visualizeInPlace_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_CascadeClassifier_GPU_visualizeInPlace_set(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize gpu_CascadeClassifier_GPU_getClassifierSize(IntPtr obj);
        
        #endregion

        #region HogDescriptor
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HOGDescriptor_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr HOGDescriptor_new( CvSize win_size, CvSize block_size, CvSize block_stride, CvSize cell_size, 
	        int nbins, double winSigma, double threshold_L2Hys, bool gamma_correction, int nlevels);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong HOGDescriptor_getDescriptorSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong HOGDescriptor_getBlockHistogramSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HOGDescriptor_checkDetectorSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double HOGDescriptor_getWinSigma(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_setSVMDetector(IntPtr obj, IntPtr svmdetector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_detect(IntPtr obj, IntPtr img, IntPtr found_locations, double hit_threshold, CvSize win_stride, CvSize padding);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_detectMultiScale(IntPtr obj, IntPtr img, IntPtr found_locations, 
										           double hit_threshold, CvSize win_stride, CvSize padding, double scale, int group_threshold);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_getDescriptors(IntPtr obj, IntPtr img, CvSize win_stride, IntPtr descriptors, [MarshalAs(UnmanagedType.I4)] Gpu.DescriptorFormat descr_format);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize HOGDescriptor_win_size_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize HOGDescriptor_block_size_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize HOGDescriptor_block_stride_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize HOGDescriptor_cell_size_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HOGDescriptor_nbins_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double HOGDescriptor_win_sigma_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double HOGDescriptor_threshold_L2hys_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HOGDescriptor_nlevels_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HOGDescriptor_gamma_correction_get(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_win_size_set(IntPtr obj, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_block_size_set(IntPtr obj, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_block_stride_set(IntPtr obj, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_cell_size_set(IntPtr obj, CvSize value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_nbins_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_win_sigma_set(IntPtr obj, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_threshold_L2hys_set(IntPtr obj, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_nlevels_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HOGDescriptor_gamma_correction_set(IntPtr obj, int value);
        #endregion

        #region StereoBM_GPU
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gpu_StereoBM_GPU_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr gpu_StereoBM_GPU_new2(int preset, int ndisparities, int winSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_StereoBM_GPU_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_StereoBM_GPU_run1(IntPtr obj, IntPtr left, IntPtr right, IntPtr disparity);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_StereoBM_GPU_run2(IntPtr obj, IntPtr left, IntPtr right, IntPtr disparity, IntPtr stream);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_StereoBM_GPU_checkIfGpuCallReasonable();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* gpu_StereoBM_GPU_preset(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* gpu_StereoBM_GPU_ndisp(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* gpu_StereoBM_GPU_winSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* gpu_StereoBM_GPU_avergeTexThreshold(IntPtr obj);
        #endregion
    }
}