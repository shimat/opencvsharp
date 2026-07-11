using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.XFeatures2D;

/// <summary>
/// Class implementing PCT (position-color-texture) signature extraction, as described in
/// KrulisLS16. The algorithm is divided into a feature sampler and a clusterizer. The feature
/// sampler produces samples at a given set of coordinates, and the clusterizer produces clusters
/// of these samples using the k-means algorithm; the resulting set of clusters is the signature
/// of the input image.
/// </summary>
public class PCTSignatures : Algorithm
{
    /// <summary>
    ///
    /// </summary>
    private PCTSignatures(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_PCTSignatures_delete(p)))
    { }

    /// <summary>
    /// Creates PCTSignatures algorithm using sample and seed count. It generates its own sets of
    /// sampling points and clusterization seed indexes.
    /// </summary>
    /// <param name="initSampleCount">Number of points used for image sampling.</param>
    /// <param name="initSeedCount">Number of initial clusterization seeds. Must be lower or equal
    /// to initSampleCount.</param>
    /// <param name="pointDistribution">Distribution of generated points.</param>
    public static PCTSignatures Create(
        int initSampleCount = 2000, int initSeedCount = 400,
        PCTSignaturesPointDistribution pointDistribution = PCTSignaturesPointDistribution.Uniform)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_PCTSignatures_create1(initSampleCount, initSeedCount, (int)pointDistribution, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_PCTSignatures_get(ptr, out var rawPtr));
        return new PCTSignatures(ptr, rawPtr);
    }

    /// <summary>
    /// Creates PCTSignatures algorithm using pre-generated sampling points and number of
    /// clusterization seeds. It uses the provided sampling points and generates its own
    /// clusterization seed indexes.
    /// </summary>
    /// <param name="initSamplingPoints">Sampling points used in image sampling.</param>
    /// <param name="initSeedCount">Number of initial clusterization seeds. Must be lower or equal
    /// to initSamplingPoints.Length.</param>
    public static PCTSignatures Create(IEnumerable<Point2f> initSamplingPoints, int initSeedCount)
    {
        ArgumentNullException.ThrowIfNull(initSamplingPoints);
        var pointsArray = initSamplingPoints.ToArray();

        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_PCTSignatures_create2(pointsArray, pointsArray.Length, initSeedCount, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_PCTSignatures_get(ptr, out var rawPtr));
        return new PCTSignatures(ptr, rawPtr);
    }

    /// <summary>
    /// Creates PCTSignatures algorithm using pre-generated sampling points and clusterization
    /// seed indexes.
    /// </summary>
    /// <param name="initSamplingPoints">Sampling points used in image sampling.</param>
    /// <param name="initClusterSeedIndexes">Indexes of initial clusterization seeds. Its size
    /// must be lower or equal to initSamplingPoints.Length.</param>
    public static PCTSignatures Create(IEnumerable<Point2f> initSamplingPoints, IEnumerable<int> initClusterSeedIndexes)
    {
        ArgumentNullException.ThrowIfNull(initSamplingPoints);
        ArgumentNullException.ThrowIfNull(initClusterSeedIndexes);
        var pointsArray = initSamplingPoints.ToArray();
        var seedsArray = initClusterSeedIndexes.ToArray();

        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_PCTSignatures_create3(
                pointsArray, pointsArray.Length, seedsArray, seedsArray.Length, out var ptr));
        NativeMethods.HandleException(NativeMethods.xfeatures2d_Ptr_PCTSignatures_get(ptr, out var rawPtr));
        return new PCTSignatures(ptr, rawPtr);
    }

    /// <summary>
    /// Computes signature of a given image.
    /// </summary>
    /// <param name="image">Input image of CV_8U type.</param>
    /// <param name="signature">Output computed signature.</param>
    public void ComputeSignature(InputArray image, OutputArray signature)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_PCTSignatures_computeSignature(Handle, image.Proxy, signature.Proxy));
        GC.KeepAlive(image.Source);
        GC.KeepAlive(signature.Source);
    }

    /// <summary>
    /// Computes signatures for multiple images in parallel.
    /// </summary>
    /// <param name="images">Vector of input images of CV_8U type.</param>
    /// <returns>Vector of computed signatures.</returns>
    public Mat[] ComputeSignatures(IEnumerable<Mat> images)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(images);

        var imagesArray = images.ToArray();
        var imagesPtrs = imagesArray.Select(m => m.CvPtr).ToArray();
        using var signaturesVec = new VectorOfMat();
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_PCTSignatures_computeSignatures(Handle, imagesPtrs, imagesPtrs.Length, signaturesVec.CvPtr));
        GC.KeepAlive(imagesArray);
        return signaturesVec.ToArray();
    }

    /// <summary>
    /// Draws signature in the source image and outputs the result. Signatures are visualized as a
    /// circle with radius based on signature weight and color based on signature color. Contrast
    /// and entropy are not visualized.
    /// </summary>
    /// <param name="source">Source image.</param>
    /// <param name="signature">Image signature.</param>
    /// <param name="result">Output result.</param>
    /// <param name="radiusToShorterSideRatio">Determines maximal radius of signature in the
    /// output image.</param>
    /// <param name="borderThickness">Border thickness of the visualized signature.</param>
    public static void DrawSignature(
        InputArray source, InputArray signature, OutputArray result,
        float radiusToShorterSideRatio = 1.0f / 8, int borderThickness = 1)
    {
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_PCTSignatures_drawSignature(
                source.Proxy, signature.Proxy, result.Proxy, radiusToShorterSideRatio, borderThickness));
        GC.KeepAlive(source.Source);
        GC.KeepAlive(signature.Source);
        GC.KeepAlive(result.Source);
    }

    /// <summary>
    /// Generates initial sampling points according to the selected point distribution.
    /// </summary>
    /// <param name="count">Number of points to generate.</param>
    /// <param name="pointDistribution">Point distribution selector.</param>
    /// <returns>The generated points, with coordinates in range [0..1).</returns>
    public static Point2f[] GenerateInitPoints(int count, PCTSignaturesPointDistribution pointDistribution)
    {
        using var initPoints = new StdVector<Point2f>();
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_PCTSignatures_generateInitPoints(initPoints.CvPtr, count, (int)pointDistribution));
        return initPoints.ToArray();
    }

    #region Sampler properties

    /// <summary>
    /// Number of initial samples taken from the image.
    /// </summary>
    /// <remarks>
    /// OpenCV's native implementation of this getter is a known copy-paste bug: it returns the
    /// same value as <see cref="GrayscaleBits"/> instead of the actual sample count passed to
    /// Create().
    /// </remarks>
    public int SampleCount
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getSampleCount(Handle, out var ret));
            return ret;
        }
    }

    /// <summary>
    /// Color resolution of the greyscale bitmap represented in allocated bits (i.e., value 4
    /// means that 16 shades of grey are used). The greyscale bitmap is used for computing
    /// contrast and entropy values.
    /// </summary>
    public int GrayscaleBits
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getGrayscaleBits(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setGrayscaleBits(Handle, value));
        }
    }

    /// <summary>
    /// Size of the texture sampling window used to compute contrast and entropy (center of the
    /// window is always in the pixel selected by x,y coordinates of the corresponding feature
    /// sample).
    /// </summary>
    public int WindowRadius
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getWindowRadius(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setWindowRadius(Handle, value));
        }
    }

    /// <summary>
    /// Weight (multiplicative constant) that linearly stretches the x-axis of the feature space.
    /// </summary>
    public float WeightX
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getWeightX(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setWeightX(Handle, value));
        }
    }

    /// <summary>
    /// Weight (multiplicative constant) that linearly stretches the y-axis of the feature space.
    /// </summary>
    public float WeightY
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getWeightY(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setWeightY(Handle, value));
        }
    }

    /// <summary>
    /// Weight (multiplicative constant) that linearly stretches the L (lightness) axis of the
    /// feature space.
    /// </summary>
    public float WeightL
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getWeightL(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setWeightL(Handle, value));
        }
    }

    /// <summary>
    /// Weight (multiplicative constant) that linearly stretches the a (CIE Lab) axis of the
    /// feature space.
    /// </summary>
    public float WeightA
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getWeightA(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setWeightA(Handle, value));
        }
    }

    /// <summary>
    /// Weight (multiplicative constant) that linearly stretches the b (CIE Lab) axis of the
    /// feature space.
    /// </summary>
    public float WeightB
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getWeightB(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setWeightB(Handle, value));
        }
    }

    /// <summary>
    /// Weight (multiplicative constant) that linearly stretches the contrast axis of the feature
    /// space.
    /// </summary>
    public float WeightContrast
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getWeightContrast(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setWeightContrast(Handle, value));
        }
    }

    /// <summary>
    /// Weight (multiplicative constant) that linearly stretches the entropy axis of the feature
    /// space.
    /// </summary>
    public float WeightEntropy
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getWeightEntropy(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setWeightEntropy(Handle, value));
        }
    }

    /// <summary>
    /// Initial samples taken from the image. These sampled features become the input for
    /// clustering.
    /// </summary>
    /// <returns></returns>
    public Point2f[] GetSamplingPoints()
    {
        ThrowIfDisposed();
        using var points = new StdVector<Point2f>();
        NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getSamplingPoints(Handle, points.CvPtr));
        return points.ToArray();
    }

    /// <summary>
    /// Weights (multiplicative constants) that linearly stretch individual axes of the feature
    /// space.
    /// </summary>
    /// <param name="idx">ID of the weight (0=weight, 1=x, 2=y, 3=L, 4=a, 5=b, 6=contrast, 7=entropy).</param>
    /// <param name="value">Value of the weight.</param>
    public void SetWeight(int idx, float value)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setWeight(Handle, idx, value));
    }

    /// <summary>
    /// Weights (multiplicative constants) that linearly stretch individual axes of the feature
    /// space.
    /// </summary>
    /// <param name="weights">Values of all weights (0=weight, 1=x, 2=y, 3=L, 4=a, 5=b, 6=contrast, 7=entropy).</param>
    public void SetWeights(IEnumerable<float> weights)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(weights);
        var weightsArray = weights.ToArray();
        NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setWeights(Handle, weightsArray, weightsArray.Length));
    }

    /// <summary>
    /// Translations of the individual axes of the feature space.
    /// </summary>
    /// <param name="idx">ID of the translation (0=weight, 1=x, 2=y, 3=L, 4=a, 5=b, 6=contrast, 7=entropy).</param>
    /// <param name="value">Value of the translation.</param>
    public void SetTranslation(int idx, float value)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setTranslation(Handle, idx, value));
    }

    /// <summary>
    /// Translations of the individual axes of the feature space.
    /// </summary>
    /// <param name="translations">Values of all translations (0=weight, 1=x, 2=y, 3=L, 4=a, 5=b, 6=contrast, 7=entropy).</param>
    public void SetTranslations(IEnumerable<float> translations)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(translations);
        var translationsArray = translations.ToArray();
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_PCTSignatures_setTranslations(Handle, translationsArray, translationsArray.Length));
    }

    /// <summary>
    /// Sets sampling points used to sample the input image.
    /// </summary>
    /// <param name="samplingPoints">Vector of sampling points in range [0..1). Their count must
    /// be greater or equal to the clusterization seed count.</param>
    public void SetSamplingPoints(IEnumerable<Point2f> samplingPoints)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(samplingPoints);
        var pointsArray = samplingPoints.ToArray();
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_PCTSignatures_setSamplingPoints(Handle, pointsArray, pointsArray.Length));
    }

    #endregion

    #region Clusterizer properties

    /// <summary>
    /// Initial seeds (initial number of clusters) for the k-means algorithm.
    /// </summary>
    /// <returns></returns>
    public int[] GetInitSeedIndexes()
    {
        ThrowIfDisposed();
        using var indexes = new StdVector<int>();
        NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getInitSeedIndexes(Handle, indexes.CvPtr));
        return indexes.ToArray();
    }

    /// <summary>
    /// Initial seed indexes for the k-means algorithm.
    /// </summary>
    /// <param name="initSeedIndexes"></param>
    public void SetInitSeedIndexes(IEnumerable<int> initSeedIndexes)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(initSeedIndexes);
        var indexesArray = initSeedIndexes.ToArray();
        NativeMethods.HandleException(
            NativeMethods.xfeatures2d_PCTSignatures_setInitSeedIndexes(Handle, indexesArray, indexesArray.Length));
    }

    /// <summary>
    /// Number of initial seeds (initial number of clusters) for the k-means algorithm.
    /// </summary>
    public int InitSeedCount
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getInitSeedCount(Handle, out var ret));
            return ret;
        }
    }

    /// <summary>
    /// Number of iterations of the k-means clustering. We use a fixed number of iterations,
    /// since the modified clustering is pruning clusters (not iteratively refining k clusters).
    /// </summary>
    public int IterationCount
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getIterationCount(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setIterationCount(Handle, value));
        }
    }

    /// <summary>
    /// Maximal number of generated clusters. If the number is exceeded, the clusters are sorted
    /// by their weights and the smallest clusters are cropped.
    /// </summary>
    public int MaxClustersCount
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getMaxClustersCount(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setMaxClustersCount(Handle, value));
        }
    }

    /// <summary>
    /// This parameter, multiplied by the index of iteration, gives the lower limit for cluster
    /// size. Clusters containing fewer points than specified by the limit have their centroid
    /// dismissed and points are reassigned.
    /// </summary>
    public int ClusterMinSize
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getClusterMinSize(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setClusterMinSize(Handle, value));
        }
    }

    /// <summary>
    /// Threshold euclidean distance between two centroids. If two cluster centers are closer
    /// than this distance, one of the centroids is dismissed and points are reassigned.
    /// </summary>
    public float JoiningDistance
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getJoiningDistance(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setJoiningDistance(Handle, value));
        }
    }

    /// <summary>
    /// Remove centroids in k-means whose weight is lesser or equal to the given threshold.
    /// </summary>
    public float DropThreshold
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getDropThreshold(Handle, out var ret));
            return ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setDropThreshold(Handle, value));
        }
    }

    /// <summary>
    /// Distance function selector used for measuring distance between two points in k-means.
    /// </summary>
    public PCTSignaturesDistanceFunction DistanceFunction
    {
        get
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_getDistanceFunction(Handle, out var ret));
            return (PCTSignaturesDistanceFunction)ret;
        }
        set
        {
            ThrowIfDisposed();
            NativeMethods.HandleException(NativeMethods.xfeatures2d_PCTSignatures_setDistanceFunction(Handle, (int)value));
        }
    }

    #endregion
}
