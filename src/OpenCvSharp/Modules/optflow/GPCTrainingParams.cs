using OpenCvSharp.Internal;

namespace OpenCvSharp.OptFlow;

/// <summary>
/// Parameters for training a <see cref="GPCTree"/> or <see cref="GPCForest5"/>.
/// </summary>
public sealed class GPCTrainingParams
{
    /// <summary>
    /// Maximum tree depth to stop partitioning. Default: 20.
    /// </summary>
    public uint MaxTreeDepth { get; set; } = 20;

    /// <summary>
    /// Minimum number of samples in the node to stop partitioning. Default: 3.
    /// </summary>
    public int MinNumberOfSamples { get; set; } = 3;

    /// <summary>
    /// Type of descriptors to use. Default: <see cref="GPCDescType.DCT"/>.
    /// </summary>
    public GPCDescType DescriptorType { get; set; } = GPCDescType.DCT;

    /// <summary>
    /// Print progress to stdout. Default: true.
    /// </summary>
    public bool PrintProgress { get; set; } = true;

    /// <summary>
    /// Converts this instance to the blittable P/Invoke representation.
    /// </summary>
    internal CvGPCTrainingParams ToNative() => new()
    {
        MaxTreeDepth = MaxTreeDepth,
        MinNumberOfSamples = MinNumberOfSamples,
        DescriptorType = (int)DescriptorType,
        PrintProgress = PrintProgress ? 1 : 0,
    };
}
