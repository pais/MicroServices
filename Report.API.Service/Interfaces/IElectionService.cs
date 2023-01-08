using Report.API.Domain.Dto;
using System.Threading.Tasks;

namespace Report.API.Service.Interfaces
{
    public interface IElectionService
    {
        Task AddVote(VoteDto vote);

        Task<ElectionReportDto> GetCurrentResult();
    }
}