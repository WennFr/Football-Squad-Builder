using Infrastructure.Handlers.Services.Interfaces;
using Infrastructure.Models.Entities;
using Infrastructure.Models.TransfermarktAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace App.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballDataController : ControllerBase
    {
        private readonly ICompetitionService _competitionService;
        private readonly IClubService _clubService;
        private readonly IPlayerService _playerService;


        public FootballDataController(ICompetitionService competitionService, IClubService clubService, IPlayerService playerService)
        {
            _competitionService = competitionService;
            _clubService = clubService;
            _playerService = playerService;
        }


        [HttpGet]
        [Route("Competitions")]
        public async Task<ActionResult<List<CompetitionEntity>>> GetCompetitions()
        {
            var competitions = await _competitionService.GetAllCompetitions();

            if (competitions is null)
            {
                return NotFound();
            }

            return Ok(competitions);
        }

        [HttpGet]
        [Route("Clubs/{competitionId}")]
        public async Task<ActionResult<List<ClubEntity>>> GetClubsByCompetitionId(string competitionId)
        {
            var clubs = await _clubService.GetClubsByCompetitionId(competitionId);

            if (clubs is null || clubs.Count() == 0)
            {
                return NotFound();
            }

            return Ok(clubs);
        }


        [HttpGet]
        [Route("Players/{clubId}")]
        public async Task<ActionResult<List<ClubEntity>>> GetPlayersByClubId(string clubId)
        {
            var players = await _playerService.GetPlayersByClubId(clubId);

            if (players is null || players.Count() == 0)
            {
                return NotFound();
            }

            return Ok(players);
        }


    }
}
