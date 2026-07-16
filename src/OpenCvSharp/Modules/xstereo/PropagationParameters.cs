using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
/// Parameters controlling the quasi-dense propagation used by <see cref="QuasiDenseStereo"/>.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct PropagationParameters
{
    /// <summary>
    /// Similarity window size (X).
    /// </summary>
    public int CorrWinSizeX;

    /// <summary>
    /// Similarity window size (Y).
    /// </summary>
    public int CorrWinSizeY;

    /// <summary>
    /// Border to ignore (X).
    /// </summary>
    public int BorderX;

    /// <summary>
    /// Border to ignore (Y).
    /// </summary>
    public int BorderY;

    /// <summary>
    /// Correlation threshold used during matching.
    /// </summary>
    public float CorrelationThreshold;

    /// <summary>
    /// Texture threshold used during matching.
    /// </summary>
    public float TextrureThreshold;

    /// <summary>
    /// Neighborhood size.
    /// </summary>
    public int NeighborhoodSize;

    /// <summary>
    /// Disparity gradient threshold.
    /// </summary>
    public int DisparityGradient;

    /// <summary>
    /// Template size used by the LK flow algorithm.
    /// </summary>
    public int LkTemplateSize;

    /// <summary>
    /// Pyramid level used by the LK flow algorithm.
    /// </summary>
    public int LkPyrLvl;

    /// <summary>
    /// First termination parameter used by the LK flow algorithm.
    /// </summary>
    public int LkTermParam1;

    /// <summary>
    /// Second termination parameter used by the LK flow algorithm.
    /// </summary>
    public float LkTermParam2;

    /// <summary>
    /// Quality threshold used by the GFT (Good Features to Track) algorithm.
    /// </summary>
    public float GftQualityThres;

    /// <summary>
    /// Minimum separation distance used by the GFT algorithm.
    /// </summary>
    public int GftMinSeperationDist;

    /// <summary>
    /// Maximum number of features used by the GFT algorithm.
    /// </summary>
    public int GftMaxNumFeatures;
}
