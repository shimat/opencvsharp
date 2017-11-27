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
        private Ptr ptrObj;

        //internal override IntPtr PtrObj => ptrObj.CvPtr;

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
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
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

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int MaxFeatures
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.features2d_GFTTDetector_getMaxFeatures(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_GFTTDetector_setMaxFeatures(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double QualityLevel
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.features2d_GFTTDetector_getQualityLevel(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_GFTTDetector_setQualityLevel(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double MinDistance
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.features2d_GFTTDetector_getMinDistance(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_GFTTDetector_setMinDistance(ptr, value);
                GC.KeepAlive(this);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public int BlockSize
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.features2d_GFTTDetector_getBlockSize(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_GFTTDetector_setBlockSize(ptr, value);
                GC.KeepAlive(this);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public bool HarrisDetector
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.features2d_GFTTDetector_getHarrisDetector(ptr) != 0;
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_GFTTDetector_setHarrisDetector(ptr, value ? 1 : 0);
                GC.KeepAlive(this);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public double K
        {
            get
            {
                ThrowIfDisposed();
                var res = NativeMethods.features2d_GFTTDetector_getK(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.features2d_GFTTDetector_setK(ptr, value);
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
                var res = NativeMethods.features2d_Ptr_GFTTDetector_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.features2d_Ptr_GFTTDetector_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
