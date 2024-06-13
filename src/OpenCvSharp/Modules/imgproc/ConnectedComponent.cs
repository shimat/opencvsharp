using OpenCvSharp.Internal.Util;

namespace OpenCvSharp;

/// <summary>
/// connected components that is returned from Cv2.ConnectedComponentsEx
/// </summary>
public class ConnectedComponents
{
    /// <summary>
    /// All blobs
    /// </summary>
    public IReadOnlyList<Blob> Blobs { get; }

    /// <summary>
    /// destination labeled value
    /// </summary>
    public ReadOnlyArray2D<int> Labels { get;  }

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
    internal ConnectedComponents(IReadOnlyList<Blob> blobs, int[,] labels, int labelCount)
    {
        Blobs = blobs;
        Labels = new ReadOnlyArray2D<int>(labels);
        LabelCount = labelCount;
    }

    /// <summary>
    /// Filter a image with the specified label value. 
    /// </summary>
    /// <param name="src">Source image.</param>
    /// <param name="dst">Destination image.</param>
    /// <param name="labelValue">Label value.</param>
    /// <returns>Filtered image.</returns>
    public void FilterByLabel(Mat src, Mat dst, int labelValue)
    {
        FilterByLabels(src, dst, new[] { labelValue });
    }

    /// <summary>
    /// Filter a image with the specified label values. 
    /// </summary>
    /// <param name="src">Source image.</param>
    /// <param name="dst">Destination image.</param>
    /// <param name="labelValues">Label values.</param>
    /// <returns>Filtered image.</returns>
    public void FilterByLabels(Mat src, Mat dst, IEnumerable<int> labelValues)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        if (labelValues is null)
            throw new ArgumentNullException(nameof(labelValues));
        var labelArray = labelValues.ToArray();
        if (labelArray.Length == 0)
            throw new ArgumentException("empty labelValues");

        foreach (var labelValue in labelArray)
        {
            if (labelValue < 0 || labelValue >= LabelCount)
                throw new ArgumentException("0 <= x < LabelCount");
        }

        // マスク用Matを用意し、Andで切り抜く
        using var mask = GetLabelMask(labelArray[0]);

        for (var i = 1; i < labelArray.Length; i++)
        {
            using var maskI = GetLabelMask(labelArray[i]);
            Cv2.BitwiseOr(mask, maskI, mask);                
        }
        src.CopyTo(dst, mask);
    }

    /// <summary>
    /// Filter a image with the specified blob object. 
    /// </summary>
    /// <param name="src">Source image.</param>
    /// <param name="dst">Destination image.</param>
    /// <param name="blob">Blob value.</param>
    /// <returns>Filtered image.</returns>
    public void FilterByBlob(Mat src, Mat dst, Blob blob)
    {
        if (blob is null)
            throw new ArgumentNullException(nameof(blob));
        FilterByLabels(src, dst, new[] { blob.Label });
    }

    /// <summary>
    /// Filter a image with the specified blob objects. 
    /// </summary>
    /// <param name="src">Source image.</param>
    /// <param name="dst">Destination image.</param>
    /// <param name="blobs">Blob values.</param>
    /// <returns>Filtered image.</returns>
    public void FilterByBlobs(Mat src, Mat dst, IEnumerable<Blob> blobs)
    {
        FilterByLabels(src, dst, blobs.Select(b => b.Label));
    }

    /// <summary>
    /// Draws all blobs to the specified image.
    /// </summary>
    /// <param name="img">The target image to be drawn.</param>
    public void RenderBlobs(Mat img)
    {
        if (img is null)
            throw new ArgumentNullException(nameof(img));
        /*
        if (img.Empty())
            throw new ArgumentException("img is empty");
        if (img.Type() != MatType.CV_8UC3)
            throw new ArgumentException("img must be CV_8UC3");*/
        if (Blobs is null || Blobs.Count == 0)
            throw new OpenCvSharpException("Blobs is empty");
        if (Labels is null)
            throw new OpenCvSharpException("Labels is empty");

        var height = Labels.GetLength(0);
        var width = Labels.GetLength(1);
        img.Create(new Size(width, height), MatType.CV_8UC3);

        var colors = new Scalar[Blobs.Count];
        colors[0] = Scalar.All(0);
        for (var i = 1; i < Blobs.Count; i++)
        {
            colors[i] = Scalar.RandomColor();
        }

        using (var imgt = new Mat<Vec3b>(img))
        {
            var indexer = imgt.GetIndexer();
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var labelValue = Labels[y, x];
                    indexer[y, x] = colors[labelValue].ToVec3b();
                }
            }
        }
    }

    /// <summary>
    /// Find the largest blob.
    /// </summary>
    /// <returns>the largest blob</returns>
#pragma warning disable CA1024 // Use properties where appropriate
    public Blob GetLargestBlob()
    {
        if (Blobs is null || Blobs.Count <= 1)
            throw new OpenCvSharpException("Blobs is empty");

        var max = Blobs[1];
        for (var i = 2; i < Blobs.Count; i++)
        {
            if (max.Area < Blobs[i].Area)
                max = Blobs[i];
        }
        return max;
    }
#pragma warning restore CA1024

    /// <summary>
    /// 指定したラベル値のところのみを非0で残したマスク画像を返す
    /// </summary>
    /// <param name="label"></param>
    /// <returns></returns>
    private Mat GetLabelMask(int label)
    {
        var rows = Labels.GetLength(0);
        var cols = Labels.GetLength(1);
        using (var labels = Mat.FromPixelData(rows, cols, MatType.CV_32SC1, Labels.GetBuffer()))
        using (var cmp = new Mat(rows, cols, MatType.CV_32SC1, Scalar.All(label)))
        {
            var result = new Mat();
            Cv2.Compare(labels, cmp, result, CmpType.EQ);
            return result;
        }
    }

#pragma warning disable CA1034
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
        public Rect Rect => new Rect(Left, Top, Width, Height);

        /// <summary>
        /// The total area (in pixels) of the connected component.
        /// </summary>
        public int Area { get; internal set; }
    }
}
