using FileSystemLibrary.Extensions;
using FileSystemLibrary.Filters;
using FileSystemLibrary.Models;
using System.Collections.Generic;
using System.IO;

namespace FileSystemLibrary
{
    public class FileSystemVisitor : IFileSystemVisitor
    {
        private readonly FileSystemItemFilter fileSystemItemFilter;

        public FileSystemVisitor()
        {
        }

        public FileSystemVisitor(FileSystemItemFilter fileSystemItemFilter)
        {
            this.fileSystemItemFilter = fileSystemItemFilter;
        }

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
                if (this.fileSystemItemFilter is null)
                {
                    yield return fileSystemItem;
                }
                else if (this.fileSystemItemFilter.GetFilter(fileSystemItem, this.fileSystemItemFilter.GetParameter))
                {
                    yield return fileSystemItem;
                }
            }
        }
    }
}
