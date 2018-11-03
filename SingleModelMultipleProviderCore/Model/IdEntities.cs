using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Model
{
    public partial class IdEntities : DbContext
    {
        public IdEntities()
        {
        }

        public IdEntities(DbContextOptions<IdEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<Id> Id { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Database=.\\DATA\\DB.MDF");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Id>(entity =>
            {
                entity.HasKey(e => e.Id1);

                entity.Property(e => e.Id1).HasColumnName("Id");
            });
        }
    }
}
