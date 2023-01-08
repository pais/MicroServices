using AutoMapper;
using Report.API.Domain.Dto;
using Report.API.Domain.Entities;

namespace Report.Api.Service.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VoteDto, Vote>();
        }
    }
}