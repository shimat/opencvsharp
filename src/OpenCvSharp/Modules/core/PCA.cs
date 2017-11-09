using System;

namespace OpenCvSharp
{
    /// <summary>
    /// Principal Component Analysis
    /// </summary>
    public class PCA : DisposableCvObject
    {
        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        public PCA()
        {
            ptr = NativeMethods.core_PCA_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mean"></param>
        /// <param name="flags"></param>
        /// <param name="maxComponents"></param>
        public PCA(InputArray data, InputArray mean, Flags flags, int maxComponents = 0)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (mean == null)
                throw new ArgumentNullException(nameof(mean));
            data.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            ptr = NativeMethods.core_PCA_new2(data.CvPtr, mean.CvPtr, (int)flags, maxComponents);
            GC.KeepAlive(data);
            GC.KeepAlive(mean);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mean"></param>
        /// <param name="flags"></param>
        /// <param name="retainedVariance"></param>
        public PCA(InputArray data, InputArray mean, Flags flags, double retainedVariance)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (mean == null)
                throw new ArgumentNullException(nameof(mean));
            data.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            ptr = NativeMethods.core_PCA_new3(data.CvPtr, mean.CvPtr, (int)flags, retainedVariance);
            GC.KeepAlive(data);
            GC.KeepAlive(mean);
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.core_PCA_delete(ptr);
            base.DisposeUnmanaged();
        }

        #endregion

        #region Properties
        /// <summary>
        /// eigenvalues of the covariation matrix
        /// </summary>
        public Mat Eigenvectors
        {
            get
            {
                ThrowIfDisposed();
                IntPtr ret = NativeMethods.core_PCA_eigenvectors(ptr);
                GC.KeepAlive(this);
                return new Mat(ret);
            }
        }

        /// <summary>
        /// eigenvalues of the covariation matrix
        /// </summary>
        public Mat Eigenvalues
        {
            get
            {
                ThrowIfDisposed();
                IntPtr ret = NativeMethods.core_PCA_eigenvalues(ptr);
                GC.KeepAlive(this);
                return new Mat(ret);
            }
        }

        /// <summary>
        /// mean value subtracted before the projection and added after the back projection
        /// </summary>
        public Mat Mean
        {
            get
            {
                ThrowIfDisposed();
                IntPtr ret = NativeMethods.core_PCA_mean(ptr);
                GC.KeepAlive(this);
                return new Mat(ret);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// operator that performs PCA. The previously stored data, if any, is released
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mean"></param>
        /// <param name="flags"></param>
        /// <param name="maxComponents"></param>
        /// <returns></returns>
        public PCA Compute(InputArray data, InputArray mean, Flags flags, int maxComponents = 0)
        {
            ThrowIfDisposed();
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (mean == null)
                throw new ArgumentNullException(nameof(mean));
            data.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            NativeMethods.core_PCA_operatorThis(ptr, data.CvPtr, mean.CvPtr, (int)flags, maxComponents);
            GC.KeepAlive(data);
            GC.KeepAlive(mean);
            return this;
        }

        /// <summary>
        /// operator that performs PCA. The previously stored data, if any, is released
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mean"></param>
        /// <param name="flags"></param>
        /// <param name="retainedVariance"></param>
        /// <returns></returns>
        public PCA ComputeVar(InputArray data, InputArray mean, Flags flags, double retainedVariance)
        {
            ThrowIfDisposed();
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (mean == null)
                throw new ArgumentNullException(nameof(mean));
            data.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            NativeMethods.core_PCA_computeVar(ptr, data.CvPtr, mean.CvPtr, (int)flags, retainedVariance);
            GC.KeepAlive(data);
            GC.KeepAlive(mean);
            return this;
        }

        /// <summary>
        /// projects vector from the original space to the principal components subspace
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public Mat Project(InputArray vec)
        {
            ThrowIfDisposed();
            if (vec == null)
                throw new ArgumentNullException(nameof(vec));
            vec.ThrowIfDisposed();
            IntPtr ret = NativeMethods.core_PCA_project1(ptr, vec.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(vec);
            return new Mat(ret);
        }
        /// <summary>
        /// projects vector from the original space to the principal components subspace
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="result"></param>
        public void Project(InputArray vec, OutputArray result)
        {
            ThrowIfDisposed();
            if (vec == null)
                throw new ArgumentNullException(nameof(vec));
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            vec.ThrowIfDisposed();
            result.ThrowIfNotReady();
            NativeMethods.core_PCA_project2(ptr, vec.CvPtr, result.CvPtr);
            result.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(vec);
            GC.KeepAlive(result);
        }

        /// <summary>
        /// reconstructs the original vector from the projection
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public Mat BackProject(InputArray vec)
        {
            ThrowIfDisposed();
            if (vec == null)
                throw new ArgumentNullException(nameof(vec));
            vec.ThrowIfDisposed();
            IntPtr ret = NativeMethods.core_PCA_backProject1(ptr, vec.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(vec);
            return new Mat(ret);
        }
        /// <summary>
        /// reconstructs the original vector from the projection
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="result"></param>
        public void BackProject(InputArray vec, OutputArray result)
        {
            ThrowIfDisposed();
            if (vec == null)
                throw new ArgumentNullException(nameof(vec));
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            vec.ThrowIfDisposed();
            result.ThrowIfNotReady();
            NativeMethods.core_PCA_backProject2(ptr, vec.CvPtr, result.CvPtr);
            result.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(vec);
            GC.KeepAlive(result);
        }
        #endregion

#if LANG_JP
    /// <summary>
    /// PCAの操作フラグ
    /// </summary>
#else
        /// <summary>
        /// Flags for PCA operations
        /// </summary>
#endif
        [System.Flags]
        public enum Flags : int
        {
#if LANG_JP
        /// <summary>
        /// 行としてベクトルが保存される（つまり，あるベクトルの全ての要素は連続的に保存される）
        /// </summary>
#else
            /// <summary>
            /// The vectors are stored as rows (i.e. all the components of a certain vector are stored continously)
            /// </summary>
#endif
            DataAsRow = 0,


#if LANG_JP
        /// <summary>
        /// 列としてベクトルが保存される（つまり，あるベクトル成分に属する値は連続的に保存される）
        /// </summary>
#else
            /// <summary>
            /// The vectors are stored as columns (i.e. values of a certain vector component are stored continuously)
            /// </summary>
#endif
            DataAsCol = 1,


#if LANG_JP
        /// <summary>
        /// 事前に計算された平均ベクトルを用いる
        /// </summary>
#else
            /// <summary>
            /// Use pre-computed average vector
            /// </summary>
#endif
            UseAvg = 2,
        }
    }
}
