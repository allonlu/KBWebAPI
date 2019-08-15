using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Comm100.Runtime.Exception
{
    public class EntityNotFoundException : Comm100Exception
    {
        public Type EntityType { get; set; }
        public Guid Id { get; set; }

        public override string Message => string.Format(base.Message, EntityType.Name, Id);

        public EntityNotFoundException(Guid id, Type entityType) : this(id)
        {
            EntityType = entityType;

        }
        public EntityNotFoundException(Guid id) : base(100101,ErrorMessages.E100101)
        {
            Id = id;
        }
    }
}
