/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.MachineLearning
{
#if LANG_JP
    /// <summary>
    /// 
    /// </summary>
#else
	/// <summary>
    /// 
    /// </summary>
#endif
	public class CvForestTree : CvDTree
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
        public CvForestTree()
            : this(MLInvoke.CvForestTree_construct())
        {
			NotifyMemoryPressure(SizeOf);
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
        public CvForestTree(IntPtr ptr)
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
                        MLInvoke.CvForestTree_destruct(ptr);
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
        /// 
        /// </summary>
        /// <param name="train_data"></param>
        /// <param name="subsample_idx"></param>
        /// <param name="forest"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainData"></param>
        /// <param name="subsampleIdx"></param>
        /// <param name="forest"></param>
        /// <returns></returns>
#endif
        public virtual bool Train( CvDTreeTrainData trainData, CvMat subsampleIdx, CvRTrees forest )
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (subsampleIdx == null)
                throw new ArgumentNullException("subsampleIdx");
            if (forest == null)
                throw new ArgumentNullException("forest");

            return MLInvoke.CvForestTree_train(ptr, trainData.CvPtr, subsampleIdx.CvPtr, forest.CvPtr);
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
        public virtual int GetVarCount()
        {
            return MLInvoke.CvForestTree_get_var_count(ptr);
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="node"></param>
        /// <param name="forest"></param>
        /// <param name="data"></param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="node"></param>
        /// <param name="forest"></param>
        /// <param name="data"></param>
#endif
        public virtual void Read(CvFileStorage fs, CvFileNode node, CvRTrees forest, CvDTreeTrainData data)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            if (node == null)
                throw new ArgumentNullException("node");
            if (forest == null)
                throw new ArgumentNullException("forest");
            if (data == null)
                throw new ArgumentNullException("data");

            MLInvoke.CvForestTree_read(ptr, fs.CvPtr, node.CvPtr, forest.CvPtr, data.CvPtr);
        }
        #endregion
	}
}
