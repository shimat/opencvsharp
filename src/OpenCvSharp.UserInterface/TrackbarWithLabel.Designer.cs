namespace OpenCvSharp.UserInterface
{
    partial class TrackbarWithLabel
    {
        /// <summary> 
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this._trackBar = new System.Windows.Forms.TrackBar();
            this._label = new System.Windows.Forms.Label();
            this._splitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this._trackBar)).BeginInit();
            this._splitContainer.Panel1.SuspendLayout();
            this._splitContainer.Panel2.SuspendLayout();
            this._splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _trackBar
            // 
            this._trackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this._trackBar.Location = new System.Drawing.Point(0, 0);
            this._trackBar.Name = "_trackBar";
            this._trackBar.Size = new System.Drawing.Size(403, 49);
            this._trackBar.TabIndex = 0;
            this._trackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this._trackBar.ValueChanged += new System.EventHandler(this._trackBar_ValueChanged);
            // 
            // _label
            // 
            this._label.Dock = System.Windows.Forms.DockStyle.Fill;
            this._label.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._label.Location = new System.Drawing.Point(0, 0);
            this._label.Name = "_label";
            this._label.Size = new System.Drawing.Size(139, 49);
            this._label.TabIndex = 1;
            this._label.Text = "Label";
            this._label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _splitContainer
            // 
            this._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._splitContainer.Location = new System.Drawing.Point(0, 0);
            this._splitContainer.Name = "_splitContainer";
            // 
            // _splitContainer.Panel1
            // 
            this._splitContainer.Panel1.Controls.Add(this._label);
            this._splitContainer.Panel1MinSize = 100;
            // 
            // _splitContainer.Panel2
            // 
            this._splitContainer.Panel2.Controls.Add(this._trackBar);
            this._splitContainer.Size = new System.Drawing.Size(546, 49);
            this._splitContainer.SplitterDistance = 139;
            this._splitContainer.TabIndex = 2;
            // 
            // TrackbarWithLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._splitContainer);
            this.Name = "TrackbarWithLabel";
            this.Size = new System.Drawing.Size(546, 49);
            ((System.ComponentModel.ISupportInitialize)(this._trackBar)).EndInit();
            this._splitContainer.Panel1.ResumeLayout(false);
            this._splitContainer.Panel2.ResumeLayout(false);
            this._splitContainer.Panel2.PerformLayout();
            this._splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar _trackBar;
        private System.Windows.Forms.Label _label;
        private System.Windows.Forms.SplitContainer _splitContainer;
    }
}
