using System;

// ReSharper disable once CheckNamespace
namespace OpenCvSharp.XImgProc
{
    /// <summary>
    /// Class implementing the LSC (Linear Spectral Clustering) superpixels
    /// algorithm described in @cite LiCVPR2015LSC.
    ///
    /// LSC(Linear Spectral Clustering) produces compact and uniform superpixels with low
    /// computational costs.Basically, a normalized cuts formulation of the superpixel
    /// segmentation is adopted based on a similarity metric that measures the color
    /// similarity and space proximity between image pixels.LSC is of linear computational
    /// complexity and high memory efficiency and is able to preserve global properties of images.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class SuperpixelLSC : Algorithm
    {
        private Ptr? detectorPtr;

        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected SuperpixelLSC(IntPtr p)
        {
            detectorPtr = new Ptr(p);
            ptr = detectorPtr.Get();
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            detectorPtr?.Dispose();
            detectorPtr = null;
            base.DisposeManaged();
        }

        /// <summary>
        /// Class implementing the LSC (Linear Spectral Clustering) superpixels.
        ///
        /// The function initializes a SuperpixelLSC object for the input image. It sets the parameters of
        /// superpixel algorithm, which are: region_size and ruler.It preallocate some buffers for future
        /// computing iterations over the given image.An example of LSC is illustrated in the following picture.
        /// For enhanced results it is recommended for color images to preprocess image with little gaussian blur
        /// with a small 3 x 3 kernel and additional conversion into CieLAB color space.
        /// </summary>
        /// <param name="image">image Image to segment</param>
        /// <param name="regionSize">Chooses an average superpixel size measured in pixels</param>
        /// <param name="ratio">Chooses the enforcement of superpixel compactness factor of superpixel</param>
        /// <returns></returns>
        public static SuperpixelLSC Create(
            InputArray image, int regionSize = 10, float ratio = 0.075f)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_createSuperpixelLSC(
                    image.CvPtr, regionSize, ratio, out var p));
            
            GC.KeepAlive(image); 
            return new SuperpixelLSC(p);
        }

        /// <summary>
        /// Calculates the actual amount of superpixels on a given segmentation computed and stored in SuperpixelLSC object.
        /// </summary>
        /// <returns></returns>
        public virtual int GetNumberOfSuperpixels()
        {
            ThrowIfDisposed(); 
            NativeMethods.HandleException(
                NativeMethods.ximgproc_SuperpixelLSC_getNumberOfSuperpixels(
                    ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// Calculates the superpixel segmentation on a given image with the initialized
        /// parameters in the SuperpixelLSC object.
        ///
        /// This function can be called again without the need of initializing the algorithm with
        /// createSuperpixelLSC(). This save the computational cost of allocating memory for all the
        /// structures of the algorithm.
        ///
        /// The function computes the superpixels segmentation of an image with the parameters initialized
        /// with the function createSuperpixelLSC(). The algorithms starts from a grid of superpixels and
        /// then refines the boundaries by proposing updates of edges boundaries.
        /// </summary>
        /// <param name="numIterations">Number of iterations. Higher number improves the result.</param>
        public virtual void Iterate(int numIterations = 10)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_SuperpixelLSC_iterate(
                    ptr, numIterations));
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Returns the segmentation labeling of the image.
        /// Each label represents a superpixel, and each pixel is assigned to one superpixel label.
        ///
        /// The function returns an image with the labels of the superpixel segmentation.The labels are in
        /// the range [0, getNumberOfSuperpixels()].
        /// </summary>
        /// <param name="labelsOut">Return: A CV_32SC1 integer array containing the labels of the superpixel
        /// segmentation.The labels are in the range[0, getNumberOfSuperpixels()].</param>
        public virtual void GetLabels(OutputArray labelsOut)
        {
            ThrowIfDisposed();
            if (labelsOut == null)
                throw new ArgumentNullException(nameof(labelsOut));
            labelsOut.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_SuperpixelLSC_getLabels(
                    ptr, labelsOut.CvPtr));
            GC.KeepAlive(this);
            labelsOut.Fix();
        }

        /// <summary>
        /// Returns the mask of the superpixel segmentation stored in SuperpixelLSC object.
        /// The function return the boundaries of the superpixel segmentation.
        /// </summary>
        /// <param name="image">Return: CV_8U1 image mask where -1 indicates that the pixel is a superpixel border, and 0 otherwise.</param>
        /// <param name="thickLine">If false, the border is only one pixel wide, otherwise all pixels at the border are masked.</param>
        public virtual void GetLabelContourMask(OutputArray image, bool thickLine = true)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_SuperpixelLSC_getLabelContourMask(
                    ptr, image.CvPtr, thickLine ? 1 : 0));
            GC.KeepAlive(this);
            image.Fix();
        }

        /// <summary>
        /// Enforce label connectivity.
        /// The function merge component that is too small, assigning the previously found adjacent label
        /// to this component.Calling this function may change the final number of superpixels.
        /// </summary>
        /// <param name="minElementSize">The minimum element size in percents that should be absorbed into a bigger
        /// superpixel.Given resulted average superpixel size valid value should be in 0-100 range, 25 means
        /// that less then a quarter sized superpixel should be absorbed, this is default.</param>
        public virtual void EnforceLabelConnectivity(int minElementSize = 20)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_SuperpixelLSC_enforceLabelConnectivity(
                    ptr, minElementSize));
            GC.KeepAlive(this);
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_Ptr_SuperpixelLSC_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_Ptr_SuperpixelLSC_delete(ptr));
                base.DisposeUnmanaged();
            }
        }
    }
}
