using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Constantt values
    /// </summary>
    internal static class CppConst
    {
        // matrix decomposition types
        public const int DECOMP_LU = 0,
                         DECOMP_SVD = 1,
                         DECOMP_EIG = 2,
                         DECOMP_CHOLESKY = 3,
                         DECOMP_QR = 4,
                         DECOMP_NORMAL = 16;

        public const int InputArray_KIND_SHIFT = 16,
                         InputArray_FIXED_TYPE = 0x8000 << InputArray_KIND_SHIFT,
                         InputArray_FIXED_SIZE = 0x4000 << InputArray_KIND_SHIFT,
                         InputArray_KIND_MASK = ~(InputArray_FIXED_TYPE | InputArray_FIXED_SIZE) - (1 << InputArray_KIND_SHIFT) + 1,
                         InputArray_NONE = 0 << InputArray_KIND_SHIFT,
                         InputArray_MAT = 1 << InputArray_KIND_SHIFT,
                         InputArray_MATX = 2 << InputArray_KIND_SHIFT,
                         InputArray_STD_VECTOR = 3 << InputArray_KIND_SHIFT,
                         InputArray_STD_VECTOR_VECTOR = 4 << InputArray_KIND_SHIFT,
                         InputArray_STD_VECTOR_MAT = 5 << InputArray_KIND_SHIFT,
                         InputArray_EXPR = 6 << InputArray_KIND_SHIFT,
                         InputArray_OPENGL_BUFFER = 7 << InputArray_KIND_SHIFT,
                         InputArray_OPENGL_TEXTURE = 8 << InputArray_KIND_SHIFT,
                         InputArray_GPU_MAT = 9 << InputArray_KIND_SHIFT,
                         InputArray_OCL_MAT = 10 << InputArray_KIND_SHIFT;
    }
}
