using System;

namespace OpenCvSharp
{
    /// <summary>
    /// Singular Value Decomposition class
    /// </summary>
    public class SVD : DisposableCvObject
    {
        #region Init & Disposal

        /// <summary>
        /// the default constructor
        /// </summary>
        public SVD()
        {
            ptr = NativeMethods.core_SVD_new1();
        }
        /// <summary>
        /// the constructor that performs SVD
        /// </summary>
        /// <param name="src"></param>
        /// <param name="flags"></param>
        public SVD(InputArray src, Flags flags = 0)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();
            ptr = NativeMethods.core_SVD_new2(src.CvPtr, (int)flags);
            GC.KeepAlive(src);
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.core_SVD_delete(ptr);
            base.DisposeUnmanaged();
        }

        #endregion

        #region Methods

        /// <summary>
        /// eigenvalues of the covariation matrix
        /// </summary>
        public Mat U()
        {

            ThrowIfDisposed();
            IntPtr ret = NativeMethods.core_SVD_u(ptr);
            GC.KeepAlive(this);
            return new Mat(ret);
        }

        /// <summary>
        /// eigenvalues of the covariation matrix
        /// </summary>
        public Mat W()
        {
            ThrowIfDisposed();
            IntPtr ret = NativeMethods.core_SVD_w(ptr);
            GC.KeepAlive(this);
            return new Mat(ret);
        }

        /// <summary>
        /// mean value subtracted before the projection and added after the back projection
        /// </summary>
        public Mat Vt()
        {
            ThrowIfDisposed();
            IntPtr ret = NativeMethods.core_SVD_vt(ptr);
            GC.KeepAlive(this);
            return new Mat(ret);
        }

        /// <summary>
        /// the operator that performs SVD. The previously allocated SVD::u, SVD::w are SVD::vt are released.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public SVD Run(InputArray src, Flags flags = 0)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();
            NativeMethods.core_SVD_operatorThis(ptr, src.CvPtr, (int)flags);
            GC.KeepAlive(src);
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
            ThrowIfDisposed();
            if (rhs == null)
                throw new ArgumentNullException(nameof(rhs));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            rhs.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_SVD_backSubst(ptr, rhs.CvPtr, dst.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(rhs);
            GC.KeepAlive(dst);
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
                throw new ArgumentNullException(nameof(src));
            if (w == null)
                throw new ArgumentNullException(nameof(w));
            if (u == null)
                throw new ArgumentNullException(nameof(u));
            if (vt == null)
                throw new ArgumentNullException(nameof(vt));
            src.ThrowIfDisposed();
            w.ThrowIfNotReady();
            u.ThrowIfNotReady();
            vt.ThrowIfNotReady();
            NativeMethods.core_SVD_static_compute1(src.CvPtr, w.CvPtr, u.CvPtr, vt.CvPtr, (int)flags);
            w.Fix();
            u.Fix();
            vt.Fix();
            GC.KeepAlive(src);
            GC.KeepAlive(w);
            GC.KeepAlive(u);
            GC.KeepAlive(vt);
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
                throw new ArgumentNullException(nameof(src));
            if (w == null)
                throw new ArgumentNullException(nameof(w));
            src.ThrowIfDisposed();
            w.ThrowIfNotReady();
            NativeMethods.core_SVD_static_compute2(src.CvPtr, w.CvPtr, (int)flags);
            w.Fix();
            GC.KeepAlive(src);
            GC.KeepAlive(w);
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
                throw new ArgumentNullException(nameof(w));
            if (u == null)
                throw new ArgumentNullException(nameof(u));
            if (vt == null)
                throw new ArgumentNullException(nameof(vt));
            if (rhs == null)
                throw new ArgumentNullException(nameof(rhs));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            w.ThrowIfDisposed();
            u.ThrowIfDisposed();
            vt.ThrowIfDisposed();
            rhs.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_SVD_static_backSubst(w.CvPtr, u.CvPtr, vt.CvPtr, rhs.CvPtr, dst.CvPtr);
            dst.Fix();
            GC.KeepAlive(w);
            GC.KeepAlive(u);
            GC.KeepAlive(vt);
            GC.KeepAlive(rhs);
            GC.KeepAlive(dst);
        }

        /// <summary>
        /// finds dst = arg min_{|dst|=1} |m*dst|
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        public static void SolveZ(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_SVD_static_solveZ(src.CvPtr, dst.CvPtr);
            dst.Fix();
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
        }

        #endregion

#if LANG_JP
       /// <summary>
       /// SVDの操作フラグ
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
