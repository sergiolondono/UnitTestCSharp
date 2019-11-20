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
	public class HtmlFormatterTests
	{
		[Test]
		public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
		{
			var formatter = new HtmlFormatter();

			var result = formatter.FormatAsBold("abc");

			// Specific
			Assert.That(result, Is.EqualTo("<strong>abc</strong>"));

			// More general

		}	
	}
}
