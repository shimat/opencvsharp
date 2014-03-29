/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// Qtフォント
    /// </summary>
#else
    /// <summary>
    /// Qt Font structure
    /// </summary>
#endif
    public class CvFontQt : CvFont
    {
        #region Initialization and Disposal
#if LANG_JP
        /// <summary>
        /// 画像上にテキストを描画する際に利用されるフォントを作成します．
        /// </summary>
        /// <param name="nameFont">フォント名. 指定のフォントが見つからなければ，デフォルトフォントが利用されます．</param>
#else
        /// <summary>
        /// Create the font to be used to draw text on an image
        /// </summary>
        /// <param name="nameFont">Name of the font. The name should match the name of a system font (such as ``Times’‘). If the font is not found, a default one will be used.</param>
#endif
        public CvFontQt(string nameFont)
            : this(nameFont, -1, CvScalar.ScalarAll(0), FontWeight.Normal, FontStyle.Normal, 0)
        {
        }
#if LANG_JP
        /// <summary>
        /// 画像上にテキストを描画する際に利用されるフォントを作成します．
        /// </summary>
        /// <param name="nameFont">フォント名. 指定のフォントが見つからなければ，デフォルトフォントが利用されます．</param>
        /// <param name="pointSize">ォントサイズ．これが，未指定，または0以下の値の場合，フォンとのポイントサイズはシステム依存のデフォルト値にセットされます．通常は，12ポイントです．</param>
#else
        /// <summary>
        /// Create the font to be used to draw text on an image
        /// </summary>
        /// <param name="nameFont">Name of the font. The name should match the name of a system font (such as ``Times’‘). If the font is not found, a default one will be used.</param>
        /// <param name="pointSize">Size of the font. If not specified, equal zero or negative, the point size of the font is set to a system-dependent default value. Generally, this is 12 points.</param>
#endif
        public CvFontQt(string nameFont, int pointSize)
            : this(nameFont, pointSize, CvScalar.ScalarAll(0), FontWeight.Normal, FontStyle.Normal, 0)
        {
        }
#if LANG_JP
        /// <summary>
        /// 画像上にテキストを描画する際に利用されるフォントを作成します．
        /// </summary>
        /// <param name="nameFont">フォント名. 指定のフォントが見つからなければ，デフォルトフォントが利用されます．</param>
        /// <param name="pointSize">ォントサイズ．これが，未指定，または0以下の値の場合，フォンとのポイントサイズはシステム依存のデフォルト値にセットされます．通常は，12ポイントです．</param>
        /// <param name="color">BGRA で表現されるフォントカラー．</param>
#else
        /// <summary>
        /// Create the font to be used to draw text on an image
        /// </summary>
        /// <param name="nameFont">Name of the font. The name should match the name of a system font (such as ``Times’‘). If the font is not found, a default one will be used.</param>
        /// <param name="pointSize">Size of the font. If not specified, equal zero or negative, the point size of the font is set to a system-dependent default value. Generally, this is 12 points.</param>
        /// <param name="color">Color of the font in BGRA – A = 255 is fully transparent. Use the macro CV _ RGB for simplicity.</param>
#endif
        public CvFontQt(string nameFont, int pointSize, CvScalar color)
            : this(nameFont, pointSize, color, FontWeight.Normal, FontStyle.Normal, 0)
        {
        }
#if LANG_JP
        /// <summary>
        /// 画像上にテキストを描画する際に利用されるフォントを作成します．
        /// </summary>
        /// <param name="nameFont">フォント名. 指定のフォントが見つからなければ，デフォルトフォントが利用されます．</param>
        /// <param name="pointSize">ォントサイズ．これが，未指定，または0以下の値の場合，フォンとのポイントサイズはシステム依存のデフォルト値にセットされます．通常は，12ポイントです．</param>
        /// <param name="color">BGRA で表現されるフォントカラー．</param>
        /// <param name="weight">フォントの太さ</param>
#else
        /// <summary>
        /// Create the font to be used to draw text on an image
        /// </summary>
        /// <param name="nameFont">Name of the font. The name should match the name of a system font (such as ``Times’‘). If the font is not found, a default one will be used.</param>
        /// <param name="pointSize">Size of the font. If not specified, equal zero or negative, the point size of the font is set to a system-dependent default value. Generally, this is 12 points.</param>
        /// <param name="color">Color of the font in BGRA – A = 255 is fully transparent. Use the macro CV _ RGB for simplicity.</param>
        /// <param name="weight">The operation flags</param>
#endif
        public CvFontQt(string nameFont, int pointSize, CvScalar color, FontWeight weight)
            : this(nameFont, pointSize, color, weight, FontStyle.Normal, 0)
        {
        }
#if LANG_JP
        /// <summary>
        /// 画像上にテキストを描画する際に利用されるフォントを作成します．
        /// </summary>
        /// <param name="nameFont">フォント名. 指定のフォントが見つからなければ，デフォルトフォントが利用されます．</param>
        /// <param name="pointSize">ォントサイズ．これが，未指定，または0以下の値の場合，フォンとのポイントサイズはシステム依存のデフォルト値にセットされます．通常は，12ポイントです．</param>
        /// <param name="color">BGRA で表現されるフォントカラー．</param>
        /// <param name="weight">フォントの太さ</param>
        /// <param name="style">処理フラグ</param>
#else
        /// <summary>
        /// Create the font to be used to draw text on an image
        /// </summary>
        /// <param name="nameFont">Name of the font. The name should match the name of a system font (such as ``Times’‘). If the font is not found, a default one will be used.</param>
        /// <param name="pointSize">Size of the font. If not specified, equal zero or negative, the point size of the font is set to a system-dependent default value. Generally, this is 12 points.</param>
        /// <param name="color">Color of the font in BGRA – A = 255 is fully transparent. Use the macro CV _ RGB for simplicity.</param>
        /// <param name="weight">The operation flags</param>
        /// <param name="style">The operation flags</param>
#endif
        public CvFontQt(string nameFont, int pointSize, CvScalar color, FontWeight weight, FontStyle style)
            : this(nameFont, pointSize, color, weight, style, 0)
        {
        }
#if LANG_JP
        /// <summary>
        /// 画像上にテキストを描画する際に利用されるフォントを作成します．
        /// </summary>
        /// <param name="nameFont">フォント名. 指定のフォントが見つからなければ，デフォルトフォントが利用されます．</param>
        /// <param name="pointSize">ォントサイズ．これが，未指定，または0以下の値の場合，フォンとのポイントサイズはシステム依存のデフォルト値にセットされます．通常は，12ポイントです．</param>
        /// <param name="color">BGRA で表現されるフォントカラー．</param>
        /// <param name="weight">フォントの太さ</param>
        /// <param name="style">処理フラグ</param>
        /// <param name="spacing">文字間のスペース．正負の値が利用できます．</param>
#else
        /// <summary>
        /// Create the font to be used to draw text on an image
        /// </summary>
        /// <param name="nameFont">Name of the font. The name should match the name of a system font (such as ``Times’‘). If the font is not found, a default one will be used.</param>
        /// <param name="pointSize">Size of the font. If not specified, equal zero or negative, the point size of the font is set to a system-dependent default value. Generally, this is 12 points.</param>
        /// <param name="color">Color of the font in BGRA – A = 255 is fully transparent. Use the macro CV _ RGB for simplicity.</param>
        /// <param name="weight">The operation flags</param>
        /// <param name="style">The operation flags</param>
        /// <param name="spacing">Spacing between characters. Can be negative or positive.</param>
#endif
        public CvFontQt(string nameFont, int pointSize, CvScalar color, FontWeight weight, FontStyle style, int spacing)
        {
            if (nameFont == null)
                throw new ArgumentNullException("nameFont");

            ptr = base.AllocMemory(SizeOf);
            WCvFont font = NativeMethods.cvFontQt(nameFont, pointSize, color, weight, style, spacing);
            using (ScopedGCHandle gch = new ScopedGCHandle(font, GCHandleType.Pinned))
            {
                Util.CopyMemory(ptr, gch.AddrOfPinnedObject(), SizeOf);
            }
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
            // 親の解放処理
            base.Dispose(disposing);
        }
        #endregion
    }
}
