
using Infrastructure.Models.TransfermarktAPI.DTOs;

namespace Infrastructure.Models.TransfermarktAPI.Responses
{
    public class JerseyResponse
    {
        public string Id { get; set; }

        public List<JerseyNumberDTO> JerseyNumbers { get; set; }

    }
}
