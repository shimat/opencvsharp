using OpenCvSharp.Aruco;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

public static partial class Cv2
{
    /// <summary>
    /// aruco module
    /// </summary>
    public static partial class Aruco
    {
        /// <summary>
        /// Draw detected markers in image
        /// </summary>
        /// <param name="image">input/output image. It must have 1 or 3 channels. The number of channels is not altered.</param>
        /// <param name="corners">positions of marker corners on input image.
        /// For N detected markers, the dimensions of this array should be Nx4.The order of the corners should be clockwise.</param>
        /// <param name="ids">vector of identifiers for markers in markersCorners. Optional, if not provided, ids are not painted.</param>
        public static void DrawDetectedMarkers(InputOutputArray image, Point2f[][] corners, IEnumerable<int> ids)
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
        public static void DrawDetectedMarkers(InputOutputArray image, Point2f[][] corners, IEnumerable<int>? ids, Scalar borderColor)
        {
            ArgumentNullException.ThrowIfNull(corners);

            using var cornersAddress = new ArrayAddress2<Point2f>(corners);
            if (ids is null)
            {
                NativeMethods.HandleException(
                    NativeMethods.aruco_drawDetectedMarkers(
                        image.Proxy, cornersAddress.GetPointer(), cornersAddress.GetDim1Length(), cornersAddress.GetDim2Lengths(),
                        IntPtr.Zero, 0, borderColor));
            }
            else
            {
                var idxArray = ids.ToArray();
                NativeMethods.HandleException(
                    NativeMethods.aruco_drawDetectedMarkers(
                        image.Proxy, cornersAddress.GetPointer(), cornersAddress.GetDim1Length(), cornersAddress.GetDim2Lengths(),
                        idxArray, idxArray.Length, borderColor));
            }
            GC.KeepAlive(image.Source);
        }

        /// <summary>
        /// Returns one of the predefined dictionaries defined in PREDEFINED_DICTIONARY_NAME
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Dictionary GetPredefinedDictionary(PredefinedDictionaryType name)
        {
            NativeMethods.HandleException(
                NativeMethods.aruco_getPredefinedDictionary((int) name, out IntPtr p));
            return new Dictionary(p);
        }

        /// <summary>
        /// Returns one of the predefined dictionaries referenced by DICT_*.
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static Dictionary GetPredefinedDictionary(int dict)
        {
            NativeMethods.HandleException(
                NativeMethods.aruco_getPredefinedDictionary(dict, out IntPtr p));
            return new Dictionary(p);
        }

        /// <summary>
        /// Extend base dictionary by new nMarkers.
        /// This function creates a new dictionary composed by nMarkers markers and each markers composed
        /// by markerSize x markerSize bits. If baseDictionary is provided, its markers are directly
        /// included and the rest are generated based on them. If the size of baseDictionary is higher
        /// than nMarkers, only the first nMarkers in baseDictionary are taken and no new marker is added.
        /// </summary>
        /// <param name="nMarkers">number of markers in the dictionary</param>
        /// <param name="markerSize">number of bits per dimension of each markers</param>
        /// <param name="baseDictionary">Include the markers in this dictionary at the beginning (optional)</param>
        /// <param name="randomSeed">a user supplied seed for theRNG()</param>
        /// <returns></returns>
        public static Dictionary ExtendDictionary(int nMarkers, int markerSize, Dictionary? baseDictionary = null, int randomSeed = 0)
        {
            baseDictionary?.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.aruco_extendDictionary(
                    nMarkers, markerSize, baseDictionary?.CvPtr ?? IntPtr.Zero, randomSeed, out var p));

            GC.KeepAlive(baseDictionary);
            return new Dictionary(p);
        }

        /// <summary>
        /// Reads a new dictionary from FileNode.
        /// </summary>
        /// <remarks>
        /// Dictionary format is YAML see sample below
        /// <code>
        /// nmarkers: 35
        /// markersize: 6
        /// maxCorrectionBits: 5
        /// marker_0: "101011111011111001001001101100000000"
        /// ...
        /// marker_34: "011111010000111011111110110101100101"
        /// </code>
        /// </remarks>
        /// <param name="dictionaryFile">The path of the dictionary file</param>
        /// <returns>Instance of a Dictionary</returns>
        public static Dictionary ReadDictionary(string dictionaryFile)
        {
            NativeMethods.HandleException(
                NativeMethods.aruco_readDictionary(dictionaryFile, out IntPtr p));
            return new Dictionary(p);
        }

        /// <summary>
        /// Draw a set of detected ChArUco Diamond markers.
        /// </summary>
        /// <param name="image">input/output image. It must have 1 or 3 channels. The number of channels is not altered.</param>
        /// <param name="diamondCorners">positions of diamond corners in the same format returned by detectCharucoDiamond(). (e.g std::vector&lt;std::vector&lt;cv::Point2f&gt;&gt;). For N detected markers, the dimensions of this array should be Nx4. The order of the corners should be clockwise.</param>
        /// <param name="diamondIds">vector of identifiers for diamonds in diamondCorners, in the same format returned by detectCharucoDiamond() (e.g. std::vector&lt;Vec4i&gt;). Optional, if not provided, ids are not painted.</param>
        public static void DrawDetectedDiamonds(InputOutputArray image, Point2f[][] diamondCorners, IEnumerable<Vec4i>? diamondIds = null)
        {
            DrawDetectedDiamonds(image, diamondCorners, diamondIds, new Scalar(0, 0, 255));
        }

        /// <summary>
        /// Draw a set of detected ChArUco Diamond markers.
        /// </summary>
        /// <param name="image">input/output image. It must have 1 or 3 channels. The number of channels is not altered.</param>
        /// <param name="diamondCorners">positions of diamond corners in the same format returned by detectCharucoDiamond(). (e.g std::vector&lt;std::vector&lt;cv::Point2f&gt;&gt;). For N detected markers, the dimensions of this array should be Nx4. The order of the corners should be clockwise.</param>
        /// <param name="diamondIds">vector of identifiers for diamonds in diamondCorners, in the same format returned by detectCharucoDiamond() (e.g. std::vector&lt;Vec4i&gt;). Optional, if not provided, ids are not painted.</param>
        /// <param name="borderColor">color of marker borders. Rest of colors (text color and first corner color) are calculated based on this one.</param>
        public static void DrawDetectedDiamonds(InputOutputArray image,
            Point2f[][] diamondCorners, IEnumerable<Vec4i>? diamondIds, Scalar borderColor)
        {
            ArgumentNullException.ThrowIfNull(diamondCorners);

            using var cornersAddress = new ArrayAddress2<Point2f>(diamondCorners);

            if (diamondIds is null)
            {
                NativeMethods.HandleException(
                    NativeMethods.aruco_drawDetectedDiamonds(image.Proxy,
                        cornersAddress.GetPointer(), cornersAddress.GetDim1Length(), cornersAddress.GetDim2Lengths(),
                        IntPtr.Zero, borderColor));
            }
            else
            {
                using var ids = new StdVector<Vec4i>(diamondIds);

                NativeMethods.HandleException(
                    NativeMethods.aruco_drawDetectedDiamonds(image.Proxy,
                        cornersAddress.GetPointer(), cornersAddress.GetDim1Length(), cornersAddress.GetDim2Lengths(),
                        ids.CvPtr, borderColor));
            }

            GC.KeepAlive(image.Source);
        }

        /// <summary>
        /// Draw a set of detected ChArUco Diamond markers.
        /// </summary>
        /// <param name="image">input/output image. It must have 1 or 3 channels. The number of channels is not altered.</param>
        /// <param name="charucoCorners">vector of detected charuco corners.</param>
        /// <param name="charucoIds">list of identifiers for each corner in charucoCorners.</param>
        public static void DrawDetectedCornersCharuco(InputOutputArray image, Point2f[] charucoCorners, IEnumerable<int>? charucoIds = null)
        {
            DrawDetectedCornersCharuco(image, charucoCorners, charucoIds, new Scalar(0, 0, 255));
        }

        /// <summary>
        /// Draw a set of detected ChArUco Diamond markers.
        /// </summary>
        /// <param name="image">input/output image. It must have 1 or 3 channels. The number of channels is not altered.</param>
        /// <param name="charucoCorners">vector of detected charuco corners.</param>
        /// <param name="charucoIds">list of identifiers for each corner in charucoCorners.</param>
        /// <param name="cornerColor">color of the square surrounding each corner.</param>
        public static void DrawDetectedCornersCharuco(InputOutputArray image,
            Point2f[] charucoCorners, IEnumerable<int>? charucoIds, Scalar cornerColor)
        {
            ArgumentNullException.ThrowIfNull(charucoCorners);

            using var charucoCornersVec = new StdVector<Point2f>(charucoCorners);

            if (charucoIds is null)
            {
                NativeMethods.HandleException(
                    NativeMethods.aruco_drawDetectedCornersCharuco(image.Proxy,
                        charucoCornersVec.CvPtr, IntPtr.Zero, cornerColor));
            }
            else
            {
                using var ids = new StdVector<int>(charucoIds);

                NativeMethods.HandleException(
                    NativeMethods.aruco_drawDetectedCornersCharuco(image.Proxy,
                        charucoCornersVec.CvPtr, ids.CvPtr, cornerColor));
            }

            GC.KeepAlive(image.Source);
        }
    }
}
