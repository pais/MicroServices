using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class DetailNotificationDto
    {
        public Guid ContactId { get; set; }
        public Guid DetailId { get; set; }
        public string Location { get; set; }
    }
}
