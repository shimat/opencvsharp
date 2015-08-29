using System;

namespace OpenCvSharp
{
    // ReSharper disable once InconsistentNaming

    /// <summary>
    /// Implementation of the Shape Context descriptor and matching algorithm
    /// </summary>
    /// <remarks>
    /// proposed by Belongie et al. in "Shape Matching and Object Recognition Using Shape Contexts" 
    /// (PAMI2002). This implementation is packaged in a generic scheme, in order to allow 
    /// you the implementation of the common variations of the original pipeline.
    /// </remarks>
    public class ShapeContextDistanceExtractor : ShapeDistanceExtractor
    {
        private bool disposed;
        private Ptr<ShapeContextDistanceExtractor> ptrObj;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected ShapeContextDistanceExtractor(IntPtr p)
        {
            ptrObj = new Ptr<ShapeContextDistanceExtractor>(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Complete constructor
        /// </summary>
        /// <param name="nAngularBins">The number of angular bins in the shape context descriptor.</param>
        /// <param name="nRadialBins">The number of radial bins in the shape context descriptor.</param>
        /// <param name="innerRadius">The value of the inner radius.</param>
        /// <param name="outerRadius">The value of the outer radius.</param>
        /// <param name="iterations"></param>
        /// <returns></returns>
        public static ShapeContextDistanceExtractor Create(
            int nAngularBins = 12, int nRadialBins = 4, float innerRadius = 0.2f,
            float outerRadius = 2, int iterations = 3)
        {
            IntPtr ptr = NativeMethods.shape_createShapeContextDistanceExtractor(
                nAngularBins, nRadialBins, innerRadius, outerRadius, iterations);
            return new ShapeContextDistanceExtractor(ptr);
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
                    ptr = IntPtr.Zero;
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
        /// The number of angular bins in the shape context descriptor.
        /// </summary>
        public int AngularBins 
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.shape_ShapeContextDistanceExtractor_getAngularBins(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.shape_ShapeContextDistanceExtractor_setAngularBins(ptr, value);
            }
        }

        /// <summary>
        /// The number of radial bins in the shape context descriptor.
        /// </summary>
        public int RadialBins 
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.shape_ShapeContextDistanceExtractor_getRadialBins(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.shape_ShapeContextDistanceExtractor_setRadialBins(ptr, value);
            }
        }

        /// <summary>
        /// The value of the inner radius.
        /// </summary>
        public float InnerRadius 
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.shape_ShapeContextDistanceExtractor_getInnerRadius(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.shape_ShapeContextDistanceExtractor_setInnerRadius(ptr, value);
            }
        }

        /// <summary>
        /// The value of the outer radius.
        /// </summary>
        public float OuterRadius 
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.shape_ShapeContextDistanceExtractor_getOuterRadius(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.shape_ShapeContextDistanceExtractor_setOuterRadius(ptr, value);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool RotationInvariant 
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.shape_ShapeContextDistanceExtractor_getRotationInvariant(ptr) != 0;
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.shape_ShapeContextDistanceExtractor_setRotationInvariant(ptr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// The weight of the shape context distance in the final distance value.
        /// </summary>
        public float ShapeContextWeight 
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.shape_ShapeContextDistanceExtractor_getShapeContextWeight(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.shape_ShapeContextDistanceExtractor_setShapeContextWeight(ptr, value);
            }
        }

        /// <summary>
        /// The weight of the appearance cost in the final distance value.
        /// </summary>
        public float ImageAppearanceWeight 
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.shape_ShapeContextDistanceExtractor_getImageAppearanceWeight(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.shape_ShapeContextDistanceExtractor_setImageAppearanceWeight(ptr, value);
            }
        }

        /// <summary>
        /// The weight of the Bending Energy in the final distance value.
        /// </summary>
        public float BendingEnergyWeight
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.shape_ShapeContextDistanceExtractor_getBendingEnergyWeight(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.shape_ShapeContextDistanceExtractor_setBendingEnergyWeight(ptr, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Iterations
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.shape_ShapeContextDistanceExtractor_getIterations(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.shape_ShapeContextDistanceExtractor_setIterations(ptr, value);
            }
        }

        /// <summary>
        /// The value of the standard deviation for the Gaussian window for the image appearance cost.
        /// </summary>
        public float StdDev
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.shape_ShapeContextDistanceExtractor_getStdDev(ptr);
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.shape_ShapeContextDistanceExtractor_setStdDev(ptr, value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Set the images that correspond to each shape. 
        /// This images are used in the calculation of the Image Appearance cost.
        /// </summary>
        /// <param name="image1">Image corresponding to the shape defined by contours1.</param>
        /// <param name="image2">Image corresponding to the shape defined by contours2.</param>
        public void SetImages(InputArray image1, InputArray image2)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (image1 == null)
                throw new ArgumentNullException("image1");
            if (image2 == null)
                throw new ArgumentNullException("image2");
            image1.ThrowIfDisposed();
            image2.ThrowIfDisposed();
            NativeMethods.shape_ShapeContextDistanceExtractor_setImages(ptr, image1.CvPtr, image2.CvPtr);
            GC.KeepAlive(image1);
            GC.KeepAlive(image2);
        }

        /// <summary>
        /// Get the images that correspond to each shape. 
        /// This images are used in the calculation of the Image Appearance cost.
        /// </summary>
        /// <param name="image1">Image corresponding to the shape defined by contours1.</param>
        /// <param name="image2">Image corresponding to the shape defined by contours2.</param>
        public void GetImages(OutputArray image1, OutputArray image2)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (image1 == null)
                throw new ArgumentNullException("image1");
            if (image2 == null)
                throw new ArgumentNullException("image2");
            image1.ThrowIfNotReady();
            image2.ThrowIfNotReady();
            NativeMethods.shape_ShapeContextDistanceExtractor_getImages(ptr, image1.CvPtr, image2.CvPtr);
            image1.Fix();
            image2.Fix();
        }

        #endregion
    }
}
