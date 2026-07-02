using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace OpenCvSharp;

static partial class Cv2
{
    /// <summary>
    /// Registers depth data to an external camera.
    /// </summary>
    /// <param name="unregisteredCameraMatrix">the camera matrix of the depth camera.</param>
    /// <param name="registeredCameraMatrix">the camera matrix of the external camera.</param>
    /// <param name="registeredDistCoeffs">the distortion coefficients of the external camera.</param>
    /// <param name="Rt">the rigid body transform between the cameras.</param>
    /// <param name="unregisteredDepth">the input depth data.</param>
    /// <param name="outputImagePlaneSize">the image plane dimensions of the external camera (width, height).</param>
    /// <param name="registeredDepth">the result of transforming the depth into the external camera.</param>
    /// <param name="depthDilation">whether or not the depth is dilated to avoid holes and occlusion errors (optional).</param>
    public static void RegisterDepth(
        InputArrayRef unregisteredCameraMatrix, InputArrayRef registeredCameraMatrix, InputArrayRef registeredDistCoeffs,
        InputArrayRef Rt, InputArrayRef unregisteredDepth, Size outputImagePlaneSize,
        OutputArrayRef registeredDepth, bool depthDilation = false)
    {
        NativeMethods.HandleException(
            NativeMethods.ptcloud_registerDepth(
                unregisteredCameraMatrix.Proxy, registeredCameraMatrix.Proxy, registeredDistCoeffs.Proxy,
                Rt.Proxy, unregisteredDepth.Proxy, outputImagePlaneSize,
                registeredDepth.Proxy, depthDilation ? 1 : 0));

        GC.KeepAlive(unregisteredCameraMatrix.Source);
        GC.KeepAlive(registeredCameraMatrix.Source);
        GC.KeepAlive(registeredDistCoeffs.Source);
        GC.KeepAlive(Rt.Source);
        GC.KeepAlive(unregisteredDepth.Source);
    }

    /// <summary>
    /// Converts the specified sparse depth coordinates to 3d points.
    /// </summary>
    /// <param name="depth">the depth image.</param>
    /// <param name="inK">the calibration matrix.</param>
    /// <param name="inPoints">the list of xy coordinates.</param>
    /// <param name="points3d">the resulting 3d points (point is represented by 4 channels value [x, y, z, 0]).</param>
    public static void DepthTo3dSparse(InputArrayRef depth, InputArrayRef inK, InputArrayRef inPoints, OutputArrayRef points3d)
    {
        NativeMethods.HandleException(
            NativeMethods.ptcloud_depthTo3dSparse(depth.Proxy, inK.Proxy, inPoints.Proxy, points3d.Proxy));

        GC.KeepAlive(depth.Source);
        GC.KeepAlive(inK.Source);
        GC.KeepAlive(inPoints.Source);
    }

    /// <summary>
    /// Converts a depth image to 3d points.
    /// </summary>
    /// <param name="depth">the depth image.</param>
    /// <param name="K">the calibration matrix.</param>
    /// <param name="points3d">the resulting 3d points (point is represented by 4 channels value [x, y, z, 0]).</param>
    /// <param name="mask">the mask of the points to consider (can be empty).</param>
    public static void DepthTo3d(InputArrayRef depth, InputArrayRef K, OutputArrayRef points3d, InputArrayRef mask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.ptcloud_depthTo3d(depth.Proxy, K.Proxy, points3d.Proxy, mask.Proxy));

        GC.KeepAlive(depth.Source);
        GC.KeepAlive(K.Source);
        GC.KeepAlive(mask.Source);
    }

    /// <summary>
    /// Rescales a depth image. If the input image is of type CV_16UC1, it is converted to floats,
    /// divided by depthFactor to get a depth in meters; otherwise it is simply converted to floats.
    /// </summary>
    /// <param name="src">the depth image.</param>
    /// <param name="type">the desired output depth (CV_32F or CV_64F).</param>
    /// <param name="dst">the rescaled float depth image.</param>
    /// <param name="depthFactor">factor by which depth is converted to distance (by default = 1000.0 for Kinect sensor).</param>
    public static void RescaleDepth(InputArrayRef src, int type, OutputArrayRef dst, double depthFactor = 1000.0)
    {
        NativeMethods.HandleException(
            NativeMethods.ptcloud_rescaleDepth(src.Proxy, type, dst.Proxy, depthFactor));

        GC.KeepAlive(src.Source);
    }

    /// <summary>
    /// Warps depth or RGB-D image by reprojecting it in 3d, applying an Rt transformation
    /// and then projecting it back onto the image plane.
    /// </summary>
    /// <param name="depth">Depth data, should be 1-channel CV_16U, CV_16S, CV_32F or CV_64F.</param>
    /// <param name="image">RGB image (optional), should be 1-, 3- or 4-channel CV_8U.</param>
    /// <param name="mask">Mask of used pixels (optional), should be CV_8UC1, CV_8SC1 or CV_BoolC1.</param>
    /// <param name="Rt">Rotation+translation matrix (3x4 or 4x4) to be applied to depth points.</param>
    /// <param name="cameraMatrix">Camera intrinsics matrix (3x3).</param>
    /// <param name="warpedDepth">The warped depth data (optional).</param>
    /// <param name="warpedImage">The warped RGB image (optional).</param>
    /// <param name="warpedMask">The mask of valid pixels in warped image (optional).</param>
    public static void WarpFrame(
        InputArrayRef depth, InputArrayRef image, InputArrayRef mask, InputArrayRef Rt, InputArrayRef cameraMatrix,
        OutputArrayRef warpedDepth = default, OutputArrayRef warpedImage = default, OutputArrayRef warpedMask = default)
    {
        NativeMethods.HandleException(
            NativeMethods.ptcloud_warpFrame(
                depth.Proxy, image.Proxy, mask.Proxy, Rt.Proxy, cameraMatrix.Proxy,
                warpedDepth.Proxy, warpedImage.Proxy, warpedMask.Proxy));

        GC.KeepAlive(depth.Source);
        GC.KeepAlive(image.Source);
        GC.KeepAlive(mask.Source);
        GC.KeepAlive(Rt.Source);
        GC.KeepAlive(cameraMatrix.Source);
    }

    /// <summary>
    /// Finds the planes in a depth image.
    /// </summary>
    /// <param name="points3d">the 3d points organized like the depth image: rows x cols with 3 channels.</param>
    /// <param name="normals">the normals for every point in the depth image; optional, can be empty.</param>
    /// <param name="mask">an image where each pixel is labeled with the plane it belongs to (255 if none).</param>
    /// <param name="planeCoefficients">the coefficients of the corresponding planes (a,b,c,d) such that ax+by+cz+d=0.</param>
    /// <param name="blockSize">the size of the blocks to look at for a stable MSE.</param>
    /// <param name="minSize">the minimum size of a cluster to be considered a plane.</param>
    /// <param name="threshold">the maximum distance of a point from a plane to belong to it (in meters).</param>
    /// <param name="sensorErrorA">coefficient of the sensor error (0 by default, use 0.0075 for a Kinect).</param>
    /// <param name="sensorErrorB">coefficient of the sensor error (0 by default).</param>
    /// <param name="sensorErrorC">coefficient of the sensor error (0 by default).</param>
    /// <param name="method">the method to use to compute the planes.</param>
    public static void FindPlanes(
        InputArrayRef points3d, InputArrayRef normals, OutputArrayRef mask, OutputArrayRef planeCoefficients,
        int blockSize = 40, int minSize = 1600, double threshold = 0.01,
        double sensorErrorA = 0, double sensorErrorB = 0, double sensorErrorC = 0,
        RgbdPlaneMethod method = RgbdPlaneMethod.Default)
    {
        NativeMethods.HandleException(
            NativeMethods.ptcloud_findPlanes(
                points3d.Proxy, normals.Proxy, mask.Proxy, planeCoefficients.Proxy,
                blockSize, minSize, threshold,
                sensorErrorA, sensorErrorB, sensorErrorC, (int)method));

        GC.KeepAlive(points3d.Source);
        GC.KeepAlive(normals.Source);
    }

    /// <summary>
    /// Loads a point cloud from a file (.ply / .obj). The file format is chosen by the extension.
    /// </summary>
    /// <param name="filename">Name of the file.</param>
    /// <param name="vertices">Output vertex coordinates, each value contains 3 floats.</param>
    /// <param name="normals">Output per-vertex normals, each value contains 3 floats (optional).</param>
    /// <param name="rgb">Output per-vertex colors, each value contains 3 floats (optional).</param>
    public static void LoadPointCloud(string filename, OutputArrayRef vertices, OutputArrayRef normals = default, OutputArrayRef rgb = default)
    {
        if (filename is null)
            throw new ArgumentNullException(nameof(filename));

        NativeMethods.HandleException(
            NativeMethods.ptcloud_loadPointCloud(filename, vertices.Proxy, normals.Proxy, rgb.Proxy));

    }

    /// <summary>
    /// Saves a point cloud to a file (.ply / .obj). The file format is chosen by the extension.
    /// </summary>
    /// <param name="filename">Name of the file.</param>
    /// <param name="vertices">Vertex coordinates, each value contains 3 floats.</param>
    /// <param name="normals">Per-vertex normals, each value contains 3 floats (optional).</param>
    /// <param name="rgb">Per-vertex colors, each value contains 3 floats (optional).</param>
    public static void SavePointCloud(string filename, InputArrayRef vertices, InputArrayRef normals = default, InputArrayRef rgb = default)
    {
        if (filename is null)
            throw new ArgumentNullException(nameof(filename));

        NativeMethods.HandleException(
            NativeMethods.ptcloud_savePointCloud(filename, vertices.Proxy, normals.Proxy, rgb.Proxy));

        GC.KeepAlive(vertices.Source);
        GC.KeepAlive(normals.Source);
        GC.KeepAlive(rgb.Source);
    }

    /// <summary>
    /// Loads a mesh from a file (.ply / .obj). The file format is chosen by the extension.
    /// </summary>
    /// <param name="filename">Name of the file.</param>
    /// <param name="vertices">Output vertex coordinates, each value contains 3 floats.</param>
    /// <param name="indices">Output per-face list of vertex indices; each element is a vector of ints.</param>
    /// <param name="normals">Output per-vertex normals, each value contains 3 floats (optional).</param>
    /// <param name="colors">Output per-vertex colors, each value contains 3 floats (optional).</param>
    /// <param name="texCoords">Output per-vertex texture coordinates, each value contains 2 or 3 floats (optional).</param>
    public static void LoadMesh(
        string filename, OutputArrayRef vertices, out Mat[] indices,
        OutputArrayRef normals = default, OutputArrayRef colors = default, OutputArrayRef texCoords = default)
    {
        if (filename is null)
            throw new ArgumentNullException(nameof(filename));

        using var indicesVec = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_loadMesh(
                filename, vertices.Proxy, indicesVec.CvPtr, normals.Proxy, colors.Proxy, texCoords.Proxy));

        indices = indicesVec.ToArray();
    }

    /// <summary>
    /// Saves a mesh to a file (.ply / .obj). The file format is chosen by the extension.
    /// </summary>
    /// <param name="filename">Name of the file.</param>
    /// <param name="vertices">Vertex coordinates, each value contains 3 floats.</param>
    /// <param name="indices">Per-face list of vertex indices; each element is a vector of ints.</param>
    /// <param name="normals">Per-vertex normals, each value contains 3 floats (optional).</param>
    /// <param name="colors">Per-vertex colors, each value contains 3 floats (optional).</param>
    /// <param name="texCoords">Per-vertex texture coordinates, each value contains 2 or 3 floats (optional).</param>
    public static void SaveMesh(
        string filename, InputArrayRef vertices, IEnumerable<Mat> indices,
        InputArrayRef normals = default, InputArrayRef colors = default, InputArrayRef texCoords = default)
    {
        if (filename is null)
            throw new ArgumentNullException(nameof(filename));
        if (indices is null)
            throw new ArgumentNullException(nameof(indices));

        var indicesArray = indices as Mat[] ?? indices.ToArray();
        using var indicesVec = new VectorOfMat(indicesArray);
        NativeMethods.HandleException(
            NativeMethods.ptcloud_saveMesh(
                filename, vertices.Proxy, indicesVec.CvPtr, normals.Proxy, colors.Proxy, texCoords.Proxy));

        GC.KeepAlive(vertices.Source);
        GC.KeepAlive(normals.Source);
        GC.KeepAlive(colors.Source);
        GC.KeepAlive(texCoords.Source);
        GC.KeepAlive(indicesArray);
    }
}
