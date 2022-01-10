using FileSystemLibrary.Models;
using System;

namespace FileSystemLibrary.Filters
{
    /// <summary>
    /// File system items filter
    /// </summary>
    public class FileSystemItemFilter
    {
        private readonly Func<FileSystemItem, string, bool> filter;
        private readonly string filterParameter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemItemFilter"/> class.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="filterParameter">The parameter.</param>
        /// <exception cref="System.ArgumentNullException">parameter</exception>
        public FileSystemItemFilter(Filter filter, string filterParameter)
        {
            if (filterParameter is null)
            {
                throw new ArgumentNullException(nameof(filterParameter));
            }

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

            this.filterParameter = filterParameter;
        }

        /// <summary>
        /// Gets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public Func<FileSystemItem, string, bool> GetFilter => this.filter;

        /// <summary>
        /// Gets the filter parameter.
        /// </summary>
        /// <value>
        /// The filter parameter.
        /// </value>
        public string GetParameter => this.filterParameter;

        /// <summary>
        /// If the type is match
        /// </summary>
        public Func<FileSystemItem, string, bool> isTypeMatch = (FileSystemItem fileSystemItem, string type) => fileSystemItem.Type.ToString() == type;

        /// <summary>
        /// If contains string
        /// </summary>
        public Func<FileSystemItem, string, bool> isContainsString = (FileSystemItem fileSystemItem, string sequenceOfChars) => fileSystemItem.Name.Contains(sequenceOfChars);

        /// <summary>
        /// If modified after date
        /// </summary>
        public Func<FileSystemItem, string, bool> isModifiedAfter = (FileSystemItem fileSystemItem, string date) => fileSystemItem.DateModified > DateTime.Parse(date);

        /// <summary>
        /// If modified before date
        /// </summary>
        public Func<FileSystemItem, string, bool> isModifiedBefore = (FileSystemItem fileSystemItem, string date) => fileSystemItem.DateModified < DateTime.Parse(date);
    }
}
