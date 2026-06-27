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
            NativeMethods.flann_IndexParams_getString(Handle, key, defaultVal, result.CvPtr));
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
            NativeMethods.flann_IndexParams_getInt(Handle, key, defaultVal, out var ret));
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
            NativeMethods.flann_IndexParams_getDouble(Handle, key, defaultVal, out var ret));
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
            NativeMethods.flann_IndexParams_setString(Handle, key, value));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void SetInt(string key, int value)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_IndexParams_setInt(Handle, key, value));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void SetDouble(string key, double value)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_IndexParams_setDouble(Handle, key, value));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void SetFloat(string key, float value)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_IndexParams_setFloat(Handle, key, value));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void SetBool(string key, bool value)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_IndexParams_setBool(Handle, key, value ? 1 : 0));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public void SetAlgorithm(int value)
    {
        NativeMethods.HandleException(
            NativeMethods.flann_IndexParams_setAlgorithm(Handle, value));
    }
    #endregion
    #endregion
}
