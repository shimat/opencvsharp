using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// Class implementing the AKAZE-style affine-invariant feature wrapper (ASIFT and friends).
/// It wraps another <see cref="Feature2D"/> backend and applies it over a set of simulated
/// affine (tilt/rotation) views of the image. See Y. Yu, J.M. Morel "ASIFT".
/// </summary>
public class AffineFeature : Feature2D
{
    /// <summary>
    /// Creates instance by raw pointer cv::AffineFeature*
    /// </summary>
    private AffineFeature(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.features_Ptr_AffineFeature_delete(p)))
    {
    }

    /// <summary>
    /// Creates an AffineFeature detector/extractor over the given backend.
    /// </summary>
    /// <param name="backend">The detector/extractor used as backend (e.g. SIFT).</param>
    /// <param name="maxTilt">The highest power index of tilt factor. 5 is used in the paper as tilt sampling range n.</param>
    /// <param name="minTilt">The lowest power index of tilt factor. 0 is used in the paper.</param>
    /// <param name="tiltStep">Tilt sampling step in Algorithm 1 in the paper.</param>
    /// <param name="rotateStepBase">Rotation sampling step factor b in Algorithm 1 in the paper.</param>
    public static AffineFeature Create(
        Feature2D backend, int maxTilt = 5, int minTilt = 0,
        float tiltStep = 1.4142135623730951f, float rotateStepBase = 72)
    {
        if (backend is null)
            throw new ArgumentNullException(nameof(backend));

        NativeMethods.HandleException(
            NativeMethods.features_AffineFeature_create(
                backend.SmartPtr, maxTilt, minTilt, tiltStep, rotateStepBase, out var smartPtr));
        GC.KeepAlive(backend);
        NativeMethods.HandleException(
            NativeMethods.features_Ptr_Feature2D_get(smartPtr, out var rawPtr));
        return new AffineFeature(smartPtr, rawPtr);
    }

    /// <summary>
    /// Sets the tilt and rotation view sampling parameters.
    /// </summary>
    /// <param name="tilts">Tilt sampling values.</param>
    /// <param name="rolls">Roll (rotation) sampling values, in degrees.</param>
    public void SetViewParams(float[] tilts, float[] rolls)
    {
        if (tilts is null)
            throw new ArgumentNullException(nameof(tilts));
        if (rolls is null)
            throw new ArgumentNullException(nameof(rolls));
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.features_AffineFeature_setViewParams(Handle, tilts, tilts.Length, rolls, rolls.Length));
    }

    /// <summary>
    /// Gets the tilt and rotation view sampling parameters.
    /// </summary>
    /// <param name="tilts">Output tilt sampling values.</param>
    /// <param name="rolls">Output roll (rotation) sampling values, in degrees.</param>
    public void GetViewParams(out float[] tilts, out float[] rolls)
    {
        ThrowIfDisposed();

        using var tiltsVec = new StdVector<float>();
        using var rollsVec = new StdVector<float>();
        NativeMethods.HandleException(
            NativeMethods.features_AffineFeature_getViewParams(Handle, tiltsVec.CvPtr, rollsVec.CvPtr));
        tilts = tiltsVec.ToArray();
        rolls = rollsVec.ToArray();
    }
}
