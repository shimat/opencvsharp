using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace OpenCvSharp.Tests.Features2d
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

