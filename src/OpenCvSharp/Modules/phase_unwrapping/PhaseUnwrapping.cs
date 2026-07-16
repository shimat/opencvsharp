using OpenCvSharp.Internal;

namespace OpenCvSharp;
// ReSharper disable InconsistentNaming
#pragma warning disable 1591

/// <summary>
/// Abstract base class for phase unwrapping.
/// </summary>
public class PhaseUnwrapping : Algorithm
{
    /// <summary>
    /// constructor
    /// </summary>
    protected PhaseUnwrapping(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release)
    {
    }

    /// <summary>
    /// Unwraps a 2D phase map.
    /// </summary>
    /// <param name="wrappedPhaseMap">The wrapped phase map of type CV_32FC1 that needs to be unwrapped.</param>
    /// <param name="unwrappedPhaseMap">The unwrapped phase map.</param>
    /// <param name="shadowMask">Optional CV_8UC1 mask image used when some pixels do not hold any phase
    /// information in the wrapped phase map.</param>
    public virtual void UnwrapPhaseMap(InputArray wrappedPhaseMap, OutputArray unwrappedPhaseMap, InputArray shadowMask = default)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.phase_unwrapping_PhaseUnwrapping_unwrapPhaseMap(
                Handle, wrappedPhaseMap.Proxy, unwrappedPhaseMap.Proxy, shadowMask.Proxy));

        GC.KeepAlive(this);
        GC.KeepAlive(wrappedPhaseMap.Source);
        GC.KeepAlive(unwrappedPhaseMap.Source);
        GC.KeepAlive(shadowMask.Source);
    }
}
