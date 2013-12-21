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
    /// samples/c/letter_recog.cpp
    /// </summary>
    /// <remarks>
    /// The sample demonstrates how to train Random Trees classifier
    /// (or Boosting classifier, or MLP - see main()) using the provided dataset.
    /// 
    /// We use the sample database letter-recognition.data
    /// from UCI Repository, here is the link:
    /// 
    /// Newman, D.J. & Hettich, S. & Blake, C.L. & Merz, C.J. (1998).
    /// UCI Repository of machine learning databases
    /// [http://www.ics.uci.edu/~mlearn/MLRepository.html].
    /// Irvine, CA: University of California, Department of Information and Computer Science.
    ///
    /// The dataset consists of 20000 feature vectors along with the
    /// responses - capital latin letters A..Z.
    /// The first 16000 (10000 for boosting)) samples are used for training
    /// and the remaining 4000 (10000 for boosting) - to test the classifier.
    /// </remarks>
    class LetterRecog
    {
        /// <summary>
        /// !! Choose a classifier you want to use !!
        /// </summary>
        private readonly ClassifierType Classifier = ClassifierType.SVM;



        /// <summary>
        /// Entry point
        /// </summary>
        public LetterRecog()
        {
            ClassifierBuilder method;

            switch (Classifier)
            {
                case ClassifierType.RTrees:
                    method = BuildRtreesClassifier; break;
                case ClassifierType.Boost:
                    method = BuildBoostClassifier; break;
                case ClassifierType.MLP:
                    method = BuildMlpClassifier; break;
                case ClassifierType.SVM:
                    method = BuildSvmClassifier; break;
                default:
                    throw new NotImplementedException();
            }

            method(Const.DataLetterRecog, null, null);
        }
        /// <summary>
        /// 
        /// </summary>
        private enum ClassifierType { RTrees, Boost, MLP, SVM }
        /// <summary>
        /// 
        /// </summary>
        private delegate void ClassifierBuilder(string dataFilename, string filenameToSave, string filenameToLoad);





        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="varCount"></param>
        /// <param name="data"></param>
        /// <param name="responses"></param>
        private void ReadNumClassData(string filename, int varCount, out CvMat data, out CvMat responses)
        {
            List<float[]> seq = new List<float[]>();

            using (StreamReader sr = new StreamReader(filename))
            {                
                string buf;
                while (true)
                {
                    float[] elPtr = new float[varCount + 1];
                    buf = sr.ReadLine();
                    if (buf == null || buf.IndexOf(',') < 0)
                    {
                        break;
                    }

                    string[] vals = buf.Split(',');
                    elPtr[0] = vals[0][0];
                    int i;
                    for (i = 1; i <= varCount; i++)
                    {
                        elPtr[i] = Convert.ToSingle(vals[i]);
                    }
                    if (i <= varCount)
                    {
                        break;
                    }
                    seq.Add(elPtr);
                }
            }

            data = new CvMat(seq.Count, varCount, MatrixType.F32C1);
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
                        for (int j = 0; j < varCount; j++)
                        {
                            ddata[j] = sdata[j];
                        }
                        *dr = sdata[-1];
                    }
                }
            }

        }


        /// <summary>
        /// RTrees
        /// </summary>
        /// <param name="dataFilename"></param>
        /// <param name="filenameToSave"></param>
        /// <param name="filenameToLoad"></param>
        private void BuildRtreesClassifier(string dataFilename, string filenameToSave, string filenameToLoad)
        {
            CvMat data = null;
            CvMat responses = null;
            CvMat varType = null;
            CvMat sampleIdx = null;


            int nsamplesAll = 0, ntrainSamples = 0;
            double trainHr = 0, testHr = 0;
            CvRTrees forest = new CvRTrees();
            CvMat varImportance = null;

            try
            {
                ReadNumClassData(dataFilename, 16, out data, out responses);
            }
            catch
            {
                Console.WriteLine("Could not read the database {0}", dataFilename);
                return;
            }
            Console.WriteLine("The database {0} is loaded.", dataFilename);

            nsamplesAll = data.Rows;
            ntrainSamples = (int)(nsamplesAll * 0.8);

            // Create or load Random Trees classifier
            if (filenameToLoad != null)
            {
                // load classifier from the specified file
                forest.Load(filenameToLoad);
                ntrainSamples = 0;
                if (forest.GetTreeCount() == 0)
                {
                    Console.WriteLine("Could not read the classifier {0}", filenameToLoad);
                    return;
                }
                Console.WriteLine("The classifier {0} is loaded.", filenameToLoad);
            }
            else
            {
                // create classifier by using <data> and <responses>
                Console.Write("Training the classifier ...");

                // 1. create type mask
                varType = new CvMat(data.Cols + 1, 1, MatrixType.U8C1);
                varType.Set(CvScalar.ScalarAll(CvStatModel.CV_VAR_ORDERED));
                varType.SetReal1D(data.Cols, CvStatModel.CV_VAR_CATEGORICAL);

                // 2. create sample_idx
                sampleIdx = new CvMat(1, nsamplesAll, MatrixType.U8C1);
                {
                    CvMat mat;
                    Cv.GetCols(sampleIdx, out mat, 0, ntrainSamples);
                    mat.Set(CvScalar.RealScalar(1));

                    Cv.GetCols(sampleIdx, out mat, ntrainSamples, nsamplesAll);
                    mat.SetZero();
                }

                // 3. train classifier
                forest.Train(
                    data, DTreeDataLayout.RowSample, responses, null, sampleIdx, varType, null,
                    new CvRTParams(10, 10, 0, false, 15, null, true, 4, new CvTermCriteria(100, 0.01f))
                );
                Console.WriteLine();
            }

            // compute prediction error on train and test data
            for (int i = 0; i < nsamplesAll; i++)
            {
                double r;
                CvMat sample;
                Cv.GetRow(data, out sample, i);

                r = forest.Predict(sample);
                r = Math.Abs((double)r - responses.DataArraySingle[i]) <= float.Epsilon ? 1 : 0;

                if (i < ntrainSamples)
                    trainHr += r;
                else
                    testHr += r;
            }

            testHr /= (double)(nsamplesAll - ntrainSamples);
            trainHr /= (double)ntrainSamples;
            Console.WriteLine("Recognition rate: train = {0:F1}%, test = {1:F1}%", trainHr * 100.0, testHr * 100.0);

            Console.WriteLine("Number of trees: {0}", forest.GetTreeCount());

            // Print variable importance
            varImportance = forest.GetVarImportance();
            if (varImportance != null)
            {
                double rtImpSum = Cv.Sum(varImportance).Val0;
                Console.WriteLine("var#\timportance (in %):");
                for (int i = 0; i < varImportance.Cols; i++)
                {
                    Console.WriteLine("{0}\t{1:F1}", i, 100.0f * varImportance.DataArraySingle[i] / rtImpSum);
                }
            }

            // Print some proximitites
            Console.WriteLine("Proximities between some samples corresponding to the letter 'T':");
            {
                CvMat sample1, sample2;
                int[,] pairs = new int[,] { { 0, 103 }, { 0, 106 }, { 106, 103 }, { -1, -1 } };

                for (int i = 0; pairs[i, 0] >= 0; i++)
                {
                    Cv.GetRow(data, out sample1, pairs[i, 0]);
                    Cv.GetRow(data, out sample2, pairs[i, 1]);
                    Console.WriteLine("proximity({0},{1}) = {2:F1}%", pairs[i, 0], pairs[i, 1], forest.GetProximity(sample1, sample2) * 100.0);
                }
            }

            // Save Random Trees classifier to file if needed
            if (filenameToSave != null)
            {
                forest.Save(filenameToSave);
            }


            Console.Read();


            if (sampleIdx != null) sampleIdx.Dispose();
            if (varType != null) varType.Dispose();
            data.Dispose();
            responses.Dispose();
            forest.Dispose();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataFilename"></param>
        /// <param name="filenameToSave"></param>
        /// <param name="filenameToLoad"></param>
        private void BuildBoostClassifier(string dataFilename, string filenameToSave, string filenameToLoad)
        {
            const int ClassCount = 26;

            CvMat data = null;
            CvMat responses = null;
            CvMat varType = null;
            CvMat tempSample = null;
            CvMat weakResponses = null;

            int nsamplesAall = 0, ntrainSamples = 0;
            int varCount;
            double trainHr = 0, testHr = 0;
            CvBoost boost = new CvBoost();

            try
            {
                ReadNumClassData(dataFilename, 16, out data, out responses);
            }
            catch
            {
                Console.WriteLine("Could not read the database {0}", dataFilename);
                return;
            }
            Console.WriteLine("The database {0} is loaded.", dataFilename);

            nsamplesAall = data.Rows;
            ntrainSamples = (int)(nsamplesAall * 0.5);
            varCount = data.Cols;

            // Create or load Boosted Tree classifier
            if (filenameToLoad != null)
            {
                // load classifier from the specified file
                boost.Load(filenameToLoad);
                ntrainSamples = 0;
                if (boost.GetWeakPredictors() == null)
                {
                    Console.WriteLine("Could not read the classifier {0}", filenameToLoad);
                    return;
                }
                Console.WriteLine("The classifier {0} is loaded.", filenameToLoad);
            }
            else
            {
                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //
                // As currently boosted tree classifier in MLL can only be trained
                // for 2-class problems, we transform the training database by
                // "unrolling" each training sample as many times as the number of
                // classes (26) that we have.
                //
                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                using (CvMat newData = new CvMat(ntrainSamples * ClassCount, varCount + 1, MatrixType.F32C1))
                using (CvMat newResponses = new CvMat(ntrainSamples * ClassCount, 1, MatrixType.S32C1))
                {

                    // 1. unroll the database type mask
                    Console.WriteLine("Unrolling the database...");
                    for (int i = 0; i < ntrainSamples; i++)
                    {
                        unsafe
                        {
                            float* dataRow = (float*)(data.DataByte + data.Step * i);
                            for (int j = 0; j < ClassCount; j++)
                            {
                                float* newDataRow = (float*)(newData.DataByte + newData.Step * (i * ClassCount + j));
                                for (int k = 0; k < varCount; k++)
                                {
                                    newDataRow[k] = dataRow[k];
                                }
                                newDataRow[varCount] = (float)j;
                                newResponses.DataInt32[i * ClassCount + j] = (responses.DataSingle[i] == j + 'A') ? 1 : 0;
                            }
                        }
                    }

                    // 2. create type mask
                    varType = new CvMat(varCount + 2, 1, MatrixType.U8C1);
                    varType.Set(CvScalar.ScalarAll(CvStatModel.CV_VAR_ORDERED));
                    // the last indicator variable, as well
                    // as the new (binary) response are categorical
                    varType.SetReal1D(varCount, CvStatModel.CV_VAR_CATEGORICAL);
                    varType.SetReal1D(varCount + 1, CvStatModel.CV_VAR_CATEGORICAL);

                    // 3. train classifier
                    Console.Write("Training the classifier (may take a few minutes)...");
                    boost.Train(
                        newData, DTreeDataLayout.RowSample, newResponses, null, null, varType, null,
                        new CvBoostParams(CvBoost.REAL, 100, 0.95, 5, false, null)
                    );
                }
                Console.WriteLine();
            }

            tempSample = new CvMat(1, varCount + 1, MatrixType.F32C1);
            weakResponses = new CvMat(1, boost.GetWeakPredictors().Total, MatrixType.F32C1);

            // compute prediction error on train and test data
            for (int i = 0; i < nsamplesAall; i++)
            {
                int bestClass = 0;
                double maxSum = double.MinValue;
                double r;
                CvMat sample;

                Cv.GetRow(data, out sample, i);
                for (int k = 0; k < varCount; k++)
                {
                    tempSample.DataArraySingle[k] = sample.DataArraySingle[k];
                }

                for (int j = 0; j < ClassCount; j++)
                {
                    tempSample.DataArraySingle[varCount] = (float)j;
                    boost.Predict(tempSample, null, weakResponses);
                    double sum = weakResponses.Sum().Val0;
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        bestClass = j + 'A';
                    }
                }

                r = (Math.Abs(bestClass - responses.DataArraySingle[i]) < float.Epsilon) ? 1 : 0;

                if (i < ntrainSamples)
                    trainHr += r;
                else
                    testHr += r;
            }

            testHr /= (double)(nsamplesAall - ntrainSamples);
            trainHr /= (double)ntrainSamples;
            Console.WriteLine("Recognition rate: train = {0:F1}%, test = {1:F1}%", trainHr * 100.0, testHr * 100.0);
            Console.WriteLine("Number of trees: {0}", boost.GetWeakPredictors().Total);

            // Save classifier to file if needed
            if (filenameToSave != null)
            {
                boost.Save(filenameToSave);
            }


            Console.Read();


            tempSample.Dispose();
            weakResponses.Dispose();
            if (varType != null) varType.Dispose();
            data.Dispose();
            responses.Dispose();
            boost.Dispose();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataFilename"></param>
        /// <param name="filenameToSave"></param>
        /// <param name="filenameToLoad"></param>
        private void BuildMlpClassifier(string dataFilename, string filenameToSave, string filenameToLoad)
        {
            const int ClassCount = 26;

            CvMat data = null;
            CvMat trainData = null;
            CvMat responses = null;
            CvMat mlpResponse = null;
            CvMat layerSizes = null;

            int nsamplesAll = 0, ntrainSamples = 0;
            double trainHr = 0, testHr = 0;
            CvANN_MLP mlp = new CvANN_MLP();

            try
            {
                ReadNumClassData(dataFilename, 16, out data, out responses);
            }
            catch
            {
                Console.WriteLine("Could not read the database {0}", dataFilename);
                return;
            }
            Console.WriteLine("The database {0} is loaded.", dataFilename);

            nsamplesAll = data.Rows;
            ntrainSamples = (int)(nsamplesAll * 0.8);

            // Create or load MLP classifier
            if (filenameToLoad != null)
            {
                // load classifier from the specified file
                mlp.Load(filenameToLoad);
                ntrainSamples = 0;
                if (mlp.GetLayerCount() == 0)
                {
                    Console.WriteLine("Could not read the classifier {0}", filenameToLoad);
                    return;
                }
                Console.WriteLine("The classifier {0} is loaded.", filenameToLoad);
            }
            else
            {
                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //
                // MLP does not support categorical variables by explicitly.
                // So, instead of the output class label, we will use
                // a binary vector of <class_count> components for training and,
                // therefore, MLP will give us a vector of "probabilities" at the
                // prediction stage
                //
                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                using (CvMat newResponses = new CvMat(ntrainSamples, ClassCount, MatrixType.F32C1))
                {
                    // 1. unroll the responses
                    Console.WriteLine("Unrolling the responses...");
                    unsafe
                    {
                        for (int i = 0; i < ntrainSamples; i++)
                        {
                            int clsLabel = Cv.Round(responses.DataArraySingle[i]) - 'A';
                            float* bitVec = (float*)(newResponses.DataByte + i * newResponses.Step);
                            for (int j = 0; j < ClassCount; j++)
                            {
                                bitVec[j] = 0.0f;
                            }
                            bitVec[clsLabel] = 1.0f;
                        }
                    }
                    Cv.GetRows(data, out trainData, 0, ntrainSamples);

                    // 2. train classifier
                    int[] layerSizesData = { data.Cols, 100, 100, ClassCount };
                    layerSizes = new CvMat(1, layerSizesData.Length, MatrixType.S32C1, layerSizesData);
                    mlp.Create(layerSizes);
                    Console.Write("Training the classifier (may take a few minutes)...");
                    mlp.Train(
                        trainData, newResponses, null, null,
                        new CvANN_MLP_TrainParams(new CvTermCriteria(300, 0.01), MLPTrainingMethod.RPROP, 0.01)
                    );
                }
                Console.WriteLine();
            }

            mlpResponse = new CvMat(1, ClassCount, MatrixType.F32C1);

            // compute prediction error on train and test data
            for (int i = 0; i < nsamplesAll; i++)
            {
                int bestClass;
                CvMat sample;
                CvPoint minLoc, maxLoc;

                Cv.GetRow(data, out sample, i);                
                mlp.Predict(sample, mlpResponse);
                mlpResponse.MinMaxLoc(out minLoc, out maxLoc, null);
                bestClass = maxLoc.X + 'A';

                int r = (Math.Abs((double)bestClass - responses.DataArraySingle[i]) < float.Epsilon) ? 1 : 0;

                if (i < ntrainSamples)
                    trainHr += r;
                else
                    testHr += r;
            }

            testHr /= (double)(nsamplesAll - ntrainSamples);
            trainHr /= (double)ntrainSamples;
            Console.WriteLine("Recognition rate: train = {0:F1}%, test = {1:F1}%", trainHr * 100.0, testHr * 100.0);

            // Save classifier to file if needed
            if (filenameToSave != null)
            {
                mlp.Save(filenameToSave);
            }


            Console.Read();


            mlpResponse.Dispose();
            data.Dispose();
            responses.Dispose();
            if (layerSizes != null) layerSizes.Dispose();
            mlp.Dispose();
        }


        /// <summary>
        /// SVM
        /// </summary>
        /// <param name="dataFilename"></param>
        /// <param name="filenameToSave"></param>
        /// <param name="filenameToLoad"></param>
        private void BuildSvmClassifier(string dataFilename, string filenameToSave, string filenameToLoad)
        {
            //C_SVCのパラメータ
            const float SvmC = 1000;
            //RBFカーネルのパラメータ
            const float SvmGamma = 0.1f;

            CvMat data = null;
            CvMat responses = null;
            CvMat sampleIdx = null;

            int nsamplesAll = 0, ntrainSamples = 0;
            double trainHr = 0, testHr = 0;

            CvSVM svm = new CvSVM();
            CvTermCriteria criteria = new CvTermCriteria(100, 0.001);

            try
            {
                ReadNumClassData(dataFilename, 16, out data, out responses);
            }
            catch
            {
                Console.WriteLine("Could not read the database {0}", dataFilename);
                return;
            }
            Console.WriteLine("The database {0} is loaded.", dataFilename);

            nsamplesAll = data.Rows;
            ntrainSamples = (int)(nsamplesAll * 0.2);

            // Create or load Random Trees classifier
            if (filenameToLoad != null)
            {
                // load classifier from the specified file
                svm.Load(filenameToLoad);
                ntrainSamples = 0;
                if (svm.GetSupportVectorCount() == 0)
                {
                    Console.WriteLine("Could not read the classifier {0}", filenameToLoad);
                    return;
                }
                Console.WriteLine("The classifier {0} is loaded.", filenameToLoad);
            }
            else
            {
                // create classifier by using <data> and <responses>
                Console.Write("Training the classifier ...");

                // 2. create sample_idx
                sampleIdx = new CvMat(1, nsamplesAll, MatrixType.U8C1);
                {
                    CvMat mat;
                    Cv.GetCols(sampleIdx, out mat, 0, ntrainSamples);
                    mat.Set(CvScalar.RealScalar(1));

                    Cv.GetCols(sampleIdx, out mat, ntrainSamples, nsamplesAll);
                    mat.SetZero();
                }

                // 3. train classifier
                // 方法、カーネルにより使わないパラメータは0で良く、
                // 重みについてもNULLで良い
                svm.Train(data, responses, null, sampleIdx, new CvSVMParams(CvSVM.C_SVC, CvSVM.RBF, 0, SvmGamma, 0, SvmC, 0, 0, null, criteria));
                Console.WriteLine();
            }

            
            // compute prediction error on train and test data            
            for (int i = 0; i < nsamplesAll; i++)
            {
                double r;
                CvMat sample;
                Cv.GetRow(data, out sample, i);

                r = svm.Predict(sample);
                // compare results
                Console.WriteLine(
                    "predict: {0}, responses: {1}, {2}",
                    (char)r,
                    (char)responses.DataArraySingle[i],
                    Math.Abs((double)r - responses.DataArraySingle[i]) <= float.Epsilon ? "Good!" : "Bad!"
                );
                r = Math.Abs((double)r - responses.DataArraySingle[i]) <= float.Epsilon ? 1 : 0;

                if (i < ntrainSamples)
                    trainHr += r;
                else
                    testHr += r;
            }

            testHr /= (double)(nsamplesAll - ntrainSamples);
            trainHr /= (double)ntrainSamples;
            Console.WriteLine("Gamma={0:F5}, C={1:F5}", SvmGamma, SvmC);
            if (filenameToLoad != null)
            {
                Console.WriteLine("Recognition rate: test = {0:F1}%", testHr * 100.0);
            }
            else
            {
                Console.WriteLine("Recognition rate: train = {0:F1}%, test = {1:F1}%", trainHr * 100.0, testHr * 100.0);
            }

            Console.WriteLine("Number of Support Vector: {0}", svm.GetSupportVectorCount());
            // Save SVM classifier to file if needed
            if (filenameToSave != null)
            {
                svm.Save(filenameToSave);
            }


            Console.Read();


            if (sampleIdx != null) sampleIdx.Dispose();
            data.Dispose();
            responses.Dispose();
            svm.Dispose();
        }

    }
}
