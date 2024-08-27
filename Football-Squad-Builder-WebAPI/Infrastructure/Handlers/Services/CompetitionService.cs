using Infrastructure.Enums;
using Infrastructure.ExtensionMethods;
using Infrastructure.Handlers.Repositories;
using Infrastructure.Handlers.Services.Interfaces;
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





    }
}
