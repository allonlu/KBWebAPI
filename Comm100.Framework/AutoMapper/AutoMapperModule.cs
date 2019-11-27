using System;
using Comm100.Framework.Module;
using Comm100.Framework.Reflection;
using Comm100.Framework.Extension;
using AutoMapper;
using System.Reflection;
using Castle.MicroKernel.Registration;

namespace Comm100.Framework.AutoMapper
{
    public class AutoMapperModule : AbstractModule
    {
        private readonly ITypeFinder _typeFinder;

        public AutoMapperModule(ITypeFinder typeFinder)
        {
            _typeFinder = typeFinder;
        }

        // TODO
        // Auto Mapper Config
        //public override void PreInitialize()
        //{
            //Container.Register<IAutoMapperConfiguration, AutoMapperConfiguration>();

            //Configuration.ReplaceService<ObjectMapping.IObjectMapper, AutoMapperObjectMapper>();

            //Configuration.Modules.AbpAutoMapper().Configurators.Add(CreateCoreMappings);
        //}

        public override void PostInitialize()
        {
            CreateMappings();
        }

        private void CreateMappings()
        {
            Action<IMapperConfigurationExpression> configurer = configuration =>
            {
                FindAndAutoMapTypes(configuration);
            };

            var config = new MapperConfiguration(configurer);
            Container.Register(
                Component.For<IConfigurationProvider>().Instance(config).LifestyleSingleton()
            );

            var mapper = config.CreateMapper();
            Container.Register(
                Component.For<IMapper>().Instance(mapper).LifestyleSingleton()
            );
        }

        private void FindAndAutoMapTypes(IMapperConfigurationExpression configuration)
        {
            var types = _typeFinder.Find(type =>
            {
                var typeInfo = type.GetTypeInfo();
                return typeInfo.IsDefined(typeof(AutoMapAttribute)) ||
                       typeInfo.IsDefined(typeof(AutoMapFromAttribute)) ||
                       typeInfo.IsDefined(typeof(AutoMapToAttribute));
            }
            );

            Logger.Debug($"Found {types.Length} classes define auto mapping attributes");

            foreach (var type in types)
            {
                Logger.Debug(type.FullName);
                configuration.CreateAutoAttributeMaps(type);
            }
        }
    }
}
