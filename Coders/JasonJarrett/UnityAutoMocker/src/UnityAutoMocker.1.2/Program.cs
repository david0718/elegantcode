using System;
using Moq.AutoMocking.Testing;

namespace UnityAutoMockerConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Starting Tests...");
				var fixture = new UnityAutoMockContainerFixture();
				AutoMockContainerFixture.RunAllTests(fixture, Console.WriteLine);
				Console.WriteLine("Test Complete Tests...");
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			Console.ReadLine();
		}
	}
}
