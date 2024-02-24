namespace OpenCvSharp;

/// <summary>
/// Mouse Event Flags see cv::MouseCallback
/// </summary>
[Flags]
public enum MouseEventFlags
{
    /// <summary>
    /// indicates that the left mouse button is down.
    /// </summary>
    LButton = 1,

    /// <summary>
    /// indicates that the right mouse button is down.
    /// </summary>
    RButton = 2,

    /// <summary>
    /// indicates that the middle mouse button is down.
    /// </summary>
    MButton = 4,

    /// <summary>
    /// indicates that CTRL Key is pressed.
    /// </summary>
    CtrlKey = 8,

    /// <summary>
    /// indicates that SHIFT Key is pressed.
    /// </summary>
    ShiftKey = 16,

    /// <summary>
    /// indicates that ALT Key is pressed.
    /// </summary>
    AltKey = 32,
}
