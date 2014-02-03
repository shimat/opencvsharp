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
    /// 弱い決定木クラス
    /// </summary>
#else
	/// <summary>
    /// Weak tree classifier
    /// </summary>
#endif
	public class CvBoostTree : CvDTree
	{
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

		#region Constants
        /// <summary>
        /// sizeof(CvForestTrees)
        /// </summary>
        new public static readonly int SizeOf = MLInvoke.CvForestTree_sizeof();
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
        public CvBoostTree()
			: this(MLInvoke.CvBoostTree_construct())
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
        public CvBoostTree(IntPtr ptr)
            : base(ptr)
        {
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
                        MLInvoke.CvBoostTree_destruct(ptr);
                        //ML.CvBoostTree_clear(_ptr);
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
#if LANG_JP
        /// <summary>
        /// 決定木を学習する
        /// </summary>
        /// <param name="train_data"></param>
		/// <param name="subsample_idx"></param>
		/// <param name="ensemble"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Trains decision tree
        /// </summary>
        /// <param name="trainData"></param>
		/// <param name="subsampleIdx"></param>
		/// <param name="ensemble"></param>
        /// <returns></returns>
#endif
		public virtual bool Train(CvDTreeTrainData trainData, CvMat subsampleIdx, CvBoost ensemble)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (subsampleIdx == null)
                throw new ArgumentNullException("subsampleIdx");

            IntPtr ensemblePtr = (ensemble == null) ? IntPtr.Zero : ensemble.CvPtr;

			return MLInvoke.CvBoostTree_train(ptr, trainData.CvPtr, subsampleIdx.CvPtr, ensemblePtr);
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
#else
		/// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
#endif
		public virtual void Scale(double s)
        {
			MLInvoke.CvBoostTree_scale(ptr, s);
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fs"></param>		
        /// <param name="node"></param>
		/// <param name="ensemble"></param>
		/// <param name="data"></param>
#else
		/// <summary>
        /// 
        /// </summary>
        /// <param name="fs"></param>		
        /// <param name="node"></param>
		/// <param name="ensemble"></param>
		/// <param name="data"></param>
#endif
		public virtual void Read(CvFileStorage fs, CvFileNode node, CvBoost ensemble, CvDTreeTrainData data)
        {
			if (fs == null)
                throw new ArgumentNullException("fs");
            if (node == null)
                throw new ArgumentNullException("node");
			if (ensemble == null)
                throw new ArgumentNullException("ensemble");
			if (data == null)
                throw new ArgumentNullException("data");

			MLInvoke.CvBoostTree_read(ptr, fs.CvPtr, node.CvPtr, ensemble.CvPtr, data.CvPtr);
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
		/// <summary>
        /// 
        /// </summary>
#endif
		public override void Clear() 
        {
			MLInvoke.CvBoostTree_clear(ptr);
        }
		#endregion
	}
}
