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
    // ReSharper disable once InconsistentNaming
    public class ANN_MLP : StatModel
    {
        private Ptr ptrObj;

        #region Init and Disposal
        /// <summary>
        /// Creates instance by raw pointer cv::ml::ANN_MLP*
        /// </summary>
        protected ANN_MLP(IntPtr p)
        {
            ptrObj = new Ptr(p);
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
        /// Loads and creates a serialized ANN from a file.
        /// Use ANN::save to serialize and store an ANN to disk.
        /// Load the ANN from this file again, by calling this function with the path to the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static ANN_MLP Load(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));
            IntPtr ptr = NativeMethods.ml_ANN_MLP_load(filePath);
            return new ANN_MLP(ptr);
        }

        /// <summary>
        /// Loads algorithm from a String.
        /// </summary>
        /// <param name="strModel">he string variable containing the model you want to load.</param>
        /// <returns></returns>
        public static ANN_MLP LoadFromString(string strModel)
        {
            if (strModel == null)
                throw new ArgumentNullException(nameof(strModel));
            IntPtr ptr = NativeMethods.ml_ANN_MLP_loadFromString(strModel);
            return new ANN_MLP(ptr);
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
        /// Termination criteria of the training algorithm.
        /// </summary>
        public TermCriteria TermCriteria
        {
            get
            {
                var res = NativeMethods.ml_ANN_MLP_getTermCriteria(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.ml_ANN_MLP_setTermCriteria(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Strength of the weight gradient term.
        /// The recommended value is about 0.1. Default value is 0.1.
        /// </summary>
        public double BackpropWeightScale
        {
            get
            {
                var res = NativeMethods.ml_ANN_MLP_getBackpropWeightScale(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.ml_ANN_MLP_setBackpropWeightScale(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Strength of the momentum term (the difference between weights on the 2 previous iterations).
        /// This parameter provides some inertia to smooth the random fluctuations of the weights. 
        /// It can vary from 0 (the feature is disabled) to 1 and beyond. The value 0.1 or 
        /// so is good enough. Default value is 0.1.
        /// </summary>
        public double BackpropMomentumScale
        {
            get
            {
                var res = NativeMethods.ml_ANN_MLP_getBackpropMomentumScale(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.ml_ANN_MLP_setBackpropMomentumScale(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Initial value Delta_0 of update-values Delta_{ij}. Default value is 0.1.
        /// </summary>
// ReSharper disable once InconsistentNaming
        public double RpropDW0
        {
            get
            {
                var res = NativeMethods.ml_ANN_MLP_getRpropDW0(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.ml_ANN_MLP_setRpropDW0(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Increase factor eta^+.
        /// It must be &gt;1. Default value is 1.2.
        /// </summary>
// ReSharper disable once InconsistentNaming
        public double RpropDWPlus
        {
            get
            {
                var res = NativeMethods.ml_ANN_MLP_getRpropDWPlus(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.ml_ANN_MLP_setRpropDWPlus(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Decrease factor eta^-.
        /// It must be \&gt;1. Default value is 0.5.
        /// </summary>
// ReSharper disable once InconsistentNaming
        public double RpropDWMinus
        {
            get
            {
                var res = NativeMethods.ml_ANN_MLP_getRpropDWPlus(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.ml_ANN_MLP_setRpropDWPlus(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Update-values lower limit Delta_{min}.
        /// It must be positive. Default value is FLT_EPSILON.
        /// </summary>
// ReSharper disable once InconsistentNaming
        public double RpropDWMin
        {
            get
            {
                var res = NativeMethods.ml_ANN_MLP_getRpropDWMin(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.ml_ANN_MLP_setRpropDWMin(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Update-values upper limit Delta_{max}.
        /// It must be &gt;1. Default value is 50.
        /// </summary>
// ReSharper disable once InconsistentNaming
        public double RpropDWMax
        {
            get
            {
                var res = NativeMethods.ml_ANN_MLP_getRpropDWMax(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.ml_ANN_MLP_setRpropDWMax(ptr, value);
                GC.KeepAlive(this);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Integer vector specifying the number of neurons in each layer including the input and output layers.
        /// The very first element specifies the number of elements in the input layer.
        /// The last element - number of elements in the output layer.Default value is empty Mat.
        /// </summary>
        /// <param name="layerSizes"></param>
        public virtual void SetLayerSizes(InputArray layerSizes)
        {
            ThrowIfDisposed();
            if (layerSizes == null)
                throw new ArgumentNullException(nameof(layerSizes));
            NativeMethods.ml_ANN_MLP_setLayerSizes(ptr, layerSizes.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(layerSizes);
        }

        /// <summary>
        /// Integer vector specifying the number of neurons in each layer including the input and output layers.
        /// The very first element specifies the number of elements in the input layer.
        /// The last element - number of elements in the output layer.
        /// </summary>
        /// <returns></returns>
        public virtual Mat GetLayerSizes()
        {
            ThrowIfDisposed();
            IntPtr p = NativeMethods.ml_ANN_MLP_getLayerSizes(ptr);
            GC.KeepAlive(this);
            return new Mat(p);
        }

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

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.ml_Ptr_ANN_MLP_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.ml_Ptr_ANN_MLP_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}