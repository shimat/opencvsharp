using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Rgbd;

/// <summary>
/// DynamicFusion implementation. Extends <see cref="KinFu"/> to handle non-rigidly deforming
/// scenes by maintaining a sparse set of nodes covering the geometry, each holding a warp that
/// transforms it from a canonical space to the live frame.
/// </summary>
public class DynaFu : CvPtrObject
{
    private DynaFu(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.rgbd_dynafu_Ptr_DynaFu_delete(p)))
    { }

    /// <summary>Creates a DynaFu instance with the supplied parameters (shared with <see cref="KinFu"/>).</summary>
    public static DynaFu Create(KinFuParams parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters);
        var native = parameters.ToNative();
        InputArray intr = parameters.Intr;
        InputArray rgbIntr = parameters.RgbIntr;
        InputArray volumePose = parameters.VolumePose;
        using var icpIterations = new StdVector<int>(parameters.IcpIterations);
        NativeMethods.HandleException(NativeMethods.rgbd_dynafu_DynaFu_create(
            in native, intr.Proxy, rgbIntr.Proxy, volumePose.Proxy, icpIterations.CvPtr, out var smartPtr));
        GC.KeepAlive(parameters.Intr); GC.KeepAlive(parameters.RgbIntr); GC.KeepAlive(parameters.VolumePose);
        NativeMethods.HandleException(NativeMethods.rgbd_dynafu_Ptr_DynaFu_get(smartPtr, out var rawPtr));
        return new DynaFu(smartPtr, rawPtr);
    }

    /// <summary>Gets the current parameters.</summary>
    public virtual KinFuParams GetParams()
    {
        ThrowIfDisposed();
        var intr = new Mat();
        var rgbIntr = new Mat();
        var volumePose = new Mat();
        using var icpIterations = new StdVector<int>();
        OutputArray intrArray = intr;
        OutputArray rgbIntrArray = rgbIntr;
        OutputArray volumePoseArray = volumePose;
        NativeMethods.HandleException(NativeMethods.rgbd_dynafu_DynaFu_getParams(
            Handle, out var pod, intrArray.Proxy, rgbIntrArray.Proxy, volumePoseArray.Proxy, icpIterations.CvPtr));
        GC.KeepAlive(intr); GC.KeepAlive(rgbIntr); GC.KeepAlive(volumePose);
        return new KinFuParams(pod, intr, rgbIntr, volumePose, icpIterations.ToArray());
    }

    /// <summary>Renders a 0-surface of the TSDF using Phong shading into a CV_8UC4 image, from the last frame's camera pose.</summary>
    public virtual void Render(OutputArray image)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_dynafu_DynaFu_render(Handle, image.Proxy));
        GC.KeepAlive(image.Source);
    }

    /// <summary>Renders a 0-surface of the TSDF using Phong shading into a CV_8UC4 image, from the given camera pose.</summary>
    public virtual void Render(OutputArray image, InputArray cameraPose)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_dynafu_DynaFu_renderWithPose(Handle, image.Proxy, cameraPose.Proxy));
        GC.KeepAlive(image.Source); GC.KeepAlive(cameraPose.Source);
    }

    /// <summary>Gets points and normals of the current 3D mesh. The order of points is undefined; normals correspond to points.</summary>
    public virtual void GetCloud(OutputArray points, OutputArray normals)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_dynafu_DynaFu_getCloud(Handle, points.Proxy, normals.Proxy));
        GC.KeepAlive(points.Source); GC.KeepAlive(normals.Source);
    }

    /// <summary>Gets points of the current 3D mesh. The order of points is undefined.</summary>
    public virtual void GetPoints(OutputArray points)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_dynafu_DynaFu_getPoints(Handle, points.Proxy));
        GC.KeepAlive(points.Source);
    }

    /// <summary>Calculates normals for the given points.</summary>
    public virtual void GetNormals(InputArray points, OutputArray normals)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_dynafu_DynaFu_getNormals(Handle, points.Proxy, normals.Proxy));
        GC.KeepAlive(points.Source); GC.KeepAlive(normals.Source);
    }

    /// <summary>Clears the current model and resets the pose.</summary>
    public virtual void Reset()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_dynafu_DynaFu_reset(Handle));
    }

    /// <summary>Gets the current pose in voxel space, as a 4x4 homogeneous transform matrix.</summary>
    public virtual Mat GetPose()
    {
        ThrowIfDisposed();
        var pose = new Mat();
        OutputArray poseArray = pose;
        NativeMethods.HandleException(NativeMethods.rgbd_dynafu_DynaFu_getPose(Handle, poseArray.Proxy));
        GC.KeepAlive(pose);
        return pose;
    }

    /// <summary>
    /// Integrates the next depth frame with respect to its ICP-calculated pose.
    /// The input image is converted to CV_32F internally if it has another type.
    /// </summary>
    /// <returns>true if the new frame was successfully aligned with the current scene, false otherwise.</returns>
    public virtual bool Update(InputArray depth)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_dynafu_DynaFu_update(Handle, depth.Proxy, out var result));
        GC.KeepAlive(depth.Source);
        return result != 0;
    }

    /// <summary>Gets the positions of the deformation-graph nodes.</summary>
    public virtual Point3f[] GetNodesPos()
    {
        ThrowIfDisposed();
        using var nodes = new StdVector<Point3f>();
        NativeMethods.HandleException(NativeMethods.rgbd_dynafu_DynaFu_getNodesPos(Handle, nodes.CvPtr));
        return nodes.ToArray();
    }

    /// <summary>Extracts a triangle mesh of the current model using the marching cubes algorithm.</summary>
    public virtual void MarchCubes(OutputArray vertices, OutputArray edges)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_dynafu_DynaFu_marchCubes(Handle, vertices.Proxy, edges.Proxy));
        GC.KeepAlive(vertices.Source); GC.KeepAlive(edges.Source);
    }

    /// <summary>Renders the depth, vertex and normal images of the current (optionally warped) surface.</summary>
    public virtual void RenderSurface(OutputArray depthImage, OutputArray vertImage, OutputArray normImage, bool warp = true)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_dynafu_DynaFu_renderSurface(
            Handle, depthImage.Proxy, vertImage.Proxy, normImage.Proxy, warp ? 1 : 0));
        GC.KeepAlive(depthImage.Source); GC.KeepAlive(vertImage.Source); GC.KeepAlive(normImage.Source);
    }
}
