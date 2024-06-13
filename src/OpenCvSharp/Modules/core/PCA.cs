using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Principal Component Analysis
/// </summary>
public class PCA : DisposableCvObject
{

    /// <summary>
    /// default constructor.
    ///
    /// The default constructor initializes an empty PCA structure.
    /// The other constructors initialize the structure and call PCA::operator()().
    /// </summary>
    public PCA()
    {
        NativeMethods.HandleException(
            NativeMethods.core_PCA_new1(out ptr));
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data">input samples stored as matrix rows or matrix columns.</param>
    /// <param name="mean">optional mean value; if the matrix is empty (@c noArray()), the mean is computed from the data.</param>
    /// <param name="flags">operation flags; currently the parameter is only used to specify the data layout (PCA::Flags)</param>
    /// <param name="maxComponents">maximum number of components that PCA should retain; by default, all the components are retained.</param>
    public PCA(InputArray data, InputArray mean, Flags flags, int maxComponents = 0)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        if (mean is null)
            throw new ArgumentNullException(nameof(mean));
        data.ThrowIfDisposed();
        mean.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_PCA_new2(data.CvPtr, mean.CvPtr, (int)flags, maxComponents, out ptr));
        GC.KeepAlive(data);
        GC.KeepAlive(mean);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data">input samples stored as matrix rows or matrix columns.</param>
    /// <param name="mean">optional mean value; if the matrix is empty (noArray()), the mean is computed from the data.</param>
    /// <param name="flags">operation flags; currently the parameter is only used to specify the data layout (PCA::Flags)</param>
    /// <param name="retainedVariance">Percentage of variance that PCA should retain.
    /// Using this parameter will let the PCA decided how many components to retain but it will always keep at least 2.</param>
    public PCA(InputArray data, InputArray mean, Flags flags, double retainedVariance)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        if (mean is null)
            throw new ArgumentNullException(nameof(mean));
        data.ThrowIfDisposed();
        mean.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_PCA_new3(data.CvPtr, mean.CvPtr, (int)flags, retainedVariance, out ptr));
        GC.KeepAlive(data);
        GC.KeepAlive(mean);
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.HandleException(
            NativeMethods.core_PCA_delete(ptr));
        base.DisposeUnmanaged();
    }
        
    /// <summary>
    /// eigenvalues of the covariation matrix
    /// </summary>
    public Mat Eigenvectors
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_PCA_eigenvectors(ptr, out var ret));
            GC.KeepAlive(this);
            return Mat.FromNativePointer(ret);
        }
    }

    /// <summary>
    /// eigenvalues of the covariation matrix
    /// </summary>
    public Mat Eigenvalues
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_PCA_eigenvalues(ptr, out var ret));
            GC.KeepAlive(this);
            return Mat.FromNativePointer(ret);
        }
    }

    /// <summary>
    /// mean value subtracted before the projection and added after the back projection
    /// </summary>
    public Mat Mean
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_PCA_mean(ptr, out var ret));
            GC.KeepAlive(this);
            return Mat.FromNativePointer(ret);
        }
    }

    /// <summary>
    /// Performs PCA.
    ///
    /// The operator performs %PCA of the supplied dataset. It is safe to reuse
    /// the same PCA structure for multiple datasets. That is, if the structure
    /// has been previously used with another dataset, the existing internal
    /// data is reclaimed and the new @ref eigenvalues, @ref eigenvectors and @ref
    /// mean are allocated and computed.
    ///
    /// The computed @ref eigenvalues are sorted from the largest to the smallest and
    /// the corresponding @ref eigenvectors are stored as eigenvectors rows.
    /// </summary>
    /// <param name="data">input samples stored as the matrix rows or as the matrix columns.</param>
    /// <param name="mean">optional mean value; if the matrix is empty (noArray()), the mean is computed from the data.</param>
    /// <param name="flags">operation flags; currently the parameter is only used to specify the data layout. (Flags)</param>
    /// <param name="maxComponents">maximum number of components that PCA should retain;
    /// by default, all the components are retained.</param>
    /// <returns></returns>
    public PCA Compute(InputArray data, InputArray mean, Flags flags, int maxComponents = 0)
    {
        ThrowIfDisposed();
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        if (mean is null)
            throw new ArgumentNullException(nameof(mean));
        data.ThrowIfDisposed();
        mean.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_PCA_operatorThis(ptr, data.CvPtr, mean.CvPtr, (int)flags, maxComponents));
        GC.KeepAlive(data);
        GC.KeepAlive(mean);
        return this;
    }

    /// <summary>
    /// Performs PCA.
    ///
    /// The operator performs %PCA of the supplied dataset. It is safe to reuse
    /// the same PCA structure for multiple datasets. That is, if the structure
    /// has been previously used with another dataset, the existing internal
    /// data is reclaimed and the new @ref eigenvalues, @ref eigenvectors and @ref
    /// mean are allocated and computed.
    ///
    /// The computed @ref eigenvalues are sorted from the largest to the smallest and
    /// the corresponding @ref eigenvectors are stored as eigenvectors rows.
    /// </summary>
    /// <param name="data">input samples stored as the matrix rows or as the matrix columns.</param>
    /// <param name="mean">optional mean value; if the matrix is empty (noArray()),
    /// the mean is computed from the data.</param>
    /// <param name="flags">operation flags; currently the parameter is only used to
    /// specify the data layout. (PCA::Flags)</param>
    /// <param name="retainedVariance">Percentage of variance that %PCA should retain.
    /// Using this parameter will let the %PCA decided how many components to
    /// retain but it will always keep at least 2.</param>
    /// <returns></returns>
    public PCA ComputeVar(InputArray data, InputArray mean, Flags flags, double retainedVariance)
    {
        ThrowIfDisposed();
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        if (mean is null)
            throw new ArgumentNullException(nameof(mean));
        data.ThrowIfDisposed();
        mean.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_PCA_computeVar(ptr, data.CvPtr, mean.CvPtr, (int)flags, retainedVariance));
        GC.KeepAlive(data);
        GC.KeepAlive(mean);
        return this;
    }

    /// <summary>
    /// Projects vector(s) to the principal component subspace.
    ///
    /// The methods project one or more vectors to the principal component
    /// subspace, where each vector projection is represented by coefficients in
    /// the principal component basis. The first form of the method returns the
    /// matrix that the second form writes to the result. So the first form can
    /// be used as a part of expression while the second form can be more
    /// efficient in a processing loop.
    /// </summary>
    /// <param name="vec">input vector(s); must have the same dimensionality and the
    /// same layout as the input data used at %PCA phase, that is, if
    /// DATA_AS_ROW are specified, then `vec.cols==data.cols`
    /// (vector dimensionality) and `vec.rows` is the number of vectors to
    /// project, and the same is true for the PCA::DATA_AS_COL case.</param>
    /// <returns></returns>
    public Mat Project(InputArray vec)
    {
        ThrowIfDisposed();
        if (vec is null)
            throw new ArgumentNullException(nameof(vec));
        vec.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_PCA_project1(ptr, vec.CvPtr, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(vec);
        return Mat.FromNativePointer(ret);
    }

    /// <summary>
    /// Projects vector(s) to the principal component subspace.
    /// </summary>
    /// <param name="vec">input vector(s); must have the same dimensionality and the
    /// same layout as the input data used at PCA phase, that is, if DATA_AS_ROW are
    /// specified, then `vec.cols==data.cols` (vector dimensionality) and `vec.rows`
    /// is the number of vectors to project, and the same is true for the PCA::DATA_AS_COL case.</param>
    /// <param name="result">output vectors; in case of PCA::DATA_AS_COL, the
    /// output matrix has as many columns as the number of input vectors, this
    /// means that `result.cols==vec.cols` and the number of rows match the
    /// number of principal components (for example, `maxComponents` parameter
    /// passed to the constructor).</param>
    public void Project(InputArray vec, OutputArray result)
    {
        ThrowIfDisposed();
        if (vec is null)
            throw new ArgumentNullException(nameof(vec));
        if (result is null)
            throw new ArgumentNullException(nameof(result));
        vec.ThrowIfDisposed();
        result.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.core_PCA_project2(ptr, vec.CvPtr, result.CvPtr));
        result.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(vec);
        GC.KeepAlive(result);
    }

    /// <summary>
    /// Reconstructs vectors from their PC projections.
    ///
    /// The methods are inverse operations to PCA::project. They take PC
    /// coordinates of projected vectors and reconstruct the original vectors.
    /// Unless all the principal components have been retained, the
    /// reconstructed vectors are different from the originals. But typically,
    /// the difference is small if the number of components is large enough (but
    /// still much smaller than the original vector dimensionality). As a result, PCA is used.
    /// </summary>
    /// <param name="vec">coordinates of the vectors in the principal component subspace,
    /// the layout and size are the same as of PCA::project output vectors.</param>
    /// <returns></returns>
    public Mat BackProject(InputArray vec)
    {
        ThrowIfDisposed();
        if (vec is null)
            throw new ArgumentNullException(nameof(vec));
        vec.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_PCA_backProject1(ptr, vec.CvPtr, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(vec);
        return new Mat(ret);
    }

    /// <summary>
    /// Reconstructs vectors from their PC projections.
    ///
    /// The methods are inverse operations to PCA::project. They take PC
    /// coordinates of projected vectors and reconstruct the original vectors.
    /// Unless all the principal components have been retained, the
    /// reconstructed vectors are different from the originals. But typically,
    /// the difference is small if the number of components is large enough (but
    /// still much smaller than the original vector dimensionality). As a result, PCA is used.
    /// </summary>
    /// <param name="vec">coordinates of the vectors in the principal component subspace,
    /// the layout and size are the same as of PCA::project output vectors.</param>
    /// <param name="result">reconstructed vectors; the layout and size are the same as 
    /// of PCA::project input vectors.</param>
    public void BackProject(InputArray vec, OutputArray result)
    {
        ThrowIfDisposed();
        if (vec is null)
            throw new ArgumentNullException(nameof(vec));
        if (result is null)
            throw new ArgumentNullException(nameof(result));
        vec.ThrowIfDisposed();
        result.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.core_PCA_backProject2(ptr, vec.CvPtr, result.CvPtr));
        result.Fix();
        GC.KeepAlive(this);
        GC.KeepAlive(vec);
        GC.KeepAlive(result);
    }

    /// <summary>
    /// Write PCA objects.
    /// Writes @ref eigenvalues @ref eigenvectors and @ref mean to specified FileStorage
    /// </summary>
    /// <param name="fs"></param>
    public void Write(FileStorage fs)
    {
        if (fs is null) 
            throw new ArgumentNullException(nameof(fs));
        fs.ThrowIfDisposed();
            
        NativeMethods.HandleException(
            NativeMethods.core_PCA_write(ptr, fs.CvPtr));

        GC.KeepAlive(this);
        GC.KeepAlive(fs);
    }

    /// <summary>
    /// Load PCA objects.
    /// Loads @ref eigenvalues @ref eigenvectors and @ref mean from specified FileNode
    /// </summary>
    /// <param name="fn"></param>
    public void Read(FileNode fn)
    {
        if (fn is null) 
            throw new ArgumentNullException(nameof(fn));
        fn.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.core_PCA_read(ptr, fn.CvPtr));

        GC.KeepAlive(this);
        GC.KeepAlive(fn);
    }

#pragma warning disable CA1008 // Enums should have zero value
    /// <summary>
    /// Flags for PCA operations
    /// </summary>
    [Flags]
    public enum Flags
    {
        /// <summary>
        /// The vectors are stored as rows (i.e. all the components of a certain vector are stored continously)
        /// </summary>
        DataAsRow = 0,

        /// <summary>
        /// The vectors are stored as columns (i.e. values of a certain vector component are stored continuously)
        /// </summary>
        DataAsCol = 1,

        /// <summary>
        /// Use pre-computed average vector
        /// </summary>
        UseAvg = 2,
    }
}
