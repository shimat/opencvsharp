using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Tracking
{
    /// <inheritdoc />
    /// <summary>
    /// The MIL algorithm trains a classifier in an online manner to separate the object from the background.
    /// Multiple Instance Learning avoids the drift problem for a robust tracking.The implementation is based on @cite MIL.
    /// Original code can be found here [http://vision.ucsd.edu/~bbabenko/project_miltrack.shtml]
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class TrackerMIL : Tracker
    {
        /// <summary>
        /// 
        /// </summary>
        protected TrackerMIL(IntPtr p)
            : base(new Ptr(p))
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <returns></returns>
        public static TrackerMIL Create()
        {
            IntPtr p = NativeMethods.tracking_TrackerMIL_create1();
            return new TrackerMIL(p);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameters">MIL parameters</param>
        /// <returns></returns>
        public static TrackerMIL Create(Params parameters)
        {
            unsafe
            {
                IntPtr p = NativeMethods.tracking_TrackerMIL_create2(&parameters);
                return new TrackerMIL(p);
            }
        }
        
        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.tracking_Ptr_TrackerMIL_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.tracking_Ptr_TrackerMIL_delete(ptr);
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
            /// radius for gathering positive instances during init
            /// </summary>
            public float SamplerInitInRadius;

            /// <summary>
            /// # negative samples to use during init
            /// </summary>
            public int SamplerInitMaxNegNum;

            /// <summary>
            /// size of search window
            /// </summary>
            public float SamplerSearchWinSize;

            /// <summary>
            /// radius for gathering positive instances during tracking
            /// </summary>
            public float SamplerTrackInRadius;

            /// <summary>
            /// # positive samples to use during tracking
            /// </summary>
            public int SamplerTrackMaxPosNum;

            /// <summary>
            /// # negative samples to use during tracking
            /// </summary>
            public int SamplerTrackMaxNegNum;

            /// <summary>
            /// # features  
            /// </summary>
            public int FeatureSetNumFeatures; 
        }
    }
}