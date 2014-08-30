using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Watershed algorithm sample
    /// </summary>
    /// <remarks>http://opencv.jp/sample/segmentation_and_connection.html#watershed</remarks>
    class Watershed
    {
        public Watershed()
        {
            using (var srcImg = new IplImage(FilePath.Image.Goryokaku, LoadMode.AnyDepth | LoadMode.AnyColor))
            using (var dstImg = srcImg.Clone())
            using (var dspImg = srcImg.Clone())
            using (var markers = new IplImage(srcImg.Size, BitDepth.S32, 1))
            {
                markers.Zero();

                using (var window = new CvWindow("image", WindowMode.AutoSize))
                {
                    window.Image = srcImg;
                    // Mouse event  
                    int seedNum = 0;
                    window.OnMouseCallback += delegate(MouseEvent ev, int x, int y, MouseEvent flags)
                    {
                        if (ev == MouseEvent.LButtonDown)
                        {
                            seedNum++;
                            CvPoint pt = new CvPoint(x, y);
                            markers.Circle(pt, 20, CvScalar.ScalarAll(seedNum), Cv.FILLED, LineType.Link8, 0);
                            dspImg.Circle(pt, 20, CvColor.White, 3, LineType.Link8, 0);
                            window.Image = dspImg;
                        }
                    };
                    CvWindow.WaitKey();
                }

                Cv.Watershed(srcImg, markers);

                // draws watershed
                for (int i = 0; i < markers.Height; i++)
                {
                    for (int j = 0; j < markers.Width; j++)
                    {
                        int idx = (int)(markers.Get2D(i, j).Val0);
                        if (idx == -1)
                        {
                            dstImg.Set2D(i, j, CvColor.Red);
                        }
                    }
                }
                using (CvWindow wDst = new CvWindow("watershed transform", WindowMode.AutoSize))
                {
                    wDst.Image = dstImg;
                    CvWindow.WaitKey();
                }
            }

        }
    }
}
