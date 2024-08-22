using Infrastructure.Contexts;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.Repositories
{
    public class PlayerRepository : Repository<PlayerEntity, TransfermarktDataContext>
    {
        public PlayerRepository(TransfermarktDataContext context) : base(context)
        {
        }
    }
}
