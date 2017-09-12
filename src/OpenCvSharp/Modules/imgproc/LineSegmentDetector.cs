using System;

namespace OpenCvSharp
{
    /// <summary>
    /// Line segment detector class
    /// </summary>
    public class LineSegmentDetector : Algorithm
    {
        /// <summary>
        /// cv::Ptr&lt;LineSegmentDetector&gt;
        /// </summary>
        private Ptr ptrObj;

        /// <summary>
        /// 
        /// </summary>
        protected LineSegmentDetector(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates a smart pointer to a LineSegmentDetector object and initializes it.
        /// </summary>
        /// <param name="refine">The way found lines will be refined, see cv::LineSegmentDetectorModes</param>
        /// <param name="scale">The scale of the image that will be used to find the lines. Range (0..1].</param>
        /// <param name="sigmaScale">Sigma for Gaussian filter. It is computed as sigma = _sigma_scale/_scale.</param>
        /// <param name="quant">Bound to the quantization error on the gradient norm.</param>
        /// <param name="angTh">Gradient angle tolerance in degrees.</param>
        /// <param name="logEps">Detection threshold: -log10(NFA) \> log_eps. 
        /// Used only when advancent refinement is chosen.</param>
        /// <param name="densityTh">Minimal density of aligned region points in the enclosing rectangle.</param>
        /// <param name="nBins">Number of bins in pseudo-ordering of gradient modulus.</param>
        /// <returns></returns>
        public static LineSegmentDetector Create(
            LineSegmentDetectorModes refine = LineSegmentDetectorModes.RefineNone,
            double scale = 0.8, double sigmaScale = 0.6, double quant = 2.0, double angTh = 22.5,
            double logEps = 0, double densityTh = 0.7, int nBins = 1024)
        {
            IntPtr ptr = NativeMethods.imgproc_createLineSegmentDetector(
                (int)refine, scale, sigmaScale, quant, angTh, logEps, densityTh, nBins);
            return new LineSegmentDetector(ptr);
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

        /// <summary>
        /// Finds lines in the input image.
        /// This is the output of the default parameters of the algorithm on the above shown image.
        /// </summary>
        /// <param name="image">A grayscale (CV_8UC1) input image. </param>
        /// <param name="lines">A vector of Vec4i or Vec4f elements specifying the beginning and ending point of a line. 
        /// Where Vec4i/Vec4f is (x1, y1, x2, y2), point 1 is the start, point 2 - end. Returned lines are strictly oriented depending on the gradient.</param>
        /// <param name="width">Vector of widths of the regions, where the lines are found. E.g. Width of line.</param>
        /// <param name="prec">Vector of precisions with which the lines are found.</param>
        /// <param name="nfa">Vector containing number of false alarms in the line region, 
        /// with precision of 10%. The bigger the value, logarithmically better the detection.</param>
        public virtual void Detect(InputArray image, OutputArray lines,
            OutputArray width = null, OutputArray prec = null, OutputArray nfa = null)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (lines == null)
                throw new ArgumentNullException(nameof(lines));
            image.ThrowIfDisposed();
            lines.ThrowIfNotReady();
            width?.ThrowIfNotReady();
            prec?.ThrowIfNotReady();
            nfa?.ThrowIfNotReady();

            NativeMethods.imgproc_LineSegmentDetector_detect_OutputArray(ptr, image.CvPtr, lines.CvPtr,
                Cv2.ToPtr(width), Cv2.ToPtr(prec), Cv2.ToPtr(nfa));

            GC.KeepAlive(image);
            lines.Fix();
            width?.Fix();
            prec?.Fix();
            nfa?.Fix();
        }

        /// <summary>
        /// Finds lines in the input image.
        /// This is the output of the default parameters of the algorithm on the above shown image.
        /// </summary>
        /// <param name="image">A grayscale (CV_8UC1) input image. </param>
        /// <param name="lines">A vector of Vec4i or Vec4f elements specifying the beginning and ending point of a line. 
        /// Where Vec4i/Vec4f is (x1, y1, x2, y2), point 1 is the start, point 2 - end. Returned lines are strictly oriented depending on the gradient.</param>
        /// <param name="width">Vector of widths of the regions, where the lines are found. E.g. Width of line.</param>
        /// <param name="prec">Vector of precisions with which the lines are found.</param>
        /// <param name="nfa">Vector containing number of false alarms in the line region, 
        /// with precision of 10%. The bigger the value, logarithmically better the detection.</param>
        public virtual void Detect(InputArray image, out Vec4f[] lines,
            out double[] width, out double[] prec, out double[] nfa)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            using (var linesVec = new VectorOfVec4f())
            using (var widthVec = new VectorOfDouble())
            using (var precVec = new VectorOfDouble())
            using (var nfaVec = new VectorOfDouble())
            {
                NativeMethods.imgproc_LineSegmentDetector_detect_vector(ptr, image.CvPtr,
                    linesVec.CvPtr, widthVec.CvPtr, precVec.CvPtr, nfaVec.CvPtr);

                lines = linesVec.ToArray();
                width = widthVec.ToArray();
                prec = precVec.ToArray();
                nfa = nfaVec.ToArray();
            }

            GC.KeepAlive(image);
        }

        /// <summary>
        /// Draws the line segments on a given image.
        /// </summary>
        /// <param name="image">The image, where the liens will be drawn. 
        /// Should be bigger or equal to the image, where the lines were found.</param>
        /// <param name="lines">A vector of the lines that needed to be drawn.</param>
        public virtual void DrawSegments(InputOutputArray image, InputArray lines)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (lines == null)
                throw new ArgumentNullException(nameof(lines));
            image.ThrowIfNotReady();
            lines.ThrowIfDisposed();

            NativeMethods.imgproc_LineSegmentDetector_drawSegments(ptr, image.CvPtr, lines.CvPtr);

            image.Fix();
            GC.KeepAlive(lines);
        }

        /// <summary>
        /// Draws two groups of lines in blue and red, counting the non overlapping (mismatching) pixels.
        /// </summary>
        /// <param name="size">The size of the image, where lines1 and lines2 were found.</param>
        /// <param name="lines1">The first group of lines that needs to be drawn. It is visualized in blue color.</param>
        /// <param name="lines2">The second group of lines. They visualized in red color.</param>
        /// <param name="image">Optional image, where the lines will be drawn. 
        /// The image should be color(3-channel) in order for lines1 and lines2 to be drawn 
        /// in the above mentioned colors.</param>
        /// <returns></returns>
        public virtual int CompareSegments(
            Size size, InputArray lines1, InputArray lines2, InputOutputArray image = null)
        {
            if (lines1 == null)
                throw new ArgumentNullException(nameof(lines1));
            if (lines2 == null)
                throw new ArgumentNullException(nameof(lines2));
            lines1.ThrowIfDisposed();
            lines2.ThrowIfDisposed();
            image?.ThrowIfNotReady();

            var ret = NativeMethods.imgproc_LineSegmentDetector_compareSegments(
                ptr, size, lines1.CvPtr, lines2.CvPtr, Cv2.ToPtr(image));

            GC.KeepAlive(lines1);
            GC.KeepAlive(lines2);
            image?.Fix();

            return ret;
        }
        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.imgproc_Ptr_LineSegmentDetector_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.imgproc_Ptr_LineSegmentDetector_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
