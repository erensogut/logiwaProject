using logiwa.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logiwa.Infrastructure.DataStore
{
    public class DataContext:DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                throw new NullReferenceException("Data store configuraiton is missing");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);

                //entity.Property(e => e.).HasMaxLength(160);

                //entity.Property(e => e.Cutout).HasDefaultValueSql("((0))");

                //entity.Property(e => e.ParentalCaution).HasDefaultValueSql("((0))");

                //entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                //entity.Property(e => e.Title)
                //    .IsRequired()
                //    .HasMaxLength(160);

                //entity.Property(e => e.Upc)
                //    .IsRequired()
                //    .HasColumnName("UPC")
                //    .HasColumnType("nchar(10)");

                //entity.HasOne(d => d.Artist)
                //    .WithMany(p => p.Albums)
                //    .HasForeignKey(d => d.ArtistId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Albums_Artists");

                //entity.HasOne(d => d.Genre)
                //    .WithMany(p => p.Albums)
                //    .HasForeignKey(d => d.GenreId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Albums_Genres");
            });

            modelBuilder.Entity<Category>(entity => { entity.HasKey(e => e.Id); });

        }
    
    }
}
