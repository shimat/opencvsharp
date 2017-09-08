using System;
using System.Collections.Generic;
using OpenCvSharp.ML;
using Xunit;

namespace OpenCvSharp.Tests.Core
{
    public class AlgorithmTest : TestBase
    {
        [Fact]
        public void GetDefaultName()
        {
            using (var model = SVM.Create())
            {
                Assert.Equal("opencv_ml_svm", model.GetDefaultName());
            }
        }
    }
}

