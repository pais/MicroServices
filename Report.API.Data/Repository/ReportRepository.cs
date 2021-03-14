using Report.API.Data.Repository.Interfaces;

namespace Report.API.Data.Repository
{
    public class ReportRepository : Repository<Domain.Entites.Report>, IReportRepository
    {
        public ReportRepository(PostgreSqlReportDbContext reportDbContext) : base(reportDbContext)
        {

        }
    }
}
