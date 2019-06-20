using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// connected components that is returned from Cv2.ConnectedComponentsEx
    /// </summary>
    public class ConnectedComponents
    {
        /// <summary>
        /// All blobs
        /// </summary>
        public ReadOnlyCollection<Blob> Blobs { get; internal set; }

        /// <summary>
        /// destination labeled value
        /// </summary>
        public int[,] Labels { get; internal set; }

        /// <summary>
        /// The number of labels -1
        /// </summary>
        public int LabelCount { get; internal set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="blobs"></param>
        /// <param name="labels"></param>
        /// <param name="labelCount"></param>
        internal ConnectedComponents(IList<Blob> blobs, int[,] labels, int labelCount)
        {
            Blobs = new ReadOnlyCollection<Blob>(blobs);
            Labels = labels;
            LabelCount = labelCount;
        }

        /// <summary>
        /// Filter a image with the specified label value. 
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="labelValue">Label value.</param>
        /// <returns>Filtered image.</returns>
        public Mat FilterByLabel(Mat src, Mat dst, int labelValue)
        {
            return FilterByLabels(src, dst, new[] { labelValue });
        }

        /// <summary>
        /// Filter a image with the specified label values. 
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="labelValues">Label values.</param>
        /// <returns>Filtered image.</returns>
        public Mat FilterByLabels(Mat src, Mat dst, IEnumerable<int> labelValues)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (labelValues == null)
                throw new ArgumentNullException(nameof(labelValues));
            int[] labelArray = EnumerableEx.ToArray(labelValues);
            if (labelArray.Length == 0)
                throw new ArgumentException("empty labelValues");

            foreach (int labelValue in labelArray)
            {
                if (labelValue < 0 || labelValue >= LabelCount)
                    throw new ArgumentException("0 <= x < LabelCount");
            }

            // マスク用Matを用意し、Andで切り抜く
            using (Mat mask = GetLabelMask(labelArray[0]))
            {
                for (int i = 1; i < labelArray.Length; i++)
                {
                    using (var maskI = GetLabelMask(labelArray[i]))
                    {
                        Cv2.BitwiseOr(mask, maskI, mask);
                    }
                }
                src.CopyTo(dst, mask);
                return dst;
            }
        }

        /// <summary>
        /// Filter a image with the specified blob object. 
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="blob">Blob value.</param>
        /// <returns>Filtered image.</returns>
        public Mat FilterByBlob(Mat src, Mat dst, Blob blob)
        {
            return FilterByLabels(src, dst, new[] { blob.Label });
        }

        /// <summary>
        /// Filter a image with the specified blob objects. 
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="blobs">Blob values.</param>
        /// <returns>Filtered image.</returns>
        public Mat FilterBlobs(Mat src, Mat dst, IEnumerable<Blob> blobs)
        {
            return FilterByLabels(src, dst, EnumerableEx.Select(blobs, b => b.Label));
        }

        /// <summary>
        /// Draws all blobs to the specified image.
        /// </summary>
        /// <param name="img">The target image to be drawn.</param>
        public void RenderBlobs(Mat img)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            /*
            if (img.Empty())
                throw new ArgumentException("img is empty");
            if (img.Type() != MatType.CV_8UC3)
                throw new ArgumentException("img must be CV_8UC3");*/
            if (Blobs == null || Blobs.Count == 0)
                throw new OpenCvSharpException("Blobs is empty");
            if (Labels == null)
                throw new OpenCvSharpException("Labels is empty");

            int height = Labels.GetLength(0);
            int width = Labels.GetLength(1);
            img.Create(new Size(width, height), MatType.CV_8UC3);

            Scalar[] colors = new Scalar[Blobs.Count];
            colors[0] = Scalar.All(0);
            for (int i = 1; i < Blobs.Count; i++)
            {
                colors[i] = Scalar.RandomColor();
            }

            using (var imgt = new Mat<Vec3b>(img))
            {
                var indexer = imgt.GetIndexer();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int labelValue = Labels[y, x];
                        indexer[y, x] = colors[labelValue].ToVec3b();
                    }
                }
            }
        }

        /// <summary>
        /// Find the largest blob.
        /// </summary>
        /// <returns>the largest blob</returns>
        public Blob GetLargestBlob()
        {
            if (Blobs == null || Blobs.Count <= 1)
                throw new OpenCvSharpException("Blobs is empty");

            Blob max = Blobs[1];
            for (int i = 2; i < Blobs.Count; i++)
            {
                if (max.Area < Blobs[i].Area)
                    max = Blobs[i];
            }
            return max;
        }

        /// <summary>
        /// 指定したラベル値のところのみを非0で残したマスク画像を返す
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        private Mat GetLabelMask(int label)
        {
            int rows = Labels.GetLength(0);
            int cols = Labels.GetLength(1);
            using (var labels = new Mat(rows, cols, MatType.CV_32SC1, Labels))
            using (var cmp = new Mat(rows, cols, MatType.CV_32SC1, Scalar.All(label)))
            {
                Mat result = new Mat();
                Cv2.Compare(labels, cmp, result, CmpTypes.EQ);
                return result;
            }
        }

        /// <summary>
        /// One blob
        /// </summary>
        public class Blob
        {
            /// <summary>
            /// Label value
            /// </summary>
            public int Label { get; internal set; }

            /// <summary>
            /// Floating point centroid (x,y)
            /// </summary>
            public Point2d Centroid { get; internal set; }

            /// <summary>
            /// The leftmost (x) coordinate which is the inclusive start of the bounding box in the horizontal direction.
            /// </summary>
            public int Left { get; internal set; }

            /// <summary>
            /// The topmost (y) coordinate which is the inclusive start of the bounding box in the vertical direction.
            /// </summary>
            public int Top { get; internal set; }

            /// <summary>
            /// The horizontal size of the bounding box.
            /// </summary>
            public int Width { get; internal set; }

            /// <summary>
            /// The vertical size of the bounding box.
            /// </summary>
            public int Height { get; internal set; }

            /// <summary>
            /// The bounding box.
            /// </summary>
            public Rect Rect
            {
                get { return new Rect(Left, Top, Width, Height); }
            }

            /// <summary>
            /// The total area (in pixels) of the connected component.
            /// </summary>
            public int Area { get; internal set; }
        }
    }
}
