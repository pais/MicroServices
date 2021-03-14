using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.API.Data.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> GetAll();

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task UpdateRangeAsync(List<TEntity> entities);

        Task DeleteAsync(TEntity entity);
    }
}