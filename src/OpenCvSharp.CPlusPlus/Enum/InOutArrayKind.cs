using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
#pragma warning disable 1591

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum InOutArrayKind
    {
        None = CppConst.InputArray_NONE,
        Mat = CppConst.InputArray_MAT,
        Matx = CppConst.InputArray_MATX,
        StdVector = CppConst.InputArray_STD_VECTOR,
        VectorVector = CppConst.InputArray_STD_VECTOR_VECTOR,
        VectorMat = CppConst.InputArray_STD_VECTOR_MAT,
        Expr = CppConst.InputArray_EXPR,
        OpenGLBuffer = CppConst.InputArray_OPENGL_BUFFER,
        OpenGLTexture = CppConst.InputArray_OPENGL_TEXTURE,
        GpuMat = CppConst.InputArray_GPU_MAT,
        OclMat = CppConst.InputArray_OCL_MAT,

        FixedType = CppConst.InputArray_FIXED_TYPE,
        FixedSize = CppConst.InputArray_FIXED_SIZE,
    }
}
