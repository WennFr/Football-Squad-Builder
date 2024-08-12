using App.WebAPI.API.DTO;
using App.WebAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
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


        [HttpGet]
        [Route("Clubs/{competitionId}")]
        public async Task<ActionResult<List<ClubDTO>>> GetClubsByCompetition(string competitionId)
        {

            var clubsDTOs = await _transfermarktAPIService.GetAllCompetitionClubs(competitionId);

            if (clubsDTOs == null || clubsDTOs.Count() == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(clubsDTOs);

            }

        }

        [HttpGet]
        [Route("Players/{clubId}")]
        public async Task<ActionResult<List<PlayerDTO>>> GetPlayersByClub(string clubId)
        {

            var playerDTOs = await _transfermarktAPIService.GetAllClubPlayers(clubId);


            if (playerDTOs == null || playerDTOs.Count() == 0)
            {
                return BadRequest();
            }


            var tasks = playerDTOs.Select(async player =>
            {
                var playerProfileDTO = await _transfermarktAPIService.GetPlayerProfile(player.Id);
                var jerseyNumbers = await _transfermarktAPIService.GetPlayerJerseyNumbers(player.Id);

                player.JerseyNumber = jerseyNumbers.FirstOrDefault()?.JerseyNumber;
                player.ImageURL = playerProfileDTO.ImageURL;

                return player;
            });

            var updatedPlayerDTOs = await Task.WhenAll(tasks);

            if (updatedPlayerDTOs == null)
            {
                return BadRequest();
            }

            return Ok(updatedPlayerDTOs);
        }



    }
}
