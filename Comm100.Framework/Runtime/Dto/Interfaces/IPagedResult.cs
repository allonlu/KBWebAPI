using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Runtime.Dto
{
    public interface IPagedResult<T>
    {
        IReadOnlyList<T> Items { get; }
        int TotalCount { get; }
    }
}
