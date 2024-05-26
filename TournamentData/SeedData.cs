using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentCore.Entities;
using TournamentData.Data;

namespace TournamentData
{
    public class SeedData
    {

        public static async Task InitAsync(TournamentAPIContext context)
        {
            // Ensure the db is created and apply migrations
            await context.Database.MigrateAsync();

            if (await context.Tournament.AnyAsync()) return;

            Tournament[] tournaments = GenerateTournaments();
            await context.Tournament.AddRangeAsync(tournaments);

            await context.SaveChangesAsync();


        }

        private static Tournament[] GenerateTournaments()
        {
            return new Tournament[]
            {
                new Tournament()
                {
                    Id = 1,
                    Title = "First",
                    StartDate = DateTime.Now,
                    Games = new List<Game>

                    { new Game()
                        {
                            Id = 1,
                            Title = "T1GameOne",
                            Time = DateTime.Now,
                        },
                        new Game()
                        {
                            Id = 2,
                            Title = "T1GameTwo",
                            Time = DateTime.Now.AddMonths(1),
                        }
                    }
                },
                new Tournament()
                {
                    Id = 2,
                    Title = "Second",
                    StartDate = DateTime.Now.AddMonths(1),
                    Games = new List<Game>
                    {
                        new Game()
                        {
                            Id = 3,
                            Title = "T2GameOne",
                            Time = DateTime.Now.AddMonths(2),
                        }
                    }
                },
            };
        }
    }
}
