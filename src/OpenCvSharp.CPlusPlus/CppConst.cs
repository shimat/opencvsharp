using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Constantt values
    /// </summary>
    internal static class CppConst
    {
        /// <summary>
        /// matrix decomposition types
        /// </summary>
        public const int DECOMP_LU = 0,
                         DECOMP_SVD = 1,
                         DECOMP_EIG = 2,
                         DECOMP_CHOLESKY = 3,
                         DECOMP_QR = 4,
                         DECOMP_NORMAL = 16;

        /// <summary>
        /// InputArray kind
        /// </summary>
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

        /// <summary>
        /// various border interpolation methods
        /// </summary>
        public const int BORDER_REPLICATE = 1,
            BORDER_CONSTANT = 0,
            BORDER_REFLECT = 2,
            BORDER_WRAP = 3,
            BORDER_REFLECT101 = 4,
            BORDER_TRANSPARENT = 5,
            BORDER_DEFAULT = BORDER_REFLECT101,
            BORDER_ISOLATED = 16;

        /// <summary>
        /// shape of the structuring element
        /// </summary>
        public const int MORPH_RECT = 0,
            MORPH_CROSS = 1,
            MORPH_ELLIPSE = 2;

        /// <summary>
        /// cv::dft flags
        /// </summary>
        public const int DFT_INVERSE = 1,
            DFT_SCALE = 2,
            DFT_ROWS = 4,
            DFT_COMPLEX_OUTPUT = 16,
            DFT_REAL_OUTPUT = 32;
        /// <summary>
        /// cv::dct flags
        /// </summary>
        public const int DCT_INVERSE = DFT_INVERSE,
            DCT_ROWS = DFT_ROWS;

        /// <summary>
        /// cv::initWideAngleProjMap flags
        /// </summary>
        public const int
            PROJ_SPHERICAL_ORTHO = 0,
            PROJ_SPHERICAL_EQRECT = 1;
    }
}
