using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// Singular Value Decomposition class
    /// </summary>
    public class SVD : DisposableCvObject
    {
        private bool disposed;

        #region Init & Disposal
        /// <summary>
        /// the default constructor
        /// </summary>
        public SVD()
        {
            ptr = NativeMethods.core_SVD_new();
        }
        /// <summary>
        /// the constructor that performs SVD
        /// </summary>
        /// <param name="src"></param>
        /// <param name="flags"></param>
        public SVD(InputArray src, Flags flags = 0)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            ptr = NativeMethods.core_SVD_new(src.CvPtr, (int)flags);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (ptr != IntPtr.Zero)
                    {
                        NativeMethods.core_SVD_delete(ptr);
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// eigenvalues of the covariation matrix
        /// </summary>
        public Mat U
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("SVD");
                IntPtr ret = NativeMethods.core_SVD_u(ptr);
                return new Mat(ret);
            }
        }

        /// <summary>
        /// eigenvalues of the covariation matrix
        /// </summary>
        public Mat W
        {
            get
            {
                if(disposed)
                    throw new ObjectDisposedException("SVD");
                IntPtr ret = NativeMethods.core_SVD_w(ptr);
                return new Mat(ret);
            }
        }

        /// <summary>
        /// mean value subtracted before the projection and added after the back projection
        /// </summary>
        public Mat Vt
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("SVD");
                IntPtr ret = NativeMethods.core_SVD_vt(ptr);
                return new Mat(ret);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// the operator that performs SVD. The previously allocated SVD::u, SVD::w are SVD::vt are released.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public SVD Run(InputArray src, Flags flags = 0)
        {
            if (disposed)
                throw new ObjectDisposedException("SVD");
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            NativeMethods.core_SVD_operatorThis(ptr, src.CvPtr, (int)flags);
            return this;
        }

        /// <summary>
        /// performs back substitution, so that dst is the solution or pseudo-solution of m*dst = rhs, where m is the decomposed matrix
        /// </summary>
        /// <param name="rhs"></param>
        /// <param name="dst"></param>
        /// <returns></returns>
        public void BackSubst(InputArray rhs, OutputArray dst)
        {
            if (disposed)
                throw new ObjectDisposedException("SVD");
            if (rhs == null)
                throw new ArgumentNullException("rhs");
            if (dst == null)
                throw new ArgumentNullException("dst");
            rhs.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_SVD_backSubst(ptr, rhs.CvPtr, dst.CvPtr);
        }
        #endregion

        #region Static

        /// <summary>
        /// decomposes matrix and stores the results to user-provided matrices
        /// </summary>
        /// <param name="src"></param>
        /// <param name="w"></param>
        /// <param name="u"></param>
        /// <param name="vt"></param>
        /// <param name="flags"></param>
        public static void Compute(InputArray src, OutputArray w,
            OutputArray u, OutputArray vt, Flags flags = 0)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (w == null)
                throw new ArgumentNullException("w");
            if (u == null)
                throw new ArgumentNullException("u");
            if (vt == null)
                throw new ArgumentNullException("vt");
            src.ThrowIfDisposed();
            w.ThrowIfNotReady();
            u.ThrowIfNotReady();
            vt.ThrowIfNotReady();
            NativeMethods.core_SVD_static_compute(src.CvPtr, w.CvPtr, u.CvPtr, vt.CvPtr, (int)flags);
            w.Fix();
            u.Fix();
            vt.Fix();
        }

        /// <summary>
        /// computes singular values of a matrix
        /// </summary>
        /// <param name="src"></param>
        /// <param name="w"></param>
        /// <param name="flags"></param>
        public static void Compute(InputArray src, OutputArray w, Flags flags = 0)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (w == null)
                throw new ArgumentNullException("w");
            src.ThrowIfDisposed();
            w.ThrowIfNotReady();
            NativeMethods.core_SVD_static_compute(src.CvPtr, w.CvPtr, (int)flags);
            w.Fix();
        }

        /// <summary>
        /// performs back substitution
        /// </summary>
        /// <param name="w"></param>
        /// <param name="u"></param>
        /// <param name="vt"></param>
        /// <param name="rhs"></param>
        /// <param name="dst"></param>
        public static void BackSubst(InputArray w, InputArray u,
            InputArray vt, InputArray rhs, OutputArray dst)
        {
            if (w == null)
                throw new ArgumentNullException("w");
            if (u == null)
                throw new ArgumentNullException("u");
            if (vt == null)
                throw new ArgumentNullException("vt");
            if (rhs == null)
                throw new ArgumentNullException("rhs");
            if (dst == null)
                throw new ArgumentNullException("dst");
            w.ThrowIfDisposed();
            u.ThrowIfDisposed();
            vt.ThrowIfDisposed();
            rhs.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_SVD_static_backSubst(w.CvPtr, u.CvPtr, vt.CvPtr, rhs.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        /// <summary>
        /// finds dst = arg min_{|dst|=1} |m*dst|
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        public static void SolveZ(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_SVD_static_solveZ(src.CvPtr, dst.CvPtr);
            dst.Fix();
        }

        #endregion

#if LANG_JP
   	/// <summary>
	/// VDの操作フラグ
	/// </summary>
#else
        /// <summary>
        /// Operation flags for SVD
        /// </summary>
#endif
        [Flags]
        public enum Flags
        {
            /// <summary>
            /// 
            /// </summary>
            None = 0,

#if LANG_JP
		/// <summary>
		/// 計算中に行列Aの変更を行うことができる．このフラグの指定は処理速度を向上させる．
		/// </summary>
#else
            /// <summary>
            /// enables modification of matrix src1 during the operation. It speeds up the processing. 
            /// </summary>
#endif
            ModifyA = 1,

            /// <summary>
            /// indicates that only a vector of singular values `w` is to be processed, 
            /// while u and vt will be set to empty matrices
            /// </summary>
// ReSharper disable once InconsistentNaming
            NoUV = 2,

            /// <summary>
            /// when the matrix is not square, by default the algorithm produces u and 
            /// vt matrices of sufficiently large size for the further A reconstruction; 
            /// if, however, FULL_UV flag is specified, u and vt will be full-size square 
            /// orthogonal matrices.
            /// </summary>
// ReSharper disable once InconsistentNaming
            FullUV = 4,
        }
    }
}
