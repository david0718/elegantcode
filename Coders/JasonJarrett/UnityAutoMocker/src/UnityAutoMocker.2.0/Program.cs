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
				UnityAutoMockContainerFixture.RunAllTests(Console.WriteLine);
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			Console.ReadLine();
		}
	}
}