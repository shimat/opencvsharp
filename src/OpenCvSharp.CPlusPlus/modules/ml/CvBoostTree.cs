/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;

namespace OpenCvSharp.CPlusPlus
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
	    public CvBoostTree()
            : base(IntPtr.Zero)
		{
		    ptr = NativeMethods.ml_CvBoostTree_new();
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
        internal CvBoostTree(IntPtr ptr)
            : base(ptr)
        {
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
                        NativeMethods.ml_CvBoostTree_delete(ptr);
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
        /// 決定木を学習する
        /// </summary>
        /// <param name="trainData"></param>
        /// <param name="subsampleIdx"></param>
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

			return NativeMethods.ml_CvBoostTree_train(
                ptr, trainData.CvPtr, subsampleIdx.CvPtr, Cv2.ToPtr(ensemble)) != 0;
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
            NativeMethods.ml_CvBoostTree_scale(ptr, s);
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

            NativeMethods.ml_CvBoostTree_read(
                ptr, fs.CvPtr, node.CvPtr, ensemble.CvPtr, data.CvPtr);
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
            NativeMethods.ml_CvBoostTree_clear(ptr);
        }
		#endregion
	}
}
