using System.Runtime.InteropServices;

namespace OpenCvSharp.Internal;

/// <summary>
/// Blittable view of the scalar fields of cv::face::FacemarkLBF::Params.
/// The std::string / std::vector members are marshalled separately.
/// Field order must match the native FacemarkLBFParamsData struct.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct FacemarkLBFParamsData
{
    public double ShapeOffset;
    public int Verbose;
    public int NLandmarks;
    public int InitShapeN;
    public int StagesN;
    public int TreeN;
    public int TreeDepth;
    public double BaggingOverlap;
    public int SaveModel;
    public uint Seed;
    public Rect DetectROI;
}

/// <summary>
/// Blittable view of the scalar fields of cv::face::FacemarkAAM::Params.
/// The model_filename / scales members are marshalled separately.
/// Field order must match the native FacemarkAAMParamsData struct.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct FacemarkAAMParamsData
{
    public int M;
    public int N;
    public int NIter;
    public int Verbose;
    public int SaveModel;
    public int MaxM;
    public int MaxN;
    public int TextureMaxM;
}
