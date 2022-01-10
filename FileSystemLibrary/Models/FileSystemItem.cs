using System;

namespace FileSystemLibrary.Models
{
    /// <summary>
    /// File system item model
    /// </summary>
    public class FileSystemItem
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public DateTime DateModified { get; set; }
    }
}
