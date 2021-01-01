using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp
{
#pragma warning disable 1591
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public struct LSDParam
    {
        public double Scale;
        public double SigmaScale;
        public double Quant;
        public double AngTh;
        public double LogEps;
        public double DensityTh;
        public int NBins;

        public LSDParam(
            double scale = 0.8,
            double sigmaScale = 0.6,
            double quant = 2.0,
            double angTh = 22.5,
            double logEps = 0,
            double densityTh = 0.7,
            int nBins = 1024)
        {
            Scale = scale;
            SigmaScale = sigmaScale;
            Quant = quant;
            AngTh = angTh;
            LogEps = logEps;
            DensityTh = densityTh;
            NBins = nBins;
        }
#pragma warning restore 1591
    }

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
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();
            mask?.ThrowIfDisposed();


            NativeMethods.HandleException(
                NativeMethods.line_descriptor_LSDDetector_delete(ptr));

            GC.KeepAlive(this);
            GC.KeepAlive(image);
            GC.KeepAlive(mask);
        }


        /* @overload
@param images input images
@param keylines set of vectors that will store extracted lines for one or more images
@param scale scale factor used in pyramids generation
@param numOctaves number of octaves inside pyramid
@param masks vector of mask matrices to detect only KeyLines of interest from each input image
*/
        //public void Detect(IEnumerable<Mat> images, std::vector<std::vector<KeyLine>>& keylines, int scale, int numOctaves,
        //const std::vector<Mat>& masks = std::vector<Mat>() ) const;
    }
}
