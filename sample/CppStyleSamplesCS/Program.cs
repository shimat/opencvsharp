using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace CppStyleSamplesCS
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ISample sample =
                //new BgSubtractorMOG();  
                //new VideoWriterSample();
                //new VideoCaptureSample();
                //new MatToBitmap();
                //new MatToIplImage();
                //new SiftSurfSample();
                new HistSample();
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
            sample.Run();
        }
    }
}
