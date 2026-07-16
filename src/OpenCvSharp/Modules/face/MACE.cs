using OpenCvSharp.Internal;

namespace OpenCvSharp.Face;

/// <summary>
/// Minimum Average Correlation Energy filter for face verification.
/// </summary>
// ReSharper disable once InconsistentNaming
public sealed class MACE : Algorithm
{
    private MACE(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.face_Ptr_MACE_delete(p)))
    {
    }

    /// <summary>
    /// Creates a MACE filter.
    /// </summary>
    public static MACE Create(int imageSize = 64)
    {
        NativeMethods.HandleException(NativeMethods.face_MACE_create(imageSize, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.face_Ptr_MACE_get(smartPtr, out var rawPtr));
        return new MACE(smartPtr, rawPtr);
    }

    /// <summary>
    /// Loads a serialized MACE filter.
    /// </summary>
    public static MACE Load(string filename, string objName = "")
    {
        ArgumentNullException.ThrowIfNull(filename);
        ArgumentNullException.ThrowIfNull(objName);
        NativeMethods.HandleException(NativeMethods.face_MACE_load(filename, objName, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.face_Ptr_MACE_get(smartPtr, out var rawPtr));
        return new MACE(smartPtr, rawPtr);
    }

    /// <summary>
    /// Salts the filter with a passphrase.
    /// </summary>
    public void Salt(string passphrase)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(passphrase);
        NativeMethods.HandleException(NativeMethods.face_MACE_salt(Handle, passphrase));
    }

    /// <summary>
    /// Trains the filter on positive images.
    /// </summary>
    public void Train(IEnumerable<Mat> images)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(images);
        var imageArray = images.ToArray();
        foreach (var image in imageArray)
        {
            if (image is null)
                throw new ArgumentException("The collection contains null.", nameof(images));
            image.ThrowIfDisposed();
        }
        NativeMethods.HandleException(
            NativeMethods.face_MACE_train(
                Handle, imageArray.Select(x => x.CvPtr).ToArray(), imageArray.Length));
        GC.KeepAlive(imageArray);
    }

    /// <summary>
    /// Tests whether the query belongs to the trained class.
    /// </summary>
    public bool Same(InputArray query)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.face_MACE_same(Handle, query.Proxy, out var result));
        GC.KeepAlive(query.Source);
        return result != 0;
    }
}
