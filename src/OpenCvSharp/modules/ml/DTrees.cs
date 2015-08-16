using System;

namespace OpenCvSharp.ML
{
#if LANG_JP
    /// <summary>
    /// 決定木クラス
    /// </summary>
#else
    /// <summary>
    /// Decision tree
    /// </summary>
#endif
    public class DTrees : StatModel
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        private Ptr<DTrees> ptrObj;

        #region Init and Disposal

        /// <summary>
        /// 
        /// </summary>
        protected DTrees()
        {
            ptrObj = null;
        }

        /// <summary>
        /// Creates instance by raw pointer cv::ml::SVM*
        /// </summary>
        protected DTrees(IntPtr p)
        {
            ptrObj = new Ptr<DTrees>(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Creates the empty model.
        /// </summary>
        /// <returns></returns>
        public static DTrees Create()
        {
            IntPtr ptr = NativeMethods.ml_DTrees_create();
            return new DTrees(ptr);
        }

#if LANG_JP
    /// <summary>
    /// リソースの解放
    /// </summary>
    /// <param name="disposing">
    /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
    /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
    ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                        if (ptrObj != null)
                        {
                            ptrObj.Dispose();
                            ptrObj = null;
                        }
                    }
                    ptr = IntPtr.Zero;
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Cluster possible values of a categorical variable into 
        /// K &lt; =maxCategories clusters to find a suboptimal split.
        /// </summary>
        public int MaxCategories
        {
            get { return NativeMethods.ml_DTrees_getMaxCategories(ptr); }
            set { NativeMethods.ml_DTrees_setMaxCategories(ptr, value); }
        }

        /// <summary>
        /// The maximum possible depth of the tree.
        /// </summary>
        public int MaxDepth
        {
            get { return NativeMethods.ml_DTrees_getMaxDepth(ptr); }
            set { NativeMethods.ml_DTrees_setMaxDepth(ptr, value); }
        }

        /// <summary>
        /// If the number of samples in a node is less than this parameter then the 
        /// node will not be split. Default value is 10.
        /// </summary>
        public int MinSampleCount
        {
            get { return NativeMethods.ml_DTrees_getMinSampleCount(ptr); }
            set { NativeMethods.ml_DTrees_setMinSampleCount(ptr, value); }
        }

        /// <summary>
        /// If CVFolds \> 1 then algorithms prunes the built decision tree using K-fold 
        /// cross-validation procedure where K is equal to CVFolds. Default value is 10.
        /// </summary>
// ReSharper disable once InconsistentNaming
        public int CVFolds
        {
            get { return NativeMethods.ml_DTrees_getCVFolds(ptr); }
            set { NativeMethods.ml_DTrees_setCVFolds(ptr, value); }
        }

        /// <summary>
        /// If true then surrogate splits will be built.
        /// These splits allow to work with missing data and compute variable 
        /// importance correctly. Default value is false.
        /// </summary>
        public bool UseSurrogates
        {
            get { return NativeMethods.ml_DTrees_getUseSurrogates(ptr) != 0; }
            set { NativeMethods.ml_DTrees_setUseSurrogates(ptr, value ? 1 : 0); }
        }

        /// <summary>
        /// If true then a pruning will be harsher.
        /// This will make a tree more compact and more resistant to the training 
        /// data noise but a bit less accurate. Default value is true.
        /// </summary>
// ReSharper disable once InconsistentNaming
        public bool Use1SERule
        {
            get { return NativeMethods.ml_DTrees_getUse1SERule(ptr) != 0; }
            set { NativeMethods.ml_DTrees_setUse1SERule(ptr, value ? 1 : 0); }
        }

        /// <summary>
        /// If true then pruned branches are physically removed from the tree.
        /// Otherwise they are retained and it is possible to get results from the 
        /// original unpruned (or pruned less aggressively) tree. Default value is true.
        /// </summary>
        public bool TruncatePrunedTree
        {
            get { return NativeMethods.ml_DTrees_getTruncatePrunedTree(ptr) != 0; }
            set { NativeMethods.ml_DTrees_setTruncatePrunedTree(ptr, value ? 1 : 0); }
        }

        /// <summary>
        /// Termination criteria for regression trees.
        /// If all absolute differences between an estimated value in a node and 
        /// values of train samples in this node are less than this parameter 
        /// then the node will not be split further. Default value is 0.01f.
        /// </summary>
        public float RegressionAccuracy
        {
            get { return NativeMethods.ml_DTrees_getRegressionAccuracy(ptr); }
            set { NativeMethods.ml_DTrees_setRegressionAccuracy(ptr, value); }
        }

        /// <summary>
        /// The array of a priori class probabilities, sorted by the class label value.
        /// </summary>
        public Mat Priors
        {
            get
            {
                IntPtr p = NativeMethods.ml_DTrees_getPriors(ptr);
                return new Mat(p);
            }
            set { NativeMethods.ml_DTrees_setPriors(ptr, value.CvPtr); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns indices of root nodes
        /// </summary>
        /// <returns></returns>
        public int[] GetRoots()
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);

            using (var vector = new VectorOfInt32())
            {
                NativeMethods.ml_DTrees_getRoots(ptr, vector.CvPtr);
                return vector.ToArray();
            }
        }

        /// <summary>
        /// Returns all the nodes. 
        /// all the node indices are indices in the returned vector
        /// </summary>
        public Node[] GetNodes()
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);

            using (var vector = new VectorOfDTreesNode())
            {
                NativeMethods.ml_DTrees_getNodes(ptr, vector.CvPtr);
                return vector.ToArray();
            }
        }

        /// <summary>
        /// Returns all the splits.
        /// all the split indices are indices in the returned vector
        /// </summary>
        /// <returns></returns>
        public Split[] GetSplits()
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);

            using (var vector = new VectorOfDTreesSplit())
            {
                NativeMethods.ml_DTrees_getSplits(ptr, vector.CvPtr);
                return vector.ToArray();
            }
        }

        /// <summary>
        /// Returns all the bitsets for categorical splits.
        /// Split::subsetOfs is an offset in the returned vector
        /// </summary>
        /// <returns></returns>
        public int[] GetSubsets()
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            
            using (var vector = new VectorOfInt32())
            {
                NativeMethods.ml_DTrees_getSubsets(ptr, vector.CvPtr);
                return vector.ToArray();
            }
        }

        #endregion

        #region Types

        /// <summary>
        /// The class represents a decision tree node.
        /// </summary>
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

        /// <summary>
        /// The class represents split in a decision tree.
        /// </summary>
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

        #endregion
    }
}
