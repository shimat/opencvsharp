using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Dnn;

/// <summary>
/// This interface class allows to build new Layers - are building blocks of networks.
/// </summary>
/// <remarks>
/// Each class, derived from Layer, must implement forward() method to compute outputs.
/// Also before using the new layer into networks you must register your layer by using one of
/// LayerFactory macros.
/// </remarks>
public class Layer : Algorithm
{
    /// <summary>
    /// Creates instance by raw pointer cv::dnn::Layer*
    /// </summary>
    internal Layer(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.dnn_Ptr_Layer_delete(p)))
    {
    }

    /// <summary>
    /// List of learned parameters must be stored here to allow read them by using Net::getParam().
    /// </summary>
    public Mat[] Blobs
    {
        get
        {
            ThrowIfDisposed();
            using var blobsVec = new VectorOfMat();
            NativeMethods.HandleException(
                NativeMethods.dnn_Layer_getBlobs(Handle, blobsVec.CvPtr));
            return blobsVec.ToArray();
        }
        set
        {
            ThrowIfDisposed();
            ArgumentNullException.ThrowIfNull(value);

            using var blobsVec = new VectorOfMat(value);
            NativeMethods.HandleException(
                NativeMethods.dnn_Layer_setBlobs(Handle, blobsVec.CvPtr));
            GC.KeepAlive(value);
        }
    }

    /// <summary>
    /// Name of the layer instance, can be used for logging or other internal purposes.
    /// </summary>
    public string Name
    {
        get
        {
            ThrowIfDisposed();
            using var str = new StdString();
            NativeMethods.HandleException(
                NativeMethods.dnn_Layer_getName(Handle, str.CvPtr));
            return str.ToString();
        }
    }

    /// <summary>
    /// Type name which was used for creating layer by layer factory.
    /// </summary>
    public string Type
    {
        get
        {
            ThrowIfDisposed();
            using var str = new StdString();
            NativeMethods.HandleException(
                NativeMethods.dnn_Layer_getType(Handle, str.CvPtr));
            return str.ToString();
        }
    }

    /// <summary>
    /// Preferred target for layer forwarding.
    /// </summary>
    public Target PreferableTarget
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.dnn_Layer_getPreferableTarget(Handle, out var ret));
            return (Target)ret;
        }
    }

    /// <summary>
    /// Returns index of output blob in output array.
    /// </summary>
    /// <param name="outputName">label of output blob</param>
    /// <returns></returns>
    public int OutputNameToIndex(string outputName)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(outputName);

        NativeMethods.HandleException(
            NativeMethods.dnn_Layer_outputNameToIndex(Handle, outputName, out var ret));
        return ret;
    }
}
