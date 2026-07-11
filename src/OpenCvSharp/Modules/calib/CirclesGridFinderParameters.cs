using System.Runtime.InteropServices;

namespace OpenCvSharp;

#pragma warning disable CA1815

/// <summary>
/// Parameters for the findCirclesGrid process (cv::CirclesGridFinderParameters).
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct CirclesGridFinderParameters
{
    /// <summary>
    /// densityNeighborhoodSize
    /// </summary>
    public Size2f DensityNeighborhoodSize = new(16, 16);

    /// <summary>
    /// minDensity
    /// </summary>
    public float MinDensity = 10;

    /// <summary>
    /// kmeansAttempts
    /// </summary>
    public int KmeansAttempts = 100;

    /// <summary>
    /// minDistanceToAddKeypoint
    /// </summary>
    public int MinDistanceToAddKeypoint = 20;

    /// <summary>
    /// keypointScale
    /// </summary>
    public int KeypointScale = 1;

    /// <summary>
    /// minGraphConfidence
    /// </summary>
    public float MinGraphConfidence = 9;

    /// <summary>
    /// vertexGain
    /// </summary>
    public float VertexGain = 1;

    /// <summary>
    /// vertexPenalty
    /// </summary>
    public float VertexPenalty = -0.6f;

    /// <summary>
    /// existingVertexGain
    /// </summary>
    public float ExistingVertexGain = 10000;

    /// <summary>
    /// edgeGain
    /// </summary>
    public float EdgeGain = 1;

    /// <summary>
    /// edgePenalty
    /// </summary>
    public float EdgePenalty = -0.6f;

    /// <summary>
    /// convexHullFactor
    /// </summary>
    public float ConvexHullFactor = 1.1f;

    /// <summary>
    /// minRNGEdgeSwitchDist
    /// </summary>
    public float MinRNGEdgeSwitchDist = 5.0f;

    /// <summary>
    /// gridType
    /// </summary>
    public CirclesGridFinderGridType GridType = CirclesGridFinderGridType.SymmetricGrid;

    /// <summary>
    /// Distance between two adjacent points. Used by CALIB_CB_CLUSTERING.
    /// </summary>
    public float SquareSize = 1.0f;

    /// <summary>
    /// Max deviation from prediction. Used by CALIB_CB_CLUSTERING.
    /// </summary>
    public float MaxRectifiedDistance = 1.0f * 0.5f;

    /// <summary>
    /// Constructor
    /// </summary>
    public CirclesGridFinderParameters()
    {
    }
}
