using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
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
            using (IplImage srcImg = new IplImage(Const.ImageLenna, LoadMode.Color))
            using (IplImage srcImgGray = new IplImage(srcImg.Size, BitDepth.U8, 1))
            using (IplImage tmpImg = new IplImage(srcImg.Size, BitDepth.U8, 1))
            {
                Cv.CvtColor(srcImg, srcImgGray, ColorConversion.BgrToGray);

                // (1)画像の二値化と輪郭の検出
                Cv.Threshold(srcImgGray, tmpImg, 120, 255, ThresholdType.Binary);
                CvSeq<CvPoint> contours;
                Cv.FindContours(tmpImg, storage, out contours, CvContour.SizeOf, ContourRetrieval.Tree, ContourChain.ApproxSimple);
                /* 輪郭シーケンスから座標を取得 */
                using (CvFileStorage fs = new CvFileStorage("contours.yaml", null, FileStorageMode.Write))
                {
                    // (2)ツリーノードイテレータの初期化
                    CvTreeNodeIterator<CvSeq<CvPoint>> it = new CvTreeNodeIterator<CvSeq<CvPoint>>(contours, 1);
                    // (3)各ノード（輪郭）を走査
                    //CvSeq<CvPoint> contour;
                    //while ((contour = it.NextTreeNode()) != null)
                    foreach(CvSeq<CvPoint> contour in it)
                    {
                        fs.StartWriteStruct("contour", NodeType.Seq);
                        // (4)輪郭を構成する頂点座標を取得
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
