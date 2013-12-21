using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OpenCvSharp.Utilities
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
                IntPtr zero = IntPtr.Zero;
                // cxcore
                CvInvoke.cvReleaseImage(ref zero);
                // cv                
                CvInvoke.cvReleaseHist(ref zero);
            }
            catch (DllNotFoundException e)
            {
                DllImportError(e);
            }
            catch (BadImageFormatException e)
            {
                DllImportError(e);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// DllImportの際にDllNotFoundExceptionかBadImageFormatExceptionが発生した際に呼び出されるメソッド。
        /// エラーメッセージを表示して解決策をユーザに示す。
        /// </summary>
        /// <param name="e"></param>
        public static void DllImportError(Exception e)
        {
            string nl = Environment.NewLine;
            if (System.Globalization.CultureInfo.CurrentCulture.Name.Contains("ja"))
            {
                MessageBox.Show(
                    "P/Invokeが原因で例外が発生しました。" + nl + "以下の項目を確認して下さい。" + nl + nl +
                    "1. OpenCVのDLLが実行ファイルと同じ場所に置かれていますか? またはパスが正しく通っていますか?" + nl +
                    "2. Visual C++ Redistributable Packageをインストールしましたか?" + nl +
                    "3. OpenCVのDLLやOpenCvSharpの対象プラットフォーム(x86またはx64)と、プロジェクトのプラットフォーム設定が合っていますか?" + nl + nl +
                    e.ToString(),
                    "OpenCvSharp Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }
            else
            {
                MessageBox.Show(
                    "An exception has occurred because of P/Invoke." + nl + "Please check the following:" + nl + nl +
                    "1. OpenCV's DLL files exist in the same directory as the executable file." + nl +
                    "2. Visual C++ Redistributable Package has been installed." + nl +
                    "3. The target platform(x86/x64) of OpenCV's DLL files and OpenCvSharp is the same as your project's." + nl + nl +
                    e.ToString(),
                    "OpenCvSharp Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }
        }
    }
}
