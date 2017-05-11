using System;

namespace OpenCvSharp.Tracking
{
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

        public bool Init(Mat image, Rectd boundingBox)
        {
            ThrowIfDisposed();

            if (image == null)
                throw new ArgumentNullException(nameof(image));

            image.ThrowIfDisposed();
            var ret = NativeMethods.tracking_Tracker_init(this.ptr, image.CvPtr, boundingBox);
            GC.KeepAlive(image);

            return ret;
        }

        public bool Update(Mat image, ref Rectd boundingBox)
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

        internal new class Ptr : OpenCvSharp.Ptr
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
