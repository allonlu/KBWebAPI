﻿using System;
using Comm100.Framework.Constants;
using Comm100.Framework.Infrastructure;
using KB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KB.Infrastructure.EntityConfigurations
{
    public class ArticleEntityTypeConfiguration : CEntityTypeConfiguration<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> config)
        {
            config.ToTable("t_KB_Article" + DBConstants.MULTI_TENANT_TABLE_PLACEHOLDER);

            config.HasKey(a => a.Id);

            base.Configure(config);
        }
    }
}
