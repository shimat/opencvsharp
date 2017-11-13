using System;

namespace OpenCvSharp
{
    // ReSharper disable once InconsistentNaming

    /// <summary>
    /// Abstract base class for shape distance algorithms.
    /// </summary>
    public abstract class ShapeDistanceExtractor : Algorithm
    {
        /// <summary>
        /// Compute the shape distance between two shapes defined by its contours.
        /// </summary>
        /// <param name="contour1">Contour defining first shape.</param>
        /// <param name="contour2">Contour defining second shape.</param>
        /// <returns></returns>
        public virtual float ComputeDistance(InputArray contour1, InputArray contour2)
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            if (contour1 == null)
                throw new ArgumentNullException(nameof(contour1));
            if (contour2 == null)
                throw new ArgumentNullException(nameof(contour2));
            contour1.ThrowIfDisposed();
            contour2.ThrowIfDisposed();

            float ret = NativeMethods.shape_ShapeDistanceExtractor_computeDistance(
                ptr, contour1.CvPtr, contour2.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(contour1);
            GC.KeepAlive(contour2);

            return ret;
        }
    }
}
