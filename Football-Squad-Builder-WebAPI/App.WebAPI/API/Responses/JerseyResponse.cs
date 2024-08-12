using App.WebAPI.API.DTO;

namespace App.WebAPI.API.Responses
{
    public class JerseyResponse
    {
        public string Id { get; set; }

        public List<JerseyNumberDTO> JerseyNumbers { get; set; }

    }
}
