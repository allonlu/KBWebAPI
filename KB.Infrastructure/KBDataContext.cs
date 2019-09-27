
using KB.Domain.Articles.Entity;
using KB.Domain.Categories.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace KB.Infrastructure
{
    public class KBDataContext : DbContext
    {
        public string connectString { get; set; }
        public KBDataContext(IConfiguration configuration)
        {
            this.connectString = configuration.GetConnectionString("DefaultConnection");
            //this.configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectString);
            //.UseSqlServer(connectString);
        }

        public virtual DbSet<ArticleWithInclude> Articles { get; set; }
        public virtual DbSet<ArticleTag> ArticleTags { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleWithInclude>(
                entity =>
                {
                    entity.ToTable("t_KB_Article").HasKey(t => t.Id);
                    entity.HasMany(t => t.Tags).WithOne();
                    entity.HasOne(t => t.Author);
                    entity.HasOne(t => t.Category);
                }
            );
                

            modelBuilder.Entity<ArticleTag>(
                   entity =>
                   {
                       entity.ToTable("t_KB_ArticleTag")
                           .HasKey(t => new { t.ArticleId, t.Tag });
                       entity.HasIndex(t => new { t.ArticleId, t.Tag }).IsUnique();

                   }
               );
            modelBuilder.Entity<Category>(
                entity =>
                {
                    entity.ToTable("t_KB_Category")
                            .HasKey(t => t.Id);

                }
            );
        }
    }
}
