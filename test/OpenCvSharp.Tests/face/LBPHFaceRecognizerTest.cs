using System;
using System.Collections.Generic;
using OpenCvSharp.Face;
using Xunit;

namespace OpenCvSharp.Tests.Face
{
    // ReSharper disable once InconsistentNaming

    public class LBPHFaceRecognizerTest : TestBase
    {
        [Fact]
        public void CreateAndDispose()
        {
            var recognizer = OpenCvSharp.Face.FaceRecognizer.CreateLBPHFaceRecognizer(1, 8, 8, 8, 123);
            recognizer.Dispose();
        }

        [Fact(Skip = "not implemented")]
        public void TrainAndPredict()
        {
            var image = new Mat("Data/Image/Lenna.png");

            var model = CvFace.CreateLBPHFaceRecognizer();

            var cascade = new CascadeClassifier("../haarcascade_frontalface_default.xml");
            var rects = cascade.DetectMultiScale(image);

            foreach (Rect rect in rects)
            {
                using (Mat face = image[rect].Clone())
                {
                    Cv2.Resize(face, face, new Size(256, 256));

                    int label;
                    double confidence;
                    model.Predict(face, out label, out confidence);
                    Console.WriteLine($"{label} ({confidence})");
                }
            }
        }
    }
}

