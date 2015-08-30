using System;

namespace OpenCvSharp.ML
{
#if LANG_JP
    /// <summary>
    /// ML 統計モデルのための基本クラス
    /// </summary>
#else
    /// <summary>
    /// Base class for statistical models in ML
    /// </summary>
#endif
    public abstract class StatModel : Algorithm
    {
        #region Init and Disposal

#if LANG_JP
    /// <summary>
    /// 初期化
    /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        protected StatModel()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the number of variables in training samples
        /// </summary>
        /// <returns></returns>
        public virtual int GetVarCount()
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            return NativeMethods.ml_StatModel_getVarCount(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual new bool Empty()
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            return NativeMethods.ml_StatModel_empty(ptr) != 0;
        }

        /// <summary>
        /// Returns true if the model is trained
        /// </summary>
        /// <returns></returns>
        public virtual bool IsTrained()
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            return NativeMethods.ml_StatModel_isTrained(ptr) != 0;
        }

        /// <summary>
        /// Returns true if the model is classifier
        /// </summary>
        /// <returns></returns>
        public virtual bool IsClassifier()
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            return NativeMethods.ml_StatModel_isClassifier(ptr) != 0;
        }

        /// <summary>
        /// Trains the statistical model
        /// </summary>
        /// <param name="trainData">training data that can be loaded from file using TrainData::loadFromCSV 
        /// or created with TrainData::create.</param>
        /// <param name="flags"> optional flags, depending on the model. Some of the models can be updated with the 
        /// new training samples, not completely overwritten (such as NormalBayesClassifier or ANN_MLP).</param>
        /// <returns></returns>
        public virtual bool Train(TrainData trainData, int flags = 0)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Trains the statistical model
        /// </summary>
        /// <param name="samples">training samples</param>
        /// <param name="layout">SampleTypes value</param>
        /// <param name="responses">vector of responses associated with the training samples.</param>
        /// <returns></returns>
        public virtual bool Train(InputArray samples, SampleTypes layout, InputArray responses)
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            if (samples == null) 
                throw new ArgumentNullException("samples");
            if (responses == null)
                throw new ArgumentNullException("responses");
            samples.ThrowIfDisposed();
            responses.ThrowIfDisposed();

            int ret = NativeMethods.ml_StatModel_train2(ptr, samples.CvPtr, (int)layout, responses.CvPtr);
            GC.KeepAlive(samples);
            GC.KeepAlive(responses);
            return ret != 0;
        }

        /// <summary>
        /// Computes error on the training or test dataset
        /// </summary>
        /// <param name="data">the training data</param>
        /// <param name="test">if true, the error is computed over the test subset of the data, 
        /// otherwise it's computed over the training subset of the data. Please note that if you 
        /// loaded a completely different dataset to evaluate already trained classifier, you will 
        /// probably want not to set the test subset at all with TrainData::setTrainTestSplitRatio 
        /// and specify test=false, so that the error is computed for the whole new set. Yes, this 
        /// sounds a bit confusing.</param>
        /// <param name="resp">the optional output responses.</param>
        /// <returns></returns>
        public virtual float CalcError(TrainData data, bool test, OutputArray resp)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Predicts response(s) for the provided sample(s)
        /// </summary>
        /// <param name="samples">The input samples, floating-point matrix</param>
        /// <param name="results">The optional output matrix of results.</param>
        /// <param name="flags">The optional flags, model-dependent.</param>
        /// <returns></returns>
        public virtual float Predict(InputArray samples, OutputArray results = null, Flags flags = 0)
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            if (samples == null)
                throw new ArgumentNullException("samples");
            samples.ThrowIfDisposed();
            if (results!=null)
                results.ThrowIfNotReady();

            float ret = NativeMethods.ml_StatModel_predict(
                ptr, samples.CvPtr, Cv2.ToPtr(results), (int)flags);
            
            GC.KeepAlive(samples);
            if (results != null)
                results.Fix();
            return ret;
        }

        #endregion

        #region Types

        /// <summary>
        /// Predict options
        /// </summary>
        [FlagsAttribute]
        public enum Flags
        {
#pragma warning disable 1591
            UpdateModel = 1,
            /// <summary>
            /// makes the method return the raw results (the sum), not the class label
            /// </summary>
            RawOutput = 1, 
            CompressedInput = 2,
            PreprocessedInput = 4
#pragma warning restore 1591
        }

        #endregion
    }
}
