/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;

#pragma warning disable 1591
// ReSharper disable once InconsistentNaming

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// 
    /// </summary>
#else
	/// <summary>
    /// 
    /// </summary>
#endif
    public class CvMLData : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 既定の初期化
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public CvMLData()
        {
            ptr = NativeMethods.ml_CvMLData_new();
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        if (ptr != IntPtr.Zero)
                            NativeMethods.ml_CvMLData_delete(ptr);
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public int ReadCsv(string filename)
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            return NativeMethods.ml_CvMLData_read_csv(ptr, filename);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CvMat GetValues()
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            IntPtr result = NativeMethods.ml_CvMLData_get_values(ptr);
            return (result == IntPtr.Zero) ? null : new CvMat(result, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CvMat GetResponses()
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            IntPtr result = NativeMethods.ml_CvMLData_get_responses(ptr);
            return (result == IntPtr.Zero) ? null : new CvMat(result, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CvMat GetMissing()
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            IntPtr result = NativeMethods.ml_CvMLData_get_missing(ptr);
            return (result == IntPtr.Zero) ? null : new CvMat(result, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetResponseIdx()
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            return NativeMethods.ml_CvMLData_get_response_idx(ptr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idx"></param>
        public void SetResponseIdx(int idx)
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            NativeMethods.ml_CvMLData_set_response_idx(ptr, idx);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CvMat GetTrainSampleIdx()
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            IntPtr result = NativeMethods.ml_CvMLData_get_train_sample_idx(ptr);
            return (result == IntPtr.Zero) ? null : new CvMat(result, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CvMat GetTestSampleIdx()
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            IntPtr result = NativeMethods.ml_CvMLData_get_test_sample_idx(ptr);
            return (result == IntPtr.Zero) ? null : new CvMat(result, false);
        }
        /// <summary>
        /// 
        /// </summary>
        public void MixTrainAndTestIdx()
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            NativeMethods.ml_CvMLData_mix_train_and_test_idx(ptr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spl"></param>
        public void SetTrainTestSplit(CvTrainTestSplit spl)
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            if (spl == null)
                throw new ArgumentNullException("spl");
            NativeMethods.ml_CvMLData_set_train_test_split(ptr, spl.CvPtr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CvMat GetVarIdx()
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            IntPtr result = NativeMethods.ml_CvMLData_get_var_idx(ptr);
            return (result == IntPtr.Zero) ? null : new CvMat(result, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vi"></param>
        /// <param name="state"></param>
        public void ChangeVarIdx(int vi, bool state)
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            NativeMethods.ml_CvMLData_change_var_idx(ptr, vi, state ? 1 : 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CvMat GetVarTypes()
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            IntPtr result = NativeMethods.ml_CvMLData_get_var_types(ptr);
            return (result == IntPtr.Zero) ? null : new CvMat(result, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varIdx"></param>
        /// <returns></returns>
        public int GetVarType(int varIdx)
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            return NativeMethods.ml_CvMLData_get_var_type(ptr, varIdx);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public void SetVarTypes(string str)
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            NativeMethods.ml_CvMLData_set_var_types(ptr, str);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varIdx"></param>
        /// <param name="type"></param>
        public void ChangeVarType(int varIdx, int type)
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            NativeMethods.ml_CvMLData_change_var_type(ptr, varIdx, type);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ch"></param>
        public void SetDelimiter(byte ch)
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            NativeMethods.ml_CvMLData_set_delimiter(ptr, ch);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte GetDelimiter()
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            return NativeMethods.ml_CvMLData_get_delimiter(ptr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ch"></param>
        public void SetMissCh(byte ch)
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            NativeMethods.ml_CvMLData_set_miss_ch(ptr, ch);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte GetMissCh()
        {
            if (disposed)
                throw new ObjectDisposedException("CvMLData");
            return NativeMethods.ml_CvMLData_get_miss_ch(ptr);
        }
        #endregion
    }
}
