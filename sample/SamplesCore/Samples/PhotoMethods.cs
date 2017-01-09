using OpenCvSharp;

namespace SamplesCore
{
    /// <summary>
    /// sample of photo module methods
    /// </summary>
    class PhotoMethods : ISample
    {
        public void Run()
        {
            Mat src = new Mat(FilePath.Image.Fruits, ImreadModes.Color);

            Mat normconv = new Mat(), recursFildered = new Mat();
            Cv2.EdgePreservingFilter(src, normconv, EdgePreservingMethods.NormconvFilter);
            Cv2.EdgePreservingFilter(src, recursFildered, EdgePreservingMethods.RecursFilter);

            Mat detailEnhance = new Mat();
            Cv2.DetailEnhance(src, detailEnhance);

            Mat pencil1 = new Mat(), pencil2 = new Mat();
            Cv2.PencilSketch(src, pencil1, pencil2);

            Mat stylized = new Mat();
            Cv2.Stylization(src, stylized);

            using (new Window("src", src))
            using (new Window("edgePreservingFilter - NormconvFilter", normconv))
            using (new Window("edgePreservingFilter - RecursFilter", recursFildered))
            using (new Window("detailEnhance", detailEnhance))
            using (new Window("pencilSketch grayscale", pencil1))
            using (new Window("pencilSketch color", pencil2))
            using (new Window("stylized", stylized))
            {
                Cv2.WaitKey();
            }
        }
    }
}