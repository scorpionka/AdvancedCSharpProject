using FileSystemLibrary.Models;
using System;
using static FileSystemLibrary.Filters.FilterType;

namespace FileSystemLibrary.Filters
{
    public class FileSystemItemFilter
    {
        private readonly Func<FileSystemItem, string, bool> filter;
        private readonly string parameter;

        public FileSystemItemFilter(Filter filter, string parameter)
        {
            switch (filter)
            {
                case Filter.Type:
                    this.filter = isTypeMatch;
                    break;
                case Filter.ContainsString:
                    this.filter = isContainsString;
                    break;
                case Filter.ModifiedAfter:
                    this.filter = isModifiedAfter;
                    break;
                case Filter.ModifiedBefore:
                    this.filter = isModifiedBefore;
                    break;
            }

            this.parameter = parameter;
        }

        public Func<FileSystemItem, string, bool> GetFilter => this.filter;
        public string GetParameter => this.parameter;

        public Func<FileSystemItem, string, bool> isTypeMatch = (FileSystemItem fileSystemItem, string type) => fileSystemItem.Type.ToString() == type;
        public Func<FileSystemItem, string, bool> isContainsString = (FileSystemItem fileSystemItem, string sequenceOfChars) => fileSystemItem.Name.Contains(sequenceOfChars);
        public Func<FileSystemItem, string, bool> isModifiedAfter = (FileSystemItem fileSystemItem, string date) => fileSystemItem.DateModified > DateTime.Parse(date);
        public Func<FileSystemItem, string, bool> isModifiedBefore = (FileSystemItem fileSystemItem, string date) => fileSystemItem.DateModified < DateTime.Parse(date);
    }
}
