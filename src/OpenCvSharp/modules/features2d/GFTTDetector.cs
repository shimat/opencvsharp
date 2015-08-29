using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
    // ReSharper disable once InconsistentNaming

    /// <summary>
    /// Good Features To Track Detector
    /// </summary>
    public class GFTTDetector : Feature2D
    {
        private bool disposed;
        private Ptr<GFTTDetector> ptrObj;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxCorners"></param>
        /// <param name="qualityLevel"></param>
        /// <param name="minDistance"></param>
        /// <param name="blockSize"></param>
        /// <param name="useHarrisDetector"></param>
        /// <param name="k"></param>
        public static GFTTDetector Create(
            int maxCorners = 1000, double qualityLevel = 0.01, double minDistance = 1,
            int blockSize = 3, bool useHarrisDetector = false, double k = 0.04)
        {
            IntPtr ptr = NativeMethods.features2d_GFTTDetector_create(
                maxCorners, qualityLevel, minDistance, 
                blockSize, useHarrisDetector ? 1 : 0, k);
            return new GFTTDetector(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        protected GFTTDetector(IntPtr p)
        {
            ptrObj = new Ptr<GFTTDetector>(p);
            ptr = ptrObj.Get();
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
                        if (ptrObj != null)
                        {
                            ptrObj.Dispose();
                            ptrObj = null;
                        }
                    }
                    // releases unmanaged resources
                    
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int MaxFeatures
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_GFTTDetector_getMaxFeatures(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_GFTTDetector_setMaxFeatures(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double QualityLevel
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_GFTTDetector_getQualityLevel(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_GFTTDetector_setQualityLevel(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double MinDistance
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_GFTTDetector_getMinDistance(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_GFTTDetector_setMinDistance(ptr, value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public int BlockSize
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_GFTTDetector_getBlockSize(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_GFTTDetector_setBlockSize(ptr, value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public bool HarrisDetector
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_GFTTDetector_getHarrisDetector(ptr) != 0;
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_GFTTDetector_setHarrisDetector(ptr, value ? 1 : 0);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public double K
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_GFTTDetector_getK(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.features2d_GFTTDetector_setK(ptr, value);
            }
        }

        #endregion

        #region Methods

        #endregion
    }
}
