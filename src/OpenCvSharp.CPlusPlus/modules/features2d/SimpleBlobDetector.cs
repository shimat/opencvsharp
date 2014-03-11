/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Class for extracting blobs from an image.
    /// </summary>
    public class SimpleBlobDetector : FeatureDetector
    {
        private bool disposed;

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
        internal struct WParams
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
        /// <param name="parameters"></param>
        public SimpleBlobDetector(Params parameters = null)
        {
            if (parameters == null)
                parameters = new Params();
            ptr = CppInvoke.features2d_SimpleBlobDetector_new(ref parameters.data);
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
                    if (ptr != IntPtr.Zero)
                        CppInvoke.features2d_SimpleBlobDetector_delete(ptr);
                    ptr = IntPtr.Zero;
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
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public KeyPoint[] Run(Mat image, Mat mask)
        {
            ThrowIfDisposed();
            return base.Detect(image, mask);
        }

        /// <summary>
        /// 
        /// </summary>
        public AlgorithmInfo Info
        {
            get
            {
                ThrowIfDisposed();
                IntPtr pInfo = CppInvoke.features2d_GFTTDetector_info(ptr);
                return new AlgorithmInfo(pInfo);
            }
        }
        #endregion
    }
}
