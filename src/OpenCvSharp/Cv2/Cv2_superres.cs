namespace OpenCvSharp
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
            return FrameSource.CreateFrameSource_Empty();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static FrameSource CreateFrameSource_Video(string fileName)
        {
            return FrameSource.CreateFrameSource_Video(fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static FrameSource CreateFrameSource_Video_CUDA(string fileName)
        {
            return FrameSource.CreateFrameSource_Video_CUDA(fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static FrameSource CreateFrameSource_Camera(int deviceId)
        {
            return FrameSource.CreateFrameSource_Camera(deviceId);
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
        public static SuperResolution CreateSuperResolution_BTVL1_CUDA()
        {
            return SuperResolution.CreateBTVL1_CUDA();
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
            return DenseOpticalFlowExt.CreateFarneback_CUDA();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateOptFlow_DualTVL1_GPU()
        {
            return DenseOpticalFlowExt.CreateDualTVL1_CUDA();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateOptFlow_Brox_GPU()
        {
            return DenseOpticalFlowExt.CreateBrox_CUDA();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlowExt CreateOptFlow_PyrLK_GPU()
        {
            return DenseOpticalFlowExt.CreatePyrLK_CUDA();
        }
    }
}
