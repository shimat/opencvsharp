using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>Displays OpenCV point clouds, meshes and other 3D geometry in HighGUI windows.</summary>
/// <remarks>
/// Requires a native runtime built with OpenGL and a HighGUI backend that supports it.
/// A scene owns its window's draw, cleanup and mouse callbacks. Use a separate window for custom drawing
/// or <see cref="Cv2.ImShow(string, Mat)"/>. Pump events with <see cref="Cv2.WaitKey"/> and close
/// the window with <see cref="Cv2.DestroyWindow"/>.
/// </remarks>
public static class Viz3d
{
    /// <summary>Sets the vertical field of view in radians and the near and far clip distances.</summary>
    public static void SetPerspective(string windowName, float fieldOfView, float nearClip, float farClip)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        NativeMethods.HandleException(NativeMethods.ptcloud_viz3d_setPerspective(windowName, fieldOfView, nearClip, farClip));
    }

    /// <summary>Shows or hides the scene grid.</summary>
    public static void SetGridVisible(string windowName, bool visible)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        NativeMethods.HandleException(NativeMethods.ptcloud_viz3d_setGridVisible(windowName, visible ? 1 : 0));
    }

    /// <summary>Sets the light direction and the ambient and diffuse RGB colors.</summary>
    public static void SetSun(string windowName, Vec3f direction, Vec3f ambient, Vec3f diffuse)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        NativeMethods.HandleException(NativeMethods.ptcloud_viz3d_setSun(windowName, direction, ambient, diffuse));
    }

    /// <summary>Sets the background RGB color.</summary>
    public static void SetSky(string windowName, Vec3f color)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        NativeMethods.HandleException(NativeMethods.ptcloud_viz3d_setSky(windowName, color));
    }

    /// <summary>Displays a box with the specified half-extents and RGB color.</summary>
    public static void ShowBox(string windowName, string objectName, Vec3f size, Vec3f color, Viz3dRenderMode mode = Viz3dRenderMode.Simple)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        ArgumentException.ThrowIfNullOrEmpty(objectName);
        NativeMethods.HandleException(NativeMethods.ptcloud_viz3d_showBox(windowName, objectName, size, color, (int)mode));
    }

    /// <summary>Displays a plane facing positive Y with the specified half-extents and RGB color.</summary>
    public static void ShowPlane(string windowName, string objectName, Vec2f size, Vec3f color, Viz3dRenderMode mode = Viz3dRenderMode.Simple)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        ArgumentException.ThrowIfNullOrEmpty(objectName);
        NativeMethods.HandleException(NativeMethods.ptcloud_viz3d_showPlane(windowName, objectName, size, color, (int)mode));
    }

    /// <summary>Displays a sphere with the specified radius, RGB color and subdivision count.</summary>
    public static void ShowSphere(string windowName, string objectName,
        float radius, Vec3f color, Viz3dRenderMode mode = Viz3dRenderMode.Simple, int subdivisions = 3)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        ArgumentException.ThrowIfNullOrEmpty(objectName);
        NativeMethods.HandleException(NativeMethods.ptcloud_viz3d_showSphere(windowName, objectName, radius, color, (int)mode, subdivisions));
    }

    /// <summary>Displays a camera trajectory whose rows hold XYZ positions and XYZ viewing directions.</summary>
    public static void ShowCameraTrajectory(string windowName, string objectName, InputArray trajectory, float aspect, float scale)
        => ShowCameraTrajectory(windowName, objectName, trajectory, aspect, scale, new Vec3f(1, 1, 1), new Vec3f(0.5f, 0.5f, 0.5f));

    /// <summary>Displays a camera trajectory whose rows hold XYZ positions and XYZ viewing directions.</summary>
    public static void ShowCameraTrajectory(string windowName, string objectName,
        InputArray trajectory, float aspect, float scale, Vec3f frustumColor, Vec3f lineColor)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        ArgumentException.ThrowIfNullOrEmpty(objectName);
        NativeMethods.HandleException(NativeMethods.ptcloud_viz3d_showCameraTrajectory(windowName, objectName, trajectory.Proxy, aspect, scale, frustumColor, lineColor));
        GC.KeepAlive(trajectory.Source);
    }

    /// <summary>Displays a triangle mesh. Each vertex row holds XYZ, optional RGB and optional normals.</summary>
    public static void ShowMesh(string windowName, string objectName, InputArray vertices, InputArray indices = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        ArgumentException.ThrowIfNullOrEmpty(objectName);
        NativeMethods.HandleException(NativeMethods.ptcloud_viz3d_showMesh(windowName, objectName, vertices.Proxy, indices.Proxy));
        GC.KeepAlive(vertices.Source);
        GC.KeepAlive(indices.Source);
    }

    /// <summary>Displays points whose rows contain XYZ and RGB values.</summary>
    public static void ShowPoints(string windowName, string objectName, InputArray points)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        ArgumentException.ThrowIfNullOrEmpty(objectName);
        NativeMethods.HandleException(NativeMethods.ptcloud_viz3d_showPoints(windowName, objectName, points.Proxy));
        GC.KeepAlive(points.Source);
    }

    /// <summary>Displays lines from pairs of rows containing XYZ and RGB values.</summary>
    public static void ShowLines(string windowName, string objectName, InputArray points)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        ArgumentException.ThrowIfNullOrEmpty(objectName);
        NativeMethods.HandleException(NativeMethods.ptcloud_viz3d_showLines(windowName, objectName, points.Proxy));
        GC.KeepAlive(points.Source);
    }

    /// <summary>Displays a decoded Gaussian splat scene in the layout of <see cref="GaussianSplatLayout"/>.</summary>
    public static void ShowGaussianSplats(string windowName, string objectName, InputArray splats)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        ArgumentException.ThrowIfNullOrEmpty(objectName);
        NativeMethods.HandleException(NativeMethods.ptcloud_viz3d_showGaussianSplats(windowName, objectName, splats.Proxy));
        GC.KeepAlive(splats.Source);
    }

    /// <summary>Displays a CV_32FC4 RGB-D image with depth in millimeters using a 3-by-3 camera intrinsic matrix.</summary>
    public static void ShowRgbd(string windowName, string objectName, InputArray image, InputArray intrinsics, float scale = 1.0f)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        ArgumentException.ThrowIfNullOrEmpty(objectName);
        NativeMethods.HandleException(NativeMethods.ptcloud_viz3d_showRGBD(windowName, objectName, image.Proxy, intrinsics.Proxy, scale));
        GC.KeepAlive(image.Source);
        GC.KeepAlive(intrinsics.Source);
    }

    /// <summary>Sets the XYZ position of an object.</summary>
    public static void SetObjectPosition(string windowName, string objectName, Vec3f position)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        ArgumentException.ThrowIfNullOrEmpty(objectName);
        NativeMethods.HandleException(NativeMethods.ptcloud_viz3d_setObjectPosition(windowName, objectName, position));
    }

    /// <summary>Sets the Euler angles of an object in radians.</summary>
    public static void SetObjectRotation(string windowName, string objectName, Vec3f rotation)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        ArgumentException.ThrowIfNullOrEmpty(objectName);
        NativeMethods.HandleException(NativeMethods.ptcloud_viz3d_setObjectRotation(windowName, objectName, rotation));
    }

    /// <summary>Removes the named object from the scene.</summary>
    public static void DestroyObject(string windowName, string objectName)
    {
        ArgumentException.ThrowIfNullOrEmpty(windowName);
        ArgumentException.ThrowIfNullOrEmpty(objectName);
        NativeMethods.HandleException(NativeMethods.ptcloud_viz3d_destroyObject(windowName, objectName));
    }
}
