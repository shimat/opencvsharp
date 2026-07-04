namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// Algorithms available for building a Minimum Spanning Tree (MST). See <see cref="Cv2.BuildMST"/>.
/// </summary>
public enum MSTAlgorithm
{
    /// <summary>
    /// Prim's algorithm.
    /// </summary>
    Prim = 0,

    /// <summary>
    /// Kruskal's algorithm.
    /// </summary>
    Kruskal = 1
}
