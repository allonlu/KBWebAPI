using Comm100.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Domain.Entity
{
    [TableSwitch]
    public class SiteEntity : IGuidEntity, IBelongToSite
    {
        public Guid Id { get; set; }
        public int SiteId { get ; set ; }
    }
}
