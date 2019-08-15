using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ModelBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comm100.Domain.Ioc
{
    public class MandatoryPropertyComponentModelHelper : IContributeComponentModelConstruction
    {
        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            foreach (var property in model.Properties)
            {
                if (property.Property.GetCustomAttributes(inherit: true).Any(x => x is MandatoryAttribute))
                {
                    property.Dependency.IsOptional = false;
                }
            }
        }
    }
}
