using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Rgbd;

/// <summary>
/// Large-scale dense depth fusion implementation. Reconstructs larger environments using
/// spatially hashed TSDF volume "submaps", with periodic pose-graph optimization to reduce
/// drift over long sequences.
/// </summary>
public class LargeKinfu : CvPtrObject
{
    private LargeKinfu(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.rgbd_large_kinfu_Ptr_LargeKinfu_delete(p)))
    { }

    /// <summary>Creates a LargeKinfu instance with the supplied parameters.</summary>
    public static LargeKinfu Create(LargeKinfuParams parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters);
        ArgumentNullException.ThrowIfNull(parameters.VolumeParams);
        var native = parameters.ToNative();
        var volumeNative = parameters.VolumeParams.ToNative();
        InputArray intr = parameters.Intr;
        InputArray rgbIntr = parameters.RgbIntr;
        InputArray volumePose = parameters.VolumeParams.Pose;
        using var icpIterations = new StdVector<int>(parameters.IcpIterations);
        NativeMethods.HandleException(NativeMethods.rgbd_large_kinfu_LargeKinfu_create(
            in native, intr.Proxy, rgbIntr.Proxy, icpIterations.CvPtr, in volumeNative, volumePose.Proxy,
            out var smartPtr));
        GC.KeepAlive(parameters.Intr); GC.KeepAlive(parameters.RgbIntr); GC.KeepAlive(parameters.VolumeParams.Pose);
        NativeMethods.HandleException(NativeMethods.rgbd_large_kinfu_Ptr_LargeKinfu_get(smartPtr, out var rawPtr));
        return new LargeKinfu(smartPtr, rawPtr);
    }

    /// <summary>Gets the current parameters.</summary>
    public virtual LargeKinfuParams GetParams()
    {
        ThrowIfDisposed();
        var intr = new Mat();
        var rgbIntr = new Mat();
        var volumePose = new Mat();
        try
        {
            using var icpIterations = new StdVector<int>();
            OutputArray intrArray = intr;
            OutputArray rgbIntrArray = rgbIntr;
            OutputArray volumePoseArray = volumePose;
            NativeMethods.HandleException(NativeMethods.rgbd_large_kinfu_LargeKinfu_getParams(
                Handle, out var pod, intrArray.Proxy, rgbIntrArray.Proxy, icpIterations.CvPtr,
                out var volumePod, volumePoseArray.Proxy));
            GC.KeepAlive(intr); GC.KeepAlive(rgbIntr); GC.KeepAlive(volumePose);
            var volumeParams = new LargeKinfuVolumeParams(volumePod, volumePose);
            return new LargeKinfuParams(pod, intr, rgbIntr, icpIterations.ToArray(), volumeParams);
        }
        catch
        {
            intr.Dispose(); rgbIntr.Dispose(); volumePose.Dispose();
            throw;
        }
    }

    /// <summary>Renders a 0-surface of the TSDF using Phong shading into a CV_8UC4 image, from the last frame's camera pose.</summary>
    public virtual void Render(OutputArray image)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_large_kinfu_LargeKinfu_render(Handle, image.Proxy));
        GC.KeepAlive(image.Source);
    }

    /// <summary>Renders a 0-surface of the TSDF using Phong shading into a CV_8UC4 image, from the given camera pose.</summary>
    public virtual void Render(OutputArray image, InputArray cameraPose)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_large_kinfu_LargeKinfu_renderWithPose(Handle, image.Proxy, cameraPose.Proxy));
        GC.KeepAlive(image.Source); GC.KeepAlive(cameraPose.Source);
    }

    /// <summary>Gets points and normals of the current 3D mesh. The order of points is undefined; normals correspond to points.</summary>
    public virtual void GetCloud(OutputArray points, OutputArray normals)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_large_kinfu_LargeKinfu_getCloud(Handle, points.Proxy, normals.Proxy));
        GC.KeepAlive(points.Source); GC.KeepAlive(normals.Source);
    }

    /// <summary>Gets points of the current 3D mesh. The order of points is undefined.</summary>
    public virtual void GetPoints(OutputArray points)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_large_kinfu_LargeKinfu_getPoints(Handle, points.Proxy));
        GC.KeepAlive(points.Source);
    }

    /// <summary>Calculates normals for the given points.</summary>
    public virtual void GetNormals(InputArray points, OutputArray normals)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_large_kinfu_LargeKinfu_getNormals(Handle, points.Proxy, normals.Proxy));
        GC.KeepAlive(points.Source); GC.KeepAlive(normals.Source);
    }

    /// <summary>Clears the current model and resets the pose.</summary>
    public virtual void Reset()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_large_kinfu_LargeKinfu_reset(Handle));
    }

    /// <summary>Gets the current pose in voxel space, as a 4x4 homogeneous transform matrix.</summary>
    public virtual Mat GetPose()
    {
        ThrowIfDisposed();
        var pose = new Mat();
        try
        {
            OutputArray poseArray = pose;
            NativeMethods.HandleException(NativeMethods.rgbd_large_kinfu_LargeKinfu_getPose(Handle, poseArray.Proxy));
            GC.KeepAlive(pose);
            return pose;
        }
        catch
        {
            pose.Dispose();
            throw;
        }
    }

    /// <summary>
    /// Integrates the next depth frame with respect to its ICP-calculated pose.
    /// The input image is converted to CV_32F internally if it has another type.
    /// </summary>
    /// <returns>true if the new frame was successfully aligned with the current scene, false otherwise.</returns>
    public virtual bool Update(InputArray depth)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.rgbd_large_kinfu_LargeKinfu_update(Handle, depth.Proxy, out var result));
        GC.KeepAlive(depth.Source);
        return result != 0;
    }
}
