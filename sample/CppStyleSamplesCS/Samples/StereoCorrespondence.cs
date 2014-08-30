using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using SampleBase;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// ステレオマッチング
    /// </summary>
    class StereoCorrespondence : ISample
    {
        public StereoCorrespondence()
        {
        }

        public void Run()
        {
            // Load left&right images
            using (var imgLeft = new IplImage(FilePath.Image.TsukubaLeft, LoadMode.GrayScale))
            using (var imgRight = new IplImage(FilePath.Image.TsukubaRight, LoadMode.GrayScale))
            {
                // output image buffers
                using (var dispBM = new IplImage(imgLeft.Size, BitDepth.S16, 1))
                using (var dispLeft = new IplImage(imgLeft.Size, BitDepth.S16, 1))
                using (var dispRight = new IplImage(imgLeft.Size, BitDepth.S16, 1))
                using (var dstBM = new IplImage(imgLeft.Size, BitDepth.U8, 1))
                using (var dstGC = new IplImage(imgLeft.Size, BitDepth.U8, 1))
                using (var dstAux = new IplImage(imgLeft.Size, BitDepth.U8, 1))
                using (var dstSGBM = new Mat())
                {
                    // measures distance and scales
                    const int sad = 3;
                    using (var stateBM = new CvStereoBMState(StereoBMPreset.Basic, 16))
                    using (var stateGC = new CvStereoGCState(16, 2))
                    using (var sgbm = new StereoSGBM() // C++
                        {
                            MinDisparity = 0,
                            NumberOfDisparities = 32,
                            PreFilterCap = 63,
                            SADWindowSize = sad,
                            P1 = 8 * imgLeft.NChannels * sad * sad,
                            P2 = 32 * imgLeft.NChannels * sad * sad,
                            UniquenessRatio = 10,
                            SpeckleWindowSize = 100,
                            SpeckleRange = 32,
                            Disp12MaxDiff = 1,
                            FullDP = false,
                        })
                    {
                        Cv.FindStereoCorrespondenceBM(imgLeft, imgRight, dispBM, stateBM);   
                        Cv.FindStereoCorrespondenceGC(imgLeft, imgRight, dispLeft, dispRight, stateGC, false); 
                        Cv.FindStereoCorrespondence(imgLeft, imgRight, DisparityMode.Birchfield, dstAux, 50, 25, 5, 12, 15, 25); // cvaux
                        sgbm.Compute(new Mat(imgLeft), new Mat(imgRight), dstSGBM);

                        Cv.ConvertScale(dispBM, dstBM, 1);
                        Cv.ConvertScale(dispLeft, dstGC, -16);
                        Cv.ConvertScale(dstAux, dstAux, 16);
                        dstSGBM.ConvertTo(dstSGBM, dstSGBM.Type(), 32, 0);                     

                        using (new CvWindow("Stereo Correspondence (BM)", dstBM))
                        using (new CvWindow("Stereo Correspondence (GC)", dstGC))
                        using (new CvWindow("Stereo Correspondence (cvaux)", dstAux))
                        using (new CvWindow("Stereo Correspondence (SGBM)", dstSGBM.ToIplImage()))
                        {
                            Cv.WaitKey();
                        }
                    }
                }
            }
        }
    }
}
