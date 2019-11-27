using Comm100.Framework.Domain.Services;
using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Interfaces
{
    public interface ITagDomainService : IDomainService
    {
        Tag Get(Guid id);

        IReadOnlyList<Tag> List();
    }
}
