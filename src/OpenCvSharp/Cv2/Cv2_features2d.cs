using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
    static partial class Cv2
    {
        /// <summary>
        /// Detects corners using the FAST algorithm
        /// </summary>
        /// <param name="image">grayscale image where keypoints (corners) are detected.</param>
        /// <param name="threshold">threshold on difference between intensity of the central pixel 
        /// and pixels of a circle around this pixel.</param>
        /// <param name="nonmaxSupression">if true, non-maximum suppression is applied to 
        /// detected corners (keypoints).</param>
        /// <returns>keypoints detected on the image.</returns>
        public static KeyPoint[] FAST(InputArray image, int threshold, bool nonmaxSupression = true)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            using (var kp = new VectorOfKeyPoint())
            {
                NativeMethods.features2d_FAST1(image.CvPtr, kp.CvPtr, threshold, nonmaxSupression ? 1 : 0);
                GC.KeepAlive(image);
                return kp.ToArray();
            }
        }

        /// <summary>
        /// Detects corners using the FAST algorithm
        /// </summary>
        /// <param name="image">grayscale image where keypoints (corners) are detected.</param>
        /// <param name="threshold">threshold on difference between intensity of the central pixel 
        /// and pixels of a circle around this pixel.</param>
        /// <param name="nonmaxSupression">if true, non-maximum suppression is applied to 
        /// detected corners (keypoints).</param>
        /// <param name="type">one of the three neighborhoods as defined in the paper</param>
        /// <returns>keypoints detected on the image.</returns>
        public static KeyPoint[] FAST(InputArray image, int threshold, bool nonmaxSupression, FASTType type)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();

            using (var kp = new VectorOfKeyPoint())
            {
                NativeMethods.features2d_FAST2(image.CvPtr, kp.CvPtr, threshold, nonmaxSupression ? 1 : 0, (int)type);
                GC.KeepAlive(image);
                return kp.ToArray();
            }
        }

        /// <summary>
        /// Detects corners using the AGAST algorithm
        /// </summary>
        /// <param name="image">grayscale image where keypoints (corners) are detected.</param>
        /// <param name="threshold">threshold on difference between intensity of the central pixel 
        /// and pixels of a circle around this pixel.</param>
        /// <param name="nonmaxSuppression">if true, non-maximum suppression is applied to 
        /// detected corners (keypoints).</param>
        /// <param name="type">one of the four neighborhoods as defined in the paper</param>
        /// <returns>keypoints detected on the image.</returns>
        public static KeyPoint[] AGAST(InputArray image, int threshold, bool nonmaxSuppression, AGASTType type)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            image.ThrowIfDisposed();
            
            using (var vector = new VectorOfKeyPoint())
            {
                NativeMethods.features2d_AGAST(image.CvPtr, vector.CvPtr, threshold, nonmaxSuppression ? 1 : 0,
                    (int) type);
                GC.KeepAlive(image);
                return vector.ToArray();
            }
        }

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
                throw new ArgumentNullException(nameof(image));
            if (outImage == null)
                throw new ArgumentNullException(nameof(outImage));
            if (keypoints == null)
                throw new ArgumentNullException(nameof(keypoints));
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
                throw new ArgumentNullException(nameof(img1));
            if (img2 == null)
                throw new ArgumentNullException(nameof(img2));
            if (outImg == null)
                throw new ArgumentNullException(nameof(outImg));
            if (keypoints1 == null)
                throw new ArgumentNullException(nameof(keypoints1));
            if (keypoints2 == null)
                throw new ArgumentNullException(nameof(keypoints2));
            if (matches1To2 == null)
                throw new ArgumentNullException(nameof(matches1To2));
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
                throw new ArgumentNullException(nameof(img1));
            if (img2 == null)
                throw new ArgumentNullException(nameof(img2));
            if (outImg == null)
                throw new ArgumentNullException(nameof(outImg));
            if (keypoints1 == null)
                throw new ArgumentNullException(nameof(keypoints1));
            if (keypoints2 == null)
                throw new ArgumentNullException(nameof(keypoints2));
            if (matches1To2 == null)
                throw new ArgumentNullException(nameof(matches1To2));
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="img1"></param>
        /// <param name="img2"></param>
        /// <param name="H1to2"></param>
        /// <param name="keypoints1"></param>
        /// <param name="keypoints2"></param>
        /// <param name="repeatability"></param>
        /// <param name="correspCount"></param>
        public static void EvaluateFeatureDetector(
            Mat img1, Mat img2, Mat H1to2,
            ref KeyPoint[] keypoints1, ref KeyPoint[] keypoints2,
            out float repeatability, out int correspCount)
        {
            if (img1 == null) 
                throw new ArgumentNullException(nameof(img1));
            if (img2 == null) 
                throw new ArgumentNullException(nameof(img2));
            if (H1to2 == null) 
                throw new ArgumentNullException(nameof(H1to2));
            if (keypoints1 == null) 
                throw new ArgumentNullException(nameof(keypoints1));
            if (keypoints2 == null) 
                throw new ArgumentNullException(nameof(keypoints2));

            using (var keypoints1Vec = new VectorOfKeyPoint(keypoints1))
            using (var keypoints2Vec = new VectorOfKeyPoint(keypoints2))
            {
                NativeMethods.features2d_evaluateFeatureDetector(
                    img1.CvPtr, img2.CvPtr, H1to2.CvPtr,
                    keypoints1Vec.CvPtr, keypoints2Vec.CvPtr, 
                    out repeatability, out correspCount);
                keypoints1 = keypoints1Vec.ToArray();
                keypoints2 = keypoints2Vec.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matches1to2"></param>
        /// <param name="correctMatches1to2Mask"></param>
        /// <returns>recallPrecisionCurve</returns>
        public static Point2f[] ComputeRecallPrecisionCurve(
            DMatch[][] matches1to2, byte[][] correctMatches1to2Mask)
        {
            if (matches1to2 == null)
                throw new ArgumentNullException(nameof(matches1to2));
            if (correctMatches1to2Mask == null)
                throw new ArgumentNullException(nameof(correctMatches1to2Mask));

            using (var dm = new ArrayAddress2<DMatch>(matches1to2))
            using (var cm = new ArrayAddress2<byte>(correctMatches1to2Mask))
            using (var recall = new VectorOfPoint2f())
            {
                NativeMethods.features2d_computeRecallPrecisionCurve(
                    dm.Pointer, dm.Dim1Length, dm.Dim2Lengths,
                    cm.Pointer, cm.Dim1Length, cm.Dim2Lengths,
                    recall.CvPtr);
                return recall.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recallPrecisionCurve"></param>
        /// <param name="lPrecision"></param>
        /// <returns></returns>
        public static float GetRecall(
            IEnumerable<Point2f> recallPrecisionCurve, float lPrecision)
        {
            if (recallPrecisionCurve == null)
                throw new ArgumentNullException(nameof(recallPrecisionCurve));

            var array = EnumerableEx.ToArray(recallPrecisionCurve);
            return NativeMethods.features2d_getRecall(array, array.Length, lPrecision);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recallPrecisionCurve"></param>
        /// <param name="lPrecision"></param>
        /// <returns></returns>
        public static int GetNearestPoint(
            IEnumerable<Point2f> recallPrecisionCurve, float lPrecision)
        {
            if (recallPrecisionCurve == null)
                throw new ArgumentNullException(nameof(recallPrecisionCurve));
            var array = EnumerableEx.ToArray(recallPrecisionCurve);
            return NativeMethods.features2d_getNearestPoint(array, array.Length, lPrecision);
        }
    }
}
