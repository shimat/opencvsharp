using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
/// Represents an edge in a graph for Minimum Spanning Tree (MST) computation. See <see cref="Cv2.BuildMST"/>.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public record struct MSTEdge(int Source, int Target, double Weight)
{
    /// <summary>
    /// Source node index.
    /// </summary>
    public int Source = Source;

    /// <summary>
    /// Target node index.
    /// </summary>
    public int Target = Target;

    /// <summary>
    /// Edge weight.
    /// </summary>
    public double Weight = Weight;
}
