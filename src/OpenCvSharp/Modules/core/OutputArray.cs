using System.Diagnostics.CodeAnalysis;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

#pragma warning disable CA1002 // Do not expose generic lists

namespace OpenCvSharp;

/// <summary>
/// Proxy datatype for passing Mat's and List&lt;&gt;'s as output parameters
/// </summary>
public class OutputArray : DisposableCvObject
{
    private readonly object obj;

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
            NativeMethods.core_OutputArray_new_byMat(mat.CvPtr, out ptr));
        GC.KeepAlive(mat);
        obj = mat;
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
            NativeMethods.core_OutputArray_new_byUMat(mat.CvPtr, out ptr));
        GC.KeepAlive(mat);
        obj = mat;
    }

#if ENABLED_CUDA
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        internal OutputArray(GpuMat mat)
        {
            if (mat is null)
                throw new ArgumentNullException(nameof(mat));
            ptr = NativeMethods.core_OutputArray_new_byGpuMat(mat.CvPtr);
            GC.KeepAlive(mat);
            obj = mat;
        }
#endif

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mat"></param>
    internal OutputArray(IEnumerable<Mat> mat)
    {
        if (mat is null)
            throw new ArgumentNullException(nameof(mat));
        using (var matVector = new VectorOfMat(mat))
        {
            NativeMethods.HandleException(
                NativeMethods.core_OutputArray_new_byVectorOfMat(matVector.CvPtr, out ptr));
        }
        obj = mat;
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.HandleException(
            NativeMethods.core_OutputArray_delete(ptr));
        base.DisposeUnmanaged();
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

#if ENABLED_CUDA
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static implicit operator OutputArray(GpuMat mat)
        {
            return new OutputArray(mat);
        }
#endif

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

#if ENABLED_CUDA
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsGpuMat()
        {
            return obj is GpuMat;
        }
#endif

#if ENABLED_CUDA
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Mat GetGpuMat()
        {
            return obj as GpuMat;
        }
#endif

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsVectorOfMat()
    {
        return obj is IEnumerable<Mat>;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerable<Mat>? GetVectorOfMat()
    {
        return obj as IEnumerable<Mat>;
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
#if ENABLED_CUDA
                (IsMat() || IsGpuMat());
#else
            IsMat() || IsUMat();
#endif
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

#if ENABLED_CUDA
        /// <summary>
        /// Creates a proxy class of the specified matrix
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static OutputArray Create(GpuMat mat)
        {
            return new OutputArray(mat);
        }
#endif

    /// <summary>
    /// Creates a proxy class of the specified list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static OutputArrayOfStructList<T> Create<T>(List<T> list)
        where T : unmanaged
    {
        if (list is null)
            throw new ArgumentNullException(nameof(list));
        return new OutputArrayOfStructList<T>(list);
    }

    /// <summary>
    /// Creates a proxy class of the specified list
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static OutputArrayOfMatList Create(List<Mat> list)
    {
        if (list is null)
            throw new ArgumentNullException(nameof(list));
        return new OutputArrayOfMatList(list);
    }

    #endregion
}
