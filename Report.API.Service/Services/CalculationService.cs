using AutoMapper;
using Report.API.Cache.RedisCache;
using Report.API.Domain.EventHandlers;
using Report.API.Service.Interfaces;
using System;

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
    }
}