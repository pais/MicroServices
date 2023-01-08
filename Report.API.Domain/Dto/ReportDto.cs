using System;
using static Report.API.Domain.Dto.Enums;

namespace Report.API.Domain.Dto
{
    public class ReportDto
    {
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        public ReportStatus Status { get; set; }
    }
}