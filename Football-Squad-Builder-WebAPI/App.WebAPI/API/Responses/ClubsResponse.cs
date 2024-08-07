using App.WebAPI.API.DTO;

namespace App.WebAPI.API.Responses
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
