using AutoMapper;
using Report.API.Cache.RedisCache;
using Report.API.Data.Repository.Interfaces;
using Report.API.Domain.Dto;
using Report.API.Domain.Entities;
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
        private readonly ICacheProvider _cacheProvider;
        private readonly ICalculationService _calculationService;
        //private readonly IReportRequestSender _reportRequestSender;

        public ElectionService(ICandidateRepository candidateRepository, IVoteRepository voteRepository,
            ICacheProvider cacheProvider, ICalculationService calculationService)
        {
            _candidateRepository = candidateRepository;
            _voteRepository = voteRepository;
            _cacheProvider = cacheProvider;
            _calculationService = calculationService;
            _calculationService.OnNewResultsCalculated += _calculationService_OnNewResultsCalculated;
        }

        private void _calculationService_OnNewResultsCalculated(object sender, Domain.EventHandlers.VotingEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _calculationService_OnNewResultsArrived(object sender, Domain.EventHandlers.VotingEventArgs e)
        {
            throw new NotImplementedException();
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