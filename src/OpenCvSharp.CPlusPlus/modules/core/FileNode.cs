using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// File Storage Node class
    /// </summary>
    public class FileNode : DisposableCvObject
    {
        private bool disposed;

        #region Init & Disposal

        /// <summary>
        /// The default constructor
        /// </summary>
        public FileNode()
        {
            ptr = NativeMethods.core_FileNode_new1();
        }

        /// <summary>
        /// Initializes from cv::FileNode*
        /// </summary>
        /// <param name="ptr"></param>
        public FileNode(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (ptr != IntPtr.Zero)
                    {
                        NativeMethods.core_FileNode_delete(ptr);
                        ptr = IntPtr.Zero;
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

        #region Cast

        /// <summary>
        /// Returns the node content as an integer. If the node stores floating-point number, it is rounded.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static explicit operator int(FileNode node)
        {
            if (node == null)
                throw new ArgumentNullException("node");
            return NativeMethods.core_FileNode_toInt(node.CvPtr);
        }

        /// <summary>
        /// Returns the node content as float
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static explicit operator float(FileNode node)
        {
            if (node == null)
                throw new ArgumentNullException("node");
            return NativeMethods.core_FileNode_toFloat(node.CvPtr);
        }

        /// <summary>
        /// Returns the node content as double
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static explicit operator double(FileNode node)
        {
            if (node == null)
                throw new ArgumentNullException("node");
            return NativeMethods.core_FileNode_toDouble(node.CvPtr);
        }

        /// <summary>
        /// Returns the node content as text string
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static explicit operator string(FileNode node)
        {
            if (node == null)
                throw new ArgumentNullException("node");
            var buf = new StringBuilder(1 << 16);
            NativeMethods.core_FileNode_toString(node.CvPtr, buf, buf.Capacity);
            return buf.ToString();
        }

        #endregion

        #region Properties

        /// <summary>
        /// returns element of a mapping node
        /// </summary>
        public FileNode this[string nodeName]
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("FileNode");
                if (nodeName == null)
                    throw new ArgumentNullException("nodeName");
                IntPtr node = NativeMethods.core_FileNode_operatorThis_byString(ptr, nodeName);
                if (node == IntPtr.Zero)
                    return null;
                return new FileNode(node);
            }
        }

        /// <summary>
        /// returns element of a sequence node
        /// </summary>
        public FileNode this[int i]
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("FileNode");
                IntPtr node = NativeMethods.core_FileNode_operatorThis_byInt(ptr, i);
                if (node == IntPtr.Zero)
                    return null;
                return new FileNode(node);
            }
        }

        /// <summary>
        /// Returns true if the node is empty
        /// </summary>
        /// <returns></returns>
        public bool Empty
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("FileStorage");
                int ret = NativeMethods.core_FileNode_empty(ptr);
                return ret != 0;
            }
        }

        /// <summary>
        /// Returns true if the node is a "none" object
        /// </summary>
        /// <returns></returns>
        public bool IsNone
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("FileStorage");
                int ret = NativeMethods.core_FileNode_isNone(ptr);
                return ret != 0;
            }
        }

        /// <summary>
        /// Returns true if the node is a sequence
        /// </summary>
        /// <returns></returns>
        public bool IsSeq
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("FileStorage");
                int ret = NativeMethods.core_FileNode_isSeq(ptr);
                return ret != 0;
            }
        }

        /// <summary>
        /// Returns true if the node is a mapping
        /// </summary>
        /// <returns></returns>
        public bool IsMap
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("FileStorage");
                int ret = NativeMethods.core_FileNode_isMap(ptr);
                return ret != 0;
            }
        }

        /// <summary>
        /// Returns true if the node is an integer
        /// </summary>
        /// <returns></returns>
        public bool IsInt
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("FileStorage");
                int ret = NativeMethods.core_FileNode_isInt(ptr);
                return ret != 0;
            }
        }

        /// <summary>
        /// Returns true if the node is a floating-point number
        /// </summary>
        /// <returns></returns>
        public bool IsReal
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("FileStorage");
                int ret = NativeMethods.core_FileNode_isReal(ptr);
                return ret != 0;
            }
        }

        /// <summary>
        /// Returns true if the node is a text string
        /// </summary>
        /// <returns></returns>
        public bool IsString
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("FileStorage");
                int ret = NativeMethods.core_FileNode_isString(ptr);
                return ret != 0;
            }
        }

        /// <summary>
        /// Returns true if the node has a name
        /// </summary>
        /// <returns></returns>
        public bool IsNamed
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("FileStorage");
                int ret = NativeMethods.core_FileNode_isNamed(ptr);
                return ret != 0;
            }
        }

        /// <summary>
        /// Returns the node name or an empty string if the node is nameless
        /// </summary>
        /// <returns></returns>
        public string Name
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("FileStorage");
                var buf = new StringBuilder(1024);
                NativeMethods.core_FileNode_name(ptr, buf, buf.Capacity);
                return buf.ToString();
            }
        }

        /// <summary>
        /// Returns the number of elements in the node, if it is a sequence or mapping, or 1 otherwise.
        /// </summary>
        /// <returns></returns>
        public long Size
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("FileStorage");
                return NativeMethods.core_FileNode_size(ptr).ToInt64();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Reads node elements to the buffer with the specified format
        /// </summary>
        /// <param name="fmt"></param>
        /// <param name="vec"></param>
        /// <param name="len"></param>
        public void ReadRaw(string fmt, IntPtr vec, long len)
        {
            if (disposed)
                throw new ObjectDisposedException("FileNode");
            if (fmt == null)
                throw new ArgumentNullException("fmt");
            NativeMethods.core_FileNode_readRaw(ptr, fmt, vec, new IntPtr(len));
        }

        /// <summary>
        /// Reads the registered object and returns pointer to it
        /// </summary>
        /// <returns></returns>
        public IntPtr ReadObj()
        {
            if (disposed)
                throw new ObjectDisposedException("FileNode");
            return NativeMethods.core_FileNode_readObj(ptr);
        }

        #endregion
    }
}
