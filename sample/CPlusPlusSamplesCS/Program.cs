using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPlusPlusSamplesCS
{
    class Program
    {
        static void Main(string[] args)
        {
            ISample sample =
                //new FASTSample();
                //new FlannSample(); // Todo: crash
                //new HOGSample();
                //new HoughLinesSample();
                //new MSERSample();
                new MDS();
                //new PixelAccess();
                //new StarDetectorSample();
                //new StereoCorrespondence();
            sample.Run();
        }
    }
}
