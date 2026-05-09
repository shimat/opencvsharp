#if ENABLED_CUDA
using System;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// N-dimensional GPU matrix.
    /// </summary>
    public sealed class GpuMatND : CvObject
    {
        public GpuMatND()
        {
            NativeMethods.HandleException(NativeMethods.cuda_GpuMatND_new1(out var ptr));
            InitSafeHandle(ptr);
        }

        public GpuMatND(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Native object address is NULL");
            InitSafeHandle(ptr);
        }

        public GpuMatND(int[] sizes, MatType type)
        {
            if (sizes == null) throw new ArgumentNullException(nameof(sizes));
            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMatND_new2(sizes.Length, sizes, type.Value, out var ptr));
            InitSafeHandle(ptr);
        }

        private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
        {
            SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
                static h => NativeMethods.cuda_GpuMatND_delete(h)));
        }

        /// <summary>
        /// Allocates GPU memory. Suppose there is some GPU memory already allocated.
        /// In that case, this method may choose to reuse that GPU memory under the specific condition: 
        /// it must be of the same size and type, not externally allocated, the GPU memory is continuous(i.e., isContinuous() is true),
        /// and is not a sub-matrix of another GpuMatND (i.e., isSubmatrix() is false).
        /// In other words, this method guarantees that the GPU memory allocated by this method is always continuous and 
        /// is not a sub-region of another GpuMatND. 
        /// </summary>
        /// <param name="sizes"></param>
        /// <param name="type"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Create(int[] sizes, MatType type)
        {
            ThrowIfDisposed();
            if (sizes == null) throw new ArgumentNullException(nameof(sizes));
            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMatND_create(ptr, sizes.Length, sizes, type.Value));
            GC.KeepAlive(this);
        }

        /// <summary>
        /// returns true if GpuND data is NULL
        /// </summary>
        /// <returns></returns>
        public bool Empty()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMatND_empty(CvPtr, out int res));
            GC.KeepAlive(this);
            return res != 0;
        }

        /// <summary>
        /// Creates a full copy of the array and the underlying data (Blocking call).
        /// </summary>
        /// <returns></returns>
        public GpuMatND Clone()
        {
            return Clone(null);
        }

        /// <summary>
        /// Creates a full copy of the array and the underlying data (Asynchronous call).
        /// </summary>
        /// <param name="stream">Stream for the asynchronous version.</param>
        /// <returns></returns>
        public GpuMatND Clone(Stream? stream)
        {
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMatND_clone(ptr, out var resPtr, stream?.CvPtr ?? IntPtr.Zero));

            GC.KeepAlive(this);
            if (stream != null) GC.KeepAlive(stream);

            return new GpuMatND(resPtr);
        }

        /// <summary>
        /// Creates a GpuMat header for a 2D part of the n-dim matrix.
        /// </summary>
        /// <returns></returns>
        public GpuMat CreateGpuMatHeader()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMatND_createGpuMatHeader1(ptr, out var resPtr));
            GC.KeepAlive(this);
            return new GpuMat(resPtr);
        }

        /// <summary>
        /// Creates a GpuMat header for a 2D plane part of an n-dim matrix.
        /// </summary>
        /// <param name="indices">Indices for the higher dimensions (e.g. for 3D [10, 100, 100], use [n] to get the n-th 100x100 plane).</param>
        /// <param name="rowRange">Range of rows for the 2D plane (use Range.All for full height).</param>
        /// <param name="colRange">Range of columns for the 2D plane (use Range.All for full width).</param>
        /// <returns>A 2D GpuMat view of the data.</returns>
        public GpuMat CreateGpuMatHeader(int[] indices, Range rowRange, Range colRange)
        {
            if (indices == null) throw new ArgumentNullException(nameof(indices));
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMatND_createGpuMatHeader2(ptr, indices, indices.Length, rowRange, colRange, out var resPtr));

            GC.KeepAlive(this);
            return new GpuMat(resPtr);
        }

        /// <summary>
        /// Performs data download from GpuMatND to host memory (Blocking call).
        /// </summary>
        /// <param name="dst">Destination host array (Mat).</param>
        public void Download(OpenCvSharp.OutputArray dst)
        {
            Download(dst, null);
        }

        /// <summary>
        /// Performs data download from GpuMatND to host memory.
        /// </summary>
        /// <param name="dst">Destination host array (Mat).</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public void Download(OpenCvSharp.OutputArray dst, Stream? stream = null)
        {
            if (dst == null) 
                throw new ArgumentNullException(nameof(dst));
            ThrowIfDisposed();
            dst.ThrowIfNotReady();

            if (stream == null)
            {
                NativeMethods.HandleException(
                    NativeMethods.cuda_GpuMatND_download(ptr, dst.CvPtr));
            }
            else
            {
                NativeMethods.HandleException(
                    NativeMethods.cuda_GpuMatND_download_stream(ptr, dst.CvPtr, stream.CvPtr));
            }

            dst.Fix();
            GC.KeepAlive(this);
            if (stream != null) GC.KeepAlive(stream);
        }

        /// <summary>
        /// Returns the matrix element size in bytes.
        /// </summary>
        public ulong ElemSize
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_GpuMatND_elemSize(ptr, out var ret));
                GC.KeepAlive(this);
                return (ulong)ret;
            }
        }

        /// <summary>
        /// Returns the size of each matrix element channel in bytes.
        /// </summary>
        public ulong ElemSize1
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_GpuMatND_elemSize1(ptr, out var ret));
                GC.KeepAlive(this);
                return (ulong)ret;
            }
        }

        /// <summary>
        /// Returns true if not empty and points to external (user-allocated) GPU memory.
        /// </summary>
        public bool External
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_GpuMatND_external(ptr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
        }

        /// <summary>
        /// Returns the raw pointer to the first byte of the GPU memory.
        /// </summary>
        public IntPtr DevicePtr
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_GpuMatND_getDevicePtr(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Returns true if the matrix data is continuous.
        /// </summary>
        public bool IsContinuous
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_GpuMatND_isContinuous(ptr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
        }

        /// <summary>
        /// Returns true if the matrix is a sub-matrix of another matrix.
        /// </summary>
        public bool IsSubmatrix
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_GpuMatND_isSubmatrix(ptr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
        }

        /// <summary>
        /// Extracts a 2D plane part of an n-dim matrix if this GpuMatND is effectively 2D.
        /// This creates a DEEP COPY (clones the data).
        /// </summary>
        public static explicit operator GpuMat(GpuMatND mat)
        {
            if (mat == null) throw new ArgumentNullException(nameof(mat));
            mat.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMatND_opToGpuMat(mat.ptr, out var resPtr));

            return new GpuMat(resPtr);
        }

        /// <summary>
        /// Extracts an N-dimensional sub-matrix. 
        /// This is an O(1) operation (Shallow Copy / Header only).
        /// </summary>
        /// <param name="ranges">Array of ranges for every dimension.</param>
        /// <returns></returns>
        public GpuMatND this[params Range[] ranges]
        {
            get
            {
                if (ranges == null) throw new ArgumentNullException(nameof(ranges));
                ThrowIfDisposed();

                int[] starts = new int[ranges.Length];
                int[] ends = new int[ranges.Length];
                for (int i = 0; i < ranges.Length; i++)
                {
                    starts[i] = ranges[i].Start;
                    ends[i] = ranges[i].End;
                }

                NativeMethods.HandleException(
                    NativeMethods.cuda_GpuMatND_opSubMat(ptr, starts, ends, ranges.Length, out var resPtr));

                GC.KeepAlive(this);
                return new GpuMatND(resPtr);
            }
        }

        /// <summary>
        /// Extracts and clones a 2D plane part of an n-dim matrix.
        /// This creates a DEEP COPY (clones the data).
        /// </summary>
        public GpuMat ToGpuMat(int[] indices, Range rowRange, Range colRange)
        {
            if (indices == null) throw new ArgumentNullException(nameof(indices));
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMatND_opIndex2D(
                    ptr, indices, indices.Length, rowRange, colRange, out var resPtr));

            GC.KeepAlive(this);
            return new GpuMat(resPtr);
        }

        /// <summary>
        /// Assigns the value of another GpuMatND to this one.
        /// This is a shallow copy; both objects will point to the same data.
        /// </summary>
        /// <param name="other">The source GpuMatND.</param>
        public void AssignFrom(GpuMatND other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            ThrowIfDisposed();
            other.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMatND_opAssign(ptr, other.ptr));

            GC.KeepAlive(this);
            GC.KeepAlive(other);
        }

        /// <summary>
        /// Decreases the reference counter and deallocates the data if needed.
        /// </summary>
        public void Release()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMatND_release(ptr));
        }

        /// <summary>
        /// Swaps with another GpuMatND.
        /// </summary>
        public void Swap(GpuMatND other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            ThrowIfDisposed();
            other.ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMatND_swap(ptr, other.ptr));
            GC.KeepAlive(this);
            GC.KeepAlive(other);
        }

        /// <summary>
        /// Returns the total number of array elements.
        /// </summary>
        public ulong Total
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_GpuMatND_total(ptr, out var ret));
                GC.KeepAlive(this);
                return (ulong)ret;
            }
        }

        /// <summary>
        /// Returns the size of underlying memory in bytes.
        /// </summary>
        public ulong TotalMemSize
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_GpuMatND_totalMemSize(ptr, out var ret));
                GC.KeepAlive(this);
                return (ulong)ret;
            }
        }

        /// <summary>
        /// Returns the element type.
        /// </summary>
        public MatType Type()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.cuda_GpuMatND_type(ptr, out int ret));
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// Performs data upload from host memory to GpuMatND.
        /// </summary>
        /// <param name="src">Source host array (Mat).</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public void Upload(OpenCvSharp.InputArray src)
        {
            if (src == null) throw new ArgumentNullException(nameof(src));
            ThrowIfDisposed();
            src.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMatND_upload(ptr, src.CvPtr));

            GC.KeepAlive(this);
            GC.KeepAlive(src);

        }

        /// <summary>
        /// Performs data upload from host memory to GpuMatND.
        /// </summary>
        /// <param name="src">Source host array (Mat).</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public void Upload(OpenCvSharp.InputArray src, Stream? stream = null)
        {
            if (src == null) 
                throw new ArgumentNullException(nameof(src));
            ThrowIfDisposed();
            src.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMatND_upload_stream(ptr, src.CvPtr, stream?.CvPtr ?? IntPtr.Zero));

            GC.KeepAlive(this);
            GC.KeepAlive(src);
            GC.KeepAlive(stream);
        }

        /// <summary>
        /// Matrix dimensionality.
        /// </summary>
        public int Dims
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_GpuMatND_getDims(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Matrix flags.
        /// </summary>
        public int Flags
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_GpuMatND_getFlags(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }
        public int[] GetSize()
        {
            ThrowIfDisposed();

            using var sizeArray = new VectorOfInt32();

            // We pass sizeArray.CvPtr. C++ receives it, and fills it with data!
            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMatND_getSize(ptr, sizeArray.CvPtr));

            GC.KeepAlive(this);
            return sizeArray.ToArray();
        }

        public ulong[] GetStep()
        {
            ThrowIfDisposed();

            using var stepArray = new VectorOfUInt64();

            NativeMethods.HandleException(
                NativeMethods.cuda_GpuMatND_getStep(ptr, stepArray.CvPtr));

            GC.KeepAlive(this);
            return stepArray.ToArray();
        }

    }
}
#endif
