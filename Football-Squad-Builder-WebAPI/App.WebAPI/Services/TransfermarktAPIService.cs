using App.WebAPI.API.DTO;
using App.WebAPI.API.Responses;
using Newtonsoft.Json;

namespace App.WebAPI.Services
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

        public async Task<ClubDTO[]?> GetCompetitionClubs(string competitionId)
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

            return responseObj.Clubs;
        }

    }
}
