/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.MachineLearning
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
	public class CvBoost : CvStatModel
	{
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Constants
        /// <summary>
        /// sizeof(CvBoost)
        /// </summary>
		public static readonly int SizeOf = MLInvoke.CvBoost_sizeof();
#pragma warning disable 1591
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
		public CvBoost()
		{
			ptr = MLInvoke.CvBoost_construct_default();
			NotifyMemoryPressure(SizeOf);
		}

#if LANG_JP
        /// <summary>
        /// 学習データを与えて初期化
        /// </summary>
        /// <param name="train_data"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
#else
		/// <summary>
        /// Training constructor
        /// </summary>
        /// <param name="trainData"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
#endif
		public CvBoost(CvMat trainData, DTreeDataLayout tflag, CvMat responses)
            : this(trainData, tflag, responses, null, null, null, null, new CvBoostParams())
		{    
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
#endif
		public CvBoost(CvMat trainData, DTreeDataLayout tflag, CvMat responses, 
			CvMat varIdx, CvMat sampleIdx, CvMat varType, CvMat missingMask )
            : this(trainData, tflag, responses, varIdx, sampleIdx, varType, missingMask, new CvBoostParams())
		{    
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
        /// <param name="params"></param>
#endif
		public CvBoost(CvMat trainData, DTreeDataLayout tflag, CvMat responses, 
			CvMat varIdx, CvMat sampleIdx, CvMat varType, CvMat missingMask, CvBoostParams @params )
		{    
			if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
			
			if(@params == null)
				@params = new CvBoostParams();

            IntPtr varIdxPtr = (varIdx == null) ? IntPtr.Zero : varIdx.CvPtr;
            IntPtr sampleIdxPtr = (sampleIdx == null) ? IntPtr.Zero : sampleIdx.CvPtr;
            IntPtr varTypePtr = (varType == null) ? IntPtr.Zero : varType.CvPtr;
            IntPtr missingMaskPtr = (missingMask == null) ? IntPtr.Zero : missingMask.CvPtr;

			ptr = MLInvoke.CvBoost_construct_training(
				trainData.CvPtr, 
				(int)tflag,
				responses.CvPtr,
				varIdxPtr, 
                sampleIdxPtr, 
                varTypePtr, 
                missingMaskPtr,
				@params.CvPtr
			);

			NotifyMemoryPressure(SizeOf);
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
                        MLInvoke.CvBoost_destruct(ptr);
                        //ML.CvBoost_clear(_ptr);
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
	
        #region Properties
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
		/// <returns></returns>
#else
		/// <summary>
        /// Trains boosted tree classifier
        /// </summary>
        /// <param name="trainData"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
		/// <returns></returns>
#endif
		public virtual bool Train(CvMat trainData, DTreeDataLayout tflag, CvMat responses)
		{    
			return Train(trainData, tflag, responses, null, null, null, null, new CvBoostParams(), false);
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
		/// <returns></returns>
#endif
		public virtual bool Train(CvMat trainData, DTreeDataLayout tflag, CvMat responses, 
			CvMat varIdx, CvMat sampleIdx, CvMat varType, CvMat missingMask )
		{    
			return Train(trainData, tflag, responses, varIdx, sampleIdx, varType, missingMask, new CvBoostParams(), false);
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
        /// <param name="params"></param>
		/// <returns></returns>
#endif
		public virtual bool Train(CvMat trainData, DTreeDataLayout tflag, CvMat responses, 
			CvMat varIdx, CvMat sampleIdx, CvMat varType, CvMat missingMask, 
			CvBoostParams @params )
		{    
			return Train(trainData, tflag, responses, varIdx, sampleIdx, varType, missingMask, @params, false);
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
		/// <param name="params"></param>
        /// <param name="update"></param>
		/// <returns></returns>
#endif
		public virtual bool Train(CvMat trainData, DTreeDataLayout tflag, CvMat responses, 
			CvMat varIdx, CvMat sampleIdx, CvMat varType, CvMat missingMask, 
			CvBoostParams @params, Boolean update )
		{    
			if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
			
			if(@params == null)
				@params = new CvBoostParams();

            IntPtr varIdxPtr = (varIdx == null) ? IntPtr.Zero : varIdx.CvPtr;
            IntPtr sampleIdxPtr = (sampleIdx == null) ? IntPtr.Zero : sampleIdx.CvPtr;
            IntPtr varTypePtr = (varType == null) ? IntPtr.Zero : varType.CvPtr;
            IntPtr missingMaskPtr = (missingMask == null) ? IntPtr.Zero : missingMask.CvPtr;

			return MLInvoke.CvBoost_train(
                ptr,
				trainData.CvPtr, 
				(int)tflag,
				responses.CvPtr,
				varIdxPtr, 
                sampleIdxPtr, 
                varTypePtr, 
                missingMaskPtr,
				@params.CvPtr,
				update
			);
		}
		#endregion

		#region Predict
#if LANG_JP
        /// <summary>
        /// 入力サンプルに対する応答を予測する
        /// </summary>
        /// <param name="sample">入力サンプル</param>
        /// <returns>重み付き投票に基づく出力クラスラベル</returns>
#else
		/// <summary>
        /// Predicts response for the input sample
        /// </summary>
        /// <param name="sample">The input sample. </param>
        /// <returns>the output class label based on the weighted voting. </returns>
#endif
		public float Predict(CvMat sample)
		{
			return Predict(sample, null, null, CvSlice.WholeSeq, false);
		}
#if LANG_JP
        /// <summary>
        /// 入力サンプルに対する応答を予測する
        /// </summary>
        /// <param name="sample">入力サンプル</param>
		/// <param name="missing">データ欠損マスク（オプション）．データ欠損を扱うためには，弱い決定木が代理分岐を含まなければならない．</param>
        /// <returns>重み付き投票に基づく出力クラスラベル</returns>
#else
		/// <summary>
        /// Predicts response for the input sample
        /// </summary>
        /// <param name="sample">The input sample. </param>
		/// <param name="missing">The optional mask of missing measurements. To handle missing measurements, the weak classifiers must include surrogate splits. </param>
        /// <returns>the output class label based on the weighted voting. </returns>
#endif
		public float Predict(CvMat sample, CvMat missing)
		{
			return Predict(sample, missing, null, CvSlice.WholeSeq, false);
		}
#if LANG_JP
        /// <summary>
        /// 入力サンプルに対する応答を予測する
        /// </summary>
        /// <param name="sample">入力サンプル</param>
		/// <param name="missing">データ欠損マスク（オプション）．データ欠損を扱うためには，弱い決定木が代理分岐を含まなければならない．</param>
		/// <param name="weak_responses">個々の弱い決定木からの応答の出力パラメータ（オプション）で，これは浮動小数点型ベクトルである．ベクトルの要素数は，slice 長と等しくなければならない．</param>
        /// <returns>重み付き投票に基づく出力クラスラベル</returns>
#else
        /// <summary>
        /// Predicts response for the input sample
        /// </summary>
        /// <param name="sample">The input sample. </param>
        /// <param name="missing">The optional mask of missing measurements. To handle missing measurements, the weak classifiers must include surrogate splits. </param>
        /// <param name="weakResponses">The optional output parameter, a floating-point vector, of responses from each individual weak classifier. The number of elements in the vector must be equal to the slice length. </param>
        /// <returns>the output class label based on the weighted voting. </returns>
#endif
        public float Predict(CvMat sample, CvMat missing, CvMat weakResponses)
        {
            return Predict(sample, missing, weakResponses, CvSlice.WholeSeq, false);
        }
#if LANG_JP
        /// <summary>
        /// 入力サンプルに対する応答を予測する
        /// </summary>
        /// <param name="sample">入力サンプル</param>
		/// <param name="missing">データ欠損マスク（オプション）．データ欠損を扱うためには，弱い決定木が代理分岐を含まなければならない．</param>
		/// <param name="weak_responses">個々の弱い決定木からの応答の出力パラメータ（オプション）で，これは浮動小数点型ベクトルである．ベクトルの要素数は，slice 長と等しくなければならない．</param>
		/// <param name="slice">予測に用いられる弱い決定木シーケンスの連続的部分集合（スライス）．デフォルトでは，全ての弱い分類器が用いられる．</param>
        /// <returns>重み付き投票に基づく出力クラスラベル</returns>
#else
		/// <summary>
        /// Predicts response for the input sample
        /// </summary>
        /// <param name="sample">The input sample. </param>
		/// <param name="missing">The optional mask of missing measurements. To handle missing measurements, the weak classifiers must include surrogate splits. </param>
		/// <param name="weakResponses">The optional output parameter, a floating-point vector, of responses from each individual weak classifier. The number of elements in the vector must be equal to the slice length. </param>
		/// <param name="slice">The continuous subset of the sequence of weak classifiers to be used for prediction. By default, all the weak classifiers are used. </param>
        /// <returns>the output class label based on the weighted voting. </returns>
#endif
		public float Predict(CvMat sample, CvMat missing, CvMat weakResponses, CvSlice slice)
		{
			return Predict(sample, missing, weakResponses, slice, false);
		}
#if LANG_JP
        /// <summary>
        /// 入力サンプルに対する応答を予測する
        /// </summary>
        /// <param name="sample">入力サンプル</param>
		/// <param name="missing">データ欠損マスク（オプション）．データ欠損を扱うためには，弱い決定木が代理分岐を含まなければならない．</param>
		/// <param name="weak_responses">個々の弱い決定木からの応答の出力パラメータ（オプション）で，これは浮動小数点型ベクトルである．ベクトルの要素数は，slice 長と等しくなければならない．</param>
		/// <param name="slice">予測に用いられる弱い決定木シーケンスの連続的部分集合（スライス）．デフォルトでは，全ての弱い分類器が用いられる．</param>
        /// <param name="raw_mode">falseは通常の入力を意味する．true の場合，このメソッドは離散入力変数の全ての値があらかじめ， 0..&lt;num_of_categories_i&gt;-1 の範囲に正規化されていることを仮定する（決定木は内部的にはこのような正規化された表現を用いている）．これは決定木集合の高速な予測に役立つ．連続変数の入力変数に対しては，このフラグは利用されない．</param>
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
        /// <returns>the output class label based on the weighted voting. </returns>
#endif
		public float Predict(CvMat sample, CvMat missing, CvMat weakResponses, CvSlice slice, bool rawMode)
		{
			if (sample == null)
                throw new ArgumentNullException("sample");

            IntPtr missingPtr = (missing == null) ? IntPtr.Zero : missing.CvPtr;
            IntPtr weakResponsesPtr = (weakResponses == null) ? IntPtr.Zero : weakResponses.CvPtr;

			return MLInvoke.CvBoost_predict(
                ptr,
                sample.CvPtr, 
                missingPtr, 
                weakResponsesPtr, 
                slice, 
                rawMode
            );
		}
		#endregion

        #region Other Boost Methods
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
		public virtual void Prune(CvSlice slice)
		{    
			MLInvoke.CvBoost_prune(ptr, slice);
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
            IntPtr p = MLInvoke.CvBoost_get_weights(ptr);
            if(p == IntPtr.Zero)
                return null;
            else
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
            IntPtr p = MLInvoke.CvBoost_get_subtree_weights(ptr);
            if(p == IntPtr.Zero)
                return null;
            else
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
            IntPtr p = MLInvoke.CvBoost_get_weak_response(ptr);
            if(p == IntPtr.Zero)
                return null;
            else
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
		public CvBoostParams GetParams()
		{
			IntPtr p = MLInvoke.CvBoost_get_params(ptr);
            if(p == IntPtr.Zero)
                return null;
            else
                throw new NotImplementedException();
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
            IntPtr p = MLInvoke.CvBoost_get_weak_predictors(ptr);
            if (p == IntPtr.Zero)
                return null;
            else
                return new CvSeq(p);
        }
        #endregion

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
            MLInvoke.CvBoost_clear(ptr);
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

            MLInvoke.CvBoost_write(ptr, storage.CvPtr, name);
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

            MLInvoke.CvBoost_read(ptr, storage.CvPtr, node.CvPtr);
        }
		#endregion
        #endregion
	}
}
