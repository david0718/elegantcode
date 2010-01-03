using Moq.AutoMocking;
using NUnit.Framework;

namespace UnityAutoMocker.Examples
{
	public class FixtureBase
	{
		private readonly UnityAutoMockContainer _autoMockContainer = new UnityAutoMockContainer();

		protected UnityAutoMockContainer AutoMockContainer
		{
			get { return _autoMockContainer; }
		}

		[TestFixtureSetUp]
		public void SetupContext_ALL()
		{
			Before_all_tests();
			Because();
		}

		[TestFixtureTearDown]
		public void TearDownContext_ALL()
		{
			After_all_tests();
		}

		protected virtual void Before_all_tests()
		{
		}

		protected virtual void Because()
		{
		}

		protected virtual void After_all_tests()
		{
		}
	}
}
