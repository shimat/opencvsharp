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
    /// 決定木クラス
    /// </summary>
#else
	/// <summary>
    /// Decision tree
    /// </summary>
#endif
	public class CvDTree : CvStatModel
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Constants
        /// <summary>
        /// sizeof(CvDTree)
        /// </summary>
		public static readonly int SizeOf = MLInvoke.CvDTree_sizeof();
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
        public CvDTree()
            : this(MLInvoke.CvDTree_construct())
        {
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
#else
        /// <summary>
        /// Initializes by pointer
        /// </summary>
#endif
        public CvDTree(IntPtr ptr)
        {
            this.ptr = ptr;
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
				        MLInvoke.CvDTree_destruct(ptr);
                        //ML.CvDTree_clear(ptr);
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
        /// 決定木を学習する
        /// </summary>
        /// <param name="train_data"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Trains decision tree
        /// </summary>
        /// <param name="trainData"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
        /// <returns></returns>
#endif
		public virtual bool Train(CvMat trainData, DTreeDataLayout tflag, CvMat responses)
        {
            return Train(trainData, tflag, responses, null, null, null, null, new CvDTreeParams());
        }
#if LANG_JP
        /// <summary>
        /// 決定木を学習する
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
        /// Trains decision tree
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
			CvMat varIdx, CvMat sampleIdx, CvMat varType, CvMat missingMask)
        {
            return Train(trainData, tflag, responses, varIdx, sampleIdx, varType, missingMask, new CvDTreeParams());
        }
#if LANG_JP
        /// <summary>
        /// 決定木を学習する
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
        /// Trains decision tree
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
			CvMat varIdx, CvMat sampleIdx, CvMat varType, CvMat missingMask, CvDTreeParams @params)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");

			if(@params == null)
				@params = new CvDTreeParams();

            IntPtr varIdxPtr = (varIdx == null) ? IntPtr.Zero : varIdx.CvPtr;
            IntPtr sampleIdxPtr = (sampleIdx == null) ? IntPtr.Zero : sampleIdx.CvPtr;
            IntPtr varTypePtr = (varType == null) ? IntPtr.Zero : varType.CvPtr;
            IntPtr missingMaskPtr = (missingMask == null) ? IntPtr.Zero : missingMask.CvPtr;

            return MLInvoke.CvDTree_train(
                ptr,
				trainData.CvPtr, 
				(int)tflag, 
				responses.CvPtr, 
				varIdxPtr,
                sampleIdxPtr,
                varTypePtr,
                missingMaskPtr, 
				@params.CvPtr
			);
        }

#if LANG_JP
        /// <summary>
        /// 決定木を学習する
        /// </summary>
        /// <param name="train_data"></param>
		/// <param name="subsample_idx"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Trains decision tree
        /// </summary>
        /// <param name="trainData"></param>
		/// <param name="subsampleIdx"></param>
        /// <returns></returns>
#endif
		public virtual bool Train(CvDTreeTrainData trainData, CvMat subsampleIdx)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");

            IntPtr subsampleIdxPtr = (subsampleIdx == null) ? IntPtr.Zero : subsampleIdx.CvPtr;

			return MLInvoke.CvDTree_train(ptr, trainData.CvPtr,  subsampleIdxPtr);
        }
		#endregion

        #region Predict
#if LANG_JP
        /// <summary>
        /// 入力ベクトルに対する決定木の葉ノードを返す
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Returns the leaf node of decision tree corresponding to the input vector
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
#endif
		public virtual CvDTreeNode Predict(CvMat sample)
		{
			return Predict(sample, null, false);
		}
#if LANG_JP
        /// <summary>
        /// 入力ベクトルに対する決定木の葉ノードを返す
        /// </summary>
        /// <param name="sample"></param>
		/// <param name="missing_data_mask"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Returns the leaf node of decision tree corresponding to the input vector
        /// </summary>
        /// <param name="sample"></param>
		/// <param name="missingDataMask"></param>
        /// <returns></returns>
#endif
		public virtual CvDTreeNode Predict(CvMat sample, CvMat missingDataMask)
		{
			return Predict(sample, missingDataMask, false);
		}
#if LANG_JP
        /// <summary>
        /// 入力ベクトルに対する決定木の葉ノードを返す
        /// </summary>
        /// <param name="sample"></param>
		/// <param name="missing_data_mask"></param>
        /// <param name="preprocessed_input">falseは通常の入力を意味する．true の場合，このメソッドは離散入力変数の全ての値があらかじめ， 0..&lt;num_of_categories_i&gt;-1 の範囲に正規化されていることを仮定する（決定木は内部的にはこのような正規化された表現を用いている）．これは決定木集合の高速な予測に役立つ．連続変数の入力変数に対しては，このフラグは利用されない．</param>
        /// <returns></returns>
#else
		/// <summary>
        /// Returns the leaf node of decision tree corresponding to the input vector
        /// </summary>
        /// <param name="sample"></param>
		/// <param name="missingDataMask"></param>
        /// <param name="preprocessedInput"></param>
        /// <returns></returns>
#endif
		public virtual CvDTreeNode Predict(CvMat sample, CvMat missingDataMask, bool preprocessedInput)
		{
			if (sample == null)
                throw new ArgumentNullException("sample");

            IntPtr missingDataMaskPtr = (missingDataMask == null) ? IntPtr.Zero : missingDataMask.CvPtr;

			IntPtr result = MLInvoke.CvDTree_predict(ptr, sample.CvPtr, missingDataMaskPtr, preprocessedInput);

			if(result == IntPtr.Zero)
				return null;
		    return new CvDTreeNode(result);
		}
		#endregion

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
		public virtual CvMat GetVarImportance()
		{
			IntPtr p = MLInvoke.CvDTree_get_var_importance(ptr);
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
		public CvDTreeNode GetRoot()
		{
			IntPtr p = MLInvoke.CvDTree_get_root(ptr);
			if(p == IntPtr.Zero)
				return null;
		    return new CvDTreeNode(p);
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
		public int GetPrunedTreeIdx()
		{
			return MLInvoke.CvDTree_get_pruned_tree_idx(ptr);
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
		public CvDTreeTrainData GetData()
		{
			IntPtr p = MLInvoke.CvDTree_get_data(ptr);
			if(p == IntPtr.Zero)
				return null;
		    return new CvDTreeTrainData(p);
		}

#if LANG_JP
        /// <summary>
        /// ファイルストレージからモデルを読み込む
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="node"></param>
#else
		/// <summary>
        /// Reads the model from file storage
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="node"></param>
#endif
		public override void Read(CvFileStorage fs, CvFileNode node)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            if (node == null)
                throw new ArgumentNullException("node");

			MLInvoke.CvDTree_read(ptr, fs.CvPtr, node.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// ファイルストレージからモデルを読み込む
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="node"></param>
		/// <param name="data"></param>
#else
		/// <summary>
        /// Reads the model from file storage
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="node"></param>
		/// <param name="data"></param>
#endif
		public virtual void Read(CvFileStorage fs, CvFileNode node, CvDTreeTrainData data)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            if (node == null)
                throw new ArgumentNullException("node");
			if (data == null)
                throw new ArgumentNullException("data");

			MLInvoke.CvDTree_read(ptr, fs.CvPtr, node.CvPtr, data.CvPtr);
        }

#if LANG_JP
        /// <summary>
        /// モデルをファイルに書き込む
        /// </summary>
        /// <param name="fs"></param>
#else
		/// <summary>
        /// Writes the model to file storage
        /// </summary>
        /// <param name="fs"></param>
#endif
		public virtual void Write(CvFileStorage fs)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            MLInvoke.CvDTree_write(ptr, fs.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// モデルをファイルに書き込む
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="name"></param>
#else
		/// <summary>
        /// Writes the model to file storage
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="name"></param>
#endif
		public override void Write(CvFileStorage fs, string name)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            MLInvoke.CvDTree_write(ptr, fs.CvPtr, name);
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
            MLInvoke.CvDTree_clear(ptr);
        }
		#endregion
        #endregion
    }
}
