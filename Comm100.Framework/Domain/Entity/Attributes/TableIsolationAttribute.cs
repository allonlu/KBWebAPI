using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Framework.Domain.Entity.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TableIsolationAttribute : Attribute
    {

    }
}
