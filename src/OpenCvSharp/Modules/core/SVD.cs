using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Singular Value Decomposition class
/// </summary>
// ReSharper disable once InconsistentNaming
public class SVD : DisposableCvObject
{
    /// <summary>
    /// the default constructor
    /// </summary>
    public SVD()
    {
        NativeMethods.HandleException(
            NativeMethods.core_SVD_new1(out ptr));
    }
    /// <summary>
    /// the constructor that performs SVD
    /// </summary>
    /// <param name="src"></param>
    /// <param name="flags"></param>
    public SVD(InputArray src, Flags flags = 0)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        src.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_SVD_new2(src.CvPtr, (int)flags, out ptr));
        GC.KeepAlive(src);
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.HandleException(
            NativeMethods.core_SVD_delete(ptr));
        base.DisposeUnmanaged();
    }
        
    /// <summary>
    /// eigenvalues of the covariation matrix
    /// </summary>
    public Mat U()
    {

        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_SVD_u(ptr, out var ret));
        GC.KeepAlive(this);
        return new Mat(ret);
    }

    /// <summary>
    /// eigenvalues of the covariation matrix
    /// </summary>
    public Mat W()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_SVD_w(ptr, out var ret));
        GC.KeepAlive(this);
        return new Mat(ret);
    }

    /// <summary>
    /// mean value subtracted before the projection and added after the back projection
    /// </summary>
    public Mat Vt()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_SVD_vt(ptr, out var ret));
        GC.KeepAlive(this);
        return new Mat(ret);
    }

    /// <summary>
    /// the operator that performs SVD. The previously allocated SVD::u, SVD::w are SVD::vt are released.
    /// </summary>
    /// <param name="src"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    public SVD Run(InputArray src, Flags flags = 0)
    {
        ThrowIfDisposed();
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        src.ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_SVD_operatorThis(ptr, src.CvPtr, (int)flags));
        GC.KeepAlive(src);
        return this;
    }

    /// <summary>
    /// performs back substitution, so that dst is the solution or pseudo-solution of m*dst = rhs, where m is the decomposed matrix
    /// </summary>
    /// <param name="rhs"></param>
    /// <param name="dst"></param>
    /// <returns></returns>
    public void BackSubst(InputArray rhs, OutputArray dst)
    {
        ThrowIfDisposed();
        if (rhs is null)
            throw new ArgumentNullException(nameof(rhs));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        rhs.ThrowIfDisposed();
        dst.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.core_SVD_backSubst(ptr, rhs.CvPtr, dst.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(rhs);
        GC.KeepAlive(dst);
    }

    /// <summary>
    /// decomposes matrix and stores the results to user-provided matrices
    /// </summary>
    /// <param name="src"></param>
    /// <param name="w"></param>
    /// <param name="u"></param>
    /// <param name="vt"></param>
    /// <param name="flags"></param>
    public static void Compute(InputArray src, OutputArray w,
        OutputArray u, OutputArray vt, Flags flags = 0)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (w is null)
            throw new ArgumentNullException(nameof(w));
        if (u is null)
            throw new ArgumentNullException(nameof(u));
        if (vt is null)
            throw new ArgumentNullException(nameof(vt));
        src.ThrowIfDisposed();
        w.ThrowIfNotReady();
        u.ThrowIfNotReady();
        vt.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.core_SVD_static_compute1(src.CvPtr, w.CvPtr, u.CvPtr, vt.CvPtr, (int)flags));
        w.Fix();
        u.Fix();
        vt.Fix();
        GC.KeepAlive(src);
        GC.KeepAlive(w);
        GC.KeepAlive(u);
        GC.KeepAlive(vt);
    }

    /// <summary>
    /// computes singular values of a matrix
    /// </summary>
    /// <param name="src"></param>
    /// <param name="w"></param>
    /// <param name="flags"></param>
    public static void Compute(InputArray src, OutputArray w, Flags flags = 0)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (w is null)
            throw new ArgumentNullException(nameof(w));
        src.ThrowIfDisposed();
        w.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.core_SVD_static_compute2(src.CvPtr, w.CvPtr, (int)flags));
        w.Fix();
        GC.KeepAlive(src);
        GC.KeepAlive(w);
    }

    /// <summary>
    /// performs back substitution
    /// </summary>
    /// <param name="w"></param>
    /// <param name="u"></param>
    /// <param name="vt"></param>
    /// <param name="rhs"></param>
    /// <param name="dst"></param>
    public static void BackSubst(InputArray w, InputArray u,
        InputArray vt, InputArray rhs, OutputArray dst)
    {
        if (w is null)
            throw new ArgumentNullException(nameof(w));
        if (u is null)
            throw new ArgumentNullException(nameof(u));
        if (vt is null)
            throw new ArgumentNullException(nameof(vt));
        if (rhs is null)
            throw new ArgumentNullException(nameof(rhs));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        w.ThrowIfDisposed();
        u.ThrowIfDisposed();
        vt.ThrowIfDisposed();
        rhs.ThrowIfDisposed();
        dst.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.core_SVD_static_backSubst(w.CvPtr, u.CvPtr, vt.CvPtr, rhs.CvPtr, dst.CvPtr));
        dst.Fix();
        GC.KeepAlive(w);
        GC.KeepAlive(u);
        GC.KeepAlive(vt);
        GC.KeepAlive(rhs);
        GC.KeepAlive(dst);
    }

    /// <summary>
    /// finds dst = arg min_{|dst|=1} |m*dst|
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    public static void SolveZ(InputArray src, OutputArray dst)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        src.ThrowIfDisposed();
        dst.ThrowIfNotReady();
        NativeMethods.HandleException(
            NativeMethods.core_SVD_static_solveZ(src.CvPtr, dst.CvPtr));
        dst.Fix();
        GC.KeepAlive(src);
        GC.KeepAlive(dst);
    }

    /// <summary>
    /// Operation flags for SVD
    /// </summary>
    [Flags]
    public enum Flags
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

        /// <summary>
        /// enables modification of matrix src1 during the operation. It speeds up the processing. 
        /// </summary>
        ModifyA = 1,

        /// <summary>
        /// indicates that only a vector of singular values `w` is to be processed, 
        /// while u and vt will be set to empty matrices
        /// </summary>
        // ReSharper disable once InconsistentNaming
        NoUV = 2,

        /// <summary>
        /// when the matrix is not square, by default the algorithm produces u and 
        /// vt matrices of sufficiently large size for the further A reconstruction; 
        /// if, however, FULL_UV flag is specified, u and vt will be full-size square 
        /// orthogonal matrices.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        FullUV = 4,
    }
}
