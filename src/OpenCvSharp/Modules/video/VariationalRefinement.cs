using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Variational optical flow refinement.
/// This class implements variational refinement of the input flow field, i.e. it uses input flow
/// to initialize the minimization of the sum of color constancy, gradient constancy and smoothness terms.
/// </summary>
public class VariationalRefinement : DenseOpticalFlow
{
    private VariationalRefinement(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.video_Ptr_VariationalRefinement_delete(p)))
    { }

    /// <summary>
    /// Creates an instance of VariationalRefinement
    /// </summary>
    /// <returns></returns>
    public static VariationalRefinement Create()
    {
        NativeMethods.HandleException(
            NativeMethods.video_VariationalRefinement_create(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.video_Ptr_VariationalRefinement_get(smartPtr, out var rawPtr));
        return new VariationalRefinement(smartPtr, rawPtr);
    }

    /// <summary>
    /// calc() function overload to handle separate horizontal (u) and vertical (v) flow components
    /// (to avoid extra splits/merges)
    /// </summary>
    /// <param name="i0"></param>
    /// <param name="i1"></param>
    /// <param name="flowU"></param>
    /// <param name="flowV"></param>
    public virtual void CalcUV(InputArray i0, InputArray i1, InputOutputArray flowU, InputOutputArray flowV)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.video_VariationalRefinement_calcUV(Handle, i0.Proxy, i1.Proxy, flowU.Proxy, flowV.Proxy));
        GC.KeepAlive(this);
        GC.KeepAlive(i0.Source);
        GC.KeepAlive(i1.Source);
        GC.KeepAlive(flowU.Source);
        GC.KeepAlive(flowV.Source);
    }

    /// <summary>
    /// Number of outer (fixed-point) iterations in the minimization procedure.
    /// </summary>
    public int FixedPointIterations
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_VariationalRefinement_getFixedPointIterations(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_VariationalRefinement_setFixedPointIterations(Handle, value));
        }
    }

    /// <summary>
    /// Number of inner successive over-relaxation (SOR) iterations in the minimization procedure to solve
    /// the respective linear system.
    /// </summary>
    public int SorIterations
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_VariationalRefinement_getSorIterations(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_VariationalRefinement_setSorIterations(Handle, value));
        }
    }

    /// <summary>
    /// Relaxation factor in SOR
    /// </summary>
    public float Omega
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_VariationalRefinement_getOmega(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_VariationalRefinement_setOmega(Handle, value));
        }
    }

    /// <summary>
    /// Weight of the smoothness term
    /// </summary>
    public float Alpha
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_VariationalRefinement_getAlpha(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_VariationalRefinement_setAlpha(Handle, value));
        }
    }

    /// <summary>
    /// Weight of the color constancy term
    /// </summary>
    public float Delta
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_VariationalRefinement_getDelta(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_VariationalRefinement_setDelta(Handle, value));
        }
    }

    /// <summary>
    /// Weight of the gradient constancy term
    /// </summary>
    public float Gamma
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_VariationalRefinement_getGamma(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_VariationalRefinement_setGamma(Handle, value));
        }
    }

    /// <summary>
    /// Norm value shift for robust penalizer
    /// </summary>
    public float Epsilon
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_VariationalRefinement_getEpsilon(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.video_VariationalRefinement_setEpsilon(Handle, value));
        }
    }
}
