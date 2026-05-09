using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Base class for line segments detector.
    /// </summary>
    public class HoughSegmentDetector : Algorithm
    {
        protected HoughSegmentDetector(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_HoughSegmentDetector_delete(p)))
        {
        }

        /// <summary>
        /// Creates implementation for cuda::HoughSegmentDetector.
        /// </summary>
        /// <param name="rho">Distance resolution of the accumulator in pixels.</param>
        /// <param name="theta">Angle resolution of the accumulator in radians.</param>
        /// <param name="minLineLength">Minimum line length. Line segments shorter than that are rejected.</param>
        /// <param name="maxLineGap">Maximum allowed gap between points on the same line to link them.</param>
        /// <param name="maxLines">Maximum number of lines to return.</param>
        /// <returns></returns>
        public static HoughSegmentDetector Create(
            float rho, float theta, int minLineLength, int maxLineGap, int maxLines = 4096)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_createHoughSegmentDetector(
                    rho, theta, minLineLength, maxLineGap, maxLines, out var smartPtr));

            NativeMethods.HandleException(
                NativeMethods.cuda_HoughSegmentDetector_get(smartPtr, out var rawPtr));

            return new HoughSegmentDetector(smartPtr, rawPtr);
        }

        /// <summary>
        /// Finds line segments in a binary image using the probabilistic Hough transform.
        /// </summary>
        /// <param name="src">8-bit, single-channel, binary source image.</param>
        /// <param name="lines">Output matrix of detected lines (CV_32SC4). Each row contains (x1, y1, x2, y2).</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public virtual void Detect(
            OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray lines, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) throw new ArgumentNullException(nameof(src));
            if (lines is null) throw new ArgumentNullException(nameof(lines));

            src.ThrowIfDisposed();
            lines.ThrowIfNotReady();
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_HoughSegmentDetector_detect(RawPtr, src.CvPtr, lines.CvPtr, stream?.CvPtr??IntPtr.Zero));

            lines.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(src);
        }

        public int MaxLineGap
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_HoughSegmentDetector_getMaxLineGap(RawPtr, out int val)); 
                GC.KeepAlive(this);
                return val;
            }
            set 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_HoughSegmentDetector_setMaxLineGap(RawPtr, value)); 
                GC.KeepAlive(this); 
            }
        }

        public int MaxLines
        {
            get
            { 
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_HoughSegmentDetector_getMaxLines(RawPtr, out int val));
                GC.KeepAlive(this);
                return val;
            }
            set 
            {
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_HoughSegmentDetector_setMaxLines(RawPtr, value)); 
                GC.KeepAlive(this);
            }
        }

        public int MinLineLength
        {
            get
            { 
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_HoughSegmentDetector_getMinLineLength(RawPtr, out int val)); 
                GC.KeepAlive(this); 
                return val; 
            }
            set 
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_HoughSegmentDetector_setMinLineLength(RawPtr, value));
                GC.KeepAlive(this);
            }
        }

        public float Rho
        {
            get 
            {
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_HoughSegmentDetector_getRho(RawPtr, out float val));
                GC.KeepAlive(this);
                return val; 
            }
            set 
            { 
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_HoughSegmentDetector_setRho(RawPtr, value)); 
                GC.KeepAlive(this); 
            }
        }

        public float Theta
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_HoughSegmentDetector_getTheta(RawPtr, out float val)); 
                GC.KeepAlive(this);
                return val;
            }
            set 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_HoughSegmentDetector_setTheta(RawPtr, value)); 
                GC.KeepAlive(this);
            }
        }
    }
}
