using System;
using System.Collections.Generic;
using OpenCvSharp.Flann;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    // ReSharper disable once InconsistentNaming

    /// <summary>
    /// Brute-force descriptor matcher.
    /// For each descriptor in the first set, this matcher finds the closest descriptor in the second set by trying each one.
    /// </summary>
    public class FlannBasedMatcher : DescriptorMatcher
    {
        private bool disposed;
        private Ptr<FlannBasedMatcher> detectorPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indexParams"></param>
        /// <param name="searchParams"></param>
        public FlannBasedMatcher(IndexParams indexParams = null, SearchParams searchParams = null)
        {
            ptr = NativeMethods.features2d_FlannBasedMatcher_new(
                Cv2.ToPtr(indexParams), Cv2.ToPtr(searchParams));
        }

        /// <summary>
        /// Creates instance by cv::Ptr&lt;T&gt;
        /// </summary>
        internal FlannBasedMatcher(Ptr<FlannBasedMatcher> detectorPtr)
        {
            this.detectorPtr = detectorPtr;
            this.ptr = detectorPtr.Get();
        }

        /// <summary>
        /// Creates instance by raw pointer T*
        /// </summary>
        internal FlannBasedMatcher(IntPtr rawPtr)
        {
            detectorPtr = null;
            ptr = rawPtr;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal new static FlannBasedMatcher FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid cv::Ptr<FlannBasedMatcher> pointer");
            var ptrObj = new Ptr<FlannBasedMatcher>(ptr);
            return new FlannBasedMatcher(ptrObj);
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
                    if (detectorPtr != null)
                    {
                        detectorPtr.Dispose();
                        detectorPtr = null;
                    }
                    else
                    {
                        if (ptr != IntPtr.Zero)
                            NativeMethods.features2d_FlannBasedMatcher_delete(ptr);
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
        /// Return true if the matcher supports mask in match methods.
        /// </summary>
        /// <returns></returns>
        public override bool IsMaskSupported()
        {
            ThrowIfDisposed();
            return NativeMethods.features2d_FlannBasedMatcher_isMaskSupported(ptr) != 0;
        }

        /// <summary>
        /// Add descriptors to train descriptor collection.
        /// </summary>
        /// <param name="descriptors">Descriptors to add. Each descriptors[i] is a descriptors set from one image.</param>
        public override void Add(IEnumerable<Mat> descriptors)
        {
            ThrowIfDisposed();
            if (descriptors == null)
                throw new ArgumentNullException("descriptors");

            Mat[] descriptorsArray = EnumerableEx.ToArray(descriptors);
            if (descriptorsArray.Length == 0)
                return;

            IntPtr[] descriptorsPtrs = EnumerableEx.SelectPtrs(descriptorsArray);
            NativeMethods.features2d_DescriptorMatcher_add(ptr, descriptorsPtrs, descriptorsPtrs.Length);
        }

        /// <summary>
        /// Clear train descriptors collection.
        /// </summary>
        public override void Clear()
        {
            ThrowIfDisposed();
            NativeMethods.features2d_FlannBasedMatcher_clear(ptr);
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
        public override void Train()
        {
            ThrowIfDisposed();
            NativeMethods.features2d_FlannBasedMatcher_train(ptr);
        }

        #endregion
    }
}
