using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// XML/YAML File Storage Class.
    /// </summary>
    public class FileStorage : DisposableCvObject
    {
        #region Init & Disposal

        /// <summary>
        /// Default constructor.
        /// You should call FileStorage::open() after initialization.
        /// </summary>
        public FileStorage()
        {
            ptr = NativeMethods.core_FileStorage_new1();
        }

        /// <summary>
        /// The full constructor
        /// </summary>
        /// <param name="source">Name of the file to open or the text string to read the data from. 
        /// Extension of the file (.xml or .yml/.yaml) determines its format 
        /// (XML or YAML respectively). Also you can append .gz to work with 
        /// compressed files, for example myHugeMatrix.xml.gz. 
        /// If both FileStorage::WRITE and FileStorage::MEMORY flags are specified, 
        /// source is used just to specify the output file format 
        /// (e.g. mydata.xml, .yml etc.).</param>
        /// <param name="flags"></param>
        /// <param name="encoding">Encoding of the file. Note that UTF-16 XML encoding is not supported 
        /// currently and you should use 8-bit encoding instead of it.</param>
        public FileStorage(string source, Mode flags, string encoding = null)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            ptr = NativeMethods.core_FileStorage_new2(source, (int)flags, encoding);
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.core_FileStorage_delete(ptr);
            base.DisposeUnmanaged();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the specified element of the top-level mapping
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public FileNode this[string nodeName]
        {
            get
            {
                ThrowIfDisposed();
                if (nodeName == null)
                    throw new ArgumentNullException(nameof(nodeName));
                IntPtr node = NativeMethods.core_FileStorage_indexer(ptr, nodeName);
                GC.KeepAlive(this);
                if (node == IntPtr.Zero)
                    return null;
                return new FileNode(node);
            }
        }

        /// <summary>
        /// the currently written element
        /// </summary>
        public string ElName
        {
            get
            {
                ThrowIfDisposed();
                unsafe
                {
                    sbyte* buf = NativeMethods.core_FileStorage_elname(ptr);
                    if (buf == null)
                        return null;
                    var res = StringHelper.PtrToStringAnsi(buf); ;
                    GC.KeepAlive(this);
                    return res;
                }
            }
        }

        /// <summary>
        /// the writer state
        /// </summary>
        public States State
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.core_FileStorage_state(ptr);
                GC.KeepAlive(this);
                return (States)res;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// operator that performs PCA. The previously stored data, if any, is released
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="flags"></param>
        /// <param name="encoding">Encoding of the file. Note that UTF-16 XML encoding is not supported 
        /// currently and you should use 8-bit encoding instead of it.</param>
        /// <returns></returns>
        public virtual bool Open(string fileName, Mode flags, string encoding = null)
        {
            ThrowIfDisposed();
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            int ret = NativeMethods.core_FileStorage_open(ptr, fileName, (int)flags, encoding);
            GC.KeepAlive(this);
            return ret != 0;
        }

        /// <summary>
        /// Returns true if the object is associated with currently opened file.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsOpened()
        {
            ThrowIfDisposed();
            var res = NativeMethods.core_FileStorage_isOpened(ptr) != 0;
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// Closes the file and releases all the memory buffers
        /// </summary>
        public virtual void Release()
        {
            ThrowIfDisposed();
            Dispose();
        }

        /// <summary>
        /// Closes the file, releases all the memory buffers and returns the text string
        /// </summary>
        /// <returns></returns>
        public string ReleaseAndGetString()
        {
            ThrowIfDisposed();
            var buf = new StringBuilder(1 << 16);
            NativeMethods.core_FileStorage_releaseAndGetString(ptr, buf, buf.Capacity);
            ptr = IntPtr.Zero;
            Dispose();
            return buf.ToString();
        }

        /// <summary>
        /// Returns the first element of the top-level mapping
        /// </summary>
        /// <returns></returns>
        public FileNode GetFirstTopLevelNode()
        {
            ThrowIfDisposed();
            IntPtr node = NativeMethods.core_FileStorage_getFirstTopLevelNode(ptr);
            GC.KeepAlive(this);
            if (node == IntPtr.Zero)
                return null;
            return new FileNode(node);
        }

        /// <summary>
        /// Returns the top-level mapping. YAML supports multiple streams
        /// </summary>
        /// <param name="streamidx"></param>
        /// <returns></returns>
        public FileNode Root(int streamidx = 0)
        {
            ThrowIfDisposed();
            IntPtr node = NativeMethods.core_FileStorage_root(ptr, streamidx);
            GC.KeepAlive(this);
            if (node == IntPtr.Zero)
                return null;
            return new FileNode(node);
        }

        /// <summary>
        /// Writes one or more numbers of the specified format to the currently written structure
        /// </summary>
        /// <param name="fmt"></param>
        /// <param name="vec"></param>
        /// <param name="len"></param>
        public void WriteRaw(string fmt, IntPtr vec, long len)
        {
            ThrowIfDisposed();
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="flags"></param>
        /// <param name="typeName"></param>
        public void StartWriteStruct(string name, int flags, string typeName)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_startWriteStruct(ptr, name, flags, typeName);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public void EndWriteStruct()
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_endWriteStruct(ptr);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Returns the normalized object name for the specified file name
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetDefaultObjectName(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);

            var buf = new StringBuilder(1 << 16);
            NativeMethods.core_FileStorage_getDefaultObjectName(fileName, buf, buf.Capacity);
            return buf.ToString();
        }

        #region Write

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Write(string name, int value)
        {
            ThrowIfDisposed();
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            NativeMethods.core_FileStorage_write_int(ptr, name, value);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Write(string name, float value)
        {
            ThrowIfDisposed();
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            NativeMethods.core_FileStorage_write_float(ptr, name, value);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Write(string name, double value)
        {
            ThrowIfDisposed();
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            NativeMethods.core_FileStorage_write_double(ptr, name, value);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Write(string name, string value)
        {
            ThrowIfDisposed();
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            NativeMethods.core_FileStorage_write_String(ptr, name, value);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Write(string name, Mat value)
        {
            ThrowIfDisposed();
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            NativeMethods.core_FileStorage_write_Mat(ptr, name, value.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Write(string name, SparseMat value)
        {
            ThrowIfDisposed();
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            NativeMethods.core_FileStorage_write_SparseMat(ptr, name, value.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Write(string name, IEnumerable<KeyPoint> value)
        {
            ThrowIfDisposed();
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            using (var valueVector = new VectorOfKeyPoint(value))
            {
                NativeMethods.core_FileStorage_write_vectorOfKeyPoint(ptr, name, valueVector.CvPtr);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Write(string name, IEnumerable<DMatch> value)
        {
            ThrowIfDisposed();
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            using (var valueVector = new VectorOfDMatch(value))
            {
                NativeMethods.core_FileStorage_write_vectorOfDMatch(ptr, name, valueVector.CvPtr);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteScalar(int value)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_writeScalar_int(ptr, value);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteScalar(float value)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_writeScalar_float(ptr, value);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteScalar(double value)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_writeScalar_double(ptr, value);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteScalar(string value)
        {
            ThrowIfDisposed();
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            NativeMethods.core_FileStorage_writeScalar_String(ptr, value);
            GC.KeepAlive(this);
        }

        #endregion

        #region Add

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(string val)
        {
            if (val == null)
                throw new ArgumentNullException(nameof(val));
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_String(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(int val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_int(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(float val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_float(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(double val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_double(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Mat val)
        {
            if (val == null)
                throw new ArgumentNullException(nameof(val));
            ThrowIfDisposed();
            val.ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Mat(ptr, val.CvPtr);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(SparseMat val)
        {
            if (val == null)
                throw new ArgumentNullException(nameof(val));
            ThrowIfDisposed();
            val.ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_SparseMat(ptr, val.CvPtr);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Range val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Range(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(KeyPoint val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_KeyPoint(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(DMatch val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_DMatch(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(IEnumerable<KeyPoint> val)
        {
            if (val == null)
                throw new ArgumentNullException(nameof(val));
            ThrowIfDisposed();
            using (var valVec = new VectorOfKeyPoint(val))
            {
                NativeMethods.core_FileStorage_shift_vectorOfKeyPoint(ptr, valVec.CvPtr);
            }
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(IEnumerable<DMatch> val)
        {
            if (val == null)
                throw new ArgumentNullException(nameof(val));
            ThrowIfDisposed();
            using (var valVec = new VectorOfDMatch(val))
            {
                NativeMethods.core_FileStorage_shift_vectorOfDMatch(ptr, valVec.CvPtr);
            }
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// /Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Point val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Point2i(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Point2f val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Point2f(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Point2d val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Point2d(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Point3i val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Point3i(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Point3f val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Point3f(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Point3d val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Point3d(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Size val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Size2i(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Size2f val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Size2f(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Size2d val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Size2d(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Rect val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Rect2i(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Rect2f val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Rect2f(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Rect2d val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Rect2d(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Scalar val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Scalar(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec2i val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec2i(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec3i val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec3i(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec4i val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec4i(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec6i val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec6i(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec2d val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec2d(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec3d val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec3d(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec4d val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec4d(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec6d val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec6d(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec2f val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec2f(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec3f val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec3f(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec4f val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec4f(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec6f val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec6f(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec2b val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec2b(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec3b val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec3b(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec4b val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec4b(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec6b val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec6b(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec2s val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec2s(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec3s val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec3s(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec4s val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec4s(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec6s val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec6s(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec2w val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec2w(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec3w val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec3w(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec4w val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec4w(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        /// <summary>
        /// Writes data to a file storage.
        /// </summary>
        /// <param name="val"></param>
        public FileStorage Add(Vec6w val)
        {
            ThrowIfDisposed();
            NativeMethods.core_FileStorage_shift_Vec6w(ptr, val);
            GC.KeepAlive(this);
            return this;
        }

        #endregion

        #endregion

        /// <summary>
        /// 
        /// </summary>
        [Flags]
        public enum States
        {
            /// <summary>
            /// 
            /// </summary>
            Undefined = 0,
            
            /// <summary>
            /// 
            /// </summary>
            ValueExpected = 1,

            /// <summary>
            /// 
            /// </summary>
            NameExpected = 2,

            /// <summary>
            /// 
            /// </summary>
            InsideMap = 4
        }

#if LANG_JP
    /// <summary>
    /// FileStorageのモード
    /// </summary>
#else
        /// <summary>
        /// File storage mode
        /// </summary>
#endif
        [Flags]
        public enum Mode 
        {
#if LANG_JP
        /// <summary>
        /// データ読み込みのためのファイルオープン 
        /// </summary>
#else
            /// <summary>
            /// The storage is open for reading
            /// </summary>
#endif
            Read = 0,

#if LANG_JP
        /// <summary>
        /// データ書き込みのためのファイルオープン 
        /// </summary>
#else
            /// <summary>
            /// The storage is open for writing
            /// </summary>
#endif
            Write = 1,

#if LANG_JP
        /// <summary>
        /// データ追加書き込みのためのファイルオープン 
        /// </summary>
#else
            /// <summary>
            /// The storage is open for appending
            /// </summary>
#endif
            Append = 2,

            /// <summary>
            /// flag, read data from source or write data to the internal buffer
            /// (which is returned by FileStorage::release)
            /// </summary>
            Memory = 4,

            /// <summary>
            /// mask for format flags
            /// </summary>
            FotmatMask = (7 << 3),

            /// <summary>
            /// flag, auto format
            /// </summary>
            FormatAuto = 0,

            /// <summary>
            /// flag, XML format
            /// </summary>
            FormatXml = (1 << 3),

            /// <summary>
            /// flag, YAML format
            /// </summary>
            FormatYaml = (2 << 3),
        }
    }
}
