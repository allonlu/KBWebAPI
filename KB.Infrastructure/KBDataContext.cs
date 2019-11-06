
using KB.Domain.Entities;
using KB.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;

namespace KB.Infrastructure
{
    public class KBDataContext : DbContext
    {
        private string _connectString { get; set; }

        private ITableIsolationResolver _resolver;

        public KBDataContext(IConfiguration configuration, ITableIsolationResolver resolver)
        {
            this._connectString = configuration.GetConnectionString("DefaultConnection");
            this._resolver = resolver;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connectString)
                .AddInterceptors(new TableIsolationCommandInterceptor(_resolver));
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleTag> ArticleTags { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleTagEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TagEntityTypeConfiguration());
        }
    }
}
