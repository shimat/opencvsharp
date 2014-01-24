using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Src.Class
{
    public class KmeansInput
    {
        Array Samples { get; set; }
        MatrixType SamplesType { get; set; }
        int NClusters { get; set; }
        CvTermCriteria Criteria { get; set; }
        int[] Labels { get; set; }
        int Attemps { get; set; }
        CvRNG Rng { get; set; }
        KMeansFlag Flags { get; set; }
        

        public KmeansInput(Array samples, MatrixType samplesType, int nClusters, CvTermCriteria criteria)
        {
            Samples = samples;
            SamplesType = samplesType;
            NClusters = nClusters;
            Criteria = criteria;
        }
    }

    class KmeansOutput
    {
        
    }
}
