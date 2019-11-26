using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
	[TestFixture]
	public class OrderServiceTests
	{
		[Test]
		public void Placeorder_WhenCalled_StoreTheOrder()
		{
			// Arrange
			var storage = new Mock<IStorage>();
			var service = new OrderService(storage.Object);

			//Act
			var order = new Order();
			var result = service.PlaceOrder(order);

			// Assert
			// Assert.That(result, Is.EqualTo(0));
			storage.Verify(s => s.Store(order));
		}
	}
}
