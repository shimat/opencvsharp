using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 特徴ベクトルのインデックスに対するバランスk-d木
    /// </summary>
#else
    /// <summary>
    /// A balanced kd-tree index of feature vectors
    /// </summary>
#endif
    public class CvFeatureTree : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Initialization and Disposal
#if LANG_JP
        /// <summary>
        /// 特徴ベクトルのツリーを作成する
        /// </summary>
        /// <param name="desc">d 次元特徴ベクトルの n × d 行列 (CV_32FC1 or CV_64FC1).</param>
#else
        /// <summary>
        /// Constructs a tree of feature vectors
        /// </summary>
        /// <param name="desc">n x d matrix of n d-dimensional feature vectors (CV_32FC1 or CV_64FC1). </param>
#endif
        public CvFeatureTree(CvMat desc)
        {
            if (desc == null)
                throw new ArgumentNullException("desc");
            
            ptr = NativeMethods.cvCreateFeatureTree(desc.CvPtr);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create CvFeatureTree");
        }

#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
#else
        /// <summary>
        /// Constructs from native pointer
        /// </summary>
        /// <param name="ptr">struct CvFeatureTree*</param>
#endif
        public CvFeatureTree(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        #region static initializers
        #region CreateFeatureTree
#if LANG_JP
        /// <summary>
        /// 特徴ベクトルのツリーを作成する
        /// </summary>
        /// <param name="desc">d 次元特徴ベクトルの n × d 行列（CV_32FC1 or CV_64FC1）.</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Constructs a tree of feature vectors
        /// </summary>
        /// <param name="desc">n x d matrix of n d-dimensional feature vectors (CV_32FC1 or CV_64FC1). </param>
        /// <returns></returns>
#endif
        public static CvFeatureTree CreateFeatureTree(CvMat desc)
        {
            return Cv.CreateFeatureTree(desc);
        }
        #endregion
        #region CreateKDTree
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="desc"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Constructs kd-tree from set of feature descriptors
        /// </summary>
        /// <param name="desc"></param>
        /// <returns></returns>
#endif
        public static CvFeatureTree CreateKDTree(CvMat desc)
        {
            return Cv.CreateKDTree(desc);
        }
        #endregion
        #region CreateSpillTree
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="raw_data"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Constructs spill-tree from set of feature descriptors
        /// </summary>
        /// <param name="raw_data"></param>
        /// <returns></returns>
#endif
        public static CvFeatureTree CreateSpillTree(CvMat raw_data)
        {
            return Cv.CreateSpillTree(raw_data);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="raw_data"></param>
        /// <param name="naive"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Constructs spill-tree from set of feature descriptors
        /// </summary>
        /// <param name="raw_data"></param>
        /// <param name="naive"></param>
        /// <returns></returns>
#endif
        public static CvFeatureTree CreateSpillTree(CvMat raw_data, int naive)
        {
            return Cv.CreateSpillTree(raw_data, naive);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="raw_data"></param>
        /// <param name="naive"></param>
        /// <param name="rho"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Constructs spill-tree from set of feature descriptors
        /// </summary>
        /// <param name="raw_data"></param>
        /// <param name="naive"></param>
        /// <param name="rho"></param>
        /// <returns></returns>
#endif
        public static CvFeatureTree CreateSpillTree(CvMat raw_data, int naive, double rho)
        {
            return Cv.CreateSpillTree(raw_data, naive, rho);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="raw_data"></param>
        /// <param name="naive"></param>
        /// <param name="rho"></param>
        /// <param name="tau"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Constructs spill-tree from set of feature descriptors
        /// </summary>
        /// <param name="raw_data"></param>
        /// <param name="naive"></param>
        /// <param name="rho"></param>
        /// <param name="tau"></param>
        /// <returns></returns>
#endif
        public static CvFeatureTree CreateSpillTree(CvMat raw_data, int naive, double rho, double tau)
        {
            return Cv.CreateSpillTree(raw_data, naive, rho, tau);
        }
        #endregion
        #endregion

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        if (ptr != IntPtr.Zero)
                            NativeMethods.cvReleaseFeatureTree(ptr);
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

        #region Methods
        #region FindFeatures
#if LANG_JP
        /// <summary>
        /// 最適ビン優先（Best-Bin-First）探索を用いて，与えられたベクトルのおおよその k 近傍値を求める
        /// </summary>
        /// <param name="desc">（行）ベクトルの m × d 行列．これらのベクトルの近傍値を探索する．</param>
        /// <param name="results">一致したベクトルの行インデックス （cvCreateFeatureTreeに引数として渡される行列を参照する） の集合．m × kの行列．k 近傍より遠い場合は，その列には -1 が入る．</param>
        /// <param name="dist">k 近傍値までの距離のm × k 行列.</param>
#else
        /// <summary>
        /// Finds approximate k nearest neighbors of given vectors using best-bin-first search.
        /// </summary>
        /// <param name="desc">m x d matrix of (row-)vectors to find the nearest neighbors of. </param>
        /// <param name="results">m x k set of row indices of matching vectors (referring to matrix passed to cvCreateFeatureTree). Contains -1 in some columns if fewer than k neighbors found. </param>
        /// <param name="dist">m x k matrix of distances to k nearest neighbors. </param>
#endif
        public void FindFeatures(CvMat desc, CvMat results, CvMat dist)
        {
            Cv.FindFeatures(this, desc, results, dist);
        }
#if LANG_JP
        /// <summary>
        /// 最適ビン優先（Best-Bin-First）探索を用いて，与えられたベクトルのおおよその k 近傍値を求める
        /// </summary>
        /// <param name="desc">（行）ベクトルの m × d 行列．これらのベクトルの近傍値を探索する．</param>
        /// <param name="results">一致したベクトルの行インデックス （cvCreateFeatureTreeに引数として渡される行列を参照する） の集合．m × kの行列．k 近傍より遠い場合は，その列には -1 が入る．</param>
        /// <param name="dist">k 近傍値までの距離のm × k 行列.</param>
        /// <param name="k">検出される近傍の数．</param>
#else
        /// <summary>
        /// Finds approximate k nearest neighbors of given vectors using best-bin-first search.
        /// </summary>
        /// <param name="desc">m x d matrix of (row-)vectors to find the nearest neighbors of. </param>
        /// <param name="results">m x k set of row indices of matching vectors (referring to matrix passed to cvCreateFeatureTree). Contains -1 in some columns if fewer than k neighbors found. </param>
        /// <param name="dist">m x k matrix of distances to k nearest neighbors. </param>
        /// <param name="k">The number of neighbors to find. </param>
#endif
        public void FindFeatures(CvMat desc, CvMat results, CvMat dist, int k)
        {
            Cv.FindFeatures(this, desc, results, dist, k);
        }
#if LANG_JP
        /// <summary>
        /// 最適ビン優先（Best-Bin-First）探索を用いて，与えられたベクトルのおおよその k 近傍値を求める
        /// </summary>
        /// <param name="desc">（行）ベクトルの m × d 行列．これらのベクトルの近傍値を探索する．</param>
        /// <param name="results">一致したベクトルの行インデックス （cvCreateFeatureTreeに引数として渡される行列を参照する） の集合．m × kの行列．k 近傍より遠い場合は，その列には -1 が入る．</param>
        /// <param name="dist">k 近傍値までの距離のm × k 行列.</param>
        /// <param name="k">検出される近傍の数．</param>
        /// <param name="emax">探索する葉の最大数．</param>
#else
        /// <summary>
        /// Finds approximate k nearest neighbors of given vectors using best-bin-first search.
        /// </summary>
        /// <param name="desc">m x d matrix of (row-)vectors to find the nearest neighbors of. </param>
        /// <param name="results">m x k set of row indices of matching vectors (referring to matrix passed to cvCreateFeatureTree). Contains -1 in some columns if fewer than k neighbors found. </param>
        /// <param name="dist">m x k matrix of distances to k nearest neighbors. </param>
        /// <param name="k">The number of neighbors to find. </param>
        /// <param name="emax">The maximum number of leaves to visit. </param>
#endif
        public void FindFeatures(CvMat desc, CvMat results, CvMat dist, int k, int emax)
        {
            Cv.FindFeatures(this, desc, results, dist, k, emax);
        }
        #endregion
        #region FindFeaturesBoxed
#if LANG_JP
        /// <summary>
        /// 与えられたk-d木上で直交領域探索を行う．
        /// </summary>
        /// <param name="bounds_min">各次元の最小値を与える 1×d あるいは d×1 のベクトル（CV_32FC1 or CV_64FC1）</param>
        /// <param name="bounds_max">各次元の最大値を与える 1×d あるいは d×1 のベクトル（CV_32FC1 or CV_64FC1）</param>
        /// <param name="result">出力行インデックス（cvCreateFeatureTreeに引数として渡される行列を参照する） の 1×m あるいは m×1 のベクトル（CV_32SC1）</param>
        /// <returns>求められたベクトル数</returns>
#else
        /// <summary>
        /// Performs orthogonal range seaching on the given kd-tree.
        /// </summary>
        /// <param name="bounds_min">1 x d or d x 1 vector (CV_32FC1 or CV_64FC1) giving minimum value for each dimension. </param>
        /// <param name="bounds_max">1 x d or d x 1 vector (CV_32FC1 or CV_64FC1) giving maximum value for each dimension. </param>
        /// <param name="result">1 x m or m x 1 vector (CV_32SC1) to contain output row indices (referring to matrix passed to cvCreateFeatureTree). </param>
        /// <returns>the number of such vectors found. </returns>
#endif
        public int FindFeaturesBoxed(CvMat bounds_min, CvMat bounds_max, CvMat result)
        {
            return Cv.FindFeaturesBoxed(this, bounds_min, bounds_max, result);
        }
        #endregion
        #endregion
    }
}