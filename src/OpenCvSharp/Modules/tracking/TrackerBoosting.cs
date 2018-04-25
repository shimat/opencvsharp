using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Tracking
{
    /// <inheritdoc />
    /// <summary>
    /// This is a real-time object tracking based on a novel on-line version of the AdaBoost algorithm.
    /// The classifier uses the surrounding background as negative examples in update step to avoid the
    /// drifting problem.The implementation is based on @cite OLB.
    /// </summary>
    public class TrackerBoosting : Tracker
    {
        /// <summary>
        /// 
        /// </summary>
        protected TrackerBoosting(IntPtr p)
            : base(new Ptr(p)) 
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <returns></returns>
        public static TrackerBoosting Create()
        {
            IntPtr p = NativeMethods.tracking_TrackerBoosting_create1();
            return new TrackerBoosting(p);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameters">BOOSTING parameters</param>
        /// <returns></returns>
        public static TrackerBoosting Create(Params parameters)
        {
            unsafe
            {
                IntPtr p = NativeMethods.tracking_TrackerBoosting_create2(&parameters);
                return new TrackerBoosting(p);
            }
        }


        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.tracking_Ptr_TrackerBoosting_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.tracking_Ptr_TrackerBoosting_delete(ptr);
                base.DisposeUnmanaged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Params
        {
            /// <summary>
            /// the number of classifiers to use in a OnlineBoosting algorithm
            /// </summary>
            public int NumClassifiers; 

            /// <summary>
            /// search region parameters to use in a OnlineBoosting algorithm
            /// </summary>
            public float SamplerOverlap; 

            /// <summary>
            /// search region parameters to use in a OnlineBoosting algorithm
            /// </summary>
            public float SamplerSearchFactor; 

            /// <summary>
            /// the initial iterations
            /// </summary>
            public int IterationInit;

            /// <summary>
            /// # features
            /// </summary>
            public int FeatureSetNumFeatures;
        }
    }
}