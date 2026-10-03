using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>Octree for point-cloud storage and nearest-neighbor queries.</summary>
public sealed class Octree : CvPtrObject
{
    private Octree(IntPtr smartPtr)
        : base(smartPtr, GetRawPtr(smartPtr),
            static p => NativeMethods.HandleException(NativeMethods.ptcloud_Ptr_Octree_delete(p)))
    {
    }

    private static IntPtr GetRawPtr(IntPtr smartPtr)
    {
        if (smartPtr == IntPtr.Zero)
            throw new OpenCvSharpException("Failed to create Octree.");
        NativeMethods.HandleException(NativeMethods.ptcloud_Ptr_Octree_get(smartPtr, out var rawPtr));
        if (rawPtr == IntPtr.Zero)
            throw new OpenCvSharpException("Failed to create Octree.");
        return rawPtr;
    }

    /// <summary>Creates an empty octree with a maximum depth and bounding cube.</summary>
    public static Octree CreateWithDepth(int maxDepth, double size,
        Point3f origin = default, bool withColors = false)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maxDepth);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(size);
        NativeMethods.HandleException(NativeMethods.ptcloud_Octree_createWithDepthSize(
            maxDepth, size, origin, withColors ? 1 : 0, out var ptr));
        return new Octree(ptr);
    }

    /// <summary>Creates an octree from a point cloud with a maximum depth.</summary>
    public static Octree CreateWithDepth(int maxDepth, InputArray pointCloud, InputArray colors = default)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maxDepth);
        NativeMethods.HandleException(NativeMethods.ptcloud_Octree_createWithDepthCloud(
            maxDepth, pointCloud.Proxy, colors.Proxy, out var ptr));
        GC.KeepAlive(pointCloud.Source);
        GC.KeepAlive(colors.Source);
        return new Octree(ptr);
    }

    /// <summary>Creates an empty octree with a leaf resolution and bounding cube.</summary>
    public static Octree CreateWithResolution(double resolution, double size,
        Point3f origin = default, bool withColors = false)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(resolution);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(size);
        NativeMethods.HandleException(NativeMethods.ptcloud_Octree_createWithResolutionSize(
            resolution, size, origin, withColors ? 1 : 0, out var ptr));
        return new Octree(ptr);
    }

    /// <summary>Creates an octree from a point cloud with a leaf resolution.</summary>
    public static Octree CreateWithResolution(double resolution, InputArray pointCloud,
        InputArray colors = default)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(resolution);
        NativeMethods.HandleException(NativeMethods.ptcloud_Octree_createWithResolutionCloud(
            resolution, pointCloud.Proxy, colors.Proxy, out var ptr));
        GC.KeepAlive(pointCloud.Source);
        GC.KeepAlive(colors.Source);
        return new Octree(ptr);
    }

    /// <summary>Inserts a point and optional color.</summary>
    public bool InsertPoint(Point3f point, Point3f color = default)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.ptcloud_Octree_insertPoint(Handle, point, color, out var result));
        return result != 0;
    }

    /// <summary>Returns whether a point lies inside the octree bounds.</summary>
    public bool IsPointInBound(Point3f point)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.ptcloud_Octree_isPointInBound(Handle, point, out var result));
        return result != 0;
    }

    /// <summary>Returns whether the octree has no root node.</summary>
    public bool Empty()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.ptcloud_Octree_empty(Handle, out var result));
        return result != 0;
    }

    /// <summary>Clears all stored points.</summary>
    public void Clear()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.ptcloud_Octree_clear(Handle));
    }

    /// <summary>Deletes a stored point.</summary>
    public bool DeletePoint(Point3f point)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.ptcloud_Octree_deletePoint(Handle, point, out var result));
        return result != 0;
    }

    /// <summary>Restores a point cloud from the octree's leaf nodes.</summary>
    public void GetPointCloud(OutputArray pointCloud, OutputArray colors = default)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.ptcloud_Octree_getPointCloud(
            Handle, pointCloud.Proxy, colors.Proxy));
        GC.KeepAlive(pointCloud.Source);
        GC.KeepAlive(colors.Source);
    }

    /// <summary>Finds all points within the given radius.</summary>
    public int RadiusNNSearch(Point3f query, float radius, OutputArray points,
        OutputArray squareDists = default)
    {
        ThrowIfDisposed();
        ArgumentOutOfRangeException.ThrowIfNegative(radius);
        NativeMethods.HandleException(NativeMethods.ptcloud_Octree_radiusSearch(
            Handle, query, radius, points.Proxy, squareDists.Proxy, out var count));
        GC.KeepAlive(points.Source);
        GC.KeepAlive(squareDists.Source);
        return count;
    }

    /// <summary>Finds all points and colors within the given radius.</summary>
    public int RadiusNNSearch(Point3f query, float radius, OutputArray points,
        OutputArray colors, OutputArray squareDists)
    {
        ThrowIfDisposed();
        ArgumentOutOfRangeException.ThrowIfNegative(radius);
        NativeMethods.HandleException(NativeMethods.ptcloud_Octree_radiusSearchColor(
            Handle, query, radius, points.Proxy, colors.Proxy, squareDists.Proxy, out var count));
        GC.KeepAlive(points.Source);
        GC.KeepAlive(colors.Source);
        GC.KeepAlive(squareDists.Source);
        return count;
    }

    /// <summary>Finds the nearest points to a query point.</summary>
    public void KNNSearch(Point3f query, int k, OutputArray points,
        OutputArray squareDists = default)
    {
        ThrowIfDisposed();
        ArgumentOutOfRangeException.ThrowIfNegative(k);
        NativeMethods.HandleException(NativeMethods.ptcloud_Octree_knnSearch(
            Handle, query, k, points.Proxy, squareDists.Proxy));
        GC.KeepAlive(points.Source);
        GC.KeepAlive(squareDists.Source);
    }

    /// <summary>Finds the nearest points and colors to a query point.</summary>
    public void KNNSearch(Point3f query, int k, OutputArray points,
        OutputArray colors, OutputArray squareDists)
    {
        ThrowIfDisposed();
        ArgumentOutOfRangeException.ThrowIfNegative(k);
        NativeMethods.HandleException(NativeMethods.ptcloud_Octree_knnSearchColor(
            Handle, query, k, points.Proxy, colors.Proxy, squareDists.Proxy));
        GC.KeepAlive(points.Source);
        GC.KeepAlive(colors.Source);
        GC.KeepAlive(squareDists.Source);
    }
}
