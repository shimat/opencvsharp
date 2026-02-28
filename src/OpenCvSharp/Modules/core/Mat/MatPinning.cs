using System.Runtime.InteropServices;

namespace OpenCvSharp;

public partial class Mat
{
    private ArrayPinningLifetime? pinLifetime;

    /// <inheritdoc/>
    protected override void DisposeManaged()
    {
        pinLifetime?.Dispose();
        base.DisposeManaged();
    }

    /// <summary>
    /// Pins an array and unpins it when all references are released.
    /// </summary>
    private sealed class ArrayPinningLifetime : IDisposable
    {
        private GCHandle handle;
        private int refCount;

        /// <summary>
        /// Creates an instance of the <see cref="ArrayPinningLifetime"/> class.
        /// </summary>
        /// <param name="array">The array to be pinned.</param>
        public ArrayPinningLifetime(Array array)
        {
            handle = GCHandle.Alloc(array, GCHandleType.Pinned);
        }

        /// <summary>
        /// Gets the data pointer of the pinned <see cref="Array"/>.
        /// </summary>
        /// <exception cref="ObjectDisposedException">Thrown when the handle has been deallocated.</exception>
        public IntPtr DataPtr => handle.IsAllocated ? handle.AddrOfPinnedObject() : throw new ObjectDisposedException(nameof(ArrayPinningLifetime));

        /// <summary>Increments the reference count of the pinned array.</summary>
        /// <returns>Returns a reference to this <see cref="ArrayPinningLifetime"/> instance.</returns>
        public ArrayPinningLifetime Ref()
        {
            Interlocked.Increment(ref refCount);
            return this;
        }

        /// <summary>
        /// Decrements the reference count of the pinned array. If the reference count reaches zero, the array will be
        /// unpinned.
        /// </summary>
        public void Dispose()
        {
            if (Interlocked.Decrement(ref refCount) != 0 || !handle.IsAllocated)
            {
                return;
            }

            handle.Free();
            GC.SuppressFinalize(this);
        }

        ~ArrayPinningLifetime()
        {
            if (handle.IsAllocated)
            {
                handle.Free();
            }
        }
    }
}
