using App.WebAPI.API.DTO;

namespace App.WebAPI.API.Responses
{
    public class PlayersResponse
    {
        public string Id { get; set; } = null!;
        public PlayerDTO[]? Players { get; set; }


    }
}
