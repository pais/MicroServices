﻿using AutoMapper;
using Report.API.Data.Repository.Interfaces;
using Report.API.Domain.Dto;
using Report.API.Domain.Entities;
using Report.API.Domain.EventHandlers;
using Report.API.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Report.API.Service.Services
{
    public class ElectionService : IElectionService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IVoteRepository _voteRepository;
        private readonly IMapper _mapper;

        public ElectionService(ICandidateRepository candidateRepository, IVoteRepository voteRepository)
        {
            _candidateRepository = candidateRepository;
            _voteRepository = voteRepository;

        }

        public Task AddVote(VoteDto vote)
        {
            _candidateRepository.GetByRefAsync(vote.CandidateRef);

            var addResult = _voteRepository.AddAsync(_mapper.Map<Vote>(vote));

            //if (addResult.Status == TaskStatus.RanToCompletion )

            return addResult;
        }

        public Task<ElectionReportDto> GetCurrentResult()
        {
            throw new NotImplementedException();
        }
    }
}