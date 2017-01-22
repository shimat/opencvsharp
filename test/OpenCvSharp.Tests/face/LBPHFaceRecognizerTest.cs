using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace OpenCvSharp.Tests.Face
{
    [TestFixture]
    public class LBPHFaceRecognizerTest
    {
        [Test]
        public void New()
        {
            var recognizer = OpenCvSharp.Face.FaceRecognizer.CreateLBPHFaceRecognizer(1, 8, 8, 8, 123);
            recognizer.Dispose();
        }
    }
}

