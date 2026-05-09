#if ENABLED_CUDA
namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// StereoSGM algorithm mode.
    /// </summary>
    public enum StereoSGMMode
    {
        /// <summary>
        /// Full 8-direction optimization path. 
        /// This mode considers 8 different paths for cost aggregation, providing the highest 
        /// disparity map quality at the cost of higher computational load.
        /// </summary>
        HH = 0,

        /// <summary>
        /// Optimized 4-direction optimization path. 
        /// This mode reduces the cost aggregation to 4 paths, making it significantly faster 
        /// while maintaining acceptable quality for many real-time applications.
        /// </summary>
        HH4 = 1
    }
}
#endif
