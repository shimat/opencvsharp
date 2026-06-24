using OpenCvSharp.Internal;

namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Approximate nearest neighbor index backed by Annoy (OpenCV 5), a modern alternative to FLANN.
/// </summary>
public class ANNIndex : CvPtrObject
{
    /// <summary>
    /// Creates instance from a cv::Ptr&lt;cv::ANNIndex&gt;* smart pointer and the raw cv::ANNIndex*.
    /// </summary>
    private ANNIndex(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.features_Ptr_ANNIndex_delete(p)))
    {
    }

    /// <summary>
    /// Creates an instance of the Annoy index with the given parameters.
    /// </summary>
    /// <param name="dim">The dimension of the feature vector.</param>
    /// <param name="distType">Metric used to calculate the distance between two feature vectors.</param>
    public static ANNIndex Create(int dim, ANNIndexDistance distType = ANNIndexDistance.Euclidean)
    {
        NativeMethods.HandleException(
            NativeMethods.features_ANNIndex_create(dim, (int)distType, out var smartPtr));
        NativeMethods.HandleException(
            NativeMethods.features_Ptr_ANNIndex_get(smartPtr, out var rawPtr));
        return new ANNIndex(smartPtr, rawPtr);
    }

    /// <summary>
    /// Adds feature vectors to the index.
    /// </summary>
    /// <param name="features">Matrix containing the feature vectors to index (num_features x feature_dimension).</param>
    public void AddItems(InputArray features)
    {
        ThrowIfDisposed();
        if (features is null)
            throw new ArgumentNullException(nameof(features));
        features.ThrowIfDisposed();

        NativeMethods.HandleException(NativeMethods.features_ANNIndex_addItems(RawPtr, features.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(features);
    }

    /// <summary>
    /// Builds the index.
    /// </summary>
    /// <param name="trees">Number of trees in the index. -1 determines the number automatically.</param>
    public void Build(int trees = -1)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.features_ANNIndex_build(RawPtr, trees));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Performs a K-nearest neighbor search for the given query vector(s) using the index.
    /// </summary>
    /// <param name="query">The query vector(s).</param>
    /// <param name="indices">Output matrix that will contain the indices of the K-nearest neighbors found.</param>
    /// <param name="dists">Output matrix that will contain the distances to the K-nearest neighbors found.</param>
    /// <param name="knn">Number of nearest neighbors to search for.</param>
    /// <param name="searchK">The maximum number of nodes to inspect; defaults to trees x knn when -1.</param>
    public void KnnSearch(InputArray query, OutputArray indices, OutputArray dists, int knn, int searchK = -1)
    {
        ThrowIfDisposed();
        if (query is null)
            throw new ArgumentNullException(nameof(query));
        if (indices is null)
            throw new ArgumentNullException(nameof(indices));
        if (dists is null)
            throw new ArgumentNullException(nameof(dists));
        query.ThrowIfDisposed();
        indices.ThrowIfNotReady();
        dists.ThrowIfNotReady();

        NativeMethods.HandleException(
            NativeMethods.features_ANNIndex_knnSearch(RawPtr, query.CvPtr, indices.CvPtr, dists.CvPtr, knn, searchK));
        GC.KeepAlive(this);
        GC.KeepAlive(query);
        indices.Fix();
        dists.Fix();
    }

    /// <summary>
    /// Saves the index to disk. After saving, no more vectors can be added.
    /// </summary>
    /// <param name="filename">Filename of the index to be saved.</param>
    /// <param name="prefault">If true, pre-reads the entire file into memory.</param>
    public void Save(string filename, bool prefault = false)
    {
        ThrowIfDisposed();
        if (filename is null)
            throw new ArgumentNullException(nameof(filename));

        NativeMethods.HandleException(NativeMethods.features_ANNIndex_save(RawPtr, filename, prefault ? 1 : 0));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Loads (mmaps) an index from disk.
    /// </summary>
    /// <param name="filename">Filename of the index to be loaded.</param>
    /// <param name="prefault">If true, pre-reads the entire file into memory.</param>
    public void Load(string filename, bool prefault = false)
    {
        ThrowIfDisposed();
        if (filename is null)
            throw new ArgumentNullException(nameof(filename));

        NativeMethods.HandleException(NativeMethods.features_ANNIndex_load(RawPtr, filename, prefault ? 1 : 0));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// Returns the number of trees in the index.
    /// </summary>
    public int GetTreeNumber()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.features_ANNIndex_getTreeNumber(RawPtr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Returns the number of feature vectors in the index.
    /// </summary>
    public int GetItemNumber()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.features_ANNIndex_getItemNumber(RawPtr, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// Prepares to build the index in the specified file instead of in RAM
    /// (call before adding items; no need to save after build).
    /// </summary>
    /// <param name="filename">Filename of the index to be built.</param>
    /// <returns>True on success.</returns>
    public bool SetOnDiskBuild(string filename)
    {
        ThrowIfDisposed();
        if (filename is null)
            throw new ArgumentNullException(nameof(filename));

        NativeMethods.HandleException(NativeMethods.features_ANNIndex_setOnDiskBuild(RawPtr, filename, out var ret));
        GC.KeepAlive(this);
        return ret != 0;
    }

    /// <summary>
    /// Initializes the random number generator with the given seed.
    /// Only effective before adding items / calling build() or load().
    /// </summary>
    /// <param name="seed">The seed of the random number generator.</param>
    public void SetSeed(int seed)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.features_ANNIndex_setSeed(RawPtr, seed));
        GC.KeepAlive(this);
    }
}
