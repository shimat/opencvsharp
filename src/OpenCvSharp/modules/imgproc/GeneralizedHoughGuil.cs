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
        private bool disposed;

        /// <summary>
        /// cv::Ptr&lt;T&gt; object
        /// </summary>
        private Ptr<GeneralizedHoughGuil> ptrObj;

        /// <summary>
        /// 
        /// </summary>
        private GeneralizedHoughGuil(IntPtr p)
        {
            ptrObj = new Ptr<GeneralizedHoughGuil>(p);
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

#if LANG_JP
    /// <summary>
    /// リソースの解放
    /// </summary>
    /// <param name="disposing">
    /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
    /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
    ///</param>
#else
        /// <summary>
        /// Releases the resources
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    // releases managed resources
                    if (disposing)
                    {
                    }
                    // releases unmanaged resources
                    if (IsEnabledDispose)
                    {
                        if (ptrObj != null)
                            ptrObj.Dispose();
                        ptrObj = null;
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        /// <summary>
        /// Angle difference in degrees between two points in feature.
        /// </summary>
        /// <returns></returns>
        public double Xi
        {
            get
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHoughGuil_getXi(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHoughGuil_setXi(ptr, value);
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
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHoughGuil_getLevels(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHoughGuil_setLevels(ptr, value);
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
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHoughGuil_getAngleEpsilon(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHoughGuil_setAngleEpsilon(ptr, value);
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
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHoughGuil_getMinAngle(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHoughGuil_setMinAngle(ptr, value);
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
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHoughGuil_getMaxAngle(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHoughGuil_setMaxAngle(ptr, value);
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
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHoughGuil_getAngleStep(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHoughGuil_setAngleStep(ptr, value);
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
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHoughGuil_getAngleThresh(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHoughGuil_setAngleThresh(ptr, value);
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
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHoughGuil_getMinScale(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHoughGuil_setMinScale(ptr, value);
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
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHoughGuil_getMaxScale(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHoughGuil_setMaxScale(ptr, value);
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
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHoughGuil_getScaleStep(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHoughGuil_setScaleStep(ptr, value);
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
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHoughGuil_getScaleThresh(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHoughGuil_setScaleThresh(ptr, value);
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
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHoughGuil_getPosThresh(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHoughGuil_setPosThresh(ptr, value);
            }
        }
    }
}
