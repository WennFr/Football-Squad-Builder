using Infrastructure.Models.TransfermarktAPI.DTOs;

namespace Infrastructure.Models.TransfermarktAPI.Responses
{
    public class ClubsResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SeasonId { get; set; }
        public ClubDTO[] Clubs { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
