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
	public class DemeritPointsCalculatorTests
	{
		private DemeritPointsCalculator _demeritPoint;

		[SetUp]
		public void setUp()
		{
			_demeritPoint = new DemeritPointsCalculator();
		}

		[Test]
		public void CalculateDemeritPoints_SpeedIsNegative_ThrowArgumentOutRangeException()
		{
			var calculator = new DemeritPointsCalculator();
			Assert.That(() => calculator.CalculateDemeritPoints(-1), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		public void CalculateDemeritPoints_SpeedIsOver300_ReturnArgumentOutRangeException()
		{
			var calculator = new DemeritPointsCalculator();

			Assert.That(() => calculator.CalculateDemeritPoints(301), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(64, 0)]
		[TestCase(65, 0)]
		[TestCase(66, 0)]
		[TestCase(70, 1)]
		[TestCase(75, 2)]
		public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expectedResult)
		{
			var result = _demeritPoint.CalculateDemeritPoints(speed);

			Assert.That(result, Is.EqualTo(expectedResult));
		}

		[Test]
		[TestCase(80)]
		public void CalculateDemeritPoints_SpeedAllowed_ReturnThree(int speed)
		{
			var result = _demeritPoint.CalculateDemeritPoints(speed);

			Assert.That(result, Is.EqualTo(3));
		}

	}
}
