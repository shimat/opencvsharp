using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.Dnn;

/// <summary>
/// This class represents high-level API for object detection networks.
/// DetectionModel allows to set params for preprocessing input image.
/// DetectionModel creates net from file with trained weights and config,
/// sets preprocessing input, runs forward pass and return result detections.
/// </summary>
public class DetectionModel : Model
{
    /// <summary>
    /// Create detection model from network represented in one of the supported formats.
    /// An order of @p model and @p config arguments does not matter.
    /// </summary>
    /// <param name="model">Binary file contains trained weights.</param>
    /// <param name="config">Text file contains network configuration.</param>
    public DetectionModel(string model, string? config = null)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));

        NativeMethods.HandleException(
            NativeMethods.dnn_DetectionModel_new_String(model, config, out var p));
        SetHandle(p, NativeMethods.dnn_DetectionModel_delete);
    }

    /// <summary>
    /// Create model from deep learning network.
    /// </summary>
    /// <param name="network">Net object.</param>
    public DetectionModel(Net network)
    {
        if (network is null)
            throw new ArgumentNullException(nameof(network));

        NativeMethods.HandleException(
            NativeMethods.dnn_DetectionModel_new_Net(network.CvPtr, out var p));
        GC.KeepAlive(network);
        SetHandle(p, NativeMethods.dnn_DetectionModel_delete);
    }

    /// <summary>
    /// nmsAcrossClasses defaults to false,
    /// such that when non max suppression is used during the detect() function, it will do so per-class.
    /// This function allows you to toggle this behaviour.
    /// </summary>
    /// <param name="value">The new value for nmsAcrossClasses.</param>
    public void SetNmsAcrossClasses(bool value)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_DetectionModel_setNmsAcrossClasses(CvPtr, value ? 1 : 0));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Getter for nmsAcrossClasses. This variable defaults to false,
    /// such that when non max suppression is used during the detect() function, it will do so only per-class.
    /// </summary>
    /// <returns>true if nms is performed across classes.</returns>
    public bool GetNmsAcrossClasses()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_DetectionModel_getNmsAcrossClasses(CvPtr, out var ret));
        GC.KeepAlive(this);
        return ret != 0;
    }

    /// <summary>
    /// Given the @p input frame, create input blob, run net and return result detections.
    /// </summary>
    /// <param name="frame">The input image.</param>
    /// <param name="classIds">Class indexes in result detection.</param>
    /// <param name="confidences">A set of corresponding confidences.</param>
    /// <param name="boxes">A set of bounding boxes.</param>
    /// <param name="confThreshold">A threshold used to filter boxes by confidences.</param>
    /// <param name="nmsThreshold">A threshold used in non maximum suppression.</param>
    public void Detect(
        InputArray frame, out int[] classIds, out float[] confidences, out Rect[] boxes,
        float confThreshold = 0.5f, float nmsThreshold = 0.0f)
    {
        ThrowIfDisposed();
        if (frame is null)
            throw new ArgumentNullException(nameof(frame));
        frame.ThrowIfDisposed();

        using var classIdsVec = new StdVector<int>();
        using var confidencesVec = new StdVector<float>();
        using var boxesVec = new StdVector<Rect>();
        NativeMethods.HandleException(
            NativeMethods.dnn_DetectionModel_detect(
                CvPtr, frame.CvPtr, classIdsVec.CvPtr, confidencesVec.CvPtr, boxesVec.CvPtr,
                confThreshold, nmsThreshold));
        GC.KeepAlive(this);
        GC.KeepAlive(frame);

        classIds = classIdsVec.ToArray();
        confidences = confidencesVec.ToArray();
        boxes = boxesVec.ToArray();
    }
}
