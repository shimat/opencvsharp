namespace OpenCvSharp.UserInterface
{
    partial class CvWindowEx
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._panelTrackbar = new System.Windows.Forms.Panel();
            this._pictureBox = new OpenCvSharp.UserInterface.PictureBoxIpl();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _panelTrackbar
            // 
            this._panelTrackbar.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelTrackbar.Location = new System.Drawing.Point(0, 0);
            this._panelTrackbar.Name = "_panelTrackbar";
            this._panelTrackbar.Size = new System.Drawing.Size(584, 0);
            this._panelTrackbar.TabIndex = 0;
            // 
            // _pictureBox
            // 
            this._pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pictureBox.Location = new System.Drawing.Point(0, 0);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(584, 443);
            this._pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pictureBox.TabIndex = 2;
            this._pictureBox.TabStop = false;
            // 
            // CvWindowEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 443);
            this.Controls.Add(this._pictureBox);
            this.Controls.Add(this._panelTrackbar);
            this.KeyPreview = true;
            this.Name = "CvWindowEx";
            this.Text = "CvWindowEx";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CvWindowEx_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _panelTrackbar;
        private PictureBoxIpl _pictureBox;
    }
}