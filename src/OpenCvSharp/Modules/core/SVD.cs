using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Singular Value Decomposition class
/// </summary>
// ReSharper disable once InconsistentNaming
public class SVD : CvObject
{
    /// <summary>
    /// the default constructor
    /// </summary>
    public SVD()
    {
        NativeMethods.HandleException(
            NativeMethods.core_SVD_new1(out var p));
        InitSafeHandle(p);
    }
    /// <summary>
    /// the constructor that performs SVD
    /// </summary>
    /// <param name="src"></param>
    /// <param name="flags"></param>
    public SVD(InputArray src, Flags flags = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.core_SVD_new2(src.Proxy, (int)flags, out var p));
        GC.KeepAlive(src.Source);
        InitSafeHandle(p);
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.core_SVD_delete(h))));
    }
        
    /// <summary>
    /// eigenvalues of the covariation matrix
    /// </summary>
    public Mat U()
    {

        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_SVD_u(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// eigenvalues of the covariation matrix
    /// </summary>
    public Mat W()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_SVD_w(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// mean value subtracted before the projection and added after the back projection
    /// </summary>
    public Mat Vt()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.core_SVD_vt(Handle, out var ret));
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
        NativeMethods.HandleException(
            NativeMethods.core_SVD_operatorThis(Handle, src.Proxy, (int)flags));
        GC.KeepAlive(src.Source);
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
        NativeMethods.HandleException(
            NativeMethods.core_SVD_backSubst(Handle, rhs.Proxy, dst.Proxy));
        GC.KeepAlive(rhs.Source);
        GC.KeepAlive(dst.Source);
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
        NativeMethods.HandleException(
            NativeMethods.core_SVD_static_compute1(src.Proxy, w.Proxy, u.Proxy, vt.Proxy, (int)flags));
        GC.KeepAlive(src.Source);
        GC.KeepAlive(w.Source);
        GC.KeepAlive(u.Source);
        GC.KeepAlive(vt.Source);
    }

    /// <summary>
    /// computes singular values of a matrix
    /// </summary>
    /// <param name="src"></param>
    /// <param name="w"></param>
    /// <param name="flags"></param>
    public static void Compute(InputArray src, OutputArray w, Flags flags = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.core_SVD_static_compute2(src.Proxy, w.Proxy, (int)flags));
        GC.KeepAlive(src.Source);
        GC.KeepAlive(w.Source);
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
        NativeMethods.HandleException(
            NativeMethods.core_SVD_static_backSubst(w.Proxy, u.Proxy, vt.Proxy, rhs.Proxy, dst.Proxy));
        GC.KeepAlive(w.Source);
        GC.KeepAlive(u.Source);
        GC.KeepAlive(vt.Source);
        GC.KeepAlive(rhs.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// finds dst = arg min_{|dst|=1} |m*dst|
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    public static void SolveZ(InputArray src, OutputArray dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_SVD_static_solveZ(src.Proxy, dst.Proxy));
        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
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
