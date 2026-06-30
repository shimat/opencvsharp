using OpenCvSharp.Internal;

namespace OpenCvSharp;

// FOUNDATION (issue: InputArray/OutputArray ref-struct redesign).
// A few functions wired through the ref-struct proxy path to prove the end-to-end design:
// implicit Mat/Scalar/... -> InputArrayRef/OutputArrayRef (stack, no alloc) -> extern receives an
// ArrayProxy BY VALUE -> native rebuilds cv::_InputArray/_OutputArray on its stack. No managed or
// native _InputArray object is allocated per call.
static partial class Cv2
{
    /// <summary>
    /// FOUNDATION: Transposes a matrix through the allocation-free ref-struct proxy path.
    /// </summary>
    public static void TransposeRef(InputArrayRef src, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_transpose(src.Proxy, dst.Proxy));
        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// FOUNDATION: Per-element addition through the ref-struct proxy path. Either operand may be a
    /// Mat/UMat or a Scalar/double — scalars travel inline (no allocation).
    /// </summary>
    public static void AddRef(InputArrayRef src1, InputArrayRef src2, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_add(src1.Proxy, src2.Proxy, dst.Proxy, default, -1));
        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// FOUNDATION: Copies the lower/upper half of a square matrix onto the other half, in place,
    /// through the ref-struct proxy path (exercises the InputOutputArray proxy).
    /// </summary>
    public static void CompleteSymmRef(InputOutputArrayRef mtx, bool lowerToUpper = false)
    {
        NativeMethods.HandleException(
            NativeMethods.core_completeSymm(mtx.Proxy, lowerToUpper ? 1 : 0));
        GC.KeepAlive(mtx.Source);
    }
}
