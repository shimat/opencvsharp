using System.Collections.Generic;
using System.Linq;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// Abstract base class for shape transformation algorithms.
/// </summary>
public abstract class ShapeTransformer : Algorithm
{
    /// <inheritdoc />
    protected ShapeTransformer(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release) { }

    /// <summary>
    /// Creates a base-typed cv::Ptr&lt;ShapeTransformer&gt;* for use with SetTransformAlgorithm.
    /// The caller is responsible for deleting it via shape_Ptr_ShapeTransformer_delete.
    /// </summary>
    internal abstract IntPtr CreateBaseSmartPtr();

    /// <summary>
    /// Estimate the transformation parameters of the current transformer algorithm, based on point matches.
    /// </summary>
    /// <param name="transformingShape">Contour defining first shape.</param>
    /// <param name="targetShape">Contour defining second shape (to which the first will be transformed).</param>
    /// <param name="matches">Vector of matching points between the two contours.</param>
    public virtual void EstimateTransformation(
        InputArray transformingShape,
        InputArray targetShape,
        IEnumerable<DMatch> matches)
    {
        ThrowIfDisposed();
        if (transformingShape is null)
            throw new ArgumentNullException(nameof(transformingShape));
        if (targetShape is null)
            throw new ArgumentNullException(nameof(targetShape));
        if (matches is null)
            throw new ArgumentNullException(nameof(matches));
        transformingShape.ThrowIfDisposed();
        targetShape.ThrowIfDisposed();

        using var matchesVec = new VectorOfDMatch(matches);
        NativeMethods.HandleException(
            NativeMethods.shape_ShapeTransformer_estimateTransformation(
                RawPtr, transformingShape.CvPtr, targetShape.CvPtr, matchesVec.CvPtr));

        GC.KeepAlive(this);
        GC.KeepAlive(transformingShape);
        GC.KeepAlive(targetShape);
    }

    /// <summary>
    /// Apply a transformation to a contour, given a pre-estimated transformation.
    /// </summary>
    /// <param name="input">Contour (set of points) to apply the transformation to.</param>
    /// <param name="output">Output contour. If null, only the cost is returned without writing the output.</param>
    /// <returns>The transformation cost.</returns>
    public virtual float ApplyTransformation(InputArray input, OutputArray? output = null)
    {
        ThrowIfDisposed();
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        input.ThrowIfDisposed();
        output?.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.shape_ShapeTransformer_applyTransformation(
                RawPtr, input.CvPtr, output?.CvPtr ?? IntPtr.Zero, out var ret));

        GC.KeepAlive(this);
        GC.KeepAlive(input);
        output?.Fix();

        return ret;
    }

    /// <summary>
    /// Apply a transformation to an image.
    /// </summary>
    /// <param name="transformingImage">Input image to be transformed.</param>
    /// <param name="output">Output image.</param>
    /// <param name="flags">Image interpolation method. Default: InterpolationFlags.Linear.</param>
    /// <param name="borderMode">Border extrapolation method. Default: BorderTypes.Constant.</param>
    /// <param name="borderValue">Value used for BorderTypes.Constant borders. Default: black.</param>
    public virtual void WarpImage(
        InputArray transformingImage,
        OutputArray output,
        InterpolationFlags flags = InterpolationFlags.Linear,
        BorderTypes borderMode = BorderTypes.Constant,
        Scalar? borderValue = null)
    {
        ThrowIfDisposed();
        if (transformingImage is null)
            throw new ArgumentNullException(nameof(transformingImage));
        if (output is null)
            throw new ArgumentNullException(nameof(output));
        transformingImage.ThrowIfDisposed();
        output.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.shape_ShapeTransformer_warpImage(
                RawPtr,
                transformingImage.CvPtr,
                output.CvPtr,
                (int)flags,
                (int)borderMode,
                borderValue.GetValueOrDefault(Scalar.All(0))));

        GC.KeepAlive(this);
        GC.KeepAlive(transformingImage);
        output.Fix();
    }
}