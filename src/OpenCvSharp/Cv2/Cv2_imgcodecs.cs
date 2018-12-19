using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

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
            return new Mat(fileName, flags);
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

            using (var matsVec = new VectorOfMat())
            {
                int ret = NativeMethods.imgcodecs_imreadmulti(filename, matsVec.CvPtr, (int) flags);
                mats = matsVec.ToArray();
                return ret != 0;
            }
        }

        /// <summary>
        /// Saves an image to a specified file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="img">Image to be saved.</param>
        /// <param name="prms">Format-specific save parameters encoded as pairs</param>
        /// <returns></returns>
        public static bool ImWrite(string fileName, Mat img, int[] prms = null)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (prms == null)
                prms = new int[0];

            var res = NativeMethods.imgcodecs_imwrite(fileName, img.CvPtr, prms, prms.Length) != 0;
            GC.KeepAlive(img);
            return res;
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
            if (prms != null && prms.Length > 0)
            {
                List<int> p = new List<int>();
                foreach (ImageEncodingParam item in prms)
                {
                    p.Add((int) item.EncodingId);
                    p.Add(item.Value);
                }
                return ImWrite(fileName, img, p.ToArray());
            }

            return ImWrite(fileName, img, (int[]) null);
        }

        /// <summary>
        /// Saves an image to a specified file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="img">Image to be saved.</param>
        /// <param name="prms">Format-specific save parameters encoded as pairs</param>
        /// <returns></returns>
        public static bool ImWrite(string fileName, IEnumerable<Mat> img, int[] prms = null)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (prms == null)
                prms = new int[0];

            using (var imgVec = new VectorOfMat(img))
            {
                var res = NativeMethods.imgcodecs_imwrite_multi(fileName, imgVec.CvPtr, prms, prms.Length) != 0;
                GC.KeepAlive(img);
                return res;
            }
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
            if (prms != null && prms.Length > 0)
            {
                List<int> p = new List<int>();
                foreach (ImageEncodingParam item in prms)
                {
                    p.Add((int)item.EncodingId);
                    p.Add(item.Value);
                }
                return ImWrite(fileName, img, p.ToArray());
            }

            return ImWrite(fileName, img, (int[])null);
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
            IntPtr matPtr = NativeMethods.imgcodecs_imdecode_Mat(buf.CvPtr, (int) flags);
            GC.KeepAlive(buf);
            return new Mat(matPtr);
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
            IntPtr matPtr = NativeMethods.imgcodecs_imdecode_InputArray(buf.CvPtr, (int) flags);
            GC.KeepAlive(buf);
            return new Mat(matPtr);
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
            IntPtr matPtr = NativeMethods.imgcodecs_imdecode_vector(
                buf, new IntPtr(buf.Length), (int) flags);
            return new Mat(matPtr);
        }

        /// <summary>
        /// Compresses the image and stores it in the memory buffer
        /// </summary>
        /// <param name="ext">The file extension that defines the output format</param>
        /// <param name="img">The image to be written</param>
        /// <param name="buf">Output buffer resized to fit the compressed image.</param>
        /// <param name="prms">Format-specific parameters.</param>
        public static bool ImEncode(string ext, InputArray img, out byte[] buf, int[] prms = null)
        {
            if (string.IsNullOrEmpty(ext))
                throw new ArgumentNullException(nameof(ext));
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (prms == null)
                prms = new int[0];
            img.ThrowIfDisposed();
            using (var bufVec = new VectorOfByte())
            {
                int ret = NativeMethods.imgcodecs_imencode_vector(ext, img.CvPtr, bufVec.CvPtr, prms, prms.Length);
                GC.KeepAlive(img);
                buf = bufVec.ToArray();
                return ret != 0;
            }
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
                foreach (ImageEncodingParam item in prms)
                {
                    p.Add((int) item.EncodingId);
                    p.Add(item.Value);
                }
                ImEncode(ext, img, out buf, p.ToArray());
            }
            else
            {
                ImEncode(ext, img, out buf, (int[]) null);
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
            return NativeMethods.imgcodecs_haveImageReader(fileName) != 0;
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
            return NativeMethods.imgcodecs_haveImageWriter(fileName) != 0;
        }
    }
}
