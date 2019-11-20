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
	public class FizzBuzzTests
	{
		[Test]
		public void GetOutput_InputIsDivisibleBy3And5_ReturnFizzBuzz()
		{
			var result = FizzBuzz.GetOutput(15);
			Assert.That(result, Is.EqualTo("FizzBuzz"));
		}

		[Test]
		public void GetOutput_InputIsDivisibleBy3Only_ReturnFizz()
		{
			var result = FizzBuzz.GetOutput(9);
			Assert.That(result, Is.EqualTo("Fizz"));
		}

		[Test]
		public void GetOutput_InputIsDivisibleBy5Only_ReturnBuzz()
		{
			var result = FizzBuzz.GetOutput(10);
			Assert.That(result, Is.EqualTo("Buzz"));
		}

		[Test]
		public void GetOutput_InputIsNotDivisibleBy3Or5_ReturnTheSameNumber()
		{
			var result = FizzBuzz.GetOutput(13);
			Assert.That(result, Is.EqualTo("13"));
		}
	}
}
