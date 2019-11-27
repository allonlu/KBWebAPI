namespace Comm100.Framework.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Comm100.Framework.Domain.Entity;

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
