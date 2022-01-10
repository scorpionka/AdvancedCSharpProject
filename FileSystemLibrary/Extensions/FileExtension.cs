using FileSystemLibrary.Models;
using System;
using System.IO;

namespace FileSystemLibrary.Extensions
{
    /// <summary>
    /// Mapping of item "File"
    /// </summary>
    public static class FileExtension
    {
        /// <summary>
        /// Gets the file item.
        /// </summary>
        /// <param name="fileInfo">The file information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">fileInfo</exception>
        public static FileSystemItem GetFileItem(FileInfo fileInfo)
        {
            if (!(fileInfo is null))
            {
                return new FileSystemItem()
                {
                    Name = fileInfo.Name,
                    Type = ItemType.File,
                    DateModified = fileInfo.LastWriteTime
                };
            }
            else
            {
                throw new ArgumentNullException(nameof(fileInfo));
            }
        }
    }
}
