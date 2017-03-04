using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenCvSharp.ML;

namespace OpenCvSharp.Tests.Core
{
    [TestFixture]
    public class AlgorithmTest : TestBase
    {
        [Test]
        public void GetDefaultName()
        {
            using (var model = SVM.Create())
            {
                Assert.AreEqual("opencv_ml_svm", model.GetDefaultName());
            }
        }
    }
}

