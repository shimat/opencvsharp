using System;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// 正規分布データに対するベイズ分類器クラス
    /// </summary>
#else
	/// <summary>
    /// Bayes classifier for normally distributed data
    /// </summary>
#endif
    public class CvNormalBayesClassifier : CvStatModel
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
        public CvNormalBayesClassifier()
        {
            ptr = NativeMethods.ml_CvNormalBayesClassifier_new1();
        }
#if LANG_JP
        /// <summary>
        /// 学習データを与えて初期化
        /// </summary>
        /// <param name="trainData">既知のサンプル (m*n)</param>
        /// <param name="responses">既知のサンプルのクラス (m*1)</param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Bayes classifier for normally distributed data
        /// </summary>
        /// <param name="trainData">Known samples (m*n)</param>
        /// <param name="responses">Classes for known samples (m*1)</param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <returns></returns>
#endif
		public CvNormalBayesClassifier(
            CvMat trainData, 
            CvMat responses, 
            CvMat varIdx = null, 
            CvMat sampleIdx = null)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();

            ptr = NativeMethods.ml_CvNormalBayesClassifier_new2_CvMat(
                trainData.CvPtr, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx));
        }
#if LANG_JP
        /// <summary>
        /// 学習データを与えて初期化
        /// </summary>
        /// <param name="trainData">既知のサンプル (m*n)</param>
        /// <param name="responses">既知のサンプルのクラス (m*1)</param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Bayes classifier for normally distributed data
        /// </summary>
        /// <param name="trainData">Known samples (m*n)</param>
        /// <param name="responses">Classes for known samples (m*1)</param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <returns></returns>
#endif
        public CvNormalBayesClassifier(
            Mat trainData,
            Mat responses,
            Mat varIdx = null,
            Mat sampleIdx = null)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();

            ptr = NativeMethods.ml_CvNormalBayesClassifier_new2_Mat(
                trainData.CvPtr, responses.CvPtr, Cv2.ToPtr(varIdx), Cv2.ToPtr(sampleIdx));
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
                        NativeMethods.ml_CvNormalBayesClassifier_delete(ptr);
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
        #endregion

        #region Methods
#if LANG_JP
		/// <summary>
        /// モデルの学習
        /// </summary>
        /// <param name="trainData">既知のサンプル (m*n)</param>
        /// <param name="responses">既知のサンプルのクラス (m*1)</param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="update">モデルを最初から学習する（false）か，新しい学習データを用いて更新する（true）か</param>
        /// <returns></returns>
#else
		/// <summary>
        /// Trains the model
        /// </summary>
        /// <param name="trainData">Known samples (m*n)</param>
        /// <param name="responses">Classes for known samples (m*1)</param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="update">Adds known samples to model(true) or makes a new one(false)</param>
        /// <returns></returns>
#endif
        public virtual bool Train(
            CvMat trainData, 
            CvMat responses, 
            CvMat varIdx, 
            CvMat sampleIdx, 
            bool update = false)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");

            return NativeMethods.ml_CvNormalBayesClassifier_train_CvMat(
                ptr, 
                trainData.CvPtr,
                responses.CvPtr,
                Cv2.ToPtr(varIdx), 
                Cv2.ToPtr(sampleIdx), 
                update ? 1 : 0) != 0;
        }

#if LANG_JP
		/// <summary>
        /// モデルの学習
        /// </summary>
        /// <param name="trainData">既知のサンプル (m*n)</param>
        /// <param name="responses">既知のサンプルのクラス (m*1)</param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="update">モデルを最初から学習する（false）か，新しい学習データを用いて更新する（true）か</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Trains the model
        /// </summary>
        /// <param name="trainData">Known samples (m*n)</param>
        /// <param name="responses">Classes for known samples (m*1)</param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="update">Adds known samples to model(true) or makes a new one(false)</param>
        /// <returns></returns>
#endif
        public virtual bool Train(
            Mat trainData,
            Mat responses,
            Mat varIdx,
            Mat sampleIdx,
            bool update = false)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");

            return NativeMethods.ml_CvNormalBayesClassifier_train_Mat(
                ptr,
                trainData.CvPtr,
                responses.CvPtr,
                Cv2.ToPtr(varIdx),
                Cv2.ToPtr(sampleIdx),
                update ? 1 : 0) != 0;
        }

#if LANG_JP
        /// <summary>
        /// サンプルに対する応答を予測する
        /// </summary>
        /// <param name="sample">未知のサンプル (l*n)</param>
        /// <param name="results">既知のサンプルのクラス (l*1)</param>
#else
        /// <summary>
        /// Predicts the response for sample(s)
        /// </summary>
        /// <param name="sample">Unkown samples (l*n)</param>
        /// <param name="results">Classes for known samples (l*1)</param>
#endif
        public virtual float Predict(CvMat sample, CvMat results = null)
        {
            if (sample == null)
                throw new ArgumentNullException("sample");
            sample.ThrowIfDisposed();

            return NativeMethods.ml_CvNormalBayesClassifier_predict_CvMat(
                ptr, 
                sample.CvPtr, 
                Cv2.ToPtr(results));
        }
#if LANG_JP
        /// <summary>
        /// サンプルに対する応答を予測する
        /// </summary>
        /// <param name="sample">未知のサンプル (l*n)</param>
        /// <param name="results">既知のサンプルのクラス (l*1)</param>
#else
        /// <summary>
        /// Predicts the response for sample(s)
        /// </summary>
        /// <param name="sample">Unkown samples (l*n)</param>
        /// <param name="results">Classes for known samples (l*1)</param>
#endif
        public virtual float Predict(Mat sample, Mat results = null)
        {
            if (sample == null)
                throw new ArgumentNullException("sample");
            sample.ThrowIfDisposed();

            return NativeMethods.ml_CvNormalBayesClassifier_predict_Mat(
                ptr,
                sample.CvPtr,
                Cv2.ToPtr(results));
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
            NativeMethods.ml_CvNormalBayesClassifier_clear(ptr);
        }

#if LANG_JP
        /// <summary>
        /// モデルをファイルに書き込む
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="name"></param>
#else
		/// <summary>
        /// Writes the model to file storage
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="name"></param>
#endif
		public override void Write(CvFileStorage storage, string name)
        {
            if (storage == null)
                throw new ArgumentNullException("storage");
			if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            NativeMethods.ml_CvNormalBayesClassifier_write(ptr, storage.CvPtr, name);
        }

#if LANG_JP
        /// <summary>
        /// ファイルストレージからモデルを読み込む
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="node"></param>
#else
		/// <summary>
        /// Reads the model from file storage
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="node"></param>
#endif
		public override void Read(CvFileStorage storage, CvFileNode node)
        {
            if (storage == null)
                throw new ArgumentNullException("storage");
            if (node == null)
                throw new ArgumentNullException("node");

            NativeMethods.ml_CvNormalBayesClassifier_read(ptr, storage.CvPtr, node.CvPtr);
        }
		#endregion
        #endregion
    }
}
