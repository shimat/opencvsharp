using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Base class for Hough lines detector.
    /// </summary>
    public class HoughLinesDetector : Algorithm
    {
        protected HoughLinesDetector(IntPtr smartPtr, IntPtr rawPtr)
            : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.cuda_HoughLinesDetector_delete(p)))
        {
        }

        /// <summary>
        /// Creates implementation for cuda::HoughLinesDetector.
        /// </summary>
        /// <param name="rho">Distance resolution of the accumulator in pixels.</param>
        /// <param name="theta">Angle resolution of the accumulator in radians.</param>
        /// <param name="threshold">Accumulator threshold parameter. Only those lines are returned that get enough votes.</param>
        /// <param name="doSort">Whether to sort lines by votes.</param>
        /// <param name="maxLines">Maximum number of lines to return.</param>
        /// <returns></returns>
        public static HoughLinesDetector Create(
            float rho, float theta, int threshold, bool doSort = false, int maxLines = 4096)
        {
            NativeMethods.HandleException(
                NativeMethods.cuda_createHoughLinesDetector(
                    rho, theta, threshold, doSort ? 1 : 0, maxLines, out var smartPtr));

            NativeMethods.HandleException(
                NativeMethods.cuda_HoughLinesDetector_get(smartPtr, out var rawPtr));

            return new HoughLinesDetector(smartPtr, rawPtr);
        }

        /// <summary>
        /// Finds lines in a binary image using the classical Hough transform.
        /// </summary>
        /// <param name="src">8-bit, single-channel, binary source image.</param>
        /// <param name="lines">Output matrix of detected lines (CV_32FC2).</param>
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
                NativeMethods.cuda_HoughLinesDetector_detect(RawPtr, src.CvPtr, lines.CvPtr,stream?.CvPtr ?? IntPtr.Zero));

            lines.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(src);
        }

        /// <summary>
        /// Downloads results from Detect to host memory.
        /// </summary>
        /// <param name="dLines">Result of Detect (GpuMat).</param>
        /// <param name="hLines">Output host array (Mat).</param>
        /// <param name="hVotes">Optional output array for line votes (Mat).</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public virtual void DownloadResults(
            OpenCvSharp.Cuda.InputArray dLines,
            OpenCvSharp.OutputArray hLines,
            OpenCvSharp.OutputArray? hVotes = null,
            OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (dLines is null) throw new ArgumentNullException(nameof(dLines));
            if (hLines is null) throw new ArgumentNullException(nameof(hLines));

            dLines.ThrowIfDisposed();
            hLines.ThrowIfNotReady();
            hVotes?.ThrowIfNotReady();
            ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_HoughLinesDetector_downloadResults(
                    RawPtr, dLines.CvPtr, hLines.CvPtr, hVotes?.CvPtr ?? IntPtr.Zero, stream?.CvPtr ?? IntPtr.Zero));

            hLines.Fix();
            hVotes?.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(dLines);
            GC.KeepAlive(hLines);
            if (hVotes != null) GC.KeepAlive(hVotes);
        }

        public bool DoSort
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_HoughLinesDetector_getDoSort(RawPtr, out int val)); 
                GC.KeepAlive(this);
                return val != 0; 
            }
            set 
            { 
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_HoughLinesDetector_setDoSort(RawPtr, value ? 1 : 0)); 
                GC.KeepAlive(this); 
            }
        }

        public int MaxLines
        {
            get
            {
                ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_HoughLinesDetector_getMaxLines(RawPtr, out int val));
                GC.KeepAlive(this);
                return val;
            }
            set 
            { 
                ThrowIfDisposed(); NativeMethods.HandleException(NativeMethods.cuda_HoughLinesDetector_setMaxLines(RawPtr, value));
                GC.KeepAlive(this);
            }
        }

        public float Rho
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_HoughLinesDetector_getRho(RawPtr, out float val)); 
                GC.KeepAlive(this); 
                return val; 
            }
            set 
            { 
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_HoughLinesDetector_setRho(RawPtr, value)); 
                GC.KeepAlive(this);
            }
        }

        public float Theta
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_HoughLinesDetector_getTheta(RawPtr, out float val)); 
                GC.KeepAlive(this); 
                return val; 
            }
            set 
            { 
                ThrowIfDisposed();
                NativeMethods.HandleException(NativeMethods.cuda_HoughLinesDetector_setTheta(RawPtr, value)); 
                GC.KeepAlive(this); 
            }
        }

        public int Threshold
        {
            get 
            { 
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_HoughLinesDetector_getThreshold(RawPtr, out int val));
                GC.KeepAlive(this); 
                return val; 
            }
            set 
            {
                ThrowIfDisposed(); 
                NativeMethods.HandleException(NativeMethods.cuda_HoughLinesDetector_setThreshold(RawPtr, value));
                GC.KeepAlive(this); 
            }
        }

    }
}
