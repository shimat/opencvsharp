/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;

namespace OpenCvSharp.MachineLearning
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
        private bool disposed = false;

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
			ptr = MLInvoke.CvDTreeTrainData_construct_default();
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
		/// <param name="train_data"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
        /// <param name="var_idx"></param>
        /// <returns></returns>
#else
		/// <summary>
        /// Training constructor
        /// </summary>
		/// <param name="trainData"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
        /// <param name="varIdx"></param>
        /// <returns></returns>
#endif
        public CvDTreeTrainData(CvMat trainData, DTreeDataLayout tflag, CvMat responses, CvMat varIdx)
            : this(trainData, tflag, responses, varIdx, null, null, null, new CvDTreeParams(), false, false)
		{
		}
#if LANG_JP
		/// <summary>
        /// 学習データを与えて初期化
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
        /// Training constructor
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
		public CvDTreeTrainData(CvMat trainData, DTreeDataLayout tflag, CvMat responses, CvMat varIdx, CvMat sampleIdx, CvMat varType, CvMat missingMask)
            : this(trainData, tflag, responses, varIdx, sampleIdx, varType, missingMask, new CvDTreeParams(), false, false)
		{
		}
#if LANG_JP
		/// <summary>
        /// 学習データを与えて初期化
        /// </summary>
		/// <param name="train_data"></param>
		/// <param name="tflag"></param>
        /// <param name="responses"></param>
		/// <param name="var_idx"></param>
        /// <param name="sample_idx"></param>
        /// <param name="var_type"></param>
        /// <param name="missing_mask"></param>
        /// <param name="params"></param>
		/// <param name="shared"></param>
		/// <param name="add_labels"></param>
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
        /// <param name="params"></param>
		/// <param name="shared"></param>
		/// <param name="addLabels"></param>
        /// <returns></returns>
#endif
		public CvDTreeTrainData(CvMat trainData, DTreeDataLayout tflag, CvMat responses, CvMat varIdx, CvMat sampleIdx, CvMat varType, CvMat missingMask,
			CvDTreeParams @params, bool shared, bool addLabels)
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

			ptr = MLInvoke.CvDTreeTrainData_construct_training(
				trainData.CvPtr, 
				(int)tflag, 
				responses.CvPtr, 
				varIdxPtr, 
                sampleIdxPtr, 
                varTypePtr, 
                missingMaskPtr, 
				@params.CvPtr, 
				shared, 
                addLabels
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
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        try
                        {
                            MLInvoke.CvDTreeTrainData_destruct(ptr);
                        }
                        catch (Exception ex1)
                        {
                            Console.Error.WriteLine(ex1);
                            try
                            {
                                MLInvoke.CvDTreeTrainData_clear(ptr);
                            }
                            catch (Exception ex2)
                            {
                                Console.Error.WriteLine(ex2);
                            }
                        }
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

		#region SetData
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
		public void SetData(CvMat trainData, DTreeDataLayout tflag, CvMat responses)
		{
            SetData(trainData, tflag, responses, null, null, null, null, new CvDTreeParams(), false, false, false);
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
		public void SetData(CvMat trainData, DTreeDataLayout tflag, CvMat responses, CvMat varIdx, CvMat sampleIdx, CvMat varType, CvMat missingMask)
		{
             SetData(trainData, tflag, responses, varIdx, sampleIdx, varType, missingMask, new CvDTreeParams(), false, false, false);
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
		/// <param name="shared"></param>
		/// <param name="add_labels"></param>
		/// <param name="update_data"></param>
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
		/// <param name="shared"></param>
		/// <param name="addLabels"></param>
		/// <param name="updateData"></param>
        /// <returns></returns>
#endif
		public void SetData(CvMat trainData, DTreeDataLayout tflag, CvMat responses, CvMat varIdx, CvMat sampleIdx, CvMat varType, CvMat missingMask,
			CvDTreeParams @params, bool shared, bool addLabels, bool updateData)
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

			MLInvoke.CvDTreeTrainData_set_data(
                ptr,
				trainData.CvPtr, 
				(int)tflag, 
				responses.CvPtr, 
				varIdxPtr,
				sampleIdxPtr, 
				varTypePtr, 
				missingMaskPtr,
				@params.CvPtr, 
				shared, addLabels, updateData
			);
		}
		#endregion

		#region Properties
		/// <summary>
		/// sizeof(CvDTreeTrainData) 
		/// </summary>
		public static readonly int SizeOf = MLInvoke.CvDTreeTrainData_sizeof(); 

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
			get { return MLInvoke.CvDTreeTrainData_sample_count(ptr); }
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
            get { return MLInvoke.CvDTreeTrainData_var_all(ptr); }
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
            get { return MLInvoke.CvDTreeTrainData_var_count(ptr); }
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
            get { return MLInvoke.CvDTreeTrainData_max_c_count(ptr); }
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
            get { return MLInvoke.CvDTreeTrainData_ord_var_count(ptr); }
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
            get { return MLInvoke.CvDTreeTrainData_cat_var_count(ptr); }
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
            get { return MLInvoke.CvDTreeTrainData_have_labels(ptr); }
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
            get { return MLInvoke.CvDTreeTrainData_have_priors(ptr); }
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
            get { return MLInvoke.CvDTreeTrainData_is_classifier(ptr); }
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
            get { return MLInvoke.CvDTreeTrainData_buf_count(ptr); }
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
            get { return MLInvoke.CvDTreeTrainData_buf_size(ptr); }
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
            get { return MLInvoke.CvDTreeTrainData_shared(ptr); }
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
                UInt64 state = MLInvoke.CvDTreeTrainData_rng(ptr);
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
				IntPtr p = MLInvoke.CvDTreeTrainData_cat_count(ptr);
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
                IntPtr p = MLInvoke.CvDTreeTrainData_cat_ofs(ptr);
                if (p == IntPtr.Zero)
                    return null;
                else
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
                IntPtr p = MLInvoke.CvDTreeTrainData_cat_map(ptr);
                if (p == IntPtr.Zero)
                    return null;
                else
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
                IntPtr p = MLInvoke.CvDTreeTrainData_counts(ptr);
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
                IntPtr p = MLInvoke.CvDTreeTrainData_buf(ptr);
                if (p == IntPtr.Zero)
                    return null;
                else
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
                IntPtr p = MLInvoke.CvDTreeTrainData_direction(ptr);
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
                IntPtr p = MLInvoke.CvDTreeTrainData_split_buf(ptr);
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
                IntPtr p = MLInvoke.CvDTreeTrainData_var_idx(ptr);
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
                IntPtr p = MLInvoke.CvDTreeTrainData_var_type(ptr);
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
                IntPtr p = MLInvoke.CvDTreeTrainData_priors(ptr);
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
			return MLInvoke.CvDTreeTrainData_get_num_classes(ptr);
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
			return MLInvoke.CvDTreeTrainData_get_var_type(ptr, vi);
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
			return MLInvoke.CvDTreeTrainData_get_work_var_count(ptr);
		}


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
		/// <param name="n"></param>
        /// <param name="labels_buf"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
		/// </summary>
		/// <param name="n"></param>
        /// <param name="labels_buf"></param>
        /// <returns></returns>
#endif
        public virtual PointerAccessor1D_Int32 GetClassLabels(CvDTreeNode n, int[] labels_buf)
		{
			if(n == null)
			{
				throw new ArgumentNullException("n");
			}
            
            IntPtr p = MLInvoke.CvDTreeTrainData_get_class_labels(ptr, n.CvPtr, labels_buf);
            return new PointerAccessor1D_Int32(p);
		}
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
		/// <param name="n"></param>
        /// <param name="values_buf"></param>
        /// <param name="sample_indices_buf"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
		/// </summary>
		/// <param name="n"></param>
        /// <param name="values_buf"></param>
        /// <param name="sample_indices_buf"></param>
        /// <returns></returns>
#endif
        public virtual PointerAccessor1D_Single GetOrdResponses(CvDTreeNode n, float[] values_buf, int[] sample_indices_buf)
        {
            if (n == null)
            {
                throw new ArgumentNullException("n");
            }
            IntPtr p = MLInvoke.CvDTreeTrainData_get_ord_responses(ptr, n.CvPtr, values_buf, sample_indices_buf);
            return new PointerAccessor1D_Single(p);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
		/// <param name="n"></param>
        /// <param name="labels_buf"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
		/// </summary>
		/// <param name="n"></param>
        /// <param name="labels_buf"></param>
        /// <returns></returns>
#endif
        public virtual PointerAccessor1D_Int32 GetLabels(CvDTreeNode n, int[] labels_buf)
		{
			if(n == null)
			{
				throw new ArgumentNullException("n");
			}
            IntPtr p = MLInvoke.CvDTreeTrainData_get_cv_labels(ptr, n.CvPtr, labels_buf);
            return new PointerAccessor1D_Int32(p);
		}
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
		/// <param name="n"></param>
		/// <param name="vi"></param>
        /// <param name="cat_values_buf"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
		/// </summary>
		/// <param name="n"></param>
		/// <param name="vi"></param>
        /// <param name="cat_values_buf"></param>
        /// <returns></returns>
#endif
        public virtual PointerAccessor1D_Int32 GetCatVarData(CvDTreeNode n, int vi, int[] cat_values_buf)
		{
			if(n == null)
			{
				throw new ArgumentNullException("n");
			}
            IntPtr p = MLInvoke.CvDTreeTrainData_get_cat_var_data(ptr, n.CvPtr, vi, cat_values_buf);
            return new PointerAccessor1D_Int32(p);

		}
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
		/// <param name="n"></param>
		/// <param name="vi"></param>
        /// <param name="ord_values_buf"></param>
        /// <param name="sorted_indices_buf"></param>
        /// <param name="ord_values"></param>
        /// <param name="sorted_indices"></param>
        /// <param name="sample_indices_buf"></param>
#else
        /// <summary>
        /// 
		/// </summary>
		/// <param name="n"></param>
		/// <param name="vi"></param>
        /// <param name="ord_values_buf"></param>
        /// <param name="sorted_indices_buf"></param>
        /// <param name="ord_values"></param>
        /// <param name="sorted_indices"></param>
        /// <param name="sample_indices_buf"></param>
#endif
        public virtual void GetOrdVarData(CvDTreeNode n, int vi, float[] ord_values_buf, int[] sorted_indices_buf, float[][] ord_values, int[][] sorted_indices, int[] sample_indices_buf)
		{
			if(n == null)
			{
				throw new ArgumentNullException("n");
			}
            MLInvoke.CvDTreeTrainData_get_ord_var_data(ptr, n.CvPtr, vi, ord_values_buf, sorted_indices_buf, ord_values, sorted_indices, sample_indices_buf);	
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
			if(n == null)
			{
				throw new ArgumentNullException("n");
			}
			return MLInvoke.CvDTreeTrainData_get_child_buf_idx(ptr, n.CvPtr);
		}
		#endregion
	}
}
