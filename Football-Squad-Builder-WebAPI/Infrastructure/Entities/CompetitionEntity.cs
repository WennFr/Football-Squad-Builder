using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class CompetitionEntity
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public ICollection<ClubEntity> Clubs { get; set; } = null!;

    }
}
