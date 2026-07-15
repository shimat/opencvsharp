using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Rgbd;

/// <summary>
/// Color-aware KinectFusion implementation. Reconstructs a 3D scene in real time from a sequence
/// of registered depth and color images.
/// </summary>
public class ColoredKinFu : CvPtrObject
{
    private ColoredKinFu(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.rgbd_colored_kinfu_Ptr_ColoredKinFu_delete(p)))
    { }

    /// <summary>Creates a ColoredKinFu instance with the supplied parameters.</summary>
    public static ColoredKinFu Create(ColoredKinFuParams parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters);
        var native = parameters.ToNative();
        InputArray intr = parameters.Intr;
        InputArray rgbIntr = parameters.RgbIntr;
        InputArray volumePose = parameters.VolumePose;
        using var icpIterations = new StdVector<int>(parameters.IcpIterations);
        NativeMethods.HandleException(NativeMethods.rgbd_colored_kinfu_ColoredKinFu_create(
            in native, intr.Proxy, rgbIntr.Proxy, volumePose.Proxy, icpIterations.CvPtr, out var smartPtr));
        GC.KeepAlive(parameters.Intr); GC.KeepAlive(parameters.RgbIntr); GC.KeepAlive(parameters.VolumePose);
        NativeMethods.HandleException(NativeMethods.rgbd_colored_kinfu_Ptr_ColoredKinFu_get(smartPtr, out var rawPtr));
        return new ColoredKinFu(smartPtr, rawPtr);
    }

    /// <summary>Gets the current parameters.</summary>
    public virtual ColoredKinFuParams GetParams()
    {
        ThrowIfDisposed();
        var intr = new Mat();
        var rgbIntr = new Mat();
        var volumePose = new Mat();
        using var icpIterations = new StdVector<int>();
        OutputArray intrArray = intr;
        OutputArray rgbIntrArray = rgbIntr;
        OutputArray volumePoseArray = volumePose;
        NativeMethods.HandleException(NativeMethods.rgbd_colored_kinfu_ColoredKinFu_getParams(
            Handle, out var pod, intrArray.Proxy, rgbIntrArray.Proxy, volumePoseArray.Proxy, icpIterations.CvPtr));
        GC.KeepAlive(intr); GC.KeepAlive(rgbIntr); GC.KeepAlive(volumePose);
        return new ColoredKinFuParams(pod, intr, rgbIntr, volumePose, icpIterations.ToArray());
    }

    /// <summary>Renders a 0-surface of the TSDF using Phong shading into a CV_8UC4 image, from the last frame's camera pose.</summary>
    public virtual void Render(OutputArray image)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_colored_kinfu_ColoredKinFu_render(Handle, image.Proxy));
        GC.KeepAlive(image.Source);
    }

    /// <summary>Renders a 0-surface of the TSDF using Phong shading into a CV_8UC4 image, from the given camera pose.</summary>
    public virtual void Render(OutputArray image, InputArray cameraPose)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_colored_kinfu_ColoredKinFu_renderWithPose(Handle, image.Proxy, cameraPose.Proxy));
        GC.KeepAlive(image.Source); GC.KeepAlive(cameraPose.Source);
    }

    /// <summary>Gets points and normals of the current 3D mesh. The order of points is undefined; normals correspond to points.</summary>
    public virtual void GetCloud(OutputArray points, OutputArray normals)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_colored_kinfu_ColoredKinFu_getCloud(Handle, points.Proxy, normals.Proxy));
        GC.KeepAlive(points.Source); GC.KeepAlive(normals.Source);
    }

    /// <summary>Gets points of the current 3D mesh. The order of points is undefined.</summary>
    public virtual void GetPoints(OutputArray points)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_colored_kinfu_ColoredKinFu_getPoints(Handle, points.Proxy));
        GC.KeepAlive(points.Source);
    }

    /// <summary>Calculates normals for the given points.</summary>
    public virtual void GetNormals(InputArray points, OutputArray normals)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_colored_kinfu_ColoredKinFu_getNormals(Handle, points.Proxy, normals.Proxy));
        GC.KeepAlive(points.Source); GC.KeepAlive(normals.Source);
    }

    /// <summary>Clears the current model and resets the pose.</summary>
    public virtual void Reset()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_colored_kinfu_ColoredKinFu_reset(Handle));
    }

    /// <summary>Gets the current pose in voxel space, as a 4x4 homogeneous transform matrix.</summary>
    public virtual Mat GetPose()
    {
        ThrowIfDisposed();
        var pose = new Mat();
        OutputArray poseArray = pose;
        NativeMethods.HandleException(NativeMethods.rgbd_colored_kinfu_ColoredKinFu_getPose(Handle, poseArray.Proxy));
        GC.KeepAlive(pose);
        return pose;
    }

    /// <summary>Integrates the next registered depth and color frame with respect to its ICP-calculated pose.</summary>
    /// <param name="depth">Input depth frame.</param>
    /// <param name="rgb">Input color frame.</param>
    /// <returns>true if the new frame was successfully aligned with the current scene, false otherwise.</returns>
    public virtual bool Update(InputArray depth, InputArray rgb)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_colored_kinfu_ColoredKinFu_update(
            Handle, depth.Proxy, rgb.Proxy, out var result));
        GC.KeepAlive(depth.Source); GC.KeepAlive(rgb.Source);
        return result != 0;
    }
}
