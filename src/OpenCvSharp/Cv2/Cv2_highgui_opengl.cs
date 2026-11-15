using OpenCvSharp.Internal;

namespace OpenCvSharp;

static partial class Cv2
{
    /// <summary>Makes the OpenGL context of the named HighGUI window current on the calling thread.</summary>
    public static void SetOpenGlContext(string windowName)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        NativeMethods.HandleException(NativeMethods.highgui_setOpenGlContext(windowName));
    }

    /// <summary>Requests a redraw of the named OpenGL window.</summary>
    /// <remarks>Pump window events with <see cref="WaitKey"/> so the redraw can be processed.</remarks>
    public static void UpdateWindow(string windowName)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        NativeMethods.HandleException(NativeMethods.highgui_updateWindow(windowName));
    }

    /// <summary>Sets the unmanaged drawing callback and its user data for the named OpenGL window.</summary>
    /// <param name="windowName">An existing HighGUI window created with <see cref="WindowFlags.OpenGL"/>.</param>
    /// <param name="callback">A Cdecl function pointer, or null to clear the draw callback.</param>
    /// <param name="userData">Caller-owned data passed to the draw and free callbacks.</param>
    /// <remarks>
    /// Use a window dedicated to custom drawing. A <see cref="Viz3d"/> scene or an OpenGL image display
    /// owns its own callbacks. Keep the callback and its user data valid until they are replaced or
    /// the window is destroyed. Managed callbacks can use a static method marked UnmanagedCallersOnly
    /// with CallConvCdecl. Exceptions must be handled inside the callback.
    /// </remarks>
    public static unsafe void SetOpenGlDrawCallback(string windowName, delegate* unmanaged[Cdecl]<IntPtr, void> callback,
        IntPtr userData = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        NativeMethods.HandleException(NativeMethods.highgui_setOpenGlDrawCallback(windowName, (IntPtr)callback, userData));
    }

    /// <summary>Sets the unmanaged cleanup callback for the named OpenGL window.</summary>
    /// <param name="windowName">An existing HighGUI window created with <see cref="WindowFlags.OpenGL"/>.</param>
    /// <param name="callback">A Cdecl function pointer, or null to clear the free callback.</param>
    /// <remarks>
    /// OpenCV passes the nonzero user data most recently registered with <see cref="SetOpenGlDrawCallback"/>
    /// when it destroys the window. Replacing a callback or its user data does not invoke the free callback.
    /// Use the same dedicated window and lifetime rules as for the draw callback.
    /// </remarks>
    public static unsafe void SetOpenGlFreeCallback(string windowName, delegate* unmanaged[Cdecl]<IntPtr, void> callback)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        NativeMethods.HandleException(NativeMethods.highgui_setOpenGlFreeCallback(windowName, (IntPtr)callback));
    }

    /// <summary>Returns the current unmanaged drawing callback, or null when there is none.</summary>
    /// <remarks>The pointer is borrowed from the window and can belong to OpenCV.</remarks>
    public static unsafe delegate* unmanaged[Cdecl]<IntPtr, void> GetOpenGlDrawCallback(string windowName)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        NativeMethods.HandleException(NativeMethods.highgui_getOpenGlDrawCallback(windowName, out var callback));
        return (delegate* unmanaged[Cdecl]<IntPtr, void>)callback;
    }

    /// <summary>Returns the current OpenGL callback's user data, or zero when there is none.</summary>
    /// <remarks>The pointer is borrowed from the window and can refer to OpenCV state.</remarks>
    public static IntPtr GetOpenGlUserData(string windowName)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        NativeMethods.HandleException(NativeMethods.highgui_getOpenGlUserData(windowName, out var userData));
        return userData;
    }
}
