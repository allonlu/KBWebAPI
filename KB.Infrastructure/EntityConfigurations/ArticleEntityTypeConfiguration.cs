using System;
using KB.Domain.Articles.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KB.Infrastructure.EntityConfigurations
{
    class ArticleEntityTypeConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> articleConfiguration)
        {
            articleConfiguration.ToTable("t_KB_Article");

            articleConfiguration.HasKey(a => a.Id);
        }
    }
}
