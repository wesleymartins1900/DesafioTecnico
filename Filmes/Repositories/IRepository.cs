using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T[]> AllAsync();

        Task<T[]> SelectByIdAsync(params int[] id);

        Task SaveAsync(params T[] entities);

        Task DeleteAsync(params T[] entities);

        Task AlterAsync(params T[] entities);
    }
}