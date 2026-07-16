using OpenCvSharp.Internal;

namespace OpenCvSharp.Hfs;

/// <summary>
/// Hierarchical Feature Selection for Efficient Image Segmentation.
///
/// This algorithm is executed in 3 stages: first, the SLIC (simple linear iterative clustering)
/// algorithm is used to obtain the superpixels of the input image. Second, each superpixel is viewed
/// as a node in a graph, and the EGB (Efficient Graph-based Image Segmentation) algorithm is used to
/// merge some of the nodes, obtaining a coarser segmentation, followed by a post process that merges
/// small regions into their nearby region. Third, the algorithm exploits a similar mechanism to further
/// merge the small regions obtained in the second stage into an even coarser segmentation.
/// </summary>
public class HfsSegment : Algorithm
{
    private HfsSegment(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, static p => NativeMethods.HandleException(NativeMethods.hfs_Ptr_HfsSegment_delete(p)))
    {
    }

    /// <summary>
    /// Creates a HfsSegment object.
    /// </summary>
    /// <param name="height">the height of the input image.</param>
    /// <param name="width">the width of the input image.</param>
    /// <param name="segEgbThresholdI">parameter segEgbThresholdI.</param>
    /// <param name="minRegionSizeI">parameter minRegionSizeI.</param>
    /// <param name="segEgbThresholdII">parameter segEgbThresholdII.</param>
    /// <param name="minRegionSizeII">parameter minRegionSizeII.</param>
    /// <param name="spatialWeight">parameter spatialWeight.</param>
    /// <param name="slicSpixelSize">parameter slicSpixelSize.</param>
    /// <param name="numSlicIter">parameter numSlicIter.</param>
    public static HfsSegment Create(
        int height, int width,
        float segEgbThresholdI = 0.08f, int minRegionSizeI = 100,
        float segEgbThresholdII = 0.28f, int minRegionSizeII = 200,
        float spatialWeight = 0.6f, int slicSpixelSize = 8, int numSlicIter = 5)
    {
        NativeMethods.HandleException(
            NativeMethods.hfs_HfsSegment_create(
                height, width,
                segEgbThresholdI, minRegionSizeI,
                segEgbThresholdII, minRegionSizeII,
                spatialWeight, slicSpixelSize, numSlicIter,
                out var smartPtr));

        NativeMethods.HandleException(NativeMethods.hfs_Ptr_HfsSegment_get(smartPtr, out var rawPtr));
        return new HfsSegment(smartPtr, rawPtr);
    }

    /// <summary>
    /// This parameter is used in the second stage. It is a constant used to threshold weights of the
    /// edge when merging adjacent nodes when applying EGB algorithm. The segmentation result tends to
    /// have more regions remained if this value is large and vice versa.
    /// </summary>
    public float SegEgbThresholdI
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.hfs_HfsSegment_getSegEgbThresholdI(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.hfs_HfsSegment_setSegEgbThresholdI(Handle, value));
        }
    }

    /// <summary>
    /// This parameter is used in the second stage. After the EGB segmentation, regions that have fewer
    /// pixels than this parameter will be merged into its adjacent region.
    /// </summary>
    public int MinRegionSizeI
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.hfs_HfsSegment_getMinRegionSizeI(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.hfs_HfsSegment_setMinRegionSizeI(Handle, value));
        }
    }

    /// <summary>
    /// This parameter is used in the third stage. It serves the same purpose as SegEgbThresholdI.
    /// </summary>
    public float SegEgbThresholdII
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.hfs_HfsSegment_getSegEgbThresholdII(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.hfs_HfsSegment_setSegEgbThresholdII(Handle, value));
        }
    }

    /// <summary>
    /// This parameter is used in the third stage. It serves the same purpose as MinRegionSizeI.
    /// </summary>
    public int MinRegionSizeII
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.hfs_HfsSegment_getMinRegionSizeII(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.hfs_HfsSegment_setMinRegionSizeII(Handle, value));
        }
    }

    /// <summary>
    /// This parameter is used in the first stage (the SLIC stage). It describes how important the role
    /// of position is when calculating the distance between each pixel and its center. The exact
    /// formula to calculate the distance is colorDistance + spatialWeight * spatialDistance. The
    /// segmentation result tends to have more local consistency if this value is larger.
    /// </summary>
    public float SpatialWeight
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.hfs_HfsSegment_getSpatialWeight(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.hfs_HfsSegment_setSpatialWeight(Handle, value));
        }
    }

    /// <summary>
    /// This parameter is used in the first stage (the SLIC stage). It describes the size of each
    /// superpixel when initializing SLIC. Every superpixel approximately has
    /// slicSpixelSize x slicSpixelSize pixels in the beginning.
    /// </summary>
    public int SlicSpixelSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.hfs_HfsSegment_getSlicSpixelSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.hfs_HfsSegment_setSlicSpixelSize(Handle, value));
        }
    }

    /// <summary>
    /// This parameter is used in the first stage. It describes how many iterations to perform when
    /// executing SLIC.
    /// </summary>
    public int NumSlicIter
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.hfs_HfsSegment_getNumSlicIter(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.hfs_HfsSegment_setNumSlicIter(Handle, value));
        }
    }

    /// <summary>
    /// Do segmentation on the GPU. This method falls back to the CPU implementation when OpenCV was
    /// not built with CUDA support.
    /// </summary>
    /// <param name="src">the input image.</param>
    /// <param name="ifDraw">if true, the returned Mat is a segmented picture where the color of each
    /// region is the average color of all pixels in that region, and its data type is the same as the
    /// input image. If false, the content of the returned Mat is a matrix of indices describing the
    /// region each pixel belongs to, and its data type is CV_16U.</param>
    public virtual Mat PerformSegmentGpu(InputArray src, bool ifDraw = true)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.hfs_HfsSegment_performSegmentGpu(Handle, src.Proxy, ifDraw, out var matPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(src.Source);
        return new Mat(matPtr);
    }

    /// <summary>
    /// Do segmentation with the CPU. This method is only implemented for reference; it is highly not
    /// recommended to use it.
    /// </summary>
    /// <param name="src">the input image.</param>
    /// <param name="ifDraw">if true, the returned Mat is a segmented picture where the color of each
    /// region is the average color of all pixels in that region, and its data type is the same as the
    /// input image. If false, the content of the returned Mat is a matrix of indices describing the
    /// region each pixel belongs to, and its data type is CV_16U.</param>
    public virtual Mat PerformSegmentCpu(InputArray src, bool ifDraw = true)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.hfs_HfsSegment_performSegmentCpu(Handle, src.Proxy, ifDraw, out var matPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(src.Source);
        return new Mat(matPtr);
    }
}
