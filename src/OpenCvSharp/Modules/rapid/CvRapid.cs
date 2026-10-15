using OpenCvSharp.Internal;

namespace OpenCvSharp.Rapid;

/// <summary>Silhouette-based 3D object tracking helpers.</summary>
public static class CvRapid
{
    /// <summary>Runs one RAPID pose-refinement iteration using an initial rotation and translation.</summary>
    /// <param name="image">8-bit grayscale or BGR video frame.</param>
    /// <param name="num">Number of search lines, at least three.</param>
    /// <param name="len">Search radius in pixels.</param>
    /// <param name="vertices">Mesh vertices as 3D float points.</param>
    /// <param name="triangles">Triangle vertex indices as 3D int vectors.</param>
    /// <param name="cameraMatrix">3-by-3 camera intrinsic matrix.</param>
    /// <param name="rotation">Initial and refined rotation vector.</param>
    /// <param name="translation">Initial and refined translation vector.</param>
    /// <param name="rmsd">Reprojection difference for matched search lines, or NaN if no match is available.</param>
    /// <returns>Fraction of search lines that were matched.</returns>
    public static float Track(
        Mat image, int num, int len, Mat vertices, Mat triangles, Mat cameraMatrix,
        Mat rotation, Mat translation, out double rmsd)
    {
        ArgumentNullException.ThrowIfNull(image);
        ArgumentNullException.ThrowIfNull(vertices);
        ArgumentNullException.ThrowIfNull(triangles);
        ArgumentNullException.ThrowIfNull(cameraMatrix);
        ArgumentNullException.ThrowIfNull(rotation);
        ArgumentNullException.ThrowIfNull(translation);
        image.ThrowIfDisposed();
        vertices.ThrowIfDisposed();
        triangles.ThrowIfDisposed();
        cameraMatrix.ThrowIfDisposed();
        rotation.ThrowIfDisposed();
        translation.ThrowIfDisposed();

        if (num < 3)
            throw new ArgumentOutOfRangeException(nameof(num), "At least three search lines are required.");
        if (len <= 0)
            throw new ArgumentOutOfRangeException(nameof(len));
        if (image.Type() != MatType.CV_8UC1 && image.Type() != MatType.CV_8UC3)
            throw new ArgumentException("Expected an 8-bit grayscale or BGR image.", nameof(image));
        ValidateMesh(vertices, triangles);
        if (cameraMatrix.Rows != 3 || cameraMatrix.Cols != 3 ||
            (cameraMatrix.Type() != MatType.CV_32FC1 && cameraMatrix.Type() != MatType.CV_64FC1))
            throw new ArgumentException("Expected a 3-by-3 float or double camera matrix.", nameof(cameraMatrix));
        ValidatePose(rotation, nameof(rotation));
        ValidatePose(translation, nameof(translation));

        NativeMethods.HandleException(NativeMethods.rapid_track(
            image.CvPtr, num, len, vertices.CvPtr, triangles.CvPtr,
            cameraMatrix.CvPtr, rotation.CvPtr, translation.CvPtr, out var ratio, out rmsd));
        GC.KeepAlive(image);
        GC.KeepAlive(vertices);
        GC.KeepAlive(triangles);
        GC.KeepAlive(cameraMatrix);
        GC.KeepAlive(rotation);
        GC.KeepAlive(translation);
        return ratio;
    }

    /// <summary>Draws a projected triangle mesh on an image.</summary>
    /// <param name="image">Image to draw on.</param>
    /// <param name="imagePoints">Projected mesh vertices as 2D float points.</param>
    /// <param name="triangles">Triangle vertex indices as 3D int vectors.</param>
    /// <param name="color">Line color.</param>
    /// <param name="lineType">Line type.</param>
    /// <param name="cullBackface">Whether to omit back-facing triangles.</param>
    public static void DrawWireframe(
        Mat image, Mat imagePoints, Mat triangles, Scalar color,
        LineTypes lineType = LineTypes.Link8, bool cullBackface = false)
    {
        ArgumentNullException.ThrowIfNull(image);
        ArgumentNullException.ThrowIfNull(imagePoints);
        ArgumentNullException.ThrowIfNull(triangles);
        image.ThrowIfDisposed();
        imagePoints.ThrowIfDisposed();
        triangles.ThrowIfDisposed();
        if (imagePoints.CheckVector(2, (int)MatType.CV_32F) < 3)
            throw new ArgumentException("Expected at least three 2D float points.", nameof(imagePoints));
        if (triangles.CheckVector(3, (int)MatType.CV_32S) < 1)
            throw new ArgumentException("Expected at least one triangle of int indices.", nameof(triangles));

        NativeMethods.HandleException(NativeMethods.rapid_drawWireframe(
            image.CvPtr, imagePoints.CvPtr, triangles.CvPtr,
            color, (int)lineType, cullBackface ? 1 : 0));
        GC.KeepAlive(image);
        GC.KeepAlive(imagePoints);
        GC.KeepAlive(triangles);
    }

    private static void ValidateMesh(Mat vertices, Mat triangles)
    {
        if (vertices.CheckVector(3, (int)MatType.CV_32F) < 3)
            throw new ArgumentException("Expected at least three 3D float vertices.", nameof(vertices));
        if (triangles.CheckVector(3, (int)MatType.CV_32S) < 1)
            throw new ArgumentException("Expected at least one triangle of int indices.", nameof(triangles));
    }

    private static void ValidatePose(Mat pose, string paramName)
    {
        if ((pose.Type() != MatType.CV_32FC1 && pose.Type() != MatType.CV_64FC1) ||
            pose.CheckVector(3) != 1)
            throw new ArgumentException("Expected a three-element float or double vector.", paramName);
    }
}
