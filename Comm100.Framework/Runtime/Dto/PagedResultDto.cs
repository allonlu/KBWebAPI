using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Runtime.Dto
{
    [Serializable]
    public class PagedResultDto<T> : IPagedResult<T>
    {
        public PagedResultDto(int totalCount, List<T> list)
        {
            this.TotalCount = totalCount;
            this.Items = list;
        }
        //{"articles": [{}] , "total": 2]}
        //{"categoies": [{}], "total": 3]}
        [JsonProperty] // should dynamic serilizable 
        public IReadOnlyList<T> Items { get; private set; }
        public int TotalCount { get; private set; }
    }
}
