using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    public class DescriptorMatcher : Algorithm
    {
        private bool disposed;
        /// <summary>
        /// 
        /// </summary>
        protected IntPtr detectorPtr;

        #region Init & Disposal
        /// <summary>
        /// 
        /// </summary>
        protected DescriptorMatcher()
        {
            detectorPtr = IntPtr.Zero;
            ptr = IntPtr.Zero;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        protected DescriptorMatcher(IntPtr p)
        {
            detectorPtr = p;
            ptr = CppInvoke.core_Ptr_DescriptorMatcher_obj(p);
            if(ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid DescriptorMatcher pointer");
        }

        /// <summary>
        /// Create descriptor matcher by type name.
        /// </summary>
        /// <param name="descriptorMatcherType"></param>
        /// <returns></returns>
        public static DescriptorMatcher Create(string descriptorMatcherType)
        {
            if (String.IsNullOrEmpty(descriptorMatcherType))
                throw new ArgumentNullException("descriptorMatcherType");
            IntPtr ptr = CppInvoke.features2d_FeatureDetector_create(descriptorMatcherType);
            try
            {
                DescriptorMatcher detector = new DescriptorMatcher(ptr);
                return detector;
            }
            catch (OpenCvSharpException)
            {
                throw new OpenCvSharpException("matcher name '{0}' is not valid.", descriptorMatcherType);
            }
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
        /// Releases the resources
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
                    // releases managed resources
                    if (disposing)
                    {
                    }
                    // releases unmanaged resources
                    if (IsEnabledDispose)
                    {
                        if (detectorPtr != IntPtr.Zero)
                            CppInvoke.core_Ptr_FeatureDetector_delete(detectorPtr);
                        detectorPtr = IntPtr.Zero;
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add descriptors to train descriptor collection.
        /// </summary>
        /// <param name="descriptors">Descriptors to add. Each descriptors[i] is a descriptors set from one image.</param>
        public virtual void Add(IEnumerable<Mat> descriptors)
        {
            ThrowIfDisposed();
            if (descriptors == null)
                throw new ArgumentNullException("descriptors");

            IntPtr[] descriptorsPtrs = EnumerableEx.SelectPtrs(descriptors);
            CppInvoke.features2d_DescriptorMatcher_add(ptr, descriptorsPtrs, descriptorsPtrs.Length);
        }

        /// <summary>
        /// Get train descriptors collection.
        /// </summary>
        /// <returns></returns>
        public Mat[] GetTrainDescriptors()
        {
            ThrowIfDisposed();
            using (VectorOfMat matVec = new VectorOfMat())
            {
                CppInvoke.features2d_DescriptorMatcher_getTrainDescriptors(ptr, matVec.CvPtr);
                return matVec.ToArray();
            }
        }

        /// <summary>
        /// Clear train descriptors collection.
        /// </summary>
        public virtual void Clear()
        {
            ThrowIfDisposed();
            CppInvoke.features2d_DescriptorMatcher_clear(ptr);
        }

        /// <summary>
        /// Return true if there are not train descriptors in collection.
        /// </summary>
        /// <returns></returns>
        public virtual bool Empty()
        {
            ThrowIfDisposed();
            return CppInvoke.features2d_DescriptorMatcher_empty(ptr) != 0;
        }

        /// <summary>
        /// Return true if the matcher supports mask in match methods.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsMaskSupported()
        {
            ThrowIfDisposed();
            return CppInvoke.features2d_DescriptorMatcher_isMaskSupported(ptr) != 0;
        }

        /// <summary>
        /// Train matcher (e.g. train flann index).
        /// In all methods to match the method train() is run every time before matching.
        /// Some descriptor matchers (e.g. BruteForceMatcher) have empty implementation
        /// of this method, other matchers really train their inner structures
        /// (e.g. FlannBasedMatcher trains flann::Index). So nonempty implementation
        /// of train() should check the class object state and do traing/retraining
        /// only if the state requires that (e.g. FlannBasedMatcher trains flann::Index
        /// if it has not trained yet or if new descriptors have been added to the train collection).
        /// </summary>
        public virtual void Train()
        {
            ThrowIfDisposed();
            CppInvoke.features2d_DescriptorMatcher_train(ptr);
        }

        /// <summary>
        /// Find one best match for each query descriptor (if mask is empty).
        /// </summary>
        /// <param name="queryDescriptors"></param>
        /// <param name="trainDescriptors"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public DMatch[] Match(Mat queryDescriptors, Mat trainDescriptors, Mat mask = null)
        {
            ThrowIfDisposed();
            if (queryDescriptors == null)
                throw new ArgumentNullException("queryDescriptors");
            if (trainDescriptors == null)
                throw new ArgumentNullException("trainDescriptors");
            using (VectorOfDMatch matchesVec = new VectorOfDMatch())
            {
                CppInvoke.features2d_DescriptorMatcher_match(
                    ptr, queryDescriptors.CvPtr, trainDescriptors.CvPtr,
                    matchesVec.CvPtr, Cv2.ToPtr(mask));
                return matchesVec.ToArray();
            }
        }

        /// <summary>
        /// Find k best matches for each query descriptor (in increasing order of distances).
        /// compactResult is used when mask is not empty. If compactResult is false matches
        /// vector will have the same size as queryDescriptors rows. If compactResult is true
        /// matches vector will not contain matches for fully masked out query descriptors.
        /// </summary>
        /// <param name="queryDescriptors"></param>
        /// <param name="trainDescriptors"></param>
        /// <param name="k"></param>
        /// <param name="mask"></param>
        /// <param name="compactResult"></param>
        /// <returns></returns>
        public DMatch[][] KnnMatch(Mat queryDescriptors, Mat trainDescriptors,
            int k, Mat mask = null, bool compactResult = false)
        {
            ThrowIfDisposed();
            if (queryDescriptors == null)
                throw new ArgumentNullException("queryDescriptors");
            if (trainDescriptors == null)
                throw new ArgumentNullException("trainDescriptors");
            using (VectorOfVectorDMatch matchesVec = new VectorOfVectorDMatch())
            {
                CppInvoke.features2d_DescriptorMatcher_knnMatch(
                    ptr, queryDescriptors.CvPtr, trainDescriptors.CvPtr,
                    matchesVec.CvPtr, k, Cv2.ToPtr(mask), compactResult ? 1 : 0);
                return matchesVec.ToArray();
            }
        }

        /// <summary>
        /// Find best matches for each query descriptor which have distance less than
        /// maxDistance (in increasing order of distances).
        /// </summary>
        /// <param name="queryDescriptors"></param>
        /// <param name="trainDescriptors"></param>
        /// <param name="maxDistance"></param>
        /// <param name="mask"></param>
        /// <param name="compactResult"></param>
        /// <returns></returns>
        public DMatch[][] RadiusMatch(Mat queryDescriptors, Mat trainDescriptors,
            float maxDistance, Mat mask = null, bool compactResult = false)
        {
            ThrowIfDisposed();
            if (queryDescriptors == null)
                throw new ArgumentNullException("queryDescriptors");
            if (trainDescriptors == null)
                throw new ArgumentNullException("trainDescriptors");
            using (VectorOfVectorDMatch matchesVec = new VectorOfVectorDMatch())
            {
                CppInvoke.features2d_DescriptorMatcher_radiusMatch(
                    ptr, queryDescriptors.CvPtr, trainDescriptors.CvPtr,
                    matchesVec.CvPtr, maxDistance, Cv2.ToPtr(mask), compactResult ? 1 : 0);
                return matchesVec.ToArray();
            }
        }
        #endregion
    }
}
