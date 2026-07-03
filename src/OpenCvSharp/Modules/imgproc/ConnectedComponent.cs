using OpenCvSharp.Internal.Util;

namespace OpenCvSharp;

/// <summary>
/// connected components that is returned from Cv2.ConnectedComponentsEx
/// </summary>
public sealed class ConnectedComponents : IDisposable
{
    private readonly Mat labelsMat;
    private ReadOnlyArray2D<int>? labelsCache;
    private bool disposed;

    /// <summary>
    /// All blobs, including the background blob at index 0 (<see cref="Blob.Label"/> == 0).
    /// Most callers should skip index 0 unless the background itself is of interest
    /// (see <see cref="GetLargestBlob"/>, which starts scanning from index 1).
    /// </summary>
    public IReadOnlyList<Blob> Blobs { get; }

    /// <summary>
    /// destination labeled value. Materialized from the native label image on first access.
    /// </summary>
    public ReadOnlyArray2D<int> Labels => labelsCache ??= new ReadOnlyArray2D<int>(ToInt32Array(labelsMat));

    /// <summary>
    /// The total number of labels, including the background label (0).
    /// </summary>
    public int LabelCount { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="blobs"></param>
    /// <param name="labelsMat">The native label image (CV_32S or CV_16U). Ownership is transferred to this instance.</param>
    /// <param name="labelCount"></param>
    internal ConnectedComponents(IReadOnlyList<Blob> blobs, Mat labelsMat, int labelCount)
    {
        Blobs = blobs;
        this.labelsMat = labelsMat;
        LabelCount = labelCount;
    }

    /// <summary>
    /// Releases the underlying native label image.
    /// </summary>
    public void Dispose()
    {
        if (disposed)
            return;
        labelsMat.Dispose();
        disposed = true;
    }

    /// <summary>
    /// Filter a image with the specified label value.
    /// </summary>
    /// <param name="src">Source image.</param>
    /// <param name="dst">Destination image.</param>
    /// <param name="labelValue">Label value.</param>
    /// <returns>Filtered image.</returns>
    public void FilterByLabel(Mat src, Mat dst, int labelValue)
        => FilterByLabels(src, dst, [labelValue]);

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
        FilterByLabels(src, dst, [blob.Label]);
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
        if (Blobs is null || Blobs.Count == 0)
            throw new OpenCvSharpException("Blobs is empty");

        var height = labelsMat.Rows;
        var width = labelsMat.Cols;
        img.Create(new Size(width, height), MatType.CV_8UC3);

        var colors = new Vec3b[Blobs.Count];
        for (var i = 1; i < Blobs.Count; i++)
        {
            colors[i] = Scalar.RandomColor().ToVec3b();
        }

        var imgRows = img.AsRows<Vec3b>();
        if (labelsMat.Type() == MatType.CV_16U)
        {
            var labelRows = labelsMat.AsRows<ushort>();
            for (var y = 0; y < height; y++)
            {
                var labelRow = labelRows[y];
                var imgRow = imgRows[y];
                for (var x = 0; x < width; x++)
                    imgRow[x] = colors[labelRow[x]];
            }
        }
        else
        {
            var labelRows = labelsMat.AsRows<int>();
            for (var y = 0; y < height; y++)
            {
                var labelRow = labelRows[y];
                var imgRow = imgRows[y];
                for (var x = 0; x < width; x++)
                    imgRow[x] = colors[labelRow[x]];
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
        var result = new Mat();
        Cv2.Compare(labelsMat, new Scalar(label), result, CmpTypes.EQ);
        return result;
    }

    /// <summary>
    /// Copies the native label image (CV_32S or CV_16U) into a managed <c>int[,]</c>.
    /// </summary>
    private static int[,] ToInt32Array(Mat mat)
    {
        if (mat.Type() == MatType.CV_16U)
        {
            var rows = mat.Rows;
            var cols = mat.Cols;
            var result = new int[rows, cols];
            var srcRows = mat.AsRows<ushort>();
            for (var y = 0; y < rows; y++)
            {
                var srcRow = srcRows[y];
                for (var x = 0; x < cols; x++)
                    result[y, x] = srcRow[x];
            }
            return result;
        }

        using var int32Mat = new Mat<int>(mat);
        return int32Mat.ToRectangularArray();
    }

#pragma warning disable CA1034
    /// <summary>
    /// One blob
    /// </summary>
    public class Blob
    {
        /// <summary>
        /// Label value. 0 is the background label (see <see cref="Blobs"/>).
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
        public Rect Rect => new (Left, Top, Width, Height);

        /// <summary>
        /// The total area (in pixels) of the connected component.
        /// </summary>
        public int Area { get; internal set; }
    }
}
