using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class ClubEntity
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string CompetitionId { get; set; } = null!;
        public CompetitionEntity Competition { get; set; } = null!;
        public ICollection<PlayerEntity> Players { get; set; } = null!;

    }
}
