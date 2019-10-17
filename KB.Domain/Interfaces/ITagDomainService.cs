using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Interfaces
{
    public interface ITagDomainService
    {
        Tag Get(Guid id);

        IReadOnlyList<Tag> List();
    }
}
