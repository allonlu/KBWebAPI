using AutoMapper;
using Castle.Core.Logging;
using Comm100.Domain.Ioc;
using Comm100.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using ILogger = Comm100.Runtime.ILogger;
using NullLogger = Comm100.Runtime.NullLogger;

namespace Comm100.Application.Services
{
    public abstract class AppServiceBase: IAppService
    {
        public AppServiceBase()
        {
            this.Session = NullSession.Instance;
            this.PermissionChecker = NullPermissionChecker.Instance;
            this.Logger = NullLogger.Instance;
        }
        /// <summary>
        /// IOC容器注入
        /// </summary>
        [Mandatory]
        public ISession Session { get; set; }
        /// <summary>
        /// IOC容器注入
        /// </summary>
        [Mandatory]
        public IPermissionChecker PermissionChecker { get; set; }
        /// <summary>
        /// IOC容器注入
        /// </summary>
        [Mandatory]
        public ILogger Logger { get; set; }

        public IMapper Mapper { get; set; }
        
    }
}
