using System;

namespace Report.API.Domain.Dto
{
    public class VoteDto
    {
        public Guid CandidateRef { get; set; }
        public int VoteCount { get; set; }
    }
}