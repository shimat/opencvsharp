using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>
/// TrueType font face used by the FontFace-based <see cref="Cv2.PutText(InputOutputArray, string, Point, Scalar, FontFace, int, int, PutTextFlags, OpenCvSharp.Range?)"/>
/// and <see cref="Cv2.GetTextSize(Size, string, Point, FontFace, int, int, PutTextFlags, OpenCvSharp.Range?)"/> (OpenCV 5).
/// </summary>
public class FontFace : CvObject
{
    /// <summary>
    /// Loads the default embedded font.
    /// </summary>
    public FontFace()
    {
        NativeMethods.HandleException(
            NativeMethods.imgproc_FontFace_new1(out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(FontFace)}");
        InitSafeHandle(p);
    }

    /// <summary>
    /// Loads the font at the specified path or with the specified embedded name.
    /// </summary>
    /// <param name="fontPathOrName">Either a path to a custom font or the name of an embedded font
    /// ("sans", "italic" or "uni"). An empty string means the default embedded font.</param>
    public FontFace(string fontPathOrName)
    {
        if (fontPathOrName is null)
            throw new ArgumentNullException(nameof(fontPathOrName));
        NativeMethods.HandleException(
            NativeMethods.imgproc_FontFace_new2(fontPathOrName, out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(FontFace)}");
        InitSafeHandle(p);
    }

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.imgproc_FontFace_delete(h))));
    }

    /// <summary>
    /// Loads a new font face.
    /// </summary>
    /// <param name="fontPathOrName">Either a path to a custom font or the name of an embedded font.</param>
    /// <returns>True on success.</returns>
    public bool Set(string fontPathOrName)
    {
        if (fontPathOrName is null)
            throw new ArgumentNullException(nameof(fontPathOrName));
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.imgproc_FontFace_set(CvPtr, fontPathOrName, out var ret));
        GC.KeepAlive(this);
        return ret != 0;
    }

    /// <summary>
    /// Gets the current font name.
    /// </summary>
    public string Name
    {
        get
        {
            ThrowIfDisposed();
            using var stdString = new StdString();
            NativeMethods.HandleException(
                NativeMethods.imgproc_FontFace_getName(CvPtr, stdString.CvPtr));
            GC.KeepAlive(this);
            return stdString.ToString();
        }
    }

    /// <summary>
    /// Sets the current variable-font instance.
    /// </summary>
    /// <param name="params">The list of pairs key1, value1, key2, value2, ... Values are in 16.16 fixed-point
    /// format (integer values must be shifted left by 16, i.e. multiplied by 65536).</param>
    /// <returns>True on success.</returns>
    public bool SetInstance(int[] @params)
    {
        if (@params is null)
            throw new ArgumentNullException(nameof(@params));
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.imgproc_FontFace_setInstance(CvPtr, @params, @params.Length, out var ret));
        GC.KeepAlive(this);
        return ret != 0;
    }

    /// <summary>
    /// Gets the current variable-font instance parameters.
    /// </summary>
    /// <param name="params">Output list of key/value pairs.</param>
    /// <returns>True on success.</returns>
    public bool GetInstance(out int[] @params)
    {
        ThrowIfDisposed();

        using var vec = new VectorOfInt32();
        NativeMethods.HandleException(
            NativeMethods.imgproc_FontFace_getInstance(CvPtr, vec.CvPtr, out var ret));
        GC.KeepAlive(this);
        @params = vec.ToArray();
        return ret != 0;
    }
}
