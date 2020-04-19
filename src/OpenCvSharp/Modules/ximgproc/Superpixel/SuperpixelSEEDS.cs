using System;

// ReSharper disable once CheckNamespace
namespace OpenCvSharp.XImgProc
{
    /// <summary>
    /// Class implementing the SEEDS (Superpixels Extracted via Energy-Driven Sampling) superpixels
    /// algorithm described in @cite VBRV14.
    ///
    /// The algorithm uses an efficient hill-climbing algorithm to optimize the superpixels' energy
    /// function that is based on color histograms and a boundary term, which is optional.The energy
    /// function encourages superpixels to be of the same color, and if the boundary term is activated, the
    /// superpixels have smooth boundaries and are of similar shape. In practice it starts from a regular
    /// grid of superpixels and moves the pixels or blocks of pixels at the boundaries to refine the
    /// solution.The algorithm runs in real-time using a single CPU.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class SuperpixelSEEDS : Algorithm
    {
        private Ptr? detectorPtr;

        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected SuperpixelSEEDS(IntPtr p)
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
        /// Initializes a SuperpixelSEEDS object.
        ///
        /// The function initializes a SuperpixelSEEDS object for the input image. It stores the parameters of
        /// the image: image_width, image_height and image_channels.It also sets the parameters of the SEEDS
        /// superpixel algorithm, which are: num_superpixels, num_levels, use_prior, histogram_bins and
        /// double_step.
        ///
        /// The number of levels in num_levels defines the amount of block levels that the algorithm use in the
        /// optimization.The initialization is a grid, in which the superpixels are equally distributed through
        /// the width and the height of the image.The larger blocks correspond to the superpixel size, and the
        /// levels with smaller blocks are formed by dividing the larger blocks into 2 x 2 blocks of pixels,
        /// recursively until the smaller block level. An example of initialization of 4 block levels is
        /// illustrated in the following figure.
        /// </summary>
        /// <param name="imageWidth">Image width.</param>
        /// <param name="imageHeight">Image height.</param>
        /// <param name="imageChannels">Number of channels of the image.</param>
        /// <param name="numSuperpixels">Desired number of superpixels. Note that the actual number may be smaller
        /// due to restrictions(depending on the image size and num_levels). Use getNumberOfSuperpixels() to
        /// get the actual number.</param>
        /// <param name="numLevels">Number of block levels. The more levels, the more accurate is the segmentation,
        /// but needs more memory and CPU time.</param>
        /// <param name="prior">enable 3x3 shape smoothing term if \>0. A larger value leads to smoother shapes. prior
        /// must be in the range[0, 5].</param>
        /// <param name="histogramBins">Number of histogram bins.</param>
        /// <param name="doubleStep">If true, iterate each block level twice for higher accuracy.</param>
        /// <returns></returns>
        public static SuperpixelSEEDS Create(
            int imageWidth, int imageHeight, int imageChannels,
            int numSuperpixels, int numLevels, int prior = 2,
            int histogramBins = 5, bool doubleStep = false)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_createSuperpixelSEEDS(
                    imageWidth, imageHeight, imageChannels, numSuperpixels, numLevels, prior,
                    histogramBins, doubleStep ? 1 : 0, out var p));
             
            return new SuperpixelSEEDS(p);
        }

        /// <summary>
        /// Calculates the superpixel segmentation on a given image stored in SuperpixelSEEDS object.
        ///
        /// The function computes the superpixels segmentation of an image with the parameters initialized
        /// with the function createSuperpixelSEEDS().
        /// </summary>
        /// <returns></returns>
        public virtual int GetNumberOfSuperpixels()
        {
            ThrowIfDisposed(); 
            NativeMethods.HandleException(
                NativeMethods.ximgproc_SuperpixelSEEDS_getNumberOfSuperpixels(
                    ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// Input image. Supported formats: CV_8U, CV_16U, CV_32F. Image size &amp; number of
        /// channels must match with the initialized image size &amp; channels with the function
        /// createSuperpixelSEEDS(). It should be in HSV or Lab color space.Lab is a bit better, but also slower.
        /// </summary>
        /// <param name="img">Supported formats: CV_8U, CV_16U, CV_32F. Image size &amp; number of
        /// channels must match with the initialized image size &amp; channels with the function
        /// createSuperpixelSEEDS(). It should be in HSV or Lab color space.Lab is a bit better, but also slower.</param>
        /// <param name="numIterations">Number of pixel level iterations. Higher number improves the result.</param>
        public virtual void Iterate(InputArray img, int numIterations = 10)
        {
            ThrowIfDisposed();
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            img.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_SuperpixelSEEDS_iterate(
                    ptr, img.CvPtr, numIterations));

            GC.KeepAlive(this);
            GC.KeepAlive(img);
        }

        /// <summary>
        /// Returns the segmentation labeling of the image.
        /// Each label represents a superpixel, and each pixel is assigned to one superpixel label.
        ///
        /// The function returns an image with ssthe labels of the superpixel segmentation. The labels are in
        /// the range[0, getNumberOfSuperpixels()].
        /// </summary>
        /// <param name="labelsOut">Return: A CV_32UC1 integer array containing the labels of the superpixel
        /// segmentation.The labels are in the range[0, getNumberOfSuperpixels()].</param>
        public virtual void GetLabels(OutputArray labelsOut)
        {
            ThrowIfDisposed();
            if (labelsOut == null)
                throw new ArgumentNullException(nameof(labelsOut));
            labelsOut.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_SuperpixelSEEDS_getLabels(
                    ptr, labelsOut.CvPtr));
            GC.KeepAlive(this);
            labelsOut.Fix();
        }

        /// <summary>
        /// Returns the mask of the superpixel segmentation stored in SuperpixelSEEDS object.
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
                NativeMethods.ximgproc_SuperpixelSEEDS_getLabelContourMask(
                    ptr, image.CvPtr, thickLine ? 1 : 0));
            GC.KeepAlive(this);
            image.Fix();
        }
        
        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_Ptr_SuperpixelSEEDS_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_Ptr_SuperpixelSEEDS_delete(ptr));
                base.DisposeUnmanaged();
            }
        }
    }
}
