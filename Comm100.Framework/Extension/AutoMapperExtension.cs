using Comm100.Runtime.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comm100.Extension
{
    public static class AutoMapperExtension
    {
        public static S MapTo<S>(this object source)
        {
            return default(S);//AutoMapper.Mapper.Map<S>(source);
        }
        public static IPagedResult<S> MapTo<T, S>(this IPagedResult<T> pagedResult)
        {
            return null;
            //return new PagedResultDto<S>(pagedResult.TotalCount, AutoMapper.Mapper.Map<IReadOnlyList<T>, List<S>>());
        }
        public static IList<T> MapTo<S, T>(this IEnumerable<S> source)
        {
            return source.Select(s => s.MapTo<T>()).ToList();
        }
    }
}
