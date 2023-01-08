using System;

namespace Domain.Dto
{
    public class DetailNotificationDto
    {
        public Guid ContactId { get; set; }
        public Guid DetailId { get; set; }
        public string Location { get; set; }
    }
}