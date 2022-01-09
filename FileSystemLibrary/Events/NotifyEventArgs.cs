using System;

namespace FileSystemLibrary.Events
{
    public class NotifyEventArgs : EventArgs
    {
        public string Message { get; set; }

        public NotifyEventArgs(string message)
        {
            Message = message;
        }
    }
}
