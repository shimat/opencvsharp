namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// OBSENSOR properties
/// </summary>
/// <remarks>
/// https://github.com/opencv/opencv/blob/master/modules/videoio/include/opencv2/videoio.hpp
/// </remarks>
public enum VideoCaptureOBSensorProperties
{
    /// <summary>
    /// Intrinsic parameter fx
    /// </summary>
    IntrinsicFx = 26001,

    /// <summary>
    /// Intrinsic parameter fy
    /// </summary>
    IntrinsicFy = 26002,

    /// <summary>
    /// Intrinsic parameter cx
    /// </summary>
    IntrinsicCx = 26003,

    /// <summary>
    /// Intrinsic parameter cy
    /// </summary>
    IntrinsicCy = 26004,

    /// <summary>
    ///
    /// </summary>
    RgbPosMsec = 26005,

    /// <summary>
    ///
    /// </summary>
    DepthPosMsec = 26006,

    /// <summary>
    ///
    /// </summary>
    DepthWidth = 26007,

    /// <summary>
    ///
    /// </summary>
    DepthHeight = 26008,

    /// <summary>
    ///
    /// </summary>
    DepthFps = 26009,

    /// <summary>
    /// Color distortion coefficient k1
    /// </summary>
    ColorDistortionK1 = 26010,

    /// <summary>
    /// Color distortion coefficient k2
    /// </summary>
    ColorDistortionK2 = 26011,

    /// <summary>
    /// Color distortion coefficient k3
    /// </summary>
    ColorDistortionK3 = 26012,

    /// <summary>
    /// Color distortion coefficient k4
    /// </summary>
    ColorDistortionK4 = 26013,

    /// <summary>
    /// Color distortion coefficient k5
    /// </summary>
    ColorDistortionK5 = 26014,

    /// <summary>
    /// Color distortion coefficient k6
    /// </summary>
    ColorDistortionK6 = 26015,

    /// <summary>
    /// Color distortion coefficient p1
    /// </summary>
    ColorDistortionP1 = 26016,

    /// <summary>
    /// Color distortion coefficient p2
    /// </summary>
    ColorDistortionP2 = 26017,
}
