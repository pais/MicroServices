using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Report.API.Domain.Dto;
using Report.API.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public Task<List<ReportDto>> Get()
        {
            return _reportService.GetAllReports();
        }

        [HttpGet("{id}")]
        public Task<ReportDetailDto> Get(Guid id)
        {
            return _reportService.GetReportDetail(id);
        }


        [HttpPost]
        public async Task Post([FromBody] string location)
        {

        }

        [HttpPost, Route("add-detail")]
        public async Task AddDetail([FromBody] DetailNotificationDto detailNotification)
        {
            await _reportService.AddDetail(detailNotification);
        }

        [HttpDelete("delete-detail/{id}")]
        public async Task DeleteDetail(Guid id)
        {
            await _reportService.DeleteDetail(id);
        }

    }
}
