using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CppStyleSamplesCS
{
    class Program
    {
        static void Main(string[] args)
        {
            ISample sample =
                new MatToIplImage();
                //new FASTSample();
                //new FlannSample(); // Todo: crash
                //new HOGSample();
                //new HoughLinesSample();
                //new MSERSample();
                //new MDS();
                //new PixelAccess();
                //new StarDetectorSample();
                //new StereoCorrespondence();
                //new MorphologySample();
                //new MergeSplitSample();
                //new NormalArrayOperations();
            sample.Run();
        }
    }
}
