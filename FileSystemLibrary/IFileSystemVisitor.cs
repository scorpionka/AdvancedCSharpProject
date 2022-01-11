using FileSystemLibrary.Models;
using System.Collections.Generic;

namespace FileSystemLibrary
{
    /// <summary>
    /// Interface for file system visitor behavior
    /// </summary>
    public interface IFileSystemVisitor
    {
        /// <summary>
        /// Gets the file system items.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        IEnumerable<FileSystemItem> GetFileSystemInfo(string path);
    }
}
