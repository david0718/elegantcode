using Moq;
using NUnit.Framework;
using UnityAutoMocker.Examples.ExampleSystemUnderTest;

namespace UnityAutoMocker.Examples
{
	[TestFixture]
	public class Example__how_to_use_the_UnityAutoMockContainer_to_override_a_method_on_the_SystemUnderTest_to_test_a_certain_behavior : FixtureBase
	{

		private TestComponent _testComponent;

		protected override void Before_all_tests()
		{
			base.Before_all_tests();
			var mockTestComponent = AutoMockContainer.GetMock<TestComponent>();

			mockTestComponent
				.Setup(s => s.HowDidItGo())
				.Returns(false);

			_testComponent = mockTestComponent.Object;
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
				.Verify(v => v.RunA(), Times.Never());
		}

		[Test]
		public void Should_run_ServiceB_RunB()
		{
			AutoMockContainer
				.GetMock<IServiceB>()
				.Verify(v => v.RunB(), Times.Never());
		}
	}
}