using FileSystemLibrary.Events;
using FileSystemLibrary.Extensions;
using FileSystemLibrary.Filters;
using FileSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemLibrary
{
    /// <summary>
    /// Provides file system visitor functionality
    /// </summary>
    /// <seealso cref="FileSystemLibrary.IFileSystemVisitor" />
    public class FileSystemVisitor : IFileSystemVisitor
    {
        private readonly FileSystemItemFilter fileSystemItemFilter;
        private readonly ActionType actionType;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemVisitor"/> class.
        /// </summary>
        public FileSystemVisitor()
        {
            EnableEvents();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemVisitor"/> class.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="filterParameter">The filter parameter.</param>
        /// <param name="actionType">Type of the action.</param>
        public FileSystemVisitor(Filter filter, string filterParameter, ActionType actionType)
        {
            EnableEvents();
            if ((filter == Filter.ModifiedAfter || filter == Filter.ModifiedBefore) && !Validator.Validator.ValidateDate(filterParameter).Item1)
            {
                Notify?.Invoke(this, new NotifyEventArgs("Date is incorrect"));
                Console.ReadKey();
                Environment.Exit(0);
            }

            this.fileSystemItemFilter = new FileSystemItemFilter(filter, filterParameter);
            this.actionType = actionType;
        }

        /// <summary>
        /// Delegate for event "Notify"
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NotifyEventArgs"/> instance containing the event data.</param>
        public delegate void EventHandler(FileSystemVisitor sender, NotifyEventArgs e);

        /// <summary>
        /// Occurs when some events
        /// </summary>
        public event EventHandler Notify;

        /// <summary>
        /// Gets the file system items.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">path</exception>
        public IEnumerable<FileSystemItem> GetFileSystemItems(string path)
        {
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            DirectoryInfo directory = new(path);
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
            this.Notify += (sender, eventArgs) => Console.WriteLine(eventArgs.Message);
        }
    }
}
