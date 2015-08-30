using System;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// Base class for high-level OpenCV algorithms
    /// </summary>
    public abstract class Algorithm : DisposableCvObject
    {
        /// <summary>
        /// Stores algorithm parameters in a file storage
        /// </summary>
        /// <param name="fs"></param>
        public virtual void Write(FileStorage fs)
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            if (fs == null)
                throw new ArgumentNullException("fs");

            NativeMethods.core_Algorithm_write(ptr, fs.CvPtr);
        }

        /// <summary>
        /// Reads algorithm parameters from a file storage
        /// </summary>
        /// <param name="fn"></param>
        public virtual void Read(FileNode fn)
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            if (fn == null)
                throw new ArgumentNullException("fn");

            NativeMethods.core_Algorithm_read(ptr, fn.CvPtr);
        }

        /// <summary>
        /// Returns true if the Algorithm is empty (e.g. in the very beginning or after unsuccessful read
        /// </summary>
        /// <returns></returns>
        public virtual bool Empty
        {
            get
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);

                return NativeMethods.core_Algorithm_empty(ptr) != 0;
            }
        }

        /// <summary>
        /// Saves the algorithm to a file.
        /// In order to make this method work, the derived class must 
        /// implement Algorithm::write(FileStorage fs).
        /// </summary>
        /// <param name="filename"></param>
        public virtual void Save(string filename)
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            if (filename == null)
                throw new ArgumentNullException("filename");

            NativeMethods.core_Algorithm_save(ptr, filename);
        }

        /// <summary>
        /// Returns the algorithm string identifier.
        /// This string is used as top level xml/yml node tag when the object 
        /// is saved to a file or string.
        /// </summary>
        /// <returns></returns>
        public virtual String GetDefaultName()
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);

            var buf = new StringBuilder(1024);
            NativeMethods.core_Algorithm_getDefaultName(ptr, buf, buf.Capacity);
            return buf.ToString();
        }
    }
}
