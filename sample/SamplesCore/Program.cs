using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplesCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ISample sample =
                new ClaheSample();
                //new ConnectedComponentsSample();
                //new HOGSample();
                //new HoughLinesSample();
                //new MatOperations();
                //new NormalArrayOperations();
                //new PhotoMethods();
                //new MorphologySample();
                //new PixelAccess();
                //new SolveEquation();
                //new Subdiv2DSample();
                //new SVMSample();
                //new VideoWriterSample();
                //new VideoCaptureSample();

            sample.Run();
        }
    }
}
