using FileSystemLibrary.Models;
using System.IO;
using static FileSystemLibrary.Models.FileSystemItemType;

namespace FileSystemLibrary.Extensions
{
    public static class FileExtension
    {
        public static FileSystemItem GetFileItem(FileInfo fileInfo)
        {
            return new FileSystemItem()
            {
                Name = fileInfo.Name,
                Type = ItemType.File,
                DateModified = fileInfo.LastWriteTime
            };
        }
    }
}
