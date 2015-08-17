using System;

namespace OpenCvSharp.ML
{
	/// <summary>
    /// Boosted tree classifier derived from DTrees
    /// </summary>
	public class Boost : DTrees
	{
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;
        private Ptr<Boost> ptrObj;

		#region Init and Disposal

        /// <summary>
        /// Creates instance by raw pointer cv::ml::Boost*
        /// </summary>
        protected Boost(IntPtr p)
            : base()
        {
            ptrObj = new Ptr<Boost>(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates the empty model.
        /// </summary>
        /// <returns></returns>
        public static new Boost Create()
	    {
            IntPtr ptr = NativeMethods.ml_Boost_create();
            return new Boost(ptr);
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
        /// Type of the boosting algorithm.
        /// See Boost::Types. Default value is Boost::REAL.
        /// </summary>
        public Types BoostType
        {
            get { return (Types)NativeMethods.ml_Boost_getBoostType(ptr); }
            set { NativeMethods.ml_Boost_setBoostType(ptr, (int)value); }
        }

        /// <summary>
        /// The number of weak classifiers. 
        /// Default value is 100.
        /// </summary>
        public int WeakCount
        {
            get { return NativeMethods.ml_Boost_getWeakCount(ptr); }
            set { NativeMethods.ml_Boost_setWeakCount(ptr, value); }
        }

        /// <summary>
        /// A threshold between 0 and 1 used to save computational time. 
        /// Samples with summary weight \f$\leq 1 - weight_trim_rate
        /// do not participate in the *next* iteration of training. 
        /// Set this parameter to 0 to turn off this functionality. Default value is 0.95.
        /// </summary>
        public double WeightTrimRate
        {
            get { return NativeMethods.ml_Boost_getWeightTrimRate(ptr); }
            set { NativeMethods.ml_Boost_setWeightTrimRate(ptr, value); }
        }

        #endregion

        #region Methods
		#endregion

        #region Types

        /// <summary>
        /// Boosting type.
        /// Gentle AdaBoost and Real AdaBoost are often the preferable choices.
        /// </summary>
        public enum Types
        {
            /// <summary>
            /// Discrete AdaBoost.
            /// </summary>
            Discrete = 0, 

            /// <summary>
            /// Real AdaBoost. It is a technique that utilizes confidence-rated predictions
            /// and works well with categorical data.
            /// </summary>
            Real = 1, 

            /// <summary>
            /// LogitBoost. It can produce good regression fits.
            /// </summary>
            Logit = 2, 

            /// <summary>
            /// Gentle AdaBoost. It puts less weight on outlier data points and for that
            /// reason is often good with regression data.
            /// </summary>
            Gentle = 3 
        };

        #endregion
    }
}
