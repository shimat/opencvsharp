using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenCvSharp.UserInterface
{
#if LANG_JP
    /// <summary>
    /// IplImageの表示をサポートしたPictureBox
    /// </summary>
#else
    /// <summary>
    /// PictureBox control which supports IplImage
    /// </summary>
#endif
    public class PictureBoxIpl : PictureBox
    {
        private IplImage _imageIpl;


#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
#else
        /// <summary>
        /// Constructor
        /// </summary>
#endif
        public PictureBoxIpl() : base()
        {
            _imageIpl = null;
        }


#if LANG_JP
        /// <summary>
        /// 表示するIplImageを取得・設定する
        /// </summary>
        [Description("表示するIplImageを取得・設定する")]
#else
        /// <summary>
        /// Gets or sets the IplImage instance to be shown
        /// </summary>
        [Description("Gets or sets the IplImage instance to be shown")]
#endif
        [Browsable(false)]
        [Category()]
        [DefaultValue(null)]
        public IplImage ImageIpl
        {
            get { return _imageIpl; }
            set
            {
                if (value != null && value.IsDisposed)
                {
                    throw new ArgumentException("the image is disposed.", "value");
                }

                _imageIpl = value;
                if (Image != null)
                {
                    Image.Dispose();
                }
                if (value == null)
                {
                    Image = null;
                }
                else
                {
                    Image = BitmapConverter.ToBitmap(value);
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 表示されているIplImageを更新する
        /// </summary>
#else
        /// <summary>
        /// Refreshes the shown image
        /// </summary>
#endif
        public void RefreshIplImage()
        {
            if (ImageIpl == null)
            {
                return;
            }
            if (Image.Width != ImageIpl.Width || Image.Height != ImageIpl.Height)
            {
                Image = BitmapConverter.ToBitmap(ImageIpl);
            }
            else
            {
                BitmapConverter.ToBitmap(ImageIpl, (Bitmap)Image);
            }
        }

#if LANG_JP
        /// <summary>
        /// 表示されているIplImageを更新する
        /// </summary>
        /// <param name="img"></param>
#else
        /// <summary>
        /// Refreshes the shown image
        /// </summary>
        /// <param name="img"></param>
#endif
        public void RefreshIplImage(IplImage img)
        {
            if (img == null || Image == null)
            {
                ImageIpl = img;
            }
            else if (Image.Width != img.Width || Image.Height != img.Height)
            {
                ImageIpl = img;
            }
            else
            {
                _imageIpl = img;
                BitmapConverter.ToBitmap(img, (Bitmap)Image);
            }
            Refresh();
        }
    }
}
