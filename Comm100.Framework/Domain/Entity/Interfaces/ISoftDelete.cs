using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Framework.Domain.Entity
{
    public interface ISoftDelete
    {
        /// <summary>
        ///  Used to mark an Entity as 'Deleted'
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
