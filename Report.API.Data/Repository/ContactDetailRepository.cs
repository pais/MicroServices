using Report.API.Data.Repository.Interfaces;
using Report.API.Domain.Entities;

namespace Report.API.Data.Repository
{
    public class ContactDetailRepository : Repository<ContactDetail>, IContactDetailRepository
    {
        public ContactDetailRepository(PostgreSqlReportDbContext reportDbContext) : base(reportDbContext)
        {
        }
    }
}