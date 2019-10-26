using System;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.Tracking
{
    // ReSharper disable CommentTypo
    // ReSharper disable IdentifierTypo

    /// <inheritdoc />
    /// <summary>
    /// the CSRT tracker
    /// The implementation is based on @cite Lukezic_IJCV2018 Discriminative Correlation Filter with Channel and Spatial Reliability
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class TrackerCSRT : Tracker
    {
        /// <summary>
        /// 
        /// </summary>
        protected TrackerCSRT(IntPtr p)
            : base(new Ptr(p))
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <returns></returns>
        public static TrackerCSRT Create()
        {
            var p = NativeMethods.tracking_TrackerCSRT_create1();
            return new TrackerCSRT(p);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameters">CSRT parameters</param>
        /// <returns></returns>
        public static TrackerCSRT Create(Params parameters)
        {
            var p = NativeMethods.tracking_TrackerCSRT_create2(ref parameters);
            return new TrackerCSRT(p);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mask"></param>
        public virtual void SetInitialMask(InputArray mask)
        {
            if (mask == null)
                throw new ArgumentNullException(nameof(mask));
            mask.ThrowIfDisposed();

            NativeMethods.tracking_TrackerCSRT_setInitialMask(ptr, mask.CvPtr);

            GC.KeepAlive(mask);
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.tracking_Ptr_TrackerCSRT_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.tracking_Ptr_TrackerCSRT_delete(ptr);
                base.DisposeUnmanaged();
            }
        }

        /// <summary>
        /// CSRT Params
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Params
        {
#pragma warning disable 1591
            public int UseHog;
            public int UseColorNames;
            public int UseGray;
            public int UseRgb;
            public int UseChannelWeights;
            public int UseSegmentation;

            /// <summary>
            /// Window function: "hann", "cheb", "kaiser"
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string WindowFunction;

            public float KaiserAlpha;
            public float ChebAttenuation;

            public float TemplateSize;
            public float GslSigma;
            public float HogOrientations;
            public float HogClip;
            public float Padding;
            public float FilterLr;
            public float WeightsLr;
            public int NumHogChannelsUsed;
            public int AdmmIterations;
            public int HistogramBins;
            public float HistogramLr;
            public int BackgroundRatio;
            public int NumberOfScales;
            public float ScaleSigmaFactor;
            public float ScaleModelMaxArea;
            public float ScaleLr;
            public float ScaleStep;

            /// <summary>
            /// we lost the target, if the psr is lower than this.
            /// </summary>
            public float PsrThreshold;
#pragma warning restore 1591

            /// <summary>
            /// TrackerCSRT::Params::read()
            /// </summary>
            /// <param name="fn"></param>
            /// <returns></returns>
            public static Params Read(FileNode fn)
            {
                if (fn == null)
                    throw new ArgumentNullException(nameof(fn));
                fn.ThrowIfDisposed();

                var p = new Params();
                var windowFunction = new StringBuilder(32);
                NativeMethods.tracking_TrackerCSRT_Params_read(ref p, windowFunction, fn.CvPtr);

                GC.KeepAlive(fn);
                return p;
            }

            /// <summary>
            /// TrackerCSRT::Params::write()
            /// </summary>
            /// <param name="fs"></param>
            public void Write(FileStorage fs)
            {
                if (fs == null)
                    throw new ArgumentNullException(nameof(fs));
                fs.ThrowIfDisposed();

                NativeMethods.tracking_TrackerCSRT_Params_write(ref this, fs.CvPtr);

                GC.KeepAlive(fs);
            }
        }
    }
}