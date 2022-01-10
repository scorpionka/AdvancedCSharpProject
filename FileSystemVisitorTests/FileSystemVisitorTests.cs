using FileSystemLibrary;
using FileSystemLibrary.Models;
using Moq;
using NUnit.Framework;
using System;

namespace FileSystemVisitorTests
{
    [TestFixture]
    public class FileSystemVisitorTests
    {
        private FileSystemVisitor fileSystemVisitor;
        private Mock<FileSystemItem> fileSystemItemMock;

        [SetUp()]
        public void ClassInit()
        {
            this.fileSystemVisitor = new FileSystemVisitor();
            this.fileSystemItemMock = new Mock<FileSystemItem>();
        }

        [Test]
        public void ThrowsArgumentNullExceptionIfPathIsNull()
        {
            string path = null;

            Assert.Throws<ArgumentNullException>(() => this.fileSystemVisitor.GetFileSystemItems(path));
        }
    }
}
