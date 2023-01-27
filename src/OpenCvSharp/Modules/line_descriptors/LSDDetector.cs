

// ReSharper disable UnusedMember.Global

// https://github.com/opencv/opencv_contrib/blob/33ae078b0989b44ac8d262d210335b04bb268b4d/modules/line_descriptor/src/binary_descriptor.cpp#L1030
#if false
namespace OpenCvSharp.LineDescriptor
{
    /// <summary>
    /// Lines extraction methodology
    /// ----------------------------
    ///
    /// The lines extraction methodology described in the following is mainly based on @cite EDL.The
    /// extraction starts with a Gaussian pyramid generated from an original image, downsampled N-1 times,
    /// blurred N times, to obtain N layers(one for each octave), with layer 0 corresponding to input
    /// image.Then, from each layer (octave) in the pyramid, lines are extracted using LSD algorithm.
    ///
    /// Differently from EDLine lines extractor used in original article, LSD furnishes information only
    /// about lines extremes; thus, additional information regarding slope and equation of line are computed
    /// via analytic methods.The number of pixels is obtained using * LineIterator*. Extracted lines are
    /// returned in the form of KeyLine objects, but since extraction is based on a method different from
    /// the one used in * BinaryDescriptor* class, data associated to a line's extremes in original image and
    /// in octave it was extracted from, coincide.KeyLine's field *class_id* is used as an index to
    /// indicate the order of extraction of a line inside a single octave.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class LSDDetector : DisposableCvObject
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public LSDDetector()
        {
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_LSDDetector_new1(out ptr));
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lsdParam"></param>
        public LSDDetector(in LSDParam lsdParam)
        {
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_LSDDetector_new2(
                    scale: lsdParam.Scale,
                    sigmaScale: lsdParam.SigmaScale,
                    quant: lsdParam.Quant,
                    angTh: lsdParam.AngTh,
                    logEps: lsdParam.LogEps,
                    densityTh: lsdParam.DensityTh,
                    nBins: lsdParam.NBins,
                    out ptr));
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_LSDDetector_delete(ptr));
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// Detect lines inside an image.
        /// </summary>
        /// <param name="image">input image</param>
        /// <param name="scale">scale factor used in pyramids generation</param>
        /// <param name="numOctaves">number of octaves inside pyramid</param>
        /// <param name="mask">mask matrix to detect only KeyLines of interest</param>
        /// <returns>vector that will store extracted lines for one or more images</returns>
        public KeyLine[] Detect(Mat image, int scale, int numOctaves, Mat? mask = null)
        {
            if (image is null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();
            mask?.ThrowIfDisposed();

            using var keypointsVec = new VectorOfKeyLine();
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_LSDDetector_detect1(
                    ptr, image.CvPtr, keypointsVec.CvPtr, scale, numOctaves, mask?.CvPtr ?? IntPtr.Zero));

            GC.KeepAlive(this);
            GC.KeepAlive(image);
            GC.KeepAlive(mask);

            return keypointsVec.ToArray();
        }
        
        /// <summary>
        /// Detect lines inside an image.
        /// </summary>
        /// <param name="images">input images</param>
        /// <param name="scale">scale factor used in pyramids generation</param>
        /// <param name="numOctaves">number of octaves inside pyramid</param>
        /// <param name="masks">vector of mask matrices to detect only KeyLines of interest from each input image</param>
        /// <returns>set of vectors that will store extracted lines for one or more images</returns>
        public KeyLine[][] Detect(IEnumerable<Mat> images, int scale, int numOctaves, IEnumerable<Mat>? masks = null)
        {
            if (images is null)
                throw new ArgumentNullException(nameof(images));

            var imagesPtrs = images.Select(i =>
            {
                if (i is null)
                    throw new ArgumentException($"'{nameof(images)}' contains null", nameof(images));
                i.ThrowIfDisposed();
                return i.CvPtr;
            }).ToArray();
            var masksPtrs = masks?.Select(i =>
            {
                if (i is null)
                    throw new ArgumentException($"'{nameof(images)}' contains null", nameof(images));
                i.ThrowIfDisposed();
                return i.CvPtr;
            }).ToArray() ?? Array.Empty<IntPtr>();

            using var keypointsVec = new VectorOfVectorKeyLine();
            NativeMethods.HandleException(
                NativeMethods.line_descriptor_LSDDetector_detect2(
                    ptr, 
                    imagesPtrs, imagesPtrs.Length,
                    keypointsVec.CvPtr, scale, numOctaves,
                    masksPtrs, masksPtrs.Length));

            GC.KeepAlive(this);
            GC.KeepAlive(images);
            GC.KeepAlive(masks);

            return keypointsVec.ToArray();
        }
    }
}

#endif
