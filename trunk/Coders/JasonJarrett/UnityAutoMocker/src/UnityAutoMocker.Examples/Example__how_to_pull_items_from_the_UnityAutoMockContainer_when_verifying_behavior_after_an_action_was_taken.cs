using Moq;
using NUnit.Framework;
using UnityAutoMocker.Examples.ExampleSystemUnderTest;

namespace UnityAutoMocker.Examples
{
	[TestFixture]
	public class Example__how_to_pull_items_from_the_UnityAutoMockContainer_when_verifying_behavior_after_an_action_was_taken : FixtureBase
	{
		private TestComponent _testComponent;

		protected override void Before_all_tests()
		{
			base.Before_all_tests();
			_testComponent = AutoMockContainer.Resolve<TestComponent>();
		}

		protected override void Because()
		{
			_testComponent.RunAll();
		}

		[Test]
		public void Should_run_ServiceA_RunA()
		{
			AutoMockContainer
				.GetMock<IServiceA>()
				.Verify(v => v.RunA(), Times.Once());
		}

		[Test]
		public void Should_run_ServiceB_RunB()
		{
			AutoMockContainer
				.GetMock<IServiceB>()
				.Verify(v => v.RunB(), Times.Once());
		}
	}
}