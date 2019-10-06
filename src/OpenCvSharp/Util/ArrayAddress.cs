using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#pragma warning disable 1591
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Util
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayAddress1<T> : DisposableObject
        where T : unmanaged
    {
        protected Array array;
        protected GCHandle gch;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        public ArrayAddress1(T[] array)
        {
            this.array = array ?? throw new ArgumentNullException();
            this.gch = GCHandle.Alloc(array, GCHandleType.Pinned);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerable"></param>
        public ArrayAddress1(IEnumerable<T> enumerable)
            : this(EnumerableEx.ToArray(enumerable))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        public ArrayAddress1(T[,] array)
        {
            this.array = array ?? throw new ArgumentNullException();
            this.gch = GCHandle.Alloc(array, GCHandleType.Pinned);
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            base.DisposeManaged();
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

        /// <summary>
        /// 
        /// </summary>
        public IntPtr Pointer => gch.AddrOfPinnedObject();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static implicit operator IntPtr(ArrayAddress1<T> self)
        {
            return self.Pointer;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Length => array.Length;
    }
}