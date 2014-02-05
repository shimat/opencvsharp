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

        public static void GaussianBlur(InputArray src, OutputArray dst, CvSize ksize, double sigmaX, double sigmaY, int borderType)
        {

        }

        public static void BilateralFilter(InputArray src, OutputArray dst, int d, double sigmaColor, double sigmaSpace, int borderType)
        {

        }

        public static void BoxFilter(InputArray src, OutputArray dst, int ddepth, CvSize ksize, CvPoint anchor, bool normalize, int borderType)
        {

        }

        public static void Blur(InputArray src, OutputArray dst, CvSize ksize, CvPoint anchor, int borderType)
        {

        }
    }
}
