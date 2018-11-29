using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// File Storage Node class
    /// </summary>
    public class FileNode : DisposableCvObject, IEnumerable<FileNode>
    {
        // ReSharper disable InconsistentNaming

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
            var res = NativeMethods.core_FileNode_toInt(node.CvPtr);
            GC.KeepAlive(node);
            return res;
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
            var res = NativeMethods.core_FileNode_toFloat(node.CvPtr);
            GC.KeepAlive(node);
            return res;
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
            var res = NativeMethods.core_FileNode_toDouble(node.CvPtr);
            GC.KeepAlive(node);
            return res;
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
            GC.KeepAlive(node);
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
            GC.KeepAlive(node);
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
                GC.KeepAlive(this);
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
                GC.KeepAlive(this);
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
                GC.KeepAlive(this);
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
                GC.KeepAlive(this);
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
                GC.KeepAlive(this);
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
                GC.KeepAlive(this);
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
                GC.KeepAlive(this);
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
                GC.KeepAlive(this);
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
                GC.KeepAlive(this);
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
                GC.KeepAlive(this);
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
                GC.KeepAlive(this);
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
                var res = NativeMethods.core_FileNode_size(ptr).ToInt64();
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Returns type of the node.
        /// </summary>
        /// <returns>Type of the node.</returns>
        public Types Type
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.core_FileNode_type(ptr);
                GC.KeepAlive(this);
                return (Types)res;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// returns iterator pointing to the first node element
        /// </summary>
        /// <returns></returns>
        public FileNodeIterator Begin()
        {
            ThrowIfDisposed();
            IntPtr p = NativeMethods.core_FileNode_begin(ptr);
            GC.KeepAlive(this);
            return new FileNodeIterator(p);
        }
        //! 
        /// <summary>
        /// returns iterator pointing to the element following the last node element
        /// </summary>
        /// <returns></returns>
        public FileNodeIterator End()
        {
            ThrowIfDisposed();
            IntPtr p = NativeMethods.core_FileNode_end(ptr);
            GC.KeepAlive(this);
            return new FileNodeIterator(p);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<FileNode> GetEnumerator()
        {
            using (FileNodeIterator it = Begin(), end = End())
            {
                for (; !it.Equals(end); it.MoveNext())
                {
                    yield return it.Current;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

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
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Writes a comment.
        /// The function writes a comment into file storage.The comments are skipped when the storage is read.
        /// </summary>
        /// <param name="comment">The written comment, single-line or multi-line</param>
        /// <param name="append">If true, the function tries to put the comment at the end of current line.
        /// Else if the comment is multi-line, or if it does not fit at the end of the current line, the comment starts a new line.</param>
        public void WriteComment(string comment, bool append = false)
        {
            ThrowIfDisposed();
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));
            NativeMethods.core_FileStorage_writeComment(ptr, comment, append ? 1 : 0);
            GC.KeepAlive(this);
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
            GC.KeepAlive(this);
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
            GC.KeepAlive(this);
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
            GC.KeepAlive(this);
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
            GC.KeepAlive(this);
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
                GC.KeepAlive(this);
                GC.KeepAlive(defaultMat);
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
                GC.KeepAlive(this);
                GC.KeepAlive(defaultMat);
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
                GC.KeepAlive(this);
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
                GC.KeepAlive(this);
                return valueVector.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Range ReadRange()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Range(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public KeyPoint ReadKeyPoint()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_KeyPoint(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DMatch ReadDMatch()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_DMatch(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Point ReadPoint()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Point2i(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Point2f ReadPoint2f()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Point2f(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Point2d ReadPoint2d()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Point2d(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Point3i ReadPoint3i()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Point3i(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Point3f ReadPoint3f()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Point3f(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Point3d ReadPoint3d()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Point3d(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Size ReadSize()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Size2i(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Size2f ReadSize2f()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Size2f(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Size2d ReadSize2d()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Size2d(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Rect ReadRect()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Rect2i(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Rect2f ReadRect2f()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Rect2f(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Rect2d ReadRect2d()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Rect2d(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Scalar ReadScalar()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Scalar(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec2i ReadVec2i()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec2i(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec3i ReadVec3i()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec3i(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec4i ReadVec4i()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec4i(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec6i ReadVec6i()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec6i(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec2d ReadVec2d()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec2d(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec3d ReadVec3d()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec3d(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec4d ReadVec4d()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec4d(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec6d ReadVec6d()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec6d(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec2f ReadVec2f()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec2f(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec3f ReadVec3f()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec3f(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec4f ReadVec4f()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec4f(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec6f ReadVec6f()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec6f(ptr);
            GC.KeepAlive(this);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec2b ReadVec2b()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec2b(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec3b ReadVec3b()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec3b(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec4b ReadVec4b()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec4b(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec6b ReadVec6b()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec6b(ptr);
            GC.KeepAlive(this);
            return ret;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec2s ReadVec2s()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec2s(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec3s ReadVec3s()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec3s(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec4s ReadVec4s()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec4s(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec6s ReadVec6s()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec6s(ptr);
            GC.KeepAlive(this);
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec2w ReadVec2w()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec2w(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec3w ReadVec3w()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec3w(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec4w ReadVec4w()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec4w(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec6w ReadVec6w()
        {
            ThrowIfDisposed();
            var ret = NativeMethods.core_FileNode_read_Vec6w(ptr);
            GC.KeepAlive(this);
            return ret;
        }

        #endregion

        #endregion

        /// <summary>
        /// type of the file storage node
        /// </summary>
        [Flags]
        public enum Types
        {
            /// <summary>
            /// empty node
            /// </summary>
            None = 0,

            /// <summary>
            /// an integer
            /// </summary>
            Int = 1,

            /// <summary>
            /// floating-point number
            /// </summary>
            Real = 2,

            /// <summary>
            /// synonym or REAL
            /// </summary>
            Float = Real,

            /// <summary>
            /// text string in UTF-8 encoding
            /// </summary>
            Str = 3,

            /// <summary>
            /// synonym for STR
            /// </summary>
            String = Str,

            /// <summary>
            /// sequence
            /// </summary>
            Seq = 4,

            /// <summary>
            /// mapping
            /// </summary>
            Map = 5, 

            /// <summary>
            /// 
            /// </summary>
            TypeMask = 7,

            /// <summary>
            /// compact representation of a sequence or mapping. Used only by YAML writer
            /// </summary>
            Flow = 8,

            /// <summary>
            /// if set, means that all the collection elements are numbers of the same type (real's or int's).
            /// UNIFORM is used only when reading FileStorage; FLOW is used only when writing. So they share the same bit
            /// </summary>
            Uniform = 8,  

            /// <summary>
            /// empty structure (sequence or mapping)
            /// </summary>
            Empty = 16,

            /// <summary>
            /// the node has a name (i.e. it is element of a mapping)
            /// </summary>
            Named = 32,
        }
    }
}
