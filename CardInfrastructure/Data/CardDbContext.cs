using Microsoft.EntityFrameworkCore;
using CardDomain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CardInfrastructure.Data
{
    public class CardDbContext : DbContext
    {
        public CardDbContext(DbContextOptions<CardDbContext> options) : base(options) { }

        public DbSet<Card> Card { get; set; }
        public DbSet<Photo> Photo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Card>()
                .HasOne(c => c.Photo)
                .WithMany()
                .HasForeignKey(c => c.PhotoId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }

}
