using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace OpenCvSharp.Tests.Features2D
{
    [TestFixture]
    public class BOWKMeansTrainerTest : TestBase
    {
        [Test]
        public void New()
        {
            var bow = new BOWKMeansTrainer(100);
            bow.Dispose();
        }
    }
}

