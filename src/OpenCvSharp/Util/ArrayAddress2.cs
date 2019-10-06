using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Util
{
    /// <summary>
    /// Class to get address of specified jagged array 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayAddress2<T> : DisposableObject
        where T : unmanaged
    {
        private readonly T[][] array;
        private readonly GCHandle[] gch;
        private readonly IntPtr[] ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        public ArrayAddress2(T[][] array)
        {
            this.array = array ?? throw new ArgumentNullException(nameof(array));

            // T[][]をIntPtr[]に変換する
            ptr = new IntPtr[array.Length];
            gch = new GCHandle[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                T[] elem = array[i];
                if (elem == null/* || elem.Length == 0*/)
                    throw new ArgumentException(string.Format("array[{0}] is not valid array object.", i));
                
                // メモリ確保
                gch[i] = GCHandle.Alloc(elem, GCHandleType.Pinned);
                ptr[i] = gch[i].AddrOfPinnedObject();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerable"></param>
        public ArrayAddress2(IEnumerable<IEnumerable<T>> enumerable)
            : this(EnumerableEx.SelectToArray(enumerable, EnumerableEx.ToArray))
        {
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            foreach (GCHandle h in gch)
            {
                if (h.IsAllocated)
                {
                    h.Free();
                }
            }
            base.DisposeUnmanaged();
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