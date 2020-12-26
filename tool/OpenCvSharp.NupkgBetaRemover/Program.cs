using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OpenCvSharp.NupkgBetaRemover
{
    class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            var nupkgFiles = SelectNupkgFiles();
            if (nupkgFiles == null)
                return;

            foreach (var nupkgFile in nupkgFiles)
            {
                if (nupkgFile.Contains("ubuntu"))
                    continue;
                var fileNameMatch = Regex.Match(nupkgFile, @"OpenCvSharp4\..*(?<date>\d{8})(?<beta_version>-beta\d*)\.s?nupkg");
                if (!fileNameMatch.Success)
                    throw new Exception($"Unexpected .nupkg/.snupkg file name ({nupkgFile})");
                var dateString = fileNameMatch.Groups["date"].Value;
                var date = new DateTime(
                    year: int.Parse(dateString.Substring(0, 4)), 
                    month: int.Parse(dateString.Substring(4, 2)), 
                    day: int.Parse(dateString.Substring(6, 2)));

                using (var zipArchive = ZipFile.Open(nupkgFile, ZipArchiveMode.Update))
                {
                    var nuspecEntry = zipArchive.Entries.FirstOrDefault(e => e.FullName.EndsWith(".nuspec"));
                    if (nuspecEntry == null)
                        continue;

                    string nuspecContent;
                    using (var nuspecContentStream = nuspecEntry.Open())
                    using (var nuspecContentStreamReader = new StreamReader(nuspecContentStream, Encoding.UTF8))
                    {
                        nuspecContent = nuspecContentStreamReader.ReadToEnd();
                    }

                    if (nupkgFile.Contains("ubuntu"))
                    {
                        nuspecContent = Regex.Replace(nuspecContent, @"-\d+</version>", $".{date:yyyyMMdd}</version>");
                    }
                    else
                    {
                        nuspecContent = Regex.Replace(nuspecContent, @"-beta-?\d*</version>", "</version>");
                        nuspecContent = Regex.Replace(nuspecContent, @"(?<=<dependency.*version="")(?<version>\d{1,2}\.\d{1,2}\.\d{1,2}\.\d{8})(?<betaVersion>-beta-?\d+)", 
                            match => match.Groups["version"].Value);                        
                    }
                    nuspecContent += new string(' ', 1000);

                    using (var nuspecContentStream = nuspecEntry.Open())
                    using (var nuspecContentStreamWriter = new StreamWriter(nuspecContentStream, Encoding.UTF8))
                    {
                        nuspecContentStreamWriter.Write(nuspecContent);
                    }
                }

                var newFileName = Regex.Replace(nupkgFile, @"-beta-?\d*", "");
                File.Move(nupkgFile, newFileName);
            }
        }

        private static string[] SelectNupkgFiles()
        {
            using (var dialog = new OpenFileDialog {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "nupkg files(*.nupkg;*.snupkg)|*.nupkg;*.snupkg",
                Multiselect = true,
                RestoreDirectory = true,
                Title = "Select .nupkg files"
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return null;
                return dialog.FileNames;
            }
        }
    }
}
