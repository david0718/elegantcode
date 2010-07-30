using System;
using System.Diagnostics;

namespace DynamicMethodInvocationSpike
{
	class Program
	{
		static void Main()
		{
			DirectCall();
			MethodInvoke();
			CreateDelegate();
			Expression();
			ExpressionV2();
			ExpressionV3();
			CreateDelegateIncludingCreation();
			ExpressionIncludingCreation();
			ExpressionV2IncludingCreation();
			ExpressionV3IncludingCreation();

			Console.ReadKey();
		}
		
		private static void DirectCall()
		{
			var subject = new Subject();
			subject.DoSomething("Arg1", 45.0);
		
			Int64 totalMilliseconds = 0;

			for(var j = 0; j < 5; j++)
			{
				var stopwatch = new Stopwatch();
				stopwatch.Start();
				
				for(var i = 0; i < 1000000; i++)
				{
					subject.DoSomething("Arg1", 45.0);
				}
				
				stopwatch.Stop();
				totalMilliseconds += stopwatch.ElapsedMilliseconds;

				stopwatch.Reset();
			}

			Console.WriteLine("Direct call -> Average: {0} ms", totalMilliseconds / 5);
		}
		
		private static void MethodInvoke()
		{
			var subject = new Subject();
			var methodInfo = subject.GetType().GetMethod("DoSomething");
			methodInfo.Invoke(subject, new Object[] { "Arg1", 45.0 });

			Int64 totalMilliseconds = 0;

			for(var j = 0;j < 5;j++)
			{
				var stopwatch = new Stopwatch();
				stopwatch.Start();

				for(var i = 0;i < 1000000;i++)
				{
					methodInfo.Invoke(subject, new Object[] {"Arg1", 45.0});
				}

				stopwatch.Stop();
				totalMilliseconds += stopwatch.ElapsedMilliseconds;

				stopwatch.Reset();
			}

			Console.WriteLine("Method.Invoke -> Average: {0} ms", totalMilliseconds / 5);	
		}
		
		private static void CreateDelegate()
		{
			var subject = new Subject();
			var methodInfo = subject.GetType().GetMethod("DoSomething");
			
			var function = (Func<String, Double, Int32>)Delegate.CreateDelegate(typeof(Func<String, Double, Int32>), subject, methodInfo);
			function("Arg1", 45.0);

			Int64 totalMilliseconds = 0;

			for(var j = 0;j < 5;j++)
			{
				var stopwatch = new Stopwatch();
				stopwatch.Start();

				for(var i = 0;i < 1000000;i++)
				{
					function("Arg1", 45.0);
				}

				stopwatch.Stop();
				totalMilliseconds += stopwatch.ElapsedMilliseconds;

				stopwatch.Reset();
			}

			Console.WriteLine("CreateDelegate -> Average: {0} ms", totalMilliseconds / 5);	
		}
		
		private static void Expression()
		{
			var subject = new Subject();
			var methodInfo = subject.GetType().GetMethod("DoSomething");
			
			var function = methodInfo.CreateDelegate<Func<String, Double, Int32>>(subject);
			function("Arg1", 45.0);

			Int64 totalMilliseconds = 0;

			for(var j = 0;j < 5;j++)
			{
				var stopwatch = new Stopwatch();
				stopwatch.Start();

				for(var i = 0;i < 1000000;i++)
				{
					function("Arg1", 45.0);
				}

				stopwatch.Stop();
				totalMilliseconds += stopwatch.ElapsedMilliseconds;

				stopwatch.Reset();
			}

			Console.WriteLine("Expression -> Average: {0} ms", totalMilliseconds / 5);		
		}

		private static void ExpressionV2()
		{
			var subject = new Subject();
			var methodInfo = subject.GetType().GetMethod("DoSomething");

			var function = methodInfo.CreateDelegateV2();
			function(subject, new Object[] { "Arg1", 45.0 });

			Int64 totalMilliseconds = 0;

			for(var j = 0;j < 5;j++)
			{
				var stopwatch = new Stopwatch();
				stopwatch.Start();

				for(var i = 0;i < 1000000;i++)
				{
					function(subject, new Object[] { "Arg1", 45.0 });
				}

				stopwatch.Stop();
				totalMilliseconds += stopwatch.ElapsedMilliseconds;

				stopwatch.Reset();
			}

			Console.WriteLine("Expression V2 -> Average: {0} ms", totalMilliseconds / 5);
		}
		
		private static void ExpressionV3()
		{
			var subject = new Subject();
			var methodInfo = subject.GetType().GetMethod("DoSomething");

			var function = methodInfo.CreateFunction<String, Double, Int32>(subject);
			function("Arg1", 45.0);

			Int64 totalMilliseconds = 0;

			for(var j = 0;j < 5;j++)
			{
				var stopwatch = new Stopwatch();
				stopwatch.Start();

				for(var i = 0;i < 1000000;i++)
				{
					function("Arg1", 45.0);
				}

				stopwatch.Stop();
				totalMilliseconds += stopwatch.ElapsedMilliseconds;

				stopwatch.Reset();
			}

			Console.WriteLine("Expression V3 -> Average: {0} ms", totalMilliseconds / 5);
		}

		private static void CreateDelegateIncludingCreation()
		{
			var subject = new Subject();
			var methodInfo = subject.GetType().GetMethod("DoSomething");

			var function = (Func<String, Double, Int32>)Delegate.CreateDelegate(typeof(Func<String, Double, Int32>), subject, methodInfo);
			function("Arg1", 45.0);

			Int64 totalMilliseconds = 0;

			for(var j = 0;j < 5;j++)
			{
				var stopwatch = new Stopwatch();
				stopwatch.Start();

				for(var i = 0;i < 1000000;i++)
				{
					function = (Func<String, Double, Int32>)Delegate.CreateDelegate(typeof(Func<String, Double, Int32>), subject, methodInfo);
					function("Arg1", 45.0);
				}

				stopwatch.Stop();
				totalMilliseconds += stopwatch.ElapsedMilliseconds;

				stopwatch.Reset();
			}

			Console.WriteLine("CreateDelegate (incl. creation) -> Average: {0} ms", totalMilliseconds / 5);
		}

		private static void ExpressionIncludingCreation()
		{
			var subject = new Subject();
			var methodInfo = subject.GetType().GetMethod("DoSomething");

			var function = methodInfo.CreateDelegate<Func<String, Double, Int32>>(subject);
			function("Arg1", 45.0);

			Int64 totalMilliseconds = 0;

			for(var j = 0;j < 5;j++)
			{
				var stopwatch = new Stopwatch();
				stopwatch.Start();

				for(var i = 0;i < 1000000;i++)
				{
					function = methodInfo.CreateDelegate<Func<String, Double, Int32>>(subject);
					function("Arg1", 45.0);
				}

				stopwatch.Stop();
				totalMilliseconds += stopwatch.ElapsedMilliseconds;

				stopwatch.Reset();
			}

			Console.WriteLine("Expression (incl. creation) -> Average: {0} ms", totalMilliseconds / 5);
		}

		private static void ExpressionV2IncludingCreation()
		{
			var subject = new Subject();
			var methodInfo = subject.GetType().GetMethod("DoSomething");

			var function = methodInfo.CreateDelegateV2();
			function(subject, new Object[] { "Arg1", 45.0 });

			Int64 totalMilliseconds = 0;

			for(var j = 0;j < 5;j++)
			{
				var stopwatch = new Stopwatch();
				stopwatch.Start();

				for(var i = 0;i < 1000000;i++)
				{
					function = methodInfo.CreateDelegateV2();
					function(subject, new Object[] { "Arg1", 45.0 });
				}

				stopwatch.Stop();
				totalMilliseconds += stopwatch.ElapsedMilliseconds;

				stopwatch.Reset();
			}

			Console.WriteLine("Expression V2 (incl. creation) -> Average: {0} ms", totalMilliseconds / 5);
		}
		
		private static void ExpressionV3IncludingCreation()
		{
			var subject = new Subject();
			var methodInfo = subject.GetType().GetMethod("DoSomething");

			var function = methodInfo.CreateFunction<String, Double, Int32>(subject);
			function("Arg1", 45.0);

			Int64 totalMilliseconds = 0;

			for(var j = 0;j < 5;j++)
			{
				var stopwatch = new Stopwatch();
				stopwatch.Start();

				for(var i = 0;i < 1000000;i++)
				{
					function = methodInfo.CreateFunction<String, Double, Int32>(subject);
					function("Arg1", 45.0);
				}

				stopwatch.Stop();
				totalMilliseconds += stopwatch.ElapsedMilliseconds;

				stopwatch.Reset();
			}

			Console.WriteLine("Expression V3 (incl. creation) -> Average: {0} ms", totalMilliseconds / 5);
		}
	}
	
	public class Subject
	{
		private Int32 _count;
	
		public Int32 DoSomething(String arg1, Double Arg2)
		{
			_count += 1;
			return _count;
		}
	}
}
