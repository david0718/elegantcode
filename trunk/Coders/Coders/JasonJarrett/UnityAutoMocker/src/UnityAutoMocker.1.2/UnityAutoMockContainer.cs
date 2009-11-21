
namespace Moq
{
	namespace AutoMocking
	{
		using System;
		using System.Collections.Generic;
		using System.Diagnostics;
		using System.Reflection;
		using Microsoft.Practices.ObjectBuilder2;
		using Microsoft.Practices.Unity;
		using Microsoft.Practices.Unity.ObjectBuilder;
		using Moq.AutoMocking.Internal;

		public class UnityAutoMockContainer : AutoMockContainer
		{
			public UnityAutoMockContainer(MockFactory factory)
				: base(new UnityAutoMockerBackingContainer(factory))
			{
			}

			private class UnityAutoMockerBackingContainer : IAutoMockerBackingContainer
			{
				private readonly IUnityContainer _unityContainer = new UnityContainer();

				public UnityAutoMockerBackingContainer(MockFactory factory)
				{
					_unityContainer.AddExtension(new MockFactoryContainerExtension(factory));
				}

				public void RegisterInstance<TService>(TService instance)
				{
					_unityContainer.RegisterInstance(instance, new ContainerControlledLifetimeManager());
				}

				public void RegisterType<TService, TImplementation>()
					where TImplementation : TService
				{
					_unityContainer.RegisterType<TService, TImplementation>(new ContainerControlledLifetimeManager());
				}

				public T Resolve<T>()
				{
					return _unityContainer.Resolve<T>();
				}

				private class MockFactoryContainerExtension : UnityContainerExtension
				{
					private readonly MockFactory _mockFactory;

					public MockFactoryContainerExtension(MockFactory mockFactory)
					{
						_mockFactory = mockFactory;
					}

					protected override void Initialize()
					{
						Context.Strategies.Add(new MockExtensibilityStrategy(_mockFactory), UnityBuildStage.PreCreation);
					}
				}

				private class MockExtensibilityStrategy : BuilderStrategy
				{
					private readonly MockFactory _factory;
					private readonly MethodInfo _createMethod;
					private readonly Dictionary<Type, Mock> _alreadyCreatedMocks = new Dictionary<Type, Mock>();

					public MockExtensibilityStrategy(MockFactory factory)
					{
						_factory = factory;
						_createMethod = factory.GetType().GetMethod("Create", new Type[] { });
						Debug.Assert(_createMethod != null);
					}

					public override void PreBuildUp(IBuilderContext context)
					{
						var buildKey = context.BuildKey as IBuildKey;
						if (buildKey == null)
							throw new InvalidOperationException("buildKey is null");

						Type mockServiceType = buildKey.Type;

						if (!mockServiceType.IsInterface)
						{
							base.PreBuildUp(context);
						}
						else
						{
							Mock mockedObject;

							if (_alreadyCreatedMocks.ContainsKey(mockServiceType))
							{
								mockedObject = _alreadyCreatedMocks[mockServiceType];
							}
							else
							{
								var specificCreateMethod = _createMethod.MakeGenericMethod(new[] { mockServiceType });
								mockedObject = (Mock)specificCreateMethod.Invoke(_factory, null);
								_alreadyCreatedMocks.Add(mockServiceType, mockedObject);
							}

							context.Existing = mockedObject.Object;
							context.BuildComplete = true;
						}
					}
				}
			}
		}
	}

	namespace AutoMocking.Internal
	{

		public interface IAutoMockerBackingContainer
		{
			void RegisterInstance<TService>(TService instance);
			void RegisterType<TService, TImplementation>() where TImplementation : TService;
			T Resolve<T>();
		}

		public abstract class AutoMockContainer
		{

			private readonly IAutoMockerBackingContainer _container;

			/// <summary>
			/// Initializes the container with the <see cref="MockFactory"/> that
			/// will be used to create dependent mocks.
			/// </summary>
			protected AutoMockContainer(IAutoMockerBackingContainer container)
			{
				_container = container;
			}

			public Mock<T> GetMock<T>()
					where T : class
			{
				var obj = (IMocked<T>)Resolve<T>();
				return obj.Mock;
			}

			public void RegisterInstance<TService>(TService instance)
			{
				_container.RegisterInstance(instance);
			}

			public void Register<TService, TImplementation>()
				where TImplementation : TService
			{
				_container.RegisterType<TService, TImplementation>();
			}

			public T Resolve<T>()
			{
				return _container.Resolve<T>();
			}

		}
	}

	namespace AutoMocking.Testing
	{
		using System;
		using System.Collections.Generic;
		using System.Diagnostics;
		using Moq.AutoMocking.Internal;

		public class UnityAutoMockContainerFixture : AutoMockContainerFixture
		{
			protected override AutoMockContainer GetAutoMockContainer(MockFactory factory)
			{
				return new UnityAutoMockContainer(factory);
			}
		}


		public abstract class AutoMockContainerFixture
		{
			public static void RunAllTests(AutoMockContainerFixture fixture, Action<string> messageWriter)
			{
				foreach (var assertion in fixture.GetAllAssertions)
				{
					messageWriter("Running Test - " + assertion.Method.Name);
					assertion();
				}
			}

			public IEnumerable<Action> GetAllAssertions
			{
				get
				{
					yield return CreatesLooseMocksIfFactoryIsLoose;
					yield return CanRegisterImplementationAndResolveIt;
					yield return ResolveUnregisteredImplementationReturnsMock;
					yield return DefaultConstructorWorksWithAllTests;
					yield return ThrowsIfStrictMockWithoutExpectation;
					yield return StrictWorksWithAllExpectationsMet;
					yield return RegisteringNonMockInstanceAndTryingToResolveItAsAMockFails;
				}
			}

			protected abstract AutoMockContainer GetAutoMockContainer(MockFactory factory);

			public void CreatesLooseMocksIfFactoryIsLoose()
			{
				var factory = GetAutoMockContainer(new MockFactory(MockBehavior.Loose));
				var component = factory.Resolve<TestComponent>();

				component.RunAll();
			}

			public void RegisteringNonMockInstanceAndTryingToResolveItAsAMockFails()
			{
				var container = GetAutoMockContainer(new MockFactory(MockBehavior.Loose));

				container.RegisterInstance(new ServiceA());

				Assert.ShouldThrow(typeof(InvalidCastException), () => container.GetMock<ServiceA>());
			}

			public void CanRegisterImplementationAndResolveIt()
			{
				var factory = GetAutoMockContainer(new MockFactory(MockBehavior.Loose));
				factory.Register<ITestComponent, TestComponent>();

				var testComponent = factory.Resolve<ITestComponent>();

				Assert.IsNotNull(testComponent);
				Assert.IsFalse(testComponent is IMocked<ITestComponent>);
			}



			public void ResolveUnregisteredImplementationReturnsMock()
			{
				var factory = GetAutoMockContainer(new MockFactory(MockBehavior.Loose));

				var service = factory.Resolve<IServiceA>();

				Assert.IsNotNull(service);
				Assert.IsTrue(service is IMocked<IServiceA>);
			}

			public void DefaultConstructorWorksWithAllTests()
			{
				var factory = GetAutoMockContainer(new MockFactory(MockBehavior.Loose));
				var a = false;
				var b = false;

				factory.GetMock<IServiceA>().Setup(x => x.RunA()).Callback(() => a = true);
				factory.GetMock<IServiceB>().Setup(x => x.RunB()).Callback(() => b = true);

				var component = factory.Resolve<TestComponent>();

				component.RunAll();

				Assert.IsTrue(a);
				Assert.IsTrue(b);
			}


			public void ThrowsIfStrictMockWithoutExpectation()
			{
				var factory = GetAutoMockContainer(new MockFactory(MockBehavior.Strict));
				factory.GetMock<IServiceB>().Setup(x => x.RunB());

				var component = factory.Resolve<TestComponent>();
				Assert.ShouldThrow(typeof(MockException), component.RunAll);

			}


			public void StrictWorksWithAllExpectationsMet()
			{
				var factory = GetAutoMockContainer(new MockFactory(MockBehavior.Strict));
				factory.GetMock<IServiceA>().Setup(x => x.RunA());
				factory.GetMock<IServiceB>().Setup(x => x.RunB());

				var component = factory.Resolve<TestComponent>();
				component.RunAll();
			}


			public interface IServiceA
			{
				void RunA();
			}

			public interface IServiceB
			{
				void RunB();
			}

			public class ServiceA : IServiceA
			{
				public ServiceA()
				{
				}

				public ServiceA(int count)
				{
					this.Count = count;
				}

				public ServiceA(IServiceB b)
				{
					this.ServiceB = b;
				}

				public IServiceB ServiceB { get; private set; }
				public int Count { get; private set; }

				public string Value { get; set; }

				public void RunA() { }
			}


			public interface ITestComponent
			{
				void RunAll();
				IServiceA ServiceA { get; }
				IServiceB ServiceB { get; }
			}

			public class TestComponent : ITestComponent
			{
				public TestComponent(IServiceA serviceA, IServiceB serviceB)
				{
					this.ServiceA = serviceA;
					this.ServiceB = serviceB;
				}

				public IServiceA ServiceA { get; private set; }
				public IServiceB ServiceB { get; private set; }

				public void RunAll()
				{
					this.ServiceA.RunA();
					this.ServiceB.RunB();
				}
			}
		}


		internal static class Assert
		{
			public static void IsNotNull(object component)
			{
				Debug.Assert(component != null);
			}

			private static void IsNotNull(object component, string message)
			{
				Debug.Assert(component != null, message);
			}

			public static void IsFalse(bool condition)
			{
				Debug.Assert(condition == false);
			}

			public static void IsTrue(bool condition)
			{
				Debug.Assert(condition);
			}

			public static void ShouldThrow(Type exceptionType, Action method)
			{
				Exception exception = GetException(method);

				Assert.IsNotNull(exception, string.Format("Exception of type[{0}] was not thrown.", exceptionType.FullName));
				Debug.Assert(exceptionType == exception.GetType());
			}

			[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
			private static Exception GetException(Action method)
			{
				Exception exception = null;

				try
				{
					method();
				}
				catch (Exception e)
				{
					exception = e;
				}

				return exception;
			}
		}

	}
}