using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.Dnn;

/// <summary>
/// This class is presented high-level API for neural networks.
/// It allows to set params for preprocessing input image. It creates net from file with
/// trained weights and config, sets preprocessing input and runs forward pass.
/// </summary>
public class Model : CvObject
{
    #region Init &amp; Disposal

    /// <summary>
    /// For derived classes that construct the native object themselves.
    /// </summary>
    protected Model()
    {
    }

    /// <summary>
    /// Create model from deep learning network represented in one of the supported formats.
    /// An order of @p model and @p config arguments does not matter.
    /// </summary>
    /// <param name="model">Binary file contains trained weights.</param>
    /// <param name="config">Text file contains network configuration.</param>
    public Model(string model, string? config = null)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));

        NativeMethods.HandleException(
            NativeMethods.dnn_Model_new_String(model, config, out var p));
        SetHandle(p, NativeMethods.dnn_Model_delete);
    }

    /// <summary>
    /// Create model from deep learning network.
    /// </summary>
    /// <param name="network">Net object.</param>
    public Model(Net network)
    {
        if (network is null)
            throw new ArgumentNullException(nameof(network));

        NativeMethods.HandleException(
            NativeMethods.dnn_Model_new_Net(network.CvPtr, out var p));
        GC.KeepAlive(network);
        SetHandle(p, NativeMethods.dnn_Model_delete);
    }

    /// <summary>
    /// Sets the underlying native handle together with the correct destructor.
    /// </summary>
    /// <param name="p">native pointer</param>
    /// <param name="deleter">native destructor for the concrete model type</param>
    protected void SetHandle(IntPtr p, Func<IntPtr, ExceptionStatus> deleter)
    {
        if (deleter is null)
            throw new ArgumentNullException(nameof(deleter));
        SetSafeHandle(new OpenCvPtrSafeHandle(p, true,
            h => NativeMethods.HandleException(deleter(h))));
    }

    #endregion

    /// <summary>
    /// Set input size for frame.
    /// </summary>
    /// <param name="size">New input size.</param>
    /// <remarks>If shape of the new blob less than 0, then frame size not change.</remarks>
    public void SetInputSize(Size size)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Model_setInputSize(Handle, size));
    }

    /// <summary>
    /// Set input size for frame.
    /// </summary>
    /// <param name="width">New input width.</param>
    /// <param name="height">New input height.</param>
    public void SetInputSize(int width, int height) => SetInputSize(new Size(width, height));

    /// <summary>
    /// Set mean value for frame.
    /// </summary>
    /// <param name="mean">Scalar with mean values which are subtracted from channels.</param>
    public void SetInputMean(Scalar mean)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Model_setInputMean(Handle, mean));
    }

    /// <summary>
    /// Set scalefactor value for frame.
    /// </summary>
    /// <param name="scale">Multiplier for frame values.</param>
    public void SetInputScale(Scalar scale)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Model_setInputScale(Handle, scale));
    }

    /// <summary>
    /// Set flag crop for frame.
    /// </summary>
    /// <param name="crop">Flag which indicates whether image will be cropped after resize or not.</param>
    public void SetInputCrop(bool crop)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Model_setInputCrop(Handle, crop ? 1 : 0));
    }

    /// <summary>
    /// Set flag swapRB for frame.
    /// </summary>
    /// <param name="swapRB">Flag which indicates that swap first and last channels.</param>
    public void SetInputSwapRB(bool swapRB)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Model_setInputSwapRB(Handle, swapRB ? 1 : 0));
    }

    /// <summary>
    /// Set output names for frame.
    /// </summary>
    /// <param name="outNames">Names for output layers.</param>
    public void SetOutputNames(IEnumerable<string> outNames)
    {
        if (outNames is null)
            throw new ArgumentNullException(nameof(outNames));
        ThrowIfDisposed();

        var outNamesArray = outNames as string[] ?? outNames.ToArray();
        NativeMethods.HandleException(
            NativeMethods.dnn_Model_setOutputNames(Handle, outNamesArray, outNamesArray.Length));
    }

    /// <summary>
    /// Set preprocessing parameters for frame.
    /// </summary>
    /// <param name="scale">Multiplier for frame values.</param>
    /// <param name="size">New input size.</param>
    /// <param name="mean">Scalar with mean values which are subtracted from channels.</param>
    /// <param name="swapRB">Flag which indicates that swap first and last channels.</param>
    /// <param name="crop">Flag which indicates whether image will be cropped after resize or not.</param>
    public void SetInputParams(double scale = 1.0, Size? size = null, Scalar? mean = null, bool swapRB = false, bool crop = false)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Model_setInputParams(
                Handle, scale, size ?? new Size(), mean ?? new Scalar(), swapRB ? 1 : 0, crop ? 1 : 0));
    }

    /// <summary>
    /// Given the @p input frame, create input blob, run net and return the output @p blobs.
    /// </summary>
    /// <param name="frame">The input image.</param>
    /// <returns>Allocated output blobs, which will store results of the computation.</returns>
    public Mat[] Predict(InputArray frame)
    {
        ThrowIfDisposed();
        if (frame is null)
            throw new ArgumentNullException(nameof(frame));
        frame.ThrowIfDisposed();

        using var outsVec = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.dnn_Model_predict(Handle, frame.CvPtr, outsVec.CvPtr));
        GC.KeepAlive(frame);
        return outsVec.ToArray();
    }

    /// <summary>
    /// Ask network to use specific computation backend where it supported.
    /// </summary>
    /// <param name="backendId">backend identifier.</param>
    public void SetPreferableBackend(Backend backendId)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Model_setPreferableBackend(Handle, (int)backendId));
    }

    /// <summary>
    /// Ask network to make computations on specific target device.
    /// </summary>
    /// <param name="targetId">target identifier.</param>
    public void SetPreferableTarget(Target targetId)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Model_setPreferableTarget(Handle, (int)targetId));
    }

    /// <summary>
    /// Enables or disables the Winograd convolution optimization.
    /// </summary>
    /// <param name="useWinograd">true to enable, false to disable.</param>
    public void EnableWinograd(bool useWinograd)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_Model_enableWinograd(Handle, useWinograd ? 1 : 0));
    }
}
