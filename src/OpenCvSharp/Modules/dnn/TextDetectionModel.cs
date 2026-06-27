using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.Dnn;

/// <summary>
/// Base class for text detection networks.
/// This is an abstract base; use <see cref="TextDetectionModelEAST"/> or
/// <see cref="TextDetectionModelDB"/>.
/// </summary>
public abstract class TextDetectionModel : Model
{
    /// <summary>
    /// For derived classes that construct the native object themselves.
    /// </summary>
    protected TextDetectionModel()
    {
    }

    /// <summary>
    /// Performs detection. Given the input @p frame, prepare network input, run network inference, post-process network
    /// output and return result detections. Each result is quadrangle's 4 points in this order:
    /// bottom-left, top-left, top-right, bottom-right.
    /// </summary>
    /// <param name="frame">The input image.</param>
    /// <param name="detections">array with detections' quadrangles (4 points per result).</param>
    /// <param name="confidences">array with detection confidences.</param>
    public void Detect(InputArray frame, out Point[][] detections, out float[] confidences)
    {
        ThrowIfDisposed();
        if (frame is null)
            throw new ArgumentNullException(nameof(frame));
        frame.ThrowIfDisposed();

        using var detectionsVec = new VectorOfVectorPoint();
        using var confidencesVec = new StdVector<float>();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_detect(CvPtr, frame.CvPtr, detectionsVec.CvPtr, confidencesVec.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(frame);

        detections = detectionsVec.ToArray();
        confidences = confidencesVec.ToArray();
    }

    /// <summary>
    /// Performs detection. Given the input @p frame, prepare network input, run network inference, post-process network
    /// output and return result detections. Each result is rotated rectangle.
    /// </summary>
    /// <param name="frame">The input image.</param>
    /// <param name="detections">array with detections' RotatedRect results.</param>
    /// <param name="confidences">array with detection confidences.</param>
    public void DetectTextRectangles(InputArray frame, out RotatedRect[] detections, out float[] confidences)
    {
        ThrowIfDisposed();
        if (frame is null)
            throw new ArgumentNullException(nameof(frame));
        frame.ThrowIfDisposed();

        using var detectionsVec = new StdVector<RotatedRect>();
        using var confidencesVec = new StdVector<float>();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_detectTextRectangles(CvPtr, frame.CvPtr, detectionsVec.CvPtr, confidencesVec.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(frame);

        detections = detectionsVec.ToArray();
        confidences = confidencesVec.ToArray();
    }
}
