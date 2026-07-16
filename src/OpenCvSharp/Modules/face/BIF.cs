using OpenCvSharp.Internal;

namespace OpenCvSharp.Face;

/// <summary>
/// Computes bio-inspired features used by age-estimation models.
/// </summary>
// ReSharper disable once InconsistentNaming
public sealed class BIF : Algorithm
{
    private BIF(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.face_Ptr_BIF_delete(p)))
    {
    }

    /// <summary>
    /// Creates a BIF descriptor.
    /// </summary>
    public static BIF Create(int numBands = 8, int numRotations = 12)
    {
        NativeMethods.HandleException(NativeMethods.face_BIF_create(numBands, numRotations, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.face_Ptr_BIF_get(smartPtr, out var rawPtr));
        return new BIF(smartPtr, rawPtr);
    }

    /// <summary>
    /// Gets the number of filter bands.
    /// </summary>
    public int NumBands
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.face_BIF_getNumBands(Handle, out var value));
            return value;
        }
    }

    /// <summary>
    /// Gets the number of image rotations.
    /// </summary>
    public int NumRotations
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.face_BIF_getNumRotations(Handle, out var value));
            return value;
        }
    }

    /// <summary>
    /// Computes a CV_32FC1 feature vector from a CV_32FC1 image.
    /// </summary>
    public void Compute(InputArray image, OutputArray features)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.face_BIF_compute(Handle, image.Proxy, features.Proxy));
        GC.KeepAlive(image.Source);
        GC.KeepAlive(features.Source);
    }
}
