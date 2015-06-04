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
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ISample sample =
                new ClaheTest();
                //new BgSubtractorMOG();  
                //new VideoWriterSample();
                //new VideoCaptureSample();
                //new MatToBitmap();
                //new MatToIplImage();
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
                //new StereoCorrespondence();
                //new MorphologySample();
                //new MergeSplitSample();
                //new NormalArrayOperations();
                //new SolveEquation();
                //new MatOperations();
                //new FaceDetection();
                //new SuperResolutionSample();
                //new DTree();
                //new LetterRecog();
                //new SVM();
                //new StarDetectorSample();
                //new BRISKSample();
                //new FREAKSample();
                //new Stitching();
            sample.Run();
        }
    }
}
