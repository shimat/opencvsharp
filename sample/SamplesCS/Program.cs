using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace SamplesCS
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ISample sample =
                //new ClaheTest();
                //new BgSubtractorMOG();  
                //new VideoWriterSample();
                //new VideoCaptureSample();
                //new MatToBitmap();
                //new SiftSurfSample();
                //new HistSample();
                //new Subdiv2DSample();
                //new FASTSample();
                //new FlannSample(); 
                //new HOGSample();
                //new HoughLinesSample();
                //new MSERSample();
                //new MDS();
                //new DFT();
                //new PixelAccess();
                //new MorphologySample();
                //new MergeSplitSample();
                //new NormalArrayOperations();
                //new SolveEquation();
                //new MatOperations();
                //new FaceDetection();
                //new SuperResolutionSample();
                new SVMSample();
                //new StarDetectorSample();
                //new BRISKSample();
                //new FREAKSample();
                //new Stitching();
            sample.Run();
        }
    }
}
