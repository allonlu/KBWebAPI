using System;
using KB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KB.Infrastructure.EntityConfigurations
{
    public class ArticleTagEntityTypeConfiguration : IEntityTypeConfiguration<ArticleTag>
    {
        public void Configure(EntityTypeBuilder<ArticleTag> builder)
        {
            builder.ToTable("t_KB_ArticleTag");
            builder.HasKey(t => new { t.ArticleId, t.TagId });
            builder.HasIndex(t => new { t.ArticleId, t.TagId }).IsUnique();
        }
    }
}
