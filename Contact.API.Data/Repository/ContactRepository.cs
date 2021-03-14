using Contact.API.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Contact.API.Data.Repository
{
    public class ContactRepository : Repository<Domain.Entities.Contact>, IContactRepository
    {
        public ContactRepository(PostgreSqlContactDbContext contactDbContext) : base(contactDbContext)
        {
        }

        public async Task<Domain.Entities.Contact> GetContactByRefAsync(Guid contactRef)
        {
            return await contactDbContext.Contact.Include(x => x.Details).FirstAsync(x => x.IsActive && x.Id == contactRef);
        }

        public async Task<List<Domain.Entities.Contact>> GetAllActiveContacts()
        {
            return await contactDbContext.Contact.Where(x => x.IsActive).ToListAsync();
        }


    }
}