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
        }
    }
}
