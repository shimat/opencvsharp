using System;

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable InconsistentNaming

    public static partial class Cv2
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
    }
}
