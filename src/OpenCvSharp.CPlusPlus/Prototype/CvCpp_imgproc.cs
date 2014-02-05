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
    public static partial class CvCpp
    {
        public static void CvtColor(InputArray src, OutputArray dst, int code, int dstCn = 0)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfDisposed();
            try
            {
                CppInvoke.imgproc_cvtColor(src.CvPtr, dst.CvPtr, code, dstCn);
                dst.AssignResult();
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        public static void CopyMakeBorder(InputArray src, OutputArray dst, int top, int bottom, int left, int right, int borderType, CvScalar value)
        {
        }

        public static void MedianBlur(InputArray src, OutputArray dst, int ksize)
        {

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
