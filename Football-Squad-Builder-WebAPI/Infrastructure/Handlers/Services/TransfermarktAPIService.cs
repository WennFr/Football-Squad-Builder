using Infrastructure.Handlers.Services.Interfaces;
using Infrastructure.Models.TransfermarktAPI.DTOs;
using Infrastructure.Models.TransfermarktAPI.Responses;
using Newtonsoft.Json;

namespace Infrastructure.Handlers.Services
{
    public class TransfermarktAPIService : ITransfermarktAPIService
    {

        public async Task<CompetitionDTO?> GetCompetition(string competitionName)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://transfermarkt-api.fly.dev/competitions/search/{competitionName}")
            };

            ApiResponse<CompetitionDTO>? responseObj = null;

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                responseObj = JsonConvert.DeserializeObject<ApiResponse<CompetitionDTO>>(body);

            }

            return responseObj?.Results.FirstOrDefault();


        }

        public async Task<ClubDTO[]?> GetAllCompetitionClubs(string competitionId)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://transfermarkt-api.fly.dev/competitions/{competitionId}/clubs")
            };

            ClubsResponse? responseObj = null;

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                responseObj = JsonConvert.DeserializeObject<ClubsResponse>(body);

            }

            return responseObj?.Clubs;
        }

        public async Task<PlayerDTO[]?> GetAllClubPlayers(string clubId)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://transfermarkt-api.fly.dev/clubs/{clubId}/players")
            };

            PlayersResponse? responseObj = null;

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                responseObj = JsonConvert.DeserializeObject<PlayersResponse>(body);

            }

            return responseObj?.Players;
        }

        public async Task<List<JerseyNumberDTO>> GetPlayerJerseyNumbers(string playerId)
        {

            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://transfermarkt-api.fly.dev/players/{playerId}/jersey_numbers")
            };

            JerseyResponse? responseObj = null;

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                responseObj = JsonConvert.DeserializeObject<JerseyResponse>(body);

            }

            return responseObj?.JerseyNumbers;

        }

        public async Task<PlayerProfileDTO> GetPlayerProfile(string playerId)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://transfermarkt-api.fly.dev/players/{playerId}/profile")
            };

            PlayerProfileDTO responseObj = null;

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                responseObj = JsonConvert.DeserializeObject<PlayerProfileDTO>(body);

            }

            return responseObj;


        }



    }
}
