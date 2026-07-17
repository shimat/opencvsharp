using OpenCvSharp.Detail;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp
{
#pragma warning disable 1591
    // ReSharper disable InconsistentNaming

    namespace Detail
    {
        public enum WaveCorrectKind
        {
            Horizontal,
            Vertical,
            Auto
        }
    }

    /// <summary>
    /// High level image stitcher. 
    /// It's possible to use this class without being aware of the entire stitching 
    /// pipeline. However, to be able to achieve higher stitching stability and 
    /// quality of the final images at least being familiar with the theory is recommended
    /// </summary>
    public sealed class Stitcher : CvObject
    {
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
            NativeMethods.HandleException(NativeMethods.stitching_Ptr_Stitcher_get(p, out var rawPtr));
            SetSafeHandle(new OpenCvPtrSafeHandle(rawPtr, ownsHandle: true,
                releaseAction: _ => NativeMethods.HandleException(NativeMethods.stitching_Ptr_Stitcher_delete(p))));
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

        #endregion

        #region Properties

        public double RegistrationResol
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_registrationResol(Handle, out var ret));
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_setRegistrationResol(Handle, value));
            }
        }

        public double SeamEstimationResol
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_seamEstimationResol(Handle, out var ret));
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_setSeamEstimationResol(Handle, value));
            }
        }

        public double CompositingResol
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_compositingResol(Handle, out var ret));
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_setCompositingResol(Handle, value));
            }
        }

        public double PanoConfidenceThresh
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_panoConfidenceThresh(Handle, out var ret));
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_setPanoConfidenceThresh(Handle, value));
            }
        }

        public bool WaveCorrection
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_waveCorrection(Handle, out var ret));
                return ret != 0;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_setWaveCorrection(Handle, value ? 1 : 0));
            }
        }

        public WaveCorrectKind WaveCorrectKind
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_waveCorrectKind(Handle, out var ret));
                return (WaveCorrectKind)ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_setWaveCorrectKind(Handle, (int)value));
            }
        }

        /// <summary>
        /// Mask indicating which image pairs must be matched.
        /// </summary>
        public Mat MatchingMask
        {
            get
            {
                var mask = new Mat();
                NativeMethods.HandleException(NativeMethods.stitching_Stitcher_matchingMask(Handle, mask.CvPtr));
                return mask;
            }
            set
            {
                ArgumentNullException.ThrowIfNull(value);
                NativeMethods.HandleException(NativeMethods.stitching_Stitcher_setMatchingMask(Handle, value.CvPtr));
                GC.KeepAlive(value);
            }
        }

        // TODO this should be method?
        public IReadOnlyList<int> Component
        {
            get
            {
                using var componentVec = new StdVector<int>();
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_component(Handle, componentVec.CvPtr));
                return componentVec.ToArray();
            }
        }

        /// <summary>
        /// Estimated camera parameters, one per stitched image.
        /// </summary>
        public CameraParams[] Cameras
        {
            get
            {
                using var focals = new StdVector<double>();
                using var aspects = new StdVector<double>();
                using var ppxs = new StdVector<double>();
                using var ppys = new StdVector<double>();
                using var rs = new VectorOfMat();
                using var ts = new VectorOfMat();
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_cameras(
                        Handle, focals.CvPtr, aspects.CvPtr, ppxs.CvPtr, ppys.CvPtr, rs.CvPtr, ts.CvPtr));

                var focalsArr = focals.ToArray();
                var aspectsArr = aspects.ToArray();
                var ppxsArr = ppxs.ToArray();
                var ppysArr = ppys.ToArray();
                var rsArr = rs.ToArray();
                var tsArr = ts.ToArray();

                var result = new CameraParams[focalsArr.Length];
                for (var i = 0; i < result.Length; i++)
                    result[i] = new CameraParams(focalsArr[i], aspectsArr[i], ppxsArr[i], ppysArr[i], rsArr[i], tsArr[i]);
                return result;
            }
        }

        public double WorkScale
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.stitching_Stitcher_workScale(Handle, out var ret));
                return ret;
            }
        }

        #endregion

        #region Methods

        public Status EstimateTransform(InputArray images)
        {
            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_estimateTransform_InputArray1(Handle, images.Proxy, out var ret));

            GC.KeepAlive(images.Source);
            return (Status)ret;
        }

        public Status EstimateTransform(InputArray images, Rect[][] rois)
        {
            ArgumentNullException.ThrowIfNull(rois);

            using var roisPointer = new ArrayAddress2<Rect>(rois);
            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_estimateTransform_InputArray2(Handle, images.Proxy, roisPointer.GetPointer(), roisPointer.GetDim1Length(), roisPointer.GetDim2Lengths(), out var ret));

            GC.KeepAlive(images.Source);
            return (Status)ret;
        }

        public Status EstimateTransform(IEnumerable<Mat> images)
        {
            ArgumentNullException.ThrowIfNull(images);

            var imagesPtrs = images.Select(x => x.CvPtr).ToArray();

            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_estimateTransform_MatArray1(
                    Handle, imagesPtrs, imagesPtrs.Length, out var ret));

            GC.KeepAlive(images);
            return (Status)ret;
        }

        public Status EstimateTransform(IEnumerable<Mat> images, Rect[][] rois)
        {
            ArgumentNullException.ThrowIfNull(images);
            ArgumentNullException.ThrowIfNull(rois);

            var imagesPtrs = images.Select(x => x.CvPtr).ToArray();
            using var roisPointer = new ArrayAddress2<Rect>(rois);
            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_estimateTransform_MatArray2(
                    Handle, imagesPtrs, imagesPtrs.Length,
                    roisPointer.GetPointer(), roisPointer.GetDim1Length(), roisPointer.GetDim2Lengths(),
                    out var ret));

            GC.KeepAlive(images);
            return (Status)ret;
        }

        public Status ComposePanorama(OutputArray pano)
        {
            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_composePanorama1(Handle, pano.Proxy, out var ret));

            GC.KeepAlive(pano.Source);
            return (Status)ret;
        }

        public Status ComposePanorama(InputArray images, OutputArray pano)
        {
            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_composePanorama2_InputArray(Handle, images.Proxy, pano.Proxy, out var ret));

            GC.KeepAlive(images.Source);
            GC.KeepAlive(pano.Source);
            return (Status)ret;
        }

        public Status ComposePanorama(IEnumerable<Mat> images, OutputArray pano)
        {
            ArgumentNullException.ThrowIfNull(images);

            var imagesPtrs = images.Select(x => x.CvPtr).ToArray();
            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_composePanorama2_MatArray(Handle, imagesPtrs, imagesPtrs.Length, pano.Proxy, out var ret));

            GC.KeepAlive(images);
            GC.KeepAlive(pano.Source);
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
            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_stitch1_InputArray(Handle, images.Proxy, pano.Proxy, out var ret));

            GC.KeepAlive(images.Source);
            GC.KeepAlive(pano.Source);

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
            ArgumentNullException.ThrowIfNull(images);

            var imagesPtrs = images.Select(x => x.CvPtr).ToArray();

            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_stitch1_MatArray(Handle, imagesPtrs, imagesPtrs.Length, pano.Proxy, out var ret));

            GC.KeepAlive(images);
            GC.KeepAlive(pano.Source);

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
            ArgumentNullException.ThrowIfNull(rois);

            using var roisPointer = new ArrayAddress2<Rect>(rois);
            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_stitch2_InputArray(Handle, images.Proxy, roisPointer.GetPointer(), roisPointer.GetDim1Length(), roisPointer.GetDim2Lengths(), pano.Proxy, out var ret));

            GC.KeepAlive(images.Source);
            GC.KeepAlive(pano.Source);
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
            ArgumentNullException.ThrowIfNull(images);
            ArgumentNullException.ThrowIfNull(rois);

            var imagesPtrs = images.Select(x => x.CvPtr).ToArray();

            using var roisPointer = new ArrayAddress2<Rect>(rois);
            NativeMethods.HandleException(
                NativeMethods.stitching_Stitcher_stitch2_MatArray(Handle, imagesPtrs, imagesPtrs.Length, roisPointer.GetPointer(), roisPointer.GetDim1Length(), roisPointer.GetDim2Lengths(), pano.Proxy, out var ret));

            GC.KeepAlive(images);
            GC.KeepAlive(pano.Source);
            return (Status)ret;
        }

        // Stitcher's native setters wrap these in a non-owning cv::Ptr (no-op deleter), so the
        // managed side is solely responsible for keeping the object alive for as long as it's
        // attached to this Stitcher - otherwise the GC could collect it and free the native
        // object out from under the Stitcher, causing a use-after-free.
        private Feature2D? featuresFinderRef;
        private FeaturesMatcher? featuresMatcherRef;
        private BundleAdjusterBase? bundleAdjusterRef;
        private WarperCreator? warperRef;
        private ExposureCompensator? exposureCompensatorRef;
        private SeamFinder? seamFinderRef;
        private Blender? blenderRef;

        /// <summary>
        /// Sets the features finder used to detect keypoints and compute descriptors.
        /// </summary>
        public void SetFeaturesFinder(Feature2D featuresFinder)
        {
            ArgumentNullException.ThrowIfNull(featuresFinder);
            NativeMethods.HandleException(NativeMethods.stitching_Stitcher_setFeaturesFinder(Handle, featuresFinder.RawPtr));
            GC.KeepAlive(featuresFinder);
            featuresFinderRef = featuresFinder;
        }

        /// <summary>
        /// Sets the features matcher used to match images pairwise.
        /// </summary>
        public void SetFeaturesMatcher(FeaturesMatcher featuresMatcher)
        {
            ArgumentNullException.ThrowIfNull(featuresMatcher);
            NativeMethods.HandleException(NativeMethods.stitching_Stitcher_setFeaturesMatcher(Handle, featuresMatcher.CvPtr));
            GC.KeepAlive(featuresMatcher);
            featuresMatcherRef = featuresMatcher;
        }

        /// <summary>
        /// Sets the bundle adjuster used to refine camera parameters.
        /// </summary>
        public void SetBundleAdjuster(BundleAdjusterBase bundleAdjuster)
        {
            ArgumentNullException.ThrowIfNull(bundleAdjuster);
            NativeMethods.HandleException(NativeMethods.stitching_Stitcher_setBundleAdjuster(Handle, bundleAdjuster.CvPtr));
            GC.KeepAlive(bundleAdjuster);
            bundleAdjusterRef = bundleAdjuster;
        }

        /// <summary>
        /// Sets the warper creator used to project images onto the panorama surface.
        /// </summary>
        public void SetWarper(WarperCreator warper)
        {
            ArgumentNullException.ThrowIfNull(warper);
            NativeMethods.HandleException(NativeMethods.stitching_Stitcher_setWarper(Handle, warper.CvPtr));
            GC.KeepAlive(warper);
            warperRef = warper;
        }

        /// <summary>
        /// Sets the exposure compensator used to remove exposure related artifacts.
        /// </summary>
        public void SetExposureCompensator(ExposureCompensator exposureCompensator)
        {
            ArgumentNullException.ThrowIfNull(exposureCompensator);
            NativeMethods.HandleException(NativeMethods.stitching_Stitcher_setExposureCompensator(Handle, exposureCompensator.CvPtr));
            GC.KeepAlive(exposureCompensator);
            exposureCompensatorRef = exposureCompensator;
        }

        /// <summary>
        /// Sets the seam finder used to estimate seams between images.
        /// </summary>
        public void SetSeamFinder(SeamFinder seamFinder)
        {
            ArgumentNullException.ThrowIfNull(seamFinder);
            NativeMethods.HandleException(NativeMethods.stitching_Stitcher_setSeamFinder(Handle, seamFinder.CvPtr));
            GC.KeepAlive(seamFinder);
            seamFinderRef = seamFinder;
        }

        /// <summary>
        /// Sets the blender used to compose the final panorama.
        /// </summary>
        public void SetBlender(Blender blender)
        {
            ArgumentNullException.ThrowIfNull(blender);
            NativeMethods.HandleException(NativeMethods.stitching_Stitcher_setBlender(Handle, blender.CvPtr));
            GC.KeepAlive(blender);
            blenderRef = blender;
        }

        #endregion

            }
        }
