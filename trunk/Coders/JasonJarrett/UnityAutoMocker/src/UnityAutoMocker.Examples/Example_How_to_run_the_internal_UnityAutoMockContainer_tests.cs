using System;
using NUnit.Framework;

namespace UnityAutoMocker.Examples
{
	[TestFixture]
	public class Example_How_to_run_the_internal_UnityAutoMockContainer_tests
	{
		[Test]
		public void Should_run_all_UnityAutoMockContainer_internal_tests()
		{
			Moq.AutoMocking.SelfTesting.UnityAutoMockContainerFixture
				.RunAllTests(Console.WriteLine);
		}
	}
}