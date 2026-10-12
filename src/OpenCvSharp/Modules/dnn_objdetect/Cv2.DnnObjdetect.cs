using System.Runtime.InteropServices;
using OpenCvSharp.DnnObjdetect;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

public static partial class Cv2
{
    /// <summary>Postprocessing for the fixed-shape SqueezeDet output used by opencv_contrib dnn_objdetect.</summary>
    public static class DnnObjdetect
    {
        /// <summary>
        /// Filters SqueezeDet predictions into bounding boxes for the 20 PASCAL VOC classes.
        /// All inputs must be single-channel 32-bit floating point matrices.
        /// </summary>
        /// <param name="deltaBboxes">A 23 x 23 x 36 tensor of box deltas.</param>
        /// <param name="classScores">A 4761 x 20 matrix of class scores.</param>
        /// <param name="confidenceScores">A 23 x 23 x 9 tensor of confidence scores.</param>
        /// <param name="threshold">Minimum object probability, from 0 to 1.</param>
        public static DnnObjectDetection[] InferBboxes(
            Mat deltaBboxes, Mat classScores, Mat confidenceScores, double threshold = 0.8)
        {
            ValidateTensor(deltaBboxes, nameof(deltaBboxes), 23, 23, 36);
            ValidateMatrix(classScores, nameof(classScores), 4761, 20);
            ValidateTensor(confidenceScores, nameof(confidenceScores), 23, 23, 9);
            if (!double.IsFinite(threshold) || threshold is < 0 or > 1)
                throw new ArgumentOutOfRangeException(nameof(threshold));

            NativeMethods.HandleException(NativeMethods.dnn_objdetect_inferBboxes(
                deltaBboxes.CvPtr, classScores.CvPtr, confidenceScores.CvPtr,
                threshold, out var detections));
            GC.KeepAlive(deltaBboxes);
            GC.KeepAlive(classScores);
            GC.KeepAlive(confidenceScores);

            try
            {
                NativeMethods.HandleException(NativeMethods.dnn_objdetect_detections_count(detections, out var count));
                var result = new DnnObjectDetection[count];
                for (var i = 0; i < count; i++)
                {
                    NativeMethods.HandleException(NativeMethods.dnn_objdetect_detections_get(
                        detections, i, out var xmin, out var ymin, out var xmax, out var ymax,
                        out var classIndex, out var label, out var probability));
                    result[i] = new DnnObjectDetection(
                        xmin, ymin, xmax, ymax, classIndex,
                        Marshal.PtrToStringUTF8(label) ?? string.Empty, probability);
                }
                return result;
            }
            finally
            {
                NativeMethods.HandleException(NativeMethods.dnn_objdetect_detections_delete(detections));
            }
        }

        private static void ValidateTensor(Mat matrix, string name, int first, int second, int third)
        {
            ArgumentNullException.ThrowIfNull(matrix);
            if (matrix.Dims != 3 || matrix.Size(0) != first || matrix.Size(1) != second ||
                matrix.Size(2) != third || matrix.Type() != MatType.CV_32FC1)
                throw new ArgumentException($"Expected a {first} x {second} x {third} CV_32FC1 tensor.", name);
        }

        private static void ValidateMatrix(Mat matrix, string name, int rows, int cols)
        {
            ArgumentNullException.ThrowIfNull(matrix);
            if (matrix.Dims != 2 || matrix.Rows != rows || matrix.Cols != cols ||
                matrix.Type() != MatType.CV_32FC1)
                throw new ArgumentException($"Expected a {rows} x {cols} CV_32FC1 matrix.", name);
        }
    }
}
