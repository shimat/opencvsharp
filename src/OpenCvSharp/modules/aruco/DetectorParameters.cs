using System;

namespace OpenCvSharp.Aruco
{
    /// <summary>
    /// Parameters for the detectMarker process
    /// </summary>
    public class DetectorParameters : DisposableCvObject
    {
        /// <summary>
        /// cv::Ptr&lt;T&gt;
        /// </summary>
        internal Ptr ObjectPtr { get; }

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected DetectorParameters(IntPtr p)
        {
            ObjectPtr = new Ptr(p);
            ptr = ObjectPtr.Get();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DetectorParameters Create()
        {
            var param = NativeMethods.aruco_DetectorParameters_create();
            return new DetectorParameters(param);
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            base.DisposeManaged();
        }

        #endregion

        #region Properties

        /// <summary>
        /// minimum window size for adaptive thresholding before finding contours (default 3).
        /// </summary>
        public int AdaptiveThreshWinSizeMin
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getAdaptiveThreshWinSizeMin(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setAdaptiveThreshWinSizeMin(ptr, value);
            }
        }

        /// <summary>
        /// adaptiveThreshWinSizeMax: maximum window size for adaptive thresholding before finding contours(default 23).
        /// </summary>
        public int AdaptiveThreshWinSizeMax
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getAdaptiveThreshWinSizeMax(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setAdaptiveThreshWinSizeMax(ptr, value);
            }
        }

        /// <summary>
        /// increments from adaptiveThreshWinSizeMin to adaptiveThreshWinSizeMax during the thresholding(default 10).
        /// </summary>
        public int AdaptiveThreshWinSizeStep
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getAdaptiveThreshWinSizeStep(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setAdaptiveThreshWinSizeStep(ptr, value);
            }
        }

        /// <summary>
        /// constant for adaptive thresholding before finding contours (default 7)
        /// </summary>
        public double AdaptiveThreshConstant
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getAdaptiveThreshConstant(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setAdaptiveThreshConstant(ptr, value);
            }
        }

        /// <summary>
        /// determine minimum perimeter for marker contour to be detected. 
        /// This is defined as a rate respect to the maximum dimension of the input image(default 0.03).
        /// </summary>
        public double MinMarkerPerimeterRate
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getMinMarkerPerimeterRate(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setMinMarkerPerimeterRate(ptr, value);
            }
        }

        /// <summary>
        ///  determine maximum perimeter for marker contour to be detected. 
        /// This is defined as a rate respect to the maximum dimension of the input image(default 4.0).
        /// </summary>
        public double MaxMarkerPerimeterRate
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getMaxMarkerPerimeterRate(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setMaxMarkerPerimeterRate(ptr, value);
            }
        }

        /// <summary>
        /// minimum accuracy during the polygonal approximation process to determine which contours are squares.
        /// </summary>
        public double PolygonalApproxAccuracyRate
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getPolygonalApproxAccuracyRate(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setPolygonalApproxAccuracyRate(ptr, value);
            }
        }

        /// <summary>
        /// minimum distance between corners for detected markers relative to its perimeter(default 0.05)
        /// </summary>
        public double MinCornerDistanceRate
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getMinCornerDistanceRate(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setMinCornerDistanceRate(ptr, value);
            }
        }

        /// <summary>
        ///  minimum distance of any corner to the image border for detected markers (in pixels) (default 3)
        /// </summary>
        public int MinDistanceToBorder
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getMinDistanceToBorder(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setMinDistanceToBorder(ptr, value);
            }
        }

        /// <summary>
        /// minimum mean distance beetween two marker corners to be considered similar, 
        /// so that the smaller one is removed.The rate is relative to the smaller perimeter of the two markers(default 0.05).
        /// </summary>
        public double MinMarkerDistanceRate
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getMinMarkerDistanceRate(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setMinMarkerDistanceRate(ptr, value);
            }
        }

        /// <summary>
        /// do subpixel refinement or not
        /// </summary>
        public bool DoCornerRefinement
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getDoCornerRefinement(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setDoCornerRefinement(ptr, value);
            }
        }

        /// <summary>
        /// window size for the corner refinement process (in pixels) (default 5).
        /// </summary>
        public int CornerRefinementWinSize
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getCornerRefinementWinSize(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setCornerRefinementWinSize(ptr, value);
            }
        }

        /// <summary>
        /// maximum number of iterations for stop criteria of the corner refinement process(default 30).
        /// </summary>
        public int CornerRefinementMaxIterations
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getCornerRefinementMaxIterations(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setCornerRefinementMaxIterations(ptr, value);
            }
        }

        /// <summary>
        /// minimum error for the stop cristeria of the corner refinement process(default: 0.1)
        /// </summary>
        public double CornerRefinementMinAccuracy
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getCornerRefinementMinAccuracy(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setCornerRefinementMinAccuracy(ptr, value);
            }
        }

        /// <summary>
        /// number of bits of the marker border, i.e. marker border width (default 1).
        /// </summary>
        public int MarkerBorderBits
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getMarkerBorderBits(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setMarkerBorderBits(ptr, value);
            }
        }

        /// <summary>
        /// number of bits (per dimension) for each cell of the marker when removing the perspective(default 8).
        /// </summary>
        public int PerspectiveRemovePixelPerCell
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getPerspectiveRemovePixelPerCell(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setPerspectiveRemovePixelPerCell(ptr, value);
            }
        }

        /// <summary>
        /// width of the margin of pixels on each cell not considered for the determination 
        /// of the cell bit.Represents the rate respect to the total  size of the cell, 
        /// i.e.perpectiveRemovePixelPerCell (default 0.13)
        /// </summary>
        public double PerspectiveRemoveIgnoredMarginPerCell
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getPerspectiveRemoveIgnoredMarginPerCell(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setPerspectiveRemoveIgnoredMarginPerCell(ptr, value);
            }
        }

        /// <summary>
        /// maximum number of accepted erroneous bits in the border 
        /// (i.e. number of allowed white bits in the border). Represented as a rate respect to the total 
        /// number of bits per marker(default 0.35).
        /// </summary>
        public double MaxErroneousBitsInBorderRate
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getMaxErroneousBitsInBorderRate(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setMaxErroneousBitsInBorderRate(ptr, value);
            }
        }

        /// <summary>
        /// minimun standard deviation in pixels values during the decodification step to
        ///  apply Otsu thresholding(otherwise, all the bits are set to 0 or 1 depending on mean higher than 128 or not) (default 5.0)
        /// </summary>
        public double MinOtsuStdDev
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getMinOtsuStdDev(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setMinOtsuStdDev(ptr, value);
            }
        }

        /// <summary>
        /// errorCorrectionRate error correction rate respect to the maximun error correction capability for each dictionary. (default 0.6).
        /// </summary>
        public double ErrorCorrectionRate
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.aruco_DetectorParameters_getErrorCorrectionRate(ptr);
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setErrorCorrectionRate(ptr, value);
            }
        }

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.aruco_Ptr_DetectorParameters_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.aruco_Ptr_DetectorParameters_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
