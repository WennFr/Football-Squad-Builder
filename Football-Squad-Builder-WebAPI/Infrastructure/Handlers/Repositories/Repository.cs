using Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.Repositories
{
    public class Repository<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        private readonly TContext _context;

        public Repository(TContext context)
        {
                _context = context;
        }

        public async Task<StatusMessage> CreateAsync(TEntity entity) 
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusMessage.Error;
            }

            return StatusMessage.Success;
        }



        public async Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entity = _context.Set<TEntity>().Where(expression);

                return entity;

            }
            catch (Exception)
            {
                return null!;
            }

        }





    }
}
