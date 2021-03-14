using AutoMapper;
using Contact.Api.Service.Interfaces;
using Contact.API.Data.Repository;
using Contact.API.Data.Repository.Interfaces;
using Contact.API.Domain.Dto;
using Contact.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Api.Service.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IDetailRepository _detailRepository;
        private readonly IMapper _mapper;
        public ContactService(IContactRepository contactRepository, IDetailRepository detailRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _detailRepository = detailRepository;
            _mapper = mapper;
        }

        public Task<API.Domain.Entities.Contact> AddContact(ContactDto contact)
        {
            return _contactRepository.AddAsync(_mapper.Map<API.Domain.Entities.Contact>(contact));
        }

        public Task<Detail> AddDetail(DetailDto detail, Guid contactId)
        {
            Detail detailEntity = _mapper.Map<Detail>(detail);
            detailEntity.ContactId = contactId;

            return _detailRepository.AddAsync(detailEntity);
        }

        public Task DeleteContact(Guid contactId)
        {
            var contact = _contactRepository.GetContactByRefAsync(contactId);

            return _contactRepository.DeleteAsync(contact.Result);
        }

        public Task DeleteDetail(Guid detailId)
        {
            var detail = _detailRepository.GetDetailByRefAsync(detailId);

            return _detailRepository.DeleteAsync(detail.Result);
        }

        public Task<List<ContactDto>> GetAllContacts()
        {
            List<ContactDto> contactDtos = _mapper.Map<List<ContactDto>>(_contactRepository.GetAllActiveContacts().Result);
            return Task.FromResult(contactDtos);
        }

        public Task<ContactDetailDto> GetContactDetail(Guid contactId)
        {
            return Task.FromResult(_mapper.Map<ContactDetailDto>(_contactRepository.GetContactByRefAsync(contactId).Result));
        }
    }
}
