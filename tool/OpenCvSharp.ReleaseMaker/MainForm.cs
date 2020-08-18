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
        private static readonly IReadOnlyDictionary<string, string[]> dllFiles = new Dictionary<string, string[]>
        {
            {
                "net48", new[]
                {
                    @"OpenCvSharp\bin\Release\net48\OpenCvSharp.dll",
                    @"OpenCvSharp\bin\Release\net48\OpenCvSharp.dll.config",
                    @"OpenCvSharp\bin\Release\net48\OpenCvSharp.pdb",
                    @"OpenCvSharp.Blob\bin\Release\net48\OpenCvSharp.Blob.dll",
                    @"OpenCvSharp.Blob\bin\Release\net48\OpenCvSharp.Blob.pdb",
                    @"OpenCvSharp.Extensions\bin\Release\net48\OpenCvSharp.Extensions.dll",
                    @"OpenCvSharp.Extensions\bin\Release\net48\OpenCvSharp.Extensions.pdb",
                    @"OpenCvSharp.WpfExtensions\bin\Release\net48\OpenCvSharp.WpfExtensions.dll",
                    @"OpenCvSharp.WpfExtensions\bin\Release\net48\OpenCvSharp.WpfExtensions.pdb",
                }
            },{
                "net461", new[]
                {
                    @"OpenCvSharp\bin\Release\net461\OpenCvSharp.dll",
                    @"OpenCvSharp\bin\Release\net461\OpenCvSharp.dll.config",
                    @"OpenCvSharp\bin\Release\net461\OpenCvSharp.pdb",
                    @"OpenCvSharp.Blob\bin\Release\net461\OpenCvSharp.Blob.dll",
                    @"OpenCvSharp.Blob\bin\Release\net461\OpenCvSharp.Blob.pdb",
                    @"OpenCvSharp.Extensions\bin\Release\net461\OpenCvSharp.Extensions.dll",
                    @"OpenCvSharp.Extensions\bin\Release\net461\OpenCvSharp.Extensions.pdb",
                    @"OpenCvSharp.WpfExtensions\bin\Release\net48\OpenCvSharp.WpfExtensions.dll",
                    @"OpenCvSharp.WpfExtensions\bin\Release\net48\OpenCvSharp.WpfExtensions.pdb",
                }
            },{
                "netstandard2.0", new[]
                {
                    @"OpenCvSharp\bin\Release\netstandard2.0\OpenCvSharp.dll",
                    @"OpenCvSharp\bin\Release\netstandard2.0\OpenCvSharp.dll.config",
                    @"OpenCvSharp\bin\Release\netstandard2.0\OpenCvSharp.pdb",
                    @"OpenCvSharp.Blob\bin\Release\netstandard2.0\OpenCvSharp.Blob.dll",
                    @"OpenCvSharp.Blob\bin\Release\netstandard2.0\OpenCvSharp.Blob.pdb",
                    @"OpenCvSharp.Extensions\bin\Release\netstandard2.0\OpenCvSharp.Extensions.dll",
                    @"OpenCvSharp.Extensions\bin\Release\netstandard2.0\OpenCvSharp.Extensions.pdb",
                }
            },{
                "netstandard2.1", new[]
                {
                    @"OpenCvSharp\bin\Release\netstandard2.1\OpenCvSharp.dll",
                    @"OpenCvSharp\bin\Release\netstandard2.1\OpenCvSharp.dll.config",
                    @"OpenCvSharp\bin\Release\netstandard2.1\OpenCvSharp.pdb",
                    @"OpenCvSharp.Blob\bin\Release\netstandard2.1\OpenCvSharp.Blob.dll",
                    @"OpenCvSharp.Blob\bin\Release\netstandard2.1\OpenCvSharp.Blob.pdb",
                    @"OpenCvSharp.Extensions\bin\Release\netstandard2.1\OpenCvSharp.Extensions.dll",
                    @"OpenCvSharp.Extensions\bin\Release\netstandard2.1\OpenCvSharp.Extensions.pdb",
                }
            },{
                "netcoreapp2.1", new[]
                {
                    @"OpenCvSharp\bin\Release\netcoreapp2.1\OpenCvSharp.dll",
                    @"OpenCvSharp\bin\Release\netcoreapp2.1\OpenCvSharp.dll.config",
                    @"OpenCvSharp\bin\Release\netcoreapp2.1\OpenCvSharp.pdb",
                    @"OpenCvSharp.Blob\bin\Release\netcoreapp2.1\OpenCvSharp.Blob.dll",
                    @"OpenCvSharp.Blob\bin\Release\netcoreapp2.1\OpenCvSharp.Blob.pdb",
                    @"OpenCvSharp.Extensions\bin\Release\netcoreapp2.1\OpenCvSharp.Extensions.dll",
                    @"OpenCvSharp.Extensions\bin\Release\netcoreapp2.1\OpenCvSharp.Extensions.pdb",
                }
            },{
                "netcoreapp3.1", new[]
                {
                    // netstandard2.1
                    @"OpenCvSharp\bin\Release\netstandard2.1\OpenCvSharp.dll",
                    @"OpenCvSharp\bin\Release\netstandard2.1\OpenCvSharp.dll.config",
                    @"OpenCvSharp\bin\Release\netstandard2.1\OpenCvSharp.pdb",
                    @"OpenCvSharp.Blob\bin\Release\netstandard2.1\OpenCvSharp.Blob.dll",
                    @"OpenCvSharp.Blob\bin\Release\netstandard2.1\OpenCvSharp.Blob.pdb",
                    @"OpenCvSharp.Extensions\bin\Release\netstandard2.1\OpenCvSharp.Extensions.dll",
                    @"OpenCvSharp.Extensions\bin\Release\netstandard2.1\OpenCvSharp.Extensions.pdb",
                    // netcoreapp3.1
                    @"OpenCvSharp.WpfExtensions\bin\Release\net48\OpenCvSharp.WpfExtensions.dll",
                    @"OpenCvSharp.WpfExtensions\bin\Release\net48\OpenCvSharp.WpfExtensions.pdb",
                }
            }
        };

        private const string DebuggerVisualizerPath = @"OpenCvSharp.DebuggerVisualizers\bin\Release\OpenCvSharp.DebuggerVisualizers.dll";

        private static readonly string[] xmlFiles = {
            @"OpenCvSharp\bin\{0}\net461\OpenCvSharp.xml",
            @"OpenCvSharp.Blob\bin\{0}\net461\OpenCvSharp.Blob.xml",
            @"OpenCvSharp.Extensions\bin\{0}\net461\OpenCvSharp.Extensions.xml",
            @"OpenCvSharp.WpfExtensions\OpenCvSharp.WpfExtensions.xml",
        };

        private static readonly Dictionary<string, string[]> platforms = new Dictionary<string, string[]>
        {
            ["win"] = new[] {"x86", "x64"},
            ["uwp"] = new[] {"x86", "x64", "ARM"},
        };

        private static readonly string[] languages = {
            "Release",
            "Release-JP"
        };

        private static readonly HashSet<string> ignoredExt = new[]{
            ".bak",
            ".user",
            ".suo",
            ".git",
            ".gitignore",
        }.ToHashSet();
        private static readonly HashSet<string> ignoredDir = new[]{
            ".svn",
            ".git",
            "bin",
            "obj",
            ".vs",
            "packages",
        }.ToHashSet();

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
            // C:\****\opencvsharp\src\OpenCvSharp.ReleaseMaker\bin\Release
            var binDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            var solutionDir = binDir.Parent?.Parent?.Parent?.Parent;

            textBox_Src.Text = solutionDir?.FullName ?? "";
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
            MessageBox.Show(@"Packages successfully created.");

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
            var dirSrc = Path.Combine(dir, "src");

            using (var zf = new ZipFile())
            {
                // net40, netcoreapp2.0といったplatformごとにDLLを選択
                foreach (var framework in dllFiles)
                {
                    var frameworkName = framework.Key;
                    foreach (var dllFileName in framework.Value)
                    {
                        var dllPath = Path.Combine(dirSrc, dllFileName);
                        var e = zf.AddFile(dllPath);
                        e.FileName = Path.Combine("ManagedLib", frameworkName, Path.GetFileName(dllPath));
                    }
                }

                // XMLドキュメントコメントを選択
                foreach (var lang in languages)
                {
                    foreach (var f in xmlFiles)
                    {
                        string xml = Path.Combine(dirSrc, string.Format(f, lang));
                        if (!File.Exists(xml))
                            continue;
                        var e = zf.AddFile(xml);
                        var lg = lang.Contains("JP") ? "Japanese" : "English";
                        e.FileName = Path.Combine("XmlDoc-" + lg, Path.GetFileName(xml));
                    }
                }

                // OpenCvSharpExtern.dllを、Windows用とUWP用それぞれで、x86/x64それぞれを入れる
                foreach (var p in platforms)
                {
                    foreach (var pf in p.Value)
                    {
                        var externDir = Path.Combine(dirSrc, "Release");
                        if (p.Key == "uwp")
                            externDir = Path.Combine(externDir, "uwpOpenCvSharpExtern");
                        var pfExtern = (pf == "x86") ? "Win32" : "x64";
                        externDir = Path.Combine(externDir, pfExtern);

                        foreach (var ext in new[] {"dll", "pdb"})
                        {
                            var e = zf.AddFile(Path.Combine(externDir, $"OpenCvSharpExtern.{ext}"));

                            var dstDirectory = Path.Combine("NativeLib", p.Key, pf);
                            e.FileName = Path.Combine(dstDirectory, $"OpenCvSharpExtern.{ext}");
                        }
                    }
                }

                // Debugger Visualizerを選択
                {
                    var dllFileName = Path.Combine(dirSrc, DebuggerVisualizerPath);
                    var zipFileName = Path.Combine(
                        "DebuggerVisualizers", Path.GetFileName(DebuggerVisualizerPath));
                    var e = zf.AddFile(dllFileName);
                    e.FileName = zipFileName;
                }

                // テキストを選択
                {
                    var e1 = zf.AddFile(Path.Combine(dir, "LICENSE"));
                    e1.FileName = Path.GetFileName("LICENSE");
                    var e2 = zf.AddFile(Path.Combine(dir, "README.md"));
                    e2.FileName = Path.GetFileName("README.md");
                }

                // 使い方
                {
                    var text = @"
USAGE:
1. Add a reference to OpenCvSharp.dll to your project.
2. Place OpenCvSharpExtern.dll in the same location as the executable file (exe).
".TrimStart();
                    zf.AddEntry("usage.txt", text);
                }

                var dst = Path.Combine(dirDst, GetBinaryDstDirName(opencvVersion)) + ".zip";
                zf.Save(dst);
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

        private string GetBinaryDstDirName(string version)
        {
            string date = DateTime.Now.ToString("yyyyMMdd");
            return $"OpenCvSharp-{version}-{date}";
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
                destDirName += Path.DirectorySeparatorChar;
            }

            // コピー元のディレクトリにあるファイルをコピー
            var files = Directory.EnumerateFiles(sourceDirName)
                    .Where(f => !ignoredExt.Contains(Path.GetExtension(f)?.ToLower()))
                    .Where(f => Path.GetFileName(f) != "OpenCvSharp.DebuggerVisualizers.dll");
            foreach (var file in files)
            {
                File.Copy(file, destDirName + Path.GetFileName(file), true);
            }

            // コピー元のディレクトリにあるディレクトリについて、再帰的に呼び出す
            var dirs = Directory.EnumerateDirectories(sourceDirName)
                .Where(d => !ignoredDir.Contains(Path.GetFileName(d)));
            foreach (var dir in dirs)
            {
                CopyDirectory(dir, destDirName + Path.GetFileName(dir));
            }
        }
    }
}
