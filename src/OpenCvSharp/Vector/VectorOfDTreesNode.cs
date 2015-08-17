using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;
using OpenCvSharp.ML;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    internal class VectorOfDTreesNode : DisposableCvObject, IStdVector<DTrees.Node>
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Dispose

        /// <summary>
        /// 
        /// </summary>
        public VectorOfDTreesNode()
        {
            ptr = NativeMethods.vector_DTrees_Node_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public VectorOfDTreesNode(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfDTreesNode(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException("size");
            ptr = NativeMethods.vector_DTrees_Node_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public VectorOfDTreesNode(IEnumerable<DTrees.Node> data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            DTrees.Node[] array = EnumerableEx.ToArray(data);
            ptr = NativeMethods.vector_DTrees_Node_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (IsEnabledDispose)
                    {
                        NativeMethods.vector_DTrees_Node_delete(ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get { return NativeMethods.vector_DTrees_Node_getSize(ptr).ToInt32(); }
        }

        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get { return NativeMethods.vector_DTrees_Node_getPointer(ptr); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public DTrees.Node[] ToArray()
        {
            int size = Size;
            if (size == 0)
            {
                return new DTrees.Node[0];
            }
            var dst = new DTrees.Node[size];
            using (var dstPtr = new ArrayAddress1<DTrees.Node>(dst))
            {
                Utility.CopyMemory(dstPtr, ElemPtr, Marshal.SizeOf(typeof(DTrees.Node)) * dst.Length);
            }
            return dst;
        }

        #endregion
    }
}
