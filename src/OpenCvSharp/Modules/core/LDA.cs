using System;

namespace OpenCvSharp
{
    /// <inheritdoc />
    /// <summary>
    /// Linear Discriminant Analysis
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class LDA : DisposableCvObject
    {
        #region Init & Disposal

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="numComponents"></param>
        // ReSharper disable once InheritdocConsiderUsage
        public LDA(int numComponents = 0)
        {
            ptr = NativeMethods.core_LDA_new1(numComponents);
        }

        /// <summary>
        /// Initializes and performs a Discriminant Analysis with Fisher's 
        /// Optimization Criterion on given data in src and corresponding labels 
        /// in labels.If 0 (or less) number of components are given, they are 
        /// automatically determined for given data in computation.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="labels"></param>
        /// <param name="numComponents"></param>
        // ReSharper disable once InheritdocConsiderUsage
        public LDA(InputArray src, InputArray labels, int numComponents = 0)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (labels == null)
                throw new ArgumentNullException(nameof(labels));
            src.ThrowIfDisposed();
            labels.ThrowIfDisposed();
            ptr = NativeMethods.core_LDA_new2(src.CvPtr, labels.CvPtr, numComponents);
            GC.KeepAlive(src);
            GC.KeepAlive(labels);
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.core_LDA_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// Returns the eigenvectors of this LDA.
        /// </summary>
        public Mat Eigenvectors()
        {
            ThrowIfDisposed();
            IntPtr ret = NativeMethods.core_LDA_eigenvectors(ptr);
            GC.KeepAlive(this);
            return new Mat(ret);
        }

        /// <summary>
        /// Returns the eigenvalues of this LDA.
        /// </summary>
        public Mat Eigenvalues()
        {
            ThrowIfDisposed();
            IntPtr ret = NativeMethods.core_LDA_eigenvalues(ptr);
            GC.KeepAlive(this);
            return new Mat(ret);
        }

        /// <summary>
        /// Serializes this object to a given filename.
        /// </summary>
        /// <param name="fileName"></param>
        public void Save(string fileName)
        {
            ThrowIfDisposed();
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            NativeMethods.core_LDA_save_String(ptr, fileName);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Deserializes this object from a given filename.
        /// </summary>
        /// <param name="fileName"></param>
        public void Load(string fileName)
        {
            ThrowIfDisposed();
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            NativeMethods.core_LDA_load_String(ptr, fileName);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Serializes this object to a given cv::FileStorage.
        /// </summary>
        /// <param name="fs"></param>
        public void Save(FileStorage fs)
        {
            ThrowIfDisposed();
            if (fs == null)
                throw new ArgumentNullException(nameof(fs));
            fs.ThrowIfDisposed();
            NativeMethods.core_LDA_save_FileStorage(ptr, fs.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(fs);
        }

        /// <summary>
        /// Deserializes this object from a given cv::FileStorage.
        /// </summary>
        /// <param name="node"></param>
        public void Load(FileStorage node)
        {
            ThrowIfDisposed();
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            node.ThrowIfDisposed();
            NativeMethods.core_LDA_load_FileStorage(ptr, node.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(node);
        }

        /// <summary>
        /// Compute the discriminants for data in src (row aligned) and labels.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="labels"></param>
        public void Compute(InputArray src, InputArray labels)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (labels == null)
                throw new ArgumentNullException(nameof(labels));
            src.ThrowIfDisposed();
            labels.ThrowIfDisposed();

            NativeMethods.core_LDA_compute(ptr, src.CvPtr, labels.CvPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(src);
            GC.KeepAlive(labels);
        }

        /// <summary>
        /// Projects samples into the LDA subspace.
        /// src may be one or more row aligned samples.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public Mat Project(InputArray src)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

            IntPtr ret = NativeMethods.core_LDA_project(ptr, src.CvPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(src);

            return new Mat(ret);
        }

        /// <summary>
        /// Reconstructs projections from the LDA subspace.
        /// src may be one or more row aligned projections.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public Mat Reconstruct(InputArray src)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();

            IntPtr ret = NativeMethods.core_LDA_reconstruct(ptr, src.CvPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(src);

            return new Mat(ret);
        }

        #endregion

        #region Static

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        /// <param name="mean"></param>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Mat SubspaceProject(InputArray w, InputArray mean, InputArray src)
        {
            if (w == null)
                throw new ArgumentNullException(nameof(w));
            if (mean == null)
                throw new ArgumentNullException(nameof(mean));
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            w.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            src.ThrowIfDisposed();

            IntPtr ret = NativeMethods.core_LDA_subspaceProject(w.CvPtr, mean.CvPtr, src.CvPtr);

            GC.KeepAlive(w);
            GC.KeepAlive(mean);
            GC.KeepAlive(src);

            return new Mat(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        /// <param name="mean"></param>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Mat SubspaceReconstruct(InputArray w, InputArray mean, InputArray src)
        {
            if (w == null)
                throw new ArgumentNullException(nameof(w));
            if (mean == null)
                throw new ArgumentNullException(nameof(mean));
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            w.ThrowIfDisposed();
            mean.ThrowIfDisposed();
            src.ThrowIfDisposed();

            IntPtr ret = NativeMethods.core_LDA_subspaceProject(w.CvPtr, mean.CvPtr, src.CvPtr);

            GC.KeepAlive(w);
            GC.KeepAlive(mean);
            GC.KeepAlive(src);

            return new Mat(ret);
        }
        
        #endregion
    }
}
