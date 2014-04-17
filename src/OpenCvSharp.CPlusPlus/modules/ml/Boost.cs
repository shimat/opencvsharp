/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// ブーストされた分類器クラス
    /// </summary>
#else
	/// <summary>
    /// Boosted tree classifier
    /// </summary>
#endif
	public class Boost : StatModel
	{
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Constants
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
        // Boosting type
		public const BoostType DISCRETE = BoostType.Discrete;
		public const BoostType REAL = BoostType.Real;
		public const BoostType LOGIT = BoostType.Logit;
		public const BoostType GENTLE = BoostType.Gentle;
        // Splitting criteria
		public const BoostSplitCriteria DEFAULT = BoostSplitCriteria.Default;
		public const BoostSplitCriteria GINI = BoostSplitCriteria.Gini;
		public const BoostSplitCriteria MISCLASS = BoostSplitCriteria.Misclass;
		public const BoostSplitCriteria SQERR = BoostSplitCriteria.Sqerr;
// ReSharper restore InconsistentNaming
#pragma warning restore 1591
        #endregion

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 既定のコンストラクタ
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
		public Boost()
		{
			ptr = NativeMethods.ml_Boost_new();
		}

#if LANG_JP
        /// <summary>
        /// 学習データを与えて初期化
        /// </summary>
        /// <param name="train_data"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
		/// <param name="var_idx"></param>
        /// <param name="sample_idx"></param>
        /// <param name="var_type"></param>
        /// <param name="missing_mask"></param>
        /// <param name="params"></param>
#else
		/// <summary>
        /// Training constructor
        /// </summary>
        /// <param name="trainData"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
		/// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="varType"></param>
        /// <param name="missingMask"></param>
        /// <param name="param"></param>
#endif
		public Boost(
            CvMat trainData, 
            DTreeDataLayout tflag, 
            CvMat responses, 
			CvMat varIdx = null, 
            CvMat sampleIdx = null, 
            CvMat varType = null, 
            CvMat missingMask = null, 
            BoostParams param = null )
		{    
			if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();

            if (param == null)
                param = new BoostParams();

			ptr = NativeMethods.ml_Boost_new_CvMat(
				trainData.CvPtr, 
				(int)tflag,
				responses.CvPtr,
				Cv2.ToPtr(varIdx), 
                Cv2.ToPtr(sampleIdx), 
                Cv2.ToPtr(varType), 
                Cv2.ToPtr(missingMask),
				param.CvPtr
			);
		}

#if LANG_JP
        /// <summary>
        /// 学習データを与えて初期化
        /// </summary>
        /// <param name="train_data"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
		/// <param name="var_idx"></param>
        /// <param name="sample_idx"></param>
        /// <param name="var_type"></param>
        /// <param name="missing_mask"></param>
        /// <param name="params"></param>
#else
        /// <summary>
        /// Training constructor
        /// </summary>
        /// <param name="trainData"></param>
        /// <param name="tflag"></param>
        /// <param name="responses"></param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="varType"></param>
        /// <param name="missingMask"></param>
        /// <param name="param"></param>
#endif
        public Boost(
            Mat trainData, 
            DTreeDataLayout tflag, 
            Mat responses,
            Mat varIdx = null,
            Mat sampleIdx = null,
            Mat varType = null,
            Mat missingMask = null,
            BoostParams param = null)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();

            if (param == null)
                param = new BoostParams();

            ptr = NativeMethods.ml_Boost_new_Mat(
                trainData.CvPtr,
                (int)tflag,
                responses.CvPtr,
                Cv2.ToPtr(varIdx),
                Cv2.ToPtr(sampleIdx),
                Cv2.ToPtr(varType),
                Cv2.ToPtr(missingMask),
                param.CvPtr
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
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        if(ptr != IntPtr.Zero)
                            NativeMethods.ml_Boost_delete(ptr);
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
		#endregion
	
		#region Methods
		#region Train
#if LANG_JP
        /// <summary>
        /// ブーストされた分類器の学習
        /// </summary>
        /// <param name="train_data"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
		/// <param name="var_idx"></param>
        /// <param name="sample_idx"></param>
        /// <param name="var_type"></param>
        /// <param name="missing_mask"></param>
        /// <param name="params"></param>
		/// <param name="update"></param>
		/// <returns></returns>
#else
		/// <summary>
        /// Trains boosted tree classifier
        /// </summary>
        /// <param name="trainData"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
		/// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="varType"></param>
        /// <param name="missingMask"></param>
		/// <param name="param"></param>
        /// <param name="update"></param>
		/// <returns></returns>
#endif
		public virtual bool Train(
            CvMat trainData,
            DTreeDataLayout tflag, 
            CvMat responses,
            CvMat varIdx = null,
            CvMat sampleIdx = null,
            CvMat varType = null,
            CvMat missingMask = null, 
			BoostParams param = null,
            bool update = false )
		{    
			if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();
			
			if(param == null)
				param = new BoostParams();

            int ret = NativeMethods.ml_Boost_train_CvMat(
                ptr,
                trainData.CvPtr,
                (int)tflag,
                responses.CvPtr,
                Cv2.ToPtr(varIdx),
                Cv2.ToPtr(sampleIdx),
                Cv2.ToPtr(varType),
                Cv2.ToPtr(missingMask),
                param.CvPtr,
                update ? 1 : 0);
		    return ret != 0;
		}

#if LANG_JP
        /// <summary>
        /// ブーストされた分類器の学習
        /// </summary>
        /// <param name="train_data"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
		/// <param name="var_idx"></param>
        /// <param name="sample_idx"></param>
        /// <param name="var_type"></param>
        /// <param name="missing_mask"></param>
        /// <param name="params"></param>
		/// <param name="update"></param>
		/// <returns></returns>
#else
        /// <summary>
        /// Trains boosted tree classifier
        /// </summary>
        /// <param name="trainData"></param>
        /// <param name="tflag"></param>
        /// <param name="responses"></param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="varType"></param>
        /// <param name="missingMask"></param>
        /// <param name="param"></param>
        /// <param name="update"></param>
        /// <returns></returns>
#endif
        public virtual bool Train(
            Mat trainData,
            DTreeDataLayout tflag,
            Mat responses,
            Mat varIdx = null,
            Mat sampleIdx = null,
            Mat varType = null,
            Mat missingMask = null,
            BoostParams param = null,
            bool update = false)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();

            if (param == null)
                param = new BoostParams();

            int ret = NativeMethods.ml_Boost_train_Mat(
                ptr,
                trainData.CvPtr,
                (int)tflag,
                responses.CvPtr,
                Cv2.ToPtr(varIdx),
                Cv2.ToPtr(sampleIdx),
                Cv2.ToPtr(varType),
                Cv2.ToPtr(missingMask),
                param.CvPtr,
                update ? 1 : 0);
            return ret != 0;
        }
		#endregion

		#region Predict
#if LANG_JP
        /// <summary>
        /// 入力サンプルに対する応答を予測する
        /// </summary>
        /// <param name="sample">入力サンプル</param>
		/// <param name="missing">データ欠損マスク（オプション）．データ欠損を扱うためには，弱い決定木が代理分岐を含まなければならない．</param>
		/// <param name="weakResponses">個々の弱い決定木からの応答の出力パラメータ（オプション）で，これは浮動小数点型ベクトルである．ベクトルの要素数は，slice 長と等しくなければならない．</param>
		/// <param name="slice">予測に用いられる弱い決定木シーケンスの連続的部分集合（スライス）．デフォルトでは，全ての弱い分類器が用いられる．</param>
        /// <param name="raw_mode">falseは通常の入力を意味する．true の場合，このメソッドは離散入力変数の全ての値があらかじめ， 0..&lt;num_of_categories_i&gt;-1 の範囲に正規化されていることを仮定する（決定木は内部的にはこのような正規化された表現を用いている）．これは決定木集合の高速な予測に役立つ．連続変数の入力変数に対しては，このフラグは利用されない．</param>
        /// <param name="returnSum"></param>
        /// <returns>重み付き投票に基づく出力クラスラベル</returns>
#else
        /// <summary>
	    /// Predicts response for the input sample
	    /// </summary>
	    /// <param name="sample">The input sample. </param>
	    /// <param name="missing">The optional mask of missing measurements. To handle missing measurements, the weak classifiers must include surrogate splits. </param>
	    /// <param name="weakResponses">The optional output parameter, a floating-point vector, of responses from each individual weak classifier. The number of elements in the vector must be equal to the slice length. </param>
	    /// <param name="slice">The continuous subset of the sequence of weak classifiers to be used for prediction. By default, all the weak classifiers are used. </param>
	    /// <param name="rawMode">The last parameter is normally set to false that implies a regular input. If it is true, the method assumes that all the values of the discrete input variables have been already normalized to 0..&lt;num_of_categoriesi&gt;-1 ranges. (as the decision tree uses such normalized representation internally). It is useful for faster prediction with tree ensembles. For ordered input variables the flag is not used. </param>
	    /// <param name="returnSum"></param>
	    /// <returns>the output class label based on the weighted voting. </returns>
#endif
		public float Predict(
            CvMat sample, 
            CvMat missing = null, 
            CvMat weakResponses = null, 
            CvSlice? slice = null, 
            bool rawMode = false,
            bool returnSum = false)
		{
			if (sample == null)
                throw new ArgumentNullException("sample");

	        CvSlice slice0 = slice.GetValueOrDefault(CvSlice.WholeSeq);
			return NativeMethods.ml_Boost_predict_CvMat(
                ptr,
                sample.CvPtr, 
                Cv2.ToPtr(missing), 
                Cv2.ToPtr(weakResponses), 
                slice0, 
                rawMode ? 1 : 0,
                returnSum ? 1 : 0);
		}

#if LANG_JP
        /// <summary>
        /// 入力サンプルに対する応答を予測する
        /// </summary>
        /// <param name="sample">入力サンプル</param>
		/// <param name="missing">データ欠損マスク（オプション）．データ欠損を扱うためには，弱い決定木が代理分岐を含まなければならない．</param>
		/// <param name="slice">予測に用いられる弱い決定木シーケンスの連続的部分集合（スライス）．デフォルトでは，全ての弱い分類器が用いられる．</param>
        /// <param name="raw_mode">falseは通常の入力を意味する．true の場合，このメソッドは離散入力変数の全ての値があらかじめ， 0..&lt;num_of_categories_i&gt;-1 の範囲に正規化されていることを仮定する（決定木は内部的にはこのような正規化された表現を用いている）．これは決定木集合の高速な予測に役立つ．連続変数の入力変数に対しては，このフラグは利用されない．</param>
        /// <param name="returnSum"></param>
        /// <returns>重み付き投票に基づく出力クラスラベル</returns>
#else
        /// <summary>
        /// Predicts response for the input sample
        /// </summary>
        /// <param name="sample">The input sample. </param>
        /// <param name="missing">The optional mask of missing measurements. To handle missing measurements, the weak classifiers must include surrogate splits. </param>
        /// <param name="slice">The continuous subset of the sequence of weak classifiers to be used for prediction. By default, all the weak classifiers are used. </param>
        /// <param name="rawMode">The last parameter is normally set to false that implies a regular input. If it is true, the method assumes that all the values of the discrete input variables have been already normalized to 0..&lt;num_of_categoriesi&gt;-1 ranges. (as the decision tree uses such normalized representation internally). It is useful for faster prediction with tree ensembles. For ordered input variables the flag is not used. </param>
        /// <param name="returnSum"></param>
        /// <returns>the output class label based on the weighted voting. </returns>
#endif
        public float Predict(
            Mat sample,
            Mat missing = null,
            Range? slice = null,
            bool rawMode = false,
            bool returnSum = false)
        {
            if (sample == null)
                throw new ArgumentNullException("sample");

            CvSlice slice0 = slice.GetValueOrDefault(CvSlice.WholeSeq);
            return NativeMethods.ml_Boost_predict_Mat(
                ptr,
                sample.CvPtr,
                Cv2.ToPtr(missing),
                slice0,
                rawMode ? 1 : 0,
                returnSum ? 1 : 0);
        }
		#endregion

#if LANG_JP
        /// <summary>
        /// 指定された弱い決定木を削除する
        /// </summary>
        /// <param name="slice"></param>
#else
        /// <summary>
        /// Removes specified weak classifiers
        /// </summary>
        /// <param name="slice"></param>
#endif
		public virtual void Prune(Range slice)
		{    
			NativeMethods.ml_Boost_prune(ptr, slice);
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
		public CvMat GetWeights()
		{
            IntPtr p = NativeMethods.ml_Boost_get_weights(ptr);
            if(p == IntPtr.Zero)
                return null;
            return new CvMat(p, false);
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
		public CvMat GetSubtreeWeights()
		{
            IntPtr p = NativeMethods.ml_Boost_get_subtree_weights(ptr);
            if(p == IntPtr.Zero)
                return null;
            return new CvMat(p, false);
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
		public CvMat GetWeakResponse()
		{
            IntPtr p = NativeMethods.ml_Boost_get_weak_response(ptr);
            if(p == IntPtr.Zero)
                return null;
            return new CvMat(p, false);
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
		public BoostParams GetParams()
		{
			IntPtr p = NativeMethods.ml_Boost_get_params(ptr);
            if(p == IntPtr.Zero)
                return null;
		    return new BoostParams(p, false);
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
        public CvSeq GetWeakPredictors()
        {
            IntPtr p = NativeMethods.ml_Boost_get_weak_predictors(ptr);
            if (p == IntPtr.Zero)
                return null;
            return new CvSeq(p);
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
            NativeMethods.ml_Boost_clear(ptr);
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

            NativeMethods.ml_Boost_write(ptr, storage.CvPtr, name);
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

            NativeMethods.ml_Boost_read(ptr, storage.CvPtr, node.CvPtr);
        }
		#endregion
        #endregion
	}
}
