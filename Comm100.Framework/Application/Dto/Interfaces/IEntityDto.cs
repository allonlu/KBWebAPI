using Comm100.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Application.Dto
{
    public interface IEntityDto<TKey>:IEntity<TKey>
    {
    }
    public interface IEntityDto : IEntityDto<int> { }

    public interface IGuidEntityDto : IEntityDto<Guid> { }
}
