using FileSystemLibrary;
using FileSystemLibrary.Events;
using FileSystemLibrary.Extensions;
using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.IO.Abstractions;

namespace FileSystemVisitorTests
{
    [TestFixture]
    public class FileSystemVisitorTests
    {
        private IFileSystemVisitor fileSystemVisitor;

        [SetUp()]
        public void Init()
        {
            this.fileSystemVisitor = new FileSystemVisitor();
        }

        [Test]
        public void ThrowsArgumentNullException_IfPathIsNull()
        {
            string path = null;

            Assert.Throws<ArgumentNullException>(() => this.fileSystemVisitor.GetFileSystemInfo(path));
        }

        [Test]
        public void ThrowsArgumentException_IfPathIsEmpty()
        {
            string path = string.Empty;

            Assert.Throws<ArgumentException>(() => this.fileSystemVisitor.GetFileSystemInfo(path));
        }

        [Test]
        public void NotifyEventArgsConstructor_SetUpMessage()
        {
            NotifyEventArgs notifyEventArgs = new("New event");

            Assert.That(notifyEventArgs.Message == "New event");
        }

        [Test]
        public void NotifyEventArgsConstructor_SetUpEmptyMessage_IfNull()
        {
            NotifyEventArgs notifyEventArgs = new(null);

            Assert.That(notifyEventArgs.Message == string.Empty);
        }

        [Test]
        public void DirectoryExtensionThrowsArgumentNullException_IfDirectoryInfoIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => DirectoryExtension.GetDirectoryItem(null));
        }

        [Test]
        public void FileExtensionThrowsArgumentNullException_IfFileInfoIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => FileExtension.GetFileItem(null));
        }
    }
}
