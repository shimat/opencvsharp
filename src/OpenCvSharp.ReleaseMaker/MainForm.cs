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
        private const string VSVersion = "2012";

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
            textBox_Src.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Visual Studio " + VSVersion + @"\Projects\OpenCvSharp");
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
            //try
            {
                MakeBinaryPackage(textBox_Src.Text, textBox_Dst.Text, textBox_Version.Text);
                MakeSamplePackage(textBox_Src.Text, textBox_Dst.Text, textBox_Version.Text);
                MessageBox.Show("生成成功");
            }
            /*catch (Exception ex)
            {
                throw;
                MessageBox.Show(ex.ToString());
            }
            finally*/
            {
                b.Enabled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static readonly string[] DllFiles = new string[]{
            @"OpenCvSharp\bin\Release\OpenCvSharp.dll", 
            @"OpenCvSharp\bin\Release\OpenCvSharp.dll.config", 
            @"OpenCvSharp.Blob\bin\Release\OpenCvSharp.Blob.dll", 
            @"OpenCvSharp.Blob\bin\Release\OpenCvSharp.Blob.dll.config", 
            @"OpenCvSharp.CPlusPlus\bin\Release\OpenCvSharp.CPlusPlus.dll", 
            @"OpenCvSharp.CPlusPlus\bin\Release\OpenCvSharp.CPlusPlus.dll.config", 
            @"OpenCvSharp.Extensions\bin\Release\OpenCvSharp.Extensions.dll", 
            @"OpenCvSharp.MachineLearning\bin\Release\OpenCvSharp.MachineLearning.dll", 
            @"OpenCvSharp.MachineLearning\bin\Release\OpenCvSharp.MachineLearning.dll.config", 
            @"OpenCvSharp.UserInterface\bin\Release\OpenCvSharp.UserInterface.dll", 
            //"OpenCvSharp.Gpu.dll",
            @"OpenCvSharp.DebuggerVisualizers\bin\Release\OpenCvSharp.DebuggerVisualizers.dll", 
            //"OpenCvSharpExtern.dll",
        };

        /// <summary>
        /// 
        /// </summary>
        private static readonly string[] XmlFiles = new string[]{
            @"OpenCvSharp\bin\{0}\OpenCvSharp.xml", 
            @"OpenCvSharp.Blob\bin\{0}\OpenCvSharp.Blob.xml", 
            @"OpenCvSharp.CPlusPlus\bin\Release\OpenCvSharp.CPlusPlus.xml", 
            @"OpenCvSharp.Extensions\bin\{0}\OpenCvSharp.Extensions.xml", 
            @"OpenCvSharp.MachineLearning\bin\{0}\OpenCvSharp.MachineLearning.xml", 
            @"OpenCvSharp.UserInterface\bin\{0}\OpenCvSharp.UserInterface.xml", 
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
        private void MakeBinaryPackage(string dir, string dirDst, string version)
        {
            string dirSrc = Path.Combine(dir, "src");

            foreach (string pf in Platforms)
            {
                using (ZipFile zf = new ZipFile())
                {
                    // DLLを選択
                    foreach (string f in DllFiles)
                    {
                        string dll = Path.Combine(dirSrc, f);
                        ZipEntry e = zf.AddFile(dll);
                        e.FileName = Path.GetFileName(dll);
                    }

                    // XMLドキュメントコメントを選択
                    foreach (string lang in Languages)
                    {
                        foreach (string f in XmlFiles)
                        {
                            string xml = Path.Combine(dirSrc, String.Format(f, lang));
                            ZipEntry e = zf.AddFile(xml);
                            string lg = lang.Contains("JP") ? "Japanese" : "English";
                            e.FileName = Path.Combine("XmlDoc-" + lg, Path.GetFileName(xml));
                        }
                    }

                    // OpenCvSharpExtern.dllを選択
                    {
                        string pfExtern = (pf == "x86") ? "Win32" : "x64";
                        {
                            string externDir = Path.Combine(dirSrc, Path.Combine("Release", pfExtern));
                            string externFile = Path.Combine(externDir, "OpenCvSharpExtern.dll");
                            ZipEntry e = zf.AddFile(externFile);
                            e.FileName = Path.GetFileName(externFile);
                        }
                    }

                    // テキストを選択
                    {
                        ZipEntry e1 = zf.AddFile(Path.Combine(dir, "LICENSE.txt"));
                        e1.FileName = Path.GetFileName("LICENSE.txt");
                        ZipEntry e2 = zf.AddFile(Path.Combine(dir, "README.md"));
                        e2.FileName = Path.GetFileName("README.md");
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
            dirSrc = Path.Combine(dirSrc, "sample");
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
            ".suo",
        };
        private static readonly string[] InvalidDir = new string[] { 
            ".svn", 
            ".git", 
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
