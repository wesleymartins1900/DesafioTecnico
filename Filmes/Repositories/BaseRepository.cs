using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly WebApiContext _context;

        public BaseRepository(WebApiContext context)
        {
            _context = context;
        }

        public async Task<T[]> AllAsync() => await _context.Set<T>().ToArrayAsync();

        public async Task<T[]> SelectByIdAsync(params int[] ids) => await _context.FindAsync<T[]>(ids);

        public async Task SaveAsync(params T[] entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(params T[] entities)
        {
            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task AlterAsync(params T[] entities)
        {
            _context.Set<T>().UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}