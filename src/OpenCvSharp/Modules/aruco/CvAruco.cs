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
            GC.KeepAlive(parameters);
        }

        /// <summary>
        /// Pose estimation for single markers
        /// </summary>
        /// <param name="corners">corners vector of already detected markers corners. 
        /// For each marker, its four corners are provided, (e.g std::vector&lt;std::vector&lt;cv::Point2f&gt;&gt; ). 
        /// For N detected markers, the dimensions of this array should be Nx4. The order of the corners should be clockwise.</param>
        /// <param name="markerLength">the length of the markers' side. The returning translation vectors will 
        /// be in the same unit.Normally, unit is meters.</param>
        /// <param name="cameraMatrix">input 3x3 floating-point camera matrix 
        /// \f$A = \vecthreethree{f_x}{0}{c_x}{0}{f_y}{c_y}{0}{0}{1}\f$</param>
        /// <param name="distortionCoefficients">vector of distortion coefficients 
        /// \f$(k_1, k_2, p_1, p_2[, k_3[, k_4, k_5, k_6],[s_1, s_2, s_3, s_4]])\f$ of 4, 5, 8 or 12 elements</param>
        /// <param name="rvec">array of output rotation vectors (@sa Rodrigues) (e.g. std::vector&lt;cv::Vec3d&gt;). 
        /// Each element in rvecs corresponds to the specific marker in imgPoints.</param>
        /// <param name="tvec">array of output translation vectors (e.g. std::vector&lt;cv::Vec3d&gt;).
        /// Each element in tvecs corresponds to the specific marker in imgPoints.</param>
        /// <param name="objPoints">array of object points of all the marker corners</param>
        public static void EstimatePoseSingleMarkers(Point2f[][] corners, float markerLength, InputArray cameraMatrix, InputArray distortionCoefficients, OutputArray rvec, OutputArray tvec, OutputArray objPoints = null)
        {
            if (corners == null)
                throw new ArgumentNullException(nameof(corners));
            if (cameraMatrix == null)
                throw new ArgumentNullException(nameof(cameraMatrix));
            if (distortionCoefficients == null)
                throw new ArgumentNullException(nameof(distortionCoefficients));
            if (rvec == null)
                throw new ArgumentNullException(nameof(rvec));
            if (tvec == null)
                throw new ArgumentNullException(nameof(tvec));

            cameraMatrix.ThrowIfDisposed();
            distortionCoefficients.ThrowIfDisposed();
            rvec.ThrowIfNotReady();
            tvec.ThrowIfNotReady();
            objPoints?.ThrowIfNotReady();

            using (var cornersAddress = new ArrayAddress2<Point2f>(corners))
            {
                NativeMethods.aruco_estimatePoseSingleMarkers(
                    cornersAddress.Pointer, cornersAddress.Dim1Length, cornersAddress.Dim2Lengths,
                    markerLength, cameraMatrix.CvPtr, distortionCoefficients.CvPtr, rvec.CvPtr, tvec.CvPtr, objPoints?.CvPtr ?? IntPtr.Zero);
            }

            GC.KeepAlive(cameraMatrix);
            GC.KeepAlive(distortionCoefficients);
            rvec.Fix();
            tvec.Fix();
            objPoints?.Fix();
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
                GC.KeepAlive(image);
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
            GC.KeepAlive(mat);
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
