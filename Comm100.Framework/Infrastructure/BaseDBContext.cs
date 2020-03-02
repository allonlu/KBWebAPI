//-----------------------------------------------------------------------
// <copyright file="BaseDBContext.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Infrastructure
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using Comm100.Framework.Domain.Entity;
    using Comm100.Framework.Tenancy;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
    using Microsoft.Extensions.Configuration;

    public class BaseDBContext : DbContext
    {
        private string _connectString { get; set; }

        private IConfiguration _configuration;

        public Tenant Tenant { get; private set; }

        public BaseDBContext(IConfiguration configuration, ITenancyResolver resolver)
        {
            this._connectString = configuration.GetConnectionString("DefaultConnection");

            //this._config = configuration;

            this.Tenant = resolver.GetTenant();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connectString)
                .AddInterceptors(new TenancyTableSeparateCommandInterceptor(Tenant));

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                ConfigureGlobalFiltersMethodInfo
                    .MakeGenericMethod(entityType.ClrType)
                    .Invoke(this, new object[] { modelBuilder, entityType });

                foreach(var property in entityType.GetProperties())
                {
                    if (property.ClrType.IsEnum)
                    {
                        var attrs = property.PropertyInfo.GetCustomAttribute(typeof(EnumToStringAttribute));
                        if (attrs != null)
                        {
                            ApplyEnumToStringMethodInfo
                                .MakeGenericMethod(entityType.ClrType, property.ClrType)
                                .Invoke(this, new object[] { modelBuilder, property });
                        }
                    }
                }
            }
        }

        private static MethodInfo ConfigureGlobalFiltersMethodInfo = typeof(BaseDBContext).GetMethod(nameof(ConfigGlobalFilters), BindingFlags.Instance | BindingFlags.NonPublic);

        private static MethodInfo ApplyEnumToStringMethodInfo = typeof(BaseDBContext).GetMethod(nameof(ApplyEnumToStringConversion), BindingFlags.Instance | BindingFlags.NonPublic);

        private void ConfigGlobalFilters<TEntity>(ModelBuilder modelBuilder, IMutableEntityType entityType)
            where TEntity : class
        {
            if (entityType.BaseType == null && typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                modelBuilder.Entity<TEntity>().HasQueryFilter(CreateSoftDeleteFilterExpression<TEntity>());
            }
        }

        private void ApplyEnumToStringConversion<TEntity, TEnum>(ModelBuilder modelBuilder, IMutableProperty property)
            where TEntity : class
            where TEnum : struct
        {
            modelBuilder.Entity<TEntity>().Property(property.Name)
                .HasConversion(new EnumToStringConverter<TEnum>());
        }

        private Expression<Func<TEntity, bool>> CreateSoftDeleteFilterExpression<TEntity>()
            where TEntity : class
        {
            return e => !((ISoftDelete)e).IsDeleted;
        }
    }
}
