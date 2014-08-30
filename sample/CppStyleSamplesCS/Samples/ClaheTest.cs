using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using SampleBase;

namespace CppStyleSamplesCS
{
    class ClaheTest : ISample
    {
        public void Run()
        {
            Mat src = new Mat(FilePath.Image.TsukubaLeft, LoadMode.GrayScale);
            Mat dst1 = new Mat();
            Mat dst2 = new Mat();
            Mat dst3 = new Mat();

            using (CLAHE clahe = Cv2.CreateCLAHE())
            {
                clahe.ClipLimit = 20;
                clahe.Apply(src, dst1);
                clahe.ClipLimit = 40;
                clahe.Apply(src, dst2);
                clahe.TilesGridSize = new Size(4, 4);
                clahe.Apply(src, dst3);
            }

            Window.ShowImages(
                new[]{src, dst1, dst2, dst3}, 
                new[]{"src", "dst clip20", "dst clip40", "dst tile4x4"});
        }
    }
}
