using FileSystemLibrary.Models;
using System;
using System.IO;

namespace FileSystemLibrary.Extensions
{
    /// <summary>
    /// Mapping of item "Directory"
    /// </summary>
    public static class DirectoryExtension
    {
        /// <summary>
        /// Gets the directory item.
        /// </summary>
        /// <param name="directoryInfo">The directory information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">directoryInfo</exception>
        public static FileSystemItem GetDirectoryItem(DirectoryInfo directoryInfo)
        {
            if (!(directoryInfo is null))
            {
                return new FileSystemItem()
                {
                    Name = directoryInfo.Name,
                    Type = ItemType.Directory,
                    DateModified = directoryInfo.LastWriteTime
                };
            }
            else
            {
                throw new ArgumentNullException(nameof(directoryInfo));
            }
        }
    }
}
