using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.XFeatures2D;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Class implementing Signature Quadratic Form Distance (SQFD).
/// </summary>
public class PCTSignaturesSQFD : Algorithm
{
    /// <summary>
    ///
    /// </summary>
    private PCTSignaturesSQFD(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_PCTSignaturesSQFD_delete(p)))
    { }

    /// <summary>
    /// Creates the algorithm instance using the selected distance function, similarity function,
    /// and similarity function parameter.
    /// </summary>
    /// <param name="distanceFunction">Distance function selector.</param>
    /// <param name="similarityFunction">Similarity function selector.</param>
    /// <param name="similarityParameter">Parameter of the similarity function.</param>
    public static PCTSignaturesSQFD Create(
        PCTSignaturesDistanceFunction distanceFunction = PCTSignaturesDistanceFunction.L2,
        PCTSignaturesSimilarityFunction similarityFunction = PCTSignaturesSimilarityFunction.Heuristic,
        float similarityParameter = 1.0f)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_PCTSignaturesSQFD_create(
                (int)distanceFunction, (int)similarityFunction, similarityParameter, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_PCTSignaturesSQFD_get(ptr, out var rawPtr));
        return new PCTSignaturesSQFD(ptr, rawPtr);
    }

    /// <summary>
    /// Computes the Signature Quadratic Form Distance of two signatures.
    /// </summary>
    /// <param name="signature0">The first signature.</param>
    /// <param name="signature1">The second signature.</param>
    /// <returns></returns>
    public float ComputeQuadraticFormDistance(InputArray signature0, InputArray signature1)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_PCTSignaturesSQFD_computeQuadraticFormDistance(
                Handle, signature0.Proxy, signature1.Proxy, out var ret));
        GC.KeepAlive(signature0.Source);
        GC.KeepAlive(signature1.Source);
        return ret;
    }

    /// <summary>
    /// Computes the Signature Quadratic Form Distance between the reference signature and each of
    /// the other image signatures.
    /// </summary>
    /// <remarks>
    /// OpenCV's native implementation has a known bug for <paramref name="imageSignatures"/> with
    /// more than one element: it validates each signature via <c>mImageSignatures[i].empty()</c>
    /// where <c>mImageSignatures</c> is a pointer to the whole vector rather than an element
    /// accessor, so any index beyond 0 reads out-of-bounds memory. Prefer calling
    /// <see cref="ComputeQuadraticFormDistance"/> in a loop for more than one signature.
    /// </remarks>
    /// <param name="sourceSignature">The signature to measure the distance of other signatures from.</param>
    /// <param name="imageSignatures">Vector of signatures to measure the distance from the source signature.</param>
    /// <returns>Measured distances.</returns>
    public float[] ComputeQuadraticFormDistances(Mat sourceSignature, IEnumerable<Mat> imageSignatures)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(sourceSignature);
        ArgumentNullException.ThrowIfNull(imageSignatures);

        var imageSignaturesArray = imageSignatures.ToArray();
        var imageSignaturesPtrs = imageSignaturesArray.Select(m => m.CvPtr).ToArray();
        using var distances = new StdVector<float>();
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_PCTSignaturesSQFD_computeQuadraticFormDistances(
                Handle, sourceSignature.CvPtr, imageSignaturesPtrs, imageSignaturesPtrs.Length, distances.CvPtr));
        GC.KeepAlive(sourceSignature);
        GC.KeepAlive(imageSignaturesArray);
        return distances.ToArray();
    }
}
