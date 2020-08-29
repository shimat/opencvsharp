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
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_new_byMat(IntPtr mat, out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_new_byMatExpr(IntPtr mat, out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_new_byScalar(Scalar val, out IntPtr handle, out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_new_byDouble(IntPtr valPointer, out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_new_byVectorOfMat(IntPtr vector, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_new_byVecb(IntPtr vec, int n, out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_new_byVecs(IntPtr vec, int n, out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_new_byVecw(IntPtr vec, int n, out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_new_byVeci(IntPtr vec, int n, out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_new_byVecf(IntPtr vec, int n, out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_new_byVecd(IntPtr vec, int n, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_delete(IntPtr ia);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_delete_withScalar(IntPtr ia, IntPtr handle);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_getMat(IntPtr ia, int idx, out IntPtr returnValue);
        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern ExceptionStatus core_InputArray_getMat_(IntPtr ia, int idx, out IntPtr returnValue);
        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern IntPtr core_InputArray_getUMat(IntPtr ia, int idx);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_getMatVector(IntPtr ia, IntPtr mv);
        //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        //public static extern void core_InputArray_getUMatVector(IntPtr ia, IntPtr umv);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_getFlags(IntPtr ia, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_getObj(IntPtr ia, out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_getSz(IntPtr ia, out Size returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_kind(IntPtr ia, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_dims(IntPtr ia, int i, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_cols(IntPtr ia, int i, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_rows(IntPtr ia, int i, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_size(IntPtr ia, int i, out Size returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_sizend(IntPtr ia, int[] sz, int i, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_sameSize(IntPtr self, IntPtr target, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_total(IntPtr ia, int i, out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_type(IntPtr ia, int i, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_depth(IntPtr ia, int i, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_channels(IntPtr ia, int i, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_isContinuous(IntPtr ia, int i, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_isSubmatrix(IntPtr ia, int i, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_empty(IntPtr ia, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_copyTo1(IntPtr ia, IntPtr arr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_copyTo2(IntPtr ia, IntPtr arr, IntPtr mask);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_offset(IntPtr ia, int i, out IntPtr returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_step(IntPtr ia, int i, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_isMat(IntPtr ia, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_isUMat(IntPtr ia, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_isMatVector(IntPtr ia, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_isUMatVector(IntPtr ia, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_isMatx(IntPtr ia, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_isVector(IntPtr ia, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus core_InputArray_isGpuMatVector(IntPtr ia, out int returnValue);
    }
}