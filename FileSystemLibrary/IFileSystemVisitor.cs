using FileSystemLibrary.Models;
using System.Collections.Generic;

namespace FileSystemLibrary
{
    interface IFileSystemVisitor
    {
        IEnumerable<FileSystemItem> GetFileSystemItems(string path);
    }
}
