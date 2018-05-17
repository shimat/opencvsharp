using System;

namespace OpenCvSharp.XImgProc
{
    /// <summary>
    /// Helper class for training part of [P. Dollar and C. L. Zitnick. Structured Forests for Fast Edge Detection, 2013].
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class RFFeatureGetter : Algorithm
    {
        internal Ptr PtrObj { get; private set; }

        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected RFFeatureGetter(IntPtr p)
        {
            PtrObj = new Ptr(p);
            ptr = PtrObj.Get();
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            PtrObj?.Dispose();
            PtrObj = null;
            base.DisposeManaged();
        }

        /// <summary>
        /// Creates a RFFeatureGetter
        /// </summary>
        /// <returns></returns>
        public static RFFeatureGetter Create()
        {
            IntPtr p = NativeMethods.ximgproc_createRFFeatureGetter();
            return new RFFeatureGetter(p);
        }

        /// <summary>
        /// Extracts feature channels from src.
        /// Than StructureEdgeDetection uses this feature space to detect edges.
        /// </summary>
        /// <param name="src">source image to extract features</param>
        /// <param name="features">output n-channel floating point feature matrix.</param>
        /// <param name="gnrmRad">gradientNormalizationRadius</param>
        /// <param name="gsmthRad">gradientSmoothingRadius</param>
        /// <param name="shrink">shrinkNumber</param>
        /// <param name="outNum">numberOfOutputChannels</param>
        /// <param name="gradNum">numberOfGradientOrientations</param>
        public virtual void GetFeatures(Mat src, Mat features,
            int gnrmRad,
            int gsmthRad,
            int shrink,
            int outNum,
            int gradNum)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (features == null)
                throw new ArgumentNullException(nameof(features));
            src.ThrowIfDisposed();
            features.ThrowIfDisposed();
            
            NativeMethods.ximgproc_RFFeatureGetter_getFeatures(
                ptr, src.CvPtr, features.CvPtr, gnrmRad, gsmthRad, shrink, outNum, gradNum);

            GC.KeepAlive(this);
            GC.KeepAlive(src);
            GC.KeepAlive(features);
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.ximgproc_Ptr_RFFeatureGetter_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.ximgproc_Ptr_RFFeatureGetter_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
