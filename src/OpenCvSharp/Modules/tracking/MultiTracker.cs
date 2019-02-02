
using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp.Tracking
{
    /// <inheritdoc />
    /// <summary>
    /// This class is used to track multiple objects using the specified tracker algorithm.
    /// The MultiTracker is naive implementation of multiple object tracking.
    /// It process the tracked objects independently without any optimization accross the tracked objects.
    /// </summary>
    public class MultiTracker : Algorithm
    {
        /// <summary>
        /// cv::Ptr&lt;T&gt;
        /// </summary>
        private Ptr ptrObj;

        /// <summary>
        /// 
        /// </summary>
        protected MultiTracker(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <returns></returns>
        public static MultiTracker Create()
        {
            IntPtr p = NativeMethods.tracking_MultiTracker_create();
            return new MultiTracker(p);
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

        /// <summary>
        /// Add a new object to be tracked.
        /// </summary>
        /// <param name="newTracker">tracking algorithm to be used</param>
        /// <param name="image">input image</param>
        /// <param name="boundingBox">a rectangle represents ROI of the tracked object</param>
        /// <returns></returns>
        public bool Add(Tracker newTracker, InputArray image, Rect2d boundingBox)
        {
            if (newTracker == null)
                throw new ArgumentNullException(nameof(newTracker));
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            newTracker.ThrowIfDisposed();
            image.ThrowIfDisposed();

            int ret = NativeMethods.tracking_MultiTracker_add1(ptr, newTracker.PtrObj.CvPtr, image.CvPtr, boundingBox);

            GC.KeepAlive(newTracker);
            GC.KeepAlive(image);
            GC.KeepAlive(this);

            return ret != 0;
        }

        /// <summary>
        /// Add a set of objects to be tracked.
        /// </summary>
        /// <param name="newTrackers">list of tracking algorithms to be used</param>
        /// <param name="image">input image</param>
        /// <param name="boundingBox">list of the tracked objects</param>
        /// <returns></returns>
        public bool Add(IEnumerable<Tracker> newTrackers, InputArray image, IEnumerable<Rect2d> boundingBox)
        {
            if (newTrackers == null)
                throw new ArgumentNullException(nameof(newTrackers));
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (boundingBox == null)
                throw new ArgumentNullException(nameof(boundingBox));

            IntPtr[] newTrackersPtrs = EnumerableEx.SelectToArray(newTrackers, t => t.PtrObj.CvPtr);
            Rect2d[] boundingBoxArray = EnumerableEx.ToArray(boundingBox);
            int ret = NativeMethods.tracking_MultiTracker_add2(ptr, newTrackersPtrs, newTrackersPtrs.Length,
                image.CvPtr, boundingBoxArray, boundingBoxArray.Length);
            
            GC.KeepAlive(newTrackers);
            GC.KeepAlive(newTrackersPtrs);
            GC.KeepAlive(image);
            GC.KeepAlive(boundingBox);
            GC.KeepAlive(boundingBoxArray);
            GC.KeepAlive(this);

            return ret != 0;
        }

        /// <summary>
        /// Update the current tracking status.
        /// The result will be saved in the internal storage.
        /// </summary>
        /// <param name="image">input image</param>
        /// <returns></returns>
        public bool Update(InputArray image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            int ret = NativeMethods.tracking_MultiTracker_update1(ptr, image.CvPtr);

            GC.KeepAlive(image);
            GC.KeepAlive(this);
            
            return ret != 0;
        }
        
        /// <summary>
        /// Update the current tracking status.
        /// </summary>
        /// <param name="image">input image</param>
        /// <param name="boundingBox">the tracking result, represent a list of ROIs of the tracked objects.</param>
        /// <returns></returns>
        public bool Update(InputArray image, out Rect2d[] boundingBox)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            using (var bbVec = new VectorOfRect2d())
            {
                int ret = NativeMethods.tracking_MultiTracker_update2(ptr, image.CvPtr, bbVec.CvPtr);
                boundingBox = bbVec.ToArray();

                GC.KeepAlive(image);
                GC.KeepAlive(this);

                return ret != 0;
            }
        }

        /// <summary>
        /// Returns a reference to a storage for the tracked objects, each object corresponds to one tracker algorithm
        /// </summary>
        /// <returns></returns>
        public Rect2d[] GetObjects()
        {
            using (var bbVec = new VectorOfRect2d())
            {
                NativeMethods.tracking_MultiTracker_getObjects(ptr, bbVec.CvPtr);
                GC.KeepAlive(this);
                return bbVec.ToArray();
            }
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.tracking_Ptr_MultiTracker_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.tracking_Ptr_MultiTracker_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
 