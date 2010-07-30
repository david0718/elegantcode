using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DynamicMethodInvocationSpike
{
    public static class ParameterInfoExtensions
    {
        public static IEnumerable<ParameterExpression> ToParameterExpressions(this IEnumerable<ParameterInfo> parameters)
        {
            return parameters.Select((parameter, index) => ToParameterExpression(parameter, "parameter" + index));
        }

        public static ParameterExpression ToParameterExpression(this ParameterInfo parameterInfo, String defaultParameterName)
        {
            return Expression.Parameter(parameterInfo.ParameterType, parameterInfo.Name ?? defaultParameterName);
        }
    }
}