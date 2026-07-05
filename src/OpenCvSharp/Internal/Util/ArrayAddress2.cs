using System.Runtime.InteropServices;

namespace OpenCvSharp.Internal.Util;

/// <summary>
/// Pins each row of a jagged array for the duration of a single native call and exposes the
/// row addresses. Scoped, stack-only helper (use with <c>using</c>): no finalizer.
/// </summary>
/// <typeparam name="T"></typeparam>
public ref struct ArrayAddress2<T>
    where T : unmanaged
{
    private readonly T[][] array;
    private readonly GCHandle[] gch;
    private readonly IntPtr[] ptr;

    /// <summary>
    ///
    /// </summary>
    /// <param name="array"></param>
    public ArrayAddress2(T[][] array)
    {
        ArgumentNullException.ThrowIfNull(array);
        this.array = array;

        // Convert T[][] into an array of pinned-row pointers (IntPtr[]).
        ptr = new IntPtr[array.Length];
        gch = new GCHandle[array.Length];
        for (var i = 0; i < array.Length; i++)
        {
            var elem = array[i];
            if (elem is null/* || elem.Length == 0*/)
                throw new ArgumentException($"array[{i}] is not valid array object.");

            gch[i] = GCHandle.Alloc(elem, GCHandleType.Pinned);
            ptr[i] = gch[i].AddrOfPinnedObject();
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="enumerable"></param>
    public ArrayAddress2(IEnumerable<IEnumerable<T>> enumerable)
        : this(enumerable.Select(x => x.ToArray()).ToArray())
    {
    }

    /// <summary>
    /// Releases the pins.
    /// </summary>
    public void Dispose()
    {
        foreach (var h in gch)
        {
            if (h.IsAllocated)
            {
                h.Free();
            }
        }
    }

    /// <summary>
    /// </summary>
    public readonly IntPtr[] GetPointer()
    {
        return ptr;
    }

    /// <summary>
    /// </summary>
#pragma warning disable CA1024 // Use properties where appropriate
    public readonly int GetDim1Length() => array.Length;
#pragma warning restore CA1024 // Use properties where appropriate

    /// <summary>
    /// </summary>
    public readonly int[] GetDim2Lengths()
    {
        var lengths = new int[array.Length];
        for (var i = 0; i < array.Length; i++)
        {
            lengths[i] = array[i].Length;
        }
        return lengths;
    }
}
