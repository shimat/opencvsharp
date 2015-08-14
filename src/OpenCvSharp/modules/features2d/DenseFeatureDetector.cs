using System;

namespace OpenCvSharp
{
#if false
    /// <summary>
    /// Class for generation of image features which are 
    /// distributed densely and regularly over the image.
    /// </summary>
    public class DenseFeatureDetector : FeatureDetector
    {
        private bool disposed;
        private Ptr<DenseFeatureDetector> detectorPtr;

        #region Init & Disposal
        /// <summary>
        /// The detector generates several levels (in the amount of featureScaleLevels) of features. 
        /// Features of each level are located in the nodes of a regular grid over the image 
        /// (excluding the image boundary of given size). The level parameters (a feature scale, 
        /// a node size, a size of boundary) are multiplied by featureScaleMul with level index 
        /// growing depending on input flags, viz.:
        /// </summary>
        /// <param name="initFeatureScale"></param>
        /// <param name="featureScaleLevels"></param>
        /// <param name="featureScaleMul"></param>
        /// <param name="initXyStep"></param>
        /// <param name="initImgBound"></param>
        /// <param name="varyXyStepWithScale">The grid node size is multiplied if this is true.</param>
        /// <param name="varyImgBoundWithScale">Size of image boundary is multiplied if this is true.</param>
        public DenseFeatureDetector( float initFeatureScale=1.0f, int featureScaleLevels=1,
                                   float featureScaleMul=0.1f,
                                   int initXyStep=6, int initImgBound=0,
                                   bool varyXyStepWithScale=true,
                                   bool varyImgBoundWithScale=false )
        {
            ptr = NativeMethods.features2d_DenseFeatureDetector_new(
                initFeatureScale, featureScaleLevels, featureScaleMul,initXyStep, initImgBound, 
                varyXyStepWithScale ? 1 : 0, varyImgBoundWithScale ? 1 : 0);
        }

        /// <summary>
        /// Creates instance by cv::Ptr&lt;cv::SURF&gt;
        /// </summary>
        internal DenseFeatureDetector(Ptr<DenseFeatureDetector> detectorPtr)
        {
            this.detectorPtr = detectorPtr;
            this.ptr = detectorPtr.Get();
        }
        /// <summary>
        /// Creates instance by raw pointer cv::SURF*
        /// </summary>
        internal DenseFeatureDetector(IntPtr rawPtr)
        {
            detectorPtr = null;
            ptr = rawPtr;
        }
        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static new DenseFeatureDetector FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid cv::Ptr<DenseFeatureDetector> pointer");
            var ptrObj = new Ptr<DenseFeatureDetector>(ptr);
            return new DenseFeatureDetector(ptrObj);
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
                    if (detectorPtr != null)
                    {
                        detectorPtr.Dispose();
                        detectorPtr = null;
                    }
                    else
                    {
                        if (ptr != IntPtr.Zero)
                            NativeMethods.features2d_DenseFeatureDetector_delete(ptr);
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
        #endregion

        /// <summary>
        /// Pointer to algorithm information (cv::AlgorithmInfo*)
        /// </summary>
        /// <returns></returns>
        public override IntPtr InfoPtr
        {
            get
            {
                return NativeMethods.features2d_DenseFeatureDetector_info(ptr);
            }
        }
    }
#endif
}
