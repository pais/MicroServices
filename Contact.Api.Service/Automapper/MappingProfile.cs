using AutoMapper;
using Contact.API.Domain.Dto;
using Contact.API.Domain.Entities;

namespace Contact.Api.Service.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactDto, API.Domain.Entities.Contact>();
            CreateMap<API.Domain.Entities.Contact, ContactDto>();
            CreateMap<API.Domain.Entities.Contact, ContactDetailDto>();
            CreateMap<Detail, DetailDto>();
            CreateMap<DetailDto, Detail>();
        }
    }
}