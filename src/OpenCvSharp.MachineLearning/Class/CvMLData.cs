/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp.MachineLearning
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
        private bool _disposed = false;

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
            : base()
        {
            ptr = MLInvoke.CvMLData_construct();
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
            if (!this._disposed)
            {
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        MLInvoke.CvMLData_destruct(ptr);
                    }
                    this._disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvMLData)
        /// </summary>
        public static readonly int SizeOf = MLInvoke.CvMLData_sizeof();
        #endregion


        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public int ReadCsv(string filename)
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            return MLInvoke.CvMLData_read_csv(ptr, filename);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CvMat GetValues()
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            IntPtr result = MLInvoke.CvMLData_get_values(ptr);
            return (result == IntPtr.Zero) ? null : new CvMat(result, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CvMat GetResponses()
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            IntPtr result = MLInvoke.CvMLData_get_responses(ptr);
            return (result == IntPtr.Zero) ? null : new CvMat(result, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CvMat GetMissing()
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            IntPtr result = MLInvoke.CvMLData_get_missing(ptr);
            return (result == IntPtr.Zero) ? null : new CvMat(result, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetResponseIdx()
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            return MLInvoke.CvMLData_get_response_idx(ptr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idx"></param>
        public void SetResponseIdx(int idx)
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            MLInvoke.CvMLData_set_response_idx(ptr, idx);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CvMat GetTrainSampleIdx()
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            IntPtr result = MLInvoke.CvMLData_get_train_sample_idx(ptr);
            return (result == IntPtr.Zero) ? null : new CvMat(result, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CvMat GetTestSampleIdx()
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            IntPtr result = MLInvoke.CvMLData_get_test_sample_idx(ptr);
            return (result == IntPtr.Zero) ? null : new CvMat(result, false);
        }
        /// <summary>
        /// 
        /// </summary>
        public void MixTrainAndTestIdx()
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            MLInvoke.CvMLData_mix_train_and_test_idx(ptr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spl"></param>
        public void SetTrainTestSplit(CvTrainTestSplit spl)
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            if (spl == null)
                throw new ArgumentNullException("spl");
            MLInvoke.CvMLData_set_train_test_split(ptr, spl.CvPtr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CvMat GetVarIdx()
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            IntPtr result = MLInvoke.CvMLData_get_var_idx(ptr);
            return (result == IntPtr.Zero) ? null : new CvMat(result, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vi"></param>
        /// <param name="state"></param>
        public void ChangeVarIdx(int vi, bool state)
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            MLInvoke.CvMLData_change_var_idx(ptr, vi, state);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CvMat GetVarTypes()
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            IntPtr result = MLInvoke.CvMLData_get_var_types(ptr);
            return (result == IntPtr.Zero) ? null : new CvMat(result, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="var_idx"></param>
        /// <returns></returns>
        public int GetVarType(int var_idx)
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            return MLInvoke.CvMLData_get_var_type(ptr, var_idx);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public void SetVarTypes(string str)
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            MLInvoke.CvMLData_set_var_types(ptr, str);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="var_idx"></param>
        /// <param name="type"></param>
        public void ChangeVarType(int var_idx, int type)
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            MLInvoke.CvMLData_change_var_type(ptr, var_idx, type);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ch"></param>
        public void SetDelimiter(byte ch)
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            MLInvoke.CvMLData_set_delimiter(ptr, ch);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte GetDelimiter()
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            return MLInvoke.CvMLData_get_delimiter(ptr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ch"></param>
        public void SetMissCh(byte ch)
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            MLInvoke.CvMLData_set_miss_ch(ptr, ch);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte GetMissCh()
        {
            if (_disposed)
                throw new ObjectDisposedException("CvMLData");
            return MLInvoke.CvMLData_get_miss_ch(ptr);
        }
        #endregion
    }
}
