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
        private bool disposed;
        private Ptr<Stitcher> ptrObj;

        #region Enum

        public const int ORIG_RESOL = -1;

        /// <summary>
        /// Status code
        /// </summary>
        public enum Status
        {
            OK,
            ErrorNeedMoreImgs,
        }


        #endregion

        #region Init & Disposal

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ptr">cv::Stitcher*</param>
        private Stitcher(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Creates a stitcher with the default parameters.
        /// </summary>
        /// <param name="tryUseGpu">Flag indicating whether GPU should be used 
        /// whenever it's possible.</param>
        public static Stitcher Create(bool tryUseGpu = false)
        {
            IntPtr ptr = NativeMethods.stitching_createStitcher(tryUseGpu ? 1 : 0);
            return new Stitcher(ptr);
        }

        /// <summary>
        /// Deletes all resources 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    // releases managed resources
                    if (disposing)
                    {
                        if (ptrObj != null)
                        {
                            ptrObj.Dispose();
                            ptrObj = null;
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

        #endregion

        #region Properties

        public double RegistrationResol
        {
            get { return NativeMethods.stitching_Stitcher_registrationResol(ptr); }
            set { NativeMethods.stitching_Stitcher_setRegistrationResol(ptr, value); }
        }

        public double SeamEstimationResol
        {
            get { return NativeMethods.stitching_Stitcher_seamEstimationResol(ptr); }
            set { NativeMethods.stitching_Stitcher_setRegistrationResol(ptr, value); }
        }

        public double CompositingResol
        {
            get { return NativeMethods.stitching_Stitcher_compositingResol(ptr); }
            set { NativeMethods.stitching_Stitcher_setRegistrationResol(ptr, value); }
        }

        public double PanoConfidenceThresh
        {
            get { return NativeMethods.stitching_Stitcher_panoConfidenceThresh(ptr); }
            set { NativeMethods.stitching_Stitcher_setRegistrationResol(ptr, value); }
        }

        public bool WaveCorrection
        {
            get { return NativeMethods.stitching_Stitcher_waveCorrection(ptr) != 0; }
            set { NativeMethods.stitching_Stitcher_setRegistrationResol(ptr, value ? 1 : 0); }
        }

        public WaveCorrectKind WaveCorrectKind
        {
            get { return (WaveCorrectKind)NativeMethods.stitching_Stitcher_waveCorrectKind(ptr); }
            set { NativeMethods.stitching_Stitcher_setRegistrationResol(ptr, (int)value); }
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
                return ret;
            }
        }

        public CameraParams[] Cameras
        {
            get { throw new NotImplementedException(); }
        }

        public double WorkScale
        {
            get { return NativeMethods.stitching_Stitcher_workScale(ptr); }
        }

        #endregion

        #region Methods

        public Status EstimateTransform(InputArray images)
        {
            if (images == null)
                throw new ArgumentNullException("images");
            images.ThrowIfDisposed();

            int status = NativeMethods.stitching_Stitcher_estimateTransform_InputArray1(
                ptr, images.CvPtr);
            return (Status)status;
        }

        public Status EstimateTransform(InputArray images, Rect[][] rois)
        {
            if (images == null)
                throw new ArgumentNullException("images");
            if (rois == null)
                throw new ArgumentNullException("rois");
            images.ThrowIfDisposed();

            using (var roisPointer = new ArrayAddress2<Rect>(rois))
            {
                int status = NativeMethods.stitching_Stitcher_estimateTransform_InputArray2(
                    ptr, images.CvPtr,
                    roisPointer.Pointer, roisPointer.Dim1Length, roisPointer.Dim2Lengths);
                return (Status)status;
            }
        }

        public Status EstimateTransform(IEnumerable<Mat> images)
        {
            if (images == null)
                throw new ArgumentNullException("images");

            IntPtr[] imagesPtrs = EnumerableEx.SelectPtrs(images);

            int status = NativeMethods.stitching_Stitcher_estimateTransform_MatArray1(
                ptr, imagesPtrs, imagesPtrs.Length);
            return (Status)status;
        }

        public Status EstimateTransform(IEnumerable<Mat> images, Rect[][] rois)
        {
            if (images == null)
                throw new ArgumentNullException("images");
            if (rois == null)
                throw new ArgumentNullException("rois");

            IntPtr[] imagesPtrs = EnumerableEx.SelectPtrs(images);

            using (var roisPointer = new ArrayAddress2<Rect>(rois))
            {
                int status = NativeMethods.stitching_Stitcher_estimateTransform_MatArray2(
                    ptr, imagesPtrs, imagesPtrs.Length,
                    roisPointer.Pointer, roisPointer.Dim1Length, roisPointer.Dim2Lengths);
                return (Status)status;
            }
        }

        public Status ComposePanorama(OutputArray pano)
        {
            if (pano == null)
                throw new ArgumentNullException("pano");
            pano.ThrowIfNotReady();

            int status = NativeMethods.stitching_Stitcher_composePanorama1(
                ptr, pano.CvPtr);
            pano.Fix();
            return (Status)status;
        }

        public Status ComposePanorama(InputArray images, OutputArray pano)
        {
            if (images == null)
                throw new ArgumentNullException("images");
            if (pano == null)
                throw new ArgumentNullException("pano");
            images.ThrowIfDisposed();
            pano.ThrowIfNotReady();

            int status = NativeMethods.stitching_Stitcher_composePanorama2_InputArray(
                ptr, images.CvPtr, pano.CvPtr);
            pano.Fix();
            return (Status)status;
        }

        public Status ComposePanorama(IEnumerable<Mat> images, OutputArray pano)
        {
            if (images == null)
                throw new ArgumentNullException("images");
            if (pano == null)
                throw new ArgumentNullException("pano");
            pano.ThrowIfNotReady();

            IntPtr[] imagesPtrs = EnumerableEx.SelectPtrs(images);
            int status = NativeMethods.stitching_Stitcher_composePanorama2_MatArray(
                ptr, imagesPtrs, imagesPtrs.Length, pano.CvPtr);
            pano.Fix();
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
                throw new ArgumentNullException("images");
            if (pano == null)
                throw new ArgumentNullException("pano");
            images.ThrowIfDisposed();
            pano.ThrowIfNotReady();

            Status status = (Status)NativeMethods.stitching_Stitcher_stitch1_InputArray(
                ptr, images.CvPtr, pano.CvPtr);

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
                throw new ArgumentNullException("images");
            if (pano == null)
                throw new ArgumentNullException("pano");
            pano.ThrowIfNotReady();

            IntPtr[] imagesPtrs = EnumerableEx.SelectPtrs(images);

            Status status = (Status)NativeMethods.stitching_Stitcher_stitch1_MatArray(
                ptr, imagesPtrs, imagesPtrs.Length, pano.CvPtr);

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
                throw new ArgumentNullException("images");
            if (rois == null)
                throw new ArgumentNullException("rois");
            if (pano == null)
                throw new ArgumentNullException("pano");
            images.ThrowIfDisposed();
            pano.ThrowIfNotReady();

            using (var roisPointer = new ArrayAddress2<Rect>(rois))
            {
                int status = NativeMethods.stitching_Stitcher_stitch2_InputArray(
                    ptr, images.CvPtr,
                    roisPointer.Pointer, roisPointer.Dim1Length, roisPointer.Dim2Lengths,
                    pano.CvPtr);
                pano.Fix();
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
                throw new ArgumentNullException("images");
            if (rois == null)
                throw new ArgumentNullException("rois");
            if (pano == null)
                throw new ArgumentNullException("pano");
            pano.ThrowIfNotReady();

            IntPtr[] imagesPtrs = EnumerableEx.SelectPtrs(images);

            using (var roisPointer = new ArrayAddress2<Rect>(rois))
            {
                int status = NativeMethods.stitching_Stitcher_stitch2_MatArray(
                    ptr, imagesPtrs, imagesPtrs.Length,
                    roisPointer.Pointer, roisPointer.Dim1Length, roisPointer.Dim2Lengths,
                    pano.CvPtr);
                pano.Fix();
                return (Status)status;
            }
        }

        #endregion
    }
}
