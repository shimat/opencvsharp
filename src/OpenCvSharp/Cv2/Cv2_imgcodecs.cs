using System;
using System.Collections.Generic;

namespace OpenCvSharp
{
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
            return new Mat(ret);
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
            if (filename == null) 
                throw new ArgumentNullException(nameof(filename));

            using var matsVec = new VectorOfMat();
            NativeMethods.HandleException(
                NativeMethods.imgcodecs_imreadmulti(filename, matsVec.CvPtr, (int) flags, out var ret));
            mats = matsVec.ToArray();
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
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (prms == null)
                prms = Array.Empty<int>();

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
            if (prms == null || prms.Length <= 0) 
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
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (prms == null)
                prms = Array.Empty<int>();

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
            if (prms == null || prms.Length <= 0)
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
            if (buf == null)
                throw new ArgumentNullException(nameof(buf));
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
            if (buf == null)
                throw new ArgumentNullException(nameof(buf));
            buf.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.imgcodecs_imdecode_InputArray(buf.CvPtr, (int) flags, out var ret));
            GC.KeepAlive(buf);
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
            if (buf == null)
                throw new ArgumentNullException(nameof(buf));

            NativeMethods.HandleException(
                NativeMethods.imgcodecs_imdecode_vector(buf, new IntPtr(buf.Length), (int) flags, out var ret));
            return new Mat(ret);
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
                        NativeMethods.imgcodecs_imdecode_vector(pBuf, new IntPtr(span.Length), (int) flags, out var ret));
                    return new Mat(ret);
                }
            }
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
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (prms == null)
                prms = Array.Empty<int>();
            img.ThrowIfDisposed();

            using var bufVec = new VectorOfByte();
            NativeMethods.HandleException(
                NativeMethods.imgcodecs_imencode_vector(ext, img.CvPtr, bufVec.CvPtr, prms, prms.Length, out var ret));
            GC.KeepAlive(img);
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
            if (prms != null)
            {
                var p = new List<int>();
                foreach (var item in prms)
                {
                    p.Add((int) item.EncodingId);
                    p.Add(item.Value);
                }
                ImEncode(ext, img, out buf, p.ToArray());
            }
            else
            {
                ImEncode(ext, img, out buf);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool HaveImageReader(string fileName)
        {
            if (fileName == null) 
                throw new ArgumentNullException(nameof(fileName));

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
            if (fileName == null) 
                throw new ArgumentNullException(nameof(fileName));

            NativeMethods.HandleException(
                NativeMethods.imgcodecs_haveImageWriter(fileName, out var ret));
            return ret != 0;
        }
    }
}
