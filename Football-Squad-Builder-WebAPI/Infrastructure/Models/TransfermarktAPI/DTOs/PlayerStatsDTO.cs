using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.TransfermarktAPI.DTOs
{
    public class PlayerStatsDTO
    {
        public string? CompetitionId { get; set; }

        public string? ClubId { get; set; }

        public string? SeasonId { get; set; }

        public string? Appearances { get; set; }

        public string? Goals { get; set; }

        public string? Assists { get; set; }

        public string? YellowCards { get; set; }

        public string? MinutesPlayed { get; set; }

    }
}
