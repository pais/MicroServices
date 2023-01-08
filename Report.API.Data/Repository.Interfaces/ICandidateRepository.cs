using System.Threading.Tasks;
using System;

namespace Report.API.Data.Repository.Interfaces
{
    public interface ICandidateRepository : IRepository<Domain.Entities.Candidate>
    {
        Task<Domain.Entities.Candidate> GetByRefAsync(Guid candidateRef);
    }
}