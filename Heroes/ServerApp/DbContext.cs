using Microsoft.EntityFrameworkCore;
using ServerApp.Models;

namespace ServerApp
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Universe> Universes { get; set; }
        public DbSet<Superhero> Superheroes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Universe>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Name).IsRequired();
                entity.HasMany(u => u.Superheroes);
            });

            modelBuilder.Entity<Superhero>(entity =>
            {
                entity.HasKey(h => h.Id);
                entity.Property(h => h.Name).IsRequired();
                entity.Property(h => h.Power).IsRequired();

                entity.HasOne(h => h.Universe)
                      .WithMany()
                      .HasForeignKey(h => h.UniverseId)
                      .IsRequired();
            });

            modelBuilder.Entity<Universe>().HasData(
                new Universe { Id = 1, Name = "DC" },
                new Universe { Id = 2, Name = "Marvel" });

            modelBuilder.Entity<Superhero>().HasData(
                new Superhero { Id = 1, Name = "Superman", Power = 100, UniverseId = 1 },
                new Superhero { Id = 2, Name = "Aquaman", Power = 75, UniverseId = 1 },
                new Superhero { Id = 3, Name = "Batman", Power = 40, UniverseId = 1 },
                new Superhero { Id = 4, Name = "Catwoman", Power = 35, UniverseId = 1 },
                new Superhero { Id = 5, Name = "Supergirl", Power = 60, UniverseId = 1 },
                new Superhero { Id = 6, Name = "Iron Man", Power = 85, UniverseId = 2 },
                new Superhero { Id = 7, Name = "Thor", Power = 100, UniverseId = 2 },
                new Superhero { Id = 8, Name = "Wolverine", Power = 50, UniverseId = 2 },
                new Superhero { Id = 9, Name = "Hulk", Power = 70, UniverseId = 2 }
            );
        }
    }
}
