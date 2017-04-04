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
    {
        protected Array array;
        protected GCHandle gch;
        protected object original;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        public ArrayAddress1(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            this.array = array;
            this.gch = GCHandle.Alloc(array, GCHandleType.Pinned);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerable"></param>
        public ArrayAddress1(IEnumerable<T> enumerable)
            : this(EnumerableEx.ToArray(enumerable))
        {
            original = enumerable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        public ArrayAddress1(T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            this.array = array;
            this.gch = GCHandle.Alloc(array, GCHandleType.Pinned);
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            original = null;
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
        public IntPtr Pointer
        {
            get { return gch.AddrOfPinnedObject(); }
        }

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
        public int Length
        {
            get { return array.Length; }
        }
    }
}