using System;
using Comm100.Framework.Infrastructure;
using KB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KB.Infrastructure.EntityConfigurations
{
    public class TagEntityTypeConfiguration : CEntityTypeConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> config)
        {
            config.ToTable("t_KB_Tag").HasKey(t => t.Name);

            base.Configure(config);
        }
    }
}
