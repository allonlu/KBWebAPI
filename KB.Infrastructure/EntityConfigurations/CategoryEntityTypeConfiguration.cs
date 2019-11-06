using System;
using Comm100.Framework.Infrastructure;
using KB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KB.Infrastructure.EntityConfigurations
{
    public class CategoryEntityTypeConfiguration : CEntityTypeConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> config)
        {
            config.ToTable("t_KB_Category").HasKey(c => c.Id);

            base.Configure(config);
        }
    }
}
