using System;
using System.Collections.Generic;

namespace OpenCvSharp.XImgProc
{
    /// <summary>
    /// Class implementing the FLD (Fast Line Detector) algorithm described in @cite Lee14.
    /// </summary>
    public class FastLineDetector : Algorithm
    {
        private Ptr? detectorPtr;

        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected FastLineDetector(IntPtr p)
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
        /// Creates a smart pointer to a FastLineDetector object and initializes it
        /// </summary>
        /// <param name="lengthThreshold">Segment shorter than this will be discarded</param>
        /// <param name="distanceThreshold"> A point placed from a hypothesis line segment farther than 
        /// this will be regarded as an outlier</param>
        /// <param name="cannyTh1">First threshold for hysteresis procedure in Canny()</param>
        /// <param name="cannyTh2">Second threshold for hysteresis procedure in Canny()</param>
        /// <param name="cannyApertureSize">Aperturesize for the sobel operator in Canny()</param>
        /// <param name="doMerge">If true, incremental merging of segments will be perfomred</param>
        /// <returns></returns>
        public static FastLineDetector Create(
            int lengthThreshold = 10, float distanceThreshold = 1.414213562f,
            double cannyTh1 = 50.0, double cannyTh2 = 50.0, int cannyApertureSize = 3,
            bool doMerge = false)
        {
            NativeMethods.HandleException(
                NativeMethods.ximgproc_createFastLineDetector(
                    lengthThreshold, distanceThreshold, cannyTh1, cannyTh2, cannyApertureSize, doMerge ? 1 : 0, out var p));
            return new FastLineDetector(p);
        }

        /// <summary>
        /// Finds lines in the input image.
        /// This is the output of the default parameters of the algorithm on the above shown image.
        /// </summary>
        /// <param name="image">A grayscale (CV_8UC1) input image. If only a roi needs to be
        /// selected, use: `fld_ptr-\>detect(image(roi), lines, ...);
        /// lines += Scalar(roi.x, roi.y, roi.x, roi.y);`</param>
        /// <param name="lines">A vector of Vec4f elements specifying the beginning
        /// and ending point of a line. Where Vec4f is (x1, y1, x2, y2), 
        /// point 1 is the start, point 2 - end.Returned lines are directed so that the
        /// brighter side is on their left.</param>
        public virtual void Detect(InputArray image, OutputArray lines)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (lines == null)
                throw new ArgumentNullException(nameof(lines));
            image.ThrowIfDisposed();
            lines.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.ximgproc_FastLineDetector_detect_OutputArray(ptr, image.CvPtr, lines.CvPtr));
            GC.KeepAlive(this);
            GC.KeepAlive(image);
            GC.KeepAlive(lines);
            lines.Fix();
        }

        /// <summary>
        /// Finds lines in the input image.
        /// This is the output of the default parameters of the algorithm on the above shown image.
        /// </summary>
        /// <param name="image">A grayscale (CV_8UC1) input image. If only a roi needs to be
        /// selected, use: `fld_ptr-\>detect(image(roi), lines, ...);
        /// lines += Scalar(roi.x, roi.y, roi.x, roi.y);`</param>
        /// <returns>A vector of Vec4f elements specifying the beginning
        /// and ending point of a line. Where Vec4f is (x1, y1, x2, y2), 
        /// point 1 is the start, point 2 - end.Returned lines are directed so that the
        /// brighter side is on their left.</returns>
        public virtual Vec4f[] Detect(InputArray image)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            using var lines = new VectorOfVec4f();
            NativeMethods.HandleException(
                NativeMethods.ximgproc_FastLineDetector_detect_vector(ptr, image.CvPtr, lines.CvPtr));
            GC.KeepAlive(this);
            GC.KeepAlive(image);
            return lines.ToArray();
        }

        /// <summary>
        /// Draws the line segments on a given image.
        /// </summary>
        /// <param name="image">The image, where the lines will be drawn. Should be bigger or equal to the image, where the lines were found.</param>
        /// <param name="lines">A vector of the lines that needed to be drawn.</param>
        /// <param name="drawArrow">If true, arrow heads will be drawn.</param>
        public virtual void DrawSegments(InputOutputArray image, InputArray lines,
            bool drawArrow = false)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (lines == null)
                throw new ArgumentNullException(nameof(lines));

            NativeMethods.HandleException(
                NativeMethods.ximgproc_FastLineDetector_drawSegments_InputArray(ptr, image.CvPtr, lines.CvPtr, drawArrow ? 1 : 0));
            GC.KeepAlive(this);
            GC.KeepAlive(image);
            image.Fix();
            GC.KeepAlive(lines);
        }

        /// <summary>
        /// Draws the line segments on a given image.
        /// </summary>
        /// <param name="image">The image, where the lines will be drawn. Should be bigger or equal to the image, where the lines were found.</param>
        /// <param name="lines">A vector of the lines that needed to be drawn.</param>
        /// <param name="drawArrow">If true, arrow heads will be drawn.</param>
        public virtual void DrawSegments(InputOutputArray image, IEnumerable<Vec4f> lines, bool drawArrow = false)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (lines == null)
                throw new ArgumentNullException(nameof(lines));

            using var linesVec = new VectorOfVec4f(lines);
            NativeMethods.HandleException(
                NativeMethods.ximgproc_FastLineDetector_drawSegments_vector(
                    ptr, image.CvPtr, linesVec.CvPtr, drawArrow ? 1 : 0));
            
            GC.KeepAlive(this);
            GC.KeepAlive(image);
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
                    NativeMethods.ximgproc_Ptr_FastLineDetector_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.HandleException(
                    NativeMethods.ximgproc_Ptr_FastLineDetector_delete(ptr));
                base.DisposeUnmanaged();
            }
        }
    }
}
