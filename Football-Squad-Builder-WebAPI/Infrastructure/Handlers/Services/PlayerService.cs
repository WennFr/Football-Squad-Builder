using Infrastructure.Enums;
using Infrastructure.ExtensionMethods;
using Infrastructure.Handlers.Repositories;
using Infrastructure.Handlers.Services.Interfaces;
using Infrastructure.Models.Entities;
using Infrastructure.Models.TransfermarktAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly ClubRepository _clubRepository;
        private readonly PlayerRepository _playerRepository;
        private readonly ITransfermarktAPIService _transfermarktAPIService;

        public PlayerService(ClubRepository clubRepository, PlayerRepository playerRepository, ITransfermarktAPIService transfermarktAPIService)
        {
            _clubRepository = clubRepository;
            _playerRepository = playerRepository;
            _transfermarktAPIService = transfermarktAPIService;
        }



        public async Task<Dictionary<string, PlayerDTO[]>> GetPlayersWithClubIdFromTransfermarktAPI()
        {
            var clubs = await _clubRepository.GetAllAsync(x => true);
            var playersWithClubId = new Dictionary<string, PlayerDTO[]>();
            var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };

            foreach (var club in clubs)
            {
                var players = await _transfermarktAPIService.GetAllClubPlayers(club.Id);

                var playerTasks = players.Select(async player =>
                {
                    var profileTask = _transfermarktAPIService.GetPlayerProfile(player.Id, httpClient);
                    var statsTask = _transfermarktAPIService.GetPlayerStats(player.Id, httpClient);

                    await Task.WhenAll(profileTask, statsTask);

                    var playerProfile = await profileTask;
                    var playerStats = await statsTask;


                    var playerStatsCurrentSeason = playerStats?.FirstOrDefault();

                    // Update player details
                    player.JerseyNumber = playerProfile.ShirtNumber ?? "0";
                    player.ImageURL = playerProfile.ImageURL;
                    player.GoalsThisSeason = playerStatsCurrentSeason?.Goals ?? "0";
                    player.AssistsThisSeason = playerStatsCurrentSeason?.Assists ?? "0";



                    return player;
                }).ToList();

                // Wait for all player tasks to complete
                var updatedPlayers = await Task.WhenAll(playerTasks);


                await CreatePlayers(club.Id, updatedPlayers);

                playersWithClubId.Add(club.Id, updatedPlayers);

            }

            return playersWithClubId;

        }

        public async Task<StatusMessage> CreatePlayer(string clubId, PlayerDTO playerDTO)
        {

            var playerEntity = PlayerExtension.ConvertPlayerDTOToPlayerEntity(playerDTO);
            playerEntity.ClubId = clubId;

            var status = await _playerRepository.CreateAsync(playerEntity);

            return status;

        }


        public async Task<StatusMessage> CreatePlayers(string clubId, PlayerDTO[] playersDTO)
        {
            var playerEntities = new List<PlayerEntity>();

            foreach (var playerDTO in playersDTO)
            {
                var playerEntity = PlayerExtension.ConvertPlayerDTOToPlayerEntity(playerDTO);
                playerEntity.ClubId = clubId;
                playerEntities.Add(playerEntity);
            }

            var status = await _playerRepository.CreateBatchAsync(playerEntities);

            return status;

        }


        public async Task<bool> CheckIfPlayerTableContainsAnyRecords()
        {
            var records = await _playerRepository.GetAllAsync(x => true);

            if (records.Any())
            {
                return true;
            }

            return false;

        }



    }
}
