using Contact.API.Domain.Dto;
using Contact.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Api.Service.Interfaces
{
    public interface IContactService
    {
        Task<API.Domain.Entities.Contact> AddContact(ContactDto contact);
        Task DeleteContact(Guid contactId);
        Task<ContactDetailDto> GetContactDetail(Guid contactId);
        Task<List<ContactDto>> GetAllContacts();
        Task<Detail> AddDetail(DetailDto detail, Guid contactId);
        Task DeleteDetail(Guid detailId);
    }
}
