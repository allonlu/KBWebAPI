using System;
using System.ComponentModel.DataAnnotations.Schema;
using Comm100.Framework.Constants;

namespace Comm100.Framework.Domain.Entity
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TableSeparateAttribute : TableAttribute
    {
        public TableSeparateAttribute(string name)
            : base(name + DBConstants.TABLE_SEPERATE_PLACEHOLDER)
        {
        }
    }
}
