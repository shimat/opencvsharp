using System;

namespace OpenCvSharp.ML
{
	/// <summary>
    /// Implements Logistic Regression classifier.
    /// </summary>
	public class LogisticRegression : StatModel
	{
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;
        private Ptr<LogisticRegression> ptrObj;

        #region Init and Disposal

        /// <summary>
        /// Creates instance by raw pointer cv::ml::LogisticRegression*
        /// </summary>
        protected LogisticRegression(IntPtr p)
        {
            ptrObj = new Ptr<LogisticRegression>(p);
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
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
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
            if (disposed)
	            throw new NotImplementedException(GetType().Name);
            if (samples == null)
                throw new ArgumentNullException("samples");
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
            if (disposed)
                throw new NotImplementedException(GetType().Name);

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
    }
}