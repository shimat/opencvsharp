using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp.XImgProc;

/// <summary>
/// Class implementing edge detection algorithm from @cite Dollar2013 :
/// </summary>
public class StructuredEdgeDetection : Algorithm
{
    /// <summary>
    /// Creates instance by raw pointer
    /// </summary>
    private StructuredEdgeDetection(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_StructuredEdgeDetection_delete(p)))
    { }
    /// <summary>
    /// Creates a StructuredEdgeDetection
    /// </summary>
    /// <param name="model">name of the file where the model is stored</param>
    /// <param name="howToGetFeatures">optional object inheriting from RFFeatureGetter.
    /// You need it only if you would like to train your own forest, pass null otherwise</param>
    /// <returns></returns>
    public static StructuredEdgeDetection Create(string model, RFFeatureGetter? howToGetFeatures = null)
    {
        NativeMethods.HandleException(
            NativeMethods.ximgproc_createStructuredEdgeDetection(
                model, howToGetFeatures?.PtrObj ?? IntPtr.Zero, out var smartPtr));
        GC.KeepAlive(howToGetFeatures);
        NativeMethods.HandleException(NativeMethods.ximgproc_Ptr_StructuredEdgeDetection_get(smartPtr, out var rawPtr));
        return new StructuredEdgeDetection(smartPtr, rawPtr);
    }

    /// <summary>
    /// Returns array containing proposal boxes.
    /// </summary>
    /// <param name="edgeMap">edge image.</param>
    /// <param name="orientationMap">orientation map.</param>
    /// <param name="boxes">proposal boxes.</param>
    public virtual void GetBoundingBoxes(InputArray edgeMap, InputArray orientationMap, out Rect[] boxes)
    {
        ThrowIfDisposed();

        using var boxesVec = new StdVector<Rect>();
        NativeMethods.HandleException(
            NativeMethods.ximgproc_EdgeBoxes_getBoundingBoxes(Handle, edgeMap.Proxy, orientationMap.Proxy, boxesVec.CvPtr));
        boxes = boxesVec.ToArray();

        GC.KeepAlive(edgeMap.Source);
        GC.KeepAlive(orientationMap.Source);
    }

    /// <summary>
    /// The function detects edges in src and draw them to dst.
    /// The algorithm underlies this function is much more robust to texture presence, than common approaches, e.g.Sobel
    /// </summary>
    /// <param name="src">source image (RGB, float, in [0;1]) to detect edges</param>
    /// <param name="dst">destination image (grayscale, float, in [0;1]) where edges are drawn</param>
    public virtual void DetectEdges(InputArray src, OutputArray dst)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_StructuredEdgeDetection_detectEdges(Handle, src.Proxy, dst.Proxy));

        GC.KeepAlive(src.Source);
    }

    /// <summary>
    /// The function computes orientation from edge image.
    /// </summary>
    /// <param name="src">edge image.</param>
    /// <param name="dst">orientation image.</param>
    public virtual void ComputeOrientation(InputArray src, OutputArray dst)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_StructuredEdgeDetection_computeOrientation(Handle, src.Proxy, dst.Proxy));

        GC.KeepAlive(src.Source);
    }

    /// <summary>
    /// The function edgenms in edge image and suppress edges where edge is stronger in orthogonal direction.
    /// </summary>
    /// <param name="edgeImage">edge image from detectEdges function.</param>
    /// <param name="orientationImage">orientation image from computeOrientation function.</param>
    /// <param name="dst">suppressed image (grayscale, float, in [0;1])</param>
    /// <param name="r">radius for NMS suppression.</param>
    /// <param name="s">radius for boundary suppression.</param>
    /// <param name="m">multiplier for conservative suppression.</param>
    /// <param name="isParallel">enables/disables parallel computing.</param>
    public virtual void EdgesNms(InputArray edgeImage, InputArray orientationImage, OutputArray dst, 
        int r = 2, int s = 0, float m = 1, bool isParallel = true)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ximgproc_StructuredEdgeDetection_edgesNms(
                Handle, edgeImage.Proxy, orientationImage.Proxy, dst.Proxy, r, s, m, isParallel ? 1 : 0));

        GC.KeepAlive(edgeImage.Source);
        GC.KeepAlive(orientationImage.Source);
    }

    }
