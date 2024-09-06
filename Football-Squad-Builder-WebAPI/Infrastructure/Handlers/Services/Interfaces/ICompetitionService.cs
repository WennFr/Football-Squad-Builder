using Infrastructure.Enums;
using Infrastructure.Models.Entities;
using Infrastructure.Models.TransfermarktAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.Services.Interfaces
{
    public interface ICompetitionService
    {
        Task<IEnumerable<CompetitionDTO>> GetCompetitionsFromTransfermarktAPI();

        Task<StatusMessage> CreateCompetition(CompetitionDTO competition);

        Task<List<CompetitionEntity>> GetAllCompetitions();

        Task<bool> CheckIfCompetitionTableContainsAnyRecords();

    }
}
