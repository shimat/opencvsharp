namespace OpenCvSharp;

/// <summary>
/// Mouse Events 
/// </summary>
public enum MouseEventTypes
{
    /// <summary>
    /// indicates that the mouse pointer has moved over the window.
    /// </summary>
    MouseMove = 0,

    /// <summary>
    /// indicates that the left mouse button is pressed.
    /// </summary>
    LButtonDown = 1,

    /// <summary>
    /// indicates that the right mouse button is pressed.
    /// </summary>
    RButtonDown = 2,

    /// <summary>
    /// indicates that the middle mouse button is pressed.
    /// </summary>
    MButtonDown = 3,

    /// <summary>
    /// indicates that left mouse button is released.
    /// </summary>
    LButtonUp = 4,

    /// <summary>
    /// indicates that right mouse button is released.
    /// </summary>
    RButtonUp = 5,

    /// <summary>
    /// indicates that middle mouse button is released.
    /// </summary>
    MButtonUp = 6,

    /// <summary>
    /// indicates that left mouse button is double clicked.
    /// </summary>
    LButtonDoubleClick = 7,

    /// <summary>
    /// indicates that right mouse button is double clicked.
    /// </summary>
    RButtonDoubleClick = 8,

    /// <summary>
    /// indicates that middle mouse button is double clicked.
    /// </summary>
    MButtonDoubleClick = 9,

    /// <summary>
    /// positive and negative values mean forward and backward scrolling, respectively.
    /// </summary>
    MouseWheel = 10,

    /// <summary>
    /// positive and negative values mean right and left scrolling, respectively.
    /// </summary>
    MouseHWheel = 11,
}
