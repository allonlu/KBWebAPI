using System;
namespace Comm100.Framework.Domain.Entity
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Property, AllowMultiple = false)]
    public class EnumToStringAttribute : Attribute
    {
        public EnumToStringAttribute()
        {
        }
    }
}
