using System;

namespace OpenCvSharp
{
#pragma warning disable 1591

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum InOutArrayKind
    {
        None = 0 << InputArray.KIND_SHIFT,
        Mat = 1 << InputArray.KIND_SHIFT,
        Matx = 2 << InputArray.KIND_SHIFT,
        StdVector = 3 << InputArray.KIND_SHIFT,
        VectorVector = 4 << InputArray.KIND_SHIFT,
        VectorMat = 5 << InputArray.KIND_SHIFT,
        Expr = 6 << InputArray.KIND_SHIFT,
        OpenGLBuffer = 7 << InputArray.KIND_SHIFT,
        OpenGLTexture = 8 << InputArray.KIND_SHIFT,
        GpuMat = 9 << InputArray.KIND_SHIFT,
        OclMat = 10 << InputArray.KIND_SHIFT,

        FixedType = 0x8000 << InputArray.KIND_SHIFT,
        FixedSize = 0x4000 << InputArray.KIND_SHIFT,
    }
}
