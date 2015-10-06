using System;

namespace OpenCvSharp.ML
{
#if LANG_JP
    /// <summary>
    /// MLPモデルクラス
    /// </summary>
#else
	/// <summary>
    /// Artificial Neural Networks - Multi-Layer Perceptrons.
    /// </summary>
#endif
	public class ANN_MLP : StatModel
	{
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;
        private Ptr<ANN_MLP> ptrObj;

        #region Init and Disposal
        /// <summary>
        /// Creates instance by raw pointer cv::ml::ANN_MLP*
        /// </summary>
        protected ANN_MLP(IntPtr p)
            : base()
        {
            ptrObj = new Ptr<ANN_MLP>(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates the empty model.
        /// </summary>
        /// <returns></returns>
        public static ANN_MLP Create()
	    {
            IntPtr ptr = NativeMethods.ml_ANN_MLP_create();
            return new ANN_MLP(ptr);
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
        /// Termination criteria of the training algorithm.
        /// </summary>
        public TermCriteria TermCriteria
        {
            get { return NativeMethods.ml_ANN_MLP_getTermCriteria(ptr); }
            set { NativeMethods.ml_ANN_MLP_setTermCriteria(ptr, value); }
        }

        /// <summary>
        /// Strength of the weight gradient term.
        /// The recommended value is about 0.1. Default value is 0.1.
        /// </summary>
        public double BackpropWeightScale
        {
            get { return NativeMethods.ml_ANN_MLP_getBackpropWeightScale(ptr); }
            set { NativeMethods.ml_ANN_MLP_setBackpropWeightScale(ptr, value); }
        }

        /// <summary>
        /// Strength of the momentum term (the difference between weights on the 2 previous iterations).
        /// This parameter provides some inertia to smooth the random fluctuations of the weights. 
        /// It can vary from 0 (the feature is disabled) to 1 and beyond. The value 0.1 or 
        /// so is good enough. Default value is 0.1.
        /// </summary>
        public double BackpropMomentumScale
        {
            get { return NativeMethods.ml_ANN_MLP_getBackpropMomentumScale(ptr); }
            set { NativeMethods.ml_ANN_MLP_setBackpropMomentumScale(ptr, value); }
        }

        /// <summary>
        /// Initial value Delta_0 of update-values Delta_{ij}. Default value is 0.1.
        /// </summary>
// ReSharper disable once InconsistentNaming
        public double RpropDW0
        {
            get { return NativeMethods.ml_ANN_MLP_getRpropDW0(ptr); }
            set { NativeMethods.ml_ANN_MLP_setRpropDW0(ptr, value); }
        }

        /// <summary>
        /// Increase factor eta^+.
        /// It must be &gt;1. Default value is 1.2.
        /// </summary>
// ReSharper disable once InconsistentNaming
        public double RpropDWPlus
        {
            get { return NativeMethods.ml_ANN_MLP_getRpropDWPlus(ptr); }
            set { NativeMethods.ml_ANN_MLP_setRpropDWPlus(ptr, value); }
        }

        /// <summary>
        /// Decrease factor eta^-.
        /// It must be \&gt;1. Default value is 0.5.
        /// </summary>
// ReSharper disable once InconsistentNaming
        public double RpropDWMinus
        {
            get { return NativeMethods.ml_ANN_MLP_getRpropDWPlus(ptr); }
            set { NativeMethods.ml_ANN_MLP_setRpropDWPlus(ptr, value); }
        }

        /// <summary>
        /// Update-values lower limit Delta_{min}.
        /// It must be positive. Default value is FLT_EPSILON.
        /// </summary>
// ReSharper disable once InconsistentNaming
        public double RpropDWMin
        {
            get { return NativeMethods.ml_ANN_MLP_getRpropDWMin(ptr); }
            set { NativeMethods.ml_ANN_MLP_setRpropDWMin(ptr, value); }
        }

        /// <summary>
        /// Update-values upper limit Delta_{max}.
        /// It must be &gt;1. Default value is 50.
        /// </summary>
// ReSharper disable once InconsistentNaming
        public double RpropDWMax
        {
            get { return NativeMethods.ml_ANN_MLP_getRpropDWMax(ptr); }
            set { NativeMethods.ml_ANN_MLP_setRpropDWMax(ptr, value); }
        }

        #endregion

		#region Methods

        #endregion

        #region Types

        /// <summary>
        /// possible activation functions
        /// </summary>
        public enum ActivationFunctions
        {
            /// <summary>
            /// Identity function: $f(x)=x
            /// </summary>
            Identity = 0,

            /// <summary>
            /// Symmetrical sigmoid: f(x)=\beta*(1-e^{-\alpha x})/(1+e^{-\alpha x}
            /// </summary>
            SigmoidSym = 1,

            /// <summary>
            /// Gaussian function: f(x)=\beta e^{-\alpha x*x}
            /// </summary>
            Gaussian = 2
        }

        /// <summary>
        /// Train options
        /// </summary>
        [Flags]
        public enum TrainFlags
        {
            /// <summary>
            /// Update the network weights, rather than compute them from scratch. 
            /// In the latter case the weights are initialized using the Nguyen-Widrow algorithm.
            /// </summary>
            UpdateWeights = 1,

            /*  */
            /// <summary>
            /// Do not normalize the input vectors. 
            /// If this flag is not set, the training algorithm normalizes each input feature 
            /// independently, shifting its mean value to 0 and making the standard deviation 
            /// equal to 1. If the network is assumed to be updated frequently, the new 
            /// training data could be much different from original one. In this case, 
            /// you should take care of proper normalization.
            /// </summary>
            NoInputScale = 2,

            /// <summary>
            /// Do not normalize the output vectors. If the flag is not set, 
            /// the training algorithm normalizes each output feature independently, 
            /// by transforming it to the certain range depending on the used activation function.
            /// </summary>
            NoOutputScale = 4
        }

        /// <summary>
        /// Available training methods
        /// </summary>
        public enum TrainingMethods
        {
            /// <summary>
            /// The back-propagation algorithm.
            /// </summary>
            BackProp = 0, 

            /// <summary>
            /// The RPROP algorithm. See @cite RPROP93 for details.
            /// </summary>
            RProp = 1  
        }

        #endregion
    }
}