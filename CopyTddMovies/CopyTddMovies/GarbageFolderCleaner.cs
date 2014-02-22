using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CopyTddMovies
{
    class GarbageFolderCleaner
    {
        public string RootFolder { get; set; }

        internal void Clean()
        {
            if (!Directory.Exists(RootFolder)) return;

            int smallFolderSizeMagaByte = 100;
            CleanSmallSizeFolders(smallFolderSizeMagaByte);
        }

        private void CleanSmallSizeFolders(int smallFolderSizeMagaByte)
        {
            var subDirs = Directory.GetDirectories(RootFolder);

            foreach(var dir in subDirs)
            {
                long folderSize = GetFolderSize(dir);

                if(folderSize < smallFolderSizeMagaByte * 1024 * 1024)
                {
                    if (DoIt) Directory.Delete(dir, true);

                    Console.WriteLine("Deleted " + dir);
                }
            }
        }

        private long GetFolderSize(string dir)
        {
            var items = Directory.GetFiles(dir);

            long size = 0;

            foreach(var item in items)
            {
                var info = new FileInfo(item);

                size += info.Length;
            }

            return size;
        }

        public bool DoIt { get; set; }
    }
}
