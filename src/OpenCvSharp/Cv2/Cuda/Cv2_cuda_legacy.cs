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

        #region CalcOpticalFlowBM
        /// <summary>
        /// Calculates optical flow for 2 images using block matching algorithm.
        /// </summary>
        /// <remarks>
        /// Only works when opencv is build with legacy support
        /// </remarks>
        public static void CalcOpticalFlowBM(
            GpuMat prev, GpuMat curr,
            Size blockSize, Size shiftSize, Size maxRange, bool usePrevious,
            GpuMat velx, GpuMat vely, GpuMat buf, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (prev is null) 
                throw new ArgumentNullException(nameof(prev));
            if (curr is null) 
                throw new ArgumentNullException(nameof(curr));
            if (velx is null) 
                throw new ArgumentNullException(nameof(velx));
            if (vely is null) 
                throw new ArgumentNullException(nameof(vely));
            if (buf is null) 
                throw new ArgumentNullException(nameof(buf));

            prev.ThrowIfDisposed();
            curr.ThrowIfDisposed();
            velx.ThrowIfDisposed();
            vely.ThrowIfDisposed();
            buf.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_calcOpticalFlowBM(
                    prev.CvPtr, curr.CvPtr, blockSize, shiftSize, maxRange,
                    usePrevious ? 1 : 0, velx.CvPtr, vely.CvPtr, buf.CvPtr, ToPtr(stream)));

            GC.KeepAlive(prev);
            GC.KeepAlive(curr);
            GC.KeepAlive(velx);
            GC.KeepAlive(vely);
            GC.KeepAlive(buf);
        }

        #endregion

        #region ConnectivityMask
        /// <summary>
        /// compute mask for Generalized Flood fill componetns labeling. 
        /// </summary>
        /// <remarks>
        /// Only works when opencv is build with legacy support. Use InRange.
        /// </remarks>
        public static void ConnectivityMask(GpuMat image, GpuMat mask, Scalar lo, Scalar hi, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (image is null) 
                throw new ArgumentNullException(nameof(image));
            if (mask is null) 
                throw new ArgumentNullException(nameof(mask));

            image.ThrowIfDisposed();
            mask.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_connectivityMask(image.CvPtr, mask.CvPtr, lo, hi, ToPtr(stream)));

            GC.KeepAlive(image);
            GC.KeepAlive(mask);
        }

        #endregion

        #region CreateOpticalFlowNeedleMap
        /// <summary>
        /// Creates a needle map (vector field visualization) from optical flow components.
        /// </summary>
        public static void CreateOpticalFlowNeedleMap(GpuMat u, GpuMat v, GpuMat vertex, GpuMat colors)
        {
            if (u is null) 
                throw new ArgumentNullException(nameof(u));
            if (v is null) 
                throw new ArgumentNullException(nameof(v));
            if (vertex is null) 
                throw new ArgumentNullException(nameof(vertex));
            if (colors is null) 
                throw new ArgumentNullException(nameof(colors));

            u.ThrowIfDisposed();
            v.ThrowIfDisposed();
            vertex.ThrowIfDisposed();
            colors.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_createOpticalFlowNeedleMap(u.CvPtr, v.CvPtr, vertex.CvPtr, colors.CvPtr));

            GC.KeepAlive(u);
            GC.KeepAlive(v);
            GC.KeepAlive(vertex);
            GC.KeepAlive(colors);
        }

        #endregion

        #region GraphCut

        /// <summary>
        /// Performs labeling via graph cuts of a 2D regular 4-connected graph.
        /// </summary>
        public static void Graphcut(GpuMat terminals, GpuMat leftTransp, GpuMat rightTransp, GpuMat top, GpuMat bottom, GpuMat labels, GpuMat buf, 
            OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (terminals is null) 
                throw new ArgumentNullException(nameof(terminals));
            if (leftTransp is null) 
                throw new ArgumentNullException(nameof(leftTransp));
            if (rightTransp is null) 
                throw new ArgumentNullException(nameof(rightTransp));
            if (top is null) 
                throw new ArgumentNullException(nameof(top));
            if (bottom is null) 
                throw new ArgumentNullException(nameof(bottom));
            if (labels is null) 
                throw new ArgumentNullException(nameof(labels));
            if (buf is null) 
                throw new ArgumentNullException(nameof(buf));

            terminals.ThrowIfDisposed();
            leftTransp.ThrowIfDisposed();
            rightTransp.ThrowIfDisposed();
            top.ThrowIfDisposed();
            bottom.ThrowIfDisposed();
            labels.ThrowIfDisposed();
            buf.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_graphcut(
                    terminals.CvPtr, leftTransp.CvPtr, rightTransp.CvPtr,
                    top.CvPtr, bottom.CvPtr, labels.CvPtr,
                    buf.CvPtr, ToPtr(stream)));

            GC.KeepAlive(terminals);
            GC.KeepAlive(leftTransp);
            GC.KeepAlive(rightTransp);
            GC.KeepAlive(top);
            GC.KeepAlive(bottom);
            GC.KeepAlive(labels);
            GC.KeepAlive(buf);
        }

        /// <summary>
        /// Performs labeling via graph cuts of a 2D regular 8-connected graph.
        /// </summary>
        public static void Graphcut(GpuMat terminals, GpuMat leftTransp, GpuMat rightTransp, GpuMat top, GpuMat topLeft, GpuMat topRight, 
            GpuMat bottom, GpuMat bottomLeft, GpuMat bottomRight, GpuMat labels, GpuMat buf, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (terminals is null) 
                throw new ArgumentNullException(nameof(terminals));
            if (leftTransp is null) 
                throw new ArgumentNullException(nameof(leftTransp));
            if (rightTransp is null) 
                throw new ArgumentNullException(nameof(rightTransp));
            if (top is null) 
                throw new ArgumentNullException(nameof(top));
            if (topLeft is null) 
                throw new ArgumentNullException(nameof(topLeft));
            if (topRight is null) 
                throw new ArgumentNullException(nameof(topRight));
            if (bottom is null) 
                throw new ArgumentNullException(nameof(bottom));
            if (bottomLeft is null) 
                throw new ArgumentNullException(nameof(bottomLeft));
            if (bottomRight is null) 
                throw new ArgumentNullException(nameof(bottomRight));
            if (labels is null) 
                throw new ArgumentNullException(nameof(labels));
            if (buf is null) 
                throw new ArgumentNullException(nameof(buf));

            terminals.ThrowIfDisposed();
            leftTransp.ThrowIfDisposed();
            rightTransp.ThrowIfDisposed();
            top.ThrowIfDisposed();
            topLeft.ThrowIfDisposed();
            topRight.ThrowIfDisposed();
            bottom.ThrowIfDisposed();
            bottomLeft.ThrowIfDisposed();
            bottomRight.ThrowIfDisposed();
            labels.ThrowIfDisposed();
            buf.ThrowIfDisposed();


            NativeMethods.HandleException(
                NativeMethods.cuda_graphcut8(terminals.CvPtr, leftTransp.CvPtr, rightTransp.CvPtr, top.CvPtr, topLeft.CvPtr, topRight.CvPtr, bottom.CvPtr, bottomLeft.CvPtr, bottomRight.CvPtr, labels.CvPtr, buf.CvPtr, ToPtr(stream)));

            GC.KeepAlive(terminals); 
            GC.KeepAlive(leftTransp); 
            GC.KeepAlive(rightTransp);
            GC.KeepAlive(top); 
            GC.KeepAlive(topLeft); 
            GC.KeepAlive(topRight);
            GC.KeepAlive(bottom); 
            GC.KeepAlive(bottomLeft); 
            GC.KeepAlive(bottomRight);
            GC.KeepAlive(labels); 
            GC.KeepAlive(buf);
        }

        #endregion

        #region InterpolateFrames

        /// <summary>
        /// Interpolates frames (images) using provided optical flow (displacement field).
        /// </summary>
        public static void InterpolateFrames(GpuMat frame0, GpuMat frame1, GpuMat fu, GpuMat fv, GpuMat bu, 
            GpuMat bv, float pos, GpuMat newFrame, GpuMat buf, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (frame0 is null)
                throw new ArgumentNullException(nameof(frame0));
            if (frame1 is null)
                throw new ArgumentNullException(nameof(frame1));
            if (fu is null)
                throw new ArgumentNullException(nameof(fu));
            if (fv is null)
                throw new ArgumentNullException(nameof(fv));
            if (bu is null)
                throw new ArgumentNullException(nameof(bu));
            if (bv is null)
                throw new ArgumentNullException(nameof(bv));
            if (buf is null)
                throw new ArgumentNullException(nameof(buf));
            if (newFrame is null)
                throw new ArgumentNullException(nameof(newFrame));
            frame0.ThrowIfDisposed();
            frame1.ThrowIfDisposed();
            fu.ThrowIfDisposed();
            fv.ThrowIfDisposed();
            bu.ThrowIfDisposed();
            bv.ThrowIfDisposed();
            buf.ThrowIfDisposed();
            newFrame.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_interpolateFrames(
                    frame0.CvPtr, frame1.CvPtr, fu.CvPtr, fv.CvPtr, bu.CvPtr, bv.CvPtr,
                    pos, newFrame.CvPtr, buf.CvPtr, ToPtr(stream)));

            GC.KeepAlive(frame0); 
            GC.KeepAlive(frame1);
            GC.KeepAlive(fu); 
            GC.KeepAlive(fv);
            GC.KeepAlive(bu); 
            GC.KeepAlive(bv);
            GC.KeepAlive(newFrame); 
            GC.KeepAlive(buf);
        }

        #endregion

        #region LabelComponents
        /// <summary>
        /// Performs connected components labeling.
        /// </summary>
        /// <param name="mask">8-bit single-channel binary source image.</param>
        /// <param name="components">Destination image (CV_32SC1) where each pixel contains the ID of its connected component.</param>
        /// <param name="flags">Reserved for future use (currently not used in OpenCV CUDA).</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void LabelComponents( GpuMat mask, GpuMat components, int flags = 0, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (mask is null) 
                throw new ArgumentNullException(nameof(mask));
            if (components is null) 
                throw new ArgumentNullException(nameof(components));

            mask.ThrowIfDisposed();
            components.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_labelComponents(mask.CvPtr, components.CvPtr, flags, ToPtr(stream)));

            GC.KeepAlive(mask);
            GC.KeepAlive(components);
        }

        #endregion

        #region ProjectPoints

        /// <summary>
        /// Projects 3D points to an image plane.
        /// </summary>
        /// <remarks>Use this function at your own risk. It is legacy.</remarks>
        /// <param name="src">3D points on GPU. Must be CV_32FC3 or CV_64FC3.</param>
        /// <param name="rvec">Rotation vector (CPU Mat).</param>
        /// <param name="tvec">Translation vector (CPU Mat).</param>
        /// <param name="cameraMat">Camera intrinsic matrix (CPU Mat).</param>
        /// <param name="distCoef">Distortion coefficients (CPU Mat).</param>
        /// <param name="dst">Output 2D points on GPU. Will be CV_32FC2 or CV_64FC2.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void ProjectPoints(GpuMat src, Mat rvec, Mat tvec, Mat cameraMat, Mat distCoef, GpuMat dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (rvec is null) 
                throw new ArgumentNullException(nameof(rvec));
            if (tvec is null) 
                throw new ArgumentNullException(nameof(tvec));
            if (cameraMat is null) 
                throw new ArgumentNullException(nameof(cameraMat));
            if (distCoef is null) 
                throw new ArgumentNullException(nameof(distCoef));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            rvec.ThrowIfDisposed();
            tvec.ThrowIfDisposed();
            cameraMat.ThrowIfDisposed();
            distCoef.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_projectPoints(
                    src.CvPtr, rvec.CvPtr, tvec.CvPtr,
                    cameraMat.CvPtr, distCoef.CvPtr,
                    dst.CvPtr, ToPtr(stream)));

            GC.KeepAlive(src);
            GC.KeepAlive(rvec);
            GC.KeepAlive(tvec);
            GC.KeepAlive(cameraMat);
            GC.KeepAlive(distCoef);
            GC.KeepAlive(dst);
        }

        #endregion

        #region SolvePnPRansac

        /// <summary>
        /// Finds the object pose from 3D-2D point correspondences using RANSAC scheme.
        /// </summary>
        /// <param name="object">Array of object points in the object coordinate space (CV_32FC3 or CV_64FC3).</param>
        /// <param name="image">Array of corresponding image points (CV_32FC2 or CV_64FC2).</param>
        /// <param name="cameraMat">Input camera matrix.</param>
        /// <param name="distCoef">Input vector of distortion coefficients.</param>
        /// <param name="rvec">Output rotation vector.</param>
        /// <param name="tvec">Output translation vector.</param>
        /// <param name="useExtrinsicGuess">If true, the function uses the provided rvec and tvec values as initial approximations.</param>
        /// <param name="numIters">Number of iterations.</param>
        /// <param name="maxDist">Parameter used by the RANSAC algorithm to distinguish between inliers and outliers.</param>
        /// <param name="minInlierCount">Minimum number of inliers to consider the solution valid.</param>
        /// <param name="inliers">Output vector that contains indices of inliers in objectPoints and imagePoints.</param>
        public static void SolvePnPRansac(
            Mat obj, Mat image, Mat cameraMat, Mat distCoef,
            Mat rvec, Mat tvec, bool useExtrinsicGuess = false, int numIters = 100,
            float maxDist = 8.0f, int minInlierCount = 100, OutputArray? inliers = null)
        {
            if (obj is null) 
                throw new ArgumentNullException(nameof(obj));
            if (image is null) 
                throw new ArgumentNullException(nameof(image));
            if (cameraMat is null) 
                throw new ArgumentNullException(nameof(cameraMat));
            if (distCoef is null)
                throw new ArgumentNullException(nameof(distCoef));
            if (rvec is null) 
                throw new ArgumentNullException(nameof(rvec));
            if (tvec is null) 
                throw new ArgumentNullException(nameof(tvec));

            NativeMethods.HandleException(
                NativeMethods.cuda_solvePnPRansac(
                    obj.CvPtr, image.CvPtr, cameraMat.CvPtr, distCoef.CvPtr,
                    rvec.CvPtr, tvec.CvPtr, useExtrinsicGuess ? 1 : 0, numIters,
                    maxDist, minInlierCount, inliers?.CvPtr ?? IntPtr.Zero));

            GC.KeepAlive(obj);
            GC.KeepAlive(image);
            GC.KeepAlive(cameraMat);
            GC.KeepAlive(distCoef);
            GC.KeepAlive(rvec);
            GC.KeepAlive(tvec);
            inliers?.Fix();
        
        }

        #endregion

        #region Transform Points

        /// <summary>
        /// Transforms 3D points using a rotation vector and a translation vector.
        /// </summary>
        /// <param name="src">Source 3D points on GPU. Must be CV_32FC3 or CV_64FC3.</param>
        /// <param name="rvec">Rotation vector (CPU Mat, 1x3 or 3x1).</param>
        /// <param name="tvec">Translation vector (CPU Mat, 1x3 or 3x1).</param>
        /// <param name="dst">Destination 3D points on GPU.</param>
        /// <param name="stream">Stream for the asynchronous version.</param>
        public static void TransformPoints(GpuMat src, Mat rvec, Mat tvec, GpuMat dst, OpenCvSharp.Cuda.Stream? stream = null)
        {
            if (src is null) 
                throw new ArgumentNullException(nameof(src));
            if (rvec is null) 
                throw new ArgumentNullException(nameof(rvec));
            if (tvec is null) 
                throw new ArgumentNullException(nameof(tvec));
            if (dst is null) 
                throw new ArgumentNullException(nameof(dst));

            src.ThrowIfDisposed();
            rvec.ThrowIfDisposed();
            tvec.ThrowIfDisposed();
            dst.ThrowIfDisposed();

            NativeMethods.HandleException(
                NativeMethods.cuda_transformPoints(src.CvPtr, rvec.CvPtr, tvec.CvPtr, dst.CvPtr, ToPtr(stream)));

            GC.KeepAlive(src);
            GC.KeepAlive(rvec);
            GC.KeepAlive(tvec);
            GC.KeepAlive(dst);
        }

        #endregion

    }


}
