using OpenCvSharp;
using SampleBase;

namespace SamplesCS
{
    /// <summary>
    /// cv::seamlessClone
    /// </summary>
    class SeamlessClone : ISample
    {
        public void Run()
        {
            Mat src = new Mat(FilePath.Image.Girl, ImreadModes.Color);
            Mat dst = new Mat(FilePath.Image.Lenna, ImreadModes.Color);
            Mat src0 = src.Resize(dst.Size(), 0, 0, InterpolationFlags.Lanczos4);
            Mat mask = Mat.Zeros(src0.Size(), MatType.CV_8UC3);

            mask.Circle(200, 200, 100, Scalar.White, -1);

            Mat blend1 = new Mat();
            Mat blend2 = new Mat();
            Mat blend3 = new Mat();
            Cv2.SeamlessClone(
                src0, dst, mask, new Point(260, 270), blend1,
                SeamlessCloneMethods.NormalClone);
            Cv2.SeamlessClone(
                src0, dst, mask, new Point(260, 270), blend2,
                SeamlessCloneMethods.MonochromeTransfer);
                        Cv2.SeamlessClone(
                src0, dst, mask, new Point(260, 270), blend3,
                SeamlessCloneMethods.MixedClone);

            using (new Window("src", src0))
            using (new Window("dst", dst))
            using (new Window("mask", mask))
            using (new Window("blend NormalClone", blend1))
            using (new Window("blend MonochromeTransfer", blend2))
            using (new Window("blend MixedClone", blend3))
            {
                Cv2.WaitKey();
            }
        }
    }
}