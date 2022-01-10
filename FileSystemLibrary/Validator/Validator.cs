using System;

namespace FileSystemLibrary.Validator
{
    /// <summary>
    /// Validate parameters
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Validates the date.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static (bool, DateTime) ValidateDate(string dateTime)
        {
            return (DateTime.TryParse(dateTime, out DateTime correctDateTime), correctDateTime);
        }

        /// <summary>
        /// Validates the path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">path</exception>
        public static void ValidatePath(string path)
        {
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException(string.Empty, nameof(path));
            }
        }
    }
}
