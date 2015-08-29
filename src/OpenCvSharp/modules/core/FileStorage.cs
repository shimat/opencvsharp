using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// XML/YAML File Storage Class.
    /// </summary>
    public class FileStorage : DisposableCvObject
    {
        private bool disposed;

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
                throw new ArgumentNullException("source");
            ptr = NativeMethods.core_FileStorage_new2(source, (int)flags, encoding);
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
                        NativeMethods.core_FileStorage_delete(ptr);
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
                if (disposed)
                    throw new ObjectDisposedException("FileStorage");
                if (nodeName == null)
                    throw new ArgumentNullException("nodeName");
                IntPtr node = NativeMethods.core_FileStorage_indexer(ptr, nodeName);
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
                if (disposed)
                    throw new ObjectDisposedException("FileStorage");
                unsafe
                {
                    sbyte* buf = NativeMethods.core_FileStorage_elname(ptr);
                    if (buf == null)
                        return null;
                    return new string(buf);
                }
            }
        }

        /// <summary>
        /// the stack of written structures
        /// </summary>
        public byte[] Structs
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("FileStorage");

                IntPtr length;
                IntPtr buf = NativeMethods.core_FileStorage_structs(ptr, out length);
                byte[] result = new byte[length.ToInt32()];
                Marshal.Copy(buf, result, 0, result.Length);
                return result;
            }
        }

        /// <summary>
        /// the writer state
        /// </summary>
        public int State
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException("FileStorage");
                return NativeMethods.core_FileStorage_state(ptr);
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
            if (disposed)
                throw new ObjectDisposedException("FileStorage");
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            int ret = NativeMethods.core_FileStorage_open(ptr, fileName, (int)flags, encoding);
            return ret != 0;
        }

        /// <summary>
        /// Returns true if the object is associated with currently opened file.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsOpened()
        {
            if (disposed)
                throw new ObjectDisposedException("FileStorage");
            return NativeMethods.core_FileStorage_isOpened(ptr) != 0;
        }

        /// <summary>
        /// Closes the file and releases all the memory buffers
        /// </summary>
        public virtual void Release()
        {
            if (disposed)
                throw new ObjectDisposedException("FileStorage");
            Dispose();
        }

        /// <summary>
        /// Closes the file, releases all the memory buffers and returns the text string
        /// </summary>
        /// <returns></returns>
        public string ReleaseAndGetString()
        {
            if (disposed)
                throw new ObjectDisposedException("FileStorage");
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
            if (disposed)
                throw new ObjectDisposedException("FileStorage");
            IntPtr node = NativeMethods.core_FileStorage_getFirstTopLevelNode(ptr);
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
            if (disposed)
                throw new ObjectDisposedException("FileStorage");
            IntPtr node = NativeMethods.core_FileStorage_root(ptr, streamidx);
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
            if (disposed)
                throw new ObjectDisposedException("FileStorage");
        }

        /// <summary>
        /// Writes the registered C structure (CvMat, CvMatND, CvSeq). See cvWrite()
        /// </summary>
        /// <param name="name"></param>
        /// <param name="obj"></param>
        public void WriteObj(string name, IntPtr obj)
        {
            if (disposed)
                throw new ObjectDisposedException("FileStorage");
            if (name == null)
                throw new ArgumentNullException("name");
            NativeMethods.core_FileStorage_writeObj(ptr, name, obj);
        }

        /// <summary>
        /// Returns the normalized object name for the specified file name
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetDefaultObjectName(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            if (!File.Exists(fileName))
                throw new FileNotFoundException("", fileName);

            var buf = new StringBuilder(1 << 16);
            NativeMethods.core_FileStorage_getDefaultObjectName(fileName, buf, buf.Capacity);
            return buf.ToString();
        }

        #endregion

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
        /// [CV_STORAGE_WRITE]
        /// </summary>
#else
            /// <summary>
            /// The storage is open for writing
            /// [CV_STORAGE_WRITE]
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
