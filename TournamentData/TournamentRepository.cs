using TournamentCore.Entities;
using TournamentCore.Repositories;

namespace TournamentData
{
    public class TournamentRepository : ITournamentRepository
    {
        void ITournamentRepository.Add(Tournament tournament)
        {
            throw new NotImplementedException();
        }

        Task<bool> ITournamentRepository.AnyAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Tournament>> ITournamentRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Tournament> ITournamentRepository.GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        void ITournamentRepository.Remove(Tournament tournament)
        {
            throw new NotImplementedException();
        }

        void ITournamentRepository.Update(Tournament tournament)
        {
            throw new NotImplementedException();
        }
    }
}
