using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Face;

/// <summary>
/// base for two FaceRecognizer classes
/// </summary>
public abstract class BasicFaceRecognizer : FaceRecognizer
{
    /// <summary>
    /// 
    /// </summary>
    protected BasicFaceRecognizer(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release) { }

    /// <summary>
    /// Gets the number of components (Eigenfaces or Fisherfaces) kept by the underlying PCA/LDA computation.
    /// </summary>
    /// <returns></returns>
    public virtual int GetNumComponents()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_getNumComponents(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Sets the number of components (Eigenfaces or Fisherfaces) kept by the underlying PCA/LDA computation.
    /// </summary>
    /// <param name="val"></param>
    public virtual void SetNumComponents(int val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_setNumComponents(Handle, val));
    }

    /// <summary>
    /// Gets the threshold applied in the prediction. If the distance to the nearest neighbor is
    /// larger than the threshold, the prediction returns -1.
    /// </summary>
    /// <returns></returns>
    public new virtual double GetThreshold()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_getThreshold(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Sets the threshold applied in the prediction. If the distance to the nearest neighbor is
    /// larger than the threshold, the prediction returns -1.
    /// </summary>
    /// <param name="val"></param>
    public new virtual void SetThreshold(double val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_setThreshold(Handle, val));
    }

    /// <summary>
    /// Gets the projections of the training data.
    /// </summary>
    /// <returns></returns>
    public virtual Mat[] GetProjections()
    {
        ThrowIfDisposed();
        using var resultVector = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_getProjections(Handle, resultVector.CvPtr));
        return resultVector.ToArray();
    }

    /// <summary>
    /// Gets the labels corresponding to the training data projections.
    /// </summary>
    /// <returns></returns>
    public virtual Mat GetLabels()
    {
        ThrowIfDisposed();
        var result = new Mat();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_getLabels(Handle, result.CvPtr));
        return result;
    }

    /// <summary>
    /// Gets the eigenvalues computed during training, ordered descending.
    /// </summary>
    /// <returns></returns>
    public virtual Mat GetEigenValues()
    {
        ThrowIfDisposed();
        var result = new Mat();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_getEigenValues(Handle, result.CvPtr));
        return result;
    }

    /// <summary>
    /// Gets the eigenvectors computed during training, ordered by their eigenvalue.
    /// </summary>
    /// <returns></returns>
    public virtual Mat GetEigenVectors()
    {
        ThrowIfDisposed();
        var result = new Mat();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_getEigenVectors(Handle, result.CvPtr));
        return result;
    }

    /// <summary>
    /// Gets the sample mean calculated from the training data.
    /// </summary>
    /// <returns></returns>
    public virtual Mat GetMean()
    {
        ThrowIfDisposed();
        var result = new Mat();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_getMean(Handle, result.CvPtr));
        return result;
    }
}
