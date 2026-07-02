using System.Diagnostics.CodeAnalysis;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Proxy datatype for passing Mat's as output parameters
/// </summary>
public class OutputArray : CvObject
{
    private readonly object obj;

    // Migration scaffold (issue #1976, strategy 3): wraps this class's native cv::_OutputArray* as an
    // ArrayProxy so externs can move to the ArrayProxy ABI one module at a time while OutputArray is
    // still a class. The caller must keep this object alive across the native call (GC.KeepAlive).
    internal OutputArrayProxy ToOutputProxy() => new() { Handle = CvPtr, Kind = (int)ArrayProxyKind.RawOutputArray };

    #region Init & Disposal

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mat"></param>
    internal OutputArray(Mat mat)
    {
        if (mat is null)
            throw new ArgumentNullException(nameof(mat));
        NativeMethods.HandleException(
            NativeMethods.core_OutputArray_new_byMat(mat.CvPtr, out var p));
        GC.KeepAlive(mat);
        obj = mat;
        InitSafeHandle(p);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mat"></param>
    internal OutputArray(UMat mat)
    {
        if (mat is null)
            throw new ArgumentNullException(nameof(mat));
        NativeMethods.HandleException(
            NativeMethods.core_OutputArray_new_byUMat(mat.CvPtr, out var p));
        GC.KeepAlive(mat);
        obj = mat;
        InitSafeHandle(p);
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.core_OutputArray_delete(h))));
    }

    #endregion

    #region Cast

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mat"></param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Design", "CA2225: Operator overloads have named alternates")]
    public static implicit operator OutputArray(Mat mat)
    {
        return new(mat);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="umat"></param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Design", "CA2225: Operator overloads have named alternates")]
    public static implicit operator OutputArray(UMat umat)
    {
        return new(umat);
    }

    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsMat()
    {
        return obj is Mat;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsUMat()
    {
        return obj is UMat;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual Mat? GetMat()
    {
        return obj as Mat;
    }

    /// <summary>
    ///
    /// </summary>
    public virtual void AssignResult()
    {
        if (!IsReady())
            throw new NotSupportedException();
    }

    /// <summary>
    /// 
    /// </summary>
    public void Fix()
    {
        AssignResult();
        Dispose();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsReady()
    {
        return
            ptr != IntPtr.Zero &&
            !IsDisposed &&
            IsMat() || IsUMat();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public void ThrowIfNotReady()
    {
        if (!IsReady())
            throw new OpenCvSharpException("Invalid OutputArray");
    }

    /// <summary>
    /// Creates a proxy class of the specified matrix
    /// </summary>
    /// <param name="mat"></param>
    /// <returns></returns>
    public static OutputArray Create(Mat mat)
    {
        return new (mat);
    }

    /// <summary>
    /// Creates a proxy class of the specified matrix
    /// </summary>
    /// <param name="mat"></param>
    /// <returns></returns>
    public static OutputArray Create(UMat mat)
    {
        return new (mat);
    }

    #endregion
}
