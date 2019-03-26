using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public abstract class DenseOpticalFlowExt : Algorithm
    {
        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected DenseOpticalFlowExt()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateFarneback()
        {
            IntPtr ptr = NativeMethods.superres_createOptFlow_Farneback();
            return FarnebackOpticalFlow.FromPtr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateFarneback_CUDA()
        {
            IntPtr ptr = NativeMethods.superres_createOptFlow_Farneback_CUDA();
            return FarnebackOpticalFlow.FromPtr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateDualTVL1()
        {
            IntPtr ptr = NativeMethods.superres_createOptFlow_DualTVL1();
            return FarnebackOpticalFlow.FromPtr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateDualTVL1_CUDA()
        {
            IntPtr ptr = NativeMethods.superres_createOptFlow_DualTVL1_CUDA();
            return FarnebackOpticalFlow.FromPtr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateBrox_CUDA()
        {
            IntPtr ptr = NativeMethods.superres_createOptFlow_Brox_CUDA();
            return FarnebackOpticalFlow.FromPtr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreatePyrLK_CUDA()
        {
            IntPtr ptr = NativeMethods.superres_createOptFlow_PyrLK_CUDA();
            return FarnebackOpticalFlow.FromPtr(ptr);
        }

        #endregion

        /// <summary>
        /// Clear all inner buffers.
        /// </summary>
        public virtual void CollectGarbage()
        {
            NativeMethods.superres_DenseOpticalFlowExt_collectGarbage(ptr);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frame0"></param>
        /// <param name="frame1"></param>
        /// <param name="flow1"></param>
        /// <param name="flow2"></param>
        public virtual void Calc(InputArray frame0, InputArray frame1, OutputArray flow1, OutputArray flow2 = null)
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
            flow2?.ThrowIfNotReady();

            NativeMethods.superres_DenseOpticalFlowExt_calc(
                ptr, frame0.CvPtr, frame1.CvPtr, flow1.CvPtr, Cv2.ToPtr(flow2));
            GC.KeepAlive(this);
            GC.KeepAlive(frame0);
            GC.KeepAlive(frame1);
            GC.KeepAlive(flow1);
            GC.KeepAlive(flow2);
            flow1.Fix();
            flow2?.Fix();
        }
    }
}
