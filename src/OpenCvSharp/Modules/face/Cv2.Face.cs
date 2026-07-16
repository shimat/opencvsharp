using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

public static partial class Cv2
{
    /// <summary>
    /// cv::face utility functions.
    /// </summary>
    public static partial class Face
    {
        /// <summary>
        /// Creates a Kazemi facemark detector.
        /// </summary>
        public static OpenCvSharp.Face.FacemarkKazemi CreateFacemarkKazemi()
        {
            return OpenCvSharp.Face.FacemarkKazemi.Create();
        }

        /// <summary>
        /// Detects faces with a Haar cascade.
        /// </summary>
        public static bool GetFacesHAAR(InputArray image, OutputArray faces, string faceCascadeName)
        {
            ArgumentNullException.ThrowIfNull(faceCascadeName);
            NativeMethods.HandleException(
                NativeMethods.face_getFacesHAAR(
                    image.Proxy, faces.Proxy, faceCascadeName, out var result));
            GC.KeepAlive(image.Source);
            GC.KeepAlive(faces.Source);
            return result != 0;
        }

        /// <summary>
        /// Loads paired image and annotation paths from list files.
        /// </summary>
        public static bool LoadDatasetList(
            string imageList,
            string annotationList,
            out string[] images,
            out string[] annotations)
        {
            ArgumentNullException.ThrowIfNull(imageList);
            ArgumentNullException.ThrowIfNull(annotationList);
            using var imageVector = new VectorOfString();
            using var annotationVector = new VectorOfString();
            NativeMethods.HandleException(
                NativeMethods.face_loadDatasetList(
                    imageList, annotationList, imageVector.CvPtr, annotationVector.CvPtr, out var result));
            images = imageVector.ToArray();
            annotations = annotationVector.ToArray();
            return result != 0;
        }

        /// <summary>
        /// Loads a facial landmark dataset from a single file.
        /// </summary>
        public static bool LoadTrainingData(
            string filename,
            out string[] images,
            out Point2f[][] facePoints,
            char delimiter = ' ',
            float offset = 0)
        {
            ArgumentNullException.ThrowIfNull(filename);
            if (delimiter > byte.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(delimiter));
            using var imageVector = new VectorOfString();
            using var pointVector = new VectorOfVectorPoint2f();
            NativeMethods.HandleException(
                NativeMethods.face_loadTrainingData1(
                    filename, imageVector.CvPtr, pointVector.CvPtr, (byte)delimiter, offset, out var result));
            images = imageVector.ToArray();
            facePoints = pointVector.ToArray();
            return result != 0;
        }

        /// <summary>
        /// Loads a facial landmark dataset from image and ground-truth list files.
        /// </summary>
        public static bool LoadTrainingData(
            string imageList,
            string groundTruth,
            out string[] images,
            out Point2f[][] facePoints,
            float offset = 0)
        {
            ArgumentNullException.ThrowIfNull(imageList);
            ArgumentNullException.ThrowIfNull(groundTruth);
            using var imageVector = new VectorOfString();
            using var pointVector = new VectorOfVectorPoint2f();
            NativeMethods.HandleException(
                NativeMethods.face_loadTrainingData2(
                    imageList, groundTruth, imageVector.CvPtr, pointVector.CvPtr, offset, out var result));
            images = imageVector.ToArray();
            facePoints = pointVector.ToArray();
            return result != 0;
        }

        /// <summary>
        /// Loads training landmarks from a collection of annotation files.
        /// </summary>
        public static bool LoadTrainingData(
            IEnumerable<string> filenames,
            out Point2f[][] landmarks,
            out string[] images)
        {
            ArgumentNullException.ThrowIfNull(filenames);
            using var filenameVector = new VectorOfString(filenames);
            using var landmarkVector = new VectorOfVectorPoint2f();
            using var imageVector = new VectorOfString();
            NativeMethods.HandleException(
                NativeMethods.face_loadTrainingData3(
                    filenameVector.CvPtr, landmarkVector.CvPtr, imageVector.CvPtr, out var result));
            landmarks = landmarkVector.ToArray();
            images = imageVector.ToArray();
            return result != 0;
        }

        /// <summary>
        /// Loads landmark points from a standard .pts file.
        /// </summary>
        public static bool LoadFacePoints(string filename, out Point2f[] points, float offset = 0)
        {
            ArgumentNullException.ThrowIfNull(filename);
            using var pointVector = new StdVector<Point2f>();
            NativeMethods.HandleException(
                NativeMethods.face_loadFacePoints(filename, pointVector.CvPtr, offset, out var result));
            points = pointVector.ToArray();
            return result != 0;
        }

        /// <summary>
        /// Draws facial landmark points on an image.
        /// </summary>
        public static void DrawFacemarks(
            InputOutputArray image,
            InputArray points,
            Scalar? color = null)
        {
            NativeMethods.HandleException(
                NativeMethods.face_drawFacemarks(
                    image.Proxy, points.Proxy, color ?? new Scalar(255, 0, 0)));
            GC.KeepAlive(image.Source);
            GC.KeepAlive(points.Source);
        }
    }
}
