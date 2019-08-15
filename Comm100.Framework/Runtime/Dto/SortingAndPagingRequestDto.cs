using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Comm100.Runtime.Dto
{
    public class SortingAndPagingRequestDto : ISortingAndPagingRequest
    {
        public SortingAndPagingRequestDto()
        {
            PageSize = 10;
            PageIndex = 0;
        }
        public string Sorting { get; set; }
        [Range(10, 100)]
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
