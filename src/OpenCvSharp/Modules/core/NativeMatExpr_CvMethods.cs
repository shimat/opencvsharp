using OpenCvSharp.Internal;

namespace OpenCvSharp;

partial class NativeMatExpr
{
    /// <summary>
    /// Computes absolute value of each matrix element
    /// </summary>
    /// <returns></returns>
    public NativeMatExpr Abs()
    {
        NativeMethods.HandleException(NativeMethods.core_abs_MatExpr(CvPtr, out var ret));
        return new NativeMatExpr(ret);
    }
}
