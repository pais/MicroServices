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

            try
            {
                HttpResponseMessage response = await _client.PostAsync($"report/", stringContent);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {

                throw;
            }


            //if (response.IsSuccessStatusCode)
            //{
            //    response.Content.Dispose();
            //    return JsonConvert.DeserializeObject<Product>(content);
            //}
            //throw new Exception("Product service connection error");
        }

        public Task DeleteDetail(Guid detailId)
        {
            throw new NotImplementedException();
        }


    }
}
