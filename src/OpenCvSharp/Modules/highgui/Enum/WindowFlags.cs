
// ReSharper disable InconsistentNaming

#pragma warning disable CA1008 // Enums should have zero value

namespace OpenCvSharp;

/// <summary>
/// Flags for cv::namedWindow
/// </summary>
[Flags]
public enum WindowFlags
{
    /// <summary>
    /// the user can resize the window (no constraint) / 
    /// also use to switch a fullscreen window to a normal size
    /// </summary>
    Normal = 0x00000000,

    /// <summary>
    /// the user cannot resize the window, the size is constrainted by the image displayed.
    /// </summary>
    AutoSize = 0x00000001,

    /// <summary>
    /// window with opengl support
    /// </summary>
    OpenGL = 0x00001000,
        
#pragma warning disable CA1069 // Enums should not have duplicate values

    /// <summary>
    /// change the window to fullscreen
    /// </summary>
    FullScreen = 1,

    /// <summary>
    /// the image expends as much as it can (no ratio constraint)
    /// </summary>
    FreeRatio = 0x00000100,

    /// <summary>
    /// the ratio of the image is respected
    /// </summary>
    KeepRatio = 0x00000000,

    /// <summary>
    /// status bar and tool bar
    /// </summary>
    GuiExpanded = 0x00000000,

    /// <summary>
    /// old fashious way
    /// </summary>
    GuiNormal = 0x00000010,
}
