using System;
using static FileSystemLibrary.Models.FileSystemItemType;

namespace FileSystemLibrary.Models
{
    public class FileSystemItem
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public DateTime DateModified { get; set; }
    }
}
