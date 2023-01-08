using Report.API.Domain.Dto;
using Report.API.Domain.EventHandlers;
using System;
using System.Threading.Tasks;

namespace Report.API.Service.Interfaces
{
    public interface ICalculationService
    {
        event EventHandler<VotingEventArgs> OnNewResultsCalculated;

        Task AddVoting(VoteCacheDto vote);
    }
}