using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DynamicMethodInvocationSpike
{
	public delegate Object LateBoundMethod(Object target, Object[] arguments);

	public static class MethodInfoExtensions2
	{	
		private static readonly ConcurrentDictionary<MethodInfo, LateBoundMethod> _delegateCache = new ConcurrentDictionary<MethodInfo, LateBoundMethod>(); 
	
		public static Func<T1, T2, TResult> CreateFunction<T1, T2, TResult>(this MethodInfo method, Object instance)
		{
			var lateBoundMethod = CreateDelegateV2(method);
			return (p1, p2) => (TResult)lateBoundMethod(instance, new Object[] { p1, p2 });
		}

		public static LateBoundMethod CreateDelegateV2(this MethodInfo method)
		{
			LateBoundMethod lateBoundMethod;
			if(_delegateCache.TryGetValue(method, out lateBoundMethod))
				return lateBoundMethod;
		
			var instanceParameter = Expression.Parameter(typeof(object), "target");
			var argumentsParameter = Expression.Parameter(typeof(object[]), "arguments");

			var call = Expression.Call(
				Expression.Convert(instanceParameter, method.DeclaringType),
				method,
				CreateParameterExpressions(method, argumentsParameter));

			var lambda = Expression.Lambda<LateBoundMethod>(
				Expression.Convert(call, typeof(object)),
				instanceParameter,
				argumentsParameter);

			lateBoundMethod = lambda.Compile();
			_delegateCache.TryAdd(method, lateBoundMethod);

			return lateBoundMethod;
		}

		private static Expression[] CreateParameterExpressions(MethodInfo method, Expression argumentsParameter)
		{
		  return method.GetParameters().Select((parameter, index) =>
			Expression.Convert(
			  Expression.ArrayIndex(argumentsParameter, Expression.Constant(index)), parameter.ParameterType)).ToArray();
		}
	}
}