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
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual int GetNumComponents()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_getNumComponents(RawPtr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="val"></param>
    public virtual void SetNumComponents(int val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_setNumComponents(RawPtr, val));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public new virtual double GetThreshold()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_getThreshold(RawPtr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="val"></param>
    public new virtual void SetThreshold(double val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_setThreshold(RawPtr, val));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual Mat[] GetProjections()
    {
        ThrowIfDisposed();
        using var resultVector = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_getProjections(RawPtr, resultVector.CvPtr));
        GC.KeepAlive(this);
        return resultVector.ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual Mat GetLabels()
    {
        ThrowIfDisposed();
        var result = new Mat();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_getLabels(RawPtr, result.CvPtr));
        GC.KeepAlive(this);
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual Mat GetEigenValues()
    {
        ThrowIfDisposed();
        var result = new Mat();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_getEigenValues(RawPtr, result.CvPtr));
        GC.KeepAlive(this);
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual Mat GetEigenVectors()
    {
        ThrowIfDisposed();
        var result = new Mat();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_getEigenVectors(RawPtr, result.CvPtr));
        GC.KeepAlive(this);
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual Mat GetMean()
    {
        ThrowIfDisposed();
        var result = new Mat();
        NativeMethods.HandleException(
            NativeMethods.face_BasicFaceRecognizer_getMean(RawPtr, result.CvPtr));
        GC.KeepAlive(this);
        return result;
    }
}
