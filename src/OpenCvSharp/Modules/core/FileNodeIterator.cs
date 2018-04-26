using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// File Storage Node class
    /// </summary>
    public class FileNodeIterator : DisposableCvObject
    {
        /// <summary>
        /// The default constructor
        /// </summary>
        public FileNodeIterator()
        {
            ptr = NativeMethods.core_FileNodeIterator_new1();
        }

        /// <summary>
        /// Initializes from cv::FileNode*
        /// </summary>
        /// <param name="ptr"></param>
        public FileNodeIterator(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.core_FileNodeIterator_delete(ptr);
            base.DisposeUnmanaged();
        }


        public static bool operator==(FileNodeIterator it1, FileNodeIterator it2)
        {
            if (it1 is null)
                return it2 is null;
            if (it2 is null)
                return false;

            it1.ThrowIfDisposed();
            it2.ThrowIfDisposed();

            int ret = NativeMethods.core_FileNodeIterator_operatorEqual(it1.CvPtr, it2.CvPtr);

            GC.KeepAlive(it1);
            GC.KeepAlive(it2);

            return ret != 0;
        }

        public static bool operator!=(FileNodeIterator it1, FileNodeIterator it2)
        {
            if (it1 is null)
                return !(it2 is null);
            if (it2 is null)
                return true;

            it1.ThrowIfDisposed();
            it2.ThrowIfDisposed();

            int ret = NativeMethods.core_FileNodeIterator_operatorNotEqual(it1.CvPtr, it2.CvPtr);

            GC.KeepAlive(it1);
            GC.KeepAlive(it2);

            return ret != 0;
        }

        public static long operator-(FileNodeIterator it1, FileNodeIterator it2)
        {
            if (it1 == null)
                throw new ArgumentNullException(nameof(it1));
            if (it2 == null)
                throw new ArgumentNullException(nameof(it2));
            it1.ThrowIfDisposed();
            it2.ThrowIfDisposed();

            IntPtr ret = NativeMethods.core_FileNodeIterator_operatorMinus(it1.CvPtr, it2.CvPtr);

            GC.KeepAlive(it1);
            GC.KeepAlive(it2);

            return ret.ToInt64();
        }

        public static bool operator<(FileNodeIterator it1, FileNodeIterator it2)
        {
            if (it1 == null)
                throw new ArgumentNullException(nameof(it1));
            if (it2 == null)
                throw new ArgumentNullException(nameof(it2));
            it1.ThrowIfDisposed();
            it2.ThrowIfDisposed();

            int ret = NativeMethods.core_FileNodeIterator_operatorLessThan(it1.CvPtr, it2.CvPtr);

            GC.KeepAlive(it1);
            GC.KeepAlive(it2);

            return ret != 0;
        }

        public static bool operator >(FileNodeIterator it1, FileNodeIterator it2)
        {
            return it1 != it2 && !(it1 < it2);
        }

        #region Methods


        #endregion
    }
}
