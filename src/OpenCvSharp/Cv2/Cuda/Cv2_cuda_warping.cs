using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using OpenCvSharp.Cuda;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

public static partial class Cv2
{
    public static partial class Cuda
    {
        #region BuildWarpAffineMaps

        /// <summary>
        /// Builds transformation maps for affine transformation. 
        /// </summary>
        public static void BuildWarpAffineMaps(InputArray src, bool inverse, Size dsize, OpenCvSharp.Cuda.OutputArray xmap, OpenCvSharp.Cuda.OutputArray ymap, 
            OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (xmap is null)
                throw new ArgumentNullException(nameof(xmap));
            if (ymap is null)
                throw new ArgumentNullException(nameof(ymap));
            src.ThrowIfDisposed();
            xmap.ThrowIfNotReady();
            ymap.ThrowIfNotReady();

            NativeMethods.HandleException(NativeMethods.cuda_buildWarpAffineMaps(src.CvPtr, inverse ? 1 : 0, dsize, xmap.CvPtr, ymap.CvPtr, ToPtr(stream)));

            GC.KeepAlive(src);
            xmap.Fix();
            ymap.Fix();
        }

        #endregion

        #region BuildWarpPerspectiveMaps
        /// <summary>
        /// Builds transformation maps for perspective transformation. 
        /// </summary>
        public static void BuildWarpPerspectiveMaps(InputArray src, bool inverse, Size dsize, OpenCvSharp.Cuda.OutputArray xmap, 
            OpenCvSharp.Cuda.OutputArray ymap, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (xmap is null)
                throw new ArgumentNullException(nameof(xmap));
            if (ymap is null)
                throw new ArgumentNullException(nameof(ymap));
            src.ThrowIfDisposed();
            xmap.ThrowIfNotReady();
            ymap.ThrowIfNotReady();

            NativeMethods.HandleException(NativeMethods.cuda_buildWarpPerspectiveMaps(src.CvPtr, inverse ? 1 : 0, dsize, xmap.CvPtr, ymap.CvPtr, ToPtr(stream)));

            GC.KeepAlive(src);
            xmap.Fix();
            ymap.Fix();
        }

        #endregion

        #region PyrDown

        /// <summary>
        /// Smoothes an image and downsamples it.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image; will have Size((src.cols+1)/2, (src.rows+1)/2) and the same type as src.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void PyrDown(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_pyrDown(src.CvPtr, dst.CvPtr, ToPtr(stream)));
            
            GC.KeepAlive(src);
            dst.Fix();
            
        }

        #endregion

        #region pyrUp

        /// <summary>
        /// Upsamples an image and then smoothes it.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image; will have Size(src.cols*2, src.rows*2) and the same type as src.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void PyrUp(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_pyrUp(src.CvPtr, dst.CvPtr, ToPtr(stream)));
            
            GC.KeepAlive(src);
            dst.Fix();
            
        }

        #endregion

        #region Remap
        /// <summary>
        /// Applies a generic geometrical transformation to an image.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image. It has the same size as xmap and the same type as src.</param>
        /// <param name="xmap">Map of X coordinates. CV_32FC1 or CV_32FC2.</param>
        /// <param name="ymap">Map of Y coordinates. CV_32FC1 (empty if xmap is CV_32FC2).</param>
        /// <param name="interpolation">Interpolation method (InterpolationFlags.Linear, InterpolationFlags.Nearest).</param>
        /// <param name="borderMode">Pixel extrapolation method.</param>
        /// <param name="borderValue">Value used in case of a constant border.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Remap(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst,   
            OpenCvSharp.Cuda.InputArray xmap, OpenCvSharp.Cuda.InputArray ymap, InterpolationFlags interpolation, BorderTypes borderMode = BorderTypes.Constant,  Scalar? borderValue = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));
            if (xmap is null) 
                throw new ArgumentNullException(nameof(xmap));
            if (ymap is null) 
                throw new ArgumentNullException(nameof(ymap));

            src.ThrowIfDisposed();
            xmap.ThrowIfDisposed();
            ymap.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            Scalar bValue = borderValue ?? new Scalar();

            NativeMethods.HandleException(
                NativeMethods.cuda_remap(
                    src.CvPtr, dst.CvPtr, xmap.CvPtr, ymap.CvPtr,
                    (int)interpolation, (int)borderMode, bValue, ToPtr(stream)));

            GC.KeepAlive(src);
            GC.KeepAlive(xmap);
            GC.KeepAlive(ymap);
            dst.Fix();

        }
        #endregion

        #region Resize
        /// <summary>
        /// Resizes an image.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image; will have Size dsize (when dsize is non-zero) or Size(round(src.cols*fx), round(src.rows*fy)) and the same type as src.</param>
        /// <param name="dsize">Destination size. If it is Size(0,0), it is computed as: dsize = Size(round(fx*src.cols), round(fy*src.rows))</param>
        /// <param name="fx">Scale factor along the horizontal axis. If it is 0, it is computed as (double)dsize.width/src.cols</param>
        /// <param name="fy">Scale factor along the vertical axis. If it is 0, it is computed as (double)dsize.height/src.rows</param>
        /// <param name="interpolation">Interpolation method (InterpolationFlags.Linear is default).</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Resize(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, Size dsize, double fx = 0, double fy = 0, InterpolationFlags interpolation = InterpolationFlags.Linear,
            OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_resize(
                    src.CvPtr, dst.CvPtr, dsize, fx, fy, (int)interpolation, ToPtr(stream)));
            GC.KeepAlive(src);
            dst.Fix();
          
        }

        #endregion

        #region Rotate
        /// <summary>
        /// Rotates an image around the origin (0,0) and then shifts it.
        /// </summary>
        /// <remarks>You will need the xshift and yshift or you are rotating your image outside your GpuMat</remarks>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="dsize">Size of the destination image.</param>
        /// <param name="angle">Angle of rotation in degrees.</param>
        /// <param name="xShift">Shift along the horizontal axis.</param>
        /// <param name="yShift">Shift along the vertical axis.</param>
        /// <param name="interpolation">Interpolation method.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void Rotate(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, 
            Size dsize, double angle, double xShift = 0, double yShift = 0, InterpolationFlags interpolation = InterpolationFlags.Linear, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.HandleException(
                NativeMethods.cuda_rotate(
                    src.CvPtr, dst.CvPtr, dsize, angle, xShift, yShift, (int)interpolation, ToPtr(stream)));

            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// Rotates an image similar like Cpu Version
        /// </summary>
        public static void Rotate(OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, RotateFlags rotateCode, InterpolationFlags interpolation = InterpolationFlags.Linear, OpenCvSharp.Cuda.Stream? stream = null)
        {
            double angle = 0;
            double xshift = 0;
            double yshift = 0;
            OpenCvSharp.Size s = src.Size();
            switch (rotateCode)
            {
                case RotateFlags.Rotate90Clockwise:
                    angle = 270;
                    xshift = s.Width - 1;
                    break;
                case RotateFlags.Rotate90Counterclockwise:
                    angle = 90;
                    yshift = s.Height - 1;
                    break;
                case RotateFlags.Rotate180:
                    angle = 180;
                    xshift = s.Width - 1;
                    yshift = s.Height - 1;
                    break;
            }

            Rotate(src, dst, s, angle, xshift, yshift, interpolation, stream);
        }

        #endregion

        #region WarpAffine
        /// <summary>
        /// Applies an affine transformation to an image.
        /// </summary>
        public static void WarpAffine( OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, InputArray M, Size dsize, InterpolationFlags flags = InterpolationFlags.Linear, BorderTypes borderMode = BorderTypes.Constant, Scalar? borderValue = null, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));
            if (M is null) 
                throw new ArgumentNullException(nameof(M));

            src.ThrowIfDisposed();
            M.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            Scalar bValue = borderValue ?? new Scalar();

            NativeMethods.HandleException(
                NativeMethods.cuda_warpAffine(
                    src.CvPtr, dst.CvPtr, M.CvPtr, dsize, (int)flags, (int)borderMode, bValue, ToPtr(stream)));

            GC.KeepAlive(src);
            GC.KeepAlive(M);
            dst.Fix();
         
        }

        #endregion

        #region WarpPerspective

        /// <summary>
        /// Applies a perspective transformation to an image.
        /// </summary>
        public static void WarpPerspective(
            OpenCvSharp.Cuda.InputArray src, OpenCvSharp.Cuda.OutputArray dst, InputArray M, Size dsize,
            InterpolationFlags flags = InterpolationFlags.Linear,
            BorderTypes borderMode = BorderTypes.Constant, Scalar? borderValue = null,
            OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (dst is null)
                throw new ArgumentNullException(nameof(dst));
            if (M is null) 
                throw new ArgumentNullException(nameof(M));

            src.ThrowIfDisposed();
            M.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            Scalar bValue = borderValue ?? new Scalar();

            NativeMethods.HandleException(
                NativeMethods.cuda_warpPerspective(
                    src.CvPtr, dst.CvPtr, M.CvPtr, dsize, (int)flags, (int)borderMode, bValue, ToPtr(stream)));

            GC.KeepAlive(src);
            GC.KeepAlive(M);
            dst.Fix();

        }

        #endregion
    }
}
