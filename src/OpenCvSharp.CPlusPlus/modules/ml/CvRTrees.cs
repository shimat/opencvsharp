using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// ランダムツリークラス
    /// </summary>
#else
	/// <summary>
    /// Random Trees
    /// </summary>
#endif
	public class CvRTrees : CvStatModel
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
        public CvRTrees()
        {
            ptr = NativeMethods.ml_CvRTrees_new();
        }

        /// <summary>
        /// Initializes by pointer
        /// </summary>
        internal CvRTrees(IntPtr ptr)
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
                        if (ptr != IntPtr.Zero)
                            NativeMethods.ml_CvRTrees_delete(ptr);
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
        #endregion

		#region Methods
		#region Train
#if LANG_JP
        /// <summary>
        /// ランダムツリーモデルの学習
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
        /// Trains Random Trees model
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
            CvMat varIdx = null,
            CvMat sampleIdx = null,
            CvMat varType = null,
            CvMat missingMask = null, 
            CvRTParams param = null)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");

			if(param == null)
				param = new CvRTParams();

            return NativeMethods.ml_CvRTrees_train_CvMat(
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
        /// ランダムツリーモデルの学習
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
        /// Trains Random Trees model
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
            Mat varIdx = null,
            Mat sampleIdx = null,
            Mat varType = null,
            Mat missingMask = null,
            CvRTParams param = null)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");

            if (param == null)
                param = new CvRTParams();

            return NativeMethods.ml_CvRTrees_train_CvMat(
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
		#endregion

		#region Predict
#if LANG_JP
        /// <summary>
        /// 入力サンプルに対する出力を予測する
        /// </summary>
        /// <param name="sample"></param>
		/// <param name="missing"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Predicts the output for the input sample
        /// </summary>
        /// <param name="sample"></param>
		/// <param name="missing"></param>
        /// <returns></returns>
#endif
        public virtual double Predict(CvMat sample, CvMat missing = null)
		{
			if (sample == null)
                throw new ArgumentNullException("sample");
            sample.ThrowIfDisposed();

            return NativeMethods.ml_CvRTrees_predict_CvMat(
                ptr, sample.CvPtr, Cv2.ToPtr(missing));
		}
#if LANG_JP
        /// <summary>
        /// 入力サンプルに対する出力を予測する
        /// </summary>
        /// <param name="sample"></param>
		/// <param name="missing"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Predicts the output for the input sample
        /// </summary>
        /// <param name="sample"></param>
        /// <param name="missing"></param>
        /// <returns></returns>
#endif
        public virtual double Predict(Mat sample, Mat missing = null)
        {
            if (sample == null)
                throw new ArgumentNullException("sample");
            sample.ThrowIfDisposed();

            return NativeMethods.ml_CvRTrees_predict_CvMat(
                ptr, sample.CvPtr, Cv2.ToPtr(missing));
        }
		#endregion

        #region PredictProb
#if LANG_JP
        /// <summary>
        /// 入力サンプルに対する出力を予測する
        /// </summary>
        /// <param name="sample"></param>
		/// <param name="missing"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Predicts the output for the input sample
        /// </summary>
        /// <param name="sample"></param>
        /// <param name="missing"></param>
        /// <returns></returns>
#endif
        public virtual double PredictProb(CvMat sample, CvMat missing = null)
        {
            if (sample == null)
                throw new ArgumentNullException("sample");
            sample.ThrowIfDisposed();

            return NativeMethods.ml_CvRTrees_predict_prob_CvMat(
                ptr, sample.CvPtr, Cv2.ToPtr(missing));
        }
#if LANG_JP
        /// <summary>
        /// 入力サンプルに対する出力を予測する
        /// </summary>
        /// <param name="sample"></param>
		/// <param name="missing"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Predicts the output for the input sample
        /// </summary>
        /// <param name="sample"></param>
        /// <param name="missing"></param>
        /// <returns></returns>
#endif
        public virtual double PredictProb(Mat sample, Mat missing = null)
        {
            if (sample == null)
                throw new ArgumentNullException("sample");
            sample.ThrowIfDisposed();

            return NativeMethods.ml_CvRTrees_predict_prob_CvMat(
                ptr, sample.CvPtr, Cv2.ToPtr(missing));
        }
        #endregion

#if LANG_JP
        /// <summary>
        /// 変数の重要度を表す配列を取得する
        /// </summary>
        /// <returns></returns>
#else
		/// <summary>
        /// Retrieves the variable importance array
        /// </summary>
        /// <returns></returns>
#endif
		public virtual Mat GetVarImportance()
		{
            IntPtr p = NativeMethods.ml_CvRTrees_getVarImportance(ptr);
			if(p == IntPtr.Zero)
				return null;
		    return new Mat(p);
		}

#if LANG_JP
        /// <summary>
        /// 二つの学習サンプル間の近さを取り出す
        /// </summary>
        /// <param name="sample1"></param>
        /// <param name="sample2"></param>
        /// <param name="missing1"></param>
        /// <param name="missing2"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Retrieves proximity measure between two training samples
        /// </summary>
        /// <param name="sample1"></param>
        /// <param name="sample2"></param>
        /// <param name="missing1"></param>
        /// <param name="missing2"></param>
        /// <returns></returns>
#endif
        public virtual float GetProximity(
            CvMat sample1, CvMat sample2, 
            CvMat missing1 = null, CvMat missing2 = null)
        {
            if (sample1 == null)
                throw new ArgumentNullException("sample1");
            if (sample2 == null)
                throw new ArgumentNullException("sample2");

            return NativeMethods.ml_CvRTrees_get_proximity(
                ptr, sample1.CvPtr, sample2.CvPtr, 
                Cv2.ToPtr(missing1), Cv2.ToPtr(missing2));
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
		public CvMat GetActiveVarMask()
		{
            IntPtr p = NativeMethods.ml_CvRTrees_get_active_var_mask(ptr);
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
		public CvRNG GetRng()
		{
            IntPtr p = NativeMethods.ml_CvRTrees_get_rng(ptr);
			if(p == IntPtr.Zero)
				return null;
		    return new CvRNG(Marshal.ReadInt64(p));
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
		public int GetTreeCount()
		{
            return NativeMethods.ml_CvRTrees_get_tree_count(ptr);
		}

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
#endif
        public CvForestTree GetTree(int i)
        {
            IntPtr p = NativeMethods.ml_CvRTrees_get_tree(ptr, i);
            if (p == IntPtr.Zero)
                return null;
            return new CvForestTree(p);
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
            NativeMethods.ml_CvRTrees_clear(ptr);
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
		public override void Write(CvFileStorage storage, String name) 
        {
            if (storage == null)
                throw new ArgumentNullException("storage");
			if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            NativeMethods.ml_CvRTrees_write(ptr, storage.CvPtr, name);
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
            NativeMethods.ml_CvRTrees_read(ptr, fs.CvPtr, node.CvPtr);
        }
		#endregion
        #endregion
	}
}
