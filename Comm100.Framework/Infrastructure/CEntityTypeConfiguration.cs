using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Comm100.Framework.Domain.Entity;

namespace Comm100.Framework.Infrastructure
{
    public abstract class CEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
    {

        public virtual void Configure(EntityTypeBuilder<TEntity> config)
        {
            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity))) {
                config.HasQueryFilter(t => !((ISoftDelete)t).IsDeleted);
            }
        }
    }
}
