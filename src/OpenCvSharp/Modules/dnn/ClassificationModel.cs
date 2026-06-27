using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.Dnn;

/// <summary>
/// This class represents high-level API for classification models.
/// ClassificationModel allows to set params for preprocessing input image.
/// ClassificationModel creates net from file with trained weights and config,
/// sets preprocessing input, runs forward pass and return top-1 prediction.
/// </summary>
public class ClassificationModel : Model
{
    /// <summary>
    /// Create classification model from network represented in one of the supported formats.
    /// An order of @p model and @p config arguments does not matter.
    /// </summary>
    /// <param name="model">Binary file contains trained weights.</param>
    /// <param name="config">Text file contains network configuration.</param>
    public ClassificationModel(string model, string? config = null)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));

        NativeMethods.HandleException(
            NativeMethods.dnn_ClassificationModel_new_String(model, config, out var p));
        SetHandle(p, NativeMethods.dnn_ClassificationModel_delete);
    }

    /// <summary>
    /// Create model from deep learning network.
    /// </summary>
    /// <param name="network">Net object.</param>
    public ClassificationModel(Net network)
    {
        if (network is null)
            throw new ArgumentNullException(nameof(network));

        NativeMethods.HandleException(
            NativeMethods.dnn_ClassificationModel_new_Net(network.CvPtr, out var p));
        GC.KeepAlive(network);
        SetHandle(p, NativeMethods.dnn_ClassificationModel_delete);
    }

    /// <summary>
    /// Set enable/disable softmax post processing option.
    /// </summary>
    /// <param name="enable">Set enable softmax post processing.</param>
    public void SetEnableSoftmaxPostProcessing(bool enable)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_ClassificationModel_setEnableSoftmaxPostProcessing(Handle, enable ? 1 : 0));
    }

    /// <summary>
    /// Get enable/disable softmax post processing option.
    /// </summary>
    /// <returns>true if softmax post processing is enabled.</returns>
    public bool GetEnableSoftmaxPostProcessing()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_ClassificationModel_getEnableSoftmaxPostProcessing(Handle, out var ret));
        return ret != 0;
    }

    /// <summary>
    /// Given the @p input frame, create input blob, run net and return top-1 prediction.
    /// </summary>
    /// <param name="frame">The input image.</param>
    /// <param name="classId">Top-1 predicted class id.</param>
    /// <param name="conf">Top-1 prediction confidence.</param>
    public void Classify(InputArray frame, out int classId, out float conf)
    {
        ThrowIfDisposed();
        if (frame is null)
            throw new ArgumentNullException(nameof(frame));
        frame.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.dnn_ClassificationModel_classify(Handle, frame.CvPtr, out classId, out conf));
        GC.KeepAlive(frame);
    }
}
