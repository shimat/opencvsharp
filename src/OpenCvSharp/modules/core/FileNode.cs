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
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.core_FileNode_delete(ptr);
            base.DisposeUnmanaged();
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
                throw new ArgumentNullException(nameof(node));
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
                throw new ArgumentNullException(nameof(node));
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
                throw new ArgumentNullException(nameof(node));
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
                throw new ArgumentNullException(nameof(node));
            var buf = new StringBuilder(1 << 16);
            NativeMethods.core_FileNode_toString(node.CvPtr, buf, buf.Capacity);
            return buf.ToString();
        }
        
        /// <summary>
        /// Returns the node content as OpenCV Mat
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static explicit operator Mat(FileNode node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            node.ThrowIfDisposed();

            var matrix = new Mat();
            NativeMethods.core_FileNode_toMat(node.CvPtr, matrix.CvPtr);
            return matrix;
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
                ThrowIfDisposed();
                if (nodeName == null)
                    throw new ArgumentNullException(nameof(nodeName));
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
                ThrowIfDisposed();
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
                ThrowIfDisposed();
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
                ThrowIfDisposed();
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
                ThrowIfDisposed();
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
                ThrowIfDisposed();
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
                ThrowIfDisposed();
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
                ThrowIfDisposed();
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
                ThrowIfDisposed();
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
                ThrowIfDisposed();
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
                ThrowIfDisposed();
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
                ThrowIfDisposed();
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
            ThrowIfDisposed();
            if (fmt == null)
                throw new ArgumentNullException(nameof(fmt));
            NativeMethods.core_FileNode_readRaw(ptr, fmt, vec, new IntPtr(len));
        }

        /// <summary>
        /// Reads the registered object and returns pointer to it
        /// </summary>
        /// <returns></returns>
        public IntPtr ReadObj()
        {
            ThrowIfDisposed();
            return NativeMethods.core_FileNode_readObj(ptr);
        }

        #region Read

        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public int ReadInt(int defaultValue = default(int))
        {
            int value;
            NativeMethods.core_FileNode_read_int(ptr, out value, defaultValue);
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public float ReadFloat(float defaultValue = default(float))
        {
            float value;
            NativeMethods.core_FileNode_read_float(ptr, out value, defaultValue);
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public double ReadDouble(double defaultValue = default(double))
        {
            double value;
            NativeMethods.core_FileNode_read_double(ptr, out value, defaultValue);
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string ReadString(string defaultValue = default(string))
        {
            var value = new StringBuilder(65536);
            NativeMethods.core_FileNode_read_String(ptr, value, value.Capacity, defaultValue);
            return value.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultMat"></param>
        /// <returns></returns>
        public Mat ReadMat(Mat defaultMat = null)
        {
            var value = new Mat();
            try
            {
                NativeMethods.core_FileNode_read_Mat(ptr, value.CvPtr, Cv2.ToPtr(defaultMat));
            }
            catch
            {
                value.Dispose();
                throw;
            }
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultMat"></param>
        /// <returns></returns>
        public SparseMat ReadSparseMat(SparseMat defaultMat = null)
        {
            var value = new SparseMat();
            try
            {
                NativeMethods.core_FileNode_read_SparseMat(ptr, value.CvPtr, Cv2.ToPtr(defaultMat));
            }
            catch
            {
                value.Dispose();
                throw;
            }
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public KeyPoint[] ReadKeyPoints()
        {
            using (var valueVector = new VectorOfKeyPoint())
            {
                NativeMethods.core_FileNode_read_vectorOfKeyPoint(ptr, valueVector.CvPtr);
                return valueVector.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DMatch[] ReadDMatches()
        {
            using (var valueVector = new VectorOfDMatch())
            {
                NativeMethods.core_FileNode_read_vectorOfDMatch(ptr, valueVector.CvPtr);
                return valueVector.ToArray();
            }
        }

        #endregion

        #endregion
    }
}
