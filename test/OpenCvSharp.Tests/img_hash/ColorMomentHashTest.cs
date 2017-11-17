using System;
using OpenCvSharp.ImgHash;
using Xunit;

namespace OpenCvSharp.Tests.ImgHash
{
    public class ColorMomentHashTest : TestBase
    {
        [Fact]
        public void CreateAndDispose()
        {
            using (var model = ColorMomentHash.Create())
            {
                GC.KeepAlive(model);
            }
        }

        [Fact]
        public void Compute()
        {
            using (var model = ColorMomentHash.Create())
            using (var img = Image("lenna.png"))
            using (var hash = new MatOfDouble())
            {
                model.Compute(img, hash);
                Assert.Equal(1, hash.Rows);
                Assert.Equal(42, hash.Cols);
                Assert.Equal(MatType.CV_64FC1, hash.Type());

                var hashArray = hash.ToArray();
                Assert.Equal(
                    new double[] {
                        0.00168819565895133, 9.69274323413482E-09, 7.15987637898653E-12, 1.58221230845821E-10, 5.30132640226369E-21, 1.29174445409783E-14,
                        5.05488594422795E-22, 0.00128582879665923, 9.54461083144018E-10, 3.93406825147193E-12, 7.14101055135503E-12, 3.77862605260528E-23,
                        1.97867503074794E-16, 2.18751322086428E-24, 0.000922420923231133, 3.66078199965787E-09, 7.66904362623121E-13, 1.19544776529889E-12,
                        -1.12961325893555E-24, -5.93904771577414E-17, -1.84824480251793E-25, 0.00132532781142086, 9.1266053151516E-09, 3.35010536084133E-12,
                        9.88703855128973E-12, 1.52916239933584E-25, -9.17283073278845E-16, 5.69019311750733E-23, 0.00099662162473446, 1.90988729313945E-10,
                        1.81949836361996E-13, 1.60681443129224E-13, -2.72531646791605E-26, 1.04472248518881E-18, -3.4777107678675E-27, 0.00139982088736603,
                        2.27107975098039E-09, 4.41840703628873E-13, 7.2892000615472E-13, -4.0962177932807E-25, 3.10975156243194E-17, -5.77217024628191E-26 },
                    hashArray, new DoubleEqualityComparer(1E-12));
            }
        }

        [Fact]
        public void CompareSameImage()
        {
            using (var model = ColorMomentHash.Create())
            using (var img1 = Image("lenna.png", ImreadModes.GrayScale))
            {
                double hash = model.Compare(img1, img1);
                Assert.Equal(0, hash, 6);
            }
        }

        [Fact]
        public void CompareDifferentImage()
        {
            using (var model = ColorMomentHash.Create())
            using (var img1 = Image("lenna.png", ImreadModes.GrayScale))
            using (var img2 = Image("building.jpg", ImreadModes.GrayScale))
            {
                var size = new Size(256, 256);
                using (var scaledImg1 = img1.Resize(size))
                using (var scaledImg2 = img2.Resize(size))
                {
                    double hash = model.Compare(scaledImg1, scaledImg2);
                    Assert.Equal(236458999.828723, hash, 6);
                }
            }
        }
    }
}
