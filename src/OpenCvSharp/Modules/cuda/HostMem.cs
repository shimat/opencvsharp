using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    public class HostMem : DisposableGpuObject
    {
        internal HostMem(IntPtr ptr)
        {
            InitSafeHandle(ptr);
        }

        public HostMem(HostMemAllocType allocType = HostMemAllocType.PageLocked)
        {
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_new1((int)allocType, out IntPtr ptr));
            InitSafeHandle(ptr);
        }

        public HostMem(int rows, int cols, MatType type, HostMemAllocType allocType = HostMemAllocType.PageLocked)
        {
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_new2(rows, cols, type.Value, (int)allocType, out IntPtr ptr));
            InitSafeHandle(ptr);
        }

        public HostMem(Size size, MatType type, HostMemAllocType allocType = HostMemAllocType.PageLocked)
            : this(size.Height, size.Width, type, allocType) { }

        public HostMem(InputArray arr, HostMemAllocType allocType = HostMemAllocType.PageLocked)
        {
            if (arr == null) throw new ArgumentNullException(nameof(arr));
            arr.ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_new3(arr.CvPtr, (int)allocType, out IntPtr ptr));
            InitSafeHandle(ptr);
            GC.KeepAlive(arr);
        }

        private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
        {
            SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
                static h => NativeMethods.cuda_HostMem_delete(h)));
        }


        public int Channels() 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_channels(ptr, out int ret)); 
            GC.KeepAlive(this); 
            return ret; 
        }

        public int Depth() 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_depth(ptr, out int ret)); 
            GC.KeepAlive(this); 
            return ret; 
        }

        public ulong ElemSize() 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_elemSize(ptr, out var ret)); 
            GC.KeepAlive(this); 
            return (ulong)ret;
        }

        public ulong ElemSize1() 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_elemSize1(ptr, out var ret)); 
            GC.KeepAlive(this);
            return (ulong)ret;
        }

        public bool Empty() 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_empty(ptr, out int ret)); 
            GC.KeepAlive(this); 
            return ret != 0; 
        }

        public bool IsContinuous() 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_isContinuous(ptr, out int ret));
            GC.KeepAlive(this);
            return ret != 0;
        }

        public Size Size() 
        { ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_size(ptr, out var ret)); 
            GC.KeepAlive(this); 
            return ret; 
        }
        public ulong Step() 
        { ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_step(ptr, out var ret));
            GC.KeepAlive(this); 
            return (ulong)ret; 
        }

        public ulong Step1()
        { ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_step1(ptr, out var ret));
            GC.KeepAlive(this); 
            return (ulong)ret;
        }

        public MatType Type() 
        { 
            ThrowIfDisposed(); 
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_type(ptr, out int ret)); 
            GC.KeepAlive(this); 
            return ret; 
        }

        public HostMem Clone()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_clone(ptr, out IntPtr ret));
            GC.KeepAlive(this);
            return new HostMem(ret);
        }

        public void Create(int rows, int cols, MatType type)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_create(ptr, rows, cols, type.Value));
            GC.KeepAlive(this);
        }

        public void Create(Size size, MatType type) => Create(size.Height, size.Width, type);

        public GpuMat CreateGpuMatHeader()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_createGpuMatHeader(ptr, out IntPtr ret));
            GC.KeepAlive(this);
            return new GpuMat(ret);
        }

        public Mat CreateMatHeader()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_createMatHeader(ptr, out IntPtr ret));
            GC.KeepAlive(this);
            return new Mat(ret);
        }

        public void Release()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_release(ptr));
            GC.KeepAlive(this);
        }

        public HostMem Reshape(int cn, int rows = 0)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_reshape(ptr, cn, rows, out IntPtr ret));
            GC.KeepAlive(this);
            return new HostMem(ret);
        }

        public void Swap(HostMem b)
        {
            if (b == null) throw new ArgumentNullException(nameof(b));
            ThrowIfDisposed();
            b.ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_swap(ptr, b.ptr));
            GC.KeepAlive(this); GC.KeepAlive(b);
        }

        public void AssignFrom(HostMem m)
        {
            if (m == null) throw new ArgumentNullException(nameof(m));
            ThrowIfDisposed(); m.ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_HostMem_assignFrom(ptr, m.ptr));
            GC.KeepAlive(this); GC.KeepAlive(m);
        }
    }
}
