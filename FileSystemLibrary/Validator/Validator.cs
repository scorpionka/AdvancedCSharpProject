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
    }
}
