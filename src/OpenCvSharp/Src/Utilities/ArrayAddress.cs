using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#pragma warning disable 1591
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayAddress1<T> : DisposableObject
    {
        protected Array array;
        protected GCHandle gch;
        private bool disposed;
        
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
        /// <param name="array"></param>
        public ArrayAddress1(T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            this.array = array;
            this.gch = GCHandle.Alloc(array, GCHandleType.Pinned);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (gch.IsAllocated)
                {
                    gch.Free();
                }
                disposed = true;
                base.Dispose(disposing);
            }
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
    }


    /// <summary>
    /// Class to get address of specified jagged array 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayAddress2<T> : DisposableObject
        where T : struct 
    {
        private bool disposed;
        protected T[][] array;
        protected GCHandle[] gch;
        protected IntPtr[] ptr;

        /// <summary>
        /// 
        /// </summary>
        public ArrayAddress2()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        public ArrayAddress2(T[][] array)
        {
            Initialize(array);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerable"></param>
        public ArrayAddress2(IEnumerable<IEnumerable<T>> enumerable)
        {
            if (enumerable == null)
                throw new ArgumentNullException("enumerable");

            var list = new List<T[]>();
            foreach (IEnumerable<T> e in enumerable)
            {
                if(e == null)
                    throw new ArgumentException("enumerable contains null");
                list.Add( new List<T>(e).ToArray() );
            }

            Initialize(list.ToArray());
        }

        protected void Initialize(T[][] target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            array = target;

            // T[][]をIntPtr[]に変換する
            ptr = new IntPtr[array.Length];
            gch = new GCHandle[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                T[] elem = array[i];
                if (elem == null || elem.Length == 0)
                {
                    throw new ArgumentException(string.Format("array[{0}] is not valid array object.", i));
                }
                // メモリ確保
                gch[i] = GCHandle.Alloc(elem, GCHandleType.Pinned);
                ptr[i] = gch[i].AddrOfPinnedObject();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                foreach (GCHandle h in gch)
                {
                    if (h.IsAllocated)
                    {
                        h.Free();
                    }
                }
                disposed = true;
                base.Dispose(disposing);
            }
        }

#if LANG_JP
        /// <summary>
        /// ポインタを得る
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public IntPtr[] Pointer
        {
            get { return ptr; }
        }
#if LANG_JP
        /// <summary>
        /// ポインタへの暗黙のキャスト
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#endif
        public static implicit operator IntPtr[](ArrayAddress2<T> self)
        {
            return self.Pointer;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Dim1Length
        {
            get { return array.Length; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int[] Dim2Lengths
        {
            get
            {
                var lengths = new int[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    lengths[i] = array[i].Length;
                }
                return lengths;
            }
        }
    }
}