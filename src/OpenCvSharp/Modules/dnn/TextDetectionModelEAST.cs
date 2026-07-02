using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.Dnn;

/// <summary>
/// This class represents high-level API for text detection DL networks compatible with EAST model.
/// </summary>
public class TextDetectionModelEAST : TextDetectionModel
{
    /// <summary>
    /// Create text detection model from network represented in one of the supported formats.
    /// An order of @p model and @p config arguments does not matter.
    /// </summary>
    /// <param name="model">Binary file contains trained weights.</param>
    /// <param name="config">Text file contains network configuration.</param>
    public TextDetectionModelEAST(string model, string? config = null)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));

        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_EAST_new_String(model, config, out var p));
        SetHandle(p, NativeMethods.dnn_TextDetectionModel_EAST_delete);
    }

    /// <summary>
    /// Create model from deep learning network.
    /// </summary>
    /// <param name="network">Net object.</param>
    public TextDetectionModelEAST(Net network)
    {
        if (network is null)
            throw new ArgumentNullException(nameof(network));

        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_EAST_new_Net(network.CvPtr, out var p));
        GC.KeepAlive(network);
        SetHandle(p, NativeMethods.dnn_TextDetectionModel_EAST_delete);
    }

    /// <summary>
    /// Set the detection confidence threshold.
    /// </summary>
    /// <param name="confThreshold">A threshold used to filter boxes by confidences.</param>
    public void SetConfidenceThreshold(float confThreshold)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_EAST_setConfidenceThreshold(Handle, confThreshold));
    }

    /// <summary>
    /// Get the detection confidence threshold.
    /// </summary>
    /// <returns>the detection confidence threshold</returns>
    public float GetConfidenceThreshold()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_EAST_getConfidenceThreshold(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Set the detection NMS filter threshold.
    /// </summary>
    /// <param name="nmsThreshold">A threshold used in non maximum suppression.</param>
    public void SetNMSThreshold(float nmsThreshold)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_EAST_setNMSThreshold(Handle, nmsThreshold));
    }

    /// <summary>
    /// Get the detection NMS filter threshold.
    /// </summary>
    /// <returns>the detection NMS filter threshold</returns>
    public float GetNMSThreshold()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_EAST_getNMSThreshold(Handle, out var ret));
        return ret;
    }
}
