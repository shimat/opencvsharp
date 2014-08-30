using System;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// CvContourScanner Sample
    /// </summary>
    class ContourScanner
    {
        public ContourScanner()
        {
            // create IplImages
            using (var src = new IplImage(FilePath.Image.Lenna, LoadMode.Color))
            using (var gray = new IplImage(src.Size, BitDepth.U8, 1))
            using (var canny = new IplImage(src.Size, BitDepth.U8, 1))
            using (var result = src.Clone())
            {
                // detect edges
                Cv.CvtColor(src, gray, ColorConversion.BgrToGray);
                Cv.Canny(gray, canny, 50, 200);

                // find all contours
                using (CvMemStorage storage = new CvMemStorage())
                {
                    // find contours by CvContourScanner

                    // native style
                    /*
                    CvContourScanner scanner = Cv.StartFindContours(canny, storage, CvContour.SizeOf, ContourRetrieval.Tree, ContourChain.ApproxSimple);
                    while (true)
                    {
                        CvSeq<CvPoint> c = Cv.FindNextContour(scanner);
                        if (c == null)
                            break;
                        else
                            Cv.DrawContours(result, c, CvColor.Red, CvColor.Green, 0, 3, LineType.AntiAlias);
                    }
                    Cv.EndFindContours(scanner);
                    //*/

                    // wrapper style
                    using (CvContourScanner scanner = new CvContourScanner(canny, storage, CvContour.SizeOf, ContourRetrieval.Tree, ContourChain.ApproxSimple))
                    {
                        foreach (CvSeq<CvPoint> c in scanner)
                        {
                            result.DrawContours(c, CvColor.Red, CvColor.Green, 0, 3, LineType.AntiAlias);
                        }
                    }                    
                }

                // show canny and result
                using (new CvWindow("ContourScanner canny", canny))
                using (new CvWindow("ContourScanner result", result))
                {
                    Cv.WaitKey();
                }             
            }
        }
    }
}
