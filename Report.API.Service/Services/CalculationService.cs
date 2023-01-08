using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Report.API.Cache.RedisCache;
using Report.API.Domain.Dto;
using Report.API.Domain.EventHandlers;
using Report.API.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.API.Service.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly IMapper _mapper;
        private readonly ICacheProvider _cacheProvider;

        public event EventHandler<VotingEventArgs> OnNewResultsCalculated;

        public CalculationService(IMapper mapper, ICacheProvider cacheProvider)
        {
            _mapper = mapper;
            _cacheProvider = cacheProvider;
        }

        public async Task AddVoting(VoteCacheDto vote)
        {
            var cache = await _cacheProvider.GetFromCache<ElectionReportDto>(Enums.DistirubedCacheKey.ElectionResult);

            if (cache != null)
            {

                cache.DateTime = DateTime.Now;

                var candidateScore = cache.Details.FirstOrDefault(x => x.CandidateId == vote.CandidateRef);
                if (candidateScore != null)
                {
                    candidateScore.VoteCount += vote.VoteCount;
                }
                else
                {
                    cache.Details.Add(new ElectionReportDetailDto
                    {
                        VoteCount = vote.VoteCount,
                        CandidateId = vote.CandidateRef,
                        CandidateName = vote.Name
                    });
                }

                await _cacheProvider.SetCache(Enums.DistirubedCacheKey.ElectionResult, cache,
                    new DistributedCacheEntryOptions());
            }
            else
            {
                var report = new ElectionReportDto
                {
                    DateTime = DateTime.Now,
                    Details = new List<ElectionReportDetailDto>
                    {
                        new()
                        {
                            VoteCount = vote.VoteCount,
                            CandidateId = vote.CandidateRef,
                            CandidateName = vote.Name
                        }
                    }
                };

                await _cacheProvider.SetCache(Enums.DistirubedCacheKey.ElectionResult, report,
                    new DistributedCacheEntryOptions());
            }
        }
    }
}