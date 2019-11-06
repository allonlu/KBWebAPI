using System;
using Comm100.Framework.Infrastructure;
using KB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KB.Infrastructure.EntityConfigurations
{
    public class ArticleTagEntityTypeConfiguration : CEntityTypeConfiguration<ArticleTag>
    {
        public override void Configure(EntityTypeBuilder<ArticleTag> config)
        {
            config.ToTable("t_KB_ArticleTag");
            config.HasKey(t => new { t.ArticleId, t.TagId });
            config.HasIndex(t => new { t.ArticleId, t.TagId }).IsUnique();

            base.Configure(config);
        }
    }
}
