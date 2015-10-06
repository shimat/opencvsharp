using System;
using System.IO;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class FrameSource : DisposableCvObject
    {
        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected FrameSource()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static FrameSource CreateEmptySource()
        {
            IntPtr ptr = NativeMethods.superres_createFrameSource_Empty();
            return FrameSourceImpl.FromPtr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static FrameSource CreateVideoSource(string fileName)
        {
            if (String.IsNullOrEmpty("fileName"))
                throw new ArgumentNullException("fileName");
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);
            IntPtr ptr = NativeMethods.superres_createFrameSource_Video(fileName);
            return FrameSourceImpl.FromPtr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static FrameSource CreateVideoSourceCuda(string fileName)
        {
            if (String.IsNullOrEmpty("fileName"))
                throw new ArgumentNullException("fileName");
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);
            IntPtr ptr = NativeMethods.superres_createFrameSource_Video_CUDA(fileName);
            return FrameSourceImpl.FromPtr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static FrameSource CreateCameraSource(int deviceId)
        {
            IntPtr ptr = NativeMethods.superres_createFrameSource_Camera(deviceId);
            return FrameSourceImpl.FromPtr(ptr);
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frame"></param>
        public abstract void NextFrame(OutputArray frame);

        /// <summary>
        /// 
        /// </summary>
        public abstract void Reset();

        #endregion
    }
}
