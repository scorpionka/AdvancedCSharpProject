using FileSystemLibrary;
using FileSystemLibrary.Models;
using System;

namespace FileSystemConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemVisitor fileSystemVisitor = new();
            string path = "C:\\";

            foreach (FileSystemItem fileSystemItem in fileSystemVisitor.GetFileSystemItems(path))
            {
                Console.WriteLine(string.Format("{0} {1} {2}", fileSystemItem.Name, fileSystemItem.Type, fileSystemItem.DateModified));
            }
        }
    }
}
