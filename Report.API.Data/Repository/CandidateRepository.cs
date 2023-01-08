using Report.API.Data.Repository.Interfaces;

namespace Report.API.Data.Repository
{
    public class CandidateRepository : Repository<Domain.Entities.Candidate>, ICandidateRepository
    {
        public CandidateRepository(PostgreSqlReportDbContext reportDbContext) : base(reportDbContext)
        {
        }
    }
}