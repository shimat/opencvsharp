using OpenCvSharp.Internal;

namespace OpenCvSharp;

public static partial class Cv2
{
    /// <summary>
    /// cv::ocl functions.
    /// </summary>
    public static partial class Ocl
    {
        /// <summary>
        /// Returns whether an OpenCL runtime with at least one platform is available.
        /// </summary>
        public static bool HaveOpenCL()
        {
            NativeMethods.HandleException(
                NativeMethods.core_ocl_haveOpenCL(out var returnValue));
            return returnValue != 0;
        }

        /// <summary>
        /// Returns whether OpenCL is currently enabled for the calling thread.
        /// </summary>
        public static bool UseOpenCL()
        {
            NativeMethods.HandleException(
                NativeMethods.core_ocl_useOpenCL(out var returnValue));
            return returnValue != 0;
        }

        /// <summary>
        /// Enables or disables OpenCL use for the calling thread.
        /// </summary>
        /// <param name="flag">True to enable OpenCL when a suitable runtime and device are available; otherwise, false.</param>
        public static void SetUseOpenCL(bool flag)
        {
            NativeMethods.HandleException(
                NativeMethods.core_ocl_setUseOpenCL(flag ? 1 : 0));
        }

        /// <summary>
        /// Waits for all queued OpenCL operations in the current default queue to complete.
        /// </summary>
        /// <remarks>
        /// This method blocks the calling thread and is primarily useful at synchronization boundaries and when measuring OpenCL execution time.
        /// Calling it after every operation can reduce performance by preventing asynchronous execution.
        /// </remarks>
        public static void Finish()
        {
            NativeMethods.HandleException(
                NativeMethods.core_ocl_finish());
        }
    }
}
