using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// 
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
            return DenseOpticalFlowExtImpl.FromPtr(ptr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateFarneback_CUDA()
        {
            IntPtr ptr = NativeMethods.superres_createOptFlow_Farneback_CUDA();
            return DenseOpticalFlowExtImpl.FromPtr(ptr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateFarneback_OCL()
        {
            throw new NotImplementedException();
            //IntPtr ptr = NativeMethods.superres_createOptFlow_Farneback_OCL();
            //return DenseOpticalFlowExtImpl.FromPtr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateSimple()
        {
            throw new NotImplementedException();
            //IntPtr ptr = NativeMethods.superres_createOptFlow_Simple();
            //return DenseOpticalFlowExtImpl.FromPtr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateDualTVL1()
        {
            IntPtr ptr = NativeMethods.superres_createOptFlow_Farneback();
            return DenseOpticalFlowExtImpl.FromPtr(ptr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateDualTVL1_CUDA()
        {
            IntPtr ptr = NativeMethods.superres_createOptFlow_Farneback_CUDA();
            return DenseOpticalFlowExtImpl.FromPtr(ptr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateDualTVL1_OCL()
        {
            throw new NotImplementedException();
            //IntPtr ptr = NativeMethods.superres_createOptFlow_Farneback_OCL();
            //return DenseOpticalFlowExtImpl.FromPtr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateBrox_CUDA()
        {
            IntPtr ptr = NativeMethods.superres_createOptFlow_Brox_CUDA();
            return DenseOpticalFlowExtImpl.FromPtr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreatePyrLK_CUDA()
        {
            IntPtr ptr = NativeMethods.superres_createOptFlow_PyrLK_CUDA();
            return DenseOpticalFlowExtImpl.FromPtr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreatePyrLK_OCL()
        {
            throw new NotImplementedException();
            //IntPtr ptr = NativeMethods.superres_createOptFlow_PyrLK_OCL();
            //return DenseOpticalFlowExtImpl.FromPtr(ptr);
        }

        #endregion

        /// <summary>
        /// Clear all inner buffers.
        /// </summary>
        public virtual void CollectGarbage()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frame0"></param>
        /// <param name="frame1"></param>
        /// <param name="flow1"></param>
        /// <param name="flow2"></param>
        public abstract void Calc(InputArray frame0, InputArray frame1, OutputArray flow1, OutputArray flow2 = null);
    }
}
