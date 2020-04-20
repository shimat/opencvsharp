using System;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
    /// <inheritdoc />
    /// <summary>
    /// C++ std::string
    /// </summary>
    public class StdString : DisposableCvObject
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public StdString()
        {
            ptr = NativeMethods.string_new1();
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public StdString(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new ArgumentException("null pointer", nameof(ptr));
            this.ptr = ptr;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="str"></param>
        public StdString(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            var utf8Bytes = Encoding.UTF8.GetBytes(str);
            ptr = NativeMethods.string_new2(utf8Bytes);
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.string_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// string.size()
        /// </summary>
        public int Size
        {
            get
            {
                var ret = NativeMethods.string_size(ptr).ToInt32(); 
                GC.KeepAlive(this);
                return ret;
            }
        }

        /// <summary>
        /// Converts std::string to managed string
        /// </summary>
        /// <returns></returns>
        public new string ToString()
        {
            unsafe
            {
                var stringPointer = NativeMethods.string_c_str(ptr);
                return Encoding.UTF8.GetString((byte*) stringPointer, Size);
            }
        }
    }
}