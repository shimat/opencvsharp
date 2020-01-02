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
            NativeMethods.HandleException(
                NativeMethods.superres_createFrameSource_Empty(out var ptr));
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

            NativeMethods.HandleException(
                NativeMethods.superres_createFrameSource_Video(fileName, out var ptr));
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

            NativeMethods.HandleException(
                NativeMethods.superres_createFrameSource_Video_CUDA(fileName, out var ptr));
            return FrameSourceImpl.FromPtr(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static FrameSource CreateFrameSource_Camera(int deviceId)
        {
            NativeMethods.HandleException(
                NativeMethods.superres_createFrameSource_Camera(deviceId, out var ptr));
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
