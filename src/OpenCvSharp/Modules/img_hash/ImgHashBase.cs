using OpenCvSharp.Internal;

namespace OpenCvSharp.ImgHash;

/// <inheritdoc />
/// <summary>
/// The base class for image hash algorithms
/// </summary>
public abstract class ImgHashBase : Algorithm
{
    /// <inheritdoc />
    protected ImgHashBase(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release) { }

    /// <summary>
    /// Computes hash of the input image
    /// </summary>
    /// <param name="inputArr">input image want to compute hash value</param>
    /// <param name="outputArr">hash of the image</param>
    /// <returns></returns>
    public virtual void Compute(InputArray inputArr, OutputArray outputArr)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.img_hash_ImgHashBase_compute(Handle, inputArr.Proxy, outputArr.Proxy));

        GC.KeepAlive(inputArr.Source);
    }

    /// <summary>
    /// Compare the hash value between inOne and inTwo
    /// </summary>
    /// <param name="hashOne">Hash value one</param>
    /// <param name="hashTwo">Hash value two</param>
    /// <returns>value indicate similarity between inOne and inTwo, the meaning of the value vary from algorithms to algorithms</returns>
    public virtual double Compare(InputArray hashOne, InputArray hashTwo)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.img_hash_ImgHashBase_compare(Handle, hashOne.Proxy, hashTwo.Proxy, out var ret));
        GC.KeepAlive(hashOne.Source);
        GC.KeepAlive(hashOne.Source);
        return ret;
    }
}
