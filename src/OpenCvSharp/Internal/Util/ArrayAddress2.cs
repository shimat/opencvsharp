using System.Runtime.InteropServices;

namespace OpenCvSharp.Internal.Util;

/// <summary>
/// Class to get address of specified jagged array 
/// </summary>
/// <typeparam name="T"></typeparam>
public class ArrayAddress2<T> : DisposableObject
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
        this.array = array ?? throw new ArgumentNullException(nameof(array));

        // T[][]をIntPtr[]に変換する
        ptr = new IntPtr[array.Length];
        gch = new GCHandle[array.Length];
        for (var i = 0; i < array.Length; i++)
        {
            var elem = array[i];
            if (elem is null/* || elem.Length == 0*/)
                throw new ArgumentException($"array[{i}] is not valid array object.");
                
            // メモリ確保
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
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        foreach (var h in gch)
        {
            if (h.IsAllocated)
            {
                h.Free();
            }
        }
        base.DisposeUnmanaged();
    }

    /// <summary>
    /// </summary>
    public IntPtr[] GetPointer()
    {
        return ptr;
    }

    /// <summary> 
    /// </summary>
#pragma warning disable CA1024 // Use properties where appropriate
    public int GetDim1Length() => array.Length;
#pragma warning restore CA1024 // Use properties where appropriate

    /// <summary> 
    /// </summary>
    public int[] GetDim2Lengths()
    {
        var lengths = new int[array.Length];
        for (var i = 0; i < array.Length; i++)
        {
            lengths[i] = array[i].Length;
        }
        return lengths;
    }
}
