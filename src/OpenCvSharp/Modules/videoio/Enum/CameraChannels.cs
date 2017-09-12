
namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
    /// マルチヘッドカメラから取得する画像のチャネル
    /// </summary>
#else
    /// <summary>
    /// channel indices for multi-head camera live streams
    /// </summary>
#endif
    public enum CameraChannels : int
    {
        // Data given from depth generator.

        /// <summary>
        /// Depth values in mm (CV_16UC1)
        /// </summary>
        OpenNI_DepthMap = 0, 

        /// <summary>
        /// XYZ in meters (CV_32FC3)
        /// </summary>
        OpenNI_PointCloudMap = 1, 

        /// <summary>
        /// Disparity in pixels (CV_8UC1)
        /// </summary>
        OpenNI_DisparityMap = 2, 

        /// <summary>
        /// Disparity in pixels (CV_32FC1)
        /// </summary>
        OpenNI_DisparityMap32F = 3, 

        /// <summary>
        /// CV_8UC1
        /// </summary>
        OpenNI_ValidDepthMask = 4, 
    }
}
