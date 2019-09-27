using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Comm100.Framework
{
    public class Paging
    {        
        [Range(1, int.MaxValue)]
        public int PageIndex { get; set; } = 1;

        [Range(10, 100)]
        public int PageSize { get; set; } = 10;
    }
}
