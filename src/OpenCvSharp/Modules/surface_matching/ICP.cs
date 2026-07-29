using OpenCvSharp.Internal;

namespace OpenCvSharp.PpfMatch3D;

/// <summary>
/// Iterative Closest Point registration for 3D point clouds.
/// </summary>
public sealed class ICP : CvObject
{
    /// <summary>
    /// Creates an ICP instance with the OpenCV defaults.
    /// </summary>
    public ICP()
    {
        NativeMethods.HandleException(
            NativeMethods.surface_matching_ICP_new1(out var ptr));
        SetSafeHandle(new OpenCvPtrSafeHandle(
            ptr,
            ownsHandle: true,
            releaseAction: static p => NativeMethods.HandleException(
                NativeMethods.surface_matching_ICP_delete(p))));
    }

    /// <summary>
    /// Creates an ICP instance.
    /// </summary>
    /// <param name="iterations">Maximum number of ICP iterations.</param>
    /// <param name="tolerance">Registration accuracy at each pyramid level.</param>
    /// <param name="rejectionScale">Standard-deviation coefficient used for robust outlier rejection.</param>
    /// <param name="numberOfLevels">Number of point-cloud pyramid levels.</param>
    public ICP(
        int iterations,
        float tolerance = 0.05f,
        float rejectionScale = 2.5f,
        int numberOfLevels = 6)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(iterations);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(tolerance);
        ArgumentOutOfRangeException.ThrowIfNegative(rejectionScale);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numberOfLevels);

        NativeMethods.HandleException(
            NativeMethods.surface_matching_ICP_new2(
                iterations,
                tolerance,
                rejectionScale,
                numberOfLevels,
                out var ptr));
        SetSafeHandle(new OpenCvPtrSafeHandle(
            ptr,
            ownsHandle: true,
            releaseAction: static p => NativeMethods.HandleException(
                NativeMethods.surface_matching_ICP_delete(p))));
    }

    /// <summary>
    /// Registers a source point cloud to a destination point cloud.
    /// </summary>
    /// <param name="sourcePointCloud">Source point cloud as an N-by-6 CV_32F matrix containing XYZ coordinates and normals.</param>
    /// <param name="destinationPointCloud">Destination point cloud as an N-by-6 CV_32F matrix containing XYZ coordinates and normals.</param>
    /// <param name="residual">Output registration error.</param>
    /// <param name="pose">Output 4-by-4 CV_64F transformation from the source point cloud to the destination point cloud.</param>
    /// <returns>Zero on success.</returns>
    public int RegisterModelToScene(
        InputArray sourcePointCloud,
        InputArray destinationPointCloud,
        out double residual,
        out Mat pose)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.surface_matching_ICP_registerModelToScene(
                Handle,
                sourcePointCloud.Proxy,
                destinationPointCloud.Proxy,
                out residual,
                out var posePtr,
                out var returnValue));
        pose = new Mat(posePtr);

        GC.KeepAlive(this);
        GC.KeepAlive(sourcePointCloud.Source);
        GC.KeepAlive(destinationPointCloud.Source);
        return returnValue;
    }
}
