using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// Class for extracting blobs from an image.
    /// </summary>
    public class SimpleBlobDetector : Feature2D
    {
        private bool disposed;
        private Ptr<SimpleBlobDetector> ptrObj;

        /// <summary>
        /// SimpleBlobDetector parameters
        /// </summary>
        public class Params
        {
            internal WParams data;

            /// <summary>
            /// 
            /// </summary>
            public Params()
            {
                data = new WParams
                    {
                        thresholdStep = 10,
                        minThreshold = 50,
                        maxThreshold = 220,
                        minRepeatability = 2,
                        minDistBetweenBlobs = 10,
                        filterByColor = 1,
                        blobColor = 0,
                        filterByArea = 1,
                        minArea = 25,
                        maxArea = 5000,
                        filterByCircularity = 0,
                        minCircularity = 0.8f,
                        maxCircularity = Single.MaxValue,
                        filterByInertia = 1,
                        minInertiaRatio = 0.1f,
                        maxInertiaRatio = Single.MaxValue,
                        filterByConvexity = 1,
                        minConvexity = 0.95f,
                        maxConvexity = Single.MaxValue
                    };
            }

#pragma warning disable 1591
            public float ThresholdStep
            {
                get { return data.thresholdStep; }
                set { data.thresholdStep = value; }
            }
            public float MinThreshold
            {
                get { return data.minThreshold; }
                set { data.minThreshold = value; }
            }
            public float MaxThreshold
            {
                get { return data.maxThreshold; }
                set { data.maxThreshold = value; }
            }
            public uint MinRepeatability
            {
                get { return data.minRepeatability; }
                set { data.minRepeatability = value; }
            }
            public float MinDistBetweenBlobs
            {
                get { return data.minDistBetweenBlobs; }
                set { data.minDistBetweenBlobs = value; }
            }

            public bool FilterByColor
            {
                get { return data.filterByColor != 0; }
                set { data.filterByColor = (value ? 1 : 0); }
            }
            public byte BlobColor
            {
                get { return data.blobColor; }
                set { data.blobColor = value; }
            }

            public bool FilterByArea
            {
                get { return data.filterByArea != 0; }
                set { data.filterByArea = (value ? 1 : 0); }
            }
            public float MinArea{
                get { return data.minArea; }
                set { data.minArea = value; }
            }
            public float MaxArea
            {
                get { return data.maxArea; }
                set { data.maxArea = value; }
            }

            public bool FilterByCircularity
            {
                get { return data.filterByCircularity != 0; }
                set { data.filterByCircularity = (value ? 1 : 0); }
            }
            public float MinCircularity{
                get { return data.minCircularity; }
                set { data.minCircularity = value; }
            }
            public float MaxCircularity
            {
                get { return data.maxCircularity; }
                set { data.maxCircularity = value; }
            }

            public bool FilterByInertia
            {
                get { return data.filterByInertia != 0; }
                set { data.filterByInertia = (value ? 1 : 0); }
            }
            public float MinInertiaRatio{
                get { return data.minInertiaRatio; }
                set { data.minInertiaRatio = value; }
            }
            public float MaxInertiaRatio
            {
                get { return data.maxInertiaRatio; }
                set { data.maxInertiaRatio = value; }
            }

            public bool FilterByConvexity
            {
                get { return data.filterByConvexity != 0; }
                set { data.filterByConvexity = (value ? 1 : 0); }
            }
            public float MinConvexity{
                get { return data.minConvexity; }
                set { data.minConvexity = value; }
            }
            public float MaxConvexity
            {
                get { return data.maxConvexity; }
                set { data.maxConvexity = value; }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WParams
        {
            public float thresholdStep;
            public float minThreshold;
            public float maxThreshold;
            public uint minRepeatability; // size_t
            public float minDistBetweenBlobs;

            public int filterByColor;
            public byte blobColor;

            public int filterByArea;
            public float minArea, maxArea;

            public int filterByCircularity;
            public float minCircularity, maxCircularity;

            public int filterByInertia;
            public float minInertiaRatio, maxInertiaRatio;

            public int filterByConvexity;
            public float minConvexity, maxConvexity;
#pragma warning restore 1591
        }
        
        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected SimpleBlobDetector(IntPtr p)
        {
            ptrObj = new Ptr<SimpleBlobDetector>(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        public static SimpleBlobDetector Create(Params parameters = null)
        {
            if (parameters == null)
                parameters = new Params();
            IntPtr ptr = NativeMethods.features2d_SimpleBlobDetector_create(ref parameters.data);
            return new SimpleBlobDetector(ptr);
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
                        if (ptrObj != null)
                        {
                            ptrObj.Dispose();
                            ptrObj = null;
                        }
                    }
                    // releases unmanaged resources

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

        #endregion
    }
}
