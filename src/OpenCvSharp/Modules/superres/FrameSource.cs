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
        /// <returns></returns>
        public static FrameSource CreateFrameSource_Empty()
        {
            var ptr = NativeMethods.superres_createFrameSource_Empty();
            return FrameSourceImpl.FromPtr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static FrameSource CreateFrameSource_Video(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);

            var ptr = NativeMethods.superres_createFrameSource_Video(fileName);
            return FrameSourceImpl.FromPtr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static FrameSource CreateFrameSource_Video_CUDA(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);

            var ptr = NativeMethods.superres_createFrameSource_Video_CUDA(fileName);
            return FrameSourceImpl.FromPtr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static FrameSource CreateFrameSource_Camera(int deviceId)
        {
            var ptr = NativeMethods.superres_createFrameSource_Camera(deviceId);
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
