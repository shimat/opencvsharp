using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// 輪郭の検出を行い，木構造を持つ輪郭データから座標を取り出す.
    /// </summary>
    /// <remarks>http://opencv.jp/sample/tree.html#contour_treenode</remarks>
    class TreeNodeIterator
    {
        public TreeNodeIterator()
        {
            using (CvMemStorage storage = new CvMemStorage(0))
            using (IplImage srcImg = new IplImage(FilePath.Image.Lenna, LoadMode.Color))
            using (IplImage srcImgGray = new IplImage(srcImg.Size, BitDepth.U8, 1))
            using (IplImage tmpImg = new IplImage(srcImg.Size, BitDepth.U8, 1))
            {
                Cv.CvtColor(srcImg, srcImgGray, ColorConversion.BgrToGray);

                Cv.Threshold(srcImgGray, tmpImg, 120, 255, ThresholdType.Binary);
                CvSeq<CvPoint> contours;
                Cv.FindContours(tmpImg, storage, out contours, CvContour.SizeOf, ContourRetrieval.Tree, ContourChain.ApproxSimple);

                using (CvFileStorage fs = new CvFileStorage("contours.yaml", null, FileStorageMode.Write))
                {
                    CvTreeNodeIterator<CvSeq<CvPoint>> it = new CvTreeNodeIterator<CvSeq<CvPoint>>(contours, 1);

                    foreach(CvSeq<CvPoint> contour in it)
                    {
                        fs.StartWriteStruct("contour", NodeType.Seq);

                        CvPoint tmp = contour[-1].Value;
                        for (int i = 0; i < contour.Total; i++)
                        {
                            CvPoint point = contour[i].Value;
                            srcImg.Line(tmp, point, CvColor.Blue, 2);
                            fs.StartWriteStruct(null, NodeType.Map | NodeType.Flow);
                            fs.WriteInt("x", point.X);
                            fs.WriteInt("y", point.Y);
                            fs.EndWriteStruct();
                            tmp = point;
                        }
                        fs.EndWriteStruct();
                    }
                }

                Console.WriteLine(File.ReadAllText("contours.yaml"));

                using (new CvWindow("Contours", srcImg))
                {
                    Cv.WaitKey(0);
                }
            }
        }
    }
}
