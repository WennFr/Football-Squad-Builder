using Infrastructure.Models.TransfermarktAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.TransfermarktAPI.Responses
{
    public class PlayerStatsResponse
    {
        public string? Id { get; set; }
        public List<PlayerStatsDTO> Stats { get; set; } = null!;


    }
}
