using System;
using System.Collections.Generic;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// 
    /// </summary>
    internal sealed class DenseOpticalFlowImpl : DenseOpticalFlow
    {
        /// <summary>
        /// 
        /// </summary>
        private Ptr detectorPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        private DenseOpticalFlowImpl()
        {
            detectorPtr = null;
            ptr = IntPtr.Zero;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static DenseOpticalFlowImpl FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid DenseOpticalFlow pointer");

            var ptrObj = new Ptr(ptr);
            var obj = new DenseOpticalFlowImpl
            {
                detectorPtr = ptrObj,
                ptr = ptrObj.Get()
            };
            return obj;
        }

        /// <summary>
        /// Creates instance from raw pointer T*
        /// </summary>
        /// <param name="ptr"></param>
        internal static DenseOpticalFlowImpl FromRawPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid DenseOpticalFlow pointer");
            var obj = new DenseOpticalFlowImpl
            {
                detectorPtr = null,
                ptr = ptr
            };
            return obj;
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            detectorPtr?.Dispose();
            detectorPtr = null;
            base.DisposeManaged();
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frame0"></param>
        /// <param name="frame1"></param>
        /// <param name="flow"></param>
        public override void Calc(
            InputArray frame0, InputArray frame1, InputOutputArray flow)
        {
            ThrowIfDisposed();
            if (frame0 == null)
                throw new ArgumentNullException(nameof(frame0));
            if (frame1 == null)
                throw new ArgumentNullException(nameof(frame1));
            if (flow == null)
                throw new ArgumentNullException(nameof(flow));
            frame0.ThrowIfDisposed();
            frame1.ThrowIfDisposed();
            flow.ThrowIfNotReady();

            NativeMethods.video_DenseOpticalFlow_calc(
                ptr, frame0.CvPtr, frame1.CvPtr, flow.CvPtr);

            flow.Fix();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void CollectGarbage()
        {
            ThrowIfDisposed();
            NativeMethods.video_DenseOpticalFlow_collectGarbage(ptr);
        }

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.superres_Ptr_DenseOpticalFlowExt_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.superres_Ptr_DenseOpticalFlowExt_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
