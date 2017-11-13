using System;

namespace OpenCvSharp
{
    // ReSharper disable once InconsistentNaming

    /// <summary>
    /// Brute-force descriptor matcher.
    /// For each descriptor in the first set, this matcher finds the closest descriptor in the second set by trying each one.
    /// </summary>
    public abstract class BOWTrainer : DisposableCvObject
    {
        /// <summary>
        /// Adds descriptors to a training set.
        /// </summary>
        /// <param name="descriptors">descriptors Descriptors to add to a training set. Each row of the descriptors matrix is a descriptor.
        /// The training set is clustered using clustermethod to construct the vocabulary.</param>
        public void Add(Mat descriptors)
        {
            if (descriptors == null)
                throw new ArgumentNullException(nameof(descriptors));
            NativeMethods.features2d_BOWTrainer_add(ptr, descriptors.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(descriptors);
        }

        /// <summary>
        /// Returns a training set of descriptors.
        /// </summary>
        /// <returns></returns>
        public Mat[] GetDescriptors()
        {
            using (var descriptors = new VectorOfMat())
            {
                NativeMethods.features2d_BOWTrainer_getDescriptors(ptr, descriptors.CvPtr);
                GC.KeepAlive(this);
                return descriptors.ToArray();
            }
        }

        /// <summary>
        /// Returns the count of all descriptors stored in the training set.
        /// </summary>
        /// <returns></returns>
        public int DescriptorsCount()
        {
            var res = NativeMethods.features2d_BOWTrainer_descriptorsCount(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Clear()
        {
            NativeMethods.features2d_BOWTrainer_clear(ptr);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Clusters train descriptors.
        /// </summary>
        /// <returns></returns>
        public abstract Mat Cluster();

        /// <summary>
        /// Clusters train descriptors.
        /// </summary>
        /// <param name="descriptors">Descriptors to cluster. Each row of the descriptors matrix is a descriptor. Descriptors are not added to the inner train descriptor set.
        /// The vocabulary consists of cluster centers. So, this method returns the vocabulary. In the first variant of the method, train descriptors stored in the object 
        /// are clustered.In the second variant, input descriptors are clustered.</param>
        /// <returns></returns>
        public abstract Mat Cluster(Mat descriptors);
    }
}
