using Infrastructure.Contexts;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.Repositories
{
    public class CompetitionRepository : Repository<CompetitionEntity, TransfermarktDataContext>
    {
        public CompetitionRepository(TransfermarktDataContext context) : base(context)
        {
        }
    }
}
