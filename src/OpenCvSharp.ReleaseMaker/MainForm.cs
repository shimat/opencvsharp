using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Ionic.Zip;

namespace OpenCvSharp.ReleaseMaker
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OnLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            textBox_Src.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Visual Studio 2013\Projects\OpenCvSharp");
            textBox_Dst.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        /// <summary>
        /// Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Src
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Src_Click(object sender, EventArgs e)
        {
            folderBrowserDialog_Src.SelectedPath = textBox_Src.Text;
            if (folderBrowserDialog_Src.ShowDialog(this) == DialogResult.OK)
            {
                textBox_Src.Text = folderBrowserDialog_Src.SelectedPath;
            }
        }

        /// <summary>
        /// Dst
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Dst_Click(object sender, EventArgs e)
        {
            folderBrowserDialog_Dst.SelectedPath = textBox_Dst.Text;
            if (folderBrowserDialog_Dst.ShowDialog(this) == DialogResult.OK)
            {
                textBox_Dst.Text = folderBrowserDialog_Dst.SelectedPath;
            }
        }

        /// <summary>
        /// Make
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Make_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                MakeBinaryPackage(textBox_Src.Text, textBox_Dst.Text, textBox_Version.Text);
                MakeSamplePackage(textBox_Src.Text, textBox_Dst.Text, textBox_Version.Text);
                MessageBox.Show("生成成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                b.Enabled = true;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private static readonly string[] FileNames = new string[]{
            "OpenCvSharp.dll", 
            "OpenCvSharp.xml",
            "OpenCvSharp.dll.config",
            "OpenCvSharp.Blob.dll",
            "OpenCvSharp.Blob.xml",
            "OpenCvSharp.Blob.dll.config",
            "OpenCvSharp.CPlusPlus.dll",
            "OpenCvSharp.CPlusPlus.xml",
            "OpenCvSharp.Extensions.dll",
            "OpenCvSharp.Extensions.xml",
            "OpenCvSharp.MachineLearning.dll",
            "OpenCvSharp.MachineLearning.xml",
            "OpenCvSharp.MachineLearning.dll.config",
            "OpenCvSharp.UserInterface.dll",
            "OpenCvSharp.UserInterface.xml",
            "OpenCvSharp.Gpu.dll",
            "OpenCvSharp.Gpu.xml",
            //"OpenCvSharp.DebuggerVisualizers.dll",
            //"OpenCvSharpExtern.dll",
            "LGPL.txt",
            "ReadMe.txt",
        };
        private static readonly string[] Platforms = new string[] { 
            "x86", 
            "x64" 
        };
        private static readonly string[] Languages = new string[] { 
            "Release", 
            "Release JP" 
        };

        /// <summary>
        /// バイナリのzipパッケージを作成
        /// </summary>
        /// <param name="dirSrc"></param>
        /// <param name="dirDst"></param>
        /// <param name="language"></param>
        /// <param name="platform"></param>
        private void MakeBinaryPackage(string dirSrc, string dirDst, string version)
        {
            dirSrc = Path.Combine(dirSrc, version);

            foreach (string pf in Platforms)
            {
                using (ZipFile zf = new ZipFile())
                {
                    // DLLをまず選択
                    {
                        string srcBase = Path.Combine(Path.Combine(dirSrc, @"OpenCvSharp.Test\bin"), Path.Combine(pf, "Release"));
                        foreach (string f in FileNames)
                        {
                            if (Path.GetExtension(f).ToLower() != ".xml")
                            {
                                string src = Path.Combine(srcBase, f);
                                ZipEntry e = zf.AddFile(src);
                                e.FileName = Path.GetFileName(src);
                            }
                        }
                    }
                    // DebuggerVisualizerを持ってくる
                    {
                        string src = Path.Combine(dirSrc, @"OpenCvSharp.DebuggerVisualizers\bin\Release\OpenCvSharp.DebuggerVisualizers.dll");
                        ZipEntry e = zf.AddFile(src);
                        e.FileName = Path.GetFileName(src);
                    }
                    // XMLドキュメントコメントを選択
                    foreach (string lang in Languages)
                    {
                        string srcBase = Path.Combine(Path.Combine(dirSrc, @"OpenCvSharp.Test\bin"), Path.Combine(pf, lang));
                        foreach (string f in FileNames)
                        {
                            if (Path.GetExtension(f).ToLower() == ".xml")
                            {
                                string src = Path.Combine(srcBase, f);
                                ZipEntry e = zf.AddFile(src);
                                string lg = lang.Contains("JP") ? "Japanese" : "English";
                                e.FileName = Path.Combine("XmlDoc-" + lg, Path.GetFileName(src));
                            }
                        }
                    }
                    // OpenCvSharpExtern.dllを選択
                    {
                        string pfExtern = (pf == "x86") ? "Win32" : "x64";
                        // 2010を標準添付 
                        {
                            string externDir = Path.Combine(dirSrc, Path.Combine("Release", pfExtern));
                            string externFile = Path.Combine(externDir, "OpenCvSharpExtern.dll");
                            ZipEntry e = zf.AddFile(externFile);
                            e.FileName = Path.GetFileName(externFile);
                        }
                    }

                    string dst = Path.Combine(dirDst, GetBinaryDstDirName(pf, version)) + ".zip";
                    zf.Save(dst);
                }
            }
        }

        /// <summary>
        /// Sampleのzipアーカイブを作成
        /// </summary>
        /// <param name="dirSrc"></param>
        /// <param name="dirDst"></param>
        /// <param name="version"></param>
        private void MakeSamplePackage(string dirSrc, string dirDst, string version)
        {
            dirSrc = Path.Combine(Path.Combine(dirSrc, version), "OpenCvSharp.Test");
            dirDst = Path.Combine(dirDst, GetSampleDstDirName(version));

            CopyDirectory(dirSrc, dirDst);

            using (ZipFile zf = new ZipFile())
            {
                zf.AddDirectory(dirDst);
                zf.Save(dirDst + ".zip");
            }

            Directory.Delete(dirDst, true);
        }

        private string GetBinaryDstDirName(string pf, string version)
        {
            string date = DateTime.Now.ToString("yyyyMMdd");
            return string.Format("OpenCvSharp-{0}-{1}-{2}", version, pf, date);
        }
        private string GetSampleDstDirName(string version)
        {
            string date = DateTime.Now.ToString("yyyyMMdd");
            return string.Format("Sample-{0}-{1}", version, date);
        }

        /// <summary>
        /// ディレクトリの作成（既存のディレクトリがあれば削除してから）
        /// </summary>
        /// <param name="path"></param>
        private void CreateDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            Directory.CreateDirectory(path);
        }


        private static readonly string[] InvalidExt = new string[] { 
            ".pdb", 
            ".bak",
            ".user",
        };
        private static readonly string[] InvalidDir = new string[] { 
            ".svn", 
            "bin",
            "obj",            
        };

        /// <summary>
        /// ディレクトリをコピーする。
        /// .svn bin obj は除外。
        /// </summary>
        /// <param name="sourceDirName">コピーするディレクトリ</param>
        /// <param name="destDirName">コピー先のディレクトリ</param>
        /// <remarks>http://dobon.net/vb/dotnet/file/copyfolder.html から拝借</remarks>
        public static void CopyDirectory(
            string sourceDirName, string destDirName)
        {
            // コピー先のディレクトリがあれば削除
            if (Directory.Exists(destDirName))
            {
                Directory.Delete(destDirName, true);
            }

            // コピー先のディレクトリを作る
            Directory.CreateDirectory(destDirName);
            File.SetAttributes(destDirName, File.GetAttributes(sourceDirName));

            // コピー先のディレクトリ名の末尾に"\"をつける
            if (destDirName[destDirName.Length - 1] != Path.DirectorySeparatorChar)
            {
                destDirName = destDirName + Path.DirectorySeparatorChar;
            }

            // コピー元のディレクトリにあるファイルをコピー
            var files = from f in Directory.GetFiles(sourceDirName)
                             where !InvalidExt.Contains(Path.GetExtension(f).ToLower()) && Path.GetFileName(f) != "OpenCvSharp.DebuggerVisualizers.dll"
                             select f;            
            foreach (string file in files)
            {
                File.Copy(file, destDirName + Path.GetFileName(file), true);
            }

            // コピー元のディレクトリにあるディレクトリについて、再帰的に呼び出す
            var dirs = from d in Directory.GetDirectories(sourceDirName)
                       where !InvalidDir.Contains(Path.GetFileName(d))
                       select d;
            foreach (string dir in dirs)
            {
                CopyDirectory(dir, destDirName + Path.GetFileName(dir));
            }
        }

    }
}
