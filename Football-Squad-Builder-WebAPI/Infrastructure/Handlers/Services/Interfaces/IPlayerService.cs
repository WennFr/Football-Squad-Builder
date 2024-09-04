using Infrastructure.Enums;
using Infrastructure.Models.TransfermarktAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<Dictionary<string, PlayerDTO[]>> GetPlayersWithClubIdFromTransfermarktAPI();

        Task<StatusMessage> CreatePlayer(string clubId, PlayerDTO playerDTO);

        Task<StatusMessage> CreatePlayers(string clubId, PlayerDTO[] playersDTO);

        Task<bool> CheckIfPlayerTableContainsAnyRecords();

    }
}
