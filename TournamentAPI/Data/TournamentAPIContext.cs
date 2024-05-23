using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TournamentCore.Entities;

namespace TournamentAPI.Data
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
