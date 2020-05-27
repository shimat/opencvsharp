using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp
{
    /// <inheritdoc cref="DisposableCvObject" />
    /// <summary>
    /// File Storage Node class
    /// </summary>
    public class FileNodeIterator : DisposableCvObject, IEquatable<FileNodeIterator?>, IEnumerator<FileNode>
    {
        /// <summary>
        /// The default constructor
        /// </summary>
        public FileNodeIterator()
        {
            NativeMethods.HandleException(
                NativeMethods.core_FileNodeIterator_new1(out ptr));
        }

        /// <summary>
        /// Initializes from cv::FileNode*
        /// </summary>
        /// <param name="ptr"></param>
        public FileNodeIterator(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.core_FileNodeIterator_delete(ptr));
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// Reads node elements to the buffer with the specified format. 
        /// Usually it is more convenient to use operator `>>` instead of this method.
        /// </summary>
        /// <param name="fmt">Specification of each array element.See @ref format_spec "format specification"</param>
        /// <param name="vec">Pointer to the destination array.</param>
        /// <param name="maxCount">Number of elements to read. If it is greater than number of remaining elements then all of them will be read.</param>
        /// <returns></returns>
        public FileNodeIterator ReadRaw(string fmt, IntPtr vec, long maxCount = int.MaxValue)
        {
            if (fmt == null)
                throw new ArgumentNullException(nameof(fmt));
            NativeMethods.HandleException(
                NativeMethods.core_FileNodeIterator_readRaw(ptr, fmt, vec, new IntPtr(maxCount)));
            GC.KeepAlive(this);
            return this;
        }      

        /// <summary>
        /// *iterator
        /// </summary>
        public FileNode Current
        {
            get
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(
                    NativeMethods.core_FileNodeIterator_operatorAsterisk(ptr, out var p));
                GC.KeepAlive(this);
                return new FileNode(p);
            }
        }

        object IEnumerator.Current => Current;
        
        /// <summary>
        /// IEnumerable&lt;T&gt;.Reset
        /// </summary>
        public void Reset()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// iterator++
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_FileNodeIterator_operatorIncrement(ptr, out var changed));
            GC.KeepAlive(this);
            return changed != 0;
        }

        /// <summary>
        /// iterator += ofs
        /// </summary>
        /// <param name="ofs"></param>
        /// <returns></returns>
        public bool MoveNext(int ofs)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.core_FileNodeIterator_operatorPlusEqual(ptr, ofs, out var changed));
            GC.KeepAlive(this);
            return changed != 0;
        }

        /// <summary>
        /// Reads node elements to the buffer with the specified format. 
        /// Usually it is more convenient to use operator `>>` instead of this method.
        /// </summary>
        /// <param name="fmt">Specification of each array element.See @ref format_spec "format specification"</param>
        /// <param name="vec">Pointer to the destination array.</param>
        /// <param name="maxCount">Number of elements to read. If it is greater than number of remaining elements then all of them will be read.</param>
        /// <returns></returns>
        public FileNodeIterator ReadRaw(string fmt, byte[] vec, long maxCount = int.MaxValue)
        {
            if (fmt == null)
                throw new ArgumentNullException(nameof(fmt));
            if (vec == null)
                throw new ArgumentNullException(nameof(vec));
            unsafe
            {
                fixed (byte* vecPtr = vec)
                {
                    NativeMethods.HandleException(
                        NativeMethods.core_FileNodeIterator_readRaw(ptr, fmt, new IntPtr(vecPtr), new IntPtr(maxCount)));
                }
            }
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="it"></param>
        /// <returns></returns>
        public bool Equals(FileNodeIterator? it)
        {
            if (it is null)
                return false;
            ThrowIfDisposed();
            it.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_FileNodeIterator_operatorEqual(ptr, it.CvPtr, out var ret));

            GC.KeepAlive(this);
            GC.KeepAlive(it);

            return ret != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="it"></param>
        /// <returns></returns>
        public long Minus(FileNodeIterator it)
        {
            if (it == null)
                throw new ArgumentNullException(nameof(it));
            ThrowIfDisposed();
            it.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_FileNodeIterator_operatorMinus(ptr, it.CvPtr, out var ret));

            GC.KeepAlive(this);
            GC.KeepAlive(it);

            return ret.ToInt64();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="it"></param>
        /// <returns></returns>
        public bool LessThan(FileNodeIterator it)
        {
            if (it == null)
                throw new ArgumentNullException(nameof(it));
            ThrowIfDisposed();
            it.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.core_FileNodeIterator_operatorLessThan(ptr, it.CvPtr, out var ret));

            GC.KeepAlive(this);
            GC.KeepAlive(it);

            return ret != 0;
        }
    }
}
