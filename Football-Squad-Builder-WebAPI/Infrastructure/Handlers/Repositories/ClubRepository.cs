using Infrastructure.Contexts;
using Infrastructure.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.Repositories
{
    public class ClubRepository : Repository<ClubEntity, TransfermarktDataContext>
    {
        public ClubRepository(TransfermarktDataContext context) : base(context)
        {
        }
    }
}
