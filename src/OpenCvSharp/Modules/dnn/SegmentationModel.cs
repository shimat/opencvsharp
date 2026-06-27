using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.Dnn;

/// <summary>
/// This class represents high-level API for segmentation models.
/// SegmentationModel allows to set params for preprocessing input image.
/// SegmentationModel creates net from file with trained weights and config,
/// sets preprocessing input, runs forward pass and returns the class prediction for each pixel.
/// </summary>
public class SegmentationModel : Model
{
    /// <summary>
    /// Create segmentation model from network represented in one of the supported formats.
    /// An order of @p model and @p config arguments does not matter.
    /// </summary>
    /// <param name="model">Binary file contains trained weights.</param>
    /// <param name="config">Text file contains network configuration.</param>
    public SegmentationModel(string model, string? config = null)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));

        NativeMethods.HandleException(
            NativeMethods.dnn_SegmentationModel_new_String(model, config, out var p));
        SetHandle(p, NativeMethods.dnn_SegmentationModel_delete);
    }

    /// <summary>
    /// Create model from deep learning network.
    /// </summary>
    /// <param name="network">Net object.</param>
    public SegmentationModel(Net network)
    {
        if (network is null)
            throw new ArgumentNullException(nameof(network));

        NativeMethods.HandleException(
            NativeMethods.dnn_SegmentationModel_new_Net(network.CvPtr, out var p));
        GC.KeepAlive(network);
        SetHandle(p, NativeMethods.dnn_SegmentationModel_delete);
    }

    /// <summary>
    /// Given the @p input frame, create input blob, run net.
    /// </summary>
    /// <param name="frame">The input image.</param>
    /// <param name="mask">Allocated class prediction for each pixel.</param>
    public void Segment(InputArray frame, OutputArray mask)
    {
        ThrowIfDisposed();
        if (frame is null)
            throw new ArgumentNullException(nameof(frame));
        if (mask is null)
            throw new ArgumentNullException(nameof(mask));
        frame.ThrowIfDisposed();
        mask.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.dnn_SegmentationModel_segment(Handle, frame.CvPtr, mask.CvPtr));
        GC.KeepAlive(frame);
        mask.Fix();
    }
}
