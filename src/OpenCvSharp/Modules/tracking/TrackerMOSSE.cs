using System;

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
            NativeMethods.HandleException(
                NativeMethods.tracking_TrackerMOSSE_create(out var p));
            return new TrackerMOSSE(p);
        }
        
        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                NativeMethods.HandleException(
                    NativeMethods.tracking_Ptr_TrackerMOSSE_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.HandleException(
                    NativeMethods.tracking_Ptr_TrackerMOSSE_delete(ptr));
                base.DisposeUnmanaged();
            }
        }
    }
}