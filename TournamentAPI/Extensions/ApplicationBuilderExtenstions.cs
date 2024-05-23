using Microsoft.OpenApi.Writers;
using System.Data;
using System.Linq.Expressions;
using TournamentData.Data;
using TournamentCore;
using TournamentAPI;
using TournamentData;


namespace TournamentAPI.Extensions
{
    public static class ApplicationBuilderExtenstions
    {
        public static async Task SeedDataAsync(this IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<TournamentAPIContext>();

                try
                {
                    await SeedData.InitAsync(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
    }
}

