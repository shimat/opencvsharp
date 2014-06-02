using System;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// K近傍法モデルクラス
    /// </summary>
#else
	/// <summary>
    /// K nearest neighbors classifier
    /// </summary>
#endif
    public class CvKNearest : CvStatModel
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 既定の初期化
        /// </summary>
#else
		/// <summary>
        /// Default constructor
        /// </summary>
#endif
        public CvKNearest()
        {
			ptr = NativeMethods.ml_CvKNearest_new1();
        }

#if LANG_JP
        /// <summary>
        /// 学習データを与えて初期化
        /// </summary>
        /// <param name="trainData">既知のサンプル (m*n)</param>
        /// <param name="responses">既知のサンプルのクラス (m*1)</param>
        /// <param name="sampleIdx"></param>
        /// <param name="isRegression"></param>
        /// <param name="maxK">FindNearestに渡される近傍の最大値</param>
#else
		/// <summary>
        /// Training constructor
        /// </summary>
        /// <param name="trainData">Known samples (m*n)</param>
        /// <param name="responses">Classes for known samples (m*1)</param>
        /// <param name="sampleIdx"></param>
        /// <param name="isRegression"></param>
        /// <param name="maxK">Maximum number of neighbors to return</param>
#endif
		public CvKNearest(
            CvMat trainData, 
            CvMat responses, 
            CvMat sampleIdx = null, 
            bool isRegression = false, 
            int maxK = 32)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();

            ptr = NativeMethods.ml_CvKNearest_new2_CvMat(
                trainData.CvPtr, 
                responses.CvPtr,
                Cv2.ToPtr(sampleIdx), 
                isRegression ? 1 : 0, 
                maxK
            );
        }
#if LANG_JP
        /// <summary>
        /// 学習データを与えて初期化
        /// </summary>
        /// <param name="trainData">既知のサンプル (m*n)</param>
        /// <param name="responses">既知のサンプルのクラス (m*1)</param>
        /// <param name="sampleIdx"></param>
        /// <param name="isRegression"></param>
        /// <param name="maxK">FindNearestに渡される近傍の最大値</param>
#else
        /// <summary>
        /// Training constructor
        /// </summary>
        /// <param name="trainData">Known samples (m*n)</param>
        /// <param name="responses">Classes for known samples (m*1)</param>
        /// <param name="sampleIdx"></param>
        /// <param name="isRegression"></param>
        /// <param name="maxK">Maximum number of neighbors to return</param>
#endif
        public CvKNearest(
            Mat trainData,
            Mat responses,
            Mat sampleIdx = null,
            bool isRegression = false,
            int maxK = 32)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();

            ptr = NativeMethods.ml_CvKNearest_new2_Mat(
                trainData.CvPtr,
                responses.CvPtr,
                Cv2.ToPtr(sampleIdx),
                isRegression ? 1 : 0,
                maxK
            );
        }


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
                            NativeMethods.ml_CvKNearest_delete(ptr);
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
#if LANG_JP
        /// <summary>
        /// モデルの学習
        /// </summary>
        /// <param name="trainData">既知のサンプル (m*n)</param>
        /// <param name="responses">既知のサンプルのクラス (m*1)</param>
        /// <param name="sampleIdx"></param>
        /// <param name="isRegression"></param>
        /// <param name="maxK">FindNearestに渡される近傍の最大数</param>
        /// <param name="updateBase">モデルを始めから作り直す（false）か，新しい教師データを使って更新する（true）か</param>
        /// <returns></returns>
#else
		/// <summary>
        /// Trains the model
        /// </summary>
        /// <param name="trainData">Known samples (m*n)</param>
        /// <param name="responses">Classes for known samples (m*1)</param>
        /// <param name="sampleIdx"></param>
        /// <param name="isRegression"></param>
        /// <param name="maxK">Maximum number of neighbors to return</param>
        /// <param name="updateBase">Adds known samples to model(true) or makes a new one(false)</param>
        /// <returns></returns>
#endif
        public virtual bool Train(
            CvMat trainData, 
            CvMat responses, 
            CvMat sampleIdx = null,
            bool isRegression = false, 
            int maxK = 32,
            bool updateBase = false)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();

            return NativeMethods.ml_CvKNearest_train_CvMat(
                ptr,
                trainData.CvPtr,
                responses.CvPtr,
                Cv2.ToPtr(sampleIdx),
                isRegression ? 1 : 0,
                maxK, 
                updateBase ? 1 : 0
            ) != 0;
        }
#if LANG_JP
        /// <summary>
        /// モデルの学習
        /// </summary>
        /// <param name="trainData">既知のサンプル (m*n)</param>
        /// <param name="responses">既知のサンプルのクラス (m*1)</param>
        /// <param name="sampleIdx"></param>
        /// <param name="isRegression"></param>
        /// <param name="maxK">FindNearestに渡される近傍の最大数</param>
        /// <param name="updateBase">モデルを始めから作り直す（false）か，新しい教師データを使って更新する（true）か</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Trains the model
        /// </summary>
        /// <param name="trainData">Known samples (m*n)</param>
        /// <param name="responses">Classes for known samples (m*1)</param>
        /// <param name="sampleIdx"></param>
        /// <param name="isRegression"></param>
        /// <param name="maxK">Maximum number of neighbors to return</param>
        /// <param name="updateBase">Adds known samples to model(true) or makes a new one(false)</param>
        /// <returns></returns>
#endif
        public virtual bool Train(
            Mat trainData, 
            Mat responses, 
            Mat sampleIdx = null, 
            bool isRegression = false,
            int maxK = 32,
            bool updateBase = false)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();

            return NativeMethods.ml_CvKNearest_train_Mat(
                ptr,
                trainData.CvPtr,
                responses.CvPtr,
                Cv2.ToPtr(sampleIdx),
                isRegression ? 1 : 0,
                maxK,
                updateBase ? 1 : 0
            ) != 0;
        }

#if LANG_JP
        /// <summary>
        /// 入力ベクトルの近傍を探す
        /// </summary>
        /// <param name="samples">既知のサンプル (l*n)</param>
        /// <param name="k">探索する近傍の数の最大数</param>
        /// <param name="results"></param>
        /// <param name="neighbors"></param>
        /// <param name="neighborResponses">それぞれのサンプルの近傍 (l*k)</param>
        /// <param name="dist">サンプルから近傍までの距離</param>
        /// <returns></returns>
#else
		/// <summary>
        /// Finds the K nearest neighbors of samples
        /// </summary>
        /// <param name="samples">Known samples (l*n)</param>
        /// <param name="k">max neighbors to find</param>
        /// <param name="results"></param>
        /// <param name="neighbors"></param>
        /// <param name="neighborResponses">Neighbors for each samples (l*k)</param>
        /// <param name="dist">Distance from each sample to neighbors</param>
        /// <returns></returns>
#endif
        public virtual float FindNearest(
            CvMat samples, 
            int k, 
            CvMat results = null,
            float[][] neighbors = null,
            CvMat neighborResponses = null, 
            CvMat dist = null)
        {
            if (samples == null)
                throw new ArgumentNullException("samples");
                        
            if (neighbors == null)
            {
                return NativeMethods.ml_CvKNearest_find_nearest_CvMat(
                    ptr,
                    samples.CvPtr, 
                    k, 
                    Cv2.ToPtr(results), 
                    null, 
                    Cv2.ToPtr(neighborResponses),
                    Cv2.ToPtr(dist));
            }
		    using (var aa = new ArrayAddress2<Single>(neighbors))
		    {
                return NativeMethods.ml_CvKNearest_find_nearest_CvMat(
		            ptr,
		            samples.CvPtr,
		            k,
		            Cv2.ToPtr(results),
		            aa.Pointer,
		            Cv2.ToPtr(neighborResponses),
		            Cv2.ToPtr(dist));
		    }
        }

#if LANG_JP
        /// <summary>
        /// 入力ベクトルの近傍を探す
        /// </summary>
        /// <param name="samples">既知のサンプル (l*n)</param>
        /// <param name="k">探索する近傍の数の最大数</param>
        /// <param name="results"></param>
        /// <param name="neighborResponses">それぞれのサンプルの近傍 (l*k)</param>
        /// <param name="dists">サンプルから近傍までの距離</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds the K nearest neighbors of samples
        /// </summary>
        /// <param name="samples">Known samples (l*n)</param>
        /// <param name="k">max neighbors to find</param>
        /// <param name="results"></param>
        /// <param name="neighborResponses">Neighbors for each samples (l*k)</param>
        /// <param name="dists">Distance from each sample to neighbors</param>
        /// <returns></returns>
#endif
        public virtual float FindNearest(
            Mat samples, 
            int k, 
            Mat results,
            Mat neighborResponses, 
            Mat dists)
        {
            if (samples == null)
                throw new ArgumentNullException("samples");
            if (results == null)
                throw new ArgumentNullException("results");
            if (neighborResponses == null)
                throw new ArgumentNullException("neighborResponses");
            if (dists == null)
                throw new ArgumentNullException("dists");
            samples.ThrowIfDisposed();
            results.ThrowIfDisposed();
            neighborResponses.ThrowIfDisposed();
            dists.ThrowIfDisposed();

            return NativeMethods.ml_CvKNearest_find_nearest_Mat(
                ptr, samples.CvPtr, k, results.CvPtr,
                neighborResponses.CvPtr, dists.CvPtr);
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public int GetMaxK()
        {
            return NativeMethods.ml_CvKNearest_get_max_k(ptr);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public int GetVarCount() 
        {
            return NativeMethods.ml_CvKNearest_get_var_count(ptr);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public int GetSampleCount()
        {
            return NativeMethods.ml_CvKNearest_get_sample_count(ptr);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public bool IsRegression()
        {
            return NativeMethods.ml_CvKNearest_is_regression(ptr) != 0;
        }

		#region CvStatModel methods
#if LANG_JP
        /// <summary>
        /// メモリを解放し，モデルの状態をリセットする
        /// </summary>
#else
		/// <summary>
        /// Deallocates memory and resets the model state
        /// </summary>
#endif
        public override void Clear() 
        {
            NativeMethods.ml_CvKNearest_clear(ptr);
        }
		#endregion
        #endregion
    }
}
