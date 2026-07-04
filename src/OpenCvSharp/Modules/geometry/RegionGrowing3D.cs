using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace OpenCvSharp;

/// <summary>
/// Region Growing algorithm in 3D point cloud.
/// </summary>
/// <remarks>
/// The key idea of region growing is to merge the nearest neighbor points that satisfy a certain
/// angle threshold into the same region according to the normal between the two points, so as to
/// achieve the purpose of segmentation.
/// </remarks>
public class RegionGrowing3D : Algorithm
{
    private RegionGrowing3D(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.geometry_Ptr_RegionGrowing3D_delete(p)))
    {
    }

    /// <summary>
    /// Creates a RegionGrowing3D object.
    /// </summary>
    /// <returns>RegionGrowing3D instance</returns>
    public static RegionGrowing3D Create()
    {
        NativeMethods.HandleException(NativeMethods.geometry_createRegionGrowing3D(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.geometry_Ptr_RegionGrowing3D_get(smartPtr, out var rawPtr));
        return new RegionGrowing3D(smartPtr, rawPtr);
    }

    /// <summary>
    /// Executes segmentation using the Region Growing algorithm.
    /// </summary>
    /// <param name="regionsIdx">Index information of all points in each region.</param>
    /// <param name="labels">The label corresponds to the model number, 0 means it does not belong to
    /// any model, range [0, Number of final resultant models obtained].</param>
    /// <param name="inputPts">Original point cloud, support vector&lt;Point3f&gt; and Mat of size Nx3/3xN.</param>
    /// <param name="normals">Normal of each point, support vector&lt;Point3f&gt; and Mat of size Nx3.</param>
    /// <param name="nnIdx">Index information of nearest neighbors of all points. The first nearest
    /// neighbor of each point is itself. Support Mat of size NxK. If the information in a row is
    /// [0, 2, 1, -5, -1, 4, 7 ... negative number] it will use only non-negative indexes until it
    /// meets a negative number or bound of this row i.e. [0, 2, 1].</param>
    /// <returns>Number of final resultant regions obtained by segmentation.</returns>
    public virtual int Segment(out int[][] regionsIdx, OutputArray labels, InputArray inputPts, InputArray normals, InputArray nnIdx)
    {
        ThrowIfDisposed();

        using var regionsIdxVec = new VectorOfVectorInt32();
        NativeMethods.HandleException(
            NativeMethods.geometry_RegionGrowing3D_segment(
                Handle, regionsIdxVec.CvPtr, labels.Proxy, inputPts.Proxy, normals.Proxy, nnIdx.Proxy, out var ret));
        GC.KeepAlive(inputPts.Source);
        GC.KeepAlive(normals.Source);
        GC.KeepAlive(nnIdx.Source);
        regionsIdx = regionsIdxVec.ToArray();
        return ret;
    }

    /// <summary>
    /// The minimum size of region. Setting to a non-positive number or default will be unlimited.
    /// </summary>
    public virtual int MinSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_RegionGrowing3D_getMinSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_RegionGrowing3D_setMinSize(Handle, value));
        }
    }

    /// <summary>
    /// The maximum size of region. Setting to a non-positive number or default will be unlimited.
    /// </summary>
    public virtual int MaxSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_RegionGrowing3D_getMaxSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_RegionGrowing3D_setMaxSize(Handle, value));
        }
    }

    /// <summary>
    /// Whether to use the smoothness mode. Default is true.
    /// If true it will check the angle between the normal of the current point and the normal of its
    /// neighbor. Otherwise, it will check the angle between the normal of the seed point and the normal
    /// of the current neighbor.
    /// </summary>
    public virtual bool SmoothModeFlag
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_RegionGrowing3D_getSmoothModeFlag(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_RegionGrowing3D_setSmoothModeFlag(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Threshold value of the angle between normals, in radian. Default is 30(degree)*PI/180.
    /// </summary>
    public virtual double SmoothnessThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_RegionGrowing3D_getSmoothnessThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_RegionGrowing3D_setSmoothnessThreshold(Handle, value));
        }
    }

    /// <summary>
    /// Threshold value of curvature. Default is 0.05.
    /// Only points with curvature less than the threshold will be considered to belong to the same region.
    /// If the curvature of each point is not set, this option will not work.
    /// </summary>
    public virtual double CurvatureThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_RegionGrowing3D_getCurvatureThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_RegionGrowing3D_setCurvatureThreshold(Handle, value));
        }
    }

    /// <summary>
    /// The maximum number of neighbors to use including itself.
    /// Setting to a non-positive number or default will use the information from nnIdx.
    /// </summary>
    public virtual int MaxNumberOfNeighbors
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_RegionGrowing3D_getMaxNumberOfNeighbors(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_RegionGrowing3D_setMaxNumberOfNeighbors(Handle, value));
        }
    }

    /// <summary>
    /// The maximum number of regions you want. Setting to a non-positive number or default will be unlimited.
    /// </summary>
    public virtual int NumberOfRegions
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_RegionGrowing3D_getNumberOfRegions(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_RegionGrowing3D_setNumberOfRegions(Handle, value));
        }
    }

    /// <summary>
    /// Whether the results need to be sorted in descending order by the number of points.
    /// </summary>
    public virtual bool NeedSort
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_RegionGrowing3D_getNeedSort(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.geometry_RegionGrowing3D_setNeedSort(Handle, value ? 1 : 0));
        }
    }

    /// <summary>
    /// Sets the seed points, it will grow according to the seeds.
    /// If not set (or set to an empty array), the default method will be used:
    /// 1. If the curvature of each point is set, the seeds will be sorted in ascending order of curvatures.
    /// 2. Otherwise, the natural order of the point cloud will be used.
    /// </summary>
    public virtual void SetSeeds(InputArray seeds)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.geometry_RegionGrowing3D_setSeeds(Handle, seeds.Proxy));
        GC.KeepAlive(seeds.Source);
    }

    /// <summary>
    /// Gets the seed points.
    /// </summary>
    public virtual void GetSeeds(OutputArray seeds)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.geometry_RegionGrowing3D_getSeeds(Handle, seeds.Proxy));
    }

    /// <summary>
    /// Sets the curvature of each point. If not available, pass an empty array.
    /// </summary>
    public virtual void SetCurvatures(InputArray curvatures)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.geometry_RegionGrowing3D_setCurvatures(Handle, curvatures.Proxy));
        GC.KeepAlive(curvatures.Source);
    }

    /// <summary>
    /// Gets the curvature of each point, if set.
    /// </summary>
    public virtual void GetCurvatures(OutputArray curvatures)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.geometry_RegionGrowing3D_getCurvatures(Handle, curvatures.Proxy));
    }
}
