using Report.API.Domain.Entites;
using System;
using System.Threading.Tasks;

namespace Report.API.Data.Repository.Interfaces
{
    public interface IReportRepository : IRepository<Domain.Entites.Report>
    {
    }
}
