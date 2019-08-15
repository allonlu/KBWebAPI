using Comm100.Application.Dto;
using Comm100.Domain.Entity;
using Comm100.Runtime.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Extension
{
    public static class EntityExtention
    {
        public static void ModifyBy<T>(this IEntity<T> entity, IEntityDto<T> obj)
        {

            if (!entity.Id.Equals(obj.Id))
                throw new Comm100Exception(100105, ErrorMessages.E100105);

            foreach (var p in obj.GetType().GetProperties())
            {
                if (p.Name == "Id") continue;
                var v = p.GetValue(obj);
                if (v!= null )
                {
                    entity.GetType().GetProperty(p.Name)?.SetValue(entity,v);
                }
            }
        }
        public static void Modify<T>(this IEntity<T> entity, IEntity<T> entityBase)
        {
            if (!entity.Id.Equals(entityBase.Id))
                throw new Comm100Exception(100105, ErrorMessages.E100105);

            foreach (var p in entityBase.GetType().GetProperties())
            {
                if (p.Name == "Id") continue;
                var v1 = p.GetValue(entityBase);
                var v2 = p.GetValue(entity);
                if (v1 != v2)
                {
                    p.SetValue(entity, v1);
                }
            }
        }
    }
}
