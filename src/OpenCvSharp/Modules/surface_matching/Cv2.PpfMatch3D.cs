using OpenCvSharp.Internal;

namespace OpenCvSharp;

public static partial class Cv2
{
    /// <summary>
    /// Surface-matching helpers in the native cv::ppf_match_3d namespace.
    /// </summary>
    public static class PpfMatch3D
    {
        /// <summary>
        /// Computes surface normals for a point cloud using local plane fitting.
        /// </summary>
        /// <param name="pointCloud">Input point cloud as an N-by-3 CV_32F matrix.</param>
        /// <param name="pointCloudWithNormals">Output N-by-6 CV_32F matrix containing XYZ coordinates and normals.</param>
        /// <param name="numberOfNeighbors">Number of neighboring points used for each local plane fit.</param>
        /// <param name="flipViewpoint">Whether normals should be oriented toward <paramref name="viewpoint"/>.</param>
        /// <param name="viewpoint">Viewpoint used when <paramref name="flipViewpoint"/> is true.</param>
        /// <returns>One on success, matching the OpenCV implementation.</returns>
        public static int ComputeNormalsPC3d(
            InputArray pointCloud,
            OutputArray pointCloudWithNormals,
            int numberOfNeighbors = 6,
            bool flipViewpoint = false,
            Vec3f viewpoint = default)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numberOfNeighbors);

            NativeMethods.HandleException(
                NativeMethods.surface_matching_computeNormalsPC3d(
                    pointCloud.Proxy,
                    pointCloudWithNormals.Proxy,
                    numberOfNeighbors,
                    flipViewpoint ? 1 : 0,
                    viewpoint,
                    out var returnValue));

            GC.KeepAlive(pointCloud.Source);
            GC.KeepAlive(pointCloudWithNormals.Source);
            return returnValue;
        }
    }
}
