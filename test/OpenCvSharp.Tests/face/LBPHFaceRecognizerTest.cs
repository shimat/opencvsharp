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
            var recognizer = LBPHFaceRecognizer.Create(1, 8, 8, 8, 123);
            recognizer.Dispose();
        }

        [Fact]
        public void TrainAndPredict()
        {
            using (var image = Image("lenna.png"))
            using (var grayImage = image.CvtColor(ColorConversionCodes.BGR2GRAY))
            using (var model = LBPHFaceRecognizer.Create())
            using (var cascade = new CascadeClassifier("_data/text/haarcascade_frontalface_default.xml"))
            {
                var rects = cascade.DetectMultiScale(image);

                model.Train(new[] { grayImage }, new[] { 1 });

                foreach (Rect rect in rects)
                {
                    using (Mat face = grayImage[rect].Clone())
                    {
                        Cv2.Resize(face, face, new Size(256, 256));

                        model.Predict(face, out int label, out double confidence);

                        Console.WriteLine($"{label} ({confidence})");
                        Assert.Equal(1, label);
                        Assert.NotEqual(0, confidence, 9);
                    }
                }
            }
        }
    }
}

