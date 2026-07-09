using OpenCvSharp.Internal;

namespace OpenCvSharp.Flann;

/// <summary>
/// The FLANN nearest neighbor index class. 
/// </summary>
public class Index : CvObject
{
    /// <summary>
    /// Constructs an empty index. Call <see cref="Build"/> or <see cref="Load"/> before searching.
    /// </summary>
    public Index()
    {
        NativeMethods.HandleException(
            NativeMethods.flann_Index_new0(out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException("Failed to create Index");
        InitSafeHandle(p);
    }

    /// <summary>
    /// Constructs a nearest neighbor search index for a given dataset.
    /// </summary>
    /// <param name="features">features – Matrix of type CV _ 32F containing the features(points) to index. The size of the matrix is num _ features x feature _ dimensionality.</param>
    /// <param name="params">Structure containing the index parameters. The type of index that will be constructed depends on the type of this parameter. </param>
    /// <param name="distType"></param>
    public Index(InputArray features, IndexParams @params, FlannDistance distType = FlannDistance.L2)
    {
        ArgumentNullException.ThrowIfNull(@params);

        NativeMethods.HandleException(
            NativeMethods.flann_Index_new(features.Proxy, @params.CvPtr, (int)distType, out var p));

        GC.KeepAlive(features.Source);
        GC.KeepAlive(@params);
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException("Failed to create Index");
        InitSafeHandle(p);
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>

    private void InitSafeHandle(IntPtr p, bool ownsHandle = true)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle,
            static h => NativeMethods.HandleException(NativeMethods.flann_Index_delete(h))));
    }

    /// <summary>
    /// Builds the index using the specified dataset and parameters.
    /// </summary>
    /// <param name="features">Matrix of type CV_32F containing the features(points) to index.</param>
    /// <param name="params">Structure containing the index parameters.</param>
    /// <param name="distType"></param>
    public void Build(InputArray features, IndexParams @params, FlannDistance distType = FlannDistance.L2)
    {
        ArgumentNullException.ThrowIfNull(@params);

        NativeMethods.HandleException(
            NativeMethods.flann_Index_build(Handle, features.Proxy, @params.CvPtr, (int)distType));

        GC.KeepAlive(features.Source);
        GC.KeepAlive(@params);
    }

    /// <summary>
    /// Loads a previously saved index from a file.
    /// </summary>
    /// <param name="features">The dataset that was used to build the saved index.</param>
    /// <param name="filename">The file to load the index from.</param>
    /// <returns>true if the load succeeded.</returns>
    public bool Load(InputArray features, string filename)
    {
        if (string.IsNullOrEmpty(filename))
            throw new ArgumentNullException(nameof(filename));

        NativeMethods.HandleException(
            NativeMethods.flann_Index_load(Handle, features.Proxy, filename, out var ret));

        GC.KeepAlive(features.Source);
        return ret != 0;
    }

    /// <summary>
    /// Releases the inner search structures. Reserved for future use.
    /// </summary>
    public void Release()
    {
        NativeMethods.HandleException(
            NativeMethods.flann_Index_release(Handle));
    }

    /// <summary>
    /// The distance metric used by the index.
    /// </summary>
    public FlannDistance GetDistance()
    {
        NativeMethods.HandleException(
            NativeMethods.flann_Index_getDistance(Handle, out var ret));
        return (FlannDistance)ret;
    }

    /// <summary>
    /// The algorithm used by the index.
    /// </summary>
    public FlannAlgorithm GetAlgorithm()
    {
        NativeMethods.HandleException(
            NativeMethods.flann_Index_getAlgorithm(Handle, out var ret));
        return (FlannAlgorithm)ret;
    }

    /// <summary>
    /// Performs a K-nearest neighbor search for multiple query points.
    /// </summary>
    /// <param name="queries">The query points, one per row</param>
    /// <param name="indices">Indices of the nearest neighbors found</param>
    /// <param name="dists">Distances to the nearest neighbors found</param>
    /// <param name="knn">Number of nearest neighbors to search for</param>
    /// <param name="params">Search parameters</param>
    public void KnnSearch(float[] queries, out int[] indices, out float[] dists, int knn, SearchParams @params)
    {
        ArgumentNullException.ThrowIfNull(queries);
        ArgumentNullException.ThrowIfNull(@params);
        if (queries.Length == 0)
            throw new ArgumentException("empty array", nameof(queries));
        ArgumentOutOfRangeException.ThrowIfLessThan(knn, 1);

        indices = new int[knn];
        dists = new float[knn];

        NativeMethods.HandleException(
            NativeMethods.flann_Index_knnSearch1(
                Handle, queries, queries.Length, indices, dists, knn, @params.CvPtr));

        GC.KeepAlive(@params);
    }

    /// <summary>
    /// Performs a K-nearest neighbor search for multiple query points.
    /// </summary>
    /// <param name="queries">The query points, one per row</param>
    /// <param name="indices">Indices of the nearest neighbors found</param>
    /// <param name="dists">Distances to the nearest neighbors found</param>
    /// <param name="knn">Number of nearest neighbors to search for</param>
    /// <param name="params">Search parameters</param>
    public void KnnSearch(Mat queries, Mat indices, Mat dists, int knn, SearchParams @params)
    {
        ArgumentNullException.ThrowIfNull(queries);
        ArgumentNullException.ThrowIfNull(indices);
        ArgumentNullException.ThrowIfNull(dists);
        ArgumentNullException.ThrowIfNull(@params);

        NativeMethods.HandleException(
            NativeMethods.flann_Index_knnSearch2(
                Handle, queries.CvPtr, indices.CvPtr, dists.CvPtr, knn, @params.CvPtr));

        GC.KeepAlive(queries);
        GC.KeepAlive(indices);
        GC.KeepAlive(dists);
        GC.KeepAlive(@params);
    }

    /// <summary>
    /// Performs a K-nearest neighbor search for multiple query points.
    /// </summary>
    /// <param name="queries">The query points, one per row</param>
    /// <param name="indices">Indices of the nearest neighbors found</param>
    /// <param name="dists">Distances to the nearest neighbors found</param>
    /// <param name="knn">Number of nearest neighbors to search for</param>
    /// <param name="params">Search parameters</param>
    public void KnnSearch(Mat queries, out int[] indices, out float[] dists, int knn, SearchParams @params)
    {
        ArgumentNullException.ThrowIfNull(queries);
        ArgumentNullException.ThrowIfNull(@params);
        ArgumentOutOfRangeException.ThrowIfLessThan(knn, 1);

        indices = new int[knn];
        dists = new float[knn];

        NativeMethods.HandleException(
            NativeMethods.flann_Index_knnSearch3(
                Handle, queries.CvPtr, indices, dists, knn, @params.CvPtr));

        GC.KeepAlive(queries);
        GC.KeepAlive(@params);
    }

    /// <summary>
    /// Performs a radius nearest neighbor search for a given query point.
    /// </summary>
    /// <param name="queries">The query point</param>
    /// <param name="indices">Indices of the nearest neighbors found</param>
    /// <param name="dists">Distances to the nearest neighbors found</param>
    /// <param name="radius">Number of nearest neighbors to search for</param>
    /// <param name="maxResults"></param>
    /// <param name="params">Search parameters</param>
    public void RadiusSearch(float[] queries, int[] indices, float[] dists, double radius, int maxResults, SearchParams @params)
    {
        ArgumentNullException.ThrowIfNull(queries);
        ArgumentNullException.ThrowIfNull(indices);
        ArgumentNullException.ThrowIfNull(dists);
        ArgumentNullException.ThrowIfNull(@params);

        NativeMethods.HandleException(
            NativeMethods.flann_Index_radiusSearch1(
                Handle, queries, queries.Length, indices, indices.Length, dists, dists.Length, radius, maxResults, @params.CvPtr));

        GC.KeepAlive(@params);
    }

    /// <summary>
    /// Performs a radius nearest neighbor search for a given query point.
    /// </summary>
    /// <param name="queries">The query point</param>
    /// <param name="indices">Indices of the nearest neighbors found</param>
    /// <param name="dists">Distances to the nearest neighbors found</param>
    /// <param name="radius">Number of nearest neighbors to search for</param>
    /// <param name="maxResults"></param>
    /// <param name="params">Search parameters</param>
    public void RadiusSearch(Mat queries, Mat indices, Mat dists, double radius, int maxResults, SearchParams @params)
    {
        ArgumentNullException.ThrowIfNull(queries);
        ArgumentNullException.ThrowIfNull(indices);
        ArgumentNullException.ThrowIfNull(dists);
        ArgumentNullException.ThrowIfNull(@params);

        NativeMethods.HandleException(
            NativeMethods.flann_Index_radiusSearch2(
                Handle, queries.CvPtr, indices.CvPtr, dists.CvPtr, radius, maxResults, @params.CvPtr));

        GC.KeepAlive(queries);
        GC.KeepAlive(indices);
        GC.KeepAlive(dists);
        GC.KeepAlive(@params);
    }

    /// <summary>
    /// Performs a radius nearest neighbor search for a given query point.
    /// </summary>
    /// <param name="queries">The query point</param>
    /// <param name="indices">Indices of the nearest neighbors found</param>
    /// <param name="dists">Distances to the nearest neighbors found</param>
    /// <param name="radius">Number of nearest neighbors to search for</param>
    /// <param name="maxResults"></param>
    /// <param name="params">Search parameters</param>
    public void RadiusSearch(Mat queries, int[] indices, float[] dists, double radius, int maxResults, SearchParams @params)
    {
        ArgumentNullException.ThrowIfNull(queries);
        ArgumentNullException.ThrowIfNull(indices);
        ArgumentNullException.ThrowIfNull(dists);
        ArgumentNullException.ThrowIfNull(@params);

        NativeMethods.HandleException(
            NativeMethods.flann_Index_radiusSearch3(
                Handle, queries.CvPtr, indices, indices.Length, dists, dists.Length, radius, maxResults, @params.CvPtr));

        GC.KeepAlive(queries);
        GC.KeepAlive(@params);
    }

    /// <summary>
    /// Saves the index to a file.
    /// </summary>
    /// <param name="filename">The file to save the index to</param>
    public void Save(string filename)
    {
        if (string.IsNullOrEmpty(filename))
            throw new ArgumentNullException(nameof(filename));
        NativeMethods.HandleException(
            NativeMethods.flann_Index_save(Handle, filename));
    }
}
