using Infrastructure.Enums;
using Infrastructure.ExtensionMethods;
using Infrastructure.Handlers.Repositories;
using Infrastructure.Handlers.Services.Interfaces;
using Infrastructure.Models.Entities;
using Infrastructure.Models.TransfermarktAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.Services
{
    public class CompetitionService : ICompetitionService
    {
        private readonly CompetitionRepository _competitionRepository;
        private readonly ITransfermarktAPIService _transfermarktAPIService;

        public CompetitionService(CompetitionRepository competitionRepository, ITransfermarktAPIService transfermarktAPIService)
        {
            _competitionRepository = competitionRepository;
            _transfermarktAPIService = transfermarktAPIService;
        }


        public async Task<IEnumerable<CompetitionDTO>> GetCompetitionsFromTransfermarktAPI()
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

            var competitions = competitionDTOs.Where(dto => dto != null);

            return competitions!;

        }


        public async Task<StatusMessage> CreateCompetition(CompetitionDTO competition)
        {

            var status = await _competitionRepository.CreateAsync(CompetitionExtension.ConvertCompetitionDTOToCompetitionEntity(competition));

            return status;

        }


        public async Task<List<CompetitionEntity>> GetAllCompetitions()
        {
            var competitions = await _competitionRepository.GetAllAsync(x => true);

            return competitions.ToList();
        }



        public async Task<bool> CheckIfCompetitionTableContainsAnyRecords()
        {
            var records = await _competitionRepository.GetAllAsync(x => true);

            if (records.Any())
            {
                return true;
            }

            return false;

        }



    }
}
