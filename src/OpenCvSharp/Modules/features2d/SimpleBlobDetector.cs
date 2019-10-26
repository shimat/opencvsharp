﻿using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// Class for extracting blobs from an image.
    /// </summary>
    public class SimpleBlobDetector : Feature2D
    {
        private Ptr? ptrObj;

        //internal override IntPtr PtrObj => ptrObj.CvPtr;

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
                        maxCircularity = float.MaxValue,
                        filterByInertia = 1,
                        minInertiaRatio = 0.1f,
                        maxInertiaRatio = float.MaxValue,
                        filterByConvexity = 1,
                        minConvexity = 0.95f,
                        maxConvexity = float.MaxValue
                    };
            }

#pragma warning disable 1591
            public float ThresholdStep
            {
                get => data.thresholdStep;
                set => data.thresholdStep = value;
            }
            public float MinThreshold
            {
                get => data.minThreshold;
                set => data.minThreshold = value;
            }
            public float MaxThreshold
            {
                get => data.maxThreshold;
                set => data.maxThreshold = value;
            }
            public uint MinRepeatability
            {
                get => data.minRepeatability;
                set => data.minRepeatability = value;
            }
            public float MinDistBetweenBlobs
            {
                get => data.minDistBetweenBlobs;
                set => data.minDistBetweenBlobs = value;
            }

            public bool FilterByColor
            {
                get => data.filterByColor != 0;
                set => data.filterByColor = (value ? 1 : 0);
            }
            public byte BlobColor
            {
                get => data.blobColor;
                set => data.blobColor = value;
            }

            public bool FilterByArea
            {
                get => data.filterByArea != 0;
                set => data.filterByArea = (value ? 1 : 0);
            }
            public float MinArea{
                get => data.minArea;
                set => data.minArea = value;
            }
            public float MaxArea
            {
                get => data.maxArea;
                set => data.maxArea = value;
            }

            public bool FilterByCircularity
            {
                get => data.filterByCircularity != 0;
                set => data.filterByCircularity = (value ? 1 : 0);
            }
            public float MinCircularity{
                get => data.minCircularity;
                set => data.minCircularity = value;
            }
            public float MaxCircularity
            {
                get => data.maxCircularity;
                set => data.maxCircularity = value;
            }

            public bool FilterByInertia
            {
                get => data.filterByInertia != 0;
                set => data.filterByInertia = (value ? 1 : 0);
            }
            public float MinInertiaRatio{
                get => data.minInertiaRatio;
                set => data.minInertiaRatio = value;
            }
            public float MaxInertiaRatio
            {
                get => data.maxInertiaRatio;
                set => data.maxInertiaRatio = value;
            }

            public bool FilterByConvexity
            {
                get => data.filterByConvexity != 0;
                set => data.filterByConvexity = (value ? 1 : 0);
            }
            public float MinConvexity{
                get => data.minConvexity;
                set => data.minConvexity = value;
            }
            public float MaxConvexity
            {
                get => data.maxConvexity;
                set => data.maxConvexity = value;
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
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        public static SimpleBlobDetector Create(Params? parameters = null)
        {
            if (parameters == null)
                parameters = new Params();
            var ptr = NativeMethods.features2d_SimpleBlobDetector_create(ref parameters.data);
            return new SimpleBlobDetector(ptr);
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

        #endregion

        #region Methods

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                var res = NativeMethods.features2d_Ptr_SimpleBlobDetector_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.features2d_Ptr_SimpleBlobDetector_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
