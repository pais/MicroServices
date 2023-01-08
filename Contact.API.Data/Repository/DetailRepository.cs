using Contact.API.Data.Repository.Interfaces;
using Contact.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Contact.API.Data.Repository
{
    public class DetailRepository : Repository<Detail>, IDetailRepository
    {
        public DetailRepository(PostgreSqlContactDbContext contactDbContext) : base(contactDbContext)
        {
        }

        public async Task<Detail> GetDetailByRefAsync(Guid detailRef)
        {
            return await contactDbContext.Detail.FirstAsync(x => x.IsActive && x.Id == detailRef);
        }
    }
}