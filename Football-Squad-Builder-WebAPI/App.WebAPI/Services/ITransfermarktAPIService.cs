using App.WebAPI.API.DTO;

namespace App.WebAPI.Services
{
    public interface ITransfermarktAPIService
    {
        Task<CompetitionDTO?> GetCompetition(string competitionName);

        Task<ClubDTO[]?> GetAllCompetitionClubs(string competitionId);

        Task<PlayerDTO[]?> GetAllClubPlayers(string clubId);

        Task<List<JerseyNumberDTO>> GetPlayerJerseyNumbers(string playerId);

    }
}
