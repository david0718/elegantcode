namespace UnityAutoMocker.Examples.ExampleSystemUnderTest
{
	public interface IServiceA { void RunA(); }

	public interface IServiceB { void RunB(); }

	public class TestComponent
	{
		public TestComponent(IServiceA serviceA, IServiceB serviceB)
		{
			ServiceA = serviceA;
			ServiceB = serviceB;
		}

		public IServiceA ServiceA { get; private set; }
		public IServiceB ServiceB { get; private set; }

		public void RunAll()
		{
			if (!HowDidItGo())
				return;
			ServiceA.RunA();
			ServiceB.RunB();
		}

		public virtual bool HowDidItGo()
		{
			// some really nasty untestable code
			return true;
		}
	}
}