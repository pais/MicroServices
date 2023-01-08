using System;
using System.Collections.Generic;

namespace Report.API.Domain.Dto
{
    public class ElectionReportDto
    {
        public DateTime DateTime { get; set; }
        public List<ElectionReportDetailDto> Details { get; set; }
    }
}