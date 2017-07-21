using System;
using System.Diagnostics;
using NUnit.Framework;

namespace OpenCvSharp.Tests.Video
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class BackgroundSubtractorMOG2Test : TestBase
    {
        [Test]
        public void CheckProperties()
        {
            using (var mog = BackgroundSubtractorMOG2.Create())
            {
                mog.BackgroundRatio = mog.BackgroundRatio;
                mog.ComplexityReductionThreshold = mog.ComplexityReductionThreshold;
                mog.DetectShadows = mog.DetectShadows;
                mog.History = mog.History;
                mog.NMixtures = mog.NMixtures;
                mog.ShadowThreshold = mog.ShadowThreshold;
                mog.ShadowValue = mog.ShadowValue;
                mog.VarInit = mog.VarInit;
                mog.VarMax = mog.VarMax;
                mog.VarMin = mog.VarMin;
                mog.VarThreshold = mog.VarThreshold;
                mog.VarThresholdGen = mog.BackgroundRatio;
            }
        }

        [Test]
        public void Apply()
        {
            using (var mog = BackgroundSubtractorMOG2.Create())
            using (var src = Image("lenna.png"))
            using (var dst = new Mat())
            {
                mog.Apply(src, dst);
            }
        }
    }
}
