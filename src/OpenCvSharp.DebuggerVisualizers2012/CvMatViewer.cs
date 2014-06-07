using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenCvSharp.DebuggerVisualizers2012
{
    /// <summary>
    /// CvMatの中身の値を表示するビューア
    /// </summary>
    public partial class CvMatViewer : Form
    {
        private readonly CvMatProxy proxy;
        private readonly CvScalar[,] data;

        public CvMatProxy ModifiedProxy 
        {
            get
            {
                return new CvMatProxy(data, proxy.Rows, proxy.Cols, proxy.ElemChannels);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CvMatViewer()
        {
            InitializeComponent();
            proxy = null;
            data = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="proxy"></param>
        public CvMatViewer(CvMatProxy proxy)
            : this()
        {
            this.proxy = proxy;
            data = new CvScalar[proxy.Rows, proxy.Cols];
            for (int r = 0; r < proxy.Rows; r++)
            {
                for (int c = 0; c < proxy.Cols; c++)
                {
                    data[r, c] = proxy.Data[r, c];
                }
            }
        }

        #region Event handlers
        /// <summary>
        /// フォームが開くとき
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // キャプション
            Text = GetWindowCaption();
            // コントロールの初期化
            InitializeDataGridView(proxy);
            InitializeComboBox(proxy);
        }

        /// <summary>
        /// チャンネル数設定のComboBoxのインデックスに変更があったとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox_NChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox cb = (ToolStripComboBox)sender;

            switch (cb.SelectedIndex)
            {
                // All channels
                case 0:
                    FillCellValue(0);
                    dataGridView.ReadOnly = true;
                    dataGridView.BackgroundColor = SystemColors.ControlDark;
                    break;
                // x channel
                case 1:
                case 2:
                case 3:
                case 4:
                    FillCellValue(cb.SelectedIndex);
                    dataGridView.ReadOnly = false;
                    break;
                default:
                    throw new Exception("Not expected index");
            }
        }

        /// <summary>
        /// セルの値の検証
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            const string ErrorText = "The cell value is invalid. \r\nIt must be convertible to double.";

            DataGridView dgw = (DataGridView)sender;

            if (dgw.ReadOnly)
            {
                return;
            }

            int c = e.ColumnIndex;
            int r = e.RowIndex;
            string cellText = (string)e.FormattedValue;
            Type valuteType = dgw[c, r].Value.GetType();

            double value;
            if (!double.TryParse(cellText, out value))
            {                
                dgw[c, r].ErrorText = ErrorText;
                MessageBox.Show(ErrorText, "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
        /// <summary>
        /// セルの値の検証終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int c = e.ColumnIndex;
            int r = e.RowIndex;

            dgv[c, r].ErrorText = null;
        }

        /// <summary>
        /// セル編集終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgw = (DataGridView)sender;
            int c = e.ColumnIndex;
            int r = e.RowIndex;
            string cellText = (string)(dgw[c, r].Value);
            double value;

            if (double.TryParse(cellText, out value))
            {
                data[r, c] = value;
            }
        }
        #endregion

        #region private methods

        /// <summary>
        /// フォームのタイトルバーに表示するテキストを取得する
        /// </summary>
        /// <returns></returns>
        private string GetWindowCaption()
        {
            return string.Format("CvMatViewer - Rows:{0} Cols:{1} ElemChannels:{2}", proxy.Rows, proxy.Cols, proxy.ElemChannels);
        }

        /// <summary>
        /// DataGridViewを初期化
        /// </summary>
        /// <param name="proxy"></param>
        private void InitializeDataGridView(CvMatProxy proxy)
        {
            // 行数、列数の指定
            dataGridView.RowCount = proxy.Rows;
            dataGridView.ColumnCount = proxy.Cols;

            // ヘッダセルの設定
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                DataGridViewColumn c = dataGridView.Columns[i];
                c.HeaderText = string.Format("Col {0}", i);
                c.SortMode = DataGridViewColumnSortMode.NotSortable;    // 並び替え禁止
            }
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                DataGridViewRow r = dataGridView.Rows[i];
                r.HeaderCell.Value = string.Format("Row {0}", i);
            }
            dataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            // 値の設定
            FillCellValue(0);
        }

        /// <summary>
        /// DataGridViewに行列の値を表示
        /// </summary>
        /// <param name="channel">表示するチャンネル。0なら全部表示。</param>
        private void FillCellValue(int channel)
        {
            for (int r = 0; r < proxy.Rows; r++)
            {
                for (int c = 0; c < proxy.Cols; c++)
                {
                    DataGridViewCell cell = dataGridView[c, r];
                    CvScalar value = data[r, c];

                    switch (channel)
                    {
                        case 0:
                            cell.Value = value.ToString();
                            break;
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            cell.Value = value[channel - 1].ToString();
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// チャンネル数設定のComboBoxの初期化
        /// </summary>
        /// <param name="_proxy"></param>
        private void InitializeComboBox(CvMatProxy proxy)
        {
            ToolStripComboBox cb = toolStripComboBox_NChannels;
            cb.Items.Clear();
            cb.Items.Add("All channels");
            for (int i = 1; i <= proxy.ElemChannels; i++)
            {
                cb.Items.Add(string.Format("Channel {0}", i));
            }            

            cb.SelectedIndex = 0;
        }
        #endregion

    }
}
