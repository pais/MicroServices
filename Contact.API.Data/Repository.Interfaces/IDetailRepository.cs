using Contact.API.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Contact.API.Data.Repository.Interfaces
{
    public interface IDetailRepository : IRepository<Detail>
    {
        Task<Detail> GetDetailByRefAsync(Guid detailRef);
    }
}
