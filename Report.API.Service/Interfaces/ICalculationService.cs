using Report.API.Domain.EventHandlers;
using System;

namespace Report.API.Service.Interfaces
{
    public interface ICalculationService
    {
        event EventHandler<VotingEventArgs> OnNewResultsCalculated;
    }
}