// ReSharper disable CommentTypo
// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

/// <summary>
/// Property identifiers for cvGetWindowProperty/cvSetWindowProperty
/// </summary>
public enum WindowPropertyFlags
{
    /// <summary>
    /// fullscreen property (can be WINDOW_NORMAL or WINDOW_FULLSCREEN)
    /// </summary>
    Fullscreen = 0,

    /// <summary>
    /// autosize property (can be WINDOW_NORMAL or WINDOW_AUTOSIZE)
    /// </summary>
    AutoSize = 1,
        
    /// <summary>
    /// window's aspect ration (can be set to WINDOW_FREERATIO or WINDOW_KEEPRATIO)
    /// </summary>
    AspectRatio = 2,

    /// <summary>
    /// opengl support
    /// </summary>
    OpenGL = 3,

    /// <summary>
    /// checks whether the window exists and is visible
    /// </summary>
    Visible = 4,

    /// <summary>
    /// property to toggle normal window being topmost or not
    /// </summary>
    Topmost = 5
}
