using System;

namespace OpenCvSharp.XPhoto
{
    /// <summary>
    /// More sophisticated learning-based automatic white balance algorithm.
    /// </summary>
    public class LearningBasedWB : WhiteBalancer
    {

        private Ptr ptrObj;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        internal LearningBasedWB(IntPtr p)
        {
            this.ptrObj = new Ptr(p);
            this.ptr = this.ptrObj.Get();
        }

        /// <summary>
        /// Creates an instance of LearningBasedWB
        /// </summary>
        /// <param name="model">Path to a .yml file with the model. If not specified, the default model is used</param>
        /// <returns></returns>
        public static LearningBasedWB Create(string model)
        {
            var ptr = NativeMethods.xphoto_createLearningBasedWB(model ?? "");
            return new LearningBasedWB(ptr);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Defines the size of one dimension of a three-dimensional RGB histogram that is used internally by the algorithm. It often makes sense to increase the number of bins for images with higher bit depth (e.g. 256 bins for a 12 bit image).
        /// </summary>
        public int HistBinNum
        {
            get
            {
                this.ThrowIfDisposed();
                var res = NativeMethods.xphoto_LearningBasedWB_HistBinNum_get(this.ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.xphoto_LearningBasedWB_HistBinNum_set(this.ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Maximum possible value of the input image (e.g. 255 for 8 bit images, 4095 for 12 bit images)
        /// </summary>
        public int RangeMaxVal
        {
            get
            {
                this.ThrowIfDisposed();
                var res = NativeMethods.xphoto_LearningBasedWB_RangeMaxVal_get(this.ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.xphoto_LearningBasedWB_RangeMaxVal_set(this.ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Threshold that is used to determine saturated pixels, i.e. pixels where at least one of the channels exceeds 
        /// </summary>
        public float SaturationThreshold
        {
            get
            {
                this.ThrowIfDisposed();
                var res = NativeMethods.xphoto_LearningBasedWB_SaturationThreshold_get(this.ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.xphoto_LearningBasedWB_SaturationThreshold_set(this.ptr, value);
                GC.KeepAlive(this);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Applies white balancing to the input image.
        /// </summary>
        /// <param name="src">Input image</param>
        /// <param name="dst">White balancing result</param>
        public override void BalanceWhite(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.xphoto_LearningBasedWB_balanceWhite(this.ptr, src.CvPtr, dst.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Implements the feature extraction part of the algorithm.
        /// </summary>
        /// <param name="src">Input three-channel image (BGR color space is assumed).</param>
        /// <param name="dst">An array of four (r,g) chromaticity tuples corresponding to the features listed above.</param>
        public void ExtractSimpleFeatures(InputArray src, OutputArray dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.xphoto_LearningBasedWB_extractSimpleFeatures(this.ptr, src.CvPtr, dst.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr)
                : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.xphoto_Ptr_LearningBasedWB_get(this.ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.xphoto_Ptr_LearningBasedWB_delete(this.ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}