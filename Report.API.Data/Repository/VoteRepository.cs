using Report.API.Data.Repository.Interfaces;

namespace Report.API.Data.Repository
{
    public class VoteRepository : Repository<Domain.Entities.Vote>, IVoteRepository
    {
        public VoteRepository(PostgreSqlReportDbContext reportDbContext) : base(reportDbContext)
        {
        }
    }
}