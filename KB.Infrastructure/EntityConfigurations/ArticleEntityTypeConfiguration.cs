using System;
using KB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KB.Infrastructure.EntityConfigurations
{
    class ArticleEntityTypeConfiguration : IEntityTypeConfiguration<Article>
    {
        private int _tenantId;
        public ArticleEntityTypeConfiguration(int tenantId)
        {
            this._tenantId = tenantId;
        }

        public void Configure(EntityTypeBuilder<Article> articleConfiguration)
        {
            articleConfiguration.ToTable("t_KB_Article");

            articleConfiguration.HasKey(a => a.Id);
        }
    }
}
