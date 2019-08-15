using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Comm100.Runtime.Dto
{
    public interface IPagingRequest
    {
       
        int PageSize { get; set; }
        int PageIndex { get; set; }
    }
}
