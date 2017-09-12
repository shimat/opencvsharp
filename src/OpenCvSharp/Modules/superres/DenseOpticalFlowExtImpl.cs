using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// 
    /// </summary>
    internal sealed class DenseOpticalFlowExtImpl : DenseOpticalFlowExt
    {
        /// <summary>
        /// 
        /// </summary>
        private Ptr detectorPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        private DenseOpticalFlowExtImpl()
        {
            detectorPtr = null;
            ptr = IntPtr.Zero;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static DenseOpticalFlowExtImpl FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid DenseOpticalFlowExt pointer");

            var ptrObj = new Ptr(ptr);
            var obj = new DenseOpticalFlowExtImpl
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
        internal static DenseOpticalFlowExtImpl FromRawPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid DenseOpticalFlowExt pointer");
            var obj = new DenseOpticalFlowExtImpl
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
        /// <param name="flow1"></param>
        /// <param name="flow2"></param>
        public override void Calc(
            InputArray frame0, InputArray frame1, OutputArray flow1, OutputArray flow2 = null)
        {
            if (frame0 == null)
                throw new ArgumentNullException(nameof(frame0));
            if (frame1 == null)
                throw new ArgumentNullException(nameof(frame1));
            if (flow1 == null)
                throw new ArgumentNullException(nameof(flow1));
            frame0.ThrowIfDisposed();
            frame1.ThrowIfDisposed();
            flow1.ThrowIfNotReady();
            if (flow2 != null)
                flow2.ThrowIfNotReady();

            NativeMethods.superres_DenseOpticalFlowExt_calc(
                ptr, frame0.CvPtr, frame1.CvPtr, flow1.CvPtr, Cv2.ToPtr(flow2));

            flow1.Fix();
            if (flow2 != null)
                flow2.Fix();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void CollectGarbage()
        {
            NativeMethods.superres_DenseOpticalFlowExt_collectGarbage(ptr);
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
                base.Dispose();
            }
        }
    }
}
