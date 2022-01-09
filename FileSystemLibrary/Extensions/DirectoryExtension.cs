using FileSystemLibrary.Models;
using System.IO;
using static FileSystemLibrary.Models.FileSystemItemType;

namespace FileSystemLibrary.Extensions
{
    public static class DirectoryExtension
    {
        public static FileSystemItem GetDirectoryItem(DirectoryInfo directoryInfo)
        {
            return new FileSystemItem()
            {
                Name = directoryInfo.Name,
                Type = ItemType.Directory,
                DateModified = directoryInfo.LastWriteTime
            };
        }
    }
}
