using Domain.Entities;
using System;

namespace Report.API.Domain.Entities
{
    public class Vote : BaseEntity
    {
        public Guid CandidateRef { get; set; }
        public int VoteCount { get; set; }
    }
}