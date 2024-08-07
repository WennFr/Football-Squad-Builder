using App.WebAPI.API.DTO;

namespace App.WebAPI.Services
{
    public interface ITransfermarktAPIService
    {
        Task<CompetitionDTO?> GetCompetition(string competitionName);

        Task<ClubDTO[]?> GetCompetitionClubs(string competitionId);

    }
}
