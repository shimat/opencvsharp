using System;

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable InconsistentNaming

    static partial class Cv2
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static FrameSource CreateFrameSource_Empty()
        {
            return FrameSource.CreateEmptySource();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static FrameSource CreateFrameSource_Video(string fileName)
        {
            return FrameSource.CreateVideoSource(fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static FrameSource CreateFrameSource_Video_GPU(string fileName)
        {
            return FrameSource.CreateVideoSourceGpu(fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static FrameSource CreateFrameSource_Camera(int deviceId)
        {
            return FrameSource.CreateCameraSource(deviceId);
        }


        /// <summary>
        /// Create Bilateral TV-L1 Super Resolution.
        /// </summary>
        /// <returns></returns>
        public static SuperResolution CreateSuperResolution_BTVL1()
        {
            return SuperResolution.CreateBTVL1();
        }

        /// <summary>
        /// Create Bilateral TV-L1 Super Resolution.
        /// </summary>
        /// <returns></returns>
        public static SuperResolution CreateSuperResolution_BTVL1_GPU()
        {
            return SuperResolution.CreateBTVL1_GPU();
        }

        /// <summary>
        /// Create Bilateral TV-L1 Super Resolution.
        /// </summary>
        /// <returns></returns>
        public static SuperResolution CreateSuperResolution_BTVL1_OCL()
        {
            return SuperResolution.CreateBTVL1_OCL();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateOptFlow_Farneback()
        {
            return DenseOpticalFlowExt.CreateFarneback();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateOptFlow_Farneback_GPU()
        {
            return DenseOpticalFlowExt.CreateFarneback_GPU();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateOptFlow_Farneback_OCL()
        {
            return DenseOpticalFlowExt.CreateFarneback_OCL();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateOptFlow_Simple()
        {
            return DenseOpticalFlowExt.CreateSimple();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateOptFlow_DualTVL1Ex()
        {
            return DenseOpticalFlowExt.CreateDualTVL1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateOptFlow_DualTVL1_GPU()
        {
            return DenseOpticalFlowExt.CreateDualTVL1_GPU();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateOptFlow_DualTVL1_OCL()
        {
            return DenseOpticalFlowExt.CreateDualTVL1_OCL();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateOptFlow_Brox_GPU()
        {
            return DenseOpticalFlowExt.CreateBrox_GPU();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateOptFlow_PyrLK_GPU()
        {
            return DenseOpticalFlowExt.CreatePyrLK_GPU();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateOptFlow_PyrLK_OCL()
        {
            return DenseOpticalFlowExt.CreatePyrLK_OCL();
        }
    }
}