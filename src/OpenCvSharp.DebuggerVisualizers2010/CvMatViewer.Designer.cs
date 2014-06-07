namespace OpenCvSharp.DebuggerVisualizers
{
    partial class CvMatViewer
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_NChannels = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox_NChannels = new System.Windows.Forms.ToolStripComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_NChannels,
            this.toolStripComboBox_NChannels});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(384, 26);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip";
            // 
            // toolStripLabel_NChannels
            // 
            this.toolStripLabel_NChannels.Name = "toolStripLabel_NChannels";
            this.toolStripLabel_NChannels.Size = new System.Drawing.Size(54, 23);
            this.toolStripLabel_NChannels.Text = "Channel";
            // 
            // toolStripComboBox_NChannels
            // 
            this.toolStripComboBox_NChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox_NChannels.Name = "toolStripComboBox_NChannels";
            this.toolStripComboBox_NChannels.Size = new System.Drawing.Size(121, 26);
            this.toolStripComboBox_NChannels.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_NChannels_SelectedIndexChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 26);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 21;
            this.dataGridView.Size = new System.Drawing.Size(384, 237);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValidated);
            this.dataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView_CellValidating);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            // 
            // CvMatViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 263);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CvMatViewer";
            this.Text = "CvMatViewer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_NChannels;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_NChannels;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}