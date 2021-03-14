using AutoMapper;
using Contact.Api.Service.Interfaces;
using Contact.API.Data.Repository.Interfaces;
using Contact.API.Domain.Dto;
using Contact.API.Domain.Entities;
using Domain.Dto;
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
        private readonly IReportHttpService _reportHttpService;
        public ContactService(IContactRepository contactRepository, IDetailRepository detailRepository, IMapper mapper, IReportHttpService reportHttpService)
        {
            _contactRepository = contactRepository;
            _detailRepository = detailRepository;
            _mapper = mapper;
            _reportHttpService = reportHttpService;
        }

        public Task<API.Domain.Entities.Contact> AddContact(ContactDto contact)
        {
            return _contactRepository.AddAsync(_mapper.Map<API.Domain.Entities.Contact>(contact));
        }

        public async Task<Detail> AddDetail(DetailDto detail, Guid contactId)
        {
            Detail detailEntity = _mapper.Map<Detail>(detail);
            detailEntity.ContactId = contactId;

            var addResult = await _detailRepository.AddAsync(detailEntity);

            await _reportHttpService.AddDetail(new DetailNotificationDto
            {
                ContactId = contactId,
                DetailId = addResult.Id,
                Location = detail.Location
            });

            return addResult;
        }

        public Task DeleteContact(Guid contactId)
        {
            var contact = _contactRepository.GetContactByRefAsync(contactId);

            return _contactRepository.DeleteAsync(contact.Result);
        }

        public Task DeleteDetail(Guid detailId)
        {
            var detail = _detailRepository.GetDetailByRefAsync(detailId);

            var result = _detailRepository.DeleteAsync(detail.Result);

            if (result.Status == TaskStatus.RanToCompletion)
                _reportHttpService.DeleteDetail(detailId);

            return result;
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
