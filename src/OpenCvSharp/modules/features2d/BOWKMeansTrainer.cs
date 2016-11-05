using System;

namespace OpenCvSharp
{
    // ReSharper disable once InconsistentNaming

    /// <summary>
    /// Brute-force descriptor matcher.
    /// For each descriptor in the first set, this matcher finds the closest descriptor in the second set by trying each one.
    /// </summary>
    public class BOWKMeansTrainer : BOWTrainer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clusterCount"></param>
        /// <param name="termcrit"></param>
        /// <param name="attempts"></param>
        /// <param name="flags"></param>
        public BOWKMeansTrainer(int clusterCount, TermCriteria? termcrit = null,
            int attempts = 3, KMeansFlags flags = KMeansFlags.PpCenters)
        {
            var termCritValue = termcrit.GetValueOrDefault(new TermCriteria());
            ptr = NativeMethods.features2d_BOWKMeansTrainer_new(clusterCount, termCritValue, attempts, (int)flags);
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
            if (!IsDisposed)
            {
                try
                {
                    // releases managed resources
                    if (disposing)
                    {
                    }
                    else
                    {
                        if (ptr != IntPtr.Zero)
                            NativeMethods.features2d_BOWKMeansTrainer_delete(ptr);
                        ptr = IntPtr.Zero;
                    }
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        /// <summary>
        /// Clusters train descriptors.
        /// </summary>
        /// <returns></returns>
        public override Mat Cluster()
        {
            if (IsDisposed)
                throw new ObjectDisposedException(GetType().Name);
            IntPtr p = NativeMethods.features2d_BOWKMeansTrainer_cluster1(ptr);
            return new Mat(p);
        }

        /// <summary>
        /// Clusters train descriptors.
        /// </summary>
        /// <param name="descriptors">Descriptors to cluster. Each row of the descriptors matrix is a descriptor. Descriptors are not added to the inner train descriptor set.
        /// The vocabulary consists of cluster centers. So, this method returns the vocabulary. In the first variant of the method, train descriptors stored in the object 
        /// are clustered.In the second variant, input descriptors are clustered.</param>
        /// <returns></returns>
        public override Mat Cluster(Mat descriptors)
        {
            if (IsDisposed)
                throw new ObjectDisposedException(GetType().Name);
            descriptors.ThrowIfDisposed();
            IntPtr p = NativeMethods.features2d_BOWKMeansTrainer_cluster2(ptr, descriptors.CvPtr);
            GC.KeepAlive(descriptors);
            return new Mat(p);
        }
    }
}
