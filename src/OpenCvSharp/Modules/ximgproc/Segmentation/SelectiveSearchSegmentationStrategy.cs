using System.Diagnostics.CodeAnalysis;
using OpenCvSharp.Internal;

namespace OpenCvSharp.XImgProc.Segmentation;

/// <inheritdoc />
/// <summary>
/// Strategy for the selective search segmentation algorithm.
/// The class implements a generic stragery for the algorithm described in @cite uijlings2013selective.
/// </summary>
public abstract class SelectiveSearchSegmentationStrategy : Algorithm
{
    /// <summary>
    /// 
    /// </summary>
    public IntPtr PtrObj { get; }

    /// <summary>
    /// Creates instance via factory pattern (cv::Ptr&lt;T&gt;* + raw T*).
    /// </summary>
    protected SelectiveSearchSegmentationStrategy(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release)
    {
        PtrObj = smartPtr;
    }

    /// <summary>
    /// Set a initial image, with a segementation.
    /// </summary>
    /// <param name="img">The input image. Any number of channel can be provided</param>
    /// <param name="regions">A segementation of the image. The parameter must be the same size of img.</param>
    /// <param name="sizes">The sizes of different regions</param>
    /// <param name="imageId">If not set to -1, try to cache pre-computations. If the same set og (img, regions, size) is used, the image_id need to be the same.</param>
    public virtual void SetImage(InputArray img, InputArray regions, InputArray sizes, int imageId = -1)
    {
        ThrowIfDisposed();
        if (img is null)
            throw new ArgumentNullException(nameof(img));
        if (regions is null)
            throw new ArgumentNullException(nameof(regions));
        if (sizes is null)
            throw new ArgumentNullException(nameof(sizes));
        img.ThrowIfDisposed();
        regions.ThrowIfDisposed();
        sizes.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentationStrategy_setImage(
                RawPtr, img.CvPtr, regions.CvPtr, sizes.CvPtr, imageId));

        GC.KeepAlive(this);
        GC.KeepAlive(img);
        GC.KeepAlive(regions);
        GC.KeepAlive(sizes);
    }

    /// <summary>
    /// Return the score between two regions (between 0 and 1)
    /// </summary>
    /// <param name="r1">The first region</param>
    /// <param name="r2">The second region</param>
    [SuppressMessage("Microsoft.Design", "CA1716: Identifiers should not match keywords")]
    public virtual float Get(int r1, int r2)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentationStrategy_get(RawPtr, r1, r2, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Inform the strategy that two regions will be merged
    /// </summary>
    /// <param name="r1">The first region</param>
    /// <param name="r2">The second region</param>
    public virtual void Merge(int r1, int r2)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ximgproc_segmentation_SelectiveSearchSegmentationStrategy_merge(RawPtr, r1, r2));
        GC.KeepAlive(this);
    }
}

/// <inheritdoc />
/// <summary>
/// Color-based strategy for the selective search segmentation algorithm.
/// The class is implemented from the algorithm described in @cite uijlings2013selective.
/// </summary>
public class SelectiveSearchSegmentationStrategyColor : SelectiveSearchSegmentationStrategy {

    /// <inheritdoc />
    /// <summary>
    /// Creates instance by raw pointer
    /// </summary>
    private SelectiveSearchSegmentationStrategyColor(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_delete(p)))
    { }

    /// <summary>
    /// Create a new color-based strategy
    /// </summary>
    /// <returns></returns>
    public static SelectiveSearchSegmentationStrategyColor Create()
    {
        NativeMethods.HandleException(
            NativeMethods.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyColor(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_get(smartPtr, out var rawPtr));
        return new SelectiveSearchSegmentationStrategyColor(smartPtr, rawPtr);
    }
}

/// <inheritdoc />
/// <summary>
/// Size-based strategy for the selective search segmentation algorithm.
/// The class is implemented from the algorithm described in @cite uijlings2013selective.
/// </summary>
public class SelectiveSearchSegmentationStrategySize : SelectiveSearchSegmentationStrategy
{
    /// <inheritdoc />
    /// <summary>
    /// Creates instance by raw pointer
    /// </summary>
    private SelectiveSearchSegmentationStrategySize(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_delete(p)))
    { }

    /// <summary>
    /// Create a new size-based strategy
    /// </summary>
    /// <returns></returns>
    public static SelectiveSearchSegmentationStrategySize Create()
    {
        NativeMethods.HandleException(
            NativeMethods.ximgproc_segmentation_createSelectiveSearchSegmentationStrategySize(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_get(smartPtr, out var rawPtr));
        return new SelectiveSearchSegmentationStrategySize(smartPtr, rawPtr);
    }
}

/// <summary>
/// Texture-based strategy for the selective search segmentation algorithm.
/// The class is implemented from the algorithm described in @cite uijlings2013selective.
/// </summary>
public class SelectiveSearchSegmentationStrategyTexture : SelectiveSearchSegmentationStrategy {
    /// <inheritdoc />
    /// <summary>
    /// Creates instance by raw pointer
    /// </summary>
    private SelectiveSearchSegmentationStrategyTexture(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_delete(p)))
    { }

    /// <summary>
    /// Create a new texture-based strategy
    /// </summary>
    /// <returns></returns>
    public static SelectiveSearchSegmentationStrategyTexture Create()
    {
        NativeMethods.HandleException(
            NativeMethods.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyTexture(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_get(smartPtr, out var rawPtr));
        return new SelectiveSearchSegmentationStrategyTexture(smartPtr, rawPtr);
    }
}

/// <summary>
/// Fill-based strategy for the selective search segmentation algorithm.
/// The class is implemented from the algorithm described in @cite uijlings2013selective.
/// </summary>
public class SelectiveSearchSegmentationStrategyFill : SelectiveSearchSegmentationStrategy {
    /// <inheritdoc />
    /// <summary>
    /// Creates instance by raw pointer
    /// </summary>
    private SelectiveSearchSegmentationStrategyFill(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_delete(p)))
    { }

    /// <summary>
    /// Create a new fill-based strategy
    /// </summary>
    /// <returns></returns>
    public static SelectiveSearchSegmentationStrategyFill Create()
    {
        NativeMethods.HandleException(
            NativeMethods.ximgproc_segmentation_createSelectiveSearchSegmentationStrategyFill(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_get(smartPtr, out var rawPtr));
        return new SelectiveSearchSegmentationStrategyFill(smartPtr, rawPtr);
    }
}
