using Castle.DynamicProxy;
using Comm100.Runtime.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Transactions;

namespace Comm100.Extension
{
    public static class InterceptorExtension
    {
        public static MethodInfo GetMethod(this IInvocation invocation)
        {
            try
            {
                return invocation.MethodInvocationTarget;
            }
            catch
            {
                return invocation.GetConcreteMethod();
            }
        }
        public static IsolationLevel GetIsolationLevel(this MethodInfo methodInfo)
        {
            var attrs = methodInfo.GetCustomAttributes(true).OfType<TransactionAttribute>().ToArray();
            if (attrs.Length > 0)
                return attrs[0].IsolationLevel;

            switch (methodInfo.Name.Substring(0, 3))
            {
                case "Add":
                    return IsolationLevel.Serializable;

                default:
                    return IsolationLevel.ReadCommitted;
            }

        }
        public static IsolationLevel GetIsolationLevel(this IInvocation invocation)
        {
            return invocation.GetMethod().GetIsolationLevel();
        }
    }
}
