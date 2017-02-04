using System;
using System.Collections.Generic;
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
        private const string VisualStudioVersion = "2015";

        private static readonly IReadOnlyDictionary<string, string[]> dllFiles = new Dictionary<string, string[]>
        {
            {
                "net20", new[]
                {
                    @"OpenCvSharp\bin\Release\net20\OpenCvSharp.dll",
                    @"OpenCvSharp\bin\Release\net20\OpenCvSharp.dll.config",
                    @"OpenCvSharp.Blob\bin\Release\net20\OpenCvSharp.Blob.dll",
                }
            },{
                "net40", new[]
                {
                    @"OpenCvSharp\bin\Release\net40\OpenCvSharp.dll",
                    @"OpenCvSharp\bin\Release\net40\OpenCvSharp.dll.config",
                    @"OpenCvSharp.Blob\bin\Release\net40\OpenCvSharp.Blob.dll",
                    @"OpenCvSharp.Extensions\bin\Release\net40\OpenCvSharp.Extensions.dll",
                    @"OpenCvSharp.UserInterface\bin\Release\net40\OpenCvSharp.UserInterface.dll",
                }
            },{
                "net46", new[]
                {
                    @"OpenCvSharp\bin\Release\net46\OpenCvSharp.dll",
                    @"OpenCvSharp\bin\Release\net46\OpenCvSharp.dll.config",
                    @"OpenCvSharp.Blob\bin\Release\net46\OpenCvSharp.Blob.dll",
                    @"OpenCvSharp.Extensions\bin\Release\net46\OpenCvSharp.Extensions.dll",
                    @"OpenCvSharp.UserInterface\bin\Release\net46\OpenCvSharp.UserInterface.dll",
                }
            },{
                "netstandard1.6", new[]
                {
                    @"OpenCvSharp\bin\Release\netstandard1.6\OpenCvSharp.dll",
                    @"OpenCvSharp\bin\Release\netstandard1.6\OpenCvSharp.dll.config",
                    @"OpenCvSharp.Blob\bin\Release\netstandard1.6\OpenCvSharp.Blob.dll",
                }
            }
        };

        private static readonly string debuggerVisualizerPath =
            @"OpenCvSharp.DebuggerVisualizers{0}\bin\Release\net20\OpenCvSharp.DebuggerVisualizers{0}.dll";

        private static readonly string debuggerVisualizerPath2015 =
            @"OpenCvSharp.DebuggerVisualizers{0}\bin\Release\OpenCvSharp.DebuggerVisualizers{0}.dll";

        private static readonly string[] debuggerVisualizerVersions =
        {
            "2010", "2012", "2013", "2015",
        };

        private static readonly string[] xmlFiles = {
            @"OpenCvSharp\bin\{0}\net46\OpenCvSharp.xml",
            @"OpenCvSharp.Blob\bin\{0}\net46\OpenCvSharp.Blob.xml",
            @"OpenCvSharp.Extensions\bin\{0}\net46\OpenCvSharp.Extensions.xml",
            @"OpenCvSharp.UserInterface\bin\{0}\net46\OpenCvSharp.UserInterface.xml",
        };

        private static readonly string[] platforms = {
            "x86",
            "x64"
        };
        private static readonly string[] languages = {
            "Release",
            "Release-JP"
        };

        private static readonly string[] ignoredExt = {
            ".pdb",
            ".bak",
            ".user",
            ".suo",
            ".git",
            ".gitignore",
        };
        private static readonly string[] ignoredDir = {
            ".svn",
            ".git",
            "bin",
            "obj",
        };

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
            textBox_Src.Text = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                @"Visual Studio " + VisualStudioVersion + @"\Projects\OpenCvSharp");
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
            
            MakeBinaryPackage(textBox_Src.Text, textBox_Dst.Text, textBox_Version.Text);
            MakeSamplePackage(textBox_Src.Text, textBox_Dst.Text, textBox_Version.Text);
            MessageBox.Show(@"Packages created successfully.");

            b.Enabled = true;
        }

        /// <summary>
        /// バイナリのzipパッケージを作成
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="dirDst"></param>
        /// <param name="opencvVersion"></param>
        private void MakeBinaryPackage(string dir, string dirDst, string opencvVersion)
        {
            string dirSrc = Path.Combine(dir, "src");

            foreach (string pf in platforms)
            {
                using (ZipFile zf = new ZipFile())
                {
                    // net20, net40といったplatformごとにDLLを選択
                    foreach (var framework in dllFiles)
                    {
                        var frameworkName = framework.Key;
                        foreach (var dllFileName in framework.Value)
                        {
                            string dllPath = Path.Combine(dirSrc, dllFileName);
                            ZipEntry e = zf.AddFile(dllPath);
                            e.FileName = Path.Combine(frameworkName, Path.GetFileName(dllPath));
                        }
                    }

                    // XMLドキュメントコメントを選択
                    foreach (string lang in languages)
                    {
                        foreach (string f in xmlFiles)
                        {
                            string xml = Path.Combine(dirSrc, String.Format(f, lang));
                            if (!File.Exists(xml))
                                continue;
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

                    // Debugger Visualizerを選択
                    foreach (string version in debuggerVisualizerVersions)
                    {
                        var dvPath = (version == "2015")
                            ? String.Format(debuggerVisualizerPath2015, version)
                            : String.Format(debuggerVisualizerPath, version);
                        string dllFileName = Path.Combine(dirSrc, dvPath);
                        string zipFileName = Path.Combine(
                            "DebuggerVisualizers", version, Path.GetFileName(dvPath));
                        ZipEntry e = zf.AddFile(dllFileName);
                        e.FileName = zipFileName;
                    }

                    // テキストを選択
                    {
                        ZipEntry e1 = zf.AddFile(Path.Combine(dir, "LICENSE"));
                        e1.FileName = Path.GetFileName("LICENSE");
                        ZipEntry e2 = zf.AddFile(Path.Combine(dir, "README.md"));
                        e2.FileName = Path.GetFileName("README.md");
                    }

                    string dst = Path.Combine(
                        dirDst, GetBinaryDstDirName(pf, opencvVersion)) + ".zip";
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
            dirSrc = Path.Combine(dirSrc, "samples");
            dirDst = Path.Combine(dirDst, GetSampleDstDirName(version));

            CopyDirectory(dirSrc, dirDst);

            using (var zf = new ZipFile())
            {
                zf.AddDirectory(dirDst);
                zf.Save(dirDst + ".zip");
            }

            Directory.Delete(dirDst, true);
        }

        private string GetBinaryDstDirName(string pf, string version)
        {
            string date = DateTime.Now.ToString("yyyyMMdd");
            return $"OpenCvSharp-{version}-{pf}-{date}";
        }
        private string GetSampleDstDirName(string version)
        {
            string date = DateTime.Now.ToString("yyyyMMdd");
            return $"Sample-{version}-{date}";
        }

        /// <summary>
        /// ディレクトリをコピーする。
        /// .svn bin obj は除外。
        /// </summary>
        /// <param name="sourceDirName">コピーするディレクトリ</param>
        /// <param name="destDirName">コピー先のディレクトリ</param>
        /// <remarks>http://dobon.net/vb/dotnet/file/copyfolder.html から拝借</remarks>
        private static void CopyDirectory(
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
                             where !ignoredExt.Contains(Path.GetExtension(f)?.ToLower()) && Path.GetFileName(f) != "OpenCvSharp.DebuggerVisualizers.dll"
                             select f;            
            foreach (string file in files)
            {
                File.Copy(file, destDirName + Path.GetFileName(file), true);
            }

            // コピー元のディレクトリにあるディレクトリについて、再帰的に呼び出す
            var dirs = from d in Directory.GetDirectories(sourceDirName)
                       where !ignoredDir.Contains(Path.GetFileName(d))
                       select d;
            foreach (string dir in dirs)
            {
                CopyDirectory(dir, destDirName + Path.GetFileName(dir));
            }
        }

    }
}
