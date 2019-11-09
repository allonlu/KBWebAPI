using Castle.DynamicProxy;
using Comm100.Framework.AuditLog;
using Comm100.Runtime.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Transactions;

namespace Comm100.Framework.Extensions
{
    public static class InterceptorExtension
    {
        private static MethodInfo GetMethod(this IInvocation invocation)
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

        public static T[] GetAttributes<T>(this IInvocation invocation)
        {
            var attrs = invocation.GetMethod().GetCustomAttributes(true).OfType<T>().ToArray();
            return attrs;
        }

        public static IsolationLevel GetIsolationLevel(this IInvocation invocation)
        {
            var attrs = invocation.GetAttributes<TransactionAttribute>();
            if (attrs.Length > 0)
                return attrs[0].IsolationLevel;

            return IsolationLevel.ReadCommitted;
        }

        public static string GetAuditAction(this IInvocation invocation)
        {
            var attrs = invocation.GetAttributes<AuditAttribute>();
            if (attrs.Length > 0)
                return attrs[0].Action;

            return null;
        }
    }
}
