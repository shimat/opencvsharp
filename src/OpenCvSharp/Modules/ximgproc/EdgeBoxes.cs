using System;
using System.Collections.Generic;

namespace OpenCvSharp.XImgProc
{
    /// <summary>
    /// Class implementing EdgeBoxes algorithm from @cite ZitnickECCV14edgeBoxes
    /// </summary>
    public class EdgeBoxes : Algorithm
    {
        private Ptr ptrObj;

        /// <summary>
        /// Creates instance by raw pointer
        /// </summary>
        protected EdgeBoxes(IntPtr p)
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
        /// Creates a EdgeBoxes
        /// </summary>
        /// <param name="alpha">step size of sliding window search.</param>
        /// <param name="beta">nms threshold for object proposals.</param>
        /// <param name="eta">adaptation rate for nms threshold.</param>
        /// <param name="minScore">min score of boxes to detect.</param>
        /// <param name="maxBoxes">max number of boxes to detect.</param>
        /// <param name="edgeMinMag">edge min magnitude. Increase to trade off accuracy for speed.</param>
        /// <param name="edgeMergeThr">edge merge threshold. Increase to trade off accuracy for speed.</param>
        /// <param name="clusterMinMag">cluster min magnitude. Increase to trade off accuracy for speed.</param>
        /// <param name="maxAspectRatio">max aspect ratio of boxes.</param>
        /// <param name="minBoxArea">minimum area of boxes.</param>
        /// <param name="gamma">affinity sensitivity.</param>
        /// <param name="kappa">scale sensitivity.</param>
        /// <returns></returns>
        public static EdgeBoxes Create(
            float alpha = 0.65f,
            float beta = 0.75f,
            float eta = 1,
            float minScore = 0.01f,
            int maxBoxes = 10000,
            float edgeMinMag = 0.1f,
            float edgeMergeThr = 0.5f,
            float clusterMinMag = 0.5f,
            float maxAspectRatio = 3,
            float minBoxArea = 1000,
            float gamma = 2,
            float kappa = 1.5f)
        {
            IntPtr p = NativeMethods.ximgproc_createEdgeBoxes(
                alpha, beta, eta, minScore, maxBoxes, edgeMinMag, edgeMergeThr, 
                clusterMinMag, maxAspectRatio, minBoxArea, gamma, kappa);
            return new EdgeBoxes(p);
        }

        /// <summary>
        /// Gets or sets the step size of sliding window search.
        /// </summary>
        public virtual float Alpha
        {
            get
            {
                ThrowIfDisposed();
                float value = NativeMethods.ximgproc_EdgeBoxes_getAlpha(ptr);
                GC.KeepAlive(this);
                return value;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.ximgproc_EdgeBoxes_setAlpha(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Gets or sets the nms threshold for object proposals.
        /// </summary>
        public virtual float Beta
        {
            get
            {
                ThrowIfDisposed();
                float value = NativeMethods.ximgproc_EdgeBoxes_getBeta(ptr);
                GC.KeepAlive(this);
                return value;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.ximgproc_EdgeBoxes_setBeta(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Gets or sets adaptation rate for nms threshold.
        /// </summary>
        public virtual float Eta
        {
            get
            {
                ThrowIfDisposed();
                float value = NativeMethods.ximgproc_EdgeBoxes_getEta(ptr);
                GC.KeepAlive(this);
                return value;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.ximgproc_EdgeBoxes_setEta(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Gets or sets the min score of boxes to detect.
        /// </summary>
        public virtual float MinScore
        {
            get
            {
                ThrowIfDisposed();
                float value = NativeMethods.ximgproc_EdgeBoxes_getMinScore(ptr);
                GC.KeepAlive(this);
                return value;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.ximgproc_EdgeBoxes_setMinScore(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Gets or sets the max number of boxes to detect.
        /// </summary>
        public virtual int MaxBoxes
        {
            get
            {
                ThrowIfDisposed();
                int value = NativeMethods.ximgproc_EdgeBoxes_getMaxBoxes(ptr);
                GC.KeepAlive(this);
                return value;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.ximgproc_EdgeBoxes_setMaxBoxes(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Gets or sets the edge min magnitude.
        /// </summary>
        public virtual float EdgeMinMag
        {
            get
            {
                ThrowIfDisposed();
                float value = NativeMethods.ximgproc_EdgeBoxes_getEdgeMinMag(ptr);
                GC.KeepAlive(this);
                return value;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.ximgproc_EdgeBoxes_setEdgeMinMag(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Gets or sets the edge merge threshold.
        /// </summary>
        public virtual float EdgeMergeThr
        {
            get
            {
                ThrowIfDisposed();
                float value = NativeMethods.ximgproc_EdgeBoxes_getEdgeMergeThr(ptr);
                GC.KeepAlive(this);
                return value;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.ximgproc_EdgeBoxes_setEdgeMergeThr(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Gets or sets the cluster min magnitude.
        /// </summary>
        public virtual float ClusterMinMag
        {
            get
            {
                ThrowIfDisposed();
                float value = NativeMethods.ximgproc_EdgeBoxes_getClusterMinMag(ptr);
                GC.KeepAlive(this);
                return value;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.ximgproc_EdgeBoxes_setClusterMinMag(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Gets or sets the max aspect ratio of boxes.
        /// </summary>
        public virtual float MaxAspectRatio
        {
            get
            {
                ThrowIfDisposed();
                float value = NativeMethods.ximgproc_EdgeBoxes_getMaxAspectRatio(ptr);
                GC.KeepAlive(this);
                return value;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.ximgproc_EdgeBoxes_setMaxAspectRatio(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Gets or sets the minimum area of boxes.
        /// </summary>
        public virtual float MinBoxArea
        {
            get
            {
                ThrowIfDisposed();
                float value = NativeMethods.ximgproc_EdgeBoxes_getMinBoxArea(ptr);
                GC.KeepAlive(this);
                return value;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.ximgproc_EdgeBoxes_setMinBoxArea(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Gets or sets the affinity sensitivity.
        /// </summary>
        public virtual float Gamma
        {
            get
            {
                ThrowIfDisposed();
                float value = NativeMethods.ximgproc_EdgeBoxes_getGamma(ptr);
                GC.KeepAlive(this);
                return value;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.ximgproc_EdgeBoxes_setGamma(ptr, value);
                GC.KeepAlive(this);
            }
        }

        /// <summary>
        /// Gets or sets the scale sensitivity.
        /// </summary>
        public virtual float Kappa
        {
            get
            {
                ThrowIfDisposed();
                float value = NativeMethods.ximgproc_EdgeBoxes_getKappa(ptr);
                GC.KeepAlive(this);
                return value;
            }
            set
            {
                ThrowIfDisposed();
                NativeMethods.ximgproc_EdgeBoxes_setKappa(ptr, value);
                GC.KeepAlive(this);
            }
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

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.ximgproc_Ptr_EdgeBoxes_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.ximgproc_Ptr_EdgeBoxes_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
