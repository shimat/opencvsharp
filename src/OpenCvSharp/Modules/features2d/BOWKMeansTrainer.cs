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

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.features2d_BOWKMeansTrainer_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// Clusters train descriptors.
        /// </summary>
        /// <returns></returns>
        public override Mat Cluster()
        {
            ThrowIfDisposed();
            IntPtr p = NativeMethods.features2d_BOWKMeansTrainer_cluster1(ptr);
            GC.KeepAlive(this);
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
            ThrowIfDisposed();
            descriptors.ThrowIfDisposed();
            IntPtr p = NativeMethods.features2d_BOWKMeansTrainer_cluster2(ptr, descriptors.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(descriptors);
            return new Mat(p);
        }
    }
}
