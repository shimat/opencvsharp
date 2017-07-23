using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// C++ std::string
    /// </summary>
    public class StdString : DisposableCvObject
    {
        /// <summary>
        /// 
        /// </summary>
        public StdString()
        {
            ptr = NativeMethods.string_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public StdString(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            ptr = NativeMethods.string_new2(str);
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
        public int Size => NativeMethods.string_size(ptr).ToInt32();

        /// <summary>
        /// Converts std::string to managed string
        /// </summary>
        /// <returns></returns>
        public new string ToString()
        {
            unsafe
            {
                sbyte* stringPointer = NativeMethods.string_c_str(ptr);
#if DOTNET_FRAMEWORK
                return new string(stringPointer);
#else
                return Marshal.PtrToStringUni(new IntPtr(stringPointer));
#endif
            }
        }
    }
}
