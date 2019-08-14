using System;
using System.Linq;
using System.Linq.Expressions;

namespace Comm100.Framework
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate, bool condition)
        {
            return condition ? query.Where(predicate) : query;
        }
    }
}
