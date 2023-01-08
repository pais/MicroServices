using Domain.Entities;
using System;

namespace Report.API.Domain.Entities
{
    public class Report : BaseEntity
    {
        public string Location { get; set; }
        public int ContactCount { get; set; }
        public int PhoneCount { get; set; }
        public DateTime RequestDate { get; set; }
        public byte ReportStatus { get; set; }
    }
}