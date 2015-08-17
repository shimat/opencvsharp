using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Util
{
    /// <summary>
    /// 
    /// </summary>
    public static class PInvokeHelper
    {
#if LANG_JP
        /// <summary>
        /// PInvokeが正常に行えるかチェックする
        /// </summary>
#else
        /// <summary>
        /// Checks whether PInvoke functions can be called
        /// </summary>
#endif
        public static void TryPInvoke()
        {
            try
            {
                NativeMethods.core_Mat_sizeof();
            }
            catch (DllNotFoundException e)
            {
                DllImportError(e);
            }
            catch (BadImageFormatException e)
            {
                DllImportError(e);
            }
        }

        /// <summary>
        /// DllImportの際にDllNotFoundExceptionかBadImageFormatExceptionが発生した際に呼び出されるメソッド。
        /// エラーメッセージを表示して解決策をユーザに示す。
        /// </summary>
        /// <param name="ex"></param>
        public static void DllImportError(Exception ex)
        {
            throw CreateException(ex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public static OpenCvSharpException CreateException(Exception ex)
        {
            StringBuilder message = new StringBuilder();
            if (System.Globalization.CultureInfo.CurrentCulture.Name.Contains("ja"))
            {
                message.AppendFormat("{0}\n", ex.Message);
                message.Append("*** P/Invokeが原因で例外が発生しました。***\n")
                    .Append("以下の項目を確認して下さい。\n")
                    .Append("(1) OpenCVのDLLが実行ファイルと同じ場所に置かれていますか? またはパスが正しく通っていますか?\n")
                    .Append("(2) Visual C++ Redistributable Packageをインストールしましたか?\n")
                    .Append("(3) OpenCVのDLLやOpenCvSharpの対象プラットフォーム(x86またはx64)と、プロジェクトのプラットフォーム設定が合っていますか?\n")
                    .Append("\n")
                    .Append(ex.ToString());
            }
            else
            {
                message.AppendFormat("{0}\n", ex.Message);
                message.Append("*** An exception has occurred because of P/Invoke. ***\n")
                    .Append("Please check the following:\n")
                    .Append("(1) OpenCV's DLL files exist in the same directory as the executable file.\n")
                    .Append("(2) Visual C++ Redistributable Package has been installed.\n")
                    .Append("(3) The target platform(x86/x64) of OpenCV's DLL files and OpenCvSharp is the same as your project's.\n")
                    .Append("\n")
                    .Append(ex.ToString());
            }            
            return new OpenCvSharpException(message.ToString(), ex);
        }
    }
}
