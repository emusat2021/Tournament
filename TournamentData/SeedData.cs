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
            if (await context.Tournament.AnyAsync()) return;

            Tournament[] tournaments = GenerateTournaments();
            await context.Tournament.AddRangeAsync(tournaments);

            Game[] games = GenerateGames();
            await context.Game.AddRangeAsync(games);

            await context.SaveChangesAsync();


        }

        private static Game[] GenerateGames()
        {
            return
            [
                new Game()
                {
                    Id = 1,
                    Title = "T1GameOne",
                    Time = DateTime.Now,
                    TournamentId = 1,
                },
                new Game()
                {
                    Id = 2,
                    Title = "T1GameTwo",
                    Time = DateTime.Now.AddMonths(1),
                    TournamentId = 1
                },
                new Game()
                {
                    Id = 3,
                    Title = "T2GameTwo",
                    Time = DateTime.Now.AddMonths(2),
                    TournamentId = 2
                },
            ];
        }

        private static Tournament[] GenerateTournaments()
        {
            return
            [
                new Tournament()
                {
                    Id = 1,
                    Title = "First",
                    StartDate = DateTime.Now,
                },
                new Tournament()
                {
                    Id = 2,
                    Title = "Second",
                    StartDate = DateTime.Now.AddMonths(1),
                },
            ];
        }
    }
}
