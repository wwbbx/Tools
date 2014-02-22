using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExtractZips
{
    class ExtractManager
    {
        public string SourceDir { get; set; }

        public string TargetDir { get; set; }

        internal void Extract()
        {
            // get all files with suffix 7z, rar, zip.
            var zipFiles = ListZipFiles(SourceDir);

            // extract them one by one.
            foreach (var zip in zipFiles)
            {
                ExtractSingleFile(zip);
            }
        }

        private void ExtractSingleFile(string zip)
        {
            // extract to temp directory
            var tempDir = GetTemporaryContainerDir();
            CleanTempDir(tempDir);

            // get target file's name based on extracted file.
            ExtractFile(zip, tempDir);

            var content = new ZipContent(tempDir);
            content.TargetDir = TargetDir;

            content.Copy();
        }

        private void CleanTempDir(string tempDir)
        {
            Directory.Delete(tempDir, true);

            Directory.CreateDirectory(tempDir);

        }

        private void ExtractFile(string zip, object tempDir)
        {
            // call 7z.exe command to extract zip file to tempDir folder.
            // C:\Program Files (x86)\7-Zip\7z.exe
            // this computer must install 7z.exe.
            // 7z x archive.zip -oc:\soft *.cpp -r
            //extracts all *.cpp files from the archive archive.zip to c:\soft folder.

            var zipExtractor = @"C:\Program Files (x86)\7-Zip\7z.exe";
            var parameters = string.Format(@"x {0} -o{1} -r", zip, tempDir);

            RunCommand.Execute(zipExtractor, parameters);
        }

        private string GetTemporaryContainerDir()
        {
            var currLocation = Environment.CurrentDirectory;

            var tempDir = Path.Combine(currLocation, "Temp");

            if(!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }

            return tempDir;
        }

        private List<string> ListZipFiles(string SourceDir)
        {
            string[] allFiles = Directory.GetFiles(SourceDir, "*", SearchOption.AllDirectories);

            List<string> zipFiles = new List<string>();

            foreach (var item in allFiles)
            {
                if(item.EndsWith("7z") || item.EndsWith("rar") || item.EndsWith("zip"))
                {
                    zipFiles.Add(item);
                }
            }

            return zipFiles;
        }
    }
}
