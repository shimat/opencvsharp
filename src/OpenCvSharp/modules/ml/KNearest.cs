using System;

namespace OpenCvSharp.ML
{
#if LANG_JP
    /// <summary>
    /// K近傍法モデルクラス
    /// </summary>
#else
	/// <summary>
    /// K nearest neighbors classifier
    /// </summary>
#endif
    public class KNearest : StatModel
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;
        private Ptr<KNearest> ptrObj;

        #region Init and Disposal

        /// <summary>
        /// Creates instance by raw pointer cv::ml::KNearest*
        /// </summary>
        protected KNearest(IntPtr p)
        {
            ptrObj = new Ptr<KNearest>(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates the empty model
        /// </summary>
        /// <returns></returns>
        public static KNearest Create()
	    {
            IntPtr ptr = NativeMethods.ml_KNearest_create();
            return new KNearest(ptr);
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
        /// Default number of neighbors to use in predict method.
        /// </summary>
        public int DefaultK
        {
            get { return NativeMethods.ml_KNearest_getDefaultK(ptr); }
            set { NativeMethods.ml_KNearest_setDefaultK(ptr, value); }
        }

        /// <summary>
        /// Whether classification or regression model should be trained.
        /// </summary>
        public new bool IsClassifier
        {
            get { return NativeMethods.ml_KNearest_getIsClassifier(ptr) != 0; }
            set { NativeMethods.ml_KNearest_setIsClassifier(ptr, value ? 1 : 0); }
        }

        /// <summary>
        /// Parameter for KDTree implementation
        /// </summary>
        public int Emax
        {
            get { return NativeMethods.ml_KNearest_getEmax(ptr); }
            set { NativeMethods.ml_KNearest_setEmax(ptr, value); }
        }

        /// <summary>
        /// Algorithm type, one of KNearest::Types.
        /// </summary>
        public Types AlgorithmType
        {
            get { return (Types)NativeMethods.ml_KNearest_getAlgorithmType(ptr); }
            set { NativeMethods.ml_KNearest_setAlgorithmType(ptr, (int)value); }
        }

        #endregion

        #region Methods

	    /// <summary>
	    /// Finds the neighbors and predicts responses for input vectors.
	    /// </summary>
	    /// <param name="samples">Input samples stored by rows. 
	    /// It is a single-precision floating-point matrix of `[number_of_samples] * k` size.</param>
	    /// <param name="k">Number of used nearest neighbors. Should be greater than 1.</param>
	    /// <param name="results">Vector with results of prediction (regression or classification) for each 
	    /// input sample. It is a single-precision floating-point vector with `[number_of_samples]` elements.</param>
	    /// <param name="neighborResponses">neighborResponses Optional output values for corresponding neighbors. 
	    /// It is a single-precision floating-point matrix of `[number_of_samples] * k` size.</param>
	    /// <param name="dist">Optional output distances from the input vectors to the corresponding neighbors. 
	    /// It is a single-precision floating-point matrix of `[number_of_samples] * k` size.</param>
	    /// <returns></returns>
	    public float FindNearest(InputArray samples, int k, OutputArray results,
	        OutputArray neighborResponses = null, OutputArray dist = null)
	    {
	        if (disposed)
	            throw new ObjectDisposedException(GetType().Name);
	        if (samples == null)
	            throw new ArgumentNullException("samples");
	        if (results == null)
	            throw new ArgumentNullException("results");
	        samples.ThrowIfDisposed();
	        results.ThrowIfNotReady();

	        float ret = NativeMethods.ml_KNearest_findNearest(
	            samples.CvPtr, k, results.CvPtr, Cv2.ToPtr(neighborResponses), Cv2.ToPtr(dist));

            GC.KeepAlive(samples);
	        results.Fix();
            if (neighborResponses != null)
    	        neighborResponses.Fix();
	        if (dist != null)
                dist.Fix();
	        return ret;
	    }

	    #endregion

        #region Types

        /// <summary>
        /// Implementations of KNearest algorithm
        /// </summary>
        public enum Types
        {
#pragma warning disable 1591
            BruteForce = 1,
            KdTree = 2
#pragma warning restore 1591
        };

        #endregion
    }
}
