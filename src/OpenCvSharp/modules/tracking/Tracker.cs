using System;

namespace OpenCvSharp.Tracking
{
    /// <summary>
    /// Base abstract class for the long-term tracker
    /// </summary>
    public class Tracker : Algorithm
    {
        /// <summary>
        /// cv::Ptr&lt;T&gt;
        /// </summary>
        private Ptr ptrObj;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected Tracker(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trackerType"></param>
        public static Tracker Create(TrackerTypes trackerType)
        {
            IntPtr ptr;
            switch (trackerType)
            {
                case TrackerTypes.Boosting:
                    ptr = NativeMethods.tracking_Tracker_create("BOOSTING");
                    break;
                case TrackerTypes.GOTURN:
                    ptr = NativeMethods.tracking_Tracker_create("GOTURN");
                    break;
                case TrackerTypes.TLD:
                    ptr = NativeMethods.tracking_Tracker_create("TLD");
                    break;
                case TrackerTypes.KCF:
                    ptr = NativeMethods.tracking_Tracker_create("KCF");
                    break;
                case TrackerTypes.MedianFlow:
                    ptr = NativeMethods.tracking_Tracker_create("MEDIANFLOW");
                    break;
                case TrackerTypes.MIL:
                    ptr = NativeMethods.tracking_Tracker_create("MIL");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(trackerType), trackerType, null);
            }

            return new Tracker(ptr);
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

        #region Methods

        /// <summary>
        /// Initialize the tracker with a know bounding box that surrounding the target
        /// </summary>
        /// <param name="image">The initial frame</param>
        /// <param name="boundingBox">The initial boundig box</param>
        /// <returns></returns>
        public bool Init(Mat image, Rect2d boundingBox)
        {
            ThrowIfDisposed();

            if (image == null)
                throw new ArgumentNullException(nameof(image));

            image.ThrowIfDisposed();
            var ret = NativeMethods.tracking_Tracker_init(this.ptr, image.CvPtr, boundingBox);
            GC.KeepAlive(image);

            return ret;
        }

        /// <summary>
        /// Update the tracker, find the new most likely bounding box for the target
        /// </summary>
        /// <param name="image">The current frame</param>
        /// <param name="boundingBox">The boundig box that represent the new target location, if true was returned, not modified otherwise</param>
        /// <returns>True means that target was located and false means that tracker cannot locate target in 
        /// current frame.Note, that latter *does not* imply that tracker has failed, maybe target is indeed 
        /// missing from the frame (say, out of sight)</returns>
        public bool Update(Mat image, ref Rect2d boundingBox)
        {
            ThrowIfDisposed();

            if (image == null)
                throw new ArgumentNullException(nameof(image));

            image.ThrowIfDisposed();
            var ret = NativeMethods.tracking_Tracker_update(this.ptr, image.CvPtr, ref boundingBox);
            GC.KeepAlive(image);

            return ret;
        }

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.tracking_Ptr_Tracker_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.tracking_Ptr_Tracker_delete(ptr);
                base.DisposeUnmanaged();
            }
        }

    }
}
