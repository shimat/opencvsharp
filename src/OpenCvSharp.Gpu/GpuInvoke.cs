/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.Utilities;

using CvLabel = System.UInt32;
using CvID = System.UInt32;

#pragma warning disable 1591

namespace OpenCvSharp.Gpu
{
    /// <summary>
    /// P/Invoke methods of OpenCV C++ GPU interface
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    internal static class GpuInvoke
    {
        /// <summary>
        /// DLL file name
        /// </summary>
        public const string DllExtern = "OpenCvSharpExternGpu";
        /// <summary>
        /// 
        /// </summary>
        internal static bool PInvokeSucceeded { get; private set; }

        #region Static constructor
        /// <summary>
        /// Static constructor
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        static GpuInvoke()
        {            
            TryPInvoke();
        }
#if LANG_JP
        /// <summary>
        /// PInvokeが正常に行えるかチェックする
        /// </summary>
#else
        /// <summary>
        /// Checks whether PInvoke functions can be called
        /// </summary>
#endif
        internal static void TryPInvoke()
        {
            if (_tried)
                return;
            _tried = true;

            // p/invokeで死ぬことが多発。標準添付のopencv_gpu220.dllだとおかしい。
            // とりあえずダメそうならフラグを折ってCvGpu.IsEnabledをfalseにしてごまかす。

            PInvokeSucceeded = true;
            try
            {
                getCudaEnabledDeviceCount();                
            }
            catch (DllNotFoundException )
            {
                //PInvokeHelper.DllImportError(e);
                PInvokeSucceeded = false;
            }
            catch (BadImageFormatException )
            {
                //PInvokeHelper.DllImportError(e);
                PInvokeSucceeded = false;
            }
            catch (TypeInitializationException )
            {
                //PInvokeHelper.DllImportError(e);
                PInvokeSucceeded = false;
            }
            catch (Exception)
            {
                //throw;
                PInvokeSucceeded = false;
            }
        }
        private static bool _tried = false;
        #endregion

        #region DllImport
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getCudaEnabledDeviceCount();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void setDevice(int device);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getDevice();

        /*
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void getDeviceName(int device, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buffer);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void getDeviceName(int device, [MarshalAs(UnmanagedType.LPStr)] byte[] buffer);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void getComputeCapability(int device, out int major, out int minor);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int getNumberOfSMs(int device);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void getGpuMemInfo(out ulong free, out ulong total);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int hasNativeDoubleSupport(int device);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int hasAtomicsSupport(int device);
        */

        #region GpuMat
        #region Init & Disposal
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GpuMat_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GpuMat_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GpuMat_new2(int rows, int cols, [MarshalAs(UnmanagedType.I4)] MatrixType type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GpuMat_new3(int rows, int cols, [MarshalAs(UnmanagedType.I4)] MatrixType type, IntPtr data, uint step);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GpuMat_new4(IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GpuMat_new5(IntPtr gpumat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GpuMat_new6(CvSize size, [MarshalAs(UnmanagedType.I4)] MatrixType type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GpuMat_new7(CvSize size, [MarshalAs(UnmanagedType.I4)] MatrixType type, IntPtr data, uint step);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GpuMat_new8(int rows, int cols, [MarshalAs(UnmanagedType.I4)] MatrixType type, CvScalar s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GpuMat_new9(IntPtr m, CvSlice rowRange, CvSlice colRange);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GpuMat_new10(IntPtr m, CvRect roi);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GpuMat_new11(CvSize size, [MarshalAs(UnmanagedType.I4)] MatrixType type, CvScalar s);
        #endregion
        #region Operators
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_opAssign1(IntPtr src, IntPtr gpumat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_opAssign2(IntPtr src, IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_opBinaryPlus(IntPtr src1, CvScalar scalar, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_opBinaryMinus(IntPtr src1, CvScalar scalar, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_opRange1(IntPtr src, CvRect roi, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_opRange2(IntPtr src, CvSlice rowRange, CvSlice colRange, IntPtr dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_opComplement(IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_opOr(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_opAnd(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_opXor(IntPtr src1, IntPtr src2, IntPtr dst);
        #endregion
        #region Fields
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GpuMat_flags(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GpuMat_rows(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GpuMat_cols(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GpuMat_step(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* GpuMat_data(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GpuMat_refcount(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GpuMat_datastart(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GpuMat_dataend(IntPtr obj);
        #endregion
        #region Methods
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_opGpuMat(IntPtr mat, IntPtr gpumat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_upload1(IntPtr obj, IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_upload2(IntPtr obj, IntPtr mem, IntPtr stream);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_opMat(IntPtr gpumat, IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_download1(IntPtr obj, IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_download2(IntPtr obj, IntPtr mem, IntPtr stream);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_row(IntPtr obj, int y, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_col(IntPtr obj, int x, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_rowRange(IntPtr obj, int startrow, int endrow, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_colRange(IntPtr obj, int startcol, int endcol, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_clone(IntPtr obj, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_copyTo1(IntPtr obj, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_copyTo2(IntPtr obj, IntPtr m, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_convertTo(IntPtr obj, IntPtr m, int rtype, double alpha, double beta);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_assignTo(IntPtr obj, IntPtr m, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_setTo(IntPtr obj, CvScalar s, IntPtr mask, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_reshape(IntPtr obj, int cn, int rows, IntPtr outValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_create1(IntPtr obj, int rows, int cols, [MarshalAs(UnmanagedType.I4)] MatrixType type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_create2(IntPtr obj, CvSize size, [MarshalAs(UnmanagedType.I4)] MatrixType type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_release(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_swap(IntPtr obj, IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_locateROI(IntPtr obj, out CvSize wholeSize, out CvPoint ofs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_adjustROI(IntPtr obj, int dtop, int dbottom, int dleft, int dright, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpuMat_t(IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GpuMat_isContinuous(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GpuMat_elemSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GpuMat_elemSize1(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern MatrixType GpuMat_type(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GpuMat_depth(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GpuMat_channels(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GpuMat_step1(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSize GpuMat_size(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GpuMat_empty(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* GpuMat_ptr(IntPtr obj, int y);
        #endregion
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
        public static extern void HOGDescriptor_getDescriptors(IntPtr obj, IntPtr img, CvSize win_stride, IntPtr descriptors, [MarshalAs(UnmanagedType.I4)] DescriptorFormat descr_format);

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
        public static extern uint StereoBM_GPU_sizeof();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr StereoBM_GPU_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr StereoBM_GPU_new2(int preset, int ndisparities, int winSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoBM_GPU_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoBM_GPU_run1(IntPtr obj, IntPtr left, IntPtr right, IntPtr disparity);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StereoBM_GPU_run2(IntPtr obj, IntPtr left, IntPtr right, IntPtr disparity, IntPtr stream);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StereoBM_GPU_checkIfGpuCallReasonable();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* StereoBM_GPU_preset(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* StereoBM_GPU_ndisp(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int* StereoBM_GPU_winSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float* StereoBM_GPU_avergeTexThreshold(IntPtr obj);
        #endregion
        #endregion
    }
}