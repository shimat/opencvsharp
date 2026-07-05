using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Face;

/// <summary>
/// Abstract base class for all face recognition models.
/// All face recognition models in OpenCV are derived from the abstract base class FaceRecognizer, which
/// provides a unified access to all face recongition algorithms in OpenCV.
/// </summary>
public abstract class FaceRecognizer : Algorithm
{
    /// <summary>
    /// 
    /// </summary>
    protected FaceRecognizer(IntPtr smartPtr, IntPtr rawPtr, Action<IntPtr> release)
        : base(smartPtr, rawPtr, release) { }

    /// <summary>
    /// Trains a FaceRecognizer with given data and associated labels.
    /// </summary>
    /// <param name="src"></param>
    /// <param name="labels"></param>
    public virtual void Train(IEnumerable<Mat> src, IEnumerable<int> labels)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(src);
        ArgumentNullException.ThrowIfNull(labels);

        var srcArray = src.Select(x => x.CvPtr).ToArray();
        var labelsArray = labels.ToArray();
        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_train(
                Handle, srcArray, srcArray.Length, labelsArray, labelsArray.Length));

        GC.KeepAlive(src);
    }

    /// <summary>
    /// Updates a FaceRecognizer with given data and associated labels.
    /// </summary>
    /// <param name="src"></param>
    /// <param name="labels"></param>
    public void Update(IEnumerable<Mat> src, IEnumerable<int> labels)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(src);
        ArgumentNullException.ThrowIfNull(labels);

        var srcArray = src.Select(x => x.CvPtr).ToArray();
        var labelsArray = labels.ToArray();
        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_update(
                Handle, srcArray, srcArray.Length, labelsArray, labelsArray.Length));
        GC.KeepAlive(src);
    }

    /// <summary>
    /// Gets a prediction from a FaceRecognizer.
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    public virtual int Predict(InputArray src)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_predict1(Handle, src.Proxy, out var ret));
        GC.KeepAlive(src.Source);
        return ret;
    }

    /// <summary>
    /// Predicts the label and confidence for a given sample.
    /// </summary>
    /// <param name="src"></param>
    /// <param name="label"></param>
    /// <param name="confidence"></param>
    public virtual void Predict(InputArray src, out int label, out double confidence)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_predict2(Handle, src.Proxy, out label, out confidence));
        GC.KeepAlive(src.Source);
    }

    /// <summary>
    /// Serializes this object to a given filename.
    /// </summary>
    /// <param name="fileName"></param>
    public virtual void Write(string fileName)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(fileName);

        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_write1(Handle, fileName));
    }

    /// <summary>
    /// Deserializes this object from a given filename.
    /// </summary>
    /// <param name="fileName"></param>
    public virtual void Read(string fileName)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(fileName);

        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_read1(Handle, fileName));
    }

    /// <inheritdoc />
    public override void Write(FileStorage fs)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(fs);
        fs.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_write2(Handle, fs.CvPtr));
        GC.KeepAlive(fs);
    }

    /// <inheritdoc />
    public override void Read(FileNode fn)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(fn);
        fn.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_read2(Handle, fn.CvPtr));
        GC.KeepAlive(fn);
    }

    /// <summary>
    /// Sets string info for the specified model's label.
    /// The string info is replaced by the provided value if it was set before for the specified label.
    /// </summary>
    /// <param name="label"></param>
    /// <param name="strInfo"></param>
    public void SetLabelInfo(int label, string strInfo)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(strInfo);

        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_setLabelInfo(Handle, label, strInfo));
    }

    /// <summary>
    /// Gets string information by label.
    /// If an unknown label id is provided or there is no label information associated with the specified 
    /// label id the method returns an empty string.
    /// </summary>
    /// <param name="label"></param>
    /// <returns></returns>
    public string GetLabelInfo(int label)
    {
        ThrowIfDisposed();

        using var resultString = new StdString();
        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_getLabelInfo(Handle, label, resultString.CvPtr));
        return resultString.ToString();
    }

    /// <summary>
    /// Gets vector of labels by string.
    /// The function searches for the labels containing the specified sub-string in the associated string info.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public int[] GetLabelsByString(string str)
    {
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(str);
        using var resultVector = new StdVector<int>();
        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_getLabelsByString(Handle, str, resultVector.CvPtr));
        return resultVector.ToArray();
    }

    /// <summary>
    /// threshold parameter accessor - required for default BestMinDist collector
    /// </summary>
    /// <returns></returns>
    public double GetThreshold()
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_getThreshold(Handle, out var ret));
        return ret;
    }

    /// <summary>
    /// Sets threshold of model
    /// </summary>
    /// <param name="val"></param>
    public void SetThreshold(double val)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_setThreshold(Handle, val));
    }
}
