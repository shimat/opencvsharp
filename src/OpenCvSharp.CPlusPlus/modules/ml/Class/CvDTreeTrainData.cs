/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// 決定木ノード
    /// </summary>
#else
	/// <summary>
    /// Decision tree node
    /// </summary>
#endif
	public class CvDTreeTrainData : DisposableCvObject
	{
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

		#region Init and Disposal
#if LANG_JP
		/// <summary>
        /// 既定の初期化
        /// </summary>
#else
		/// <summary>
        /// Default constructor
        /// </summary>
#endif
		public CvDTreeTrainData()
		{
			ptr = NativeMethods.ml_CvDTreeTrainData_new1();
		}
#if LANG_JP
		/// <summary>
        /// ポインタから初期化
        /// </summary>
#else
		/// <summary>
        /// Initializes from pointer
        /// </summary>
#endif
		public CvDTreeTrainData(IntPtr ptr)
		{
			this.ptr = ptr;
		}

#if LANG_JP
		/// <summary>
        /// 学習データを与えて初期化
        /// </summary>
        /// <param name="trainData"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
        /// <param name="varIdx"></param>
        /// <param name="sampleIdx"></param>
        /// <param name="varType"></param>
        /// <param name="missingMask"></param>
        /// <param name="param"></param>
		/// <param name="shared"></param>
        /// <param name="addLabels"></param>
        /// <returns></returns>
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
        /// <param name="param"></param>
		/// <param name="shared"></param>
		/// <param name="addLabels"></param>
        /// <returns></returns>
#endif
		public CvDTreeTrainData(
            CvMat trainData,
            DTreeDataLayout tflag, 
            CvMat responses, 
            CvMat varIdx = null, 
            CvMat sampleIdx = null, 
            CvMat varType = null, 
            CvMat missingMask = null,
			CvDTreeParams param = null, 
            bool shared = false, 
            bool addLabels = false)
		{
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");
            trainData.ThrowIfDisposed();
            responses.ThrowIfDisposed();

            if(param == null)
				param = new CvDTreeParams();

            ptr = NativeMethods.ml_CvDTreeTrainData_new2(
				trainData.CvPtr, 
				(int)tflag, 
				responses.CvPtr, 
				Cv2.ToPtr(varIdx), 
                Cv2.ToPtr(sampleIdx),
                Cv2.ToPtr(varType), 
                Cv2.ToPtr(missingMask), 
				param.CvPtr, 
				shared ? 1 : 0, 
                addLabels ? 1 : 0
			);
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
                        if(ptr != IntPtr.Zero)
                            NativeMethods.ml_CvDTreeTrainData_delete(ptr);
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

		#region SetData

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
		/// <param name="shared"></param>
        /// <param name="addLabels"></param>
        /// <param name="updateData"></param>
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
        /// <param name="shared"></param>
		/// <param name="addLabels"></param>
		/// <param name="updateData"></param>
        /// <returns></returns>
#endif
		public void SetData(
            CvMat trainData, 
            DTreeDataLayout tflag, 
            CvMat responses, 
            CvMat varIdx = null, 
            CvMat sampleIdx = null, 
            CvMat varType = null, 
            CvMat missingMask = null,
			CvDTreeParams param = null, 
            bool shared = false, 
            bool addLabels = false, 
            bool updateData = false)
		{
            if (trainData == null)
                throw new ArgumentNullException("trainData");
            if (responses == null)
                throw new ArgumentNullException("responses");

			if(param == null)
				param = new CvDTreeParams();

            NativeMethods.ml_CvDTreeTrainData_set_data(
                ptr,
				trainData.CvPtr, 
				(int)tflag, 
				responses.CvPtr,
                Cv2.ToPtr(varIdx),
                Cv2.ToPtr(sampleIdx),
                Cv2.ToPtr(varType),
                Cv2.ToPtr(missingMask),
                param.CvPtr,
                shared ? 1 : 0,
                addLabels ? 1 : 0,
                updateData ? 1 : 0
			);
		}
		#endregion

		#region Properties
#if LANG_JP
		/// <summary>
		/// 
		/// </summary>
#else
		/// <summary>
		/// 
		/// </summary>
#endif
		public int SampleCount
		{
		    get
		    {
		        if (disposed)
		            throw new ObjectDisposedException("CvDTreeTrainData");
		        return NativeMethods.ml_CvDTreeTrainData_sample_count(ptr);
		    }
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
		public int VarAll
		{
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                return NativeMethods.ml_CvDTreeTrainData_var_all(ptr);
            }
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
		public int VarCount
		{
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                return NativeMethods.ml_CvDTreeTrainData_var_count(ptr);
            }
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
		public int MaxCCount
		{
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                return NativeMethods.ml_CvDTreeTrainData_max_c_count(ptr);
            }
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
		public int OrdVarCount
		{
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                return NativeMethods.ml_CvDTreeTrainData_ord_var_count(ptr);
            }
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
		public int CatVarCount
		{
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                return NativeMethods.ml_CvDTreeTrainData_cat_var_count(ptr);
            }
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
		public bool HaveLabels
		{
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                return NativeMethods.ml_CvDTreeTrainData_have_labels(ptr) != 0;
            }
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
		public bool HavePriors
		{
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                return NativeMethods.ml_CvDTreeTrainData_have_priors(ptr) != 0;
            }
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
		public bool IsClassifier
		{
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                return NativeMethods.ml_CvDTreeTrainData_is_classifier(ptr) != 0;
            }
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
		public int BufCount
		{
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                return NativeMethods.ml_CvDTreeTrainData_buf_count(ptr);
            }
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
		public int BufSize
		{
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                return NativeMethods.ml_CvDTreeTrainData_buf_size(ptr);
            }
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
		public bool Shared
		{
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                return NativeMethods.ml_CvDTreeTrainData_shared(ptr) != 0;
            }
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
        public CvRNG Rng
        {
            get 
            {
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                UInt64 state = NativeMethods.ml_CvDTreeTrainData_rng(ptr);
                return new CvRNG(state);
            }
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
		public CvMat CatCount
		{
			get
			{
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                IntPtr p = NativeMethods.ml_CvDTreeTrainData_cat_count(ptr);
				if(p == IntPtr.Zero)
					return null;
			    return new CvMat(p, false);
			}
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
		public CvMat CatOfs
		{
			get
			{
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                IntPtr p = NativeMethods.ml_CvDTreeTrainData_cat_ofs(ptr);
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false);
			}
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
		public CvMat CatMap
		{
			get
			{
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                IntPtr p = NativeMethods.ml_CvDTreeTrainData_cat_map(ptr);
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false);
			}
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
		public CvMat Counts
		{
			get
			{
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                IntPtr p = NativeMethods.ml_CvDTreeTrainData_counts(ptr);
                if (p == IntPtr.Zero)
                    return null;
			    return new CvMat(p, false);
			}
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
		public CvMat Buf
		{
			get
			{
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                IntPtr p = NativeMethods.ml_CvDTreeTrainData_buf(ptr);
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false);
			}
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
		public CvMat Direction
		{
			get
			{
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                IntPtr p = NativeMethods.ml_CvDTreeTrainData_direction(ptr);
                if (p == IntPtr.Zero)
                    return null;
			    return new CvMat(p, false);
			}
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
		public CvMat SplitBuf
		{
			get
			{
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                IntPtr p = NativeMethods.ml_CvDTreeTrainData_split_buf(ptr);
                if (p == IntPtr.Zero)
                    return null;
			    return new CvMat(p, false);
			}
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
		public CvMat VarIdx
		{
			get
			{
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                IntPtr p = NativeMethods.ml_CvDTreeTrainData_var_idx(ptr);
                if (p == IntPtr.Zero)
                    return null;
			    return new CvMat(p, false);
			}
		}
#if LANG_JP
		/// <summary>
		/// i番目の要素が
		/// k&lt;0  - 連続変数, 
        /// k&gt;=0 - カテゴリ変数，cat_* 配列の k番目の要素を参照
		/// </summary>
#else
		/// <summary>
		/// i-th element =
        /// k&lt;0  - ordered, 
        /// k&gt;=0 - categorical, see k-th element of cat_* arrays
		/// </summary>
#endif
		public CvMat VarType
		{
			get
			{
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                IntPtr p = NativeMethods.ml_CvDTreeTrainData_var_type(ptr);
                if (p == IntPtr.Zero)
                    return null;
			    return new CvMat(p, false);
			}
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
		public CvMat Priors
		{
			get
			{
                if (disposed)
                    throw new ObjectDisposedException("CvDTreeTrainData"); 
                IntPtr p = NativeMethods.ml_CvDTreeTrainData_priors(ptr);
                if (p == IntPtr.Zero)
                    return null;
			    return new CvMat(p, false);
			}
		}
		#endregion

		#region Methods
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
		public int GetNumClasses()
		{
            if (disposed)
                throw new ObjectDisposedException("CvDTreeTrainData"); 
            return NativeMethods.ml_CvDTreeTrainData_get_num_classes(ptr);
		}
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
		/// <param name="vi"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// 
        /// </summary>
		/// <param name="vi"></param>
        /// <returns></returns>
#endif
		public int GetVarType(int vi)
		{
            if (disposed)
                throw new ObjectDisposedException("CvDTreeTrainData"); 
            return NativeMethods.ml_CvDTreeTrainData_get_var_type(ptr, vi);
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
		public int GetWorkVarCount()
		{
            if (disposed)
                throw new ObjectDisposedException("CvDTreeTrainData"); 
            return NativeMethods.ml_CvDTreeTrainData_get_work_var_count(ptr);
		}


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
		/// <param name="n"></param>
        /// <param name="labelsBuf"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
		/// </summary>
		/// <param name="n"></param>
        /// <param name="labelsBuf"></param>
        /// <returns></returns>
#endif
        public virtual PointerAccessor1D_Int32 GetClassLabels(
            CvDTreeNode n, int[] labelsBuf)
		{
            if (disposed)
                throw new ObjectDisposedException("CvDTreeTrainData");
            if (n == null)
                throw new ArgumentNullException("n");

            IntPtr p = NativeMethods.ml_CvDTreeTrainData_get_class_labels(ptr, n.CvPtr, labelsBuf);
            return new PointerAccessor1D_Int32(p);
		}
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
		/// <param name="n"></param>
        /// <param name="valuesBuf"></param>
        /// <param name="sampleIndicesBuf"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
		/// </summary>
		/// <param name="n"></param>
        /// <param name="valuesBuf"></param>
        /// <param name="sampleIndicesBuf"></param>
        /// <returns></returns>
#endif
        public virtual PointerAccessor1D_Single GetOrdResponses(
            CvDTreeNode n, float[] valuesBuf, int[] sampleIndicesBuf)
        {
            if (disposed)
                throw new ObjectDisposedException("CvDTreeTrainData");
            if (n == null)
                throw new ArgumentNullException("n");

            IntPtr p = NativeMethods.ml_CvDTreeTrainData_get_ord_responses(ptr, n.CvPtr, valuesBuf, sampleIndicesBuf);
            return new PointerAccessor1D_Single(p);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
		/// <param name="n"></param>
        /// <param name="labelsBuf"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
		/// </summary>
		/// <param name="n"></param>
        /// <param name="labelsBuf"></param>
        /// <returns></returns>
#endif
        public virtual PointerAccessor1D_Int32 GetLabels(
            CvDTreeNode n, int[] labelsBuf)
		{
            if (disposed)
                throw new ObjectDisposedException("CvDTreeTrainData");
            if (n == null)
                throw new ArgumentNullException("n");

            IntPtr p = NativeMethods.ml_CvDTreeTrainData_get_cv_labels(ptr, n.CvPtr, labelsBuf);
            return new PointerAccessor1D_Int32(p);
		}
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
		/// <param name="n"></param>
		/// <param name="vi"></param>
        /// <param name="catValuesBuf"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
		/// </summary>
		/// <param name="n"></param>
		/// <param name="vi"></param>
        /// <param name="catValuesBuf"></param>
        /// <returns></returns>
#endif
        public virtual PointerAccessor1D_Int32 GetCatVarData(
            CvDTreeNode n, int vi, int[] catValuesBuf)
		{
            if (disposed)
                throw new ObjectDisposedException("CvDTreeTrainData");
            if (n == null)
                throw new ArgumentNullException("n");

            IntPtr p = NativeMethods.ml_CvDTreeTrainData_get_cat_var_data(ptr, n.CvPtr, vi, catValuesBuf);
            return new PointerAccessor1D_Int32(p);

		}
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
		/// <param name="n"></param>
		/// <param name="vi"></param>
        /// <param name="ordValuesBuf"></param>
        /// <param name="sortedIndicesBuf"></param>
        /// <param name="ordValues"></param>
        /// <param name="sortedIndices"></param>
        /// <param name="sampleIndicesBuf"></param>
#else
        /// <summary>
        /// 
		/// </summary>
		/// <param name="n"></param>
		/// <param name="vi"></param>
        /// <param name="ordValuesBuf"></param>
        /// <param name="sortedIndicesBuf"></param>
        /// <param name="ordValues"></param>
        /// <param name="sortedIndices"></param>
        /// <param name="sampleIndicesBuf"></param>
#endif
        public virtual void GetOrdVarData(
            CvDTreeNode n, int vi, float[] ordValuesBuf, int[] sortedIndicesBuf, 
            float[][] ordValues, int[][] sortedIndices, int[] sampleIndicesBuf)
		{
            if (disposed)
                throw new ObjectDisposedException("CvDTreeTrainData");
            if (n == null)
                throw new ArgumentNullException("n");

            NativeMethods.ml_CvDTreeTrainData_get_ord_var_data(ptr, n.CvPtr, vi, ordValuesBuf, sortedIndicesBuf, ordValues, sortedIndices, sampleIndicesBuf);	
		}
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
		/// <param name="n"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// 
		/// </summary>
		/// <param name="n"></param>
        /// <returns></returns>
#endif
		public virtual int GetChildBufIdx(CvDTreeNode n)
		{
            if (disposed)
                throw new ObjectDisposedException("CvDTreeTrainData"); 
			if (n == null)
			    throw new ArgumentNullException("n");

            return NativeMethods.ml_CvDTreeTrainData_get_child_buf_idx(ptr, n.CvPtr);
		}
		#endregion
	}
}
