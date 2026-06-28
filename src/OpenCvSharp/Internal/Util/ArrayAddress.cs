using System.Runtime.InteropServices;

#pragma warning disable 1591
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Internal.Util;

/// <summary>
/// Pins a managed array for the duration of a single native call and exposes its address.
/// Scoped, stack-only helper (use with <c>using</c>): no heap allocation and no finalizer.
/// </summary>
/// <typeparam name="T"></typeparam>
public ref struct ArrayAddress1<T>
    where T : unmanaged
{
    private readonly Array array;
    private GCHandle gch;

    public ArrayAddress1(T[] array)
    {
        this.array = array ?? throw new ArgumentNullException(nameof(array));
        gch = GCHandle.Alloc(array, GCHandleType.Pinned);
    }

    public ArrayAddress1(IEnumerable<T> enumerable)
        : this(enumerable.ToArray())
    {
    }

    public ArrayAddress1(T[,] array)
    {
        this.array = array ?? throw new ArgumentNullException(nameof(array));
        gch = GCHandle.Alloc(array, GCHandleType.Pinned);
    }

    /// <summary>
    /// Releases the pin.
    /// </summary>
    public void Dispose()
    {
        if (gch.IsAllocated)
        {
            gch.Free();
        }
    }

    public readonly IntPtr Pointer => gch.AddrOfPinnedObject();

    public readonly int Length => array.Length;
}
