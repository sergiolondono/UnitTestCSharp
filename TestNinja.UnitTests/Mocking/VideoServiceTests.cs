using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
		private Mock<IFileReader> _fileReader;
		private VideoService _videoService;

		[SetUp]
		public void SetUp()
		{
			_fileReader = new Mock<IFileReader>();
			_videoService = new VideoService(_fileReader.Object);
		}

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
			// Use Mocks only for external dependencies
			_fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
   
            // service.FileReader = new FakeFileReader();

            // Act
            // var result = service.ReadVideoTitle(new FakeFileReader());
            var result = _videoService.ReadVideoTitle();

            // Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
        
    }
}
