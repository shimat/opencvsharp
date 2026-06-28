using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// Proxy datatype for passing Mat's and List&lt;&gt;'s as output parameters
/// </summary>
public sealed class OutputArrayOfStructList<T> : OutputArray
    where T : unmanaged
{
    private readonly List<T> list;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    internal OutputArrayOfStructList(List<T> list)
        : base(new Mat())
    {
        this.list = list ?? throw new ArgumentNullException(nameof(list));
    }

    /// <summary>
    /// 
    /// </summary>
    public override void AssignResult()
    {
        if (!IsReady())
            throw new NotSupportedException();
            
        NativeMethods.HandleException(
            NativeMethods.core_OutputArray_getMat(Handle, out var matPtr));
        using var mat = new Mat(matPtr);

        var size = mat.Rows * mat.Cols;

        list.Clear();
        unsafe
        {
            list.AddRange(new ReadOnlySpan<T>(mat.DataPointer, size));
        }
        // matPtr/mat aliases native memory owned by this OutputArray; keep it alive across the copy.
        GC.KeepAlive(this);
    }
}
