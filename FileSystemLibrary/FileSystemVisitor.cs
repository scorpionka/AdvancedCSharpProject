using FileSystemLibrary.Events;
using FileSystemLibrary.Extensions;
using FileSystemLibrary.Filters;
using FileSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemLibrary
{
    public class FileSystemVisitor : IFileSystemVisitor
    {
        private readonly FileSystemItemFilter fileSystemItemFilter;
        private readonly ActionType actionType;

        public FileSystemVisitor()
        {
            EnableEvents();
        }

        public FileSystemVisitor(Filter filter, string filterParameter, ActionType actionType)
        {
            this.fileSystemItemFilter = new FileSystemItemFilter(filter, filterParameter);
            this.actionType = actionType;
            EnableEvents();
        }

        public delegate void EventHandler(FileSystemVisitor sender, NotifyEventArgs e);
        public event EventHandler Notify;

        public IEnumerable<FileSystemItem> GetFileSystemItems(string path)
        {
            var directory = new DirectoryInfo(path);
            List<FileSystemItem> fileSystemItems = new();

            if (directory.Exists)
            {
                DirectoryInfo[] dirs = directory.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    fileSystemItems.Add(DirectoryExtension.GetDirectoryItem(dir));
                }

                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    fileSystemItems.Add(FileExtension.GetFileItem(file));
                }
            }

            Notify?.Invoke(this, new NotifyEventArgs("Search is started"));

            foreach (FileSystemItem fileSystemItem in fileSystemItems)
            {
                if (this.fileSystemItemFilter is null)
                {
                    Notify?.Invoke(this, new NotifyEventArgs("Item is found"));
                    yield return fileSystemItem;
                }
                else if (this.actionType is ActionType.ExcludeItems && !(this.fileSystemItemFilter.GetFilter(fileSystemItem, this.fileSystemItemFilter.GetParameter)))
                {
                    Notify?.Invoke(this, new NotifyEventArgs("Item is found"));
                    yield return fileSystemItem;
                }
                else if (this.fileSystemItemFilter.GetFilter(fileSystemItem, this.fileSystemItemFilter.GetParameter))
                {
                    switch (this.actionType)
                    {
                        case ActionType.Continue:
                            Notify?.Invoke(this, new NotifyEventArgs("Filtered item is found"));
                            yield return fileSystemItem;
                            break;
                        case ActionType.Abort:
                            Notify?.Invoke(this, new NotifyEventArgs("Search is aborted"));
                            yield break;
                    }
                }
            }

            Notify?.Invoke(this, new NotifyEventArgs("Search is finished"));
        }

        private void EnableEvents()
        {
            this.Notify += (s, e) => Console.WriteLine(e.Message);
        }
    }
}
