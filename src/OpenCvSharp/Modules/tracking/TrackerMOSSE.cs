using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Tracking
{
    /// <inheritdoc />
    /// <summary>
    /// MOSSE tracker. 
    /// this tracker works with grayscale images, if passed bgr ones, they will get converted internally.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class TrackerMOSSE : Tracker
    {
        /// <summary>
        /// 
        /// </summary>
        protected TrackerMOSSE(IntPtr p)
            : base(new Ptr(p))
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <returns></returns>
        public static TrackerMOSSE Create()
        {
            IntPtr p = NativeMethods.tracking_TrackerMOSSE_create();
            return new TrackerMOSSE(p);
        }
        
        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.tracking_Ptr_TrackerMOSSE_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.tracking_Ptr_TrackerMOSSE_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}