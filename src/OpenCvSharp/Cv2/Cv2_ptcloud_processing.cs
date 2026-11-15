using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

static partial class Cv2
{
    /// <summary>Filters points by their mean distance to their nearest neighbors.</summary>
    /// <param name="inputCloud">Input point cloud.</param>
    /// <param name="outputCloud">Output filtered point cloud.</param>
    /// <param name="meanK">Number of neighbors used to estimate each point's mean distance.</param>
    /// <param name="stddevMulThresh">Standard-deviation multiplier for the distance threshold.</param>
    /// <param name="keptIndices">Optional output indices into the original cloud.</param>
    public static void RemoveStatisticalOutliers(InputArray inputCloud, OutputArray outputCloud, int meanK = 20, double stddevMulThresh = 2.0,
        OutputArray keptIndices = default)
    {
        NativeMethods.HandleException(NativeMethods.ptcloud_removeStatisticalOutliers(inputCloud.Proxy, outputCloud.Proxy, meanK, stddevMulThresh, keptIndices.Proxy));

        GC.KeepAlive(inputCloud.Source);
        GC.KeepAlive(outputCloud.Source);
        GC.KeepAlive(keptIndices.Source);
    }

    /// <summary>Filters points by the number of neighbors within a radius.</summary>
    /// <param name="inputCloud">Input point cloud.</param>
    /// <param name="outputCloud">Output filtered point cloud.</param>
    /// <param name="radius">Search radius.</param>
    /// <param name="minNeighbors">Minimum number of other points required within the radius.</param>
    /// <param name="keptIndices">Optional output indices into the original cloud.</param>
    public static void RemoveRadiusOutliers(InputArray inputCloud, OutputArray outputCloud, double radius, int minNeighbors = 16,
        OutputArray keptIndices = default)
    {
        NativeMethods.HandleException(NativeMethods.ptcloud_removeRadiusOutliers(inputCloud.Proxy, outputCloud.Proxy, radius, minNeighbors, keptIndices.Proxy));

        GC.KeepAlive(inputCloud.Source);
        GC.KeepAlive(outputCloud.Source);
        GC.KeepAlive(keptIndices.Source);
    }

    /// <summary>Orients point-cloud normals towards a viewpoint.</summary>
    /// <param name="inputCloud">Input point cloud.</param>
    /// <param name="normals">Input/output normals, one per point.</param>
    /// <param name="viewpoint">Point that the normals should face.</param>
    public static void OrientNormals(InputArray inputCloud, InputOutputArray normals, Point3f viewpoint)
    {
        NativeMethods.HandleException(NativeMethods.ptcloud_orientNormals(inputCloud.Proxy, normals.Proxy, viewpoint));

        GC.KeepAlive(inputCloud.Source);
        GC.KeepAlive(normals.Source);
    }

    /// <summary>Propagates consistent normal directions across a point cloud.</summary>
    /// <param name="inputCloud">Input point cloud.</param>
    /// <param name="normals">Input/output normals, one per point.</param>
    /// <param name="k">Number of nearest neighbors used to build the graph.</param>
    public static void OrientNormalsConsistent(InputArray inputCloud, InputOutputArray normals, int k = 30)
    {
        NativeMethods.HandleException(NativeMethods.ptcloud_orientNormalsConsistent(inputCloud.Proxy, normals.Proxy, k));

        GC.KeepAlive(inputCloud.Source);
        GC.KeepAlive(normals.Source);
    }

    /// <summary>Estimates the median distance to the nearest neighbor.</summary>
    /// <param name="inputCloud">Input point cloud.</param>
    /// <returns>Median nearest-neighbor distance, or zero for fewer than two points.</returns>
    public static float EstimateMedianSpacing(InputArray inputCloud)
    {
        NativeMethods.HandleException(NativeMethods.ptcloud_estimateMedianSpacing(inputCloud.Proxy, out var result));

        GC.KeepAlive(inputCloud.Source);
        return result;
    }

    /// <summary>Reconstructs a triangle mesh from an oriented point cloud using Ball-Pivoting.</summary>
    /// <param name="inputCloud">Input point cloud.</param>
    /// <param name="normals">One normal per input point.</param>
    /// <param name="vertices">Output vertices as a CV_32FC3 vector.</param>
    /// <param name="triangles">Output triangle indices as an Mx3 CV_32S matrix.</param>
    /// <param name="radii">Optional ball radii. If omitted, OpenCV derives them from the median point spacing.</param>
    public static void CreateMeshBPA(InputArray inputCloud, InputArray normals, OutputArray vertices, OutputArray triangles,
        InputArray radii = default)
    {
        NativeMethods.HandleException(NativeMethods.ptcloud_createMeshBPA(inputCloud.Proxy, normals.Proxy, vertices.Proxy, triangles.Proxy, radii.Proxy));

        GC.KeepAlive(inputCloud.Source);
        GC.KeepAlive(normals.Source);
        GC.KeepAlive(vertices.Source);
        GC.KeepAlive(triangles.Source);
        GC.KeepAlive(radii.Source);
    }

    /// <summary>Computes the axis-aligned bounding box of a point cloud.</summary>
    /// <param name="inputCloud">Input point cloud.</param>
    /// <param name="minBound">Output minimum corner as a 3x1 CV_32F matrix.</param>
    /// <param name="maxBound">Output maximum corner as a 3x1 CV_32F matrix.</param>
    public static void BoundingBox3D(InputArray inputCloud, OutputArray minBound, OutputArray maxBound)
    {
        NativeMethods.HandleException(NativeMethods.ptcloud_boundingBox3D(inputCloud.Proxy, minBound.Proxy, maxBound.Proxy));

        GC.KeepAlive(inputCloud.Source);
        GC.KeepAlive(minBound.Source);
        GC.KeepAlive(maxBound.Source);
    }

    /// <summary>Computes a principal-component-based oriented bounding box.</summary>
    /// <param name="inputCloud">Input point cloud.</param>
    /// <param name="center">Output center as a 3x1 CV_32F matrix.</param>
    /// <param name="axes">Output 3x3 CV_32F matrix with one unit axis per row.</param>
    /// <param name="halfExtents">Output half-size along each axis as a 3x1 CV_32F matrix.</param>
    public static void OrientedBoundingBox3D(InputArray inputCloud, OutputArray center, OutputArray axes, OutputArray halfExtents)
    {
        NativeMethods.HandleException(NativeMethods.ptcloud_orientedBoundingBox3D(inputCloud.Proxy, center.Proxy, axes.Proxy, halfExtents.Proxy));

        GC.KeepAlive(inputCloud.Source);
        GC.KeepAlive(center.Source);
        GC.KeepAlive(axes.Source);
        GC.KeepAlive(halfExtents.Source);
    }

    /// <summary>Computes an approximate smallest enclosing sphere.</summary>
    /// <param name="inputCloud">Input point cloud.</param>
    /// <param name="center">Output sphere center as a 3x1 CV_32F matrix.</param>
    /// <returns>Sphere radius, or zero for an empty cloud.</returns>
    public static double ApproxEnclosingSphere3D(InputArray inputCloud, OutputArray center)
    {
        NativeMethods.HandleException(NativeMethods.ptcloud_approxEnclosingSphere3D(inputCloud.Proxy, center.Proxy, out var result));

        GC.KeepAlive(inputCloud.Source);
        GC.KeepAlive(center.Source);
        return result;
    }

    /// <summary>Decodes Gaussian Splatting attributes into a scene.</summary>
    /// <param name="attributes">CV_32F matrix with columns in the order returned by GetGaussianSplatPlyPropNames.</param>
    /// <param name="splats">Output scene with columns defined by GaussianSplatLayout.</param>
    public static void DecodeGaussianSplats(InputArray attributes, OutputArray splats)
    {
        NativeMethods.HandleException(NativeMethods.ptcloud_decodeGaussianSplats(attributes.Proxy, splats.Proxy));

        GC.KeepAlive(attributes.Source);
        GC.KeepAlive(splats.Source);
    }

    /// <summary>Decodes packed 32-byte Gaussian Splatting records.</summary>
    /// <param name="buffer">CV_8U data containing the bytes of a .splat file.</param>
    /// <param name="splats">Output scene with columns defined by GaussianSplatLayout.</param>
    public static void DecodeGaussianSplatsPacked(InputArray buffer, OutputArray splats)
    {
        NativeMethods.HandleException(NativeMethods.ptcloud_decodeGaussianSplatsPacked(buffer.Proxy, splats.Proxy));

        GC.KeepAlive(buffer.Source);
        GC.KeepAlive(splats.Source);
    }

    /// <summary>Returns the default PLY vertex property names in the order used by DecodeGaussianSplats.</summary>
    public static string[] GetGaussianSplatPlyPropNames()
    {
        using var names = new VectorOfString();
        NativeMethods.HandleException(NativeMethods.ptcloud_getGaussianSplatPlyPropNames(names.CvPtr));
        return names.ToArray();
    }

    /// <summary>Loads a Gaussian splat scene from a PLY or .splat file.</summary>
    /// <param name="filename">Input scene filename.</param>
    /// <param name="splats">Output scene with columns defined by <see cref="GaussianSplatLayout"/>.</param>
    /// <param name="plyProperties">Optional PLY property names in the order returned by
    /// <see cref="GetGaussianSplatPlyPropNames"/>. The default names are used when omitted or empty.</param>
    public static void LoadGaussianSplats(string filename, OutputArray splats, IEnumerable<string>? plyProperties = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);

        using var properties = plyProperties is null ? new VectorOfString() : new VectorOfString(plyProperties);
        NativeMethods.HandleException(NativeMethods.ptcloud_loadGaussianSplats(filename, splats.Proxy, properties.CvPtr));

        GC.KeepAlive(splats.Source);
    }
}
