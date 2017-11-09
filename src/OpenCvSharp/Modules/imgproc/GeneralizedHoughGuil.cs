using System;

namespace OpenCvSharp
{
    /// <summary>
    /// Guil, N., González-Linares, J.M. and Zapata, E.L. (1999). 
    /// Bidimensional shape detection using an invariant approach. 
    /// Pattern Recognition 32 (6): 1025-1038.
    /// Detects position, traslation and rotation
    /// </summary>
    public class GeneralizedHoughGuil : GeneralizedHough
    {
        /// <summary>
        /// cv::Ptr&lt;T&gt; object
        /// </summary>
        private Ptr ptrObj;

        /// <summary>
        /// 
        /// </summary>
        private GeneralizedHoughGuil(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates a predefined GeneralizedHoughBallard object
        /// </summary>
        /// <returns></returns>
        public static GeneralizedHoughGuil Create()
        {
            IntPtr ptr = NativeMethods.imgproc_createGeneralizedHoughGuil();
            return new GeneralizedHoughGuil(ptr);
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            ptrObj?.Dispose();
            ptrObj = null;
            base.DisposeManaged();
        }

        /// <summary>
        /// Angle difference in degrees between two points in feature.
        /// </summary>
        /// <returns></returns>
        public double Xi
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_GeneralizedHoughGuil_getXi(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.imgproc_GeneralizedHoughGuil_setXi(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Feature table levels.
        /// </summary>
        /// <returns></returns>
        public int Levels
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_GeneralizedHoughGuil_getLevels(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.imgproc_GeneralizedHoughGuil_setLevels(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Maximal difference between angles that treated as equal.
        /// </summary>
        /// <returns></returns>
        public double AngleEpsilon
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_GeneralizedHoughGuil_getAngleEpsilon(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.imgproc_GeneralizedHoughGuil_setAngleEpsilon(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Minimal rotation angle to detect in degrees.
        /// </summary>
        /// <returns></returns>
        public double MinAngle
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_GeneralizedHoughGuil_getMinAngle(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.imgproc_GeneralizedHoughGuil_setMinAngle(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Maximal rotation angle to detect in degrees.
        /// </summary>
        /// <returns></returns>
        public double MaxAngle
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_GeneralizedHoughGuil_getMaxAngle(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.imgproc_GeneralizedHoughGuil_setMaxAngle(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Angle step in degrees.
        /// </summary>
        /// <returns></returns>
        public double AngleStep
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_GeneralizedHoughGuil_getAngleStep(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.imgproc_GeneralizedHoughGuil_setAngleStep(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Angle votes threshold.
        /// </summary>
        /// <returns></returns>
        public int AngleThresh
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_GeneralizedHoughGuil_getAngleThresh(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.imgproc_GeneralizedHoughGuil_setAngleThresh(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Minimal scale to detect.
        /// </summary>
        /// <returns></returns>
        public double MinScale
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_GeneralizedHoughGuil_getMinScale(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.imgproc_GeneralizedHoughGuil_setMinScale(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Maximal scale to detect.
        /// </summary>
        /// <returns></returns>
        public double MaxScale
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_GeneralizedHoughGuil_getMaxScale(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.imgproc_GeneralizedHoughGuil_setMaxScale(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Scale step.
        /// </summary>
        /// <returns></returns>
        public double ScaleStep
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_GeneralizedHoughGuil_getScaleStep(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.imgproc_GeneralizedHoughGuil_setScaleStep(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Scale votes threshold.
        /// </summary>
        /// <returns></returns>
        public int ScaleThresh
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_GeneralizedHoughGuil_getScaleThresh(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.imgproc_GeneralizedHoughGuil_setScaleThresh(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Position votes threshold.
        /// </summary>
        /// <returns></returns>
        public int PosThresh
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.imgproc_GeneralizedHoughGuil_getPosThresh(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.imgproc_GeneralizedHoughGuil_setPosThresh(ptr, value);
                GC.KeepAlive(this);
            }
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.imgproc_Ptr_GeneralizedHoughGuil_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.imgproc_Ptr_GeneralizedHoughBallard_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
