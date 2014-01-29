using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp.Blob;
using OpenCvSharp.CPlusPlus.Prototype;

namespace OpenCvSharp.Sandbox
{
    /// <summary>
    /// 書き捨てのコード。
    /// うまくいったらSampleに移管
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Mat mat = CvCpp.ImRead(@"img\shapes.png");

            CvCpp.ImShow("window", mat);
            CvCpp.WaitKey();
        }
    }
}
