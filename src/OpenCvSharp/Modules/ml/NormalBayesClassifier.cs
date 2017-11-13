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
        private Ptr ptrObj;

        #region Init and Disposal

        /// <summary>
        /// Creates instance by raw pointer cv::ml::NormalBayesClassifier*
        /// </summary>
        protected NormalBayesClassifier(IntPtr p)
        {
            ptrObj = new Ptr(p);
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

        /// <summary>
        /// Loads and creates a serialized model from a file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static NormalBayesClassifier Load(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));
            IntPtr ptr = NativeMethods.ml_NormalBayesClassifier_load(filePath);
            return new NormalBayesClassifier(ptr);
        }

        /// <summary>
        /// Loads algorithm from a String.
        /// </summary>
        /// <param name="strModel">he string variable containing the model you want to load.</param>
        /// <returns></returns>
        public static NormalBayesClassifier LoadFromString(string strModel)
        {
            if (strModel == null)
                throw new ArgumentNullException(nameof(strModel));
            IntPtr ptr = NativeMethods.ml_NormalBayesClassifier_loadFromString(strModel);
            return new NormalBayesClassifier(ptr);
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
            ThrowIfDisposed();
            if (inputs == null)
                throw new ArgumentNullException(nameof(inputs));
            if (outputs == null)
                throw new ArgumentNullException(nameof(outputs));
            if (outputProbs == null)
                throw new ArgumentNullException(nameof(outputProbs));

            inputs.ThrowIfDisposed();
            outputs.ThrowIfNotReady();
            outputProbs.ThrowIfNotReady();

            float result = NativeMethods.ml_NormalBayesClassifier_predictProb(
                ptr, inputs.CvPtr, outputs.CvPtr, outputProbs.CvPtr, flags);
            outputs.Fix();
            outputProbs.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(inputs);
            GC.KeepAlive(outputs);
            GC.KeepAlive(outputProbs);
            return result;
        }

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.ml_Ptr_NormalBayesClassifier_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.ml_Ptr_NormalBayesClassifier_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
