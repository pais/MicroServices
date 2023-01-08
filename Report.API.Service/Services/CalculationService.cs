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
        private readonly ICacheProvider _cacheProvider;
        private readonly IMapper _mapper;

        public CalculationService(IMapper mapper, ICacheProvider cacheProvider)
        {
            _mapper = mapper;
            _cacheProvider = cacheProvider;
        }

        public event EventHandler<VotingEventArgs> OnNewResultsCalculated;

        public async Task AddVoting(VoteCacheDto vote)
        {
            var cache = await _cacheProvider.GetFromCache<ElectionReportDto>(Enums.DistirubedCacheKey.ElectionResult);

            ElectionReportDto electionReport;

            if (cache != null)
            {
                electionReport = UpdateCache(cache, vote);
            }
            else
            {
                electionReport = new ElectionReportDto
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
            }

            await _cacheProvider.SetCache(Enums.DistirubedCacheKey.ElectionResult, electionReport,
                new DistributedCacheEntryOptions());
        }

        private ElectionReportDto UpdateCache(ElectionReportDto report, VoteCacheDto vote)
        {
            report.DateTime = DateTime.Now;

            var candidateScore = report.Details.FirstOrDefault(x => x.CandidateId == vote.CandidateRef);
            if (candidateScore != null)
            {
                candidateScore.VoteCount += vote.VoteCount;
            }
            else
            {
                report.Details.Add(new ElectionReportDetailDto
                {
                    VoteCount = vote.VoteCount,
                    CandidateId = vote.CandidateRef,
                    CandidateName = vote.Name
                });
            }

            return report;
        }
    }
}