using Comm100.Framework.Infrastructure;
using Comm100.Framework.Tenants;
using KB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KB.Infrastructure
{
    public class KBDataContext : BaseDBContext
    {

        public KBDataContext(IConfiguration configuration, ITenantProvider provider)
            : base(configuration, provider)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleTag> ArticleTags { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
