using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace CPlusPlusSamplesCS
{
    /// <summary>
    /// 
    /// </summary>
    class MergeSplitSample : ISample
    {
        public void Run()
        {
            Mat src = new Mat(ImagePath.Lenna, LoadMode.Color);

            // Split each plane
            Mat[] planes;
            Cv2.Split(src, out planes);

            Cv2.ImShow("planes 0", planes[0]);
            Cv2.ImShow("planes 1", planes[1]);
            Cv2.ImShow("planes 2", planes[2]);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();

            // Invert G plane
            Cv2.BitwiseNot(planes[1], planes[1]);

            // Merge
            Mat merged = new Mat();
            Cv2.Merge(planes, merged);

            Cv2.ImShow("src", src);
            Cv2.ImShow("merged", merged);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}