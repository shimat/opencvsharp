using OpenCvSharp.Internal;

namespace OpenCvSharp.Flann;

/// <summary>
/// The FLANN nearest neighbor index class. 
/// </summary>
public class Index : DisposableCvObject
{
    /// <summary>
    /// Constructs a nearest neighbor search index for a given dataset.
    /// </summary>
    /// <param name="features">features – Matrix of type CV _ 32F containing the features(points) to index. The size of the matrix is num _ features x feature _ dimensionality.</param>
    /// <param name="params">Structure containing the index parameters. The type of index that will be constructed depends on the type of this parameter. </param>
    /// <param name="distType"></param>
    public Index(InputArray features, IndexParams @params, FlannDistance distType = FlannDistance.L2)
    {
        if (features is null)
            throw new ArgumentNullException(nameof(features));
        if (@params is null)
            throw new ArgumentNullException(nameof(@params));

        NativeMethods.HandleException(
            NativeMethods.flann_Index_new(features.CvPtr, @params.CvPtr, (int)distType, out ptr));

        GC.KeepAlive(features);
        GC.KeepAlive(@params);
        if (ptr == IntPtr.Zero)
            throw new OpenCvSharpException("Failed to create Index");
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.HandleException(
            NativeMethods.flann_Index_delete(ptr));
        base.DisposeUnmanaged();
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
        if (queries is null)
            throw new ArgumentNullException(nameof(queries));
        if (@params is null)
            throw new ArgumentNullException(nameof(@params));
        if (queries.Length == 0)
            throw new ArgumentException("empty array", nameof(queries));
        if (knn < 1)
            throw new ArgumentOutOfRangeException(nameof(knn));

        indices = new int[knn];
        dists = new float[knn];

        NativeMethods.HandleException(
            NativeMethods.flann_Index_knnSearch1(
                ptr, queries, queries.Length, indices, dists, knn, @params.CvPtr));

        GC.KeepAlive(this);
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
        if (queries is null)
            throw new ArgumentNullException(nameof(queries));
        if (indices is null)
            throw new ArgumentNullException(nameof(indices));
        if (dists is null)
            throw new ArgumentNullException(nameof(dists));
        if (@params is null)
            throw new ArgumentNullException(nameof(@params));

        NativeMethods.HandleException(
            NativeMethods.flann_Index_knnSearch2(
                ptr, queries.CvPtr, indices.CvPtr, dists.CvPtr, knn, @params.CvPtr));

        GC.KeepAlive(this);
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
        if (queries is null)
            throw new ArgumentNullException(nameof(queries));
        if (@params is null)
            throw new ArgumentNullException(nameof(@params));
        if (knn < 1)
            throw new ArgumentOutOfRangeException(nameof(knn));

        indices = new int[knn];
        dists = new float[knn];

        NativeMethods.HandleException(
            NativeMethods.flann_Index_knnSearch3(
                ptr, queries.CvPtr, indices, dists, knn, @params.CvPtr));

        GC.KeepAlive(this);
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
        if (queries is null)
            throw new ArgumentNullException(nameof(queries));
        if (indices is null)
            throw new ArgumentNullException(nameof(indices));
        if (dists is null)
            throw new ArgumentNullException(nameof(dists));
        if (@params is null)
            throw new ArgumentNullException(nameof(@params));

        NativeMethods.HandleException(
            NativeMethods.flann_Index_radiusSearch1(
                ptr, queries, queries.Length, indices, indices.Length, dists, dists.Length, radius, maxResults, @params.CvPtr));

        GC.KeepAlive(this);
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
        if (queries is null)
            throw new ArgumentNullException(nameof(queries));
        if (indices is null)
            throw new ArgumentNullException(nameof(indices));
        if (dists is null)
            throw new ArgumentNullException(nameof(dists));
        if (@params is null)
            throw new ArgumentNullException(nameof(@params));

        NativeMethods.HandleException(
            NativeMethods.flann_Index_radiusSearch2(
                ptr, queries.CvPtr, indices.CvPtr, dists.CvPtr, radius, maxResults, @params.CvPtr));

        GC.KeepAlive(this);
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
        if (queries is null)
            throw new ArgumentNullException(nameof(queries));
        if (indices is null)
            throw new ArgumentNullException(nameof(indices));
        if (dists is null)
            throw new ArgumentNullException(nameof(dists));
        if (@params is null)
            throw new ArgumentNullException(nameof(@params));

        NativeMethods.HandleException(
            NativeMethods.flann_Index_radiusSearch3(
                ptr, queries.CvPtr, indices, indices.Length, dists, dists.Length, radius, maxResults, @params.CvPtr));

        GC.KeepAlive(this);
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
            NativeMethods.flann_Index_save(ptr, filename));
        GC.KeepAlive(this);
    }
}
