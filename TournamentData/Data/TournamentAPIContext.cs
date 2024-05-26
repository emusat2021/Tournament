using Microsoft.EntityFrameworkCore;
using TournamentCore.Entities;

namespace TournamentData.Data
{
    public class TournamentAPIContext : DbContext
    {

        public DbSet<TournamentCore.Entities.Tournament> Tournament { get; set; }
        public DbSet<TournamentCore.Entities.Game> Game { get; set; }
        public TournamentAPIContext(DbContextOptions<TournamentAPIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(e => e.StartDate)
                      .IsRequired();

                // Configure one-to-many relationship
                entity.HasMany(e => e.Games)
                      .WithOne(g => g.Tournament)
                      .HasForeignKey(g => g.TournamentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Game entity
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(e => e.Time)
                      .IsRequired();
            });
        }
    }
}
