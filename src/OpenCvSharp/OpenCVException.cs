using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// OpenCVから投げられる例外
    /// </summary>
#else
    /// <summary>
    /// The default exception to be thrown by OpenCV 
    /// </summary>
#endif
    public class OpenCVException : ApplicationException
    {
        #region Properties
#if LANG_JP
        /// <summary>
        /// エラーステータス
        /// </summary>
#else
        /// <summary>
        /// The numeric code for error status
        /// </summary>
#endif
        public ErrorCode Status { get; set; }
#if LANG_JP
        /// <summary>
        /// エラーが発生したOpenCVの関数名．
        /// </summary>
#else
        /// <summary>
        /// The source file name where error is encountered
        /// </summary>
#endif
        public string FuncName { get; set; }
#if LANG_JP
        /// <summary>
        /// エラーについての追加情報/診断結果
        /// </summary>
#else
        /// <summary>
        /// A description of the error
        /// </summary>
#endif
        public string ErrMsg { get; set; }
#if LANG_JP
        /// <summary>
        /// エラーが発生したファイル名
        /// </summary>
#else
        /// <summary>
        /// The source file name where error is encountered
        /// </summary>
#endif
        public string FileName { get; set; }
#if LANG_JP
        /// <summary>
        /// エラーが発生した行番号
        /// </summary>
#else
        /// <summary>
        /// The line number in the souce where error is encountered
        /// </summary>
#endif
        public int Line { get; set; }
        #endregion

#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="status">エラーステータス</param>
        /// <param name="funcName">エラーが発生した関数名</param>
        /// <param name="errMsg">エラーについての追加情報/診断結果</param>
        /// <param name="fileName">エラーが発生したファイル名</param>
        /// <param name="line">エラーが発生した行番号</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="status">The numeric code for error status</param>
        /// <param name="funcName">The source file name where error is encountered</param>
        /// <param name="errMsg">A description of the error</param>
        /// <param name="fileName">The source file name where error is encountered</param>
        /// <param name="line">The line number in the souce where error is encountered</param>
#endif
        public OpenCVException(ErrorCode status, string funcName, string errMsg, string fileName, int line)
            : base(errMsg)
        {
            Status = status;
            FuncName = funcName;
            ErrMsg = errMsg;
            FileName = fileName;
            Line = line;
        }
    }
}
