using System;

namespace OpenCvSharp
{
    /// <summary>
    /// finds arbitrary template in the grayscale image using Generalized Hough Transform
    /// </summary>
    public abstract class GeneralizedHough : Algorithm
    {
        /// <summary>
        /// Canny low threshold.
        /// </summary>
        /// <returns></returns>
        public int CannyLowThresh
        {
            get
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHough_getCannyLowThresh(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHough_setCannyLowThresh(ptr, value);
            }
        }

        /// <summary>
        /// Canny high threshold.
        /// </summary>
        /// <returns></returns>
        public int CannyHighThresh
        {
            get
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHough_getCannyHighThresh(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHough_setCannyHighThresh(ptr, value);
            }
        }

        /// <summary>
        /// Minimum distance between the centers of the detected objects.
        /// </summary>
        /// <returns></returns>
        public double MinDist
        {
            get
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHough_getMinDist(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHough_setMinDist(ptr, value);
            }
        }

        /// <summary>
        /// Inverse ratio of the accumulator resolution to the image resolution.
        /// </summary>
        /// <returns></returns>
        public double Dp
        {
            get
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHough_getDp(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHough_setDp(ptr, value);
            }
        }

        /// <summary>
        /// Maximal size of inner buffers.
        /// </summary>
        /// <returns></returns>
        public int MaxBufferSize
        {
            get
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.imgproc_GeneralizedHough_getMaxBufferSize(ptr);
            }
            set
            {
                if (ptr == IntPtr.Zero)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.imgproc_GeneralizedHough_setMaxBufferSize(ptr, value);
            }
        }

        /// <summary>
        /// set template to search
        /// </summary>
        /// <param name="templ"></param>
        /// <param name="templCenter"></param>
        public void SetTemplate(InputArray templ, Point? templCenter = null)
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            if (templ == null)
                throw new ArgumentNullException("templ");
            templ.ThrowIfDisposed();
            var templCenterValue = templCenter.GetValueOrDefault(new Point(-1, -1));

            NativeMethods.imgproc_GeneralizedHough_setTemplate1(ptr, templ.CvPtr, templCenterValue);

            GC.KeepAlive(templ);
        }

        /// <summary>
        /// set template to search
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="templCenter"></param>
        public virtual void SetTemplate(InputArray edges, InputArray dx, InputArray dy, Point? templCenter = null)
        {
            if (ptr == IntPtr.Zero)
                throw new ObjectDisposedException(GetType().Name);
            if (edges == null)
                throw new ArgumentNullException("edges");
            if (dx == null) 
                throw new ArgumentNullException("dx");
            if (dy == null)
                throw new ArgumentNullException("dy");
            edges.ThrowIfDisposed();
            dx.ThrowIfDisposed();
            dy.ThrowIfDisposed();
            var templCenterValue = templCenter.GetValueOrDefault(new Point(-1, -1));

            NativeMethods.imgproc_GeneralizedHough_setTemplate2(
                ptr, edges.CvPtr, dx.CvPtr, dy.CvPtr, templCenterValue);

            GC.KeepAlive(edges);
            GC.KeepAlive(dx);
            GC.KeepAlive(dy);
        }

        /// <summary>
        /// find template on image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="positions"></param>
        /// <param name="votes"></param>
        public virtual void Detect(
            InputArray image, OutputArray positions, OutputArray votes = null)
        {
            if (image == null) 
                throw new ArgumentNullException("image");
            if (positions == null) 
                throw new ArgumentNullException("positions");
            image.ThrowIfDisposed();
            positions.ThrowIfNotReady();
            if (votes != null)
                votes.ThrowIfNotReady();

            NativeMethods.imgproc_GeneralizedHough_detect1(
                ptr, image.CvPtr, positions.CvPtr, Cv2.ToPtr(votes));

            GC.KeepAlive(image);
            positions.Fix();
            if (votes != null)
                votes.Fix();
        }

        /// <summary>
        /// find template on image
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="positions"></param>
        /// <param name="votes"></param>
        public virtual void Detect(
            InputArray edges, InputArray dx, InputArray dy, OutputArray positions, OutputArray votes = null)
        {
            if (edges == null)
                throw new ArgumentNullException("edges");
            if (dx == null) 
                throw new ArgumentNullException("dx");
            if (dy == null)
                throw new ArgumentNullException("dy");
            if (positions == null)
                throw new ArgumentNullException("positions");
            edges.ThrowIfDisposed();
            dx.ThrowIfDisposed();
            dy.ThrowIfDisposed();
            positions.ThrowIfNotReady();
            if (votes != null)
                votes.ThrowIfNotReady();

            NativeMethods.imgproc_GeneralizedHough_detect2(
                ptr, edges.CvPtr, dx.CvPtr, dy.CvPtr, positions.CvPtr, Cv2.ToPtr(votes));

            GC.KeepAlive(edges);
            GC.KeepAlive(dx);
            GC.KeepAlive(dy);
            positions.Fix();
            if (votes != null)
                votes.Fix();
        }
    }
}
