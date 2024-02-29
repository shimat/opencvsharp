using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.Internal.Util;

/// <summary>
/// Original GCHandle that implement IDisposable 
/// </summary>
// ReSharper disable once InconsistentNaming
public sealed class ScopedGCHandle : IDisposable
{
    private GCHandle handle;
    private bool disposed;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="value"></param>
    public ScopedGCHandle(object value)
    {
        if (value is null) 
            throw new ArgumentNullException(nameof(value));
        handle = GCHandle.Alloc(value);
        disposed = false;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="value"></param>
    /// <param name="type"></param>
    public ScopedGCHandle(object value, GCHandleType type)
    {
        if (value is null)
            throw new ArgumentNullException(nameof(value));
        handle = GCHandle.Alloc(value, type);
        disposed = false;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="handle"></param>
    private ScopedGCHandle(GCHandle handle)
    {
        this.handle = handle;
        disposed = false;
    }
        
    public void Dispose()
    {
        if (!disposed)
        {
            // Release managed resources.
            if (handle.IsAllocated)
            {
                handle.Free();
            }
            disposed = true;
        }
    }
        
    public static ScopedGCHandle FromIntPtr(IntPtr value)
    {
        return new ScopedGCHandle(GCHandle.FromIntPtr(value));
    }

    public static IntPtr ToIntPtr(ScopedGCHandle value)
    {
        if (value is null)
            throw new ArgumentNullException(nameof(value));

        return GCHandle.ToIntPtr(value.Handle);
    }

    public GCHandle Handle => handle;

    public bool IsAllocated => handle.IsAllocated;

    public object? Target => handle.Target;

    public void Free()
    {
        handle.Free();
    }

    public override string? ToString()
    {
        return handle.ToString();
    }
}
