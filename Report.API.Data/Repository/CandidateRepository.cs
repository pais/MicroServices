using Microsoft.EntityFrameworkCore;
using Report.API.Data.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace Report.API.Data.Repository
{
    public class CandidateRepository : Repository<Domain.Entities.Candidate>, ICandidateRepository
    {
        public CandidateRepository(PostgreSqlReportDbContext reportDbContext) : base(reportDbContext)
        {
        }

        public async Task<Domain.Entities.Candidate> GetByRefAsync(Guid candidateRef)
        {
            return await reportDbContext.Candidate.FirstAsync(x => x.IsActive && x.Id == candidateRef);
        }
    }
}