using Report.API.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.API.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly PostgreSqlReportDbContext reportDbContext;

        public Repository(PostgreSqlReportDbContext reportContext)
        {
            reportDbContext = reportContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return reportDbContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await reportDbContext.AddAsync(entity);
                await reportDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                reportDbContext.Update(entity);
                await reportDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated {ex.Message}");
            }
        }

        public async Task UpdateRangeAsync(List<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateRangeAsync)} entities must not be null");
            }

            try
            {
                reportDbContext.UpdateRange(entities);
                await reportDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entities)} could not be updated {ex.Message}");
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            try
            {
                reportDbContext.Remove(entity);
                await reportDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be deleted {ex.Message}");
            }
        }
    }
}