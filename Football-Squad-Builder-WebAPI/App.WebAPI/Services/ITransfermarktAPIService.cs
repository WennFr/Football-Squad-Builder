using App.WebAPI.DTO;

namespace App.WebAPI.Services
{
    public interface ITransfermarktAPIService
    {
        Task<CompetitionDTO?> GetCompetition(string competitionName);

    }
}
