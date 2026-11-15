namespace OpenCvSharp;

/// <summary>
/// Options for reducing an n-dimensional array.
/// </summary>
public sealed class ReduceParams
{
    /// <summary>The reduction operation.</summary>
    public ReduceTypes RType { get; set; }

    /// <summary>Axes to reduce. Negative values count from the end. An empty array reduces all axes.</summary>
    public int[] Axes { get; set; }

    /// <summary>Keep the reduced axes with a size of one.</summary>
    public bool KeepDims { get; set; }

    /// <summary>Output depth. A negative value preserves the input depth.</summary>
    public int DType { get; set; }

    /// <summary>Creates options for reducing an n-dimensional array.</summary>
    /// <param name="rtype">The reduction operation.</param>
    /// <param name="axes">Axes to reduce. A null or empty array reduces all axes.</param>
    /// <param name="keepDims">Keep the reduced axes with a size of one.</param>
    /// <param name="dtype">Output depth. A negative value preserves the input depth.</param>
    public ReduceParams(ReduceTypes rtype = ReduceTypes.Sum, int[]? axes = null, bool keepDims = true, int dtype = -1)
    {
        RType = rtype;
        Axes = axes ?? [];
        KeepDims = keepDims;
        DType = dtype;
    }
}
