﻿using System;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class QRCodeDetector : DisposableCvObject
    {
        /// <summary>
        /// 
        /// </summary>
        public QRCodeDetector()
        {
            NativeMethods.HandleException(
                NativeMethods.objdetect_QRCodeDetector_new(out ptr));               
        }
        
        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.objdetect_QRCodeDetector_delete(ptr));
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// sets the epsilon used during the horizontal scan of QR code stop marker detection.
        /// </summary>
        /// <param name="epsX">Epsilon neighborhood, which allows you to determine the horizontal pattern 
        /// of the scheme 1:1:3:1:1 according to QR code standard.</param>
        public void SetEpsX(double epsX)
        {
            NativeMethods.HandleException(
                NativeMethods.objdetect_QRCodeDetector_setEpsX(ptr, epsX));
            GC.KeepAlive(this);
        }

        /// <summary>
        /// sets the epsilon used during the vertical scan of QR code stop marker detection.
        /// </summary>
        /// <param name="epsY">Epsilon neighborhood, which allows you to determine the vertical pattern
        /// of the scheme 1:1:3:1:1 according to QR code standard.</param>
        public void SetEpsY(double epsY)
        {
            NativeMethods.HandleException(
                NativeMethods.objdetect_QRCodeDetector_setEpsY(ptr, epsY));
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Detects QR code in image and returns the quadrangle containing the code.
        /// </summary>
        /// <param name="img">grayscale or color (BGR) image containing (or not) QR code.</param>
        /// <param name="points">Output vector of vertices of the minimum-area quadrangle containing the code.</param>
        /// <returns></returns>
        public bool Detect(InputArray img, out Point2f[] points)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            img.ThrowIfDisposed();

            using var pointsVec = new VectorOfPoint2f();

            NativeMethods.HandleException(
                NativeMethods.objdetect_QRCodeDetector_detect(ptr, img.CvPtr, pointsVec.CvPtr, out var ret));
            points = pointsVec.ToArray();

            GC.KeepAlive(img);
            GC.KeepAlive(this);

            return ret != 0;
        }

        /// <summary>
        /// Decodes QR code in image once it's found by the detect() method.
        /// Returns UTF8-encoded output string or empty string if the code cannot be decoded.
        /// </summary>
        /// <param name="img">grayscale or color (BGR) image containing QR code.</param>
        /// <param name="points">Quadrangle vertices found by detect() method (or some other algorithm).</param>
        /// <param name="straightQrCode">The optional output image containing rectified and binarized QR code</param>
        /// <returns></returns>
        public string Decode(InputArray img, IEnumerable<Point2f> points, OutputArray? straightQrCode = null)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (points == null)
                throw new ArgumentNullException(nameof(points));
            img.ThrowIfDisposed();
            straightQrCode?.ThrowIfNotReady();

            using var pointsVec = new VectorOfPoint2f(points);
            using var resultString = new StdString();
            NativeMethods.HandleException(
                NativeMethods.objdetect_QRCodeDetector_decode(
                ptr, img.CvPtr, pointsVec.CvPtr, Cv2.ToPtr(straightQrCode), resultString.CvPtr));

            GC.KeepAlive(img);
            GC.KeepAlive(points);
            GC.KeepAlive(straightQrCode);
            GC.KeepAlive(this);

            return resultString.ToString();
        }

        /// <summary>
        /// Both detects and decodes QR code
        /// </summary>
        /// <param name="img">grayscale or color (BGR) image containing QR code.</param>
        /// <param name="points">optional output array of vertices of the found QR code quadrangle. Will be empty if not found.</param>
        /// <param name="straightQrCode">The optional output image containing rectified and binarized QR code</param>
        /// <returns></returns>
        public string DetectAndDecode(InputArray img, out Point2f[] points, OutputArray? straightQrCode = null)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            img.ThrowIfDisposed();
            straightQrCode?.ThrowIfNotReady();

            using var pointsVec = new VectorOfPoint2f();
            using var resultString = new StdString();
            NativeMethods.HandleException(
                NativeMethods.objdetect_QRCodeDetector_detectAndDecode(
                ptr, img.CvPtr, pointsVec.CvPtr, Cv2.ToPtr(straightQrCode), resultString.CvPtr));
            points = pointsVec.ToArray();

            GC.KeepAlive(img);
            GC.KeepAlive(straightQrCode);
            GC.KeepAlive(this);

            return resultString.ToString();
        }
    }
}
