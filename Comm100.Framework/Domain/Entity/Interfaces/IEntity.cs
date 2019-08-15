using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Domain.Entity
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
    public interface IEntity : IEntity<int> { }

    public interface IGuidEntity : IEntity<Guid> { }
}
