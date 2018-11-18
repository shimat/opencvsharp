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
                var res = NativeMethods.aruco_DetectorParameters_getAdaptiveThreshWinSizeMin(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setAdaptiveThreshWinSizeMin(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_DetectorParameters_getAdaptiveThreshWinSizeMax(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setAdaptiveThreshWinSizeMax(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_DetectorParameters_getAdaptiveThreshWinSizeStep(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setAdaptiveThreshWinSizeStep(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_DetectorParameters_getAdaptiveThreshConstant(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setAdaptiveThreshConstant(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_DetectorParameters_getMinMarkerPerimeterRate(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setMinMarkerPerimeterRate(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_DetectorParameters_getMaxMarkerPerimeterRate(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setMaxMarkerPerimeterRate(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_DetectorParameters_getPolygonalApproxAccuracyRate(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setPolygonalApproxAccuracyRate(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_DetectorParameters_getMinCornerDistanceRate(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setMinCornerDistanceRate(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_DetectorParameters_getMinDistanceToBorder(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setMinDistanceToBorder(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_DetectorParameters_getMinMarkerDistanceRate(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setMinMarkerDistanceRate(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// corner refinement method.
        /// (CORNER_REFINE_NONE, no refinement. CORNER_REFINE_SUBPIX, do subpixel refinement. CORNER_REFINE_CONTOUR use contour-Points)
        /// </summary>
        public CornerRefineMethod CornerRefinementMethod
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.aruco_DetectorParameters_getCornerRefinementMethod(ptr);
                GC.KeepAlive(this);
                return (CornerRefineMethod)res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setCornerRefinementMethod(ptr, (int)value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_DetectorParameters_getCornerRefinementWinSize(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setCornerRefinementWinSize(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_DetectorParameters_getCornerRefinementMaxIterations(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setCornerRefinementMaxIterations(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_DetectorParameters_getCornerRefinementMinAccuracy(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setCornerRefinementMinAccuracy(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_DetectorParameters_getMarkerBorderBits(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setMarkerBorderBits(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_DetectorParameters_getPerspectiveRemovePixelPerCell(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setPerspectiveRemovePixelPerCell(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_DetectorParameters_getPerspectiveRemoveIgnoredMarginPerCell(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setPerspectiveRemoveIgnoredMarginPerCell(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_DetectorParameters_getMaxErroneousBitsInBorderRate(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setMaxErroneousBitsInBorderRate(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_DetectorParameters_getMinOtsuStdDev(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setMinOtsuStdDev(ptr, value);
                GC.KeepAlive(this);
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
                var res =  NativeMethods.aruco_DetectorParameters_getErrorCorrectionRate(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.aruco_DetectorParameters_setErrorCorrectionRate(ptr, value);
                GC.KeepAlive(this);
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
                var res = NativeMethods.aruco_Ptr_DetectorParameters_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.aruco_Ptr_DetectorParameters_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
