using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace OpenCvSharp.ReleaseMaker
{
    public static class Packer
    {
        private static readonly IReadOnlyDictionary<string, string[]> dllFiles = new Dictionary<string, string[]>
        {
            ["net461"] = new[]
            {
                @"OpenCvSharp\bin\Release\net461\OpenCvSharp.dll",
                @"OpenCvSharp\bin\Release\net461\OpenCvSharp.dll.config",
                @"OpenCvSharp\bin\Release\net461\OpenCvSharp.pdb",
                @"OpenCvSharp.Extensions\bin\Release\net461\OpenCvSharp.Extensions.dll",
                @"OpenCvSharp.Extensions\bin\Release\net461\OpenCvSharp.Extensions.pdb",
                @"OpenCvSharp.WpfExtensions\bin\Release\net461\OpenCvSharp.WpfExtensions.dll",
                @"OpenCvSharp.WpfExtensions\bin\Release\net461\OpenCvSharp.WpfExtensions.pdb",
            },
            ["netstandard2.0"] = new[]
            {
                @"OpenCvSharp\bin\Release\netstandard2.0\OpenCvSharp.dll",
                @"OpenCvSharp\bin\Release\netstandard2.0\OpenCvSharp.dll.config",
                @"OpenCvSharp\bin\Release\netstandard2.0\OpenCvSharp.pdb",
                @"OpenCvSharp.Extensions\bin\Release\netstandard2.0\OpenCvSharp.Extensions.dll",
                @"OpenCvSharp.Extensions\bin\Release\netstandard2.0\OpenCvSharp.Extensions.pdb",
            },
            ["netstandard2.1"] = new[]
            {
                @"OpenCvSharp\bin\Release\netstandard2.1\OpenCvSharp.dll",
                @"OpenCvSharp\bin\Release\netstandard2.1\OpenCvSharp.dll.config",
                @"OpenCvSharp\bin\Release\netstandard2.1\OpenCvSharp.pdb",
                @"OpenCvSharp.Extensions\bin\Release\netstandard2.1\OpenCvSharp.Extensions.dll",
                @"OpenCvSharp.Extensions\bin\Release\netstandard2.1\OpenCvSharp.Extensions.pdb",
            },
            ["netcoreapp2.1"] = new[]
            {
                @"OpenCvSharp\bin\Release\netcoreapp2.1\OpenCvSharp.dll",
                @"OpenCvSharp\bin\Release\netcoreapp2.1\OpenCvSharp.dll.config",
                @"OpenCvSharp\bin\Release\netcoreapp2.1\OpenCvSharp.pdb",
                @"OpenCvSharp.Extensions\bin\Release\netcoreapp2.1\OpenCvSharp.Extensions.dll",
                @"OpenCvSharp.Extensions\bin\Release\netcoreapp2.1\OpenCvSharp.Extensions.pdb",
            },
            ["netcoreapp3.1"] = new[]                
            {
                // netstandard2.1
                @"OpenCvSharp\bin\Release\netstandard2.1\OpenCvSharp.dll",
                @"OpenCvSharp\bin\Release\netstandard2.1\OpenCvSharp.dll.config",
                @"OpenCvSharp\bin\Release\netstandard2.1\OpenCvSharp.pdb",
                @"OpenCvSharp.Extensions\bin\Release\netstandard2.1\OpenCvSharp.Extensions.dll",
                @"OpenCvSharp.Extensions\bin\Release\netstandard2.1\OpenCvSharp.Extensions.pdb",
                // netcoreapp3.1
                @"OpenCvSharp.WpfExtensions\bin\Release\netcoreapp3.1\OpenCvSharp.WpfExtensions.dll",
                @"OpenCvSharp.WpfExtensions\bin\Release\netcoreapp3.1\OpenCvSharp.WpfExtensions.pdb",
            }
        };

        private const string DebuggerVisualizerPath = @"OpenCvSharp.DebuggerVisualizers\bin\Release\OpenCvSharp.DebuggerVisualizers.dll";

        private static readonly string[] xmlFiles = {
            @"OpenCvSharp\bin\Release\net461\OpenCvSharp.xml",
            @"OpenCvSharp.Extensions\bin\Release\net461\OpenCvSharp.Extensions.xml",
            @"OpenCvSharp.WpfExtensions\OpenCvSharp.WpfExtensions.xml",
        };

        private static readonly IReadOnlyDictionary<string, string[]> architectures = new Dictionary<string, string[]>
        {
            ["win"] = new[] { "x86", "x64" },
            ["uwp"] = new[] { "x86", "x64", "ARM" },
        };

        private static readonly IReadOnlyDictionary<string, string> uwpNativeDllDirectories = new Dictionary<string, string>
        {
            ["x86"] = @"opencv_files\opencv451_uwp_x86\x86\vc16\bin",
            ["x64"] = @"opencv_files\opencv451_uwp_x64\x64\vc16\bin",
            ["ARM"] = @"opencv_files\opencv451_uwp_ARM\x86\vc16\bin",
        };
        private static readonly IReadOnlyList<string> uwpNativeDlls = new[]
        {
            "opencv_world451.dll",
            "opencv_img_hash451.dll"
        };

        private static readonly HashSet<string> ignoredExt = new[]{
            ".bak",
            ".user",
            ".suo",
            ".git",
            ".gitignore",
        }.ToHashSet();
        private static readonly HashSet<string> ignoredDir = new[]{
            ".git",
            "bin",
            "obj",
            ".vs",
            ".nuget",
            "packages",
        }.ToHashSet();

        /// <summary>
        /// Make
        /// </summary>
        /// <param name="srcDir"></param>
        /// <param name="dstDir"></param>
        /// <param name="version">e.g. 4.5.1</param>
        public static void Pack(string srcDir, string dstDir, string version)
        {
            MakeBinaryPackage(srcDir, dstDir, version);
            MakeSamplePackage(srcDir, dstDir, version);
        }

        /// <summary>
        /// Create a zip package that contains DLL files
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="dirDst"></param>
        /// <param name="opencvVersion"></param>
        private static void MakeBinaryPackage(string dir, string dirDst, string opencvVersion)
        {
            var dirSrc = Path.Combine(dir, "src");

            var dstFileName = Path.Combine(dirDst, GetBinaryDstDirName(opencvVersion)) + ".zip";
            using var zipStream = File.OpenWrite(dstFileName);
            using var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Create, false);

            // net40, netcoreapp2.0といったplatformごとにDLLを選択
            foreach (var (frameworkName, dllFileNames) in dllFiles)
            {
                foreach (var dllFileName in dllFileNames)
                {
                    var dllPath = Path.Combine(dirSrc, dllFileName);
                    zipArchive.CreateEntryFromFile(
                        dllPath,
                        Path.Combine("ManagedLib", frameworkName, Path.GetFileName(dllPath)),
                        CompressionLevel.Optimal);
                }
            }

            // XMLドキュメントコメントを選択
            foreach (var f in xmlFiles)
            {
                var xmlPath = Path.Combine(dirSrc, f);
                if (!File.Exists(xmlPath))
                    continue;
                zipArchive.CreateEntryFromFile(
                    xmlPath,
                    Path.Combine("XmlDoc", Path.GetFileName(xmlPath)),
                    CompressionLevel.Optimal);
            }


            // OpenCvSharpExtern.dllを、Windows用とUWP用それぞれで、x86/x64それぞれを入れる
            foreach (var p in architectures)
            {
                foreach (var arch in p.Value)
                {
                    var externDir = Path.Combine(dirSrc, "Release");
                    if (p.Key == "uwp")
                        externDir = Path.Combine(externDir, "uwpOpenCvSharpExtern");
                    var pfExtern = (arch == "x86") ? "Win32" : "x64";
                    externDir = Path.Combine(externDir, pfExtern);

                    foreach (var ext in new[] { "dll", "pdb" })
                    {
                        var dstDirectory = Path.Combine("NativeLib", p.Key, arch);

                        zipArchive.CreateEntryFromFile(
                            Path.Combine(externDir, $"OpenCvSharpExtern.{ext}"),
                            Path.Combine(dstDirectory, $"OpenCvSharpExtern.{ext}"));
                    }

                    // UWPはopencv_world.dll等も入れる
                    if (p.Key == "uwp")
                    {
                        var uwpNativeDllDir = uwpNativeDllDirectories[arch];
                        uwpNativeDllDir = Path.Combine(dir, uwpNativeDllDir);
                        foreach (var dllName in uwpNativeDlls)
                        {
                            var uwpNativeDll = Path.Combine(uwpNativeDllDir, dllName);
                            var dstDirectory = Path.Combine("NativeLib", "uwp", arch);
                            zipArchive.CreateEntryFromFile(
                                uwpNativeDll,
                                Path.Combine(dstDirectory, dllName));
                        }
                    }
                }
            }

            // Debugger Visualizerを選択
            {
                var dllFileName = Path.Combine(dirSrc, DebuggerVisualizerPath);
                var zipFileName = Path.Combine(
                    "DebuggerVisualizers", Path.GetFileName(DebuggerVisualizerPath));
                zipArchive.CreateEntryFromFile(
                    dllFileName,
                    zipFileName);
            }

            // テキストを選択
            {
                zipArchive.CreateEntryFromFile(
                    Path.Combine(dir, "LICENSE"),
                    Path.GetFileName("LICENSE"));
                zipArchive.CreateEntryFromFile(
                    Path.Combine(dir, "README.md"),
                    Path.GetFileName("README.md"));
            }
        }

        /// <summary>
        /// Create a zip package that contains code samples
        /// </summary>
        /// <param name="dirSrc"></param>
        /// <param name="dirDst"></param>
        /// <param name="version"></param>
        private static void MakeSamplePackage(string dirSrc, string dirDst, string version)
        {
            dirSrc = Path.Combine(dirSrc, "samples");
            dirDst = Path.Combine(dirDst, GetSampleDstDirName(version));

            CopyDirectory(dirSrc, dirDst);

            var dstFileName = dirDst + ".zip";
            File.Delete(dstFileName);

            ZipFile.CreateFromDirectory(
                dirDst,
                dstFileName,
                CompressionLevel.Optimal,
                false);

            Directory.Delete(dirDst, true);
        }

        private static string GetBinaryDstDirName(string version)
        {
            var date = DateTime.Now.ToString("yyyyMMdd");
            return $"OpenCvSharp-{version}-{date}";
        }

        private static string GetSampleDstDirName(string version)
        {
            var date = DateTime.Now.ToString("yyyyMMdd");
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
            if (destDirName[^1] != Path.DirectorySeparatorChar)
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