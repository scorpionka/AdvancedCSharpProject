using System;

namespace FileSystemLibrary.Events
{
    /// <summary>
    /// Event "Notify" args
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class NotifyEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotifyEventArgs"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public NotifyEventArgs(string message)
        {
            if (!(message is null))
            {
                Message = message;
            }
            else
            {
                Message = string.Empty;
            }
        }
    }
}
