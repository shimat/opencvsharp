using System;

namespace OpenCvSharp.ML
{
#if LANG_JP
    /// <summary>
    /// 正規分布データに対するベイズ分類器クラス
    /// </summary>
#else
	/// <summary>
    /// Bayes classifier for normally distributed data
    /// </summary>
#endif
    public class NormalBayesClassifier : StatModel
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;
        private Ptr<NormalBayesClassifier> ptrObj;

        #region Init and Disposal

        /// <summary>
        /// Creates instance by raw pointer cv::ml::NormalBayesClassifier*
        /// </summary>
        protected NormalBayesClassifier(IntPtr p)
        {
            ptrObj = new Ptr<NormalBayesClassifier>(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates empty model. 
        /// Use StatModel::train to train the model after creation.
        /// </summary>
        /// <returns></returns>
        public static NormalBayesClassifier Create()
	    {
            IntPtr ptr = NativeMethods.ml_NormalBayesClassifier_create();
            return new NormalBayesClassifier(ptr);
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
        #endregion

        #region Methods

        /// <summary>
        /// Predicts the response for sample(s).
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="outputs"></param>
        /// <param name="outputProbs"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        /// <remarks>
        /// The method estimates the most probable classes for input vectors. Input vectors (one or more)
        /// are stored as rows of the matrix inputs. In case of multiple input vectors, there should be one 
        /// output vector outputs. The predicted class for a single input vector is returned by the method. 
        /// The vector outputProbs contains the output probabilities corresponding to each element of result.
        /// </remarks>
	    public float PredictProb(InputArray inputs, OutputArray outputs,
	        OutputArray outputProbs, int flags = 0)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (inputs == null) 
                throw new ArgumentNullException("inputs");
            if (outputs == null)
                throw new ArgumentNullException("outputs");
            if (outputProbs == null)
                throw new ArgumentNullException("outputProbs");

            inputs.ThrowIfDisposed();
            outputs.ThrowIfNotReady();
            outputProbs.ThrowIfNotReady();

            float result = NativeMethods.ml_NormalBayesClassifier_predictProb(
                ptr, inputs.CvPtr, outputs.CvPtr, outputProbs.CvPtr, flags);
            outputs.Fix();
            outputProbs.Fix();
            GC.KeepAlive(inputs);
            return result;
        }

	    #endregion
    }
}
