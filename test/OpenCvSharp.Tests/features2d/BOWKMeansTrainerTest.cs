using System;
using System.Collections.Generic;
using Xunit;

namespace OpenCvSharp.Tests.Features2D
{
    public class BOWKMeansTrainerTest : TestBase
    {
        [Fact]
        public void New()
        {
            var bow = new BOWKMeansTrainer(100);
            bow.Dispose();
        }
    }
}

