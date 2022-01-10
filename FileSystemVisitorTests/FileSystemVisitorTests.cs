using FileSystemLibrary;
using FileSystemLibrary.Models;
using Moq;
using NUnit.Framework;
using System;
using System.IO.Abstractions;

namespace FileSystemVisitorTests
{
    [TestFixture]
    public class FileSystemVisitorTests
    {
        private IFileSystemVisitor fileSystemVisitor;
        private Mock<IDirectoryInfo> mockDirectoryInfo;
        private Mock<FileSystemItem> mockFileSystemItem;

        [SetUp()]
        public void Init()
        {
            this.fileSystemVisitor = new FileSystemVisitor();
            this.mockDirectoryInfo = new Mock<IDirectoryInfo>();
            this.mockFileSystemItem = new Mock<FileSystemItem>();
        }

        [Test]
        public void ThrowsArgumentNullExceptionIfPathIsNull()
        {
            string path = null;

            Assert.Throws<ArgumentNullException>(() => this.fileSystemVisitor.GetFileSystemInfo(path));
        }

        [Test]
        public void ThrowsArgumentExceptionIfPathIsEmpty()
        {
            string path = string.Empty;

            Assert.Throws<ArgumentException>(() => this.fileSystemVisitor.GetFileSystemInfo(path));
        }
    }
}
