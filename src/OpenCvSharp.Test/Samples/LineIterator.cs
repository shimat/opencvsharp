using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// CvLineIterator sample
    /// </summary>
    /// <remarks>http://opencv.jp/opencv-1.1.0/document/opencvref_cxcore_point.html#decl_cvInitLineIterator</remarks>
    class LineIterator
    {
        public LineIterator()
        {
            using (IplImage image = new IplImage(Const.ImageLenna, LoadMode.Color))
            {
                CvPoint pt1 = new CvPoint(30, 100);
                CvPoint pt2 = new CvPoint(500, 400);

                CvScalar result;
                result = SumLinePixelsNative(image, pt1, pt2);      // native style
                result = SumLinePixelsManaged(image, pt1, pt2);     // wrapper style
                Console.WriteLine(result.ToString());

                Cv.Line(image, pt1, pt2, CvColor.Red, 3, LineType.Link8);

                using (new CvWindow("line", image))
                {
                    Cv.WaitKey();
                }
            }
        }

        /// <summary>
        /// Calculate sum of line pixels (native style)
        /// </summary>
        /// <param name="image"></param>
        /// <param name="pt1"></param>
        /// <param name="pt2"></param>
        /// <returns></returns>
        private CvScalar SumLinePixelsNative(IplImage image, CvPoint pt1, CvPoint pt2)
        {
            CvLineIterator iterator;
            int blue_sum = 0, green_sum = 0, red_sum = 0;
            int count = Cv.InitLineIterator(image, pt1, pt2, out iterator, PixelConnectivity.Connectivity_8, false);

            for (int i = 0; i < count; i++)
            {
                blue_sum += Marshal.ReadByte(iterator.Ptr, 0);  //blue_sum += iterator.ptr[0];
                green_sum += Marshal.ReadByte(iterator.Ptr, 1); //green_sum += iterator.ptr[1];
                red_sum += Marshal.ReadByte(iterator.Ptr, 2);   //red_sum += iterator.ptr[2];

                Cv.NEXT_LINE_POINT(iterator);

                PrintCoordinate(image, iterator);
            }
            return new CvScalar(blue_sum, green_sum, red_sum);
        }

        /// <summary>
        /// Calculate sum of line pixels (wrapper style)
        /// </summary>
        /// <param name="image"></param>
        /// <param name="pt1"></param>
        /// <param name="pt2"></param>
        /// <returns></returns>
        private CvScalar SumLinePixelsManaged(IplImage image, CvPoint pt1, CvPoint pt2)
        {            
            double blue_sum = 0, green_sum = 0, red_sum = 0;
            CvLineIterator iterator = new CvLineIterator(image, pt1, pt2, PixelConnectivity.Connectivity_8, false);

            foreach (CvScalar pixel in iterator)
            {
                blue_sum += pixel.Val0;   //blue_sum += iterator.ptr[0];
                green_sum += pixel.Val1;  //green_sum += iterator.ptr[1];
                red_sum += pixel.Val2;    //red_sum += iterator.ptr[2];

                PrintCoordinate(image, iterator);
            }
            return new CvScalar(blue_sum, green_sum, red_sum);
        }

        /// <summary>
        /// Print current pixel's coordinate
        /// </summary>
        /// <param name="image"></param>
        /// <param name="iterator"></param>
        private void PrintCoordinate(IplImage image, CvLineIterator iterator)
        {
            /* ROIは設定されていないと仮定している．もし設定されている場合には考慮する必要がある．*/
            int offset = iterator.Ptr.ToInt32() - image.ImageData.ToInt32();
            int y = offset / image.WidthStep;
            int x = (offset - y * image.WidthStep) / (3 * sizeof(byte) /* ピクセルのサイズ */);
            Console.WriteLine("(x:{0}, y:{1})", x, y);
        }
    }
}
