using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Domain.Entity
{
    public interface IDeletion
    {
        bool IsDeleted { get; set; }
    }
}
