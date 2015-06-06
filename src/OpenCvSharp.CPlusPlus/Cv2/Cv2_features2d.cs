using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
    static partial class Cv2
    {
        #region FAST/FASTX
        /// <summary>
        /// detects corners using FAST algorithm by E. Rosten
        /// </summary>
        /// <param name="image"></param>
        /// <param name="keypoints"></param>
        /// <param name="threshold"></param>
        /// <param name="nonmaxSupression"></param>
        public static void FAST(InputArray image, out KeyPoint[] keypoints, int threshold, bool nonmaxSupression = true)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();
            using (var kp = new VectorOfKeyPoint())
            {
                NativeMethods.features2d_FAST1(image.CvPtr, kp.CvPtr, threshold, nonmaxSupression ? 1 : 0);
                keypoints = kp.ToArray();
            }
            GC.KeepAlive(image);
        }

        /// <summary>
        /// detects corners using FAST algorithm by E. Rosten
        /// </summary>
        /// <param name="image"></param>
        /// <param name="keypoints"></param>
        /// <param name="threshold"></param>
        /// <param name="nonmaxSupression"></param>
        /// <param name="type"></param>
        public static void FAST(InputArray image, out KeyPoint[] keypoints, int threshold, bool nonmaxSupression, int type)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();
            using (var kp = new VectorOfKeyPoint())
            {
                NativeMethods.features2d_FAST2(image.CvPtr, kp.CvPtr, threshold, nonmaxSupression ? 1 : 0, type);
                keypoints = kp.ToArray();
            }
            GC.KeepAlive(image);
        }
        #endregion

        /// <summary>
        /// Draw keypoints.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="keypoints"></param>
        /// <param name="outImage"></param>
        /// <param name="color"></param>
        /// <param name="flags"></param>
        public static void DrawKeypoints(Mat image, IEnumerable<KeyPoint> keypoints, Mat outImage,
            Scalar? color = null, DrawMatchesFlags flags = DrawMatchesFlags.Default)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (outImage == null)
                throw new ArgumentNullException("outImage");
            if (keypoints == null)
                throw new ArgumentNullException("keypoints");
            image.ThrowIfDisposed();
            outImage.ThrowIfDisposed();

            KeyPoint[] keypointsArray = EnumerableEx.ToArray(keypoints);
            Scalar color0 = color.GetValueOrDefault(Scalar.All(-1));
            NativeMethods.features2d_drawKeypoints(image.CvPtr, keypointsArray, keypointsArray.Length,
                outImage.CvPtr, color0, (int)flags);
        }

        /// <summary>
        /// Draws matches of keypints from two images on output image.
        /// </summary>
        /// <param name="img1"></param>
        /// <param name="keypoints1"></param>
        /// <param name="img2"></param>
        /// <param name="keypoints2"></param>
        /// <param name="matches1To2"></param>
        /// <param name="outImg"></param>
        /// <param name="matchColor"></param>
        /// <param name="singlePointColor"></param>
        /// <param name="matchesMask"></param>
        /// <param name="flags"></param>
        public static void DrawMatches(Mat img1, IEnumerable<KeyPoint> keypoints1,
            Mat img2, IEnumerable<KeyPoint> keypoints2,
            IEnumerable<DMatch> matches1To2, Mat outImg,
            Scalar? matchColor = null, Scalar? singlePointColor = null,
            IEnumerable<byte> matchesMask = null, DrawMatchesFlags flags = DrawMatchesFlags.Default)
        {
            if (img1 == null)
                throw new ArgumentNullException("img1");
            if (img2 == null)
                throw new ArgumentNullException("img2");
            if (outImg == null)
                throw new ArgumentNullException("outImg");
            if (keypoints1 == null)
                throw new ArgumentNullException("keypoints1");
            if (keypoints2 == null)
                throw new ArgumentNullException("keypoints2");
            if (matches1To2 == null)
                throw new ArgumentNullException("matches1To2");
            img1.ThrowIfDisposed();
            img2.ThrowIfDisposed();
            outImg.ThrowIfDisposed();

            KeyPoint[] keypoints1Array = EnumerableEx.ToArray(keypoints1);
            KeyPoint[] keypoints2Array = EnumerableEx.ToArray(keypoints2);
            DMatch[] matches1To2Array = EnumerableEx.ToArray(matches1To2);
            Scalar matchColor0 = matchColor.GetValueOrDefault(Scalar.All(-1));
            Scalar singlePointColor0 = singlePointColor.GetValueOrDefault(Scalar.All(-1));

            byte[] matchesMaskArray = null;
            int matchesMaskLength = 0;
            if (matchesMask != null)
            {
                matchesMaskArray = EnumerableEx.ToArray(matchesMask);
                matchesMaskLength = matchesMaskArray.Length;
            }

            NativeMethods.features2d_drawMatches1(img1.CvPtr, keypoints1Array, keypoints1Array.Length,
                img2.CvPtr, keypoints2Array, keypoints2Array.Length,
                matches1To2Array, matches1To2Array.Length, outImg.CvPtr,
                matchColor0, singlePointColor0, matchesMaskArray, matchesMaskLength, (int)flags);
        }

        /// <summary>
        /// Draws matches of keypints from two images on output image.
        /// </summary>
        /// <param name="img1"></param>
        /// <param name="keypoints1"></param>
        /// <param name="img2"></param>
        /// <param name="keypoints2"></param>
        /// <param name="matches1To2"></param>
        /// <param name="outImg"></param>
        /// <param name="matchColor"></param>
        /// <param name="singlePointColor"></param>
        /// <param name="matchesMask"></param>
        /// <param name="flags"></param>
        public static void DrawMatches(Mat img1, IEnumerable<KeyPoint> keypoints1,
            Mat img2, IEnumerable<KeyPoint> keypoints2,
            IEnumerable<IEnumerable<DMatch>> matches1To2, Mat outImg,
            Scalar? matchColor = null, Scalar? singlePointColor = null,
            IEnumerable<IEnumerable<byte>> matchesMask = null,
            DrawMatchesFlags flags = DrawMatchesFlags.Default)
        {
            if (img1 == null)
                throw new ArgumentNullException("img1");
            if (img2 == null)
                throw new ArgumentNullException("img2");
            if (outImg == null)
                throw new ArgumentNullException("outImg");
            if (keypoints1 == null)
                throw new ArgumentNullException("keypoints1");
            if (keypoints2 == null)
                throw new ArgumentNullException("keypoints2");
            if (matches1To2 == null)
                throw new ArgumentNullException("matches1To2");
            img1.ThrowIfDisposed();
            img2.ThrowIfDisposed();
            outImg.ThrowIfDisposed();

            KeyPoint[] keypoints1Array = EnumerableEx.ToArray(keypoints1);
            KeyPoint[] keypoints2Array = EnumerableEx.ToArray(keypoints2);
            DMatch[][] matches1To2Array = EnumerableEx.SelectToArray(matches1To2, EnumerableEx.ToArray);
            int matches1To2Size1 = matches1To2Array.Length;
            int[] matches1To2Size2 = EnumerableEx.SelectToArray(matches1To2Array, dm => dm.Length);
            Scalar matchColor0 = matchColor.GetValueOrDefault(Scalar.All(-1));
            Scalar singlePointColor0 = singlePointColor.GetValueOrDefault(Scalar.All(-1));

            using (var matches1To2Ptr = new ArrayAddress2<DMatch>(matches1To2Array))
            {
                if (matchesMask == null)
                {
                    NativeMethods.features2d_drawMatches2(img1.CvPtr, keypoints1Array, keypoints1Array.Length,
                        img2.CvPtr, keypoints2Array, keypoints2Array.Length,
                        matches1To2Ptr, matches1To2Size1, matches1To2Size2,
                        outImg.CvPtr, matchColor0, singlePointColor0, 
                        null, 0, null, (int)flags);
                }
                else
                {
                    byte[][] matchesMaskArray = EnumerableEx.SelectToArray(matchesMask, EnumerableEx.ToArray);
                    int matchesMaskSize1 = matches1To2Array.Length;
                    int[] matchesMaskSize2 = EnumerableEx.SelectToArray(matchesMaskArray, dm => dm.Length);
                    using (var matchesMaskPtr = new ArrayAddress2<byte>(matchesMaskArray))
                    {
                        NativeMethods.features2d_drawMatches2(img1.CvPtr, keypoints1Array, keypoints1Array.Length,
                            img2.CvPtr, keypoints2Array, keypoints2Array.Length,
                            matches1To2Ptr.Pointer, matches1To2Size1, matches1To2Size2,
                            outImg.CvPtr, matchColor0, singlePointColor0,
                            matchesMaskPtr, matchesMaskSize1, matchesMaskSize2, (int)flags);
                    }
                }
            }

        }
    }
}
