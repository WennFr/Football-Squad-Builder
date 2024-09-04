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
    public class ClubService : IClubService
    {
        private readonly CompetitionRepository _competitionRepository;
        private readonly ClubRepository _clubRepository;
        private readonly ITransfermarktAPIService _transfermarktAPIService;

        public ClubService(CompetitionRepository competitionRepository, ClubRepository clubRepository, ITransfermarktAPIService transfermarktAPIService)
        {
            _competitionRepository = competitionRepository;
            _clubRepository = clubRepository;
            _transfermarktAPIService = transfermarktAPIService;
        }


        public async Task<Dictionary<string, ClubDTO[]>> GetClubsWithCompetitionIdFromTransfermarktAPI()
        {
            var competitions = await _competitionRepository.GetAllAsync(x => true);

            var clubsWithCompetitionId = new Dictionary<string, ClubDTO[]>();

            foreach (var competition in competitions)
            {
                var clubs = await _transfermarktAPIService.GetAllCompetitionClubs(competition.Id);
                clubsWithCompetitionId.Add(competition.Id, clubs!);
            }

            return clubsWithCompetitionId;

        }


        public async Task<StatusMessage> CreateClub(string competitionId, ClubDTO clubDTO)
        {

            var clubEntity = ClubExtension.ConvertClubDTOToClubEntity(clubDTO);
            clubEntity.CompetitionId = competitionId;

            var status = await _clubRepository.CreateAsync(clubEntity);

            return status;

        }

        public async Task<bool> CheckIfClubTableContainsAnyRecords()
        {
            var records = await _clubRepository.GetAllAsync(x => true);

            if (records.Any())
            {
                return true;
            }

            return false;

        }




    }
}
