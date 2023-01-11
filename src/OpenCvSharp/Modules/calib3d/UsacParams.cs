using System.Runtime.InteropServices;

namespace OpenCvSharp;
#pragma warning disable CS1591

public class UsacParams
{
#pragma warning disable CA1805
    public double Confidence { get; set; } = 0.99;
    public bool IsParallel { get; set; } = false;
    public int LoIterations { get; set; } = 5;
    public LocalOptimMethod LoMethod { get; set; } = LocalOptimMethod.INNER_LO;
    public int LoSampleSize { get; set; } = 14;
    public int MaxIterations { get; set; } = 5000;
    public NeighborSearchMethod NeighborsSearch { get; set; } = NeighborSearchMethod.GRID;
    public int RandomGeneratorState { get; set; } = 0;
    public SamplingMethod Sampler { get; set; } = SamplingMethod.UNIFORM;
    public ScoreMethod Score { get; set; } = ScoreMethod.MSAC;
    public double Threshold { get; set; } = 1.5;

    public WUsacParams ToNativeStruct() => new WUsacParams
    {
        Confidence = Confidence,
        IsParallel = IsParallel ? 1 : 0,
        LoIterations = LoIterations,
        LoMethod = LoMethod,
        LoSampleSize = LoSampleSize,
        MaxIterations = MaxIterations,
        NeighborsSearch = NeighborsSearch,
        RandomGeneratorState = RandomGeneratorState,
        Sampler = Sampler,
        Score = Score,
        Threshold = Threshold,
    };
}

#pragma warning disable CA1815
[StructLayout(LayoutKind.Sequential)]
public struct WUsacParams
{
    public double Confidence;
    public int IsParallel;
    public int LoIterations;
    public LocalOptimMethod LoMethod;
    public int LoSampleSize;
    public int MaxIterations;
    public NeighborSearchMethod NeighborsSearch;
    public int RandomGeneratorState;
    public SamplingMethod Sampler;
    public ScoreMethod Score;
    public double Threshold;
}

public enum SamplingMethod : int
{
    UNIFORM, 
    PROGRESSIVE_NAPSAC, 
    NAPSAC,
    PROSAC
}

public enum LocalOptimMethod : int
{
    NULL,
    INNER_LO, 
    INNER_AND_ITER_LO,
    GC,
    SIGMA
}

public enum ScoreMethod : int
{ 
    RANSAC, 
    MSAC, 
    MAGSAC, 
    LMEDS 
}

public enum NeighborSearchMethod : int
{ 
    FLANN_KNN, 
    GRID, 
    FLANN_RADIUS 
}
