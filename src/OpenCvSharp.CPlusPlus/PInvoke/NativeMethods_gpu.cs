using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable InconsistentNaming

    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_getCudaEnabledDeviceCount();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_setDevice(int device);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int gpu_getDevice();


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