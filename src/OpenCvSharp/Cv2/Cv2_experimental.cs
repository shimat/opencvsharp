using OpenCvSharp.Internal;

namespace OpenCvSharp;

// PROTOTYPE (issue: InputArray/OutputArray ref struct redesign).
// One function wired through the ref-struct proxy path to prove the end-to-end design:
// implicit Mat -> InputArrayRef/OutputArrayRef (stack, no alloc) -> extern receives handle+kind
// -> native builds cv::_InputArray/_OutputArray on the stack. No managed/native _InputArray
// object is allocated per call.
static partial class Cv2
{
    /// <summary>
    /// PROTOTYPE: Transposes a matrix through the allocation-free ref-struct proxy path.
    /// </summary>
    public static void TransposeRef(InputArrayRef src, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_transpose_io(src.Handle, (int)src.Kind, dst.Handle, (int)dst.Kind));
        GC.KeepAlive(src.Source);
        GC.KeepAlive(dst.Source);
    }

    /// <summary>
    /// PROTOTYPE: Per-element addition through the ref-struct proxy path. Either operand may be a
    /// Mat/UMat or a Scalar/double — scalars travel inline (no allocation).
    /// </summary>
    public static void AddRef(InputArrayRef src1, InputArrayRef src2, OutputArrayRef dst)
    {
        NativeMethods.HandleException(
            NativeMethods.core_add_io(
                src1.Handle, (int)src1.Kind, src1.ScalarValue,
                src2.Handle, (int)src2.Kind, src2.ScalarValue,
                dst.Handle, (int)dst.Kind));
        GC.KeepAlive(src1.Source);
        GC.KeepAlive(src2.Source);
        GC.KeepAlive(dst.Source);
    }
}
