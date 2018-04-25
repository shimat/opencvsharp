using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Tracking
{
    /// <inheritdoc />
    /// <summary>
    /// Median Flow tracker implementation.
    /// </summary>
    /// <remarks> 
    /// The tracker is suitable for very smooth and predictable movements when object is visible throughout the 
    /// whole sequence.It's quite and accurate for this type of problems (in particular, it was shown 
    /// by authors to outperform MIL). During the implementation period the code at [http://www.aonsquared.co.uk/node/5],
    ///  the courtesy of the author Arthur Amarra, was used for the reference purpose.
    /// </remarks>
    public class TrackerMedianFlow : Tracker
    {
        /// <summary>
        /// 
        /// </summary>
        protected TrackerMedianFlow(IntPtr p)
            : base(new Ptr(p))
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <returns></returns>
        public static TrackerMedianFlow Create()
        {
            IntPtr p = NativeMethods.tracking_TrackerMedianFlow_create1();
            return new TrackerMedianFlow(p);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameters">MedianFlow parameters</param>
        /// <returns></returns>
        public static TrackerMedianFlow Create(Params parameters)
        {
            unsafe
            {
                IntPtr p = NativeMethods.tracking_TrackerMedianFlow_create2(&parameters);
                return new TrackerMedianFlow(p);
            }
        }
        
        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.tracking_Ptr_TrackerMedianFlow_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.tracking_Ptr_TrackerMedianFlow_delete(ptr);
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
            /// square root of number of keypoints used; increase it to trade accurateness for speed
            /// </summary>
            public int PointsInGrid;

            /// <summary>
            /// window size parameter for Lucas-Kanade optical flow
            /// </summary>
            public Size WinSize;

            /// <summary>
            /// maximal pyramid level number for Lucas-Kanade optical flow
            /// </summary>
            public int MaxLevel; 

            /// <summary>
            /// termination criteria for Lucas-Kanade optical flow
            /// </summary>
            public TermCriteria TermCriteria;

            /// <summary>
            /// window size around a point for normalized cross-correlation check
            /// </summary>
            public Size WinSizeNCC; 

            /// <summary>
            /// criterion for loosing the tracked object
            /// </summary>
            public double MaxMedianLengthOfDisplacementDifference;
        }
    }
}