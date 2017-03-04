using System;
using System.Windows.Forms;

namespace OpenCvSharp.UserInterface
{
#if LANG_JP
    /// <summary>
    /// ラベルがセットになったトラックバー
    /// </summary>
#else
    /// <summary>
    /// A Trackbar come with label
    /// </summary>
#endif
    public partial class TrackbarWithLabel : UserControl
    {
        private readonly string labelText;

        /// <summary>
        /// Constructor
        /// </summary>
        public TrackbarWithLabel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="labelText"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <param name="pos"></param>
        public TrackbarWithLabel(string labelText, int pos, int max, int min) : this()
        {
            this.labelText = labelText;            
            trackBar.Maximum = max;
            trackBar.Minimum = min;
            trackBar.Value = pos;
            trackBar.TickFrequency = (max - min) / 10;
            SetLabelText();
        }

#if LANG_JP
        /// <summary>
        /// TrackBarコントロール
        /// </summary>
#else
        /// <summary>
        /// TrackBar control
        /// </summary>
#endif
        public TrackBar Trackbar
        {
            get { return trackBar; }
        }
#if LANG_JP
        /// <summary>
        /// Labelコントロール
        /// </summary>
#else
        /// <summary>
        /// Label control
        /// </summary>
#endif
        public Label Label
        {
            get { return label; }
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetLabelText()
        {
            string text = string.Format("{0} : {1}", labelText, trackBar.Value);
            label.Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _trackBar_ValueChanged(object sender, EventArgs e)
        {
            SetLabelText();
        }
    }
}
