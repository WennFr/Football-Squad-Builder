using Infrastructure.Enums;
using Infrastructure.Models.TransfermarktAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.Services.Interfaces
{
    public interface IClubService
    {
        Task<Dictionary<string, ClubDTO[]>> GetClubsWithCompetitionIdFromTransfermarktAPI();

        Task<StatusMessage> CreateClub(string competitionId, ClubDTO clubDTO);

        Task<bool> CheckIfClubTableContainsAnyRecords();

    }
}
