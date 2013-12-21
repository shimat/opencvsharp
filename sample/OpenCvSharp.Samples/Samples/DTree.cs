using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.MachineLearning;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// samples/c/mushroom.c
    /// </summary>
    /// <remarks>
    /// The sample demonstrates how to build a decision tree for classifying mushrooms.
    /// It uses the sample base agaricus-lepiota.data from UCI Repository, here is the link:
    ///
    /// Newman, D.J. & Hettich, S. & Blake, C.L. & Merz, C.J. (1998).
    /// UCI Repository of machine learning databases
    /// [http://www.ics.uci.edu/~mlearn/MLRepository.html].
    /// Irvine, CA: University of California, Department of Information and Computer Science.
    /// </remarks>
    class DTree
    {    
        private readonly string[] VarDesc = new string[]
        {
            "cap shape (bell=b,conical=c,convex=x,flat=f)",
            "cap surface (fibrous=f,grooves=g,scaly=y,smooth=s)",
            "cap color (brown=n,buff=b,cinnamon=c,gray=g,green=r,\n\tpink=p,purple=u,red=e,white=w,yellow=y)",
            "bruises? (bruises=t,no=f)",
            "odor (almond=a,anise=l,creosote=c,fishy=y,foul=f,\n\tmusty=m,none=n,pungent=p,spicy=s)",
            "gill attachment (attached=a,descending=d,free=f,notched=n)",
            "gill spacing (close=c,crowded=w,distant=d)",
            "gill size (broad=b,narrow=n)",
            "gill color (black=k,brown=n,buff=b,chocolate=h,gray=g,\n\tgreen=r,orange=o,pink=p,purple=u,red=e,white=w,yellow=y)",
            "stalk shape (enlarging=e,tapering=t)",
            "stalk root (bulbous=b,club=c,cup=u,equal=e,rhizomorphs=z,rooted=r)",
            "stalk surface above ring (ibrous=f,scaly=y,silky=k,smooth=s)",
            "stalk surface below ring (ibrous=f,scaly=y,silky=k,smooth=s)",
            "stalk color above ring (brown=n,buff=b,cinnamon=c,gray=g,orange=o,\n\tpink=p,red=e,white=w,yellow=y)",
            "stalk color below ring (brown=n,buff=b,cinnamon=c,gray=g,orange=o,\n\tpink=p,red=e,white=w,yellow=y)",
            "veil type (partial=p,universal=u)",
            "veil color (brown=n,orange=o,white=w,yellow=y)",
            "ring number (none=n,one=o,two=t)",
            "ring type (cobwebby=c,evanescent=e,flaring=f,large=l,\n\tnone=n,pendant=p,sheathing=s,zone=z)",
            "spore print color (black=k,brown=n,buff=b,chocolate=h,green=r,\n\torange=o,purple=u,white=w,yellow=y)",
            "population (abundant=a,clustered=c,numerous=n,\n\tscattered=s,several=v,solitary=y)",
            "habitat (grasses=g,leaves=l,meadows=m,paths=p\n\turban=u,waste=w,woods=d)",
        };

        /// <summary>
        /// main
        /// </summary>
        public DTree()
        {
            CvMat data;
            CvMat missing;
            CvMat responses;
            CvDTree dtree;

            if (!MushroomReadDatabase(Const.DataMushroom, out data, out missing, out responses))
            {
                Console.WriteLine("Unable to load the training database\n" +
                                  "Pass it as a parameter: dtree <path to agaricus-lepiota.data>\n");
                return;
            }
            
            dtree = MushroomCreateDTree(
                data, missing, responses,
                10 // poisonous mushrooms will have 10x higher weight in the decision tree
            );

            PrintVariableImportance(dtree);
            InteractiveClassification(dtree);

            data.Dispose();
            missing.Dispose();
            responses.Dispose();
            dtree.Dispose();

            Console.Read();
        }


        /// <summary>
        /// loads the mushroom database, which is a text file, containing
        /// one training sample per row, all the input variables and the output variable are categorical,
        /// the values are encoded by characters.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <param name="missing"></param>
        /// <param name="responses"></param>
        /// <returns></returns>
        private bool MushroomReadDatabase(string filename, out CvMat data, out CvMat missing, out CvMat responses)
        {
            data = null;
            missing = null;
            responses = null;

            int varCount = 0;
            List<float[]> seq = new List<float[]>();

            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string buf;

                    // read the first line and determine the number of variables
                    buf = sr.ReadLine();
                    foreach (char c in buf)
                    {
                        varCount += (c == ',') ? 1 : 0;
                    }

                    for (; ; )
                    {
                        // create temporary memory storage to store the whole database
                        float[] elPtr = new float[varCount + 1];

                        int i;
                        for (i = 0; i <= varCount; i++)
                        {
                            char c = buf[i * 2];
                            elPtr[i] = (c == '?') ? -1.0f : (float)c;
                        }                        
                        if (i != varCount + 1)
                        {
                            break;
                        }
                        seq.Add(elPtr);
                        buf = sr.ReadLine();
                        if (buf == null || buf.IndexOf(',') == -1)
                        {
                            break;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }

            // allocate the output matrices and copy the base there
            data = new CvMat(seq.Count, varCount, MatrixType.F32C1);
            missing = new CvMat(seq.Count, varCount, MatrixType.U8C1);
            responses = new CvMat(seq.Count, 1, MatrixType.F32C1);

            for (int i = 0; i < seq.Count; i++)
            {
                unsafe
                {
                    fixed (float* _sdata = seq[i])
                    {
                        float* sdata = _sdata + 1;
                        float* ddata = data.DataSingle + (varCount * i);
                        float* dr = responses.DataSingle + i;
                        byte* dm = missing.DataByte + (varCount * i);

                        for (int j = 0; j < varCount; j++)
                        {
                            ddata[j] = sdata[j];
                            dm[j] = (sdata[j] < 0) ? (byte)1 : (byte)0;
                        }
                        *dr = sdata[-1];
                    }
                }
            }

            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="missing"></param>
        /// <param name="responses"></param>
        /// <param name="pWeight"></param>
        /// <returns></returns>
        private CvDTree MushroomCreateDTree(CvMat data, CvMat missing, CvMat responses, float pWeight)
        {
            float[] priors = { 1, pWeight };

            CvMat varType = new CvMat(data.Cols + 1, 1, MatrixType.U8C1);
            Cv.Set(varType, CvScalar.ScalarAll(CvStatModel.CV_VAR_CATEGORICAL)); // all the variables are categorical

            CvDTree dtree = new CvDTree();

            CvDTreeParams p = new CvDTreeParams(8, // max depth
                                            10, // min sample count
                                            0, // regression accuracy: N/A here
                                            true, // compute surrogate split, as we have missing data
                                            15, // max number of categories (use sub-optimal algorithm for larger numbers)
                                            10, // the number of cross-validation folds
                                            true, // use 1SE rule => smaller tree
                                            true, // throw away the pruned tree branches
                                            priors // the array of priors, the bigger p_weight, the more attention
                // to the poisonous mushrooms
                // (a mushroom will be judjed to be poisonous with bigger chance)
            );

            dtree.Train(data, DTreeDataLayout.RowSample, responses, null, null, varType, missing, p);

            // compute hit-rate on the training database, demonstrates predict usage.
            int hr1 = 0, hr2 = 0, pTotal = 0;
            for (int i = 0; i < data.Rows; i++)
            {
                CvMat sample, mask;
                Cv.GetRow(data, out sample, i);
                Cv.GetRow(missing, out mask, i);
                double r = dtree.Predict(sample, mask).Value;
                bool d = Math.Abs(r - responses.DataArraySingle[i]) >= float.Epsilon;
                if (d)
                {
                    if (r != 'p')
                        hr1++;
                    else
                        hr2++;
                }
                //Console.WriteLine(responses.DataArraySingle[i]);
                pTotal += (responses.DataArraySingle[i] == (float)'p') ? 1 : 0;
            }

            Console.WriteLine("Results on the training database");
            Console.WriteLine("\tPoisonous mushrooms mis-predicted: {0} ({1}%)", hr1, (double)hr1 * 100 / pTotal);
            Console.WriteLine("\tFalse-alarms: {0} ({1}%)", hr2, (double)hr2 * 100 / (data.Rows - pTotal));

            varType.Dispose();

            return dtree;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtree"></param>
        /// <param name="varDesc"></param>
        private void PrintVariableImportance(CvDTree dtree )
        {
            CvMat varImportance = dtree.GetVarImportance();

            if( varImportance == null )
            {
                Console.WriteLine( "Error: Variable importance can not be retrieved" );
                return;
            }

            Console.Write( "Print variable importance information? (y/n) " );
            string input = Console.ReadLine();
            if( input[0] != 'y' && input[0] != 'Y' )
            {
                return;
            }

            for (int i = 0; i < varImportance.Cols * varImportance.Rows; i++)
            {
                double val = varImportance.DataArrayDouble[i];
                int len = VarDesc[i].IndexOf('(');
                Console.Write("{0}", VarDesc[i].Substring(0, len));
                Console.WriteLine(": {0}%", val * 100.0);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtree"></param>
        private void InteractiveClassification(CvDTree dtree)
        {
            if (dtree == null)
            {
                return;
            }

            CvDTreeNode root = dtree.GetRoot();
            CvDTreeTrainData data = dtree.GetData();
            string input;

            for (; ; )
            {
                CvDTreeNode node;

                Console.Write("Start/Proceed with interactive mushroom classification (y/n): ");
                input = Console.ReadLine();
                if (input[0] != 'y' && input[0] != 'Y')
                {
                    break;
                }
                Console.WriteLine("Enter 1-letter answers, '?' for missing/unknown value...");

                // custom version of predict
                node = root;
                for (; ; )
                {
                    CvDTreeSplit split = node.Split;
                    int dir = 0;

                    if (node.Left == null || node.Tn <= dtree.GetPrunedTreeIdx() || node.Split == null)
                    {
                        break;
                    }

                    for (; split != null; )
                    {
                        int j;
                        int vi = split.VarIdx;
                        int count = data.CatCount.DataArrayInt32[vi];


                        Console.Write("{0}: ", VarDesc[vi]);
                        input = Console.ReadLine();


                        if (input[0] == '?')
                        {
                            split = split.Next;
                            continue;
                        }

                        // convert the input character to the normalized value of the variable
                        unsafe
                        {
                            int* map = data.CatMap.DataInt32 + data.CatOfs.DataInt32[vi];
                            for (j = 0; j < count; j++)
                            {
                                if (map[j] == input[0])
                                {
                                    break;
                                }
                            }
                        }

                        if (j < count)
                        {
                            dir = (split.Subset[j >> 5] & (1 << (j & 31))) != 0 ? -1 : 1;
                            if (split.Inversed)
                            {
                                dir = -dir;
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error: unrecognized value");
                        }
                    }

                    if (dir == 0)
                    {
                        Console.WriteLine("Impossible to classify the sample");
                        node = null;
                        break;
                    }
                    node = dir < 0 ? node.Left : node.Right;
                }

                if (node != null)
                {
                    Console.Write("Prediction result: the mushroom is {0}\n", node.ClassIdx == 0 ? "EDIBLE" : "POISONOUS");
                }
                Console.Write("\n-----------------------------\n");
            }
        }
    }
}
