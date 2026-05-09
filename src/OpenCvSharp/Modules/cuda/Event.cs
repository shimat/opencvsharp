#if ENABLED_CUDA
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    public sealed class Event : DisposableGpuObject
    {
        public Event()
        {
            NativeMethods.HandleException(NativeMethods.cuda_Event_new1(out IntPtr p));
            InitSafeHandle(p);
        }

        /// <summary>
        /// Creates a new CUDA event.
        /// </summary>
        /// <param name="flags">Creation flags.</param>
        public Event(EventCreateFlags flags = EventCreateFlags.Default)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_Event_new2((int)flags, out IntPtr p));
            InitSafeHandle(p);
        }


        private void InitSafeHandle(IntPtr p)
        {
            SetSafeHandle(new OpenCvPtrSafeHandle(p, true,
                h => NativeMethods.cuda_Event_delete(h)));
        }

        public void Record(Stream stream = null)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_Event_record(CvPtr, stream?.CvPtr ?? IntPtr.Zero));
            GC.KeepAlive(this);
            if (stream != null) GC.KeepAlive(stream);
        }

        public void WaitForCompletion()
        {
            NativeMethods.HandleException(NativeMethods.cuda_Event_waitForCompletion(CvPtr));
            GC.KeepAlive(this);
        }

        public bool QueryIfComplete()
        {
            NativeMethods.HandleException(NativeMethods.cuda_Event_queryIfComplete(CvPtr, out int res));
            GC.KeepAlive(this);
            return res != 0;
        }

        /// <summary>
        /// Computes the elapsed time between two events (in milliseconds).
        /// </summary>
        public static float ElapsedTime(Event start, Event end)
        {
            if (start == null) 
                throw new ArgumentNullException(nameof(start));
            if (end == null) 
                throw new ArgumentNullException(nameof(end));
            start.ThrowIfDisposed();
            end.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_Event_elapsedTime(start.CvPtr, end.CvPtr, out float time));

            GC.KeepAlive(start);
            GC.KeepAlive(end);
            return time;
        }

        // Add this constructor if you don't have it
        internal Event(IntPtr ptr)
        {
            InitSafeHandle(ptr);
        }

        /// <summary>
        /// Returns the raw CUDA event handle (cudaEvent_t).
        /// </summary>
        public IntPtr Handle
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.cuda_Event_getEvent(ptr, out var handle));
                GC.KeepAlive(this);
                return handle;
            }
        }

        /// <summary>
        /// Creates an Event object from an existing raw CUDA event handle.
        /// </summary>
        /// <param name="rawHandle">The memory address of the existing cudaEvent_t.</param>
        /// <returns></returns>
        public static Event WrapEvent(IntPtr rawHandle)
        {
            if (rawHandle == IntPtr.Zero)
                throw new ArgumentNullException(nameof(rawHandle));

            NativeMethods.HandleException(
                NativeMethods.cuda_Event_wrapEvent(rawHandle, out var ptr));

            return new Event(ptr);
        }
    }
}
#endif
