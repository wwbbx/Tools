using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExtractZips
{
    class ZipContent
    {
        private string tempDir;

        public ZipContent(string tempDir)
        {
            this.tempDir = tempDir;
        }

        public string TargetDir { get; set; }

        internal void Copy()
        {
            // copy everything from extracted dir to target dir.
            CopyFiles(tempDir, TargetDir);
            CopyFolders(tempDir, TargetDir);
        }

        private void CopyFolders(string tempDir, string TargetDir)
        {
            var folders = Directory.GetDirectories(tempDir, TargetDir);

            foreach(var dir in folders)
            {
                var targetSubDir = Path.Combine(TargetDir, Path.GetFileName(dir));

                if (!Directory.Exists(targetSubDir)) Directory.CreateDirectory(targetSubDir);

                CopyFiles(dir, targetSubDir);

                CopyFolders(dir, targetSubDir);
            }
        }

        private void CopyFiles(string tempDir, string TargetDir)
        {
            var items = Directory.GetFiles(tempDir, "*", SearchOption.TopDirectoryOnly);

            foreach(var item in items)
            {
                var targetFile = Path.Combine(TargetDir, Path.GetFileName(item));

                File.Copy(item, targetFile, true);
            }
        }
    }
}
