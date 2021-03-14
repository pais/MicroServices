using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.API.Data.Repository.Interfaces
{
    public interface IContactRepository: IRepository<Domain.Entities.Contact>
    {
        Task<Domain.Entities.Contact> GetContactByRefAsync(Guid contactRef);
        Task<List<Domain.Entities.Contact>> GetAllActiveContacts();
    }
}