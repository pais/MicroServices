using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Report.API.Domain.Dto;
using Report.API.Messaging.Sender;
using Report.API.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IReportRequestSender _reportRequestSender;

        public ReportController(IReportService reportService, IReportRequestSender reportRequestSender)
        {
            _reportService = reportService;
            _reportRequestSender = reportRequestSender;
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
        public async Task Post(string location)
        {
            await _reportRequestSender.SendReportRequest(location);
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

        [HttpPost, Route("send-vote")]
        public async Task SendVote(string Vote)
        {
            await _reportRequestSender.SendVote(Vote);
        }
    }
}