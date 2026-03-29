using OpenCvSharp.Internal;

namespace OpenCvSharp.Flann;

/// <summary>
/// 
/// </summary>
public class IndexParams : CvObject
{
    /// <summary>
    /// 
    /// </summary>
    public IndexParams()
    {
        NativeMethods.HandleException(
            NativeMethods.flann_Ptr_IndexParams_new(out var p));
        if (p == IntPtr.Zero)
            throw new OpenCvSharpException($"Failed to create {nameof(IndexParams)}");

        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: true,
            releaseAction: _ => NativeMethods.HandleException(NativeMethods.flann_Ptr_IndexParams_delete(p))));
    }

    /// <summary>
    /// 
    /// </summary>
    protected IndexParams(IntPtr p, Func<IntPtr, ExceptionStatus> deleteAction)
    {
        SetSafeHandle(new OpenCvPtrSafeHandle(p, ownsHandle: true,
            releaseAction: _ => NativeMethods.HandleException(deleteAction(p))));
    }

    #region Methods
    #region Get**
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="defaultVal"></param>
    /// <returns></returns>
    public string GetString(string key, string? defaultVal = null)
    {
        using var result = new StdString();
        NativeMethods.HandleException(
            NativeMethods.flann_IndexParams_getString(CvPtr, key, defaultVal, result.CvPtr));
        GC.KeepAlive(this);
        return result.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="defaultVal"></param>
    /// <returns></returns>
    public int GetInt(string key, int defaultVal = -1)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_IndexParams_getInt(CvPtr, key, defaultVal, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="defaultVal"></param>
    /// <returns></returns>
    public double GetDouble(string key, double defaultVal = -1)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_IndexParams_getDouble(CvPtr, key, defaultVal, out var ret));
        GC.KeepAlive(this);
        return ret;
    }

    #endregion
    #region Set**
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void SetString(string key, string value)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_IndexParams_setString(CvPtr, key, value));
        GC.KeepAlive(this);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void SetInt(string key, int value)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_IndexParams_setInt(CvPtr, key, value));
        GC.KeepAlive(this);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void SetDouble(string key, double value)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_IndexParams_setDouble(CvPtr, key, value));
        GC.KeepAlive(this);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void SetFloat(string key, float value)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_IndexParams_setFloat(CvPtr, key, value));
        GC.KeepAlive(this);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void SetBool(string key, bool value)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_IndexParams_setBool(CvPtr, key, value ? 1 : 0));
        GC.KeepAlive(this);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public void SetAlgorithm(int value)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_IndexParams_setAlgorithm(CvPtr, value));
        GC.KeepAlive(this);
    }
    #endregion
    #endregion
}
