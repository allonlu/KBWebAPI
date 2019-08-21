using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Comm100.Framework
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate, bool condition)
        {
            return condition ? query.Where(predicate) : query;
        }

        public static IQueryable<T> Query<T>(this IQueryable<T> query, IEntityQueryer<T> queryable)
        {
            return queryable.ProcessQuery(query);
        }

        public static IQueryable<T> IncludeLoading<T>(this IQueryable<T> query, IEntityIncluder<T> includable)
        {
            return includable.ProcessInclude(query);
        }

        public static IQueryable<T> Paging<T>(this IQueryable<T> query, Paging paging)
        {
            return paging == null ? query : query.Skip(paging.Index * paging.Size).Take(paging.Size);
        }

        public static IQueryable<T> Sorting<T>(this IQueryable<T> query, Sorting sorting)
        {
            return sorting == null ? query : query;//.OrderBy(sorting.);
        }
    }

    public interface IEntityQueryer<T>
    {
        IQueryable<T> ProcessQuery(IQueryable<T> query);
    }

    public interface IEntityIncluder<T>
    {
        IQueryable<T> ProcessInclude(IQueryable<T> query);

        T ProcessInclude(T t);
    }

    public static class StringIncludeExtension {

        
    }

}