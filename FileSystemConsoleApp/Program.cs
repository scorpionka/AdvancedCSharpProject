using FileSystemLibrary;
using FileSystemLibrary.Filters;
using FileSystemLibrary.Models;
using System;
using static FileSystemLibrary.Filters.FilterType;

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

            Console.WriteLine();

            FileSystemVisitor fileSystemVisitorWithFilter = new(new FileSystemItemFilter(Filter.ModifiedBefore, "1/1/2022"));

            foreach (FileSystemItem fileSystemItem in fileSystemVisitorWithFilter.GetFileSystemItems(path))
            {
                Console.WriteLine(string.Format("{0} {1} {2}", fileSystemItem.Name, fileSystemItem.Type, fileSystemItem.DateModified));
            }
        }
    }
}
