namespace OpenCvSharp;

/// <summary>
/// Modes of the IEEE 1394 controlling registers (can be: auto, manual, auto single push, absolute.
/// Latter allowed with any other mode). Every feature can have only one mode turned on at a time.
/// </summary>
/// <remarks>
/// https://github.com/opencv/opencv/blob/master/modules/videoio/include/opencv2/videoio.hpp
/// </remarks>
public enum VideoCaptureDC1394Mode
{
    /// <summary>
    /// Turn the feature off (not controlled manually nor automatically).
    /// </summary>
    Off = -4,

    /// <summary>
    /// Set automatically when a value of the feature is set by the user.
    /// </summary>
    ModeManual = -3,

    /// <summary>
    ///
    /// </summary>
    ModeAuto = -2,

    /// <summary>
    ///
    /// </summary>
    ModeOnePushAuto = -1,

    /// <summary>
    ///
    /// </summary>
    Max = 31,
}
