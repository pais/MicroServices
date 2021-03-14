using Domain.Dto;
using System;
using System.Threading.Tasks;

namespace Contact.Api.Service.Interfaces
{
    public interface IReportHttpService
    {
        Task AddDetail(DetailNotificationDto detailNotification);
        Task DeleteDetail(Guid detailId);
    }
}
