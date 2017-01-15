using System;
using OpenCvSharp.Face;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    static partial class Cv2
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="numComponents"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static BasicFaceRecognizer CreateEigenFaceRecognizer(
            int numComponents = 0, double threshold = Double.MaxValue)
        {
            return FaceRecognizer.CreateEigenFaceRecognizer(numComponents, threshold);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="numComponents"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static BasicFaceRecognizer CreateFisherFaceRecognizer(
            int numComponents = 0, double threshold = Double.MaxValue)
        {
            return FaceRecognizer.CreateFisherFaceRecognizer(numComponents, threshold);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="neighbors"></param>
        /// <param name="gridX"></param>
        /// <param name="gridY"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static LBPHFaceRecognizer CreateLBPHFaceRecognizer(int radius = 1, int neighbors = 8,
            int gridX = 8, int gridY = 8, double threshold = Double.MaxValue)
        {
            return FaceRecognizer.CreateLBPHFaceRecognizer(radius, neighbors, gridX, gridY, threshold);
        }
    }
}
