using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Cv2
    {
        #region GetGaborKernel
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ksize"></param>
        /// <param name="sigma"></param>
        /// <param name="theta"></param>
        /// <param name="lambd"></param>
        /// <param name="gamma"></param>
        /// <param name="psi"></param>
        /// <param name="ktype"></param>
        /// <returns></returns>
        public static Mat GetGaborKernel(Size ksize, double sigma, double theta, double lambd, double gamma, double psi, int ktype)
        {
            IntPtr matPtr = CppInvoke.imgproc_getGaborKernel(ksize, sigma, theta, lambd, gamma, psi, ktype);
            return new Mat(matPtr);
        }
        #endregion
        #region GetStructuringElement
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="ksize"></param>
        /// <returns></returns>
        public static Mat GetStructuringElement(StructuringElementShape shape, Size ksize)
        {
            return GetStructuringElement(shape, ksize, new Point(-1, -1));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="ksize"></param>
        /// <param name="anchor"></param>
        /// <returns></returns>
        public static Mat GetStructuringElement(StructuringElementShape shape, Size ksize, Point anchor)
        {
            IntPtr matPtr = CppInvoke.imgproc_getStructuringElement((int)shape, ksize, anchor);
            return new Mat(matPtr);
        }
        #endregion
        #region CvtColor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="code"></param>
        /// <param name="dstCn"></param>
        public static void CvtColor(InputArray src, OutputArray dst, int code, int dstCn = 0)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            try
            {
                CppInvoke.imgproc_cvtColor(src.CvPtr, dst.CvPtr, code, dstCn);
                dst.AssignResultAndDispose();
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region CopyMakeBorder
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="top"></param>
        /// <param name="bottom"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="borderType"></param>
        public static void CopyMakeBorder(InputArray src, OutputArray dst, int top, int bottom, int left, int right, BorderType borderType)
        {
            CopyMakeBorder(src, dst, top, bottom, left, right, borderType, new Scalar());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="top"></param>
        /// <param name="bottom"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="borderType"></param>
        /// <param name="value"></param>
        public static void CopyMakeBorder(InputArray src, OutputArray dst, int top, int bottom, int left, int right, BorderType borderType, Scalar value)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            try
            {
                CppInvoke.imgproc_copyMakeBorder(src.CvPtr, dst.CvPtr, top, bottom, left, right, (int)borderType, value);
                dst.AssignResultAndDispose();
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region MedianBlur
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ksize"></param>
        public static void MedianBlur(InputArray src, OutputArray dst, int ksize)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            try
            {
                CppInvoke.imgproc_medianBlur(src.CvPtr, dst.CvPtr, ksize);
                dst.AssignResultAndDispose();
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region GaussianBlur
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ksize"></param>
        /// <param name="sigmaX"></param>
        /// <param name="sigmaY"></param>
        /// <param name="borderType"></param>
        public static void GaussianBlur(InputArray src, OutputArray dst, Size ksize, double sigmaX, 
            double sigmaY = 0, BorderType borderType = BorderType.Default)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            try
            {
                CppInvoke.imgproc_GaussianBlur(src.CvPtr, dst.CvPtr, ksize, sigmaX, sigmaY, (int)borderType);
                dst.AssignResultAndDispose();
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region BilateralFilter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="d"></param>
        /// <param name="sigmaColor"></param>
        /// <param name="sigmaSpace"></param>
        /// <param name="borderType"></param>
        public static void BilateralFilter(InputArray src, OutputArray dst, int d, double sigmaColor, double sigmaSpace, BorderType borderType = BorderType.Default)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_bilateralFilter(src.CvPtr, dst.CvPtr, d, sigmaColor, sigmaSpace, (int)borderType);
            dst.AssignResultAndDispose();
        }
        #endregion

        #region AdaptiveBilateralFilter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ksize"></param>
        /// <param name="sigmaSpace"></param>
        public static void AdaptiveBilateralFilter(InputArray src, OutputArray dst, Size ksize, double sigmaSpace)
        {
            AdaptiveBilateralFilter(src, dst, ksize, sigmaSpace, 20.0, new Point(-1, -1), BorderType.Default);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ksize"></param>
        /// <param name="sigmaSpace"></param>
        /// <param name="maxSigmaColor"></param>
        public static void AdaptiveBilateralFilter(InputArray src, OutputArray dst, Size ksize, double sigmaSpace, double maxSigmaColor)
        {
            AdaptiveBilateralFilter(src, dst, ksize, sigmaSpace, maxSigmaColor, new Point(-1, -1), BorderType.Default);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ksize"></param>
        /// <param name="sigmaSpace"></param>
        /// <param name="maxSigmaColor"></param>
        /// <param name="anchor"></param>
        public static void AdaptiveBilateralFilter(InputArray src, OutputArray dst, Size ksize, double sigmaSpace, double maxSigmaColor, Point anchor)
        {
            AdaptiveBilateralFilter(src, dst, ksize, sigmaSpace, maxSigmaColor, anchor, BorderType.Default);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="ksize"></param>
        /// <param name="sigmaSpace"></param>
        /// <param name="maxSigmaColor"></param>
        /// <param name="anchor"></param>
        /// <param name="borderType"></param>
        public static void AdaptiveBilateralFilter(InputArray src, OutputArray dst, Size ksize,
            double sigmaSpace, double maxSigmaColor, Point anchor, BorderType borderType)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.imgproc_adaptiveBilateralFilter(src.CvPtr, dst.CvPtr, ksize, sigmaSpace, maxSigmaColor, anchor, (int)borderType);
            dst.AssignResultAndDispose();
        }
        #endregion

        public static void BoxFilter(InputArray src, OutputArray dst, int ddepth, CvSize ksize, CvPoint anchor, bool normalize, BorderType borderType)
        {

        }

        public static void Blur(InputArray src, OutputArray dst, CvSize ksize, CvPoint anchor, BorderType borderType)
        {

        }
    }
}
