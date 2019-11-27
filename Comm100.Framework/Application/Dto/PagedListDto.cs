//-----------------------------------------------------------------------
// <copyright file="PagedListDto.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework
{
    using System.Collections.Generic;

    public class PagedListDto<T>
    {
        public PagedListDto(int total, IEnumerable<T> list)
        {
            this.TotalCount = total;
            this.List = list;
        }

        // [JsonProperty] dynamic serialization property name by T
        public IEnumerable<T> List { get; set; }

        public int TotalCount { get; set; }
    }
}
