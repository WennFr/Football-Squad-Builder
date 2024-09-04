using Infrastructure.Models.TransfermarktAPI.DTOs;

namespace Infrastructure.Handlers.Services.Interfaces
{
    public interface ITransfermarktAPIService
    {
        Task<CompetitionDTO?> GetCompetition(string competitionName);

        Task<ClubDTO[]?> GetAllCompetitionClubs(string competitionId);

        Task<PlayerDTO[]?> GetAllClubPlayers(string clubId);

        Task<List<JerseyNumberDTO>> GetPlayerJerseyNumbers(string playerId);

        Task<PlayerProfileDTO> GetPlayerProfile(string playerId, HttpClient client);

        Task<List<PlayerStatsDTO>> GetPlayerStats(string playerId, HttpClient client);

    }
}
