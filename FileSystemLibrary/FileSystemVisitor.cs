using FileSystemLibrary.Extensions;
using FileSystemLibrary.Models;
using System.Collections.Generic;
using System.IO;

namespace FileSystemLibrary
{
    public class FileSystemVisitor : IFileSystemVisitor
    {
        public IEnumerable<FileSystemItem> GetFileSystemItems(string path)
        {
            var directory = new DirectoryInfo(path);
            List<FileSystemItem> fileSystemItems = new();

            if (directory.Exists)
            {
                DirectoryInfo[] dirs = directory.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    fileSystemItems.Add(DirectoryExtension.GetDirectoryItem(dir));
                }

                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    fileSystemItems.Add(FileExtension.GetFileItem(file));
                }
            }

            foreach (FileSystemItem fileSystemItem in fileSystemItems)
            {
                yield return fileSystemItem;
            }
        }
    }
}
