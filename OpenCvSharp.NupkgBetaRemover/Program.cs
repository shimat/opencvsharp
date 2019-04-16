using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCvSharp.NupkgBetaRemover
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var nupkgFiles = SelectNupkgFiles();
            if (nupkgFiles == null)
                return;

            //var date = DateTime.Now;
            var date = new DateTime(2019, 4, 16);

            foreach (var nupkgFile in nupkgFiles)
            {
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
                        nuspecContent = Regex.Replace(nuspecContent, @"-\d+</version>", $".{date:yyyyMMdd}</version>");
                    else
                        nuspecContent = Regex.Replace(nuspecContent, @"-beta-\d+</version>", "</version>");
                    nuspecContent += "               ";

                    using (var nuspecContentStream = nuspecEntry.Open())
                    using (var nuspecContentStreamWriter = new StreamWriter(nuspecContentStream, Encoding.UTF8))
                    {
                        nuspecContentStreamWriter.Write(nuspecContent);
                    }
                }

                string newFileName;
                if (nupkgFile.Contains("ubuntu"))
                    newFileName  = Regex.Replace(nupkgFile, @"-\d+.nupkg", $".{date:yyyyMMdd}.nupkg");
                else
                    newFileName  = Regex.Replace(nupkgFile, @"-beta-\d+", "");
                File.Move(nupkgFile, newFileName);
            }
        }

        static string[] SelectNupkgFiles()
        {
            using (var dialog = new OpenFileDialog {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "nupkg files(*.nupkg)|*.nupkg",
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
