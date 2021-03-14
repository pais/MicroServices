using Report.API.Data;
using Report.API.Data.Repository;
using Report.API.Data.Repository.Interfaces;
using Report.API.Domain.Entites;

namespace Report.API.Data.Repository
{
    public class ContactDetailRepository : Repository<ContactDetail>, IContactDetailRepository
    {
        public ContactDetailRepository(PostgreSqlReportDbContext reportDbContext) : base(reportDbContext)
        {

        }
    }
}
