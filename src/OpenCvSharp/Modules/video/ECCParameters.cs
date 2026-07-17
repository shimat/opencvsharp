namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Parameters used by <see cref="Cv2.FindTransformECCMultiScale"/>.
/// A plain managed data class (not a blittable struct): <see cref="ItersPerLevel"/> is a
/// variable-length array (mirrors <c>std::vector&lt;int&gt;</c> on the native side) and is passed to
/// the native entry point via a separate <c>StdVector&lt;int&gt;</c> argument.
/// </summary>
public class ECCParameters
{
    /// <summary>
    /// parameter, specifying the type of motion
    /// </summary>
    public MotionTypes MotionType { get; set; } = MotionTypes.Affine;

    /// <summary>
    /// parameter, specifying the termination criteria of the ECC algorithm
    /// </summary>
    public TermCriteria Criteria { get; set; } = new(CriteriaTypes.Count | CriteriaTypes.Eps, 50, 1e-6);

    /// <summary>
    /// Criterion extension: distribution of iterations limit over pyramid levels.
    /// Can be null/empty, in which case the algorithm uses <see cref="Criteria"/>'s max count on each level.
    /// </summary>
    public int[]? ItersPerLevel { get; set; }

    /// <summary>
    /// An optional value indicating size of gaussian blur filter
    /// </summary>
    public int GaussFiltSize { get; set; } = 5;

    /// <summary>
    /// An optional value indicating amount of levels in the pyramid
    /// </summary>
    public int NLevels { get; set; } = 4;

    /// <summary>
    /// Type of warp interpolation. Possible values are Nearest and Linear.
    /// Affects accuracy, especially when MotionType == MotionTypes.Translation.
    /// </summary>
    public InterpolationFlags Interpolation { get; set; } = InterpolationFlags.Linear;
}
