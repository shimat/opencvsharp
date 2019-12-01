using System.Runtime.InteropServices;

namespace OpenCvSharp.Aruco
{
    /// <summary>
    /// Parameters for the detectMarker process
    /// </summary>
    public class DetectorParameters
    {
        internal NativeStruct Native;

        private DetectorParameters(NativeStruct native)
        {
            Native = native;
        }

        /// <summary> 
        /// </summary>
        /// <returns></returns>
        public static DetectorParameters Create()
        {
            NativeMethods.HandleException(
                NativeMethods.aruco_DetectorParameters_create(out var native));
            return new DetectorParameters(native);
        }

        /// <summary>
        /// minimum window size for adaptive thresholding before finding contours (default 3).
        /// </summary>
        public int AdaptiveThreshWinSizeMin
        {
            get => Native.adaptiveThreshWinSizeMin;
            set => Native.adaptiveThreshWinSizeMin = value;
        }

        /// <summary>
        /// adaptiveThreshWinSizeMax: maximum window size for adaptive thresholding before finding contours(default 23).
        /// </summary>
        public int AdaptiveThreshWinSizeMax
        {
            get => Native.adaptiveThreshWinSizeMax;
            set => Native.adaptiveThreshWinSizeMax = value;
        }

        /// <summary>
        /// increments from adaptiveThreshWinSizeMin to adaptiveThreshWinSizeMax during the thresholding(default 10).
        /// </summary>
        public int AdaptiveThreshWinSizeStep
        {
            get => Native.adaptiveThreshWinSizeStep;
            set => Native.adaptiveThreshWinSizeStep = value;
        }

        /// <summary>
        /// constant for adaptive thresholding before finding contours (default 7)
        /// </summary>
        public double AdaptiveThreshConstant
        {
            get => Native.adaptiveThreshConstant;
            set => Native.adaptiveThreshConstant = value;
        }

        /// <summary>
        /// determine minimum perimeter for marker contour to be detected. 
        /// This is defined as a rate respect to the maximum dimension of the input image(default 0.03).
        /// </summary>
        public double MinMarkerPerimeterRate
        {
            get => Native.minMarkerPerimeterRate;
            set => Native.minMarkerPerimeterRate = value;
        }

        /// <summary>
        ///  determine maximum perimeter for marker contour to be detected. 
        /// This is defined as a rate respect to the maximum dimension of the input image(default 4.0).
        /// </summary>
        public double MaxMarkerPerimeterRate
        {
            get => Native.maxMarkerPerimeterRate;
            set => Native.maxMarkerPerimeterRate = value;
        }

        /// <summary>
        /// minimum accuracy during the polygonal approximation process to determine which contours are squares.
        /// </summary>
        public double PolygonalApproxAccuracyRate
        {
            get => Native.polygonalApproxAccuracyRate;
            set => Native.polygonalApproxAccuracyRate = value;
        }

        /// <summary>
        /// minimum distance between corners for detected markers relative to its perimeter(default 0.05)
        /// </summary>
        public double MinCornerDistanceRate
        {
            get => Native.minCornerDistanceRate;
            set => Native.minCornerDistanceRate = value;
        }

        /// <summary>
        ///  minimum distance of any corner to the image border for detected markers (in pixels) (default 3)
        /// </summary>
        public int MinDistanceToBorder
        {
            get => Native.minDistanceToBorder;
            set => Native.minDistanceToBorder = value;
        }

        /// <summary>
        /// minimum mean distance between two marker corners to be considered similar, 
        /// so that the smaller one is removed.The rate is relative to the smaller perimeter of the two markers(default 0.05).
        /// </summary>
        public double MinMarkerDistanceRate
        {
            get => Native.minMarkerDistanceRate;
            set => Native.minMarkerDistanceRate = value;
        }

        /// <summary>
        /// corner refinement method.
        /// (CORNER_REFINE_NONE, no refinement. CORNER_REFINE_SUBPIX, do subpixel refinement. CORNER_REFINE_CONTOUR use contour-Points)
        /// </summary>
        public CornerRefineMethod CornerRefinementMethod
        {
            get => (CornerRefineMethod)Native.cornerRefinementMethod;
            set => Native.cornerRefinementMethod = (int)value;
        }

        /// <summary>
        /// window size for the corner refinement process (in pixels) (default 5).
        /// </summary>
        public int CornerRefinementWinSize
        {
            get => Native.cornerRefinementWinSize;
            set => Native.cornerRefinementWinSize = value;
        }

        /// <summary>
        /// maximum number of iterations for stop criteria of the corner refinement process(default 30).
        /// </summary>
        public int CornerRefinementMaxIterations
        {
            get => Native.cornerRefinementMaxIterations;
            set => Native.cornerRefinementMaxIterations = value;
        }

        /// <summary>
        /// minimum error for the stop criteria of the corner refinement process(default: 0.1)
        /// </summary>
        public double CornerRefinementMinAccuracy
        {
            get => Native.cornerRefinementMinAccuracy;
            set => Native.cornerRefinementMinAccuracy = value;
        }

        /// <summary>
        /// number of bits of the marker border, i.e. marker border width (default 1).
        /// </summary>
        public int MarkerBorderBits
        {
            get => Native.markerBorderBits;
            set => Native.markerBorderBits = value;
        }

        /// <summary>
        /// number of bits (per dimension) for each cell of the marker when removing the perspective(default 8).
        /// </summary>
        public int PerspectiveRemovePixelPerCell
        {
            get => Native.perspectiveRemovePixelPerCell;
            set => Native.perspectiveRemovePixelPerCell = value;
        }

        /// <summary>
        /// width of the margin of pixels on each cell not considered for the determination 
        /// of the cell bit.Represents the rate respect to the total  size of the cell, 
        /// i.e. perspectiveRemovePixelPerCell (default 0.13)
        /// </summary>
        public double PerspectiveRemoveIgnoredMarginPerCell
        {
            get => Native.perspectiveRemoveIgnoredMarginPerCell;
            set => Native.perspectiveRemoveIgnoredMarginPerCell = value;
        }

        /// <summary>
        /// maximum number of accepted erroneous bits in the border 
        /// (i.e. number of allowed white bits in the border). Represented as a rate respect to the total 
        /// number of bits per marker(default 0.35).
        /// </summary>
        public double MaxErroneousBitsInBorderRate
        {
            get => Native.maxErroneousBitsInBorderRate;
            set => Native.maxErroneousBitsInBorderRate = value;
        }

        /// <summary>
        /// minimun standard deviation in pixels values during the decodification step to
        ///  apply Otsu thresholding(otherwise, all the bits are set to 0 or 1 depending on mean higher than 128 or not) (default 5.0)
        /// </summary>
        public double MinOtsuStdDev
        {
            get => Native.minOtsuStdDev;
            set => Native.minOtsuStdDev = value;
        }

        /// <summary>
        /// errorCorrectionRate error correction rate respect to the maximun error correction capability for each dictionary. (default 0.6).
        /// </summary>
        public double ErrorCorrectionRate
        {
            get => Native.errorCorrectionRate;
            set => Native.errorCorrectionRate = value;
        }

#pragma warning disable 1591
        [StructLayout(LayoutKind.Sequential)]
        public struct NativeStruct
        {
            public int adaptiveThreshWinSizeMin;
            public int adaptiveThreshWinSizeMax;
            public int adaptiveThreshWinSizeStep;
            public double adaptiveThreshConstant;
            public double minMarkerPerimeterRate;
            public double maxMarkerPerimeterRate;
            public double polygonalApproxAccuracyRate;
            public double minCornerDistanceRate;
            public int minDistanceToBorder;
            public double minMarkerDistanceRate;
            public int cornerRefinementMethod;
            public int cornerRefinementWinSize;
            public int cornerRefinementMaxIterations;
            public double cornerRefinementMinAccuracy;
            public int markerBorderBits;
            public int perspectiveRemovePixelPerCell;
            public double perspectiveRemoveIgnoredMarginPerCell;
            public double maxErroneousBitsInBorderRate;
            public double minOtsuStdDev;
            public double errorCorrectionRate;
        };
#pragma warning restore 1591
    }
}
