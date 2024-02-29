using System.Diagnostics.CodeAnalysis;
using OpenCvSharp.Dnn;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.DnnSuperres;

/// <summary>
///  A class to upscale images via convolutional neural networks.
/// The following four models are implemented:
/// - edsr
/// - espcn
/// - fsrcnn
/// - lapsrn
/// </summary>
public class DnnSuperResImpl : DisposableCvObject
{
    /// <inheritdoc />
    /// <summary>
    /// Empty constructor
    /// </summary>
    public DnnSuperResImpl()
    {
        NativeMethods.HandleException(
            NativeMethods.dnn_superres_DnnSuperResImpl_new1(out ptr));
    }

    /// <inheritdoc />
    /// <summary>
    /// Constructor which immediately sets the desired model
    /// </summary>
    /// <param name="algo">String containing one of the desired models:
    /// - edsr
    /// - espcn
    /// - fsrcnn
    /// - lapsrn</param>
    /// <param name="scale">Integer specifying the upscale factor</param>
    public DnnSuperResImpl(string algo, int scale)
    {
        NativeMethods.HandleException(
            NativeMethods.dnn_superres_DnnSuperResImpl_new2(algo, scale, out ptr));
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    protected DnnSuperResImpl(IntPtr ptr)
    {
        this.ptr = ptr;
    }
        
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.HandleException(
            NativeMethods.dnn_superres_DnnSuperResImpl_delete(ptr));
        base.DisposeUnmanaged();
    }
        
    /// <summary>
    /// Read the model from the given path
    /// </summary>
    /// <param name="path">Path to the model file.</param>
    /// <returns></returns>
    public void ReadModel(string path)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_superres_DnnSuperResImpl_readModel1(ptr, path));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Read the model from the given path
    /// </summary>
    /// <param name="weights">Path to the model weights file.</param>
    /// <param name="definition">Path to the model definition file.</param>
    /// <returns></returns>
    public void ReadModel(string weights, string definition)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_superres_DnnSuperResImpl_readModel2(ptr, weights, definition));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Set desired model
    /// </summary>
    /// <param name="algo">String containing one of the desired models:
    /// - edsr
    /// - espcn
    /// - fsrcnn
    /// - lapsrn</param>
    /// <param name="scale">Integer specifying the upscale factor</param>
    /// <returns></returns>
    public void SetModel(string algo, int scale)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_superres_DnnSuperResImpl_setModel(ptr, algo, scale));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Ask network to use specific computation backend where it supported.
    /// </summary>
    /// <param name="backendId">backend identifier.</param>
    public void SetPreferableBackend(Backend backendId)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_superres_DnnSuperResImpl_setPreferableBackend(ptr, (int)backendId));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Ask network to make computations on specific target device.
    /// </summary>
    /// <param name="targetId">target identifier.</param>
    public void SetPreferableTarget(Target targetId)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_superres_DnnSuperResImpl_setPreferableTarget(ptr, (int)targetId));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Upsample via neural network
    /// </summary>
    /// <param name="img">Image to upscale</param>
    /// <param name="result">Destination upscaled image</param>
    public void Upsample(InputArray img, OutputArray result)
    {
        ThrowIfDisposed();
        if (img is null)
            throw new ArgumentNullException(nameof(img));
        if (result is null) 
            throw new ArgumentNullException(nameof(result));
        img.ThrowIfDisposed();
        result.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.dnn_superres_DnnSuperResImpl_upsample(ptr, img.CvPtr, result.CvPtr));

        GC.KeepAlive(this);
        GC.KeepAlive(img);
        result.Fix();
    }
        
    /// <summary>
    /// Upsample via neural network of multiple outputs
    /// </summary>
    /// <param name="img">Image to upscale</param>
    /// <param name="imgsNew">Destination upscaled images</param>
    /// <param name="scaleFactors">Scaling factors of the output nodes</param>
    /// <param name="nodeNames">Names of the output nodes in the neural network</param>
    [SuppressMessage("Maintainability", "CA1508: Avoid dead conditional code")]
    public void UpsampleMultioutput(
        InputArray img, out Mat[] imgsNew, IEnumerable<int> scaleFactors, IEnumerable<string> nodeNames)
    {
        ThrowIfDisposed();
        if (img is null) 
            throw new ArgumentNullException(nameof(img));
        if (scaleFactors is null) 
            throw new ArgumentNullException(nameof(scaleFactors));
        if (nodeNames is null)
            throw new ArgumentNullException(nameof(nodeNames));

        using var imgsNewVec = new VectorOfMat();
        var scaleFactorsArray = scaleFactors as int[] ?? scaleFactors.ToArray();
        var nodeNamesArray = nodeNames as string[] ?? nodeNames.ToArray();
        NativeMethods.HandleException(
            NativeMethods.dnn_superres_DnnSuperResImpl_upsampleMultioutput(
                ptr, img.CvPtr, imgsNewVec.CvPtr,
                scaleFactorsArray, scaleFactorsArray.Length, 
                nodeNamesArray, nodeNamesArray.Length));

        GC.KeepAlive(this);
        imgsNew = imgsNewVec.ToArray();
    }
        
    /// <summary>
    /// Returns the scale factor of the model
    /// </summary>
    /// <returns>Current scale factor.</returns>
    public int GetScale()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.dnn_superres_DnnSuperResImpl_getScale(
                ptr, out int ret));
        GC.KeepAlive(this);
        return ret;
    }
        
    /// <summary>
    /// Returns the scale factor of the model
    /// </summary>
    /// <returns>Current algorithm.</returns>
    public string GetAlgorithm()
    {
        ThrowIfDisposed();

        using var result = new StdString();
        NativeMethods.HandleException(
            NativeMethods.dnn_superres_DnnSuperResImpl_getAlgorithm(
                ptr, result.CvPtr));
        GC.KeepAlive(this);
        return result.ToString();
    }
}
