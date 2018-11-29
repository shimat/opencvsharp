using System;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_new_byMat(IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_new_byMatExpr(IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_new_byScalar(Scalar val, out IntPtr handle);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_new_byDouble(IntPtr valPointer);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_new_byGpuMat(IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_new_byVectorOfMat(IntPtr vector);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_InputArray_delete(IntPtr ia);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_InputArray_delete_withScalar(IntPtr ia, IntPtr handle);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_getMat(IntPtr ia, int idx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_getMat_(IntPtr ia, int idx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_getUMat(IntPtr ia, int idx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_InputArray_getMatVector(IntPtr ia, IntPtr mv);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_InputArray_getUMatVector(IntPtr ia, IntPtr umv);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_InputArray_getGpuMatVector(IntPtr ia, IntPtr gpumv);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_getGpuMat(IntPtr ia);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_getFlags(IntPtr ia);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_getObj(IntPtr ia);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Size core_InputArray_getSz(IntPtr ia);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_kind(IntPtr ia);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_dims(IntPtr ia, int i);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_cols(IntPtr ia, int i);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_rows(IntPtr ia, int i);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Size core_InputArray_size(IntPtr ia, int i);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_sizend(IntPtr ia, int[] sz, int i);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_sameSize(IntPtr self, IntPtr target);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_total(IntPtr ia, int i);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_type(IntPtr ia, int i);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_depth(IntPtr ia, int i);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_channels(IntPtr ia, int i);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_isContinuous(IntPtr ia, int i);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_isSubmatrix(IntPtr ia, int i);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_empty(IntPtr ia);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_InputArray_copyTo1(IntPtr ia, IntPtr arr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_InputArray_copyTo2(IntPtr ia, IntPtr arr, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_offset(IntPtr ia, int i);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_InputArray_step(IntPtr ia, int i);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_isMat(IntPtr ia);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_isUMat(IntPtr ia);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_isMatVector(IntPtr ia);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_isUMatVector(IntPtr ia);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_isMatx(IntPtr ia);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_isVector(IntPtr ia);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_InputArray_isGpuMatVector(IntPtr ia);
    }
}