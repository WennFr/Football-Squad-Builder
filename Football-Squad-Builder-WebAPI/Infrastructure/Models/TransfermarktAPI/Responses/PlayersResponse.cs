
using Infrastructure.Models.TransfermarktAPI.DTOs;

namespace Infrastructure.Models.TransfermarktAPI.Responses
{
    public class PlayersResponse
    {
        public string Id { get; set; } = null!;
        public PlayerDTO[]? Players { get; set; }


    }
}
