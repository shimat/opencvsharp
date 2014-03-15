using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X64Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            ISample sample =
                new VideoWriterSample();
                //new VideoCaptureSample();
                //new FASTSample();
                //new HOGSample();
                //new HoughLinesSample();
                //new MSERSample();
                //new MDS();
                //new PixelAccess();
                //new StarDetectorSample();
                //new StereoCorrespondence();
                //new MorphologySample();
            sample.Run();
        }
    }
}
