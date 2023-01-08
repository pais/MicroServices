using Report.API.Domain.Dto;
using System;

namespace Report.API.Domain.EventHandlers
{
    public class VotingEventArgs : EventArgs
    {
        public VoteDto Vote { get; set; }
    }
}