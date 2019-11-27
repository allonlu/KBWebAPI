using System;
using AutoMapper;

namespace Comm100.Framework.AutoMapper
{
    public abstract class BaseAutoMapAttribute : Attribute
    {
        public Type[] TargetTypes { get; private set; }

        protected BaseAutoMapAttribute(params Type[] TargetTypes)
        {
            this.TargetTypes = TargetTypes;
        }

        public abstract void CreateMap(IMapperConfigurationExpression configuration, Type type);
    }
}
