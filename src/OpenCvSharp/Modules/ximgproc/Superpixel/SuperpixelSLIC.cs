using System;

// ReSharper disable once CheckNamespace
namespace OpenCvSharp.XImgProc
{
    /// <summary>
    /// Class implementing the SLIC (Simple Linear Iterative Clustering) superpixels
    /// algorithm described in @cite Achanta2012.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once IdentifierTypo
    public class SuperpixelSLIC : Algorithm
    {
        private Ptr? detectorPtr;

        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected SuperpixelSLIC(IntPtr p)
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
        /// Initialize a SuperpixelSLIC object.
        ///
        /// The function initializes a SuperpixelSLIC object for the input image. It sets the parameters of chosen
        /// superpixel algorithm, which are: region_size and ruler.It preallocate some buffers for future
        /// computing iterations over the given image.For enanched results it is recommended for color images to
        /// preprocess image with little gaussian blur using a small 3 x 3 kernel and additional conversion into
        /// CieLAB color space.An example of SLIC versus SLICO and MSLIC is ilustrated in the following picture.
        /// </summary>
        /// <param name="image">Image to segment</param>
        /// <param name="algorithm">Chooses the algorithm variant to use:
        /// SLIC segments image using a desired region_size, and in addition SLICO will optimize using adaptive compactness factor,
        /// while MSLIC will optimize using manifold methods resulting in more content-sensitive superpixels.</param>
        /// <param name="regionSize">Chooses an average superpixel size measured in pixels</param>
        /// <param name="ruler">Chooses the enforcement of superpixel smoothness factor of superpixel</param>
        /// <returns></returns>
        public static SuperpixelSLIC Create(
            InputArray image,
            SLICType algorithm = SLICType.SLICO,
            int regionSize = 10, 
            float ruler = 10.0f)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_createSuperpixelSLIC(
                    image.CvPtr, (int)algorithm, regionSize, ruler, out var p));
            
            GC.KeepAlive(image); 
            return new SuperpixelSLIC(p);
        }

        /// <summary>
        /// Calculates the actual amount of superpixels on a given segmentation computed
        /// and stored in SuperpixelSLIC object.
        /// </summary>
        /// <returns></returns>
        public virtual int GetNumberOfSuperpixels()
        {
            ThrowIfDisposed(); 
            NativeMethods.HandleException(
                NativeMethods.ximgproc_SuperpixelSLIC_getNumberOfSuperpixels(
                    ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// Calculates the superpixel segmentation on a given image with the initialized
        /// parameters in the SuperpixelSLIC object.
        ///
        /// This function can be called again without the need of initializing the algorithm with
        /// createSuperpixelSLIC(). This save the computational cost of allocating memory for all the
        /// structures of the algorithm.
        ///
        /// The function computes the superpixels segmentation of an image with the parameters initialized
        /// with the function createSuperpixelSLIC(). The algorithms starts from a grid of superpixels and
        /// then refines the boundaries by proposing updates of edges boundaries.
        /// </summary>
        /// <param name="numIterations">Number of iterations. Higher number improves the result.</param>
        public virtual void Iterate(int numIterations = 10)
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_SuperpixelSLIC_iterate(
                    ptr, numIterations));
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Returns the segmentation labeling of the image.
        /// Each label represents a superpixel, and each pixel is assigned to one superpixel label.
        ///
        /// The function returns an image with the labels of the superpixel segmentation. The labels are in
        /// the range[0, getNumberOfSuperpixels()].
        /// </summary>
        /// <param name="labelsOut"></param>
        public virtual void GetLabels(OutputArray labelsOut)
        {
            ThrowIfDisposed();
            if (labelsOut == null)
                throw new ArgumentNullException(nameof(labelsOut));
            labelsOut.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_SuperpixelSLIC_getLabels(
                    ptr, labelsOut.CvPtr));
            GC.KeepAlive(this);
            labelsOut.Fix();
        }

        /// <summary>
        /// Returns the mask of the superpixel segmentation stored in SuperpixelSLIC object.
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
                NativeMethods.ximgproc_SuperpixelSLIC_getLabelContourMask(
                    ptr, image.CvPtr, thickLine ? 1 : 0));
            GC.KeepAlive(this);
            image.Fix();
        }

        /// <summary>
        /// Enforce label connectivity.
        ///
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
                NativeMethods.ximgproc_SuperpixelSLIC_enforceLabelConnectivity(
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
                    NativeMethods.ximgproc_Ptr_SuperpixelSLIC_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_Ptr_SuperpixelSLIC_delete(ptr));
                base.DisposeUnmanaged();
            }
        }
    }
}
