namespace OpenCvSharp.Internal.Util;

/// <summary>
/// Maps a managed element type to the corresponding <see cref="MatType"/>.
/// Shared by the type-parameterized matrix wrappers (<c>Mat&lt;T&gt;</c>, <c>UMat</c>,
/// <c>SparseMat&lt;T&gt;</c>) so the mapping lives in one place.
/// </summary>
public static class MatTypeMap
{
    /// <summary>
    /// Managed element type to <see cref="MatType"/> mapping.
    /// </summary>
    public static readonly IReadOnlyDictionary<Type, MatType> Map = new Dictionary<Type, MatType>
    {
        [typeof(byte)] = MatType.CV_8UC1,
        [typeof(sbyte)] = MatType.CV_8SC1,
        [typeof(short)] = MatType.CV_16SC1,
        [typeof(char)] = MatType.CV_16UC1,
        [typeof(ushort)] = MatType.CV_16UC1,
        [typeof(int)] = MatType.CV_32SC1,
        [typeof(float)] = MatType.CV_32FC1,
        [typeof(double)] = MatType.CV_64FC1,

        // Depths added in OpenCV 5. (CV_16BF / bfloat16 has no standard managed type, so it is omitted.)
        [typeof(uint)] = MatType.CV_32UC1,
        [typeof(long)] = MatType.CV_64SC1,
        [typeof(ulong)] = MatType.CV_64UC1,
        [typeof(Half)] = MatType.CV_16FC1,
        [typeof(bool)] = MatType.CV_BoolC1,

        [typeof(Vec2b)] = MatType.CV_8UC2,
        [typeof(Vec3b)] = MatType.CV_8UC3,
        [typeof(Vec4b)] = MatType.CV_8UC4,
        [typeof(Vec6b)] = MatType.CV_8UC(6),

        [typeof(Vec2s)] = MatType.CV_16SC2,
        [typeof(Vec3s)] = MatType.CV_16SC3,
        [typeof(Vec4s)] = MatType.CV_16SC4,
        [typeof(Vec6s)] = MatType.CV_16SC(6),

        [typeof(Vec2w)] = MatType.CV_16UC2,
        [typeof(Vec3w)] = MatType.CV_16UC3,
        [typeof(Vec4w)] = MatType.CV_16UC4,
        [typeof(Vec6w)] = MatType.CV_16UC(6),

        [typeof(Vec2i)] = MatType.CV_32SC2,
        [typeof(Vec3i)] = MatType.CV_32SC3,
        [typeof(Vec4i)] = MatType.CV_32SC4,
        [typeof(Vec6i)] = MatType.CV_32SC(6),

        [typeof(Vec2f)] = MatType.CV_32FC2,
        [typeof(Vec3f)] = MatType.CV_32FC3,
        [typeof(Vec4f)] = MatType.CV_32FC4,
        [typeof(Vec6f)] = MatType.CV_32FC(6),

        [typeof(Vec2d)] = MatType.CV_64FC2,
        [typeof(Vec3d)] = MatType.CV_64FC3,
        [typeof(Vec4d)] = MatType.CV_64FC4,
        [typeof(Vec6d)] = MatType.CV_64FC(6),

        [typeof(Point)] = MatType.CV_32SC2,
        [typeof(Point2f)] = MatType.CV_32FC2,
        [typeof(Point2d)] = MatType.CV_64FC2,

        [typeof(Point3i)] = MatType.CV_32SC3,
        [typeof(Point3f)] = MatType.CV_32FC3,
        [typeof(Point3d)] = MatType.CV_64FC3,

        [typeof(Size)] = MatType.CV_32SC2,
        [typeof(Size2f)] = MatType.CV_32FC2,
        [typeof(Size2d)] = MatType.CV_64FC2,

        [typeof(Rect)] = MatType.CV_32SC4,
        [typeof(Rect2f)] = MatType.CV_32FC4,
        [typeof(Rect2d)] = MatType.CV_64FC4,

        [typeof(DMatch)] = MatType.CV_32FC4,
    };

    /// <summary>
    /// Returns the <see cref="MatType"/> for <typeparamref name="T"/>, or throws if unsupported.
    /// </summary>
    public static MatType Get<T>() where T : unmanaged
    {
        if (Map.TryGetValue(typeof(T), out var value))
            return value;
        throw new NotSupportedException($"Type parameter {typeof(T)} is not supported.");
    }
}
