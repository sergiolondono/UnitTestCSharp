﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Fundamentals.Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Fundamentals.Math();
        }

        [Test]
        [Ignore("Because I need ignore it temporary")]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            //Arrange
            //Act
            var result = _math.Add(1, 2);

            //Assert
            Assert.That(result, Is.EqualTo(3));
        }

		[Test]
		public void GetOddNumbers_LimitsGreaterThanZero_ReturnOddNumbersUpToLimit()
		{
			var result = _math.GetOddNumbers(5);

			// Assert.That(result, Is.Not.Empty);
			// Assert.That(result.Count(), Is.Equal(3));

			// Assert.That(result, Does.Contain(1));
			// Assert.That(result, Does.Contain(3));
			// Assert.That(result, Does.Contain(5));

			Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

			//Assert.That(result, Is.Ordered);
			//Assert.That(result, Is.Unique);
		}

		[Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            //Arrange
            //Act
            var result = _math.Max(a, b);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            //Arrange
            //Act
            var result = _math.Max(2, 1);

            //Assert
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            //Arrange
            //Act
            var result = _math.Max(1, 2);

            //Assert
            Assert.That(result, Is.EqualTo(2));
        }

		[Test]
		public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
		{
			//Arrange
			//Act
			var result = _math.Max(1, 1);

			//Assert
			Assert.That(result, Is.EqualTo(1));
		}

	}
}
