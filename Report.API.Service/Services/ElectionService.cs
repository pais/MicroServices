using Report.API.Data.Repository.Interfaces;
using Report.API.Domain.Dto;
using Report.API.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Report.API.Service.Services
{
    public class ElectionService : IElectionService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IContactDetailRepository _contactDetailRepository;
        public ElectionService(IReportRepository reportRepository, IContactDetailRepository contactDetailRepository)
        {
            _reportRepository = reportRepository;
            _contactDetailRepository = contactDetailRepository;
        }

        public Task AddVote(VoteDto vote)
        {
            throw new NotImplementedException();
        }

        public Task<ElectionReportDto> GetCurrentResult()
        {
            throw new NotImplementedException();
        }
    }
}
