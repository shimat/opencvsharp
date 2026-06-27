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
        InputArray unregisteredCameraMatrix, InputArray registeredCameraMatrix, InputArray registeredDistCoeffs,
        InputArray Rt, InputArray unregisteredDepth, Size outputImagePlaneSize,
        OutputArray registeredDepth, bool depthDilation = false)
    {
        if (unregisteredCameraMatrix is null)
            throw new ArgumentNullException(nameof(unregisteredCameraMatrix));
        if (registeredCameraMatrix is null)
            throw new ArgumentNullException(nameof(registeredCameraMatrix));
        if (registeredDistCoeffs is null)
            throw new ArgumentNullException(nameof(registeredDistCoeffs));
        if (Rt is null)
            throw new ArgumentNullException(nameof(Rt));
        if (unregisteredDepth is null)
            throw new ArgumentNullException(nameof(unregisteredDepth));
        if (registeredDepth is null)
            throw new ArgumentNullException(nameof(registeredDepth));
        unregisteredCameraMatrix.ThrowIfDisposed();
        registeredCameraMatrix.ThrowIfDisposed();
        registeredDistCoeffs.ThrowIfDisposed();
        Rt.ThrowIfDisposed();
        unregisteredDepth.ThrowIfDisposed();
        registeredDepth.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.ptcloud_registerDepth(
                unregisteredCameraMatrix.CvPtr, registeredCameraMatrix.CvPtr, registeredDistCoeffs.CvPtr,
                Rt.CvPtr, unregisteredDepth.CvPtr, outputImagePlaneSize,
                registeredDepth.CvPtr, depthDilation ? 1 : 0));

        registeredDepth.Fix();
        GC.KeepAlive(unregisteredCameraMatrix);
        GC.KeepAlive(registeredCameraMatrix);
        GC.KeepAlive(registeredDistCoeffs);
        GC.KeepAlive(Rt);
        GC.KeepAlive(unregisteredDepth);
    }

    /// <summary>
    /// Converts the specified sparse depth coordinates to 3d points.
    /// </summary>
    /// <param name="depth">the depth image.</param>
    /// <param name="inK">the calibration matrix.</param>
    /// <param name="inPoints">the list of xy coordinates.</param>
    /// <param name="points3d">the resulting 3d points (point is represented by 4 channels value [x, y, z, 0]).</param>
    public static void DepthTo3dSparse(InputArray depth, InputArray inK, InputArray inPoints, OutputArray points3d)
    {
        if (depth is null)
            throw new ArgumentNullException(nameof(depth));
        if (inK is null)
            throw new ArgumentNullException(nameof(inK));
        if (inPoints is null)
            throw new ArgumentNullException(nameof(inPoints));
        if (points3d is null)
            throw new ArgumentNullException(nameof(points3d));
        depth.ThrowIfDisposed();
        inK.ThrowIfDisposed();
        inPoints.ThrowIfDisposed();
        points3d.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.ptcloud_depthTo3dSparse(depth.CvPtr, inK.CvPtr, inPoints.CvPtr, points3d.CvPtr));

        points3d.Fix();
        GC.KeepAlive(depth);
        GC.KeepAlive(inK);
        GC.KeepAlive(inPoints);
    }

    /// <summary>
    /// Converts a depth image to 3d points.
    /// </summary>
    /// <param name="depth">the depth image.</param>
    /// <param name="K">the calibration matrix.</param>
    /// <param name="points3d">the resulting 3d points (point is represented by 4 channels value [x, y, z, 0]).</param>
    /// <param name="mask">the mask of the points to consider (can be empty).</param>
    public static void DepthTo3d(InputArray depth, InputArray K, OutputArray points3d, InputArray? mask = null)
    {
        if (depth is null)
            throw new ArgumentNullException(nameof(depth));
        if (K is null)
            throw new ArgumentNullException(nameof(K));
        if (points3d is null)
            throw new ArgumentNullException(nameof(points3d));
        depth.ThrowIfDisposed();
        K.ThrowIfDisposed();
        points3d.ThrowIfNotReady();
        mask?.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ptcloud_depthTo3d(depth.CvPtr, K.CvPtr, points3d.CvPtr, ToPtr(mask)));

        points3d.Fix();
        GC.KeepAlive(depth);
        GC.KeepAlive(K);
        GC.KeepAlive(mask);
    }

    /// <summary>
    /// Rescales a depth image. If the input image is of type CV_16UC1, it is converted to floats,
    /// divided by depthFactor to get a depth in meters; otherwise it is simply converted to floats.
    /// </summary>
    /// <param name="src">the depth image.</param>
    /// <param name="type">the desired output depth (CV_32F or CV_64F).</param>
    /// <param name="dst">the rescaled float depth image.</param>
    /// <param name="depthFactor">factor by which depth is converted to distance (by default = 1000.0 for Kinect sensor).</param>
    public static void RescaleDepth(InputArray src, int type, OutputArray dst, double depthFactor = 1000.0)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        src.ThrowIfDisposed();
        dst.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.ptcloud_rescaleDepth(src.CvPtr, type, dst.CvPtr, depthFactor));

        dst.Fix();
        GC.KeepAlive(src);
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
        InputArray depth, InputArray? image, InputArray? mask, InputArray Rt, InputArray cameraMatrix,
        OutputArray? warpedDepth = null, OutputArray? warpedImage = null, OutputArray? warpedMask = null)
    {
        if (depth is null)
            throw new ArgumentNullException(nameof(depth));
        if (Rt is null)
            throw new ArgumentNullException(nameof(Rt));
        if (cameraMatrix is null)
            throw new ArgumentNullException(nameof(cameraMatrix));
        depth.ThrowIfDisposed();
        image?.ThrowIfDisposed();
        mask?.ThrowIfDisposed();
        Rt.ThrowIfDisposed();
        cameraMatrix.ThrowIfDisposed();
        warpedDepth?.ThrowIfNotReady();
        warpedImage?.ThrowIfNotReady();
        warpedMask?.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.ptcloud_warpFrame(
                depth.CvPtr, ToPtr(image), ToPtr(mask), Rt.CvPtr, cameraMatrix.CvPtr,
                ToPtr(warpedDepth), ToPtr(warpedImage), ToPtr(warpedMask)));

        warpedDepth?.Fix();
        warpedImage?.Fix();
        warpedMask?.Fix();
        GC.KeepAlive(depth);
        GC.KeepAlive(image);
        GC.KeepAlive(mask);
        GC.KeepAlive(Rt);
        GC.KeepAlive(cameraMatrix);
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
        InputArray points3d, InputArray normals, OutputArray mask, OutputArray planeCoefficients,
        int blockSize = 40, int minSize = 1600, double threshold = 0.01,
        double sensorErrorA = 0, double sensorErrorB = 0, double sensorErrorC = 0,
        RgbdPlaneMethod method = RgbdPlaneMethod.Default)
    {
        if (points3d is null)
            throw new ArgumentNullException(nameof(points3d));
        if (normals is null)
            throw new ArgumentNullException(nameof(normals));
        if (mask is null)
            throw new ArgumentNullException(nameof(mask));
        if (planeCoefficients is null)
            throw new ArgumentNullException(nameof(planeCoefficients));
        points3d.ThrowIfDisposed();
        normals.ThrowIfDisposed();
        mask.ThrowIfNotReady();
        planeCoefficients.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.ptcloud_findPlanes(
                points3d.CvPtr, normals.CvPtr, mask.CvPtr, planeCoefficients.CvPtr,
                blockSize, minSize, threshold,
                sensorErrorA, sensorErrorB, sensorErrorC, (int)method));

        mask.Fix();
        planeCoefficients.Fix();
        GC.KeepAlive(points3d);
        GC.KeepAlive(normals);
    }

    /// <summary>
    /// Loads a point cloud from a file (.ply / .obj). The file format is chosen by the extension.
    /// </summary>
    /// <param name="filename">Name of the file.</param>
    /// <param name="vertices">Output vertex coordinates, each value contains 3 floats.</param>
    /// <param name="normals">Output per-vertex normals, each value contains 3 floats (optional).</param>
    /// <param name="rgb">Output per-vertex colors, each value contains 3 floats (optional).</param>
    public static void LoadPointCloud(string filename, OutputArray vertices, OutputArray? normals = null, OutputArray? rgb = null)
    {
        if (filename is null)
            throw new ArgumentNullException(nameof(filename));
        if (vertices is null)
            throw new ArgumentNullException(nameof(vertices));
        vertices.ThrowIfNotReady();
        normals?.ThrowIfNotReady();
        rgb?.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.ptcloud_loadPointCloud(filename, vertices.CvPtr, ToPtr(normals), ToPtr(rgb)));

        vertices.Fix();
        normals?.Fix();
        rgb?.Fix();
    }

    /// <summary>
    /// Saves a point cloud to a file (.ply / .obj). The file format is chosen by the extension.
    /// </summary>
    /// <param name="filename">Name of the file.</param>
    /// <param name="vertices">Vertex coordinates, each value contains 3 floats.</param>
    /// <param name="normals">Per-vertex normals, each value contains 3 floats (optional).</param>
    /// <param name="rgb">Per-vertex colors, each value contains 3 floats (optional).</param>
    public static void SavePointCloud(string filename, InputArray vertices, InputArray? normals = null, InputArray? rgb = null)
    {
        if (filename is null)
            throw new ArgumentNullException(nameof(filename));
        if (vertices is null)
            throw new ArgumentNullException(nameof(vertices));
        vertices.ThrowIfDisposed();
        normals?.ThrowIfDisposed();
        rgb?.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.ptcloud_savePointCloud(filename, vertices.CvPtr, ToPtr(normals), ToPtr(rgb)));

        GC.KeepAlive(vertices);
        GC.KeepAlive(normals);
        GC.KeepAlive(rgb);
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
        string filename, OutputArray vertices, out Mat[] indices,
        OutputArray? normals = null, OutputArray? colors = null, OutputArray? texCoords = null)
    {
        if (filename is null)
            throw new ArgumentNullException(nameof(filename));
        if (vertices is null)
            throw new ArgumentNullException(nameof(vertices));
        vertices.ThrowIfNotReady();
        normals?.ThrowIfNotReady();
        colors?.ThrowIfNotReady();
        texCoords?.ThrowIfNotReady();

        using var indicesVec = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.ptcloud_loadMesh(
                filename, vertices.CvPtr, indicesVec.CvPtr, ToPtr(normals), ToPtr(colors), ToPtr(texCoords)));

        vertices.Fix();
        normals?.Fix();
        colors?.Fix();
        texCoords?.Fix();
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
        string filename, InputArray vertices, IEnumerable<Mat> indices,
        InputArray? normals = null, InputArray? colors = null, InputArray? texCoords = null)
    {
        if (filename is null)
            throw new ArgumentNullException(nameof(filename));
        if (vertices is null)
            throw new ArgumentNullException(nameof(vertices));
        if (indices is null)
            throw new ArgumentNullException(nameof(indices));
        vertices.ThrowIfDisposed();
        normals?.ThrowIfDisposed();
        colors?.ThrowIfDisposed();
        texCoords?.ThrowIfDisposed();

        var indicesArray = indices as Mat[] ?? indices.ToArray();
        using var indicesVec = new VectorOfMat(indicesArray);
        NativeMethods.HandleException(
            NativeMethods.ptcloud_saveMesh(
                filename, vertices.CvPtr, indicesVec.CvPtr, ToPtr(normals), ToPtr(colors), ToPtr(texCoords)));

        GC.KeepAlive(vertices);
        GC.KeepAlive(normals);
        GC.KeepAlive(colors);
        GC.KeepAlive(texCoords);
        GC.KeepAlive(indicesArray);
    }
}
