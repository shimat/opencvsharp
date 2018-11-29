namespace OpenCvSharp.ReleaseMaker
{
    partial class MainForm
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

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_Src = new System.Windows.Forms.TextBox();
            this.label_Src = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.button_Src = new System.Windows.Forms.Button();
            this.button_Dst = new System.Windows.Forms.Button();
            this.label_Dst = new System.Windows.Forms.Label();
            this.textBox_Dst = new System.Windows.Forms.TextBox();
            this.button_Make = new System.Windows.Forms.Button();
            this.folderBrowserDialog_Src = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog_Dst = new System.Windows.Forms.FolderBrowserDialog();
            this.label_Version = new System.Windows.Forms.Label();
            this.textBox_Version = new System.Windows.Forms.TextBox();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Src
            // 
            this.textBox_Src.Location = new System.Drawing.Point(107, 71);
            this.textBox_Src.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox_Src.Name = "textBox_Src";
            this.textBox_Src.Size = new System.Drawing.Size(626, 25);
            this.textBox_Src.TabIndex = 0;
            // 
            // label_Src
            // 
            this.label_Src.AutoSize = true;
            this.label_Src.Location = new System.Drawing.Point(20, 75);
            this.label_Src.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_Src.Name = "label_Src";
            this.label_Src.Size = new System.Drawing.Size(38, 18);
            this.label_Src.TabIndex = 1;
            this.label_Src.Text = "Src:";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_File});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(823, 35);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem_File
            // 
            this.toolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Exit});
            this.toolStripMenuItem_File.Name = "toolStripMenuItem_File";
            this.toolStripMenuItem_File.Size = new System.Drawing.Size(69, 29);
            this.toolStripMenuItem_File.Text = "File(&F)";
            // 
            // toolStripMenuItem_Exit
            // 
            this.toolStripMenuItem_Exit.Name = "toolStripMenuItem_Exit";
            this.toolStripMenuItem_Exit.Size = new System.Drawing.Size(144, 30);
            this.toolStripMenuItem_Exit.Text = "Exit(&X)";
            this.toolStripMenuItem_Exit.Click += new System.EventHandler(this.toolStripMenuItem_Exit_Click);
            // 
            // button_Src
            // 
            this.button_Src.Location = new System.Drawing.Point(745, 65);
            this.button_Src.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button_Src.Name = "button_Src";
            this.button_Src.Size = new System.Drawing.Size(58, 35);
            this.button_Src.TabIndex = 4;
            this.button_Src.Text = "...";
            this.button_Src.UseVisualStyleBackColor = true;
            this.button_Src.Click += new System.EventHandler(this.button_Src_Click);
            // 
            // button_Dst
            // 
            this.button_Dst.Location = new System.Drawing.Point(745, 112);
            this.button_Dst.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button_Dst.Name = "button_Dst";
            this.button_Dst.Size = new System.Drawing.Size(58, 35);
            this.button_Dst.TabIndex = 5;
            this.button_Dst.Text = "...";
            this.button_Dst.UseVisualStyleBackColor = true;
            this.button_Dst.Click += new System.EventHandler(this.button_Dst_Click);
            // 
            // label_Dst
            // 
            this.label_Dst.AutoSize = true;
            this.label_Dst.Location = new System.Drawing.Point(18, 120);
            this.label_Dst.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_Dst.Name = "label_Dst";
            this.label_Dst.Size = new System.Drawing.Size(38, 18);
            this.label_Dst.TabIndex = 6;
            this.label_Dst.Text = "Dst:";
            // 
            // textBox_Dst
            // 
            this.textBox_Dst.Location = new System.Drawing.Point(107, 115);
            this.textBox_Dst.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox_Dst.Name = "textBox_Dst";
            this.textBox_Dst.Size = new System.Drawing.Size(626, 25);
            this.textBox_Dst.TabIndex = 7;
            // 
            // button_Make
            // 
            this.button_Make.Location = new System.Drawing.Point(233, 217);
            this.button_Make.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button_Make.Name = "button_Make";
            this.button_Make.Size = new System.Drawing.Size(387, 76);
            this.button_Make.TabIndex = 8;
            this.button_Make.Text = "Make";
            this.button_Make.UseVisualStyleBackColor = true;
            this.button_Make.Click += new System.EventHandler(this.button_Make_Click);
            // 
            // folderBrowserDialog_Src
            // 
            this.folderBrowserDialog_Src.ShowNewFolderButton = false;
            // 
            // label_Version
            // 
            this.label_Version.AutoSize = true;
            this.label_Version.Location = new System.Drawing.Point(20, 165);
            this.label_Version.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_Version.Name = "label_Version";
            this.label_Version.Size = new System.Drawing.Size(68, 18);
            this.label_Version.TabIndex = 9;
            this.label_Version.Text = "Version:";
            // 
            // textBox_Version
            // 
            this.textBox_Version.Location = new System.Drawing.Point(107, 161);
            this.textBox_Version.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox_Version.Name = "textBox_Version";
            this.textBox_Version.Size = new System.Drawing.Size(81, 25);
            this.textBox_Version.TabIndex = 10;
            this.textBox_Version.Text = "4.0.0";
            // 
            // MainForm
            // 
            this.AcceptButton = this.button_Make;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 320);
            this.Controls.Add(this.textBox_Version);
            this.Controls.Add(this.label_Version);
            this.Controls.Add(this.button_Make);
            this.Controls.Add(this.textBox_Dst);
            this.Controls.Add(this.label_Dst);
            this.Controls.Add(this.button_Dst);
            this.Controls.Add(this.button_Src);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.label_Src);
            this.Controls.Add(this.textBox_Src);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "OpenCvSharp.ReleaseMaker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Src;
        private System.Windows.Forms.Label label_Src;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Exit;
        private System.Windows.Forms.Button button_Src;
        private System.Windows.Forms.Button button_Dst;
        private System.Windows.Forms.Label label_Dst;
        private System.Windows.Forms.TextBox textBox_Dst;
        private System.Windows.Forms.Button button_Make;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_Src;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_Dst;
        private System.Windows.Forms.Label label_Version;
        private System.Windows.Forms.TextBox textBox_Version;
    }
}

