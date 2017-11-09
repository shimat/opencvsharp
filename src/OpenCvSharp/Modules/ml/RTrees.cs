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
        private Ptr ptrObj;

        #region Init and Disposal

        /// <summary>
        /// Creates instance by raw pointer cv::ml::RTrees*
        /// </summary>
        protected RTrees(IntPtr p)
            : base()
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates the empty model.
        /// </summary>
        /// <returns></returns>
        public new static RTrees Create()
        {
            IntPtr ptr = NativeMethods.ml_RTrees_create();
            return new RTrees(ptr);
        }

        /// <summary>
        /// Loads and creates a serialized model from a file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public new static RTrees Load(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));
            IntPtr ptr = NativeMethods.ml_RTrees_load(filePath);
            return new RTrees(ptr);
        }

        /// <summary>
        /// Loads algorithm from a String.
        /// </summary>
        /// <param name="strModel">he string variable containing the model you want to load.</param>
        /// <returns></returns>
        public new static RTrees LoadFromString(string strModel)
        {
            if (strModel == null)
                throw new ArgumentNullException(nameof(strModel));
            IntPtr ptr = NativeMethods.ml_RTrees_loadFromString(strModel);
            return new RTrees(ptr);
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            ptrObj?.Dispose();
            ptrObj = null;
            base.DisposeManaged();
        }

        #endregion

        #region Properties

        /// <summary>
        /// If true then variable importance will be calculated and then 
        /// it can be retrieved by RTrees::getVarImportance. Default value is false.
        /// </summary>
        public bool CalculateVarImportance
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.ml_RTrees_getCalculateVarImportance(ptr) != 0;
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.ml_RTrees_setCalculateVarImportance(ptr, value ? 1 : 0);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// The size of the randomly selected subset of features at each tree node 
        /// and that are used to find the best split(s).
        /// </summary>
        public bool ActiveVarCount
        {
            get
            {
                ThrowIfDisposed();
                var res =NativeMethods.ml_RTrees_getActiveVarCount(ptr) != 0;
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.ml_RTrees_setActiveVarCount(ptr, value ? 1 : 0);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// The termination criteria that specifies when the training algorithm stops.
        /// </summary>
        public TermCriteria TermCriteria
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.ml_RTrees_getTermCriteria(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.ml_RTrees_setTermCriteria(ptr, value);
                GC.KeepAlive(this);
            }
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
            ThrowIfDisposed();
            IntPtr p = NativeMethods.ml_RTrees_getVarImportance(ptr);
            GC.KeepAlive(this);
            return new Mat(p);
        }

        #endregion

        internal new class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.ml_Ptr_RTrees_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.ml_Ptr_RTrees_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
