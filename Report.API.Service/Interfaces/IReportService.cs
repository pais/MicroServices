using Domain.Dto;
using Report.API.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.API.Service.Interfaces
{
    public interface IReportService
    {
        Task AddDetail(DetailNotificationDto detail);

        Task DeleteDetail(Guid detailId);

        Task CreateReport(string location);

        Task<List<ReportDto>> GetAllReports();

        Task<ReportDetailDto> GetReportDetail(Guid reportId);
    }
}