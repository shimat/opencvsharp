using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.Dnn;

/// <summary>
/// This class represents high-level API for keypoints models.
/// KeypointsModel allows to set params for preprocessing input image.
/// KeypointsModel creates net from file with trained weights and config,
/// sets preprocessing input, runs forward pass and returns the x and y coordinates of each detected keypoint.
/// </summary>
public class KeypointsModel : Model
{
    /// <summary>
    /// Create keypoints model from network represented in one of the supported formats.
    /// An order of @p model and @p config arguments does not matter.
    /// </summary>
    /// <param name="model">Binary file contains trained weights.</param>
    /// <param name="config">Text file contains network configuration.</param>
    public KeypointsModel(string model, string? config = null)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));

        NativeMethods.HandleException(
            NativeMethods.dnn_KeypointsModel_new_String(model, config, out var p));
        SetHandle(p, NativeMethods.dnn_KeypointsModel_delete);
    }

    /// <summary>
    /// Create model from deep learning network.
    /// </summary>
    /// <param name="network">Net object.</param>
    public KeypointsModel(Net network)
    {
        if (network is null)
            throw new ArgumentNullException(nameof(network));

        NativeMethods.HandleException(
            NativeMethods.dnn_KeypointsModel_new_Net(network.CvPtr, out var p));
        GC.KeepAlive(network);
        SetHandle(p, NativeMethods.dnn_KeypointsModel_delete);
    }

    /// <summary>
    /// Given the @p input frame, create input blob, run net.
    /// </summary>
    /// <param name="frame">The input image.</param>
    /// <param name="thresh">minimum confidence threshold to select a keypoint.</param>
    /// <returns>a vector holding the x and y coordinates of each detected keypoint.</returns>
    public Point2f[] Estimate(InputArray frame, float thresh = 0.5f)
    {
        ThrowIfDisposed();
        if (frame is null)
            throw new ArgumentNullException(nameof(frame));
        frame.ThrowIfDisposed();

        using var keypointsVec = new VectorOfPoint2f();
        NativeMethods.HandleException(
            NativeMethods.dnn_KeypointsModel_estimate(CvPtr, frame.CvPtr, keypointsVec.CvPtr, thresh));
        GC.KeepAlive(this);
        GC.KeepAlive(frame);
        return keypointsVec.ToArray();
    }
}
