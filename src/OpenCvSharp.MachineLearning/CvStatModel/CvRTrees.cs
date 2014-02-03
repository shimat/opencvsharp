/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.MachineLearning
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
        private bool disposed = false;

		#region Constants
        /// <summary>
        /// sizeof(CvRTrees)
        /// </summary>
		public static readonly int SizeOf = MLInvoke.CvRTrees_sizeof();
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
        public CvRTrees()
            //: this(ML.CvRTrees_construct())
        {
            ptr = AllocMemory(SizeOf);
            MLInvoke.CvRTrees_construct(ptr);
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
        public CvRTrees(IntPtr ptr)
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
                        /*
                        ML.CvRTrees_destruct(_ptr);
                        //*/
                        MLInvoke.CvRTrees_clear(ptr);
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
        /// ランダムツリーモデルの学習
        /// </summary>
        /// <param name="train_data"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Trains Random Trees model
        /// </summary>
        /// <param name="trainData"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
        /// <returns></returns>
#endif
		public virtual bool Train(CvMat trainData, DTreeDataLayout tflag, CvMat responses)
        {
			return Train(trainData, tflag, responses, null, null, null, null, new CvRTParams());
        }
#if LANG_JP
        /// <summary>
        /// ランダムツリーモデルの学習
        /// </summary>
        /// <param name="train_data"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
		/// <param name="comp_idx"></param>
        /// <param name="sample_idx"></param>
        /// <param name="var_type"></param>
        /// <param name="missing_mask"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Trains Random Trees model
        /// </summary>
        /// <param name="trainData"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
		/// <param name="compIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="varType"></param>
        /// <param name="missingMask"></param>
        /// <returns></returns>
#endif
		public virtual bool Train(CvMat trainData, DTreeDataLayout tflag, CvMat responses, 
			CvMat compIdx, CvMat sampleIdx, CvMat varType, CvMat missingMask)
        {
			return Train(trainData, tflag, responses, compIdx, sampleIdx, varType, missingMask, new CvRTParams());
        }
#if LANG_JP
        /// <summary>
        /// ランダムツリーモデルの学習
        /// </summary>
        /// <param name="train_data"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
		/// <param name="comp_idx"></param>
        /// <param name="sample_idx"></param>
        /// <param name="var_type"></param>
        /// <param name="missing_mask"></param>
        /// <param name="params"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Trains Random Trees model
        /// </summary>
        /// <param name="trainData"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
		/// <param name="compIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="varType"></param>
        /// <param name="missingMask"></param>
        /// <param name="params"></param>
        /// <returns></returns>
#endif
		public virtual bool Train(CvMat trainData, DTreeDataLayout tflag, CvMat responses, 
			CvMat compIdx, CvMat sampleIdx, CvMat varType, CvMat missingMask, CvRTParams @params)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");

			if(@params == null)
				@params = new CvRTParams();

            IntPtr compIdxPtr = (compIdx == null) ? IntPtr.Zero : compIdx.CvPtr;
            IntPtr sampleIdxPtr = (sampleIdx == null) ? IntPtr.Zero : sampleIdx.CvPtr;
            IntPtr varTypePtr = (varType == null) ? IntPtr.Zero : varType.CvPtr;
            IntPtr missingMaskPtr = (missingMask == null) ? IntPtr.Zero : missingMask.CvPtr;

            return MLInvoke.CvRTrees_train(
                ptr,
				trainData.CvPtr, 
				(int)tflag, 
				responses.CvPtr, 
				compIdxPtr, sampleIdxPtr, varTypePtr, missingMaskPtr, 
				@params.CvPtr
			);
        }
		#endregion

		#region Predict
#if LANG_JP
        /// <summary>
        /// 入力サンプルに対する出力を予測する
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Predicts the output for the input sample
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
#endif
        public virtual double Predict(CvMat sample)
		{
			return Predict(sample, null);
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
        public virtual double Predict(CvMat sample, CvMat missing)
		{
			if (sample == null)
                throw new ArgumentNullException("sample");

            IntPtr missingPtr = (missing == null) ? IntPtr.Zero : missing.CvPtr;

            return MLInvoke.CvRTrees_predict(ptr, sample.CvPtr, missingPtr);
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
		public virtual CvMat GetVarImportance()
		{
			IntPtr p = MLInvoke.CvRTrees_get_var_importance(ptr);
			if(p == IntPtr.Zero)
				return null;
		    return new CvMat(p, false);
		}

#if LANG_JP
        /// <summary>
        /// 二つの学習サンプル間の近さを取り出す
        /// </summary>
		/// <param name="sample_1"></param>
		/// <param name="sample_2"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Retrieves proximity measure between two training samples
        /// </summary>
		/// <param name="sample1"></param>
		/// <param name="sample2"></param>
        /// <returns></returns>
#endif
        public virtual float GetProximity(CvMat sample1, CvMat sample2)
		{
            return GetProximity(sample1, sample2, null, null);
		}

#if LANG_JP
        /// <summary>
        /// 二つの学習サンプル間の近さを取り出す
        /// </summary>
		/// <param name="sample_1"></param>
		/// <param name="sample_2"></param>
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
        public virtual float GetProximity(CvMat sample1, CvMat sample2, CvMat missing1, CvMat missing2)
        {
            if (sample1 == null)
                throw new ArgumentNullException("sample1");
            if (sample2 == null)
                throw new ArgumentNullException("sample2");

            IntPtr missing1Ptr = (missing1 == null) ? IntPtr.Zero : missing1.CvPtr;
            IntPtr missing2Ptr = (missing2 == null) ? IntPtr.Zero : missing2.CvPtr;

            return MLInvoke.CvRTrees_get_proximity(ptr, sample1.CvPtr, sample2.CvPtr, missing1Ptr, missing2Ptr);
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
			IntPtr p = MLInvoke.CvRTrees_get_active_var_mask(ptr);
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
			IntPtr p = MLInvoke.CvRTrees_get_rng(ptr);
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
			return MLInvoke.CvRTrees_get_tree_count(ptr);
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
            IntPtr p = MLInvoke.CvRTrees_get_tree(ptr, i);
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
            MLInvoke.CvRTrees_clear(ptr);
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

            MLInvoke.CvRTrees_write(ptr, storage.CvPtr, name);
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
            MLInvoke.CvRTrees_read(ptr, fs.CvPtr, node.CvPtr);
        }
		#endregion
        #endregion
	}
}
