using System;

namespace OpenCvSharp.CPlusPlus
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
        private bool disposed;

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
		{
		    ptr = NativeMethods.ml_CvDTree_new();
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
        internal CvDTree(IntPtr ptr)
        {
            this.ptr = ptr;
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
                        NativeMethods.ml_CvDTree_delete(ptr);
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

		#region Train
#if LANG_JP
        /// <summary>
        /// 決定木を学習する
        /// </summary>
        /// <param name="trainData"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="varType"></param>
        /// <param name="missingMask"></param>
        /// <param name="param"></param>
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
        /// <param name="param"></param>
        /// <returns></returns>
#endif
		public virtual bool Train(
            CvMat trainData,
            DTreeDataLayout tflag,
            CvMat responses, 
			CvMat varIdx, 
            CvMat sampleIdx, 
            CvMat varType, 
            CvMat missingMask, 
            CvDTreeParams param)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();

			if(param == null)
				param = new CvDTreeParams();

            return NativeMethods.ml_CvDTree_train1(
                ptr,
				trainData.CvPtr, 
				(int)tflag, 
				responses.CvPtr, 
				Cv2.ToPtr(varIdx),
                Cv2.ToPtr(sampleIdx),
                Cv2.ToPtr(varType),
                Cv2.ToPtr(missingMask), 
				param.CvPtr) != 0;
        }

#if LANG_JP
        /// <summary>
        /// 決定木を学習する
        /// </summary>
        /// <param name="trainData"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="varType"></param>
        /// <param name="missingMask"></param>
        /// <param name="param"></param>
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
        /// <param name="param"></param>
        /// <returns></returns>
#endif
        public virtual bool Train(
            Mat trainData,
            DTreeDataLayout tflag,
            Mat responses,
            Mat varIdx,
            Mat sampleIdx,
            Mat varType,
            Mat missingMask,
            CvDTreeParams param)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();

            if (param == null)
                param = new CvDTreeParams();

            return NativeMethods.ml_CvDTree_train_Mat(
                ptr,
                trainData.CvPtr,
                (int)tflag,
                responses.CvPtr,
                Cv2.ToPtr(varIdx),
                Cv2.ToPtr(sampleIdx),
                Cv2.ToPtr(varType),
                Cv2.ToPtr(missingMask),
                param.CvPtr) != 0;
        }

#if LANG_JP
        /// <summary>
        /// 決定木を学習する
        /// </summary>
        /// <param name="trainData"></param>
        /// <param name="subsampleIdx"></param>
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
            if (subsampleIdx == null)
                throw new ArgumentNullException("subsampleIdx");

            return NativeMethods.ml_CvDTree_train2(
                ptr, trainData.CvPtr, subsampleIdx.CvPtr) != 0;
        }

#if LANG_JP
        /// <summary>
        /// 決定木を学習する
        /// </summary>
        /// <param name="trainData"></param>
		/// <param name="param"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Trains decision tree
        /// </summary>
        /// <param name="trainData"></param>
        /// <param name="param"></param>
        /// <returns></returns>
#endif
        public virtual bool Train(CvMLData trainData, CvDTreeParams param)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (param == null)
                param = new CvDTreeParams();
            return NativeMethods.ml_CvDTree_train3(
                ptr, trainData.CvPtr, param.CvPtr) != 0;
        }

		#endregion

        #region Predict
#if LANG_JP
        /// <summary>
        /// 入力ベクトルに対する決定木の葉ノードを返す
        /// </summary>
        /// <param name="sample"></param>
        /// <param name="missingDataMask"></param>
        /// <param name="preprocessedInput">falseは通常の入力を意味する．true の場合，このメソッドは離散入力変数の全ての値があらかじめ， 0..&lt;num_of_categories_i&gt;-1 の範囲に正規化されていることを仮定する（決定木は内部的にはこのような正規化された表現を用いている）．これは決定木集合の高速な予測に役立つ．連続変数の入力変数に対しては，このフラグは利用されない．</param>
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
		public virtual CvDTreeNode Predict(
            CvMat sample, 
            CvMat missingDataMask = null,
            bool preprocessedInput = false)
		{
			if (sample == null)
                throw new ArgumentNullException("sample");
            sample.ThrowIfDisposed();

            IntPtr result = NativeMethods.ml_CvDTree_predict_CvMat(
                ptr, sample.CvPtr, Cv2.ToPtr(missingDataMask), preprocessedInput ? 1 : 0);

			if(result == IntPtr.Zero)
				return null;
		    return new CvDTreeNode(result);
		}

#if LANG_JP
        /// <summary>
        /// 入力ベクトルに対する決定木の葉ノードを返す
        /// </summary>
        /// <param name="sample"></param>
        /// <param name="missingDataMask"></param>
        /// <param name="preprocessedInput">falseは通常の入力を意味する．true の場合，このメソッドは離散入力変数の全ての値があらかじめ， 0..&lt;num_of_categories_i&gt;-1 の範囲に正規化されていることを仮定する（決定木は内部的にはこのような正規化された表現を用いている）．これは決定木集合の高速な予測に役立つ．連続変数の入力変数に対しては，このフラグは利用されない．</param>
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
        public virtual CvDTreeNode Predict(
            Mat sample,
            Mat missingDataMask = null,
            bool preprocessedInput = false)
        {
            if (sample == null)
                throw new ArgumentNullException("sample");
            sample.ThrowIfDisposed();

            IntPtr result = NativeMethods.ml_CvDTree_predict_Mat(
                ptr, sample.CvPtr, Cv2.ToPtr(missingDataMask), preprocessedInput ? 1 : 0);

            if (result == IntPtr.Zero)
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
		public virtual Mat GetVarImportance()
		{
            IntPtr p = NativeMethods.ml_CvDTree_getVarImportance(ptr);
			if (p == IntPtr.Zero)
				return null;
		    return new Mat(p);
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
            IntPtr p = NativeMethods.ml_CvDTree_get_root(ptr);
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
            return NativeMethods.ml_CvDTree_get_pruned_tree_idx(ptr);
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
            IntPtr p = NativeMethods.ml_CvDTree_get_data(ptr);
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

            NativeMethods.ml_CvDTree_read(ptr, fs.CvPtr, node.CvPtr);
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

            NativeMethods.ml_CvDTree_read(ptr, fs.CvPtr, node.CvPtr, data.CvPtr);
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
            NativeMethods.ml_CvDTree_write(ptr, fs.CvPtr);
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
            NativeMethods.ml_CvDTree_write(ptr, fs.CvPtr, name);
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
            NativeMethods.ml_CvDTree_clear(ptr);
        }
		#endregion
        #endregion
    }
}
