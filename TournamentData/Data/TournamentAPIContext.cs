using Microsoft.EntityFrameworkCore;

namespace TournamentData.Data
{
    public class TournamentAPIContext : DbContext
    {
        public TournamentAPIContext (DbContextOptions<TournamentAPIContext> options)
            : base(options)
        {
        }

        public DbSet<TournamentCore.Entities.Tournament> Tournament { get; set; } = default!;
        public DbSet<TournamentCore.Entities.Game> Game { get; set; } = default!;
    }
}
