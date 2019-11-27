using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Domain.Entity
{
    public class EntityEqualityComparer<Tkey> : IEqualityComparer<IEntity<Tkey>>
    {


        public bool Equals(IEntity<Tkey> x, IEntity<Tkey> y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(IEntity<Tkey> obj)
        {
            return obj.GetHashCode();
        }

        public static EntityEqualityComparer<Tkey> Instance => new EntityEqualityComparer<Tkey>();
    }
}
