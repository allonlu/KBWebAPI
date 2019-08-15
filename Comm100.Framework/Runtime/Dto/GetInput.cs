using Comm100.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Runtime.Dto
{
    public class GetInput<T> : IncludeInput,IEntityDto<T>
    {
        public T Id { get; set; }
        public GetInput(T id,string include="")
        {
            this.Id = id;
            this.Include = include;
        }
    }
}
