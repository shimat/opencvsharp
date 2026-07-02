using OpenCvSharp.Internal;

// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.Dnn;

/// <summary>
/// This class represents high-level API for text detection DL networks compatible with DB model.
/// </summary>
public class TextDetectionModelDB : TextDetectionModel
{
    /// <summary>
    /// Create text detection model from network represented in one of the supported formats.
    /// An order of @p model and @p config arguments does not matter.
    /// </summary>
    /// <param name="model">Binary file contains trained weights.</param>
    /// <param name="config">Text file contains network configuration.</param>
    public TextDetectionModelDB(string model, string? config = null)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));

        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_DB_new_String(model, config, out var p));
        SetHandle(p, NativeMethods.dnn_TextDetectionModel_DB_delete);
    }

    /// <summary>
    /// Create model from deep learning network.
    /// </summary>
    /// <param name="network">Net object.</param>
    public TextDetectionModelDB(Net network)
    {
        if (network is null)
            throw new ArgumentNullException(nameof(network));

        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_DB_new_Net(network.CvPtr, out var p));
        GC.KeepAlive(network);
        SetHandle(p, NativeMethods.dnn_TextDetectionModel_DB_delete);
    }

    /// <summary>
    /// Set the detection binary threshold.
    /// </summary>
    /// <param name="binaryThreshold">the detection binary threshold</param>
    public void SetBinaryThreshold(float binaryThreshold)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_DB_setBinaryThreshold(Handle, binaryThreshold));
    }

    /// <summary>
    /// Get the detection binary threshold.
    /// </summary>
    /// <returns>the detection binary threshold</returns>
    public float GetBinaryThreshold()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_DB_getBinaryThreshold(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Set the polygon threshold.
    /// </summary>
    /// <param name="polygonThreshold">the polygon threshold</param>
    public void SetPolygonThreshold(float polygonThreshold)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_DB_setPolygonThreshold(Handle, polygonThreshold));
    }

    /// <summary>
    /// Get the polygon threshold.
    /// </summary>
    /// <returns>the polygon threshold</returns>
    public float GetPolygonThreshold()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_DB_getPolygonThreshold(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Set the unclip ratio.
    /// </summary>
    /// <param name="unclipRatio">the unclip ratio</param>
    public void SetUnclipRatio(double unclipRatio)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_DB_setUnclipRatio(Handle, unclipRatio));
    }

    /// <summary>
    /// Get the unclip ratio.
    /// </summary>
    /// <returns>the unclip ratio</returns>
    public double GetUnclipRatio()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_DB_getUnclipRatio(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Set the max candidates of polygons.
    /// </summary>
    /// <param name="maxCandidates">the max candidates of polygons</param>
    public void SetMaxCandidates(int maxCandidates)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_DB_setMaxCandidates(Handle, maxCandidates));
    }

    /// <summary>
    /// Get the max candidates of polygons.
    /// </summary>
    /// <returns>the max candidates of polygons</returns>
    public int GetMaxCandidates()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_TextDetectionModel_DB_getMaxCandidates(Handle, out var ret));
        return ret;
    }
}
