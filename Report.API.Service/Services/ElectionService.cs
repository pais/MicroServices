using AutoMapper;
using Report.API.Cache.RedisCache;
using Report.API.Data.Repository.Interfaces;
using Report.API.Domain.Dto;
using Report.API.Domain.Entities;
using Report.API.Service.Interfaces;
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

        public ElectionService(ICandidateRepository candidateRepository, IVoteRepository voteRepository,
            ICacheProvider cacheProvider, ICalculationService calculationService, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _voteRepository = voteRepository;
            _cacheProvider = cacheProvider;
            _calculationService = calculationService;
            _mapper = mapper;
        }

        public async Task AddVote(VoteDto vote)
        {
            var candidate = await _candidateRepository.GetByRefAsync(vote.CandidateRef);

            await _voteRepository.AddAsync(_mapper.Map<Vote>(vote));

            await _calculationService.AddVoting(new VoteCacheDto
            {
                CandidateRef = vote.CandidateRef,
                Name = candidate.Name,
                VoteCount = vote.VoteCount
            });
        }

        public Task<ElectionReportDto> GetCurrentResult()
        {
            //TODO db check
            return _cacheProvider.GetFromCache<ElectionReportDto>(Enums.DistirubedCacheKey.ElectionResult);
        }
    }
}