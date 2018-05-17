using System;

namespace OpenCvSharp.XImgProc
{
    /// <summary>
    /// Class implementing edge detection algorithm from @cite Dollar2013 :
    /// </summary>
    public class StructuredEdgeDetection : Algorithm
    {
        private Ptr ptrObj;

        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected StructuredEdgeDetection(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            ptrObj?.Dispose();
            ptrObj = null;
            base.DisposeManaged();
        }

        /// <summary>
        /// Creates a StructuredEdgeDetection
        /// </summary>
        /// <param name="model">name of the file where the model is stored</param>
        /// <param name="howToGetFeatures">optional object inheriting from RFFeatureGetter.
        /// You need it only if you would like to train your own forest, pass null otherwise</param>
        /// <returns></returns>
        public static StructuredEdgeDetection Create(string model, RFFeatureGetter howToGetFeatures = null)
        {
            IntPtr p = NativeMethods.ximgproc_createStructuredEdgeDetection(
                model, howToGetFeatures?.PtrObj?.CvPtr ?? IntPtr.Zero);
            GC.KeepAlive(howToGetFeatures);
            return new StructuredEdgeDetection(p);
        }

        /// <summary>
        /// Returns array containing proposal boxes.
        /// </summary>
        /// <param name="edgeMap">edge image.</param>
        /// <param name="orientationMap">orientation map.</param>
        /// <param name="boxes">proposal boxes.</param>
        public virtual void GetBoundingBoxes(InputArray edgeMap, InputArray orientationMap, out Rect[] boxes)
        {
            ThrowIfDisposed();
            if (edgeMap == null)
                throw new ArgumentNullException(nameof(edgeMap));
            if (orientationMap == null)
                throw new ArgumentNullException(nameof(orientationMap));
            edgeMap.ThrowIfDisposed();
            orientationMap.ThrowIfDisposed();

            using (var boxesVec = new VectorOfRect())
            {
                NativeMethods.ximgproc_EdgeBoxes_getBoundingBoxes(ptr, edgeMap.CvPtr, orientationMap.CvPtr, boxesVec.CvPtr);
                boxes = boxesVec.ToArray();
            }

            GC.KeepAlive(this);
            GC.KeepAlive(edgeMap);
            GC.KeepAlive(orientationMap);
        }

        /// <summary>
        /// The function detects edges in src and draw them to dst.
        /// The algorithm underlies this function is much more robust to texture presence, than common approaches, e.g.Sobel
        /// </summary>
        /// <param name="src">source image (RGB, float, in [0;1]) to detect edges</param>
        /// <param name="dst">destination image (grayscale, float, in [0;1]) where edges are drawn</param>
        public virtual void DetectEdges(InputArray src, OutputArray dst)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.ximgproc_StructuredEdgeDetection_detectEdges(ptr, src.CvPtr, dst.CvPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// The function computes orientation from edge image.
        /// </summary>
        /// <param name="src">edge image.</param>
        /// <param name="dst">orientation image.</param>
        public virtual void ComputeOrientation(InputArray src, OutputArray dst)
        {
            ThrowIfDisposed();
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();

            NativeMethods.ximgproc_StructuredEdgeDetection_computeOrientation(ptr, src.CvPtr, dst.CvPtr);

            GC.KeepAlive(this);
            GC.KeepAlive(src);
            dst.Fix();
        }

        /// <summary>
        /// The function edgenms in edge image and suppress edges where edge is stronger in orthogonal direction.
        /// </summary>
        /// <param name="edgeImage">edge image from detectEdges function.</param>
        /// <param name="orientationImage">orientation image from computeOrientation function.</param>
        /// <param name="dst">suppressed image (grayscale, float, in [0;1])</param>
        /// <param name="r">radius for NMS suppression.</param>
        /// <param name="s">radius for boundary suppression.</param>
        /// <param name="m">multiplier for conservative suppression.</param>
        /// <param name="isParallel">enables/disables parallel computing.</param>
        public virtual void EdgesNms(InputArray edgeImage, InputArray orientationImage, OutputArray dst, 
            int r = 2, int s = 0, float m = 1, bool isParallel = true)
        {
            ThrowIfDisposed();
            if (edgeImage == null)
                throw new ArgumentNullException(nameof(edgeImage));
            if (orientationImage == null)
                throw new ArgumentNullException(nameof(orientationImage));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            edgeImage.ThrowIfDisposed();
            orientationImage.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            
            NativeMethods.ximgproc_StructuredEdgeDetection_edgesNms(
                ptr, edgeImage.CvPtr, orientationImage.CvPtr, dst.CvPtr, r, s, m, isParallel ? 1 : 0);

            GC.KeepAlive(this);
            GC.KeepAlive(edgeImage);
            GC.KeepAlive(orientationImage);
            dst.Fix();
        }

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.ximgproc_Ptr_StructuredEdgeDetection_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.ximgproc_Ptr_StructuredEdgeDetection_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
