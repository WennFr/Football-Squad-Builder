using App.WebAPI.DTO;
using App.WebAPI.Services;
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
                "Eliteserien",
                "Superliga",
                "Bundesliga",
                "Premier League",
            };


            var tasks = competitionNamesList.Select(competitionName =>
                          _transfermarktAPIService.GetCompetition(competitionName));

            var competitionDTOs = await Task.WhenAll(tasks);

            var competitions = competitionDTOs.Where(dto => dto != null).ToList();

            return Ok(competitions);

        }


    }
}
