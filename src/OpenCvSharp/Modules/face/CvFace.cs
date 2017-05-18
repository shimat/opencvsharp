using System;

namespace OpenCvSharp.Face
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// cv::face functions
    /// </summary>
    public static class CvFace
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="numComponents">The number of components (read: Eigenfaces) kept for this Principal Component Analysis. 
        /// As a hint: There's no rule how many components (read: Eigenfaces) should be kept for good reconstruction capabilities. 
        /// It is based on your input data, so experiment with the number. Keeping 80 components should almost always be sufficient.</param>
        /// <param name="threshold">The threshold applied in the prediction.</param>
        /// <returns></returns>
        public static BasicFaceRecognizer CreateEigenFaceRecognizer(
            int numComponents = 0, double threshold = Double.MaxValue)
        {
            return FaceRecognizer.CreateEigenFaceRecognizer(numComponents, threshold);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="numComponents">The number of components (read: Fisherfaces) kept for this Linear Discriminant Analysis 
        /// with the Fisherfaces criterion. It's useful to keep all components, that means the number of your classes c 
        /// (read: subjects, persons you want to recognize). If you leave this at the default (0) or set it 
        /// to a value less-equal 0 or greater (c-1), it will be set to the correct number (c-1) automatically.</param>
        /// <param name="threshold">The threshold applied in the prediction. If the distance to the nearest neighbor 
        /// is larger than the threshold, this method returns -1.</param>
        /// <returns></returns>
        public static BasicFaceRecognizer CreateFisherFaceRecognizer(
            int numComponents = 0, double threshold = Double.MaxValue)
        {
            return FaceRecognizer.CreateFisherFaceRecognizer(numComponents, threshold);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="radius">The radius used for building the Circular Local Binary Pattern. The greater the radius, the</param>
        /// <param name="neighbors">The number of sample points to build a Circular Local Binary Pattern from. 
        /// An appropriate value is to use `8` sample points.Keep in mind: the more sample points you include, the higher the computational cost.</param>
        /// <param name="gridX">The number of cells in the horizontal direction, 8 is a common value used in publications. 
        /// The more cells, the finer the grid, the higher the dimensionality of the resulting feature vector.</param>
        /// <param name="gridY">The number of cells in the vertical direction, 8 is a common value used in publications. 
        /// The more cells, the finer the grid, the higher the dimensionality of the resulting feature vector.</param>
        /// <param name="threshold">The threshold applied in the prediction. If the distance to the nearest neighbor 
        /// is larger than the threshold, this method returns -1.</param>
        /// <returns></returns>
        public static LBPHFaceRecognizer CreateLBPHFaceRecognizer(int radius = 1, int neighbors = 8,
            int gridX = 8, int gridY = 8, double threshold = Double.MaxValue)
        {
            return FaceRecognizer.CreateLBPHFaceRecognizer(radius, neighbors, gridX, gridY, threshold);
        }
    }
}
