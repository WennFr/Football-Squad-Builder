using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class PlayerEntity
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string Age { get; set; } = null!;
        public string Nationality { get; set; } = null!;
        public string? Height { get; set; }
        public string? Foot { get; set; }
        public string? Contract { get; set; }
        public string? MarketValue { get; set; }
        public string JerseyNumber { get; set; } = null!;
        public string? ImageURL { get; set; }
        public string GoalsThisSeason { get; set; } = null!;
        public string AssistsThisSeason { get; set; } = null!;
        public string ClubId { get; set; } = null!;
        public ClubEntity Club { get; set; } = null!;


    }
}
