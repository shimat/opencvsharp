using System.Runtime.InteropServices;

#pragma warning disable CA1805 // Do not initialize unnecessarily.

namespace OpenCvSharp;

/// <summary>
/// Represents a class which manages its own memory. 
/// </summary>
public abstract class DisposableObject : IDisposable
{
    /// <summary>
    /// Gets or sets a handle which allocates using cvSetData.
    /// </summary>
    protected GCHandle DataHandle { get; private set; }

    private volatile int disposeSignaled = 0;

    /// <summary>
    /// Gets a value indicating whether this instance has been disposed.
    /// </summary>
    public bool IsDisposed { get; protected set; }

    /// <summary>
    /// Gets or sets a value indicating whether you permit disposing this instance.
    /// </summary>
    public bool IsEnabledDispose { get; set; }

    /// <summary>
    /// Gets or sets a memory address allocated by AllocMemory.
    /// </summary>
    protected IntPtr AllocatedMemory { get; set; }

    /// <summary>
    /// Gets or sets the byte length of the allocated memory
    /// </summary>
    protected long AllocatedMemorySize { get; set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    protected DisposableObject()
        : this(true)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="isEnabledDispose">true if you permit disposing this class by GC</param>
    protected DisposableObject(bool isEnabledDispose)
    {
        IsDisposed = false;
        IsEnabledDispose = isEnabledDispose;
        AllocatedMemory = IntPtr.Zero;
        AllocatedMemorySize = 0;
    }

    /// <summary>
    /// Releases the resources
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the resources
    /// </summary>
    /// <param name="disposing">
    /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
    /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
#pragma warning disable 420
        // http://stackoverflow.com/questions/425132/a-reference-to-a-volatile-field-will-not-be-treated-as-volatile-implications
        if (Interlocked.Exchange(ref disposeSignaled, 1) != 0)
        {
            return;
        }

        IsDisposed = true;

        if (IsEnabledDispose)
        {
            if (disposing)
            {
                DisposeManaged();
            }
            DisposeUnmanaged();
        }
    }

    /// <summary>
    /// Destructor
    /// </summary>
    ~DisposableObject()
    {
        Dispose(false);
    }

    /// <summary>
    /// Releases managed resources
    /// </summary>
    protected virtual void DisposeManaged()
    {
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected virtual void DisposeUnmanaged()
    {
        if (DataHandle.IsAllocated)
        {
            DataHandle.Free();
        }
        if (AllocatedMemorySize > 0)
        {
            GC.RemoveMemoryPressure(AllocatedMemorySize);
            AllocatedMemorySize = 0;
        }
        if (AllocatedMemory != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(AllocatedMemory);
            AllocatedMemory = IntPtr.Zero;
        }
    }
        
    /// <summary>
    /// Pins the object to be allocated by cvSetData.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    // ReSharper disable once InconsistentNaming
    protected internal GCHandle AllocGCHandle(object obj)
    {
        if (obj is null)
            throw new ArgumentNullException(nameof(obj));
            
        if (DataHandle.IsAllocated)
            DataHandle.Free();
        DataHandle = GCHandle.Alloc(obj, GCHandleType.Pinned);
        return DataHandle;
    }

    /// <summary>
    /// Allocates the specified size of memory.
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    protected IntPtr AllocMemory(int size)
    {
        if (size <= 0)
            throw new ArgumentOutOfRangeException(nameof(size));
            
        if (AllocatedMemory != IntPtr.Zero)
            Marshal.FreeHGlobal(AllocatedMemory);
        AllocatedMemory = Marshal.AllocHGlobal(size);
        NotifyMemoryPressure(size);
        return AllocatedMemory;
    }

    /// <summary>
    /// Notifies the allocated size of memory.
    /// </summary>
    /// <param name="size"></param>
    protected void NotifyMemoryPressure(long size)
    {
        // マルチスレッド動作時にロックがかかるらしい。いったん廃止
        if (!IsEnabledDispose)
            return;
        if (size == 0)
            return;
        if (size <= 0)
            throw new ArgumentOutOfRangeException(nameof(size));
            
        if (AllocatedMemorySize > 0)
            GC.RemoveMemoryPressure(AllocatedMemorySize);
            
        AllocatedMemorySize = size;
        GC.AddMemoryPressure(size);
    }

    /// <summary>
    /// If this object is disposed, then ObjectDisposedException is thrown.
    /// </summary>
    public void ThrowIfDisposed()
    {
        if (IsDisposed) 
            throw new ObjectDisposedException(GetType().FullName);
    }
}
