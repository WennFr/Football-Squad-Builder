using App.WebAPI.DTO;
using App.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballDataController : ControllerBase
    {
        private readonly ITransfermarktAPIService _transfermarktAPIService;

        public FootballDataController(ITransfermarktAPIService transfermarktAPIService)
        {
            _transfermarktAPIService = transfermarktAPIService;
        }

        [HttpGet]
        [Route("Competitions")]
        public async Task<ActionResult<List<CompetitionDTO>>> GetCompetitions()
        {

            var competitionNamesList = new List<string>()
            {
                "Allsvenskan",
                "Superettan",
                "La Liga",
                "Serie A",
                "Elitserien",
                "Superliga",
                "Bundesliga",
                "Premier League",
            };

            var competitions = new List<CompetitionDTO>();


            foreach (var competitionName in competitionNamesList)
            {

                var competitionDTO = await _transfermarktAPIService.GetCompetition(competitionName);

                if (competitionDTO != null)
                {
                    competitions.Add(competitionDTO);
                }

            }

            return Ok(competitions);

        }


    }
}
