using OpenCvSharp.Internal;

namespace OpenCvSharp.ML;

/// <summary>
/// Training data used by the ml algorithms
/// </summary>
public class TrainData : CvPtrObject
{
    private TrainData(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, static p => NativeMethods.HandleException(NativeMethods.ml_Ptr_TrainData_delete(p)))
    {
    }

    /// <summary>
    /// Creates training data from in-memory arrays.
    /// </summary>
    /// <param name="samples">matrix of samples. It should have CV_32F type.</param>
    /// <param name="layout">see ml::SampleTypes.</param>
    /// <param name="responses">matrix of responses. If the responses are scalar, they should be stored as a
    /// single row or as a single column. The matrix should have type CV_32F or CV_32S (in the
    /// former case the responses are considered as ordered by default; in the latter case - as categorical)</param>
    /// <param name="varIdx">vector specifying which variables to use for training. It can be an integer vector
    /// (CV_32S) containing 0-based variable indices or byte vector (CV_8U) containing a mask of active variables.</param>
    /// <param name="sampleIdx">vector specifying which samples to use for training. It can be an integer
    /// vector (CV_32S) containing 0-based sample indices or byte vector (CV_8U) containing a mask
    /// of training samples.</param>
    /// <param name="sampleWeights">optional vector with weights for each sample. It should have CV_32F type.</param>
    /// <param name="varType">optional vector of type CV_8U and size &lt;number_of_variables_in_samples&gt; +
    /// &lt;number_of_variables_in_responses&gt;, containing types of each input and output variable.
    /// See ml::VariableTypes.</param>
    /// <returns></returns>
    public static TrainData Create(
        InputArray samples,
        SampleTypes layout,
        InputArray responses,
        InputArray varIdx = default,
        InputArray sampleIdx = default,
        InputArray sampleWeights = default,
        InputArray varType = default)
    {
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_create(
                samples.Proxy, (int)layout, responses.Proxy,
                varIdx.Proxy, sampleIdx.Proxy, sampleWeights.Proxy, varType.Proxy,
                out var smartPtr));
        GC.KeepAlive(samples.Source);
        GC.KeepAlive(responses.Source);
        GC.KeepAlive(varIdx.Source);
        GC.KeepAlive(sampleIdx.Source);
        GC.KeepAlive(sampleWeights.Source);
        GC.KeepAlive(varType.Source);

        NativeMethods.HandleException(NativeMethods.ml_Ptr_TrainData_get(smartPtr, out var rawPtr));
        return new TrainData(smartPtr, rawPtr);
    }

    /// <summary>
    /// Reads the dataset from a .csv file and returns the ready-to-use training data.
    /// </summary>
    /// <param name="filename">The input file name</param>
    /// <param name="headerLineCount">The number of lines in the beginning to skip; besides the header, the
    /// function also skips empty lines and lines starting with '#'</param>
    /// <param name="responseStartIdx">Index of the first output variable. If -1, the function considers the
    /// last variable as the response</param>
    /// <param name="responseEndIdx">Index of the last output variable + 1. If -1, then there is single
    /// response variable at responseStartIdx.</param>
    /// <param name="varTypeSpec">The optional text string that specifies the variables' types. It has the
    /// format `ord[n1-n2,n3,n4-n5,...]cat[n6,n7-n8,...]`.</param>
    /// <param name="delimiter">The character used to separate values in each line.</param>
    /// <param name="missch">The character used to specify missing measurements. It should not be a digit.</param>
    /// <returns></returns>
    public static TrainData LoadFromCSV(
        string filename,
        int headerLineCount,
        int responseStartIdx = -1,
        int responseEndIdx = -1,
        string varTypeSpec = "",
        char delimiter = ',',
        char missch = '?')
    {
        ArgumentNullException.ThrowIfNull(filename);
        ArgumentNullException.ThrowIfNull(varTypeSpec);

        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_loadFromCSV(
                filename, headerLineCount, responseStartIdx, responseEndIdx, varTypeSpec,
                (byte)delimiter, (byte)missch, out var smartPtr));
        NativeMethods.HandleException(NativeMethods.ml_Ptr_TrainData_get(smartPtr, out var rawPtr));
        return new TrainData(smartPtr, rawPtr);
    }

    /// <summary>
    /// Returns the layout (ml::SampleTypes) used by this training data.
    /// </summary>
    /// <returns></returns>
    public SampleTypes GetLayout()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getLayout(Handle, out var ret));
        return (SampleTypes)ret;
    }

    /// <summary>
    /// Returns the total number of samples
    /// </summary>
    /// <returns></returns>
    public int GetNSamples()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getNSamples(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Returns the number of training samples
    /// </summary>
    /// <returns></returns>
    public int GetNTrainSamples()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getNTrainSamples(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Returns the number of test samples
    /// </summary>
    /// <returns></returns>
    public int GetNTestSamples()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getNTestSamples(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Returns the number of variables
    /// </summary>
    /// <returns></returns>
    public int GetNVars()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getNVars(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Returns the number of variables including the responses
    /// </summary>
    /// <returns></returns>
    public int GetNAllVars()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getNAllVars(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Returns the matrix of all the samples
    /// </summary>
    /// <returns></returns>
    public Mat GetSamples()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getSamples(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Returns the mask of missing values in the samples
    /// </summary>
    /// <returns></returns>
    public Mat GetMissing()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getMissing(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Returns matrix of train samples
    /// </summary>
    /// <param name="layout">The requested layout. If it's different from the initial one, the matrix is
    /// transposed. See ml::SampleTypes.</param>
    /// <param name="compressSamples">if true, the function returns only the training samples (specified by
    /// sampleIdx)</param>
    /// <param name="compressVars">if true, the function returns the shorter training samples, containing only
    /// the active variables.</param>
    /// <returns></returns>
    public Mat GetTrainSamples(
        SampleTypes layout = SampleTypes.RowSample, bool compressSamples = true, bool compressVars = true)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getTrainSamples(
                Handle, (int)layout, compressSamples ? 1 : 0, compressVars ? 1 : 0, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Returns the vector of responses for the training samples
    /// </summary>
    /// <returns></returns>
    public Mat GetTrainResponses()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getTrainResponses(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Returns matrix of test samples
    /// </summary>
    /// <returns></returns>
    public Mat GetTestSamples()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getTestSamples(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Returns the vector of responses for the test samples
    /// </summary>
    /// <returns></returns>
    public Mat GetTestResponses()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getTestResponses(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Returns the vector of responses
    /// </summary>
    /// <returns></returns>
    public Mat GetResponses()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getResponses(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Returns the vector of variable indices used for training
    /// </summary>
    /// <returns></returns>
    public Mat GetVarIdx()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getVarIdx(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Returns the type of each input and output variable
    /// </summary>
    /// <returns></returns>
    public Mat GetVarType()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getVarType(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Returns the vector of class labels
    /// </summary>
    /// <returns></returns>
    public Mat GetClassLabels()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getClassLabels(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Returns the indices of the training samples
    /// </summary>
    /// <returns></returns>
    public Mat GetTrainSampleIdx()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getTrainSampleIdx(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Returns the indices of the test samples
    /// </summary>
    /// <returns></returns>
    public Mat GetTestSampleIdx()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_getTestSampleIdx(Handle, out var ret));
        return new Mat(ret);
    }

    /// <summary>
    /// Splits the training data into the training and test parts
    /// </summary>
    /// <param name="count"></param>
    /// <param name="shuffle"></param>
    public void SetTrainTestSplit(int count, bool shuffle = true)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_setTrainTestSplit(Handle, count, shuffle));
    }

    /// <summary>
    /// Splits the training data into the training and test parts
    /// </summary>
    /// <param name="ratio"></param>
    /// <param name="shuffle"></param>
    public void SetTrainTestSplitRatio(double ratio, bool shuffle = true)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_setTrainTestSplitRatio(Handle, ratio, shuffle));
    }

    /// <summary>
    /// Shuffles the training and test sample indices
    /// </summary>
    public void ShuffleTrainTest()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.ml_TrainData_shuffleTrainTest(Handle));
    }
}
