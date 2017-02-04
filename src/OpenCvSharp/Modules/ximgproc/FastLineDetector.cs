using System;
using System.Collections.Generic;

namespace OpenCvSharp.XImgProc
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
    /// SIFT 実装.
    /// </summary>
#else
    /// <summary>
    /// SIFT implementation.
    /// </summary>
#endif
    public class FastLineDetector : Algorithm
    {
        private bool disposed;
        private Ptr<FastLineDetector> detectorPtr;

        #region Init & Disposal

        /// <summary>
        /// Creates instance by raw pointer cv::FastLineDetector*
        /// </summary>
        protected FastLineDetector(IntPtr p)
            : base()
        {
            detectorPtr = new Ptr<FastLineDetector>(p);
            ptr = detectorPtr.Get();
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
                        if (detectorPtr != null)
                        {
                            detectorPtr.Dispose();
                            detectorPtr = null;
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
            IntPtr p = NativeMethods.ximgproc_createFastLineDetector(lengthThreshold, distanceThreshold, cannyTh1, cannyTh2,
                cannyApertureSize, doMerge ? 1 : 0);
            return new FastLineDetector(p);
        }

        #endregion

        #region Methods

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
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (lines == null)
                throw new ArgumentNullException(nameof(lines));
            image.ThrowIfDisposed();
            lines.ThrowIfNotReady();

            NativeMethods.ximgproc_FastLineDetector_detect_OutputArray(ptr, image.CvPtr, lines.CvPtr);

            GC.KeepAlive(image);
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
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            using (var lines = new VectorOfVec4f())
            {
                NativeMethods.ximgproc_FastLineDetector_detect_OutputArray(ptr, image.CvPtr, lines.CvPtr);
                GC.KeepAlive(image);
                return lines.ToArray();
            }
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
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (lines == null)
                throw new ArgumentNullException(nameof(lines));

            NativeMethods.imgproc_LineSegmentDetector_drawSegments(ptr, image.CvPtr, lines.CvPtr);

            image.Fix();
            GC.KeepAlive(lines);
        }

        /// <summary>
        /// Draws the line segments on a given image.
        /// </summary>
        /// <param name="image">The image, where the lines will be drawn. Should be bigger or equal to the image, where the lines were found.</param>
        /// <param name="lines">A vector of the lines that needed to be drawn.</param>
        /// <param name="drawArrow">If true, arrow heads will be drawn.</param>
        public virtual void DrawSegments(InputOutputArray image, IEnumerable<Vec4f> lines,
            bool drawArrow = false)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (lines == null)
                throw new ArgumentNullException(nameof(lines));

            using (var linesVec = new VectorOfVec4f(lines))
            {
                NativeMethods.imgproc_LineSegmentDetector_drawSegments(ptr, image.CvPtr, linesVec.CvPtr);
            }

            image.Fix();
        }

        #endregion
    }
}
