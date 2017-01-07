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
                //new BgSubtractorMOG();
                //new BinarizerSample();
                //new BRISKSample();
                //new ClaheSample();
                new ConnectedComponentsSample();
                //new DFT();
                //new FaceDetection();
                //new FASTSample();
                //new FlannSample(); 
                //new FREAKSample();
                //new HistSample();
                //new HOGSample();
                //new HoughLinesSample();
                //new KAZESample2();
                //new KAZESample();
                //new MatOperations();
                //new MatToBitmap();
                //new MDS();
                //new MSERSample();
                //new NormalArrayOperations();
                //new PhotoMethods();
                //new MergeSplitSample();
                //new MorphologySample();
                //new PixelAccess();
                //new SeamlessClone();
                //new SiftSurfSample();
                //new SolveEquation();
                //new StarDetectorSample();
                //new Stitching();
                //new Subdiv2DSample();
                //new SuperResolutionSample();
                //new SVMSample();
                //new VideoWriterSample();
                //new VideoCaptureSample();
                               
            sample.Run();
        }
    }
}
