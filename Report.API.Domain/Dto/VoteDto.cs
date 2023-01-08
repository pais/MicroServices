using System;

namespace Report.API.Domain.Dto
{
    public class VoteDto
    {
        public Guid CandidateId { get; set; }
        public int VoteCount { get; set; }
    }
}