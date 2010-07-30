using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DynamicMethodInvocationSpike
{
	public static class MethodInfoExtensions
	{
        public static TDelegate CreateDelegate<TDelegate>(this MethodInfo method, Object instance) where TDelegate : class
        {
            return CreateCachedDelegate<TDelegate>(method, (typeArguments, parameterExpressions) =>
            {
                Expression<Func<Object>> instanceExpression = () => instance;
                return Expression.Call(Expression.Convert(instanceExpression.Body, instance.GetType()),
                                       method.Name,
                                       typeArguments,
                                       ProvideStrongArgumentsFor(method, parameterExpressions));
            });
        }

        public static TDelegate CreateDelegate<TDelegate>(this MethodInfo method) where TDelegate : class
        {
            return CreateCachedDelegate<TDelegate>(method, (typeArguments, parameterExpressions)
                => Expression.Call(method.DeclaringType, method.Name, typeArguments,
                                   ProvideStrongArgumentsFor(method, parameterExpressions)));
        }

        private static TDelegate CreateCachedDelegate<TDelegate>(MethodBase method, Func<Type[], ParameterExpression[], MethodCallExpression> getCallExpression)
            where TDelegate : class
        {
            var @delegate = GetFromCache<TDelegate>();
            if(null == @delegate)
            {
                @delegate = CreateDelegate<TDelegate>(method, getCallExpression);
                StoreInCache(@delegate);
            }

            return @delegate;
        }

        private static TDelegate GetFromCache<TDelegate>()
        {
            Object delegateObj;
            if(_delegateCache.TryGetValue(typeof(TDelegate), out delegateObj))
                return (TDelegate)delegateObj;

            return default(TDelegate);
        }

        private static void StoreInCache<TDelegate>(TDelegate @delegate)
        {
            _delegateCache.TryAdd(typeof(TDelegate), @delegate);
        }

        private static TDelegate CreateDelegate<TDelegate>(MethodBase method, Func<Type[], ParameterExpression[], MethodCallExpression> getCallExpression)
        {
            var parameterExpressions = ExtractParameterExpressionsFrom<TDelegate>();
            CheckParameterCountsAreEqual(parameterExpressions, method.GetParameters());

            var call = getCallExpression(GetTypeArgumentsFor(method), parameterExpressions);

            var lambda = Expression.Lambda<TDelegate>(call, parameterExpressions);
            return lambda.Compile();
        }

        private static ParameterExpression[] ExtractParameterExpressionsFrom<TDelegate>()
        {
            return typeof(TDelegate)
                .GetMethod("Invoke")
                .GetParameters()
                .ToParameterExpressions()
                .ToArray();
        }

        private static void CheckParameterCountsAreEqual(IEnumerable<ParameterExpression> delegateParameters,
                                                         IEnumerable<ParameterInfo> methodParameters)
        {
            if(delegateParameters.Count() != methodParameters.Count())
                throw new InvalidOperationException("The number of parameters of the requested delegate does not match the number " +
                                                    "parameters of the specified method.");
        }

        private static Type[] GetTypeArgumentsFor(MethodBase method)
        {
            var typeArguments = method.GetGenericArguments();
            return (typeArguments.Length > 0) ? typeArguments : null;
        }

        private static Expression[] ProvideStrongArgumentsFor(MethodInfo method, ParameterExpression[] parameterExpressions)
        {
            return method.GetParameters()
                .Select((parameter, index) => Expression.Convert(parameterExpressions[index], parameter.ParameterType))
                .ToArray();
        }

        private static readonly ConcurrentDictionary<Type, Object> _delegateCache =
            new ConcurrentDictionary<Type, Object>(); 
	}
}