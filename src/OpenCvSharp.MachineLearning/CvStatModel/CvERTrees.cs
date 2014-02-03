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
        private bool disposed = false;

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
            : this(MLInvoke.CvERTrees_construct())
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
        public CvERTrees(IntPtr ptr)
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
                        MLInvoke.CvERTrees_destruct(ptr);
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
        /// <summary>
        /// sizeof(CvERTrees)
        /// </summary>
        new public static readonly int SizeOf = MLInvoke.CvERTrees_sizeof();
        #endregion

		#region Methods
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="train_data"></param>
        /// <param name="tflag"></param>
        /// <param name="responses"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainData"></param>
        /// <param name="tflag"></param>
        /// <param name="responses"></param>
        /// <returns></returns>
#endif
        public virtual bool Train(CvMat trainData, int tflag, CvMat responses)
        {
            return Train(trainData, tflag, responses, null, null, null, null, new CvRTParams());
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="train_data"></param>
        /// <param name="tflag"></param>
        /// <param name="responses"></param>
        /// <param name="var_idx"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainData"></param>
        /// <param name="tflag"></param>
        /// <param name="responses"></param>
        /// <param name="varIdx"></param>
        /// <returns></returns>
#endif
        public virtual bool Train(CvMat trainData, int tflag, CvMat responses, 
            CvMat varIdx)
        {
            return Train(trainData, tflag, responses, varIdx, null, null, null, new CvRTParams());
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="train_data"></param>
        /// <param name="tflag"></param>
        /// <param name="responses"></param>
        /// <param name="var_idx"></param>
        /// <param name="sample_idx"></param>
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
        /// <returns></returns>
#endif
        public virtual bool Train(CvMat trainData, int tflag, CvMat responses, 
            CvMat varIdx, CvMat sampleIdx)
        {
            return Train(trainData, tflag, responses, varIdx, sampleIdx, null, null, new CvRTParams());
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="train_data"></param>
        /// <param name="tflag"></param>
        /// <param name="responses"></param>
        /// <param name="var_idx"></param>
        /// <param name="sample_idx"></param>
        /// <param name="var_type"></param>
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
        /// <returns></returns>
#endif
        public virtual bool Train(CvMat trainData, int tflag, CvMat responses, 
            CvMat varIdx, CvMat sampleIdx, CvMat varType)
        {
            return Train(trainData, tflag, responses, varIdx, sampleIdx, varType, null, new CvRTParams());
        }
#if LANG_JP
        /// <summary>
        /// 
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
        /// 
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
        public virtual bool Train(CvMat trainData, int tflag, CvMat responses, 
            CvMat varIdx, CvMat sampleIdx, CvMat varType, CvMat missingMask)
        {
            return Train(trainData, tflag, responses, varIdx, sampleIdx, varType, missingMask, new CvRTParams());
        }
#if LANG_JP
        /// <summary>
        /// 
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
        /// 
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
        public virtual bool Train(CvMat trainData, int tflag, CvMat responses, 
            CvMat varIdx, CvMat sampleIdx, CvMat varType, CvMat missingMask, CvRTParams @params)
        {
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");

            IntPtr varIdxPtr = (varIdx == null) ? IntPtr.Zero : varIdx.CvPtr;
            IntPtr sampleIdxPtr = (sampleIdx == null) ? IntPtr.Zero : sampleIdx.CvPtr;
            IntPtr varTypePtr = (varType == null) ? IntPtr.Zero : varType.CvPtr;
            IntPtr missingMaskPtr = (missingMask == null) ? IntPtr.Zero : missingMask.CvPtr;
            if (@params == null)
                @params = new CvRTParams();

            return MLInvoke.CvERTrees_train1(ptr, trainData.CvPtr, tflag, responses.CvPtr, varIdxPtr, sampleIdxPtr, varTypePtr, missingMaskPtr, @params.CvPtr);
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
        /// <param name="params"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="params"></param>
        /// <returns></returns>
#endif
        public bool Train(CvMLData data, CvRTParams @params)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (@params == null)
                @params = new CvRTParams();

            return MLInvoke.CvERTrees_train2(ptr, data.CvPtr, @params.CvPtr);
        }


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="term_crit"></param>
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
            return MLInvoke.CvERTrees_grow_forest(ptr, termCrit);
        }
        #endregion
	}
}
