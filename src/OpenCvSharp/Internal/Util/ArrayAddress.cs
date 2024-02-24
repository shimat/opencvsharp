using System.Runtime.InteropServices;

#pragma warning disable 1591
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Internal.Util;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class ArrayAddress1<T> : DisposableObject
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
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        if (gch.IsAllocated)
        {
            gch.Free();
        }
        base.DisposeUnmanaged();
    }
        
    public IntPtr Pointer => gch.AddrOfPinnedObject();
        
    public int Length => array.Length;
}
