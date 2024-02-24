#pragma warning disable 1591
#pragma warning disable CA2217 // Do not mark enums with FlagsAttribute

namespace OpenCvSharp;

/// <summary>
/// 
/// </summary>
[Flags]
public enum InOutArrayKind
{
    None = 0,
    Mat = 1 << InputArray.KIND_SHIFT,
    Matx = 2 << InputArray.KIND_SHIFT,
    StdVector = 3 << InputArray.KIND_SHIFT,
    VectorVector = 4 << InputArray.KIND_SHIFT,
    VectorMat = 5 << InputArray.KIND_SHIFT,
    Expr = 6 << InputArray.KIND_SHIFT,
    OpenGLBuffer = 7 << InputArray.KIND_SHIFT,
    CudaHostMem = 8 << InputArray.KIND_SHIFT,
    CudaGpuMat = 9 << InputArray.KIND_SHIFT,
    UMat = 10 << InputArray.KIND_SHIFT,
    StdVectorUMat = 11 << InputArray.KIND_SHIFT,
    StdBoolVector = 12 << InputArray.KIND_SHIFT,
    StdVectorCudaGpuMat = 13 << InputArray.KIND_SHIFT,

    FixedType = 0x8000 << InputArray.KIND_SHIFT,
    FixedSize = 0x4000 << InputArray.KIND_SHIFT,
}
