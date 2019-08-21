using Castle.MicroKernel;
using Comm100.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain
{
    public class DomainIocInitializer
    {
        public static void Init(IKernel kernel)
        {
            kernel.DomainServiceRegister(typeof(DomainIocInitializer).Assembly);
        }
    }
}
