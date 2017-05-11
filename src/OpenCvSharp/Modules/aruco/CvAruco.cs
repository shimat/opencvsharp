using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp.Aruco
{
    /// <summary>
    /// aruco module
    /// </summary>
    public static class CvAruco
    {
        /// <summary>
        /// Basic marker detection
        /// </summary>
        /// <param name="image">input image</param>
        /// <param name="dictionary">indicates the type of markers that will be searched</param>
        /// <param name="corners">vector of detected marker corners. 
        /// For each marker, its four corners are provided. For N detected markers,
        ///  the dimensions of this array is Nx4.The order of the corners is clockwise.</param>
        /// <param name="ids">vector of identifiers of the detected markers. The identifier is of type int. 
        /// For N detected markers, the size of ids is also N. The identifiers have the same order than the markers in the imgPoints array.</param>
        /// <param name="parameters">marker detection parameters</param>
        /// <param name="rejectedImgPoints">contains the imgPoints of those squares whose inner code has not a 
        /// correct codification.Useful for debugging purposes.</param>
        public static void DetectMarkers(InputArray image, Dictionary dictionary, out Point2f[][] corners, out int[] ids, DetectorParameters parameters, out Point2f[][] rejectedImgPoints)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            using (var cornersVec = new VectorOfVectorPoint2f())
            using (var idsVec = new VectorOfInt32())
            using (var rejectedImgPointsVec = new VectorOfVectorPoint2f())
            {
                NativeMethods.aruco_detectMarkers(image.CvPtr, dictionary.ObjectPtr.CvPtr, cornersVec.CvPtr, idsVec.CvPtr, parameters.ObjectPtr.CvPtr, rejectedImgPointsVec.CvPtr);

                corners = cornersVec.ToArray();
                ids = idsVec.ToArray();
                rejectedImgPoints = rejectedImgPointsVec.ToArray();
            }

            GC.KeepAlive(image);
            GC.KeepAlive(dictionary);
        }

        /// <summary>
        /// Draw detected markers in image
        /// </summary>
        /// <param name="image">input/output image. It must have 1 or 3 channels. The number of channels is not altered.</param>
        /// <param name="corners">positions of marker corners on input image. 
        /// For N detected markers, the dimensions of this array should be Nx4.The order of the corners should be clockwise.</param>
        /// <param name="ids">vector of identifiers for markers in markersCorners. Optional, if not provided, ids are not painted.</param>
        public static void DrawDetectedMarkers(InputArray image, Point2f[][] corners, IEnumerable<int> ids)
        {
            DrawDetectedMarkers(image, corners, ids, new Scalar(0, 255, 0));
        }

        /// <summary>
        /// Draw detected markers in image
        /// </summary>
        /// <param name="image">input/output image. It must have 1 or 3 channels. The number of channels is not altered.</param>
        /// <param name="corners">positions of marker corners on input image. 
        /// For N detected markers, the dimensions of this array should be Nx4.The order of the corners should be clockwise.</param>
        /// <param name="ids">vector of identifiers for markers in markersCorners. Optional, if not provided, ids are not painted.</param>
        /// <param name="borderColor">color of marker borders. Rest of colors (text color and first corner color)
        ///  are calculated based on this one to improve visualization.</param>
        public static void DrawDetectedMarkers(InputArray image, Point2f[][] corners, IEnumerable<int> ids, Scalar borderColor)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (corners == null)
                throw new ArgumentNullException(nameof(corners));

            using (var cornersAddress = new ArrayAddress2<Point2f>(corners))
            {
                if (ids == null)
                {
                    NativeMethods.aruco_drawDetectedMarkers(image.CvPtr, cornersAddress.Pointer, cornersAddress.Dim1Length, cornersAddress.Dim2Lengths, IntPtr.Zero, 0, borderColor);
                }
                else
                {
                    int[] idxArray = EnumerableEx.ToArray(ids);
                    NativeMethods.aruco_drawDetectedMarkers(image.CvPtr, cornersAddress.Pointer, cornersAddress.Dim1Length, cornersAddress.Dim2Lengths, idxArray, idxArray.Length, borderColor);
                }
            }
        }

        /// <summary>
        /// Draw a canonical marker image
        /// </summary>
        /// <param name="dictionary">dictionary of markers indicating the type of markers</param>
        /// <param name="id">identifier of the marker that will be returned. It has to be a valid id in the specified dictionary.</param>
        /// <param name="sidePixels">size of the image in pixels</param>
        /// <param name="mat">output image with the marker</param>
        /// <param name="borderBits">width of the marker border.</param>
        public static void DrawMarker(Dictionary dictionary, int id, int sidePixels, OutputArray mat, int borderBits = 1)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));
            dictionary.ThrowIfDisposed();
            mat.ThrowIfNotReady();

            NativeMethods.aruco_drawMarker(dictionary.ObjectPtr.CvPtr, id, sidePixels, mat.CvPtr, borderBits);
            mat.Fix();
            GC.KeepAlive(dictionary);
        }

        /// <summary>
        /// Returns one of the predefined dictionaries defined in PREDEFINED_DICTIONARY_NAME
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Dictionary GetPredefinedDictionary(PredefinedDictionaryName name)
        {
            IntPtr ptr = NativeMethods.aruco_getPredefinedDictionary((int)name);
            return new Dictionary(ptr);
        }
    }
}
