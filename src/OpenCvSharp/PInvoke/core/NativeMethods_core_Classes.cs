using System;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        #region PCA
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_PCA_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_PCA_new2(IntPtr data, IntPtr mean, int flags,
            int maxComponents);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_PCA_new3(IntPtr data, IntPtr mean, int flags,
            double retainedVariance);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_PCA_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_PCA_operatorThis(IntPtr obj, IntPtr data, IntPtr mean,
            int flags, int maxComponents);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_PCA_computeVar(IntPtr obj, IntPtr data, IntPtr mean,
            int flags, double retainedVariance);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_PCA_project1(IntPtr obj, IntPtr vec);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_PCA_project2(IntPtr obj, IntPtr vec, IntPtr result);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_PCA_backProject1(IntPtr obj, IntPtr vec);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_PCA_backProject2(IntPtr obj, IntPtr vec, IntPtr result);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_PCA_eigenvectors(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_PCA_eigenvalues(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_PCA_mean(IntPtr obj);
        #endregion

        #region RNG
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_RNG_fill(ref ulong state, IntPtr mat, int distType, IntPtr a, IntPtr b, int saturateRange);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double core_RNG_gaussian(ref ulong state, double sigma);
        #endregion

        #region SVD
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_SVD_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_SVD_new2(IntPtr src, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_SVD_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_SVD_operatorThis(IntPtr obj, IntPtr src, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_SVD_backSubst(IntPtr obj, IntPtr rhs, IntPtr dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_SVD_static_compute1(IntPtr src, IntPtr w, IntPtr u, IntPtr vt, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_SVD_static_compute2(IntPtr src, IntPtr w, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_SVD_static_backSubst(IntPtr w, IntPtr u, IntPtr vt, IntPtr rhs, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_SVD_static_solveZ(IntPtr src, IntPtr dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_SVD_u(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_SVD_w(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_SVD_vt(IntPtr obj);
        #endregion
    }
}