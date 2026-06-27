using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Maximal Stable Extremal Regions class
/// </summary>
// ReSharper disable once InconsistentNaming
public class MSER : Feature2D
{
    /// <summary>
    /// Creates instance by raw pointer cv::MSER*
    /// </summary>
    private MSER(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.features_Ptr_MSER_delete(p)))
    {
    }

    /// <summary>
    /// Creates MSER parameters
    /// </summary>
    /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
    /// <param name="minArea">prune the area which smaller than min_area</param>
    /// <param name="maxArea">prune the area which bigger than max_area</param>
    /// <param name="maxVariation">prune the area have simliar size to its children</param>
    /// <param name="minDiversity">trace back to cut off mser with diversity &lt; min_diversity</param>
    /// <param name="maxEvolution">for color image, the evolution steps</param>
    /// <param name="areaThreshold">the area threshold to cause re-initialize</param>
    /// <param name="minMargin">ignore too small margin</param>
    /// <param name="edgeBlurSize">the aperture size for edge blur</param>
    public static MSER Create(
        int delta = 5, 
        int minArea = 60, 
        int maxArea = 14400, 
        double maxVariation = 0.25, 
        double minDiversity = 0.2, 
        int maxEvolution = 200, 
        double areaThreshold = 1.01, 
        double minMargin = 0.003, 
        int edgeBlurSize = 5)
    {
        NativeMethods.HandleException(
            NativeMethods.features_MSER_create(delta, minArea, maxArea, maxVariation, minDiversity,
                maxEvolution, areaThreshold, minMargin, edgeBlurSize, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.features_Ptr_Feature2D_get(smartPtr, out var rawPtr));
        return new MSER(smartPtr, rawPtr);
    }

    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public int Delta
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_MSER_getDelta(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_MSER_setDelta(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int MinArea
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_MSER_getMinArea(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_MSER_setMinArea(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int MaxArea
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_MSER_getMaxArea(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_MSER_setMaxArea(Handle, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public bool Pass2Only
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_MSER_getPass2Only(Handle, out var ret));
            return ret != 0;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.features_MSER_setPass2Only(Handle, value ? 1 : 0));
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Detect MSER regions
    /// </summary>
    /// <param name="image">input image (8UC1, 8UC3 or 8UC4, must be greater or equal than 3x3)</param>
    /// <param name="msers">resulting list of point sets</param>
    /// <param name="bboxes">resulting bounding boxes</param>
    public virtual void DetectRegions(
        InputArray image, out Point[][] msers, out Rect[] bboxes)
    {
        ThrowIfDisposed();
        if (image is null) 
            throw new ArgumentNullException(nameof(image));
        image.ThrowIfDisposed();

        using (var msersVec = new VectorOfVectorPoint())
        using (var bboxesVec = new StdVector<Rect>())
        {
            NativeMethods.HandleException(
                NativeMethods.features_MSER_detectRegions(
                    Handle, image.CvPtr, msersVec.CvPtr, bboxesVec.CvPtr));
            msers = msersVec.ToArray();
            bboxes = bboxesVec.ToArray();
        }

        GC.KeepAlive(image);
    }

    #endregion
}
