﻿using Moq;
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
		private Mock<IVideoRepository> _repository;
		private VideoService _videoService;

		[SetUp]
		public void SetUp()
		{
			_fileReader = new Mock<IFileReader>();
			_repository = new Mock<IVideoRepository>();
			_videoService = new VideoService(_fileReader.Object, _repository.Object);
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
        
		[Test]
		public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
		{
			_repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

			var result = _videoService.GetUnprocessedVideosAsCsv();

			Assert.That(result, Is.EqualTo(""));
		}

		[Test]
		public void GetUnprocessedVideosAsCsv_AFewUnprocessedVideos_ReturnStringWithIdOfUnprocessedVideos()
		{
			_repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>
			{
				new Video { Id = 1 },
				new Video { Id = 2 },
				new Video { Id = 3 }
			});

			var result = _videoService.GetUnprocessedVideosAsCsv();

			Assert.That(result, Is.EqualTo("1,2,3"));
		}

	}
}
