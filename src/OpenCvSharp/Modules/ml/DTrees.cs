using System.Diagnostics.CodeAnalysis;
using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.ML;

/// <summary>
/// Decision tree
/// </summary>
public class DTrees : StatModel
{
    #region Init and Disposal

    /// <inheritdoc />
    protected DTrees(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release) { }

    /// <summary>
    /// Creates instance by raw pointer cv::ml::SVM*
    /// </summary>
    private DTrees(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, p => NativeMethods.HandleException(NativeMethods.ml_Ptr_DTrees_delete(p)))
    { }
    /// <summary>
    /// Creates the empty model.
    /// </summary>
    /// <returns></returns>
    public static DTrees Create()
    {
        NativeMethods.HandleException(
            NativeMethods.ml_DTrees_create(out var smartPtr));
        NativeMethods.HandleException(NativeMethods.ml_Ptr_DTrees_get(smartPtr, out var rawPtr));
        return new DTrees(smartPtr, rawPtr);
    }

    /// <summary>
    /// Loads and creates a serialized model from a file.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static DTrees Load(string filePath)
    {
        if (filePath is null)
            throw new ArgumentNullException(nameof(filePath));
        NativeMethods.HandleException(
            NativeMethods.ml_DTrees_load(filePath, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.ml_Ptr_DTrees_get(smartPtr, out var rawPtr));
        return new DTrees(smartPtr, rawPtr);
    }

    /// <summary>
    /// Loads algorithm from a String.
    /// </summary>
    /// <param name="strModel">he string variable containing the model you want to load.</param>
    /// <returns></returns>
    public static DTrees LoadFromString(string strModel)
    {
        if (strModel is null)
            throw new ArgumentNullException(nameof(strModel));
        NativeMethods.HandleException(
            NativeMethods.ml_DTrees_loadFromString(strModel, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.ml_Ptr_DTrees_get(smartPtr, out var rawPtr));
        return new DTrees(smartPtr, rawPtr);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Cluster possible values of a categorical variable into 
    /// K &lt; =maxCategories clusters to find a suboptimal split.
    /// </summary>
    public int MaxCategories
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_getMaxCategories(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_setMaxCategories(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// The maximum possible depth of the tree.
    /// </summary>
    public int MaxDepth
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_getMaxDepth(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_setMaxDepth(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// If the number of samples in a node is less than this parameter then the 
    /// node will not be split. Default value is 10.
    /// </summary>
    public int MinSampleCount
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_getMinSampleCount(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_setMinSampleCount(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// If CVFolds \> 1 then algorithms prunes the built decision tree using K-fold 
    /// cross-validation procedure where K is equal to CVFolds. Default value is 10.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public int CVFolds
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_getCVFolds(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_setCVFolds(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// If true then surrogate splits will be built.
    /// These splits allow to work with missing data and compute variable 
    /// importance correctly. Default value is false.
    /// </summary>
    public bool UseSurrogates
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_getUseSurrogates(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_setUseSurrogates(CvPtr, value ? 1 : 0));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// If true then a pruning will be harsher.
    /// This will make a tree more compact and more resistant to the training 
    /// data noise but a bit less accurate. Default value is true.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public bool Use1SERule
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_getUse1SERule(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_setUse1SERule(CvPtr, value ? 1 : 0));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// If true then pruned branches are physically removed from the tree.
    /// Otherwise they are retained and it is possible to get results from the 
    /// original unpruned (or pruned less aggressively) tree. Default value is true.
    /// </summary>
    public bool TruncatePrunedTree
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_getTruncatePrunedTree(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret != 0;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_setTruncatePrunedTree(CvPtr, value ? 1 : 0));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// Termination criteria for regression trees.
    /// If all absolute differences between an estimated value in a node and 
    /// values of train samples in this node are less than this parameter 
    /// then the node will not be split further. Default value is 0.01f.
    /// </summary>
    public float RegressionAccuracy
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_getRegressionAccuracy(CvPtr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }
        set
        {
            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_setRegressionAccuracy(CvPtr, value));
            GC.KeepAlive(this);
        }
    }

    /// <summary>
    /// The array of a priori class probabilities, sorted by the class label value.
    /// </summary>
    public Mat Priors
    {
        get
        {
            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_getPriors(CvPtr, out var ret));
            GC.KeepAlive(this);
            return new Mat(ret);
        }
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            NativeMethods.HandleException(
                NativeMethods.ml_DTrees_setPriors(CvPtr, value.CvPtr));
            GC.KeepAlive(this);
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Returns indices of root nodes
    /// </summary>
    /// <returns></returns>
    public int[] GetRoots()
    {
        ThrowIfDisposed();

        using var vector = new VectorOfInt32();
        NativeMethods.HandleException(
            NativeMethods.ml_DTrees_getRoots(CvPtr, vector.CvPtr));
        GC.KeepAlive(this);
        return vector.ToArray();
    }

    /// <summary>
    /// Returns all the nodes. 
    /// all the node indices are indices in the returned vector
    /// </summary>
    public Node[] GetNodes()
    {
        ThrowIfDisposed();

        using var vector = new VectorOfDTreesNode();
        NativeMethods.HandleException(
            NativeMethods.ml_DTrees_getNodes(CvPtr, vector.CvPtr));
        GC.KeepAlive(this);
        return vector.ToArray();
    }

    /// <summary>
    /// Returns all the splits.
    /// all the split indices are indices in the returned vector
    /// </summary>
    /// <returns></returns>
    public Split[] GetSplits()
    {
        ThrowIfDisposed();

        using var vector = new VectorOfDTreesSplit();
        NativeMethods.HandleException(
            NativeMethods.ml_DTrees_getSplits(CvPtr, vector.CvPtr));
        GC.KeepAlive(this);
        return vector.ToArray();
    }

    /// <summary>
    /// Returns all the bitsets for categorical splits.
    /// Split::subsetOfs is an offset in the returned vector
    /// </summary>
    /// <returns></returns>
    public int[] GetSubsets()
    {
        ThrowIfDisposed();

        using var vector = new VectorOfInt32();
        NativeMethods.HandleException(
            NativeMethods.ml_DTrees_getSubsets(CvPtr, vector.CvPtr));
        GC.KeepAlive(this);
        return vector.ToArray();
    }

    #endregion

    #region Types

#pragma warning disable CA1034
#pragma warning disable CA1051
    /// <summary>
    /// The class represents a decision tree node.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1815: Override equals and operator equals on value types")]
    public struct Node
    {
        /// <summary>
        /// Value at the node: a class label in case of classification or estimated 
        /// function value in case of regression.
        /// </summary>
        public double Value;

        /// <summary>
        /// Class index normalized to 0..class_count-1 range and assigned to the 
        /// node. It is used internally in classification trees and tree ensembles.
        /// </summary>
        public int ClassIdx;

        /// <summary>
        /// Index of the parent node
        /// </summary>
        public int Parent;

        /// <summary>
        /// Index of the left child node
        /// </summary>
        public int Left;

        /// <summary>
        /// Index of right child node
        /// </summary>
        public int Right;

        /// <summary>
        /// Default direction where to go (-1: left or +1: right). It helps in the
        /// case of missing values.
        /// </summary>
        public int DefaultDir;

        /// <summary>
        /// Index of the first split
        /// </summary>
        public int Split;
    }

#pragma warning disable CA1034
    /// <summary>
    /// The class represents split in a decision tree.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1815: Override equals and operator equals on value types")]
    public struct Split
    {
        /// <summary>
        /// Index of variable on which the split is created.
        /// </summary>
        public int VarIdx;

        /// <summary>
        /// If not 0, then the inverse split rule is used (i.e. left and right
        /// branches are exchanged in the rule expressions below).
        /// </summary>
        public int Inversed;

        /// <summary>
        /// The split quality, a positive number. It is used to choose the best split.
        /// </summary>
        public float Quality;

        /// <summary>
        /// Index of the next split in the list of splits for the node
        /// </summary>
        public int Next;

        /// <summary>
        /// The threshold value in case of split on an ordered variable.
        /// </summary>
        public float C;

        /// <summary>
        /// Offset of the bitset used by the split on a categorical variable.
        /// </summary>
        public int SubsetOfs;
    }
#pragma warning restore CA1051

    #endregion
}
