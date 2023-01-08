using Contact.Api.Service.Interfaces;
using Domain.Dto;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Api.Service.Services
{
    public class ReportHttpService : IReportHttpService
    {
        private HttpClient _client { get; }

        public ReportHttpService(HttpClient client)
        {
            _client = client;
        }

        public async Task AddDetail(DetailNotificationDto detailNotification)
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(detailNotification), Encoding.UTF8, "application/json");

            await _client.PostAsync($"report/add-detail", stringContent);
        }

        public async Task DeleteDetail(Guid detailId)
        {
            await _client.DeleteAsync($"report/delete-detail/{detailId}");
        }
    }
}