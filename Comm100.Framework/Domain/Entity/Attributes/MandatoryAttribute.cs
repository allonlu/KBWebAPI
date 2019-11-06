using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Domain.Ioc
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class  MandatoryAttribute : Attribute { }
}
