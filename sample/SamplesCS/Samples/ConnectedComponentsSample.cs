using System.Linq;
using OpenCvSharp;

namespace SamplesCS
{
    /// <summary>
    /// 
    /// </summary>
    class ConnectedComponentsSample : ISample
    {
        public void Run()
        {
            Mat src = new Mat("Data/Image/shapes.png", ImreadModes.Color);
            Mat gray = src.CvtColor(ColorConversionCodes.BGR2GRAY);
            Mat binary = gray.Threshold(0, 255, ThresholdTypes.Otsu | ThresholdTypes.Binary);
            Mat labelView = src.EmptyClone();
            Mat rectView = binary.CvtColor(ColorConversionCodes.GRAY2BGR);

            ConnectedComponents cc = Cv2.ConnectedComponentsEx(binary);
            if (cc.LabelCount <= 1)
                return;

            // draw labels
            cc.RenderBlobs(labelView);

            // draw bonding boxes except background
            foreach (var blob in cc.Blobs.Skip(1))
            {
                rectView.Rectangle(blob.Rect, Scalar.Red);
            }

            // filter maximum blob
            var maxBlob = cc.GetLargestBlob();
            var filtered = new Mat();
            cc.FilterByBlob(src, filtered, maxBlob);

            using (new Window("src", src))
            using (new Window("binary", binary))
            using (new Window("labels", labelView))
            using (new Window("bonding boxes", rectView))
            using (new Window("maximum blob", filtered))
            {
                Cv2.WaitKey();
            }
        }
    }
}