using OpenCvSharp.Detail;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp
{
#pragma warning disable 1591
    // ReSharper disable InconsistentNaming

    // TODO
    namespace Detail
    {
        public enum WaveCorrectKind
        {
            Horizontal,
            Vertical
        }
        
        public class FeaturesFinder
        {
        }
        
        public class BundleAdjusterBase
        {
        }

        public class WarperCreator
        {
        }

        public class ExposureCompensator
        {
        }

        public class SeamFinder
        {
        }

        public class Blender
        {
        }

        public class CameraParams
        {
        }
    }

    /// <summary>
    /// High level image stitcher. 
    /// It's possible to use this class without being aware of the entire stitching 
    /// pipeline. However, to be able to achieve higher stitching stability and 
    /// quality of the final images at least being familiar with the theory is recommended
    /// </summary>
    public sealed class Stitcher : DisposableCvObject
    {
        private Ptr? ptrObj;

        #region Enum

        public const int ORIG_RESOL = -1;

        /// <summary>
        /// Status code
        /// </summary>
        public enum Status
        {
            OK = 0,
            ErrorNeedMoreImgs = 1,
            ErrorHomographyEstFail = 2,
            ErrorCameraParamsAdjustFail = 3
        }

        public enum Mode
        {
            /// <summary>
            /// Mode for creating photo panoramas. Expects images under perspective
            /// transformation and projects resulting pano to sphere.
            /// </summary>
            Panorama = 0,

            /// <summary>
            /// Mode for composing scans. Expects images under affine transformation does
            /// not compensate exposure by default.
            /// </summary>
            Scans = 1,
        }

        #endregion

        #region Init & Disposal

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="p">cv::Stitcher*</param>
        private Stitcher(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates a Stitcher configured in one of the stitching modes.
        /// </summary>
        /// <param name="mode">Scenario for stitcher operation. This is usually determined by source of images
        /// to stitch and their transformation.Default parameters will be chosen for operation in given scenario.</param>
        public static Stitcher Create(Mode mode = Mode.Panorama)
        {
            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_create((int)mode, out var ret));
            return new Stitcher(ret);
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

        #endregion

        #region Properties

        public double RegistrationResol
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_registrationResol(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_setRegistrationResol(ptr, value));
                GC.KeepAlive(this);
            }
        }

        public double SeamEstimationResol
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_seamEstimationResol(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_setSeamEstimationResol(ptr, value));
                GC.KeepAlive(this);
            }
        }

        public double CompositingResol
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_compositingResol(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_setCompositingResol(ptr, value));
                GC.KeepAlive(this);
            }
        }

        public double PanoConfidenceThresh
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_panoConfidenceThresh(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_setPanoConfidenceThresh(ptr, value));
                GC.KeepAlive(this);
            }
        }

        public bool WaveCorrection
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_waveCorrection(ptr, out var ret));
                GC.KeepAlive(this);
                return ret != 0;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_setWaveCorrection(ptr, value ? 1 : 0));
                GC.KeepAlive(this);
            }
        }

        public WaveCorrectKind WaveCorrectKind
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_waveCorrectKind(ptr, out var ret));
                GC.KeepAlive(this);
                return (WaveCorrectKind)ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_setWaveCorrectKind(ptr, (int)value));
                GC.KeepAlive(this);
            }
        }

        /*
        public FeaturesFinder FeaturesFinder
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public FeaturesMatcher FeaturesMatcher
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public Mat MatchingMask
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public BundleAdjusterBase BundleAdjuster
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public WarperCreator Warper
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ExposureCompensator ExposureCompensator
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public SeamFinder SeamFinder
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public Blender Blender
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        */

        // TODO this should be method?
        public IReadOnlyList<int> Component
        {
            get
            {
                using var componentVec = new VectorOfInt32();
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_component(ptr, componentVec.CvPtr));
                GC.KeepAlive(this); 
                return componentVec.ToArray();
            }
        }

        //public CameraParams[] Cameras => throw new NotImplementedException();

        public double WorkScale
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_workScale(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }
        }

        #endregion

        #region Methods

        public Status EstimateTransform(InputArray images)
        {
            if (images is null)
                throw new ArgumentNullException(nameof(images));
            images.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_estimateTransform_InputArray1(
                    ptr, images.CvPtr, out var ret));

            GC.KeepAlive(this);
            GC.KeepAlive(images);
            return (Status)ret;
        }

        public Status EstimateTransform(InputArray images, Rect[][] rois)
        {
            if (images is null)
                throw new ArgumentNullException(nameof(images));
            if (rois is null)
                throw new ArgumentNullException(nameof(rois));
            images.ThrowIfDisposed();

            using var roisPointer = new ArrayAddress2<Rect>(rois);
            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_estimateTransform_InputArray2(
                    ptr, images.CvPtr,
                    roisPointer.GetPointer(), roisPointer.GetDim1Length(), roisPointer.GetDim2Lengths(),
                    out var ret));

            GC.KeepAlive(this);
            GC.KeepAlive(images);
            return (Status)ret;
        }

        public Status EstimateTransform(IEnumerable<Mat> images)
        {
            if (images is null)
                throw new ArgumentNullException(nameof(images));

            var imagesPtrs = images.Select(x => x.CvPtr).ToArray();

            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_estimateTransform_MatArray1(
                    ptr, imagesPtrs, imagesPtrs.Length, out var ret));

            GC.KeepAlive(this);
            GC.KeepAlive(images);
            return (Status)ret;
        }

        public Status EstimateTransform(IEnumerable<Mat> images, Rect[][] rois)
        {
            if (images is null)
                throw new ArgumentNullException(nameof(images));
            if (rois is null)
                throw new ArgumentNullException(nameof(rois));

            var imagesPtrs = images.Select(x => x.CvPtr).ToArray();
            using var roisPointer = new ArrayAddress2<Rect>(rois);
            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_estimateTransform_MatArray2(
                    ptr, imagesPtrs, imagesPtrs.Length,
                    roisPointer.GetPointer(), roisPointer.GetDim1Length(), roisPointer.GetDim2Lengths(),
                    out var ret));

            GC.KeepAlive(this);
            GC.KeepAlive(images);
            return (Status)ret;
        }

        public Status ComposePanorama(OutputArray pano)
        {
            if (pano is null)
                throw new ArgumentNullException(nameof(pano));
            pano.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_composePanorama1(
                    ptr, pano.CvPtr, out var ret));

            pano.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(pano);
            return (Status)ret;
        }

        public Status ComposePanorama(InputArray images, OutputArray pano)
        {
            if (images is null)
                throw new ArgumentNullException(nameof(images));
            if (pano is null)
                throw new ArgumentNullException(nameof(pano));
            images.ThrowIfDisposed();
            pano.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_composePanorama2_InputArray(
                    ptr, images.CvPtr, pano.CvPtr, out var ret));

            pano.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(images);
            GC.KeepAlive(pano);
            return (Status)ret;
        }

        public Status ComposePanorama(IEnumerable<Mat> images, OutputArray pano)
        {
            if (images is null)
                throw new ArgumentNullException(nameof(images));
            if (pano is null)
                throw new ArgumentNullException(nameof(pano));
            pano.ThrowIfNotReady();

            var imagesPtrs = images.Select(x => x.CvPtr).ToArray();
            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_composePanorama2_MatArray(
                    ptr, imagesPtrs, imagesPtrs.Length, pano.CvPtr, out var ret));

            pano.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(images);
            GC.KeepAlive(pano);
            return (Status)ret;
        }

        /// <summary>
        /// Try to stitch the given images.
        /// </summary>
        /// <param name="images">Input images.</param>
        /// <param name="pano">Final pano.</param>
        /// <returns>Status code.</returns>
        public Status Stitch(InputArray images, OutputArray pano)
        {
            if (images is null)
                throw new ArgumentNullException(nameof(images));
            if (pano is null)
                throw new ArgumentNullException(nameof(pano));
            images.ThrowIfDisposed();
            pano.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_stitch1_InputArray(
                    ptr, images.CvPtr, pano.CvPtr, out var ret));

            GC.KeepAlive(this);
            GC.KeepAlive(images);
            GC.KeepAlive(pano);
            pano.Fix();

            return (Status)ret;
        }

        /// <summary>
        /// Try to stitch the given images.
        /// </summary>
        /// <param name="images">Input images.</param>
        /// <param name="pano">Final pano.</param>
        /// <returns>Status code.</returns>
        public Status Stitch(IEnumerable<Mat> images, OutputArray pano)
        {
            if (images is null)
                throw new ArgumentNullException(nameof(images));
            if (pano is null)
                throw new ArgumentNullException(nameof(pano));
            pano.ThrowIfNotReady();

            var imagesPtrs = images.Select(x => x.CvPtr).ToArray();

            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_stitch1_MatArray(
                    ptr, imagesPtrs, imagesPtrs.Length, pano.CvPtr, out var ret));

            GC.KeepAlive(this);
            GC.KeepAlive(images);
            GC.KeepAlive(pano);
            pano.Fix();

            return (Status)ret;
        }

        /// <summary>
        /// Try to stitch the given images.
        /// </summary>
        /// <param name="images">Input images.</param>
        /// <param name="rois">Region of interest rectangles.</param>
        /// <param name="pano">Final pano.</param>
        /// <returns>Status code.</returns>
        public Status Stitch(InputArray images, Rect[][] rois, OutputArray pano)
        {
            if (images is null)
                throw new ArgumentNullException(nameof(images));
            if (rois is null)
                throw new ArgumentNullException(nameof(rois));
            if (pano is null)
                throw new ArgumentNullException(nameof(pano));
            images.ThrowIfDisposed();
            pano.ThrowIfNotReady();

            using var roisPointer = new ArrayAddress2<Rect>(rois);
            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_stitch2_InputArray(
                    ptr, images.CvPtr,
                    roisPointer.GetPointer(), roisPointer.GetDim1Length(), roisPointer.GetDim2Lengths(),
                    pano.CvPtr, out var ret));

            pano.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(images);
            GC.KeepAlive(pano);
            return (Status)ret;
        }

        /// <summary>
        /// Try to stitch the given images.
        /// </summary>
        /// <param name="images">Input images.</param>
        /// <param name="rois">Region of interest rectangles.</param>
        /// <param name="pano">Final pano.</param>
        /// <returns>Status code.</returns>
        public Status Stitch(IEnumerable<Mat> images, Rect[][] rois, OutputArray pano)
        {
            if (images is null)
                throw new ArgumentNullException(nameof(images));
            if (rois is null)
                throw new ArgumentNullException(nameof(rois));
            if (pano is null)
                throw new ArgumentNullException(nameof(pano));
            pano.ThrowIfNotReady();

            var imagesPtrs = images.Select(x => x.CvPtr).ToArray();

            using var roisPointer = new ArrayAddress2<Rect>(rois);
            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_stitch2_MatArray(
                    ptr, imagesPtrs, imagesPtrs.Length,
                    roisPointer.GetPointer(), roisPointer.GetDim1Length(), roisPointer.GetDim2Lengths(),
                    pano.CvPtr, out var ret));

            pano.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(images);
            GC.KeepAlive(pano);
            return (Status)ret;
        }

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Ptr_Stitcher_get(ptr, out var ret));
                GC.KeepAlive(this);
                return ret;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Ptr_Stitcher_delete(ptr));
                base.DisposeUnmanaged();
            }
        }
    }
}
