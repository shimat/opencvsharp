using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.ML
{
#if LANG_JP
    /// <summary>
    /// ランダムツリークラス
    /// </summary>
#else
	/// <summary>
    /// The class implements the random forest predictor.
    /// </summary>
#endif
	public class RTrees : DTrees
	{
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;
        private Ptr<RTrees> ptrObj;

		#region Init and Disposal

        /// <summary>
        /// Creates instance by raw pointer cv::ml::RTrees*
        /// </summary>
        protected RTrees(IntPtr p)
            : base()
        {
            ptrObj = new Ptr<RTrees>(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates the empty model.
        /// </summary>
        /// <returns></returns>
        public static new RTrees Create()
	    {
            IntPtr ptr = NativeMethods.ml_RTrees_create();
            return new RTrees(ptr);
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
                        if (ptrObj != null)
                        {
                            ptrObj.Dispose();
                            ptrObj = null;
                        }
                    }
                    ptr = IntPtr.Zero;
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

        /// <summary>
        /// If true then variable importance will be calculated and then 
        /// it can be retrieved by RTrees::getVarImportance. Default value is false.
        /// </summary>
        public bool CalculateVarImportance
        {
            get { return NativeMethods.ml_RTrees_getCalculateVarImportance(ptr) != 0; }
            set { NativeMethods.ml_RTrees_setCalculateVarImportance(ptr, value ? 1 : 0); }
        }

        /// <summary>
        /// The size of the randomly selected subset of features at each tree node 
        /// and that are used to find the best split(s).
        /// </summary>
        public bool ActiveVarCount
        {
            get { return NativeMethods.ml_RTrees_getActiveVarCount(ptr) != 0; }
            set { NativeMethods.ml_RTrees_setActiveVarCount(ptr, value ? 1 : 0); }
        }

        /// <summary>
        /// The termination criteria that specifies when the training algorithm stops.
        /// </summary>
        public TermCriteria TermCriteria
        {
            get { return NativeMethods.ml_RTrees_getTermCriteria(ptr); }
            set { NativeMethods.ml_RTrees_setTermCriteria(ptr, value); }
        }

        #endregion

		#region Methods
		
        /// <summary>
        /// Returns the variable importance array. 
        /// The method returns the variable importance vector, computed at the training 
        /// stage when CalculateVarImportance is set to true. If this flag was set to false, 
        /// the empty matrix is returned.
        /// </summary>
        /// <returns></returns>
	    public Mat GetVarImportance()
	    {
	        if (disposed)
	            throw new NotImplementedException(GetType().Name);

            IntPtr p = NativeMethods.ml_RTrees_getVarImportance(ptr);
            return new Mat(p);
	    }

        #endregion
	}
}
