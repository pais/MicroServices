using Domain.Dto;
using Report.API.Data.Repository.Interfaces;
using Report.API.Domain.Dto;
using Report.API.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.API.Service.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IContactDetailRepository _contactDetailRepository;
        public ReportService(IReportRepository reportRepository, IContactDetailRepository contactDetailRepository)
        {
            _reportRepository = reportRepository;
            _contactDetailRepository = contactDetailRepository;
        }
        public Task AddDetail(DetailNotificationDto detail)
        {
            throw new NotImplementedException();
        }

        public Task CreateReport(string location)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDetail(Guid detailId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReportDto>> GetAllReports()
        {
            throw new NotImplementedException();
        }

        public Task<ReportDetailDto> GetReportDetail(Guid reportId)
        {
            throw new NotImplementedException();
        }
    }
}
