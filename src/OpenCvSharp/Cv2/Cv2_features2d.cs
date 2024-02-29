using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

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
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        image.ThrowIfDisposed();

        using var kp = new VectorOfKeyPoint();
        NativeMethods.HandleException(
            NativeMethods.features2d_FAST1(image.CvPtr, kp.CvPtr, threshold, nonmaxSupression ? 1 : 0));
        GC.KeepAlive(image);
        return kp.ToArray();
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
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        image.ThrowIfDisposed();

        using var kp = new VectorOfKeyPoint();
        NativeMethods.HandleException(
            NativeMethods.features2d_FAST2(image.CvPtr, kp.CvPtr, threshold, nonmaxSupression ? 1 : 0, (int)type));
        GC.KeepAlive(image);
        return kp.ToArray();
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
    public static KeyPoint[] AGAST(InputArray image, int threshold, bool nonmaxSuppression, AgastFeatureDetector.DetectorType type)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        image.ThrowIfDisposed();

        using var vector = new VectorOfKeyPoint();
        NativeMethods.HandleException(
            NativeMethods.features2d_AGAST(image.CvPtr, vector.CvPtr, threshold, nonmaxSuppression ? 1 : 0, (int) type));
        GC.KeepAlive(image);
        return vector.ToArray();
    }

    /// <summary>
    /// Draw keypoints.
    /// </summary>
    /// <param name="image">Source image.</param>
    /// <param name="keypoints">Keypoints from the source image.</param>
    /// <param name="outImage">Output image. Its content depends on the flags value defining what is drawn in the output image. See possible flags bit values below.</param>
    /// <param name="color">Color of keypoints.</param>
    /// <param name="flags">Flags setting drawing features. Possible flags bit values are defined by DrawMatchesFlags.</param>
    public static void DrawKeypoints(
        InputArray image,
        IEnumerable<KeyPoint> keypoints, 
        InputOutputArray outImage,
        Scalar? color = null,
        DrawMatchesFlags flags = DrawMatchesFlags.Default)
    {
        if (image is null)
            throw new ArgumentNullException(nameof(image));
        if (outImage is null)
            throw new ArgumentNullException(nameof(outImage));
        if (keypoints is null)
            throw new ArgumentNullException(nameof(keypoints));
        image.ThrowIfDisposed();
        outImage.ThrowIfDisposed();

        var keypointsArray = keypoints.CastOrToArray();
        var color0 = color.GetValueOrDefault(Scalar.All(-1));
        NativeMethods.HandleException(
            NativeMethods.features2d_drawKeypoints(image.CvPtr, keypointsArray, keypointsArray.Length, outImage.CvPtr, color0, (int)flags));

        GC.KeepAlive(image);
        GC.KeepAlive(outImage);
    }

    /// <summary>
    /// Draws the found matches of keypoints from two images.
    /// </summary>
    /// <param name="img1">First source image.</param>
    /// <param name="keypoints1">Keypoints from the first source image.</param>
    /// <param name="img2">Second source image.</param>
    /// <param name="keypoints2">Keypoints from the second source image.</param>
    /// <param name="matches1To2">Matches from the first image to the second one, which means that keypoints1[i]
    /// has a corresponding point in keypoints2[matches[i]] .</param>
    /// <param name="outImg">Output image. Its content depends on the flags value defining what is drawn in the
    /// output image. See possible flags bit values below.</param>
    /// <param name="matchColor">Color of matches (lines and connected keypoints). If matchColor==Scalar::all(-1),
    /// the color is generated randomly.</param>
    /// <param name="singlePointColor">Color of single keypoints (circles), which means that keypoints do not
    /// have the matches. If singlePointColor==Scalar::all(-1) , the color is generated randomly.</param>
    /// <param name="matchesMask">Mask determining which matches are drawn. If the mask is empty, all matches are drawn.</param>
    /// <param name="flags">Flags setting drawing features. Possible flags bit values are defined by DrawMatchesFlags.</param>
    public static void DrawMatches(
        Mat img1, 
        IEnumerable<KeyPoint> keypoints1,
        Mat img2,
        IEnumerable<KeyPoint> keypoints2,
        IEnumerable<DMatch> matches1To2,
        Mat outImg,
        Scalar? matchColor = null,
        Scalar? singlePointColor = null,
        IEnumerable<byte>? matchesMask = null,
        DrawMatchesFlags flags = DrawMatchesFlags.Default)
    {
        if (img1 is null)
            throw new ArgumentNullException(nameof(img1));
        if (img2 is null)
            throw new ArgumentNullException(nameof(img2));
        if (outImg is null)
            throw new ArgumentNullException(nameof(outImg));
        if (keypoints1 is null)
            throw new ArgumentNullException(nameof(keypoints1));
        if (keypoints2 is null)
            throw new ArgumentNullException(nameof(keypoints2));
        if (matches1To2 is null)
            throw new ArgumentNullException(nameof(matches1To2));
        img1.ThrowIfDisposed();
        img2.ThrowIfDisposed();
        outImg.ThrowIfDisposed();

        var keypoints1Array = keypoints1.CastOrToArray();
        var keypoints2Array = keypoints2.CastOrToArray();
        var matches1To2Array = matches1To2.CastOrToArray();
        var matchColor0 = matchColor.GetValueOrDefault(Scalar.All(-1));
        var singlePointColor0 = singlePointColor.GetValueOrDefault(Scalar.All(-1));

        var matchesMaskArray = matchesMask?.CastOrToArray(); 
        var matchesMaskLength = matchesMaskArray?.Length ?? 0;

        NativeMethods.HandleException(
            NativeMethods.features2d_drawMatches(
                img1.CvPtr, keypoints1Array, keypoints1Array.Length,
                img2.CvPtr, keypoints2Array, keypoints2Array.Length,
                matches1To2Array, matches1To2Array.Length, outImg.CvPtr,
                matchColor0, singlePointColor0, matchesMaskArray, matchesMaskLength, (int) flags));

        GC.KeepAlive(img1);
        GC.KeepAlive(img2);
        GC.KeepAlive(outImg);
    }

    /// <summary>
    /// Draws the found matches of keypoints from two images.
    /// </summary>
    /// <param name="img1">First source image.</param>
    /// <param name="keypoints1">Keypoints from the first source image.</param>
    /// <param name="img2">Second source image.</param>
    /// <param name="keypoints2">Keypoints from the second source image.</param>
    /// <param name="matches1To2">Matches from the first image to the second one, which means that keypoints1[i]
    /// has a corresponding point in keypoints2[matches[i]] .</param>
    /// <param name="outImg">Output image. Its content depends on the flags value defining what is drawn in the
    /// output image. See possible flags bit values below.</param>
    /// <param name="matchColor">Color of matches (lines and connected keypoints). If matchColor==Scalar::all(-1),
    /// the color is generated randomly.</param>
    /// <param name="singlePointColor">Color of single keypoints (circles), which means that keypoints do not
    /// have the matches. If singlePointColor==Scalar::all(-1) , the color is generated randomly.</param>
    /// <param name="matchesMask">Mask determining which matches are drawn. If the mask is empty, all matches are drawn.</param>
    /// <param name="flags">Flags setting drawing features. Possible flags bit values are defined by DrawMatchesFlags.</param>
    public static void DrawMatchesKnn(
        Mat img1, 
        IEnumerable<KeyPoint> keypoints1,
        Mat img2, 
        IEnumerable<KeyPoint> keypoints2,
        IEnumerable<IEnumerable<DMatch>> matches1To2,
        Mat outImg,
        Scalar? matchColor = null,
        Scalar? singlePointColor = null,
        IEnumerable<IEnumerable<byte>>? matchesMask = null,
        DrawMatchesFlags flags = DrawMatchesFlags.Default)
    {
        if (img1 is null)
            throw new ArgumentNullException(nameof(img1));
        if (img2 is null)
            throw new ArgumentNullException(nameof(img2));
        if (outImg is null)
            throw new ArgumentNullException(nameof(outImg));
        if (keypoints1 is null)
            throw new ArgumentNullException(nameof(keypoints1));
        if (keypoints2 is null)
            throw new ArgumentNullException(nameof(keypoints2));
        if (matches1To2 is null)
            throw new ArgumentNullException(nameof(matches1To2));
        img1.ThrowIfDisposed();
        img2.ThrowIfDisposed();
        outImg.ThrowIfDisposed();

        var keypoints1Array = keypoints1.CastOrToArray();
        var keypoints2Array = keypoints2.CastOrToArray();
        var matches1To2Array = matches1To2.Select(m => m.ToArray()).ToArray();
        var matches1To2Size1 = matches1To2Array.Length;
        var matches1To2Size2 = matches1To2Array.Select(dm => dm.Length).ToArray();
        var matchColor0 = matchColor.GetValueOrDefault(Scalar.All(-1));
        var singlePointColor0 = singlePointColor.GetValueOrDefault(Scalar.All(-1));

        using var matches1To2Ptr = new ArrayAddress2<DMatch>(matches1To2Array);
        if (matchesMask is null)
        {
            NativeMethods.HandleException(
                NativeMethods.features2d_drawMatchesKnn(
                    img1.CvPtr, keypoints1Array, keypoints1Array.Length,
                    img2.CvPtr, keypoints2Array, keypoints2Array.Length,
                    matches1To2Ptr.GetPointer(), matches1To2Size1, matches1To2Size2,
                    outImg.CvPtr, matchColor0, singlePointColor0,
                    null, 0, null, (int) flags));
        }
        else
        {
            var matchesMaskArray = matchesMask.Select(m => m.ToArray()).ToArray();
            var matchesMaskSize1 = matches1To2Array.Length;
            var matchesMaskSize2 = matchesMaskArray.Select(dm => dm.Length).ToArray();
            using var matchesMaskPtr = new ArrayAddress2<byte>(matchesMaskArray);
            NativeMethods.HandleException(
                NativeMethods.features2d_drawMatchesKnn(
                    img1.CvPtr, keypoints1Array, keypoints1Array.Length,
                    img2.CvPtr, keypoints2Array, keypoints2Array.Length,
                    matches1To2Ptr.GetPointer(), matches1To2Size1, matches1To2Size2,
                    outImg.CvPtr, matchColor0, singlePointColor0,
                    matchesMaskPtr.GetPointer(), matchesMaskSize1, matchesMaskSize2, (int) flags));
        }
        GC.KeepAlive(img1);
        GC.KeepAlive(img2);
        GC.KeepAlive(outImg);
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
        if (img1 is null) 
            throw new ArgumentNullException(nameof(img1));
        if (img2 is null) 
            throw new ArgumentNullException(nameof(img2));
        if (H1to2 is null) 
            throw new ArgumentNullException(nameof(H1to2));
        if (keypoints1 is null) 
            throw new ArgumentNullException(nameof(keypoints1));
        if (keypoints2 is null) 
            throw new ArgumentNullException(nameof(keypoints2));

        using var keypoints1Vec = new VectorOfKeyPoint(keypoints1);
        using var keypoints2Vec = new VectorOfKeyPoint(keypoints2);
        NativeMethods.HandleException(
            NativeMethods.features2d_evaluateFeatureDetector(
                img1.CvPtr, img2.CvPtr, H1to2.CvPtr,
                keypoints1Vec.CvPtr, keypoints2Vec.CvPtr,
                out repeatability, out correspCount));
        GC.KeepAlive(img1);
        GC.KeepAlive(img2);
        GC.KeepAlive(H1to2);
        keypoints1 = keypoints1Vec.ToArray();
        keypoints2 = keypoints2Vec.ToArray();
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
        if (matches1to2 is null)
            throw new ArgumentNullException(nameof(matches1to2));
        if (correctMatches1to2Mask is null)
            throw new ArgumentNullException(nameof(correctMatches1to2Mask));

        using var dm = new ArrayAddress2<DMatch>(matches1to2);
        using var cm = new ArrayAddress2<byte>(correctMatches1to2Mask);
        using var recall = new VectorOfPoint2f();
        NativeMethods.HandleException(
            NativeMethods.features2d_computeRecallPrecisionCurve(
                dm.GetPointer(), dm.GetDim1Length(), dm.GetDim2Lengths(),
                cm.GetPointer(), cm.GetDim1Length(), cm.GetDim2Lengths(),
                recall.CvPtr));
        return recall.ToArray();
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
        if (recallPrecisionCurve is null)
            throw new ArgumentNullException(nameof(recallPrecisionCurve));

        var recallPrecisionCurveArray = recallPrecisionCurve.CastOrToArray();
        NativeMethods.HandleException( 
            NativeMethods.features2d_getRecall(
                recallPrecisionCurveArray, recallPrecisionCurveArray.Length, lPrecision, out var ret));
        return ret;
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
        if (recallPrecisionCurve is null)
            throw new ArgumentNullException(nameof(recallPrecisionCurve));

        var recallPrecisionCurveArray = recallPrecisionCurve.CastOrToArray();
        NativeMethods.HandleException(
            NativeMethods.features2d_getNearestPoint(
                recallPrecisionCurveArray, recallPrecisionCurveArray.Length, lPrecision, out var ret));
        return ret;
    }
}
