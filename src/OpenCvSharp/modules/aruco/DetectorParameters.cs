using System;

namespace OpenCvSharp
{
    public class DetectorParameters : DisposableCvObject
    {
        /// <summary>
        /// cv::Ptr&lt;T&gt;
        /// </summary>
        private Ptr objectPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected DetectorParameters(IntPtr p)
        {
            objectPtr = new Ptr(p);
            ptr = objectPtr.Get();
        }

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

        internal new class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.aruco_Ptr_Dictionary_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.aruco_Ptr_Dictionary_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
