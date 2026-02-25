using System.Text;

namespace OpenCvSharp.Internal;

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
            var ret = NativeMethods.string_size(ptr); 
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
            var ret = Encoding.UTF8.GetString((byte*) stringPointer, (int)Size);
            GC.KeepAlive(this);
            return ret;
        }
    }
}
