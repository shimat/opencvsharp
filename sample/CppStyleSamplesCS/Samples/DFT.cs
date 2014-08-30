using System;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using SampleBase;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// DFT, inverse DFT
    /// http://stackoverflow.com/questions/19761526/how-to-do-inverse-dft-in-opencv
    /// </summary>
    class DFT : ISample
    {
        public void Run()
        {
            Mat img = Cv2.ImRead(FilePath.Image.Lenna, LoadMode.GrayScale);

            // expand input image to optimal size
            Mat padded = new Mat(); 
            int m = Cv2.GetOptimalDFTSize(img.Rows);
            int n = Cv2.GetOptimalDFTSize(img.Cols); // on the border add zero values
            Cv2.CopyMakeBorder(img, padded, 0, m - img.Rows, 0, n - img.Cols, BorderType.Constant, Scalar.All(0));
            
            // Add to the expanded another plane with zeros
            Mat paddedF32 = new Mat();
            padded.ConvertTo(paddedF32, MatType.CV_32F);
            Mat[] planes = { paddedF32, Mat.Zeros(padded.Size(), MatType.CV_32F) };
            Mat complex = new Mat();
            Cv2.Merge(planes, complex);         

            // this way the result may fit in the source matrix
            Mat dft = new Mat();
            Cv2.Dft(complex, dft);            

            // compute the magnitude and switch to logarithmic scale
            // => log(1 + sqrt(Re(DFT(I))^2 + Im(DFT(I))^2))
            Mat[] dftPlanes;
            Cv2.Split(dft, out dftPlanes);  // planes[0] = Re(DFT(I), planes[1] = Im(DFT(I))

            // planes[0] = magnitude
            Mat magnitude = new Mat();
            Cv2.Magnitude(dftPlanes[0], dftPlanes[1], magnitude);

            magnitude += Scalar.All(1);  // switch to logarithmic scale
            Cv2.Log(magnitude, magnitude);

            // crop the spectrum, if it has an odd number of rows or columns
            Mat spectrum = magnitude[
                new Rect(0, 0, magnitude.Cols & -2, magnitude.Rows & -2)];

            // rearrange the quadrants of Fourier image  so that the origin is at the image center
            int cx = spectrum.Cols / 2;
            int cy = spectrum.Rows / 2;

            Mat q0 = new Mat(spectrum, new Rect(0, 0, cx, cy));   // Top-Left - Create a ROI per quadrant
            Mat q1 = new Mat(spectrum, new Rect(cx, 0, cx, cy));  // Top-Right
            Mat q2 = new Mat(spectrum, new Rect(0, cy, cx, cy));  // Bottom-Left
            Mat q3 = new Mat(spectrum, new Rect(cx, cy, cx, cy)); // Bottom-Right

            // swap quadrants (Top-Left with Bottom-Right)
            Mat tmp = new Mat();                           
            q0.CopyTo(tmp);
            q3.CopyTo(q0);
            tmp.CopyTo(q3);

            // swap quadrant (Top-Right with Bottom-Left)
            q1.CopyTo(tmp);                    
            q2.CopyTo(q1);
            tmp.CopyTo(q2);

            // Transform the matrix with float values into a
            Cv2.Normalize(spectrum, spectrum, 0, 1, NormType.MinMax); 
                                     
            // Show the result
            Cv2.ImShow("Input Image"       , img);
            Cv2.ImShow("Spectrum Magnitude", spectrum);

            // calculating the idft
            Mat inverseTransform = new Mat();
            Cv2.Dft(dft, inverseTransform, DftFlag2.Inverse | DftFlag2.RealOutput);
            Cv2.Normalize(inverseTransform, inverseTransform, 0, 1, NormType.MinMax);
            Cv2.ImShow("Reconstructed by Inverse DFT", inverseTransform);
            Cv2.WaitKey();
        }
    }
}