using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.API.Domain.Dto
{
    public class ReportDetailDto
    {
        public string Location { get; set; }
        public int ContactCount { get; set; }
        public int PhoneCount { get; set; }
    }
}
