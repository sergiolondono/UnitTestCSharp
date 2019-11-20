using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class CustomerControllerTests
	{
		[Test]
		public void Getustomer_IdIsZero_ReturnNotFound()
		{
			var controller = new CustomerController();

			var result = controller.GetCustomer(0);

			// Not Found
			Assert.That(result, Is.TypeOf<NotFound>());

			// Not Found or one of its derivatives
			// Assert.That(result, Is.TypeOf<NotFound>());
		}

		[Test]
		public void Getustomer_IdIsNotZero_ReturnOk()
		{
			var controller = new CustomerController();

			var result = controller.GetCustomer(1);

			// Not Found
			 Assert.That(result, Is.TypeOf<Ok>());

			// Not Found or one of its derivatives
			// Assert.That(result, Is.TypeOf<Ok>());
		}

	}
}
