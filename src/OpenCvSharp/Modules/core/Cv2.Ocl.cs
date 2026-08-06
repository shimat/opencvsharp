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
