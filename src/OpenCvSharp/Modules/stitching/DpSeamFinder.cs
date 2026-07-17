using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Cost function used by <see cref="DpSeamFinder"/> and <see cref="GraphCutSeamFinder"/>.
/// </summary>
public enum SeamFinderCostFunction
{
#pragma warning disable 1591
    Color,
    ColorGrad,
#pragma warning restore 1591
}

internal static class SeamFinderCostFunctionExtensions
{
    public static string ToNativeString(this SeamFinderCostFunction costFunction) => costFunction switch
    {
        SeamFinderCostFunction.Color => "COLOR",
        SeamFinderCostFunction.ColorGrad => "COLOR_GRAD",
        _ => throw new ArgumentOutOfRangeException(nameof(costFunction), costFunction, null),
    };
}

/// <summary>
/// Seam estimator based on dynamic programming.
/// </summary>
public class DpSeamFinder : SeamFinder
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="costFunction"></param>
    public DpSeamFinder(SeamFinderCostFunction costFunction = SeamFinderCostFunction.Color)
        : base(Create(costFunction), static h =>
            NativeMethods.HandleException(NativeMethods.stitching_DpSeamFinder_delete(h)))
    {
    }

    private static IntPtr Create(SeamFinderCostFunction costFunction)
    {
        NativeMethods.HandleException(
            NativeMethods.stitching_DpSeamFinder_new(costFunction.ToNativeString(), out var ptr));
        return ptr;
    }

    /// <summary>
    /// Sets the cost function used to estimate seams.
    /// </summary>
    public void SetCostFunction(SeamFinderCostFunction costFunction)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.stitching_DpSeamFinder_setCostFunction(Handle, costFunction.ToNativeString()));
    }
}
