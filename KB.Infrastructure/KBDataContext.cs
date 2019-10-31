
using KB.Domain.Entities;
using KB.Infrastructure.EntityConfigurations;
using KB.Infrastructure.Tenants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KB.Infrastructure
{
    public class KBDataContext : DbContext
    {
        private string _connectString { get; set; }

        private readonly Tenant _tenant;

        public KBDataContext(IConfiguration configuration, ITenantProvider tenantProvider)
        {
            this._connectString = configuration.GetConnectionString("DefaultConnection");
            this._tenant = tenantProvider.GetTenant();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectString);
            
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleTag> ArticleTags { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleEntityTypeConfiguration(this._tenant.Id));
            modelBuilder.ApplyConfiguration(new ArticleTagEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TagEntityTypeConfiguration());
        }
    }
}
