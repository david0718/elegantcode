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

		public class UnityAutoMockContainer : AutoMockContainer
		{
			public const string NameForMocking = "____FOR____MOCKING____";
			public UnityAutoMockContainer(MockFactory factory)
				: base(new UnityAutoMockerBackingContainer(factory))
			{
			}

			private class UnityAutoMockerBackingContainer : IAutoMockerBackingContainer
			{
				private readonly IUnityContainer _unityContainer = new UnityContainer();

				public UnityAutoMockerBackingContainer(MockFactory factory)
				{
					_unityContainer.AddExtension(new MockFactoryContainerExtension(factory, this));
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

				public object Resolve(Type type)
				{
					return _unityContainer.Resolve(type);
				}

				public IMocked<T> ResolveForMocking<T>()
					where T : class
				{
					return (IMocked<T>)_unityContainer.Resolve<T>(NameForMocking);
				}

				private class MockFactoryContainerExtension : UnityContainerExtension
				{
					private readonly MockFactory _mockFactory;
					private readonly IAutoMockerBackingContainer _container;

					public MockFactoryContainerExtension(MockFactory mockFactory, IAutoMockerBackingContainer container)
					{
						_mockFactory = mockFactory;
						_container = container;
					}

					protected override void Initialize()
					{
						Context.Strategies.Add(new MockExtensibilityStrategy(_mockFactory, _container), UnityBuildStage.PreCreation);
					}
				}

				private class MockExtensibilityStrategy : BuilderStrategy
				{
					private readonly MockFactory _factory;
					private readonly IAutoMockerBackingContainer _container;
					private readonly MethodInfo _createMethod;
					private readonly Dictionary<Type, Mock> _alreadyCreatedMocks = new Dictionary<Type, Mock>();
					private MethodInfo _createMethodWithParameters;

					public MockExtensibilityStrategy(MockFactory factory, IAutoMockerBackingContainer container)
					{
						_factory = factory;
						_container = container;
						_createMethod = factory.GetType().GetMethod("Create", new Type[] { });
						Debug.Assert(_createMethod != null);
					}

					public override void PreBuildUp(IBuilderContext context)
					{
						NamedTypeBuildKey buildKey = (NamedTypeBuildKey)context.BuildKey;
						bool isToBeAMockedClassInstance = buildKey.Name == NameForMocking;
						Type mockServiceType = buildKey.Type;

						if (!mockServiceType.IsInterface && !isToBeAMockedClassInstance)
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
								if (isToBeAMockedClassInstance && !mockServiceType.IsInterface)
								{
									object[] mockedParametersToInject = GetConstructorParameters(context).ToArray();

									_createMethodWithParameters = _factory.GetType().GetMethod("Create", new[] { typeof(object[]) });

									MethodInfo specificCreateMethod = _createMethodWithParameters.MakeGenericMethod(new[] { mockServiceType });

									var x = specificCreateMethod.Invoke(_factory, new object[] { mockedParametersToInject });
									mockedObject = (Mock)x;
								}
								else
								{
									MethodInfo specificCreateMethod = _createMethod.MakeGenericMethod(new[] { mockServiceType });
									mockedObject = (Mock)specificCreateMethod.Invoke(_factory, null);
								}

								_alreadyCreatedMocks.Add(mockServiceType, mockedObject);
							}


							context.Existing = mockedObject.Object;
							context.BuildComplete = true;
						}
					}

					private List<object> GetConstructorParameters(IBuilderContext context)
					{
						var parameters = new List<object>();
						var policy = new DefaultUnityConstructorSelectorPolicy();
						var constructor = policy.SelectConstructor(context).Constructor;
						foreach (ParameterInfo parameterInfo in constructor.GetParameters())
							parameters.Add(_container.Resolve(parameterInfo.ParameterType));

						return parameters;
					}
				}
			}
		}
	}

	namespace AutoMocking
	{
		using System;

		public interface IAutoMockerBackingContainer
		{
			void RegisterInstance<TService>(TService instance);
			void RegisterType<TService, TImplementation>() where TImplementation : TService;
			T Resolve<T>();
			object Resolve(Type type);
			IMocked<T> ResolveForMocking<T>() where T : class;
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
				return _container.ResolveForMocking<T>().Mock;
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
		using System.Linq;
		using System.Reflection;

		public class UnityAutoMockContainerFixture
		{
			protected UnityAutoMockContainer GetAutoMockContainer(MockFactory factory)
			{
				return new UnityAutoMockContainer(factory);
			}

			public static void RunAllTests(Action<string> messageWriter)
			{
				var fixture = new UnityAutoMockContainerFixture();
				RunAllTests(fixture, messageWriter);
			}

			public static void RunAllTests(UnityAutoMockContainerFixture fixture, Action<string> messageWriter)
			{
				messageWriter("Starting Tests...");
				foreach (var assertion in fixture.GetAllAssertions)
				{
					assertion(messageWriter);
				}
				messageWriter("Completed Tests...");
			}

			public IEnumerable<Action<Action<string>>> GetAllAssertions
			{
				get
				{
					var methodInfos = this
						.GetType()
						.GetMethods(BindingFlags.Public | BindingFlags.Instance)
						.Where(w => w.GetCustomAttributes(typeof(TestAttribute), true).Any());
					var tests = new List<Action<Action<string>>>();
					foreach (var methodInfo in methodInfos)
					{
						MethodInfo info = methodInfo;
						Action<Action<string>> a = messageWriter =>
									{
										messageWriter("Testing - " + info.Name);
										info.Invoke(this, new object[0]);
									};

						tests.Add(a);
					}

					foreach (var action in tests)
						yield return action;
				}
			}

			[Test]
			public void CreatesLooseMocksIfFactoryIsLoose()
			{
				var factory = GetAutoMockContainer(new MockFactory(MockBehavior.Loose));
				var component = factory.Resolve<TestComponent>();

				component.RunAll();
			}

			[Test]
			public void CanRegisterImplementationAndResolveIt()
			{
				var factory = GetAutoMockContainer(new MockFactory(MockBehavior.Loose));
				factory.Register<ITestComponent, TestComponent>();

				var testComponent = factory.Resolve<ITestComponent>();

				Assert.IsNotNull(testComponent);
				Assert.IsFalse(testComponent is IMocked<ITestComponent>);
			}

			[Test]
			public void ResolveUnregisteredInterfaceReturnsMock()
			{
				var factory = GetAutoMockContainer(new MockFactory(MockBehavior.Loose));

				var service = factory.Resolve<IServiceA>();

				Assert.IsNotNull(service);
				Assert.IsTrue(service is IMocked<IServiceA>);
			}

			[Test]
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


			[Test]
			public void ThrowsIfStrictMockWithoutExpectation()
			{
				var factory = GetAutoMockContainer(new MockFactory(MockBehavior.Strict));
				factory.GetMock<IServiceB>().Setup(x => x.RunB());

				var component = factory.Resolve<TestComponent>();
				Assert.ShouldThrow(typeof(MockException), component.RunAll);

			}


			[Test]
			public void StrictWorksWithAllExpectationsMet()
			{
				var factory = GetAutoMockContainer(new MockFactory(MockBehavior.Strict));
				factory.GetMock<IServiceA>().Setup(x => x.RunA());
				factory.GetMock<IServiceB>().Setup(x => x.RunB());

				var component = factory.Resolve<TestComponent>();
				component.RunAll();
			}

			[Test]
			public void GetMockedInstanceOfConcreteClass()
			{
				var factory = GetAutoMockContainer(new MockFactory(MockBehavior.Loose));
				var mockedInstance = factory.GetMock<TestComponent>();

				Assert.IsNotNull(mockedInstance);
				Assert.IsNotNull(mockedInstance.Object.ServiceA);
				Assert.IsNotNull(mockedInstance.Object.ServiceB);
			}

			[Test]
			public void GetMockedInstanceOfConcreteClassWithInterfaceConstructorParameter()
			{
				var factory = GetAutoMockContainer(new MockFactory(MockBehavior.Loose));
				var mockedInstance = factory.GetMock<TestComponent>();
				Assert.IsNotNull(mockedInstance);
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
					Count = count;
				}

				public ServiceA(IServiceB b)
				{
					ServiceB = b;
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
					ServiceA = serviceA;
					ServiceB = serviceB;
				}

				public IServiceA ServiceA { get; private set; }
				public IServiceB ServiceB { get; private set; }

				public void RunAll()
				{
					ServiceA.RunA();
					ServiceB.RunB();
				}
			}
		}

		[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
		public class TestAttribute : Attribute { }

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

				IsNotNull(exception, string.Format("Exception of type[{0}] was not thrown.", exceptionType.FullName));
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