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
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            // Arrange
            var service = new VideoService(new FakeFileReader());
            // service.FileReader = new FakeFileReader();

            // Act
            // var result = service.ReadVideoTitle(new FakeFileReader());
            var result = service.ReadVideoTitle();

            // Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
        
    }
}
