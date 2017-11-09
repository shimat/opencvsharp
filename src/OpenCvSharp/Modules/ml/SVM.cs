using System;

namespace OpenCvSharp.ML
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
    /// SVM model classifier
    /// </summary>
#else
    /// <summary>
    /// Support Vector Machines
    /// </summary>
#endif

    public class SVM : StatModel
    {
        private Ptr ptrObj;

        #region Init and Disposal

        /// <summary>
        /// Creates instance by raw pointer cv::ml::SVM*
        /// </summary>
        protected SVM(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates empty model.
        /// Use StatModel::Train to train the model. 
        /// Since %SVM has several parameters, you may want to find the best 
        /// parameters for your problem, it can be done with SVM::TrainAuto.
        /// </summary>
        /// <returns></returns>
        public static SVM Create()
        {
            IntPtr ptr = NativeMethods.ml_SVM_create();
            return new SVM(ptr);
        }

        /// <summary>
        /// Loads and creates a serialized svm from a file.
        /// Use SVM::save to serialize and store an SVM to disk.
        /// Load the SVM from this file again, by calling this function with the path to the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static SVM Load(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));
            IntPtr ptr = NativeMethods.ml_SVM_load(filePath);
            return new SVM(ptr);
        }

        /// <summary>
        /// Loads algorithm from a String.
        /// </summary>
        /// <param name="strModel">The string variable containing the model you want to load.</param>
        /// <returns></returns>
        public static SVM LoadFromString(string strModel)
        {
            if (strModel == null)
                throw new ArgumentNullException(nameof(strModel));
            IntPtr ptr = NativeMethods.ml_SVM_loadFromString(strModel);
            return new SVM(ptr);
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
        /// Type of a %SVM formulation. 
        /// Default value is SVM::C_SVC.
        /// </summary>
        public Types Type
        {
            get
            {
                var res = (Types)NativeMethods.ml_SVM_getType(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.ml_SVM_setType(ptr, (int)value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Parameter gamma of a kernel function.
        /// For SVM::POLY, SVM::RBF, SVM::SIGMOID or SVM::CHI2. Default value is 1. 
        /// </summary>
        public double Gamma
        {
            get
            {
                var res = NativeMethods.ml_SVM_getGamma(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.ml_SVM_setGamma(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Parameter coef0 of a kernel function.
        /// For SVM::POLY or SVM::SIGMOID. Default value is 0.
        /// </summary>
        public double Coef0
        {
            get
            {
                var res = NativeMethods.ml_SVM_getCoef0(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.ml_SVM_setCoef0(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Parameter degree of a kernel function.
        /// For SVM::POLY. Default value is 0.
        /// </summary>
        public double Degree
        {
            get
            {
                var res = NativeMethods.ml_SVM_getDegree(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.ml_SVM_setDegree(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Parameter C of a %SVM optimization problem.
        /// For SVM::C_SVC, SVM::EPS_SVR or SVM::NU_SVR. Default value is 0.
        /// </summary>
        public double C
        {
            get
            {
                var res = NativeMethods.ml_SVM_getC(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.ml_SVM_setC(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Parameter nu of a %SVM optimization problem.
        /// For SVM::NU_SVC, SVM::ONE_CLASS or SVM::NU_SVR. Default value is 0.
        /// </summary>
        public double Nu
        {
            get
            {
                var res = NativeMethods.ml_SVM_getNu(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.ml_SVM_setNu(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Parameter epsilon of a %SVM optimization problem.
        /// For SVM::EPS_SVR. Default value is 0.
        /// </summary>
        public double P
        {
            get
            {
                var res = NativeMethods.ml_SVM_getP(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.ml_SVM_setP(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Optional weights in the SVM::C_SVC problem, assigned to particular classes.
        /// </summary>
        /// <remarks>
        /// They are multiplied by _C_ so the parameter _C_ of class _i_ becomes `classWeights(i) * C`. 
        /// Thus these weights affect the misclassification penalty for different classes. 
        /// The larger weight, the larger penalty on misclassification of data from the 
        /// corresponding class. Default value is empty Mat.
        /// </remarks>
        public Mat ClassWeights
        {
            get
            {
                IntPtr p = NativeMethods.ml_SVM_getClassWeights(ptr);
                GC.KeepAlive(this);
                return new Mat(p);
            }
            set
            {
                NativeMethods.ml_SVM_setClassWeights(ptr, value.CvPtr);
                GC.KeepAlive(this);
                GC.KeepAlive(value);
            }
        }

        /// <summary>
        /// Termination criteria of the iterative SVM training procedure 
        /// which solves a partial case of constrained quadratic optimization problem.
        /// </summary>
        /// <remarks>
        /// You can specify tolerance and/or the maximum number of iterations. 
        /// Default value is `TermCriteria( TermCriteria::MAX_ITER + TermCriteria::EPS, 1000, FLT_EPSILON )`;
        /// </remarks>
        public TermCriteria TermCriteria
        {
            get
            {
                var res = NativeMethods.ml_SVM_getTermCriteria(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.ml_SVM_setTermCriteria(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Type of a %SVM kernel. See SVM::KernelTypes. Default value is SVM::RBF.
        /// </summary>
        public KernelTypes KernelType
        {
            get
            {
                var res = (KernelTypes)NativeMethods.ml_SVM_getKernelType(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.ml_SVM_setKernel(ptr, (int)value);
                GC.KeepAlive(this);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize with custom kernel.
        /// </summary>
        /// <param name="kernel"></param>
        public void SetCustomKernel(Kernel kernel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Trains an %SVM with optimal parameters.
        /// </summary>
        /// <param name="data">the training data that can be constructed using 
        /// TrainData::create or TrainData::loadFromCSV.</param>
        /// <param name="kFold">Cross-validation parameter. The training set is divided into kFold subsets. 
        /// One subset is used to test the model, the others form the train set. So, the %SVM algorithm is 
        /// executed kFold times.</param>
        /// <param name="cGrid">grid for C</param>
        /// <param name="gammaGrid">grid for gamma</param>
        /// <param name="pGrid">grid for p</param>
        /// <param name="nuGrid">grid for nu</param>
        /// <param name="coeffGrid">grid for coeff</param>
        /// <param name="degreeGrid">grid for degree</param>
        /// <param name="balanced">If true and the problem is 2-class classification then the method creates 
        /// more balanced cross-validation subsets that is proportions between classes in subsets are close 
        /// to such proportion in the whole train dataset.</param>
        /// <returns></returns>
        public bool TrainAuto(TrainData data, int kFold = 10,
            ParamGrid? cGrid = null,
            ParamGrid? gammaGrid = null,
            ParamGrid? pGrid = null,
            ParamGrid? nuGrid = null,
            ParamGrid? coeffGrid = null,
            ParamGrid? degreeGrid = null,
            bool balanced = false)
        {
            throw new NotImplementedException();
            /*
            var cGridValue = cGrid.GetValueOrDefault(GetDefaultGrid(ParamTypes.C));
            var gammaGridValue = gammaGrid.GetValueOrDefault(GetDefaultGrid(ParamTypes.Gamma));
            var pGridValue = pGrid.GetValueOrDefault(GetDefaultGrid(ParamTypes.P));
            var nuGridValue = nuGrid.GetValueOrDefault(GetDefaultGrid(ParamTypes.Nu));
            var coeffGridValue = coeffGrid.GetValueOrDefault(GetDefaultGrid(ParamTypes.Coef));
            var degreeGridValue = degreeGrid.GetValueOrDefault(GetDefaultGrid(ParamTypes.Degree));*/
        }

        /// <summary>
        /// Retrieves all the support vectors
        /// </summary>
        /// <returns></returns>
        public Mat GetSupportVectors()
        {
            ThrowIfDisposed();
            IntPtr p = NativeMethods.ml_SVM_getSupportVectors(ptr);
            GC.KeepAlive(this);
            return new Mat(p);
        }

        /// <summary>
        /// Retrieves the decision function
        /// </summary>
        /// <param name="i">i the index of the decision function. 
        /// If the problem solved is regression, 1-class or 2-class classification, then 
        /// there will be just one decision function and the index should always be 0. 
        /// Otherwise, in the case of N-class classification, there will be N(N-1)/2 decision functions.</param>
        /// <param name="alpha">alpha the optional output vector for weights, corresponding to 
        /// different support vectors. In the case of linear %SVM all the alpha's will be 1's.</param>
        /// <param name="svidx">the optional output vector of indices of support vectors 
        /// within the matrix of support vectors (which can be retrieved by SVM::getSupportVectors). 
        /// In the case of linear %SVM each decision function consists of a single "compressed" support vector.</param>
        /// <returns></returns>
        public double GetDecisionFunction(int i, OutputArray alpha, OutputArray svidx)
        {
            ThrowIfDisposed();
            if (alpha == null)
                throw new ArgumentNullException(nameof(alpha));
            if (svidx == null)
                throw new ArgumentNullException(nameof(svidx));

            alpha.ThrowIfNotReady();
            svidx.ThrowIfNotReady();
            double ret = NativeMethods.ml_SVM_getDecisionFunction(ptr, i, alpha.CvPtr, svidx.CvPtr);
            alpha.Fix();
            svidx.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(alpha);
            GC.KeepAlive(svidx);
            return ret;
        }

        /// <summary>
        /// Generates a grid for SVM parameters.
        /// </summary>
        /// <param name="paramId">SVM parameters IDs that must be one of the SVM::ParamTypes. 
        /// The grid is generated for the parameter with this ID.</param>
        /// <returns></returns>
        public static ParamGrid GetDefaultGrid(ParamTypes paramId)
        {
            return NativeMethods.ml_SVM_getDefaultGrid((int)paramId);
        }

        #endregion

        #region Types

        /// <summary>
        /// 
        /// </summary>
        public class Kernel
        {
            /// <summary>
            /// 
            /// </summary>
            public Kernel()
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// SVM type
        /// </summary>
        public enum Types
        {
            /// <summary>
            /// C-Support Vector Classification. n-class classification (n \f$\geq\f$ 2), 
            /// allows imperfect separation of classes with penalty multiplier C for outliers.
            /// </summary>
            CSvc = 100,

            /// <summary>
            /// nu-Support Vector Classification. n-class classification with possible
            /// imperfect separation. Parameter \f$\nu\f$ (in the range 0..1, the larger 
            /// the value, the smoother the decision boundary) is used instead of C.
            /// </summary>
            NuSvc = 101,

            /// <summary>
            /// Distribution Estimation (One-class %SVM). All the training data are from
            /// the same class, %SVM builds a boundary that separates the class from the 
            /// rest of the feature space.
            /// </summary>
            OneClass = 102,

            /// <summary>
            /// epsilon-Support Vector Regression. 
            /// The distance between feature vectors from the training set and the fitting 
            /// hyper-plane must be less than p. For outliers the penalty multiplier C is used.
            /// </summary>
            EpsSvr = 103,

            /// <summary>
            /// nu-Support Vector Regression. \f$\nu\f$ is used instead of p.
            /// See @cite LibSVM for details.
            /// </summary>
            NuSvr = 104
        }

        /// <summary>
        /// SVM kernel type
        /// </summary>
        public enum KernelTypes
        {
            /// <summary>
            /// Returned by SVM::getKernelType in case when custom kernel has been set
            /// </summary>
            Custom = -1,

            /// <summary>
            /// Linear kernel. No mapping is done, linear discrimination (or regression) is
            /// done in the original feature space. It is the fastest option. \f$K(x_i, x_j) = x_i^T x_j\f$.
            /// </summary>
            Linear = 0,

            /// <summary>
            /// Polynomial kernel:
            /// \f$K(x_i, x_j) = (\gamma x_i^T x_j + coef0)^{degree}, \gamma &gt; 0\f$.
            /// </summary>
            Poly = 1,

            /// <summary>
            /// Radial basis function (RBF), a good choice in most cases.
            /// \f$K(x_i, x_j) = e^{-\gamma ||x_i - x_j||^2}, \gamma > 0\f$.
            /// </summary>
            Rbf = 2,

            /// <summary>
            /// Sigmoid kernel: 
            /// \f$K(x_i, x_j) = \tanh(\gamma x_i^T x_j + coef0)\f$.
            /// </summary>
            Sigmoid = 3,

            /// <summary>
            /// Exponential Chi2 kernel, similar to the RBF kernel:
            /// \f$K(x_i, x_j) = e^{-\gamma \chi^2(x_i,x_j)}, \chi^2(x_i,x_j) = (x_i-x_j)^2/(x_i+x_j), \gamma &gt; 0\f$. 
            /// </summary>
            Chi2 = 4,

            /// <summary>
            /// Histogram intersection kernel. 
            /// A fast kernel. \f$K(x_i, x_j) = min(x_i,x_j)\f$. 
            /// </summary>
            Inter = 5
        }

        /// <summary>
        /// SVM params type
        /// </summary>
        public enum ParamTypes
        {
#pragma warning disable 1591
            C = 0,
            Gamma = 1,
            P = 2,
            Nu = 3,
            Coef = 4,
            Degree = 5
#pragma warning restore 1591
        };

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.ml_Ptr_SVM_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.ml_Ptr_SVM_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
