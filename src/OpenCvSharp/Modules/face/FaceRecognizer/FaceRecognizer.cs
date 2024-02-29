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
    /// Trains a FaceRecognizer with given data and associated labels.
    /// </summary>
    /// <param name="src"></param>
    /// <param name="labels"></param>
    public virtual void Train(IEnumerable<Mat> src, IEnumerable<int> labels)
    {
        ThrowIfDisposed();
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (labels is null)
            throw new ArgumentNullException(nameof(labels));

        var srcArray = src.Select(x => x.CvPtr).ToArray();
        var labelsArray = labels.ToArray();
        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_train(
                ptr, srcArray, srcArray.Length, labelsArray, labelsArray.Length));

        GC.KeepAlive(this);
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
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (labels is null)
            throw new ArgumentNullException(nameof(labels));

        var srcArray = src.Select(x => x.CvPtr).ToArray();
        var labelsArray = labels.ToArray();
        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_update(
                ptr, srcArray, srcArray.Length, labelsArray, labelsArray.Length));
        GC.KeepAlive(this);
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
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        src.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_predict1(ptr, src.CvPtr, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(src);
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
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        src.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_predict2(ptr, src.CvPtr, out label, out confidence));
        GC.KeepAlive(this);
        GC.KeepAlive(src);
    }

    /// <summary>
    /// Serializes this object to a given filename.
    /// </summary>
    /// <param name="fileName"></param>
    public virtual void Write(string fileName)
    {
        ThrowIfDisposed();
        if (fileName is null)
            throw new ArgumentNullException(nameof(fileName));

        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_write1(ptr, fileName));
    }

    /// <summary>
    /// Deserializes this object from a given filename.
    /// </summary>
    /// <param name="fileName"></param>
    public virtual void Read(string fileName)
    {
        ThrowIfDisposed();
        if (fileName is null)
            throw new ArgumentNullException(nameof(fileName));

        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_read1(ptr, fileName));
    }

    /// <inheritdoc />
    /// <summary>
    /// Serializes this object to a given cv::FileStorage.
    /// </summary>
    /// <param name="fs"></param>
    public override void Write(FileStorage fs)
    {
        ThrowIfDisposed();
        if (fs is null)
            throw new ArgumentNullException(nameof(fs));
        fs.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_write2(ptr, fs.CvPtr));
        GC.KeepAlive(this);
        GC.KeepAlive(fs);
    }

    /// <inheritdoc />
    /// <summary>
    /// Deserializes this object from a given cv::FileNode.
    /// </summary>
    /// <param name="fn"></param>
    public override void Read(FileNode fn)
    {
        ThrowIfDisposed();
        if (fn is null)
            throw new ArgumentNullException(nameof(fn));
        fn.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_read2(ptr, fn.CvPtr));
        GC.KeepAlive(this);
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
        if (strInfo is null)
            throw new ArgumentNullException(nameof(strInfo));

        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_setLabelInfo(ptr, label, strInfo));
        GC.KeepAlive(this);
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
            NativeMethods.face_FaceRecognizer_getLabelInfo(ptr, label, resultString.CvPtr));
        GC.KeepAlive(this);
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
        if (str is null)
            throw new ArgumentNullException(nameof(str));
        using var resultVector = new VectorOfInt32();
        NativeMethods.HandleException(
            NativeMethods.face_FaceRecognizer_getLabelsByString(ptr, str, resultVector.CvPtr));
        GC.KeepAlive(this);
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
            NativeMethods.face_FaceRecognizer_getThreshold(ptr, out var ret));
        GC.KeepAlive(this);
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
            NativeMethods.face_FaceRecognizer_setThreshold(ptr, val));
        GC.KeepAlive(this);
    }
}
