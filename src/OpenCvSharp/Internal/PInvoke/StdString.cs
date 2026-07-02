using System.Text;

namespace OpenCvSharp.Internal;

/// <inheritdoc />
/// <summary>
/// C++ std::string
/// </summary>
public class StdString : CvObject
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public StdString()
    {
        var p = NativeMethods.string_new1();
        InitSafeHandle(p);
    }
        
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <param name="str"></param>
    public StdString(string str)
    {
        if (str is null)
            throw new ArgumentNullException(nameof(str));

        var utf8Bytes = Encoding.UTF8.GetBytes(str);
        var p = NativeMethods.string_new2(utf8Bytes);
        InitSafeHandle(p);
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.string_delete(h)));
    }

    /// <summary>
    /// string.size()
    /// </summary>
    public nuint Size
    {
        get
        {
            // Passing the SafeHandle keeps this instance alive for the duration of the
            // call, so no explicit GC.KeepAlive is needed (the result is a value, not an
            // interior pointer).
            return NativeMethods.string_size(Handle);
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
            // c_str() returns an interior pointer into the std::string buffer that is
            // dereferenced by GetString below, so this instance must stay alive past the
            // call: the SafeHandle parameter alone is not enough, keep GC.KeepAlive(this).
            var stringPointer = NativeMethods.string_c_str(Handle);
            var ret = Encoding.UTF8.GetString((byte*) stringPointer, (int)Size);
            GC.KeepAlive(this);
            return ret;
        }
    }
}
