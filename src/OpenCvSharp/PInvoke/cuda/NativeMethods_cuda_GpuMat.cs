#if ENABLED_CUDA

using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    static partial class NativeMethods
    {
#region Init & Disposal
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_GpuMat_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_new2(int rows, int cols, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_new3(int rows, int cols, int type, IntPtr data, ulong step);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_new4(IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_new5(IntPtr gpumat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_new6(Size size, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_new7(Size size, int type, IntPtr data, ulong step);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_new8(int rows, int cols, int type, Scalar s);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_new9(IntPtr m, Range rowRange, Range colRange);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_new10(IntPtr m, Rect roi);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_new11(Size size, int type, Scalar s);
        
#endregion

#region Operators

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_opToMat(IntPtr src);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_opToGpuMat(IntPtr src);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_GpuMat_opAssign(IntPtr left, IntPtr right);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_opRange1(IntPtr src, Rect roi);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_opRange2(IntPtr src, Range rowRange, Range colRange);
        
#endregion

#region Fields

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_GpuMat_flags(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_GpuMat_rows(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_GpuMat_cols(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong cuda_GpuMat_step(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe byte* cuda_GpuMat_data(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_refcount(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_datastart(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_dataend(IntPtr obj);
#endregion

#region Methods
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_GpuMat_upload(IntPtr obj, IntPtr mat);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_GpuMat_download(IntPtr obj, IntPtr mat);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_row(IntPtr obj, int y);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_col(IntPtr obj, int x);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_rowRange(IntPtr obj, int startrow, int endrow);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_colRange(IntPtr obj, int startcol, int endcol);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_clone(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_GpuMat_copyTo1(IntPtr obj, IntPtr m);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_GpuMat_copyTo2(IntPtr obj, IntPtr m, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_GpuMat_convertTo(IntPtr obj, IntPtr m, int rtype, double alpha, double beta);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_GpuMat_assignTo(IntPtr obj, IntPtr m, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_setTo(IntPtr obj, Scalar s, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_reshape(IntPtr obj, int cn, int rows);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_GpuMat_create1(IntPtr obj, int rows, int cols, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_GpuMat_create2(IntPtr obj, Size size, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_GpuMat_release(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_GpuMat_swap(IntPtr obj, IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_GpuMat_locateROI(IntPtr obj, out Size wholeSize, out Point ofs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_GpuMat_adjustROI(IntPtr obj, int dtop, int dbottom, int dleft, int drightt);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_GpuMat_isContinuous(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong cuda_GpuMat_elemSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong cuda_GpuMat_elemSize1(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_GpuMat_type(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_GpuMat_depth(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_GpuMat_channels(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong cuda_GpuMat_step1(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Size cuda_GpuMat_size(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int cuda_GpuMat_empty(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe byte* cuda_GpuMat_ptr(IntPtr obj, int y);
#endregion

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_createContinuous1(
            int rows, int cols, int type, IntPtr gm);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr cuda_createContinuous2(
            int rows, int cols, int type);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void cuda_ensureSizeIsEnough(
            int rows, int cols, int type, IntPtr m);
    }
}

#endif