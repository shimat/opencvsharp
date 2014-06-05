using System;

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
    /// 
    /// </summary>
#else
	/// <summary>
    /// 
    /// </summary>
#endif
    public class CvERTrees : CvRTrees
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
        public CvERTrees()
            : this(IntPtr.Zero)
		{
		    ptr = NativeMethods.ml_CvERTrees_new();
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
        internal CvERTrees(IntPtr ptr)
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
                        NativeMethods.ml_CvERTrees_delete(ptr);
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
        /// 
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
        /// 
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
            int tflag, 
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
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();

            if (param == null)
                param = new CvRTParams();

            return NativeMethods.ml_CvERTrees_train1(
                ptr,
                trainData.CvPtr, 
                tflag, 
                responses.CvPtr, 
                Cv2.ToPtr(varIdx), 
                Cv2.ToPtr(sampleIdx), 
                Cv2.ToPtr(varType),
                Cv2.ToPtr(missingMask),
                param.CvPtr) != 0;
        }


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
#endif
        public bool Train(CvMLData data)
        {
            return Train(data, new CvRTParams());
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="param"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="param"></param>
        /// <returns></returns>
#endif
        public bool Train(CvMLData data, CvRTParams param)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (param == null)
                param = new CvRTParams();

            return NativeMethods.ml_CvERTrees_train2(ptr, data.CvPtr, param.CvPtr) != 0;
        }


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="termCrit"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="termCrit"></param>
        /// <returns></returns>
#endif
        protected bool GrowForest(CvTermCriteria termCrit)
        {
            return NativeMethods.ml_CvERTrees_grow_forest(ptr, termCrit) != 0;
        }
        #endregion
	}
}
