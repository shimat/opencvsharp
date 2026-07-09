using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

static partial class Cv2
{
    /// <summary>
    /// Loads an image from a file.
    /// </summary>
    /// <param name="fileName">Name of file to be loaded.</param>
    /// <param name="flags">Specifies color type of the loaded image</param>
    /// <returns></returns>
    public static Mat ImRead(string fileName, ImreadModes flags = ImreadModes.Color)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentNullException(nameof(fileName));

        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imread(fileName, (int) flags, out var ret));
        if (ret == IntPtr.Zero)
            throw new OpenCvSharpException("imread failed.");
        return Mat.FromNativePointer(ret);
    }

    /// <summary>
    /// Loads a multi-page image from a file. 
    /// </summary>
    /// <param name="filename">Name of file to be loaded.</param>
    /// <param name="mats">A vector of Mat objects holding each page, if more than one.</param>
    /// <param name="flags">Flag that can take values of @ref cv::ImreadModes, default with IMREAD_ANYCOLOR.</param>
    /// <returns></returns>
    public static bool ImReadMulti(string filename, out Mat[] mats, ImreadModes flags = ImreadModes.AnyColor)
    {
        ArgumentNullException.ThrowIfNull(filename);

        using var matsVec = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imreadmulti(filename, matsVec.CvPtr, (int) flags, out var ret));
        mats = matsVec.ToArray();
        return ret != 0;
    }

    /// <summary>
    /// Loads a specified range of pages from a multi-page image from a file.
    /// </summary>
    /// <param name="filename">Name of file to be loaded.</param>
    /// <param name="mats">A vector of Mat objects holding each page.</param>
    /// <param name="start">Start index of the image to load.</param>
    /// <param name="count">Count number of images to load.</param>
    /// <param name="flags">Flag that can take values of @ref cv::ImreadModes, default with IMREAD_ANYCOLOR.</param>
    /// <returns></returns>
    public static bool ImReadMulti(string filename, out Mat[] mats, int start, int count, ImreadModes flags = ImreadModes.AnyColor)
    {
        ArgumentNullException.ThrowIfNull(filename);

        using var matsVec = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imreadmulti_range(filename, matsVec.CvPtr, start, count, (int) flags, out var ret));
        mats = matsVec.ToArray();
        return ret != 0;
    }

    /// <summary>
    /// Returns the number of images inside the given file.
    /// The function returns the number of pages in a multi-page image (e.g. TIFF), the number of frames
    /// in an animation (e.g. AVIF), and 1 otherwise. If the image cannot be decoded, 0 is returned.
    /// </summary>
    /// <param name="filename">Name of file to be loaded.</param>
    /// <param name="flags">Flag that can take values of @ref cv::ImreadModes, default with IMREAD_COLOR.</param>
    /// <returns></returns>
    public static long ImCount(string filename, ImreadModes flags = ImreadModes.Color)
    {
        ArgumentNullException.ThrowIfNull(filename);

        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imcount(filename, (int) flags, out var ret));
        return ret.ToInt64();
    }

    /// <summary>
    /// Reads an image from a file along with associated metadata (EXIF, XMP, etc.), depending on file format support.
    /// </summary>
    /// <param name="filename">Name of the file to be loaded.</param>
    /// <param name="metadataTypes">Output array with types of metadata chunks returned in metadata.</param>
    /// <param name="metadata">Output array of matrices to store the retrieved metadata.</param>
    /// <param name="flags">Flag that can take values of @ref cv::ImreadModes.</param>
    /// <returns>The loaded image. If the image cannot be read, the function returns an empty matrix.</returns>
    public static Mat ImReadWithMetadata(string filename, out ImageMetadataType[] metadataTypes, out Mat[] metadata, ImreadModes flags = ImreadModes.Color)
    {
        ArgumentNullException.ThrowIfNull(filename);

        using var metadataTypesVec = new StdVector<int>();
        using var metadataVec = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imreadWithMetadata(filename, metadataTypesVec.CvPtr, metadataVec.CvPtr, (int) flags, out var ret));
        metadataTypes = Array.ConvertAll(metadataTypesVec.ToArray(), t => (ImageMetadataType) t);
        metadata = metadataVec.ToArray();
        return new Mat(ret);
    }

    /// <summary>
    /// Saves an image to a specified file, additionally writing metadata if the corresponding format supports it.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <param name="img">Image to be saved.</param>
    /// <param name="metadataTypes">Array with types of metadata chunks stored in metadata to write.</param>
    /// <param name="metadata">Array of matrices with chunks of metadata to store into the file.</param>
    /// <param name="prms">Format-specific save parameters encoded as pairs</param>
    /// <returns></returns>
    public static bool ImWriteWithMetadata(
        string fileName, Mat img, ImageMetadataType[] metadataTypes, IEnumerable<Mat> metadata, int[]? prms = null)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentNullException(nameof(fileName));
        ArgumentNullException.ThrowIfNull(img);
        ArgumentNullException.ThrowIfNull(metadataTypes);
        ArgumentNullException.ThrowIfNull(metadata);
        prms ??= [];

        using var metadataVec = new VectorOfMat(metadata);
        var metadataTypesInt = Array.ConvertAll(metadataTypes, t => (int) t);
        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imwriteWithMetadata(
                fileName, img.CvPtr, metadataTypesInt, metadataTypesInt.Length, metadataVec.CvPtr, prms, prms.Length, out var ret));
        GC.KeepAlive(img);
        return ret != 0;
    }

    /// <summary>
    /// Loads frames from an animated image file (e.g., GIF, AVIF, APNG, WEBP) into the provided Animation object.
    /// </summary>
    /// <param name="filename">A string containing the path to the file.</param>
    /// <param name="animation">The Animation object where the loaded frames will be stored.</param>
    /// <param name="start">The index of the first frame to load. Defaults to 0.</param>
    /// <param name="count">The number of frames to load. Defaults to 32767.</param>
    /// <returns>true if the file was successfully loaded and frames were extracted; false otherwise.</returns>
    public static bool ImReadAnimation(string filename, Animation animation, int start = 0, int count = short.MaxValue)
    {
        ArgumentNullException.ThrowIfNull(filename);
        ArgumentNullException.ThrowIfNull(animation);

        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imreadanimation(filename, animation.CvPtr, start, count, out var ret));
        GC.KeepAlive(animation);
        return ret != 0;
    }

    /// <summary>
    /// Loads frames from an animated image buffer (e.g., GIF, AVIF, APNG, WEBP) into the provided Animation object.
    /// </summary>
    /// <param name="buf">The image buffer.</param>
    /// <param name="animation">The Animation object where the loaded frames will be stored.</param>
    /// <param name="start">The index of the first frame to load. Defaults to 0.</param>
    /// <param name="count">The number of frames to load. Defaults to 32767.</param>
    /// <returns>true if the buffer was successfully loaded and frames were extracted; false otherwise.</returns>
    public static bool ImDecodeAnimation(InputArray buf, Animation animation, int start = 0, int count = short.MaxValue)
    {
        ArgumentNullException.ThrowIfNull(animation);

        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imdecodeanimation(buf.Proxy, animation.CvPtr, start, count, out var ret));
        GC.KeepAlive(buf.Source);
        GC.KeepAlive(animation);
        return ret != 0;
    }

    /// <summary>
    /// Saves an Animation to a specified file in an animated format (e.g., GIF, AVIF, APNG, WEBP).
    /// </summary>
    /// <param name="fileName">The name of the file where the animation will be saved. The file extension determines the format.</param>
    /// <param name="animation">The Animation containing the frames and metadata to be saved.</param>
    /// <param name="prms">Format-specific save parameters encoded as pairs</param>
    /// <returns>true if the animation was successfully saved; false otherwise.</returns>
    public static bool ImWriteAnimation(string fileName, Animation animation, int[]? prms = null)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentNullException(nameof(fileName));
        ArgumentNullException.ThrowIfNull(animation);
        prms ??= [];

        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imwriteanimation(fileName, animation.CvPtr, prms, prms.Length, out var ret));
        GC.KeepAlive(animation);
        return ret != 0;
    }

    /// <summary>
    /// Encodes an Animation into a memory buffer in an animated format (e.g., GIF, AVIF, APNG, WEBP).
    /// </summary>
    /// <param name="ext">The file extension that determines the format of the encoded data.</param>
    /// <param name="animation">The Animation containing the frames and metadata to be encoded.</param>
    /// <param name="buf">The buffer where the encoded data will be stored.</param>
    /// <param name="prms">Format-specific save parameters encoded as pairs</param>
    /// <returns>true if the animation was successfully encoded; false otherwise.</returns>
    public static bool ImEncodeAnimation(string ext, Animation animation, out byte[] buf, int[]? prms = null)
    {
        if (string.IsNullOrEmpty(ext))
            throw new ArgumentNullException(nameof(ext));
        ArgumentNullException.ThrowIfNull(animation);
        prms ??= [];

        using var bufVec = new StdVector<byte>();
        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imencodeanimation(ext, animation.CvPtr, bufVec.CvPtr, prms, prms.Length, out var ret));
        GC.KeepAlive(animation);
        buf = bufVec.ToArray();
        return ret != 0;
    }

    /// <summary>
    /// Saves an image to a specified file.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <param name="img">Image to be saved.</param>
    /// <param name="prms">Format-specific save parameters encoded as pairs</param>
    /// <returns></returns>
    public static bool ImWrite(string fileName, Mat img, int[]? prms = null)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentNullException(nameof(fileName));
        ArgumentNullException.ThrowIfNull(img);
        prms ??= [];

        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imwrite(fileName, img.CvPtr, prms, prms.Length, out var ret));
        GC.KeepAlive(img);
        return ret != 0;
    }

    /// <summary>
    /// Saves an image to a specified file.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <param name="img">Image to be saved.</param>
    /// <param name="prms">Format-specific save parameters encoded as pairs</param>
    /// <returns></returns>
    public static bool ImWrite(string fileName, Mat img, params ImageEncodingParam[] prms)
    {
        ArgumentNullException.ThrowIfNull(prms);
        if (prms.Length <= 0) 
            return ImWrite(fileName, img);

        var p = new List<int>();
        foreach (var item in prms)
        {
            p.Add((int) item.EncodingId);
            p.Add(item.Value);
        }
        return ImWrite(fileName, img, p.ToArray());
    }

    /// <summary>
    /// Saves an image to a specified file.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <param name="img">Image to be saved.</param>
    /// <param name="prms">Format-specific save parameters encoded as pairs</param>
    /// <returns></returns>
    public static bool ImWrite(string fileName, IEnumerable<Mat> img, int[]? prms = null)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentNullException(nameof(fileName));
        ArgumentNullException.ThrowIfNull(img);
        prms ??= [];

        using var imgVec = new VectorOfMat(img);
        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imwrite_multi(fileName, imgVec.CvPtr, prms, prms.Length, out var ret));
        GC.KeepAlive(img);
        return ret != 0;
    }

    /// <summary>
    /// Saves an image to a specified file.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <param name="img">Image to be saved.</param>
    /// <param name="prms">Format-specific save parameters encoded as pairs</param>
    /// <returns></returns>
    public static bool ImWrite(string fileName, IEnumerable<Mat> img, params ImageEncodingParam[] prms)
    {
        ArgumentNullException.ThrowIfNull(prms);
        if (prms.Length <= 0)
            return ImWrite(fileName, img);

        var p = new List<int>();
        foreach (var item in prms)
        {
            p.Add((int)item.EncodingId);
            p.Add(item.Value);
        }
        return ImWrite(fileName, img, p.ToArray());
    }

    /// <summary>
    /// Reads image from the specified buffer in memory.
    /// </summary>
    /// <param name="buf">The input array of vector of bytes.</param>
    /// <param name="flags">The same flags as in imread</param>
    /// <returns></returns>
    public static Mat ImDecode(Mat buf, ImreadModes flags)
    {
        ArgumentNullException.ThrowIfNull(buf);
        buf.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imdecode_Mat(buf.CvPtr, (int) flags, out var ret));
        GC.KeepAlive(buf);
        return new Mat(ret);
    }

    /// <summary>
    /// Reads image from the specified buffer in memory.
    /// </summary>
    /// <param name="buf">The input array of vector of bytes.</param>
    /// <param name="flags">The same flags as in imread</param>
    /// <returns></returns>
    public static Mat ImDecode(InputArray buf, ImreadModes flags)
    {
        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imdecode_InputArray(buf.Proxy, (int) flags, out var ret));
        GC.KeepAlive(buf.Source);
        return new Mat(ret);
    }

    /// <summary>
    /// Reads image from the specified buffer in memory.
    /// </summary>
    /// <param name="buf">The input array of vector of bytes.</param>
    /// <param name="flags">The same flags as in imread</param>
    /// <returns></returns>
    public static Mat ImDecode(byte[] buf, ImreadModes flags)
    {
        ArgumentNullException.ThrowIfNull(buf);
        var ret = ImDecode(new ReadOnlySpan<byte>(buf), flags);
        GC.KeepAlive(buf);
        return ret;
    }

    /// <summary>
    /// Reads image from the specified buffer in memory.
    /// </summary>
    /// <param name="span">The input slice of bytes.</param>
    /// <param name="flags">The same flags as in imread</param>
    /// <returns></returns>
    public static Mat ImDecode(ReadOnlySpan<byte> span, ImreadModes flags)
    {
        if (span.IsEmpty)
            throw new ArgumentException("Empty span", nameof(span));

        unsafe
        {
            fixed (byte* pBuf = span)
            {
                NativeMethods.HandleException(
                    NativeMethods.imgcodecs_imdecode_vector(pBuf, span.Length, (int) flags, out var ret));
                return new Mat(ret);
            }
        }
    }

    /// <summary>
    /// Reads a multi-page image from a buffer in memory.
    /// </summary>
    /// <param name="buf">Input array or vector of bytes.</param>
    /// <param name="flags">The same flags as in imread</param>
    /// <param name="mats">A vector of Mat objects holding each page, if more than one.</param>
    /// <param name="range">A continuous selection of pages. Defaults to all pages.</param>
    /// <returns></returns>
    public static bool ImDecodeMulti(InputArray buf, ImreadModes flags, out Mat[] mats, Range? range = null)
    {
        using var matsVec = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imdecodemulti(buf.Proxy, (int) flags, matsVec.CvPtr, range ?? Range.All, out var ret));
        GC.KeepAlive(buf.Source);
        mats = matsVec.ToArray();
        return ret != 0;
    }

    /// <summary>
    /// Decodes an image from a memory buffer and extracts associated metadata.
    /// </summary>
    /// <param name="buf">Input array or vector of bytes containing the encoded image data.</param>
    /// <param name="metadataTypes">Output array with types of metadata chunks returned in metadata.</param>
    /// <param name="metadata">Output array of matrices to store the retrieved metadata.</param>
    /// <param name="flags">The same flags as in imread</param>
    /// <returns>The decoded image. If decoding fails, the function returns an empty matrix.</returns>
    public static Mat ImDecodeWithMetadata(InputArray buf, out ImageMetadataType[] metadataTypes, out Mat[] metadata, ImreadModes flags)
    {
        using var metadataTypesVec = new StdVector<int>();
        using var metadataVec = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imdecodeWithMetadata(buf.Proxy, metadataTypesVec.CvPtr, metadataVec.CvPtr, (int) flags, out var ret));
        GC.KeepAlive(buf.Source);
        metadataTypes = Array.ConvertAll(metadataTypesVec.ToArray(), t => (ImageMetadataType) t);
        metadata = metadataVec.ToArray();
        return new Mat(ret);
    }

    /// <summary>
    /// Compresses the image and stores it in the memory buffer
    /// </summary>
    /// <param name="ext">The file extension that defines the output format</param>
    /// <param name="img">The image to be written</param>
    /// <param name="buf">Output buffer resized to fit the compressed image.</param>
    /// <param name="prms">Format-specific parameters.</param>
    public static bool ImEncode(string ext, InputArray img, out byte[] buf, int[]? prms = null)
    {
        if (string.IsNullOrEmpty(ext))
            throw new ArgumentNullException(nameof(ext));
        prms ??= [];

        using var bufVec = new StdVector<byte>();
        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imencode_vector(ext, img.Proxy, bufVec.CvPtr, prms, prms.Length, out var ret));
        GC.KeepAlive(img.Source);
        buf = bufVec.ToArray();
        return ret != 0;
    }

    /// <summary>
    /// Compresses the image and stores it in the memory buffer
    /// </summary>
    /// <param name="ext">The file extension that defines the output format</param>
    /// <param name="img">The image to be written</param>
    /// <param name="buf">Output buffer resized to fit the compressed image.</param>
    /// <param name="prms">Format-specific parameters.</param>
    public static void ImEncode(string ext, InputArray img, out byte[] buf, params ImageEncodingParam[] prms)
    {
        ArgumentNullException.ThrowIfNull(prms);
        var p = new List<int>();
        foreach (var item in prms)
        {
            p.Add((int)item.EncodingId);
            p.Add(item.Value);
        }
        ImEncode(ext, img, out buf, p.ToArray());
    }

    /// <summary>
    /// Compresses the image into a memory buffer, additionally encoding metadata if the corresponding format supports it.
    /// </summary>
    /// <param name="ext">The file extension that defines the output format</param>
    /// <param name="img">The image to be written</param>
    /// <param name="metadataTypes">Array with types of metadata chunks stored in metadata to write.</param>
    /// <param name="metadata">Array of matrices with chunks of metadata to store into the file.</param>
    /// <param name="buf">Output buffer resized to fit the compressed image.</param>
    /// <param name="prms">Format-specific parameters.</param>
    public static bool ImEncodeWithMetadata(
        string ext, InputArray img, ImageMetadataType[] metadataTypes, IEnumerable<Mat> metadata, out byte[] buf, int[]? prms = null)
    {
        if (string.IsNullOrEmpty(ext))
            throw new ArgumentNullException(nameof(ext));
        ArgumentNullException.ThrowIfNull(metadataTypes);
        ArgumentNullException.ThrowIfNull(metadata);
        prms ??= [];

        using var metadataVec = new VectorOfMat(metadata);
        using var bufVec = new StdVector<byte>();
        var metadataTypesInt = Array.ConvertAll(metadataTypes, t => (int) t);
        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imencodeWithMetadata(
                ext, img.Proxy, metadataTypesInt, metadataTypesInt.Length, metadataVec.CvPtr, bufVec.CvPtr, prms, prms.Length, out var ret));
        GC.KeepAlive(img.Source);
        buf = bufVec.ToArray();
        return ret != 0;
    }

    /// <summary>
    /// Encodes array of images into a memory buffer.
    /// </summary>
    /// <param name="ext">The file extension that defines the output format</param>
    /// <param name="imgs">The images to be written</param>
    /// <param name="buf">Output buffer resized to fit the compressed data.</param>
    /// <param name="prms">Format-specific parameters.</param>
    public static bool ImEncodeMulti(string ext, IEnumerable<Mat> imgs, out byte[] buf, int[]? prms = null)
    {
        if (string.IsNullOrEmpty(ext))
            throw new ArgumentNullException(nameof(ext));
        ArgumentNullException.ThrowIfNull(imgs);
        prms ??= [];

        using var imgsVec = new VectorOfMat(imgs);
        using var bufVec = new StdVector<byte>();
        NativeMethods.HandleException(
            NativeMethods.imgcodecs_imencodemulti(ext, imgsVec.CvPtr, bufVec.CvPtr, prms, prms.Length, out var ret));
        buf = bufVec.ToArray();
        return ret != 0;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static bool HaveImageReader(string fileName)
    {
        ArgumentNullException.ThrowIfNull(fileName);

        NativeMethods.HandleException(
            NativeMethods.imgcodecs_haveImageReader(fileName, out var ret));
        return ret != 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static bool HaveImageWriter(string fileName)
    {
        ArgumentNullException.ThrowIfNull(fileName);

        NativeMethods.HandleException(
            NativeMethods.imgcodecs_haveImageWriter(fileName, out var ret));
        return ret != 0;
    }
}
