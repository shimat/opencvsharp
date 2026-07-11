using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Util;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// A class filters a vector of keypoints.
/// </summary>
public static class KeyPointsFilter
{
    /// <summary>
    /// Remove keypoints within borderPixels of an image edge.
    /// </summary>
    /// <param name="keypoints"></param>
    /// <param name="imageSize"></param>
    /// <param name="borderSize"></param>
    /// <returns></returns>
    public static KeyPoint[] RunByImageBorder(IEnumerable<KeyPoint> keypoints, Size imageSize, int borderSize)
    {
        ArgumentNullException.ThrowIfNull(keypoints);

        using var keypointsVec = new StdVector<KeyPoint>(keypoints);
        NativeMethods.HandleException(
            NativeMethods.features_KeyPointsFilter_runByImageBorder(
                keypointsVec.CvPtr, imageSize, borderSize));
        return keypointsVec.ToArray();
    }

    /// <summary>
    /// Remove keypoints of sizes out of range.
    /// </summary>
    /// <param name="keypoints"></param>
    /// <param name="minSize"></param>
    /// <param name="maxSize"></param>
    /// <returns></returns>
    public static KeyPoint[] RunByKeypointSize(IEnumerable<KeyPoint> keypoints, float minSize,
        float maxSize = float.MaxValue)
    {
        ArgumentNullException.ThrowIfNull(keypoints);

        using var keypointsVec = new StdVector<KeyPoint>(keypoints);
        NativeMethods.HandleException(
            NativeMethods.features_KeyPointsFilter_runByKeypointSize(
                keypointsVec.CvPtr, minSize, maxSize));
        return keypointsVec.ToArray();
    }

    /// <summary>
    /// Remove keypoints from some image by mask for pixels of this image.
    /// </summary>
    /// <param name="keypoints"></param>
    /// <param name="mask"></param>
    /// <returns></returns>
    public static KeyPoint[] RunByPixelsMask(IEnumerable<KeyPoint> keypoints, InputArray mask)
    {
        ArgumentNullException.ThrowIfNull(keypoints);

        using var keypointsVec = new StdVector<KeyPoint>(keypoints);
        NativeMethods.HandleException(
            NativeMethods.features_KeyPointsFilter_runByPixelsMask(keypointsVec.CvPtr, mask.Proxy));
        GC.KeepAlive(mask.Source);
        return keypointsVec.ToArray();
    }

    /// <summary>
    /// Remove objects from some image and a vector of points by mask for pixels of this image.
    /// </summary>
    /// <param name="keypoints"></param>
    /// <param name="removeFrom"></param>
    /// <param name="mask"></param>
    /// <returns></returns>
    public static (KeyPoint[] Keypoints, Point[][] RemoveFrom) RunByPixelsMask2VectorPoint(
        IEnumerable<KeyPoint> keypoints, IEnumerable<IEnumerable<Point>> removeFrom, InputArray mask)
    {
        ArgumentNullException.ThrowIfNull(keypoints);
        ArgumentNullException.ThrowIfNull(removeFrom);

        using var keypointsVec = new StdVector<KeyPoint>(keypoints);
        using var removeFromPtr = new ArrayAddress2<Point>(removeFrom);
        using var removeFromResultVec = new VectorOfVectorPoint();
        NativeMethods.HandleException(
            NativeMethods.features_KeyPointsFilter_runByPixelsMask2VectorPoint(
                keypointsVec.CvPtr, removeFromPtr.GetPointer(), removeFromPtr.GetDim1Length(), removeFromPtr.GetDim2Lengths(),
                mask.Proxy, removeFromResultVec.CvPtr));
        GC.KeepAlive(mask.Source);
        return (keypointsVec.ToArray(), removeFromResultVec.ToArray());
    }

    /// <summary>
    /// Remove duplicated keypoints.
    /// </summary>
    /// <param name="keypoints"></param>
    /// <returns></returns>
    public static KeyPoint[] RemoveDuplicated(IEnumerable<KeyPoint> keypoints)
    {
        ArgumentNullException.ThrowIfNull(keypoints);

        using var keypointsVec = new StdVector<KeyPoint>(keypoints);
        NativeMethods.HandleException(
            NativeMethods.features_KeyPointsFilter_removeDuplicated(keypointsVec.CvPtr));
        return keypointsVec.ToArray();
    }

    /// <summary>
    /// Remove duplicated keypoints and sort the remaining keypoints
    /// </summary>
    /// <param name="keypoints"></param>
    /// <returns></returns>
    public static KeyPoint[] RemoveDuplicatedSorted(IEnumerable<KeyPoint> keypoints)
    {
        ArgumentNullException.ThrowIfNull(keypoints);

        using var keypointsVec = new StdVector<KeyPoint>(keypoints);
        NativeMethods.HandleException(
            NativeMethods.features_KeyPointsFilter_removeDuplicatedSorted(keypointsVec.CvPtr));
        return keypointsVec.ToArray();
    }


    /// <summary>
    /// Retain the specified number of the best keypoints (according to the response)
    /// </summary>
    /// <param name="keypoints"></param>
    /// <param name="nPoints"></param>
    /// <returns></returns>
    public static KeyPoint[] RetainBest(IEnumerable<KeyPoint> keypoints, int nPoints)
    {
        ArgumentNullException.ThrowIfNull(keypoints);

        using var keypointsVec = new StdVector<KeyPoint>(keypoints);
        NativeMethods.HandleException(
            NativeMethods.features_KeyPointsFilter_retainBest(
                keypointsVec.CvPtr, nPoints));
        return keypointsVec.ToArray();
    }
}
