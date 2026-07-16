using System.Runtime.InteropServices;

namespace OpenCvSharp.Internal;

[StructLayout(LayoutKind.Sequential)]
internal struct FacemarkKazemiParamsData
{
    public ulong CascadeDepth;
    public ulong TreeDepth;
    public ulong NumTreesPerCascadeLevel;
    public float LearningRate;
    public ulong OversamplingAmount;
    public ulong NumTestCoordinates;
    public float Lambda;
    public ulong NumTestSplits;
}
