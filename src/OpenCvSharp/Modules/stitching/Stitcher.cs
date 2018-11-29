using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Detail;
using OpenCvSharp.Util;

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

        public class FeaturesMatcher
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
        private Ptr ptrObj;

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
            IntPtr p = NativeMethods.stitching_Stitcher_create((int)mode);
            return new Stitcher(p);
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
                var res = NativeMethods.stitching_Stitcher_registrationResol(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.stitching_Stitcher_setRegistrationResol(ptr, value);
                GC.KeepAlive(this);
            }
        }

        public double SeamEstimationResol
        {
            get
            {
                var res = NativeMethods.stitching_Stitcher_seamEstimationResol(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.stitching_Stitcher_setSeamEstimationResol(ptr, value);
                GC.KeepAlive(this);
            }
        }

        public double CompositingResol
        {
            get
            {
                var res = NativeMethods.stitching_Stitcher_compositingResol(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.stitching_Stitcher_setCompositingResol(ptr, value);
                GC.KeepAlive(this);
            }
        }

        public double PanoConfidenceThresh
        {
            get
            {
                var res = NativeMethods.stitching_Stitcher_panoConfidenceThresh(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.stitching_Stitcher_setPanoConfidenceThresh(ptr, value);
                GC.KeepAlive(this);
            }
        }

        public bool WaveCorrection
        {
            get
            {
                var res = NativeMethods.stitching_Stitcher_waveCorrection(ptr) != 0;
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.stitching_Stitcher_setWaveCorrection(ptr, value ? 1 : 0);
                GC.KeepAlive(this);
            }
        }

        public WaveCorrectKind WaveCorrectKind
        {
            get
            {
                var res = (WaveCorrectKind)NativeMethods.stitching_Stitcher_waveCorrectKind(ptr);
                GC.KeepAlive(this);
                return res;
            }
            set
            {
                NativeMethods.stitching_Stitcher_setWaveCorrectKind(ptr, (int)value);
                GC.KeepAlive(this);
            }
        }

        public FeaturesFinder FeaturesFinder
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }


        public FeaturesMatcher FeaturesMatcher
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Mat MatchingMask
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public BundleAdjusterBase BundleAdjuster
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public WarperCreator Warper
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public ExposureCompensator ExposureCompensator
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public SeamFinder SeamFinder
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Blender Blender
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        
        public int[] Component
        {
            get
            {
                IntPtr pointer;
                int length;
                NativeMethods.stitching_Stitcher_component(ptr, out pointer, out length);

                int[] ret = new int[length];
                Marshal.Copy(pointer, ret, 0, length);
                GC.KeepAlive(this); // needs to be after copy of unmanaged data
                return ret;
            }
        }

        public CameraParams[] Cameras
        {
            get { throw new NotImplementedException(); }
        }

        public double WorkScale
        {
            get
            {
                var res = NativeMethods.stitching_Stitcher_workScale(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        #endregion

        #region Methods

        public Status EstimateTransform(InputArray images)
        {
            if (images == null)
                throw new ArgumentNullException(nameof(images));
            images.ThrowIfDisposed();

            int status = NativeMethods.stitching_Stitcher_estimateTransform_InputArray1(
                ptr, images.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(images);
            return (Status)status;
        }

        public Status EstimateTransform(InputArray images, Rect[][] rois)
        {
            if (images == null)
                throw new ArgumentNullException(nameof(images));
            if (rois == null)
                throw new ArgumentNullException(nameof(rois));
            images.ThrowIfDisposed();

            using (var roisPointer = new ArrayAddress2<Rect>(rois))
            {
                int status = NativeMethods.stitching_Stitcher_estimateTransform_InputArray2(
                    ptr, images.CvPtr,
                    roisPointer.Pointer, roisPointer.Dim1Length, roisPointer.Dim2Lengths);
                GC.KeepAlive(this);
                GC.KeepAlive(images);
                return (Status)status;
            }
        }

        public Status EstimateTransform(IEnumerable<Mat> images)
        {
            if (images == null)
                throw new ArgumentNullException(nameof(images));

            IntPtr[] imagesPtrs = EnumerableEx.SelectPtrs(images);

            int status = NativeMethods.stitching_Stitcher_estimateTransform_MatArray1(
                ptr, imagesPtrs, imagesPtrs.Length);
            GC.KeepAlive(this);
            GC.KeepAlive(images);
            return (Status)status;
        }

        public Status EstimateTransform(IEnumerable<Mat> images, Rect[][] rois)
        {
            if (images == null)
                throw new ArgumentNullException(nameof(images));
            if (rois == null)
                throw new ArgumentNullException(nameof(rois));

            IntPtr[] imagesPtrs = EnumerableEx.SelectPtrs(images);

            using (var roisPointer = new ArrayAddress2<Rect>(rois))
            {
                int status = NativeMethods.stitching_Stitcher_estimateTransform_MatArray2(
                    ptr, imagesPtrs, imagesPtrs.Length,
                    roisPointer.Pointer, roisPointer.Dim1Length, roisPointer.Dim2Lengths);
                GC.KeepAlive(this);
                GC.KeepAlive(images);
                return (Status)status;
            }
        }

        public Status ComposePanorama(OutputArray pano)
        {
            if (pano == null)
                throw new ArgumentNullException(nameof(pano));
            pano.ThrowIfNotReady();

            int status = NativeMethods.stitching_Stitcher_composePanorama1(
                ptr, pano.CvPtr);
            pano.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(pano);
            return (Status)status;
        }

        public Status ComposePanorama(InputArray images, OutputArray pano)
        {
            if (images == null)
                throw new ArgumentNullException(nameof(images));
            if (pano == null)
                throw new ArgumentNullException(nameof(pano));
            images.ThrowIfDisposed();
            pano.ThrowIfNotReady();

            int status = NativeMethods.stitching_Stitcher_composePanorama2_InputArray(
                ptr, images.CvPtr, pano.CvPtr);
            pano.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(images);
            GC.KeepAlive(pano);
            return (Status)status;
        }

        public Status ComposePanorama(IEnumerable<Mat> images, OutputArray pano)
        {
            if (images == null)
                throw new ArgumentNullException(nameof(images));
            if (pano == null)
                throw new ArgumentNullException(nameof(pano));
            pano.ThrowIfNotReady();

            IntPtr[] imagesPtrs = EnumerableEx.SelectPtrs(images);
            int status = NativeMethods.stitching_Stitcher_composePanorama2_MatArray(
                ptr, imagesPtrs, imagesPtrs.Length, pano.CvPtr);
            pano.Fix();
            GC.KeepAlive(this);
            GC.KeepAlive(images);
            GC.KeepAlive(pano);
            return (Status)status;
        }

        /// <summary>
        /// Try to stitch the given images.
        /// </summary>
        /// <param name="images">Input images.</param>
        /// <param name="pano">Final pano.</param>
        /// <returns>Status code.</returns>
        public Status Stitch(InputArray images, OutputArray pano)
        {
            if (images == null)
                throw new ArgumentNullException(nameof(images));
            if (pano == null)
                throw new ArgumentNullException(nameof(pano));
            images.ThrowIfDisposed();
            pano.ThrowIfNotReady();

            Status status = (Status)NativeMethods.stitching_Stitcher_stitch1_InputArray(
                ptr, images.CvPtr, pano.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(images);
            GC.KeepAlive(pano);
            pano.Fix();

            return status;
        }

        /// <summary>
        /// Try to stitch the given images.
        /// </summary>
        /// <param name="images">Input images.</param>
        /// <param name="pano">Final pano.</param>
        /// <returns>Status code.</returns>
        public Status Stitch(IEnumerable<Mat> images, OutputArray pano)
        {
            if (images == null)
                throw new ArgumentNullException(nameof(images));
            if (pano == null)
                throw new ArgumentNullException(nameof(pano));
            pano.ThrowIfNotReady();

            IntPtr[] imagesPtrs = EnumerableEx.SelectPtrs(images);

            Status status = (Status)NativeMethods.stitching_Stitcher_stitch1_MatArray(
                ptr, imagesPtrs, imagesPtrs.Length, pano.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(images);
            GC.KeepAlive(pano);
            pano.Fix();

            return status;
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
            if (images == null)
                throw new ArgumentNullException(nameof(images));
            if (rois == null)
                throw new ArgumentNullException(nameof(rois));
            if (pano == null)
                throw new ArgumentNullException(nameof(pano));
            images.ThrowIfDisposed();
            pano.ThrowIfNotReady();

            using (var roisPointer = new ArrayAddress2<Rect>(rois))
            {
                int status = NativeMethods.stitching_Stitcher_stitch2_InputArray(
                    ptr, images.CvPtr,
                    roisPointer.Pointer, roisPointer.Dim1Length, roisPointer.Dim2Lengths,
                    pano.CvPtr);
                pano.Fix();
                GC.KeepAlive(this);
                GC.KeepAlive(images);
                GC.KeepAlive(pano);
                return (Status)status;
            }
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
            if (images == null)
                throw new ArgumentNullException(nameof(images));
            if (rois == null)
                throw new ArgumentNullException(nameof(rois));
            if (pano == null)
                throw new ArgumentNullException(nameof(pano));
            pano.ThrowIfNotReady();

            IntPtr[] imagesPtrs = EnumerableEx.SelectPtrs(images);

            using (var roisPointer = new ArrayAddress2<Rect>(rois))
            {
                int status = NativeMethods.stitching_Stitcher_stitch2_MatArray(
                    ptr, imagesPtrs, imagesPtrs.Length,
                    roisPointer.Pointer, roisPointer.Dim1Length, roisPointer.Dim2Lengths,
                    pano.CvPtr);
                pano.Fix();
                GC.KeepAlive(this);
                GC.KeepAlive(images);
                GC.KeepAlive(pano);
                return (Status)status;
            }
        }

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.stitching_Ptr_Stitcher_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.stitching_Ptr_Stitcher_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
