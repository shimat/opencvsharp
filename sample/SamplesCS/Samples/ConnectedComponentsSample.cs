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
            Mat src = new Mat("Data/Image/shapes.png", LoadMode.Color);
            Mat gray = src.CvtColor(ColorConversion.BgrToGray);
            Mat binary = gray.Threshold(0, 255, ThresholdType.Otsu | ThresholdType.Binary);
            Mat labelView = src.EmptyClone();
            Mat rectView = binary.CvtColor(ColorConversion.GrayToBgr);

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
            ConnectedComponents.Blob maxBlob = cc.GetLargestBlob();
            Mat filtered = cc.FilterByBlob(src, maxBlob);

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