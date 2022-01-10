using FileSystemLibrary;
using FileSystemLibrary.Events;
using FileSystemLibrary.Filters;
using FileSystemLibrary.Models;
using System;

namespace FileSystemConsoleApp
{
    class Program
    {
        static void Main()
        {
            FileSystemVisitor fileSystemVisitor = new();

            string path = "C:\\";

            foreach (FileSystemItem fileSystemItem in fileSystemVisitor.GetFileSystemItems(path))
            {
                Console.WriteLine(string.Format("{0} {1} {2}", fileSystemItem.Name, fileSystemItem.Type, fileSystemItem.DateModified));
            }

            Console.WriteLine();

            FileSystemVisitor fileSystemVisitorWithFilter = new(Filter.Type, "Directory", ActionType.ExcludeItems);

            foreach (FileSystemItem fileSystemItem in fileSystemVisitorWithFilter.GetFileSystemItems(path))
            {
                Console.WriteLine(string.Format("{0} {1} {2}", fileSystemItem.Name, fileSystemItem.Type, fileSystemItem.DateModified));
            }

            Console.WriteLine();

            fileSystemVisitorWithFilter = new(Filter.ModifiedAfter, "1/1/2022", ActionType.Continue);

            foreach (FileSystemItem fileSystemItem in fileSystemVisitorWithFilter.GetFileSystemItems(path))
            {
                Console.WriteLine(string.Format("{0} {1} {2}", fileSystemItem.Name, fileSystemItem.Type, fileSystemItem.DateModified));
            }
        }
    }
}
