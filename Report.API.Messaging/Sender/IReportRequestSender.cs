using System.Threading.Tasks;

namespace Report.API.Messaging.Sender
{
    public interface IReportRequestSender
    {
        Task SendReportRequest(string location);
    }
}