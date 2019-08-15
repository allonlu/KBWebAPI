using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Framework
{
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
