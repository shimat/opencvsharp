using System;

namespace OpenCvSharp.ML
{
    /// <summary>
    /// Implements Logistic Regression classifier.
    /// </summary>
    public class LogisticRegression : StatModel
    {
        private Ptr ptrObj;

        #region Init and Disposal

        /// <summary>
        /// Creates instance by raw pointer cv::ml::LogisticRegression*
        /// </summary>
        protected LogisticRegression(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates the empty model.
        /// </summary>
        /// <returns></returns>
        public static LogisticRegression Create()
        {
            IntPtr ptr = NativeMethods.ml_LogisticRegression_create();
            return new LogisticRegression(ptr);
        }

        /// <summary>
        /// Loads and creates a serialized model from a file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static LogisticRegression Load(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));
            IntPtr ptr = NativeMethods.ml_LogisticRegression_load(filePath);
            return new LogisticRegression(ptr);
        }

        /// <summary>
        /// Loads algorithm from a String.
        /// </summary>
        /// <param name="strModel">he string variable containing the model you want to load.</param>
        /// <returns></returns>
        public static LogisticRegression LoadFromString(string strModel)
        {
            if (strModel == null)
                throw new ArgumentNullException(nameof(strModel));
            IntPtr ptr = NativeMethods.ml_LogisticRegression_loadFromString(strModel);
            return new LogisticRegression(ptr);
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
        /// Learning rate
        /// </summary>
        public double LearningRate
        {
            get { return NativeMethods.ml_LogisticRegression_getLearningRate(ptr); }
            set { NativeMethods.ml_LogisticRegression_setLearningRate(ptr, value); }
        }

        /// <summary>
        /// Number of iterations.
        /// </summary>
        public int Iterations
        {
            get { return NativeMethods.ml_LogisticRegression_getIterations(ptr); }
            set { NativeMethods.ml_LogisticRegression_setIterations(ptr, value); }
        }

        /// <summary>
        /// Kind of regularization to be applied. See LogisticRegression::RegKinds.
        /// </summary>
        public RegKinds Regularization
        {
            get { return (RegKinds)NativeMethods.ml_LogisticRegression_getRegularization(ptr); }
            set { NativeMethods.ml_LogisticRegression_setRegularization(ptr, (int)value); }
        }

        /// <summary>
        /// Kind of training method used. See LogisticRegression::Methods.
        /// </summary>
        public Methods TrainMethod
        {
            get { return (Methods)NativeMethods.ml_LogisticRegression_getTrainMethod(ptr); }
            set { NativeMethods.ml_LogisticRegression_setTrainMethod(ptr, (int)value); }
        }

        /// <summary>
        /// Specifies the number of training samples taken in each step of Mini-Batch Gradient. 
        /// Descent. Will only be used if using LogisticRegression::MINI_BATCH training algorithm. 
        /// It has to take values less than the total number of training samples.
        /// </summary>
        public int MiniBatchSize
        {
            get { return NativeMethods.ml_LogisticRegression_getMiniBatchSize(ptr); }
            set { NativeMethods.ml_LogisticRegression_setMiniBatchSize(ptr, value); }
        }

        /// <summary>
        /// Termination criteria of the training algorithm.
        /// </summary>
        public TermCriteria TermCriteria
        {
            get { return NativeMethods.ml_LogisticRegression_getTermCriteria(ptr); }
            set { NativeMethods.ml_LogisticRegression_setTermCriteria(ptr, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Predicts responses for input samples and returns a float type.
        /// </summary>
        /// <param name="samples">The input data for the prediction algorithm. Matrix [m x n], 
        /// where each row contains variables (features) of one object being classified. 
        /// Should have data type CV_32F.</param>
        /// <param name="results">Predicted labels as a column matrix of type CV_32S.</param>
        /// <param name="flags">Not used.</param>
        /// <returns></returns>
        public float Predict(InputArray samples, OutputArray results = null, int flags = 0)
        {
            ThrowIfDisposed();
            if (samples == null)
                throw new ArgumentNullException(nameof(samples));
            samples.ThrowIfDisposed();
            if (results != null)
                results.ThrowIfNotReady();

            float ret = NativeMethods.ml_LogisticRegression_predict(ptr, samples.CvPtr, Cv2.ToPtr(results), flags);

            GC.KeepAlive(samples);
            if (results != null)
                results.Fix();

            return ret;
        }

        /// <summary>
        /// This function returns the trained paramters arranged across rows.
        ///  For a two class classifcation problem, it returns a row matrix. 
        /// It returns learnt paramters of the Logistic Regression as a matrix of type CV_32F.
        /// </summary>
        /// <returns></returns>
        public Mat GetLearntThetas()
        {
            ThrowIfDisposed();

            IntPtr p = NativeMethods.ml_LogisticRegression_get_learnt_thetas(ptr);
            return new Mat(p);
        }

        #endregion

        #region Types

        /// <summary>
        /// Regularization kinds
        /// </summary>
        public enum RegKinds
        {
            /// <summary>
            /// Regularization disabled
            /// </summary>
            RegDisable = -1,

            /// <summary>
            /// L1 norm
            /// </summary>
            RegL1 = 0,

            /// <summary>
            /// L2 norm
            /// </summary>
            RegL2 = 1
        }

        /// <summary>
        /// Training methods
        /// </summary>
        public enum Methods
        {
            /// <summary>
            /// 
            /// </summary>
            Batch = 0,

            /// <summary>
            /// Set MiniBatchSize to a positive integer when using this method.
            /// </summary>
            MiniBatch = 1
        }

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.ml_Ptr_LogisticRegression_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.ml_Ptr_LogisticRegression_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}