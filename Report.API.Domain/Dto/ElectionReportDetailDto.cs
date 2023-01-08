using System;

namespace Report.API.Domain.Dto
{
    public class ElectionReportDetailDto
    {
        public Guid CandidateId { get; set; }
        public string CandidateName { get; set; }
        public int VoteCount { get; set; }
    }
}
