using AutoMapper;
using Report.API.Data.Repository.Interfaces;
using Report.API.Domain.Dto;
using Report.API.Domain.Entities;
using Report.API.Domain.EventHandlers;
using Report.API.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Report.API.Service.Services
{
    public class CalculationService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IVoteRepository _voteRepository;
        private readonly IMapper _mapper;

        public CalculationService(ICandidateRepository candidateRepository, IVoteRepository voteRepository)
        {
            _candidateRepository = candidateRepository;
            _voteRepository = voteRepository;
        }


    }
}