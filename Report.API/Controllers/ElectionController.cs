using Microsoft.AspNetCore.Mvc;
using Report.API.Domain.Dto;
using Report.API.Service.Interfaces;
using System.Threading.Tasks;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectionController : ControllerBase
    {
        private readonly IElectionService _electionService;

        public ElectionController(IElectionService electionService)
        {
            _electionService = electionService;
        }

        [HttpGet]
        public Task<ElectionReportDto> Get()
        {
            return _electionService.GetCurrentResult();
        }

        [HttpPost]
        public async Task Post(VoteDto vote)
        {
            await _electionService.AddVote(vote);
        }
    }
}