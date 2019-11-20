using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    // [TestClass]
    [TestFixture] // NUnit.Framework
    public class ReservationTests
    {
        // [TestMethod]
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnTrue()
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            //Assert
            // Assert.IsTrue(result);
            Assert.That(result, Is.True);
            // Assert.That(result == true);
        }

        // [TestMethod]
        [Test]
        public void CanBeCancelledBy_SameUserCancelling_ReturnTrue()
        {
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            var result = reservation.CanBeCancelledBy(user);

            // Assert.IsTrue(result);
            Assert.That(result, Is.True);
            // Assert.That(result == true);
        }

        // [TestMethod]
        [Test]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnFalse()
        {
            //Arrange
            var reservation = new Reservation { MadeBy = new User()};

            //Act
            var result = reservation.CanBeCancelledBy(new User());

            //Assert
            // Assert.IsFalse(result);
            Assert.That(result, Is.False);
            // Assert.That(result == true);
        }
    }
}
